using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class dpsegmento : GXProcedure
   {
      public dpsegmento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpsegmento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtSDTSegmentos_Segmento> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTSegmentos_Segmento>( context, "Segmento", "Premios") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTSegmentos_Segmento> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTSegmentos_Segmento> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTSegmentos_Segmento>( context, "Segmento", "Premios") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdtsegmentos = new SdtSDTSegmentos_Segmento(context);
         Gxm2rootcol.Add(Gxm1sdtsegmentos, 0);
         Gxm1sdtsegmentos.gxTpr_Segmento = "AUTO";
         Gxm1sdtsegmentos = new SdtSDTSegmentos_Segmento(context);
         Gxm2rootcol.Add(Gxm1sdtsegmentos, 0);
         Gxm1sdtsegmentos.gxTpr_Segmento = "CAMIONETA";
         Gxm1sdtsegmentos = new SdtSDTSegmentos_Segmento(context);
         Gxm2rootcol.Add(Gxm1sdtsegmentos, 0);
         Gxm1sdtsegmentos.gxTpr_Segmento = "CAMIÓN";
         Gxm1sdtsegmentos = new SdtSDTSegmentos_Segmento(context);
         Gxm2rootcol.Add(Gxm1sdtsegmentos, 0);
         Gxm1sdtsegmentos.gxTpr_Segmento = "AGRÍCOLA";
         Gxm1sdtsegmentos = new SdtSDTSegmentos_Segmento(context);
         Gxm2rootcol.Add(Gxm1sdtsegmentos, 0);
         Gxm1sdtsegmentos.gxTpr_Segmento = "INDUSTRIAL";
         Gxm1sdtsegmentos = new SdtSDTSegmentos_Segmento(context);
         Gxm2rootcol.Add(Gxm1sdtsegmentos, 0);
         Gxm1sdtsegmentos.gxTpr_Segmento = "OTR";
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
         Gxm1sdtsegmentos = new SdtSDTSegmentos_Segmento(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtSDTSegmentos_Segmento> Gxm2rootcol ;
      private SdtSDTSegmentos_Segmento Gxm1sdtsegmentos ;
      private GXBaseCollection<SdtSDTSegmentos_Segmento> aP0_Gxm2rootcol ;
   }

}
