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
   public class dpfacturaestatusfiltrado : GXProcedure
   {
      public dpfacturaestatusfiltrado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpfacturaestatusfiltrado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<int> aP2_ListaUsuarios ,
                           out GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem> aP3_Gxm2rootcol )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV8ListaUsuarios = aP2_ListaUsuarios;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem>( context, "SDTFacturaEstatusItem", "Premios") ;
         initialize();
         ExecuteImpl();
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem> executeUdp( DateTime aP0_FromDate ,
                                                                                      DateTime aP1_ToDate ,
                                                                                      GxSimpleCollection<int> aP2_ListaUsuarios )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_ListaUsuarios, out aP3_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<int> aP2_ListaUsuarios ,
                                 out GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem> aP3_Gxm2rootcol )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV8ListaUsuarios = aP2_ListaUsuarios;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem>( context, "SDTFacturaEstatusItem", "Premios") ;
         SubmitImpl();
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdtfacturaestatus = new SdtSDTFacturaEstatus_SDTFacturaEstatusItem(context);
         Gxm2rootcol.Add(Gxm1sdtfacturaestatus, 0);
         Gxm1sdtfacturaestatus.gxTpr_Estatus = "Aprobada";
         GXt_int1 = 0;
         new getcantidadporestatusfiltrado(context ).execute(  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_int1) ;
         Gxm1sdtfacturaestatus.gxTpr_Cantidad = GXt_int1;
         Gxm1sdtfacturaestatus = new SdtSDTFacturaEstatus_SDTFacturaEstatusItem(context);
         Gxm2rootcol.Add(Gxm1sdtfacturaestatus, 0);
         Gxm1sdtfacturaestatus.gxTpr_Estatus = "En Proceso";
         GXt_int1 = 0;
         new getcantidadporestatusfiltrado(context ).execute(  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_int1) ;
         Gxm1sdtfacturaestatus.gxTpr_Cantidad = GXt_int1;
         Gxm1sdtfacturaestatus = new SdtSDTFacturaEstatus_SDTFacturaEstatusItem(context);
         Gxm2rootcol.Add(Gxm1sdtfacturaestatus, 0);
         Gxm1sdtfacturaestatus.gxTpr_Estatus = "Rechazada";
         GXt_int1 = 0;
         new getcantidadporestatusfiltrado(context ).execute(  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_int1) ;
         Gxm1sdtfacturaestatus.gxTpr_Cantidad = GXt_int1;
         Gxm1sdtfacturaestatus = new SdtSDTFacturaEstatus_SDTFacturaEstatusItem(context);
         Gxm2rootcol.Add(Gxm1sdtfacturaestatus, 0);
         Gxm1sdtfacturaestatus.gxTpr_Estatus = "Cancelada";
         GXt_int1 = 0;
         new getcantidadporestatusfiltrado(context ).execute(  "Cancelada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_int1) ;
         Gxm1sdtfacturaestatus.gxTpr_Cantidad = GXt_int1;
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
         Gxm1sdtfacturaestatus = new SdtSDTFacturaEstatus_SDTFacturaEstatusItem(context);
         /* GeneXus formulas. */
      }

      private long GXt_int1 ;
      private DateTime AV6FromDate ;
      private DateTime AV7ToDate ;
      private GxSimpleCollection<int> AV8ListaUsuarios ;
      private GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem> Gxm2rootcol ;
      private SdtSDTFacturaEstatus_SDTFacturaEstatusItem Gxm1sdtfacturaestatus ;
      private GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem> aP3_Gxm2rootcol ;
   }

}
