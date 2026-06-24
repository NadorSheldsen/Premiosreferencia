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
   public class dpgraficafacturaspormesfiltradodinamico : GXProcedure
   {
      public dpgraficafacturaspormesfiltradodinamico( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpgraficafacturaspormesfiltradodinamico( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<int> aP2_ListaUsuarios ,
                           out GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP3_Gxm1rootcol )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV8ListaUsuarios = aP2_ListaUsuarios;
         this.Gxm1rootcol = new GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem>( context, "SDTGraficaFacturasPorMesItem", "Premios") ;
         initialize();
         ExecuteImpl();
         aP3_Gxm1rootcol=this.Gxm1rootcol;
      }

      public GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> executeUdp( DateTime aP0_FromDate ,
                                                                                                    DateTime aP1_ToDate ,
                                                                                                    GxSimpleCollection<int> aP2_ListaUsuarios )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_ListaUsuarios, out aP3_Gxm1rootcol);
         return Gxm1rootcol ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<int> aP2_ListaUsuarios ,
                                 out GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP3_Gxm1rootcol )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV8ListaUsuarios = aP2_ListaUsuarios;
         this.Gxm1rootcol = new GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem>( context, "SDTGraficaFacturasPorMesItem", "Premios") ;
         SubmitImpl();
         aP3_Gxm1rootcol=this.Gxm1rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         /* GeneXus formulas. */
      }

      private DateTime AV6FromDate ;
      private DateTime AV7ToDate ;
      private GxSimpleCollection<int> AV8ListaUsuarios ;
      private GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> Gxm1rootcol ;
      private GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP3_Gxm1rootcol ;
   }

}
