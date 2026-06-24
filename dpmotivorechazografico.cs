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
   public class dpmotivorechazografico : GXProcedure
   {
      public dpmotivorechazografico( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpmotivorechazografico( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem>( context, "SDTMotivoRechazoItem", "Premios") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem>( context, "SDTMotivoRechazoItem", "Premios") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P000G2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A20MotivoRechazoDescripcion = P000G2_A20MotivoRechazoDescripcion[0];
            A19MotivoRechazoID = P000G2_A19MotivoRechazoID[0];
            Gxm1sdtmotivorechazografico = new SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem(context);
            Gxm2rootcol.Add(Gxm1sdtmotivorechazografico, 0);
            Gxm1sdtmotivorechazografico.gxTpr_Motivorechazodescripcion = A20MotivoRechazoDescripcion;
            GXt_int1 = 0;
            new obtienecantidadmotivorechazo(context ).execute(  A19MotivoRechazoID, out  GXt_int1) ;
            Gxm1sdtmotivorechazografico.gxTpr_Cantidad = GXt_int1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
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
         P000G2_A20MotivoRechazoDescripcion = new string[] {""} ;
         P000G2_A19MotivoRechazoID = new int[1] ;
         A20MotivoRechazoDescripcion = "";
         Gxm1sdtmotivorechazografico = new SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpmotivorechazografico__default(),
            new Object[][] {
                new Object[] {
               P000G2_A20MotivoRechazoDescripcion, P000G2_A19MotivoRechazoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int1 ;
      private int A19MotivoRechazoID ;
      private string A20MotivoRechazoDescripcion ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private string[] P000G2_A20MotivoRechazoDescripcion ;
      private int[] P000G2_A19MotivoRechazoID ;
      private SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem Gxm1sdtmotivorechazografico ;
      private GXBaseCollection<SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem> aP0_Gxm2rootcol ;
   }

   public class dpmotivorechazografico__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoID` FROM `MotivoRechazo` ORDER BY `MotivoRechazoID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
