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
   public class dpfacturaestatusfiltradonew : GXProcedure
   {
      public dpfacturaestatusfiltradonew( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpfacturaestatusfiltradonew( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<int> aP2_ListaUsuarios ,
                           GxSimpleCollection<int> aP3_PromocionID ,
                           string aP4_FacturaNo ,
                           string aP5_FiltroEstatus ,
                           out GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem> aP6_Gxm2rootcol )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV8ListaUsuarios = aP2_ListaUsuarios;
         this.AV9PromocionID = aP3_PromocionID;
         this.AV10FacturaNo = aP4_FacturaNo;
         this.AV12FiltroEstatus = aP5_FiltroEstatus;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem>( context, "SDTFacturaEstatusItem", "Premios") ;
         initialize();
         ExecuteImpl();
         aP6_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem> executeUdp( DateTime aP0_FromDate ,
                                                                                      DateTime aP1_ToDate ,
                                                                                      GxSimpleCollection<int> aP2_ListaUsuarios ,
                                                                                      GxSimpleCollection<int> aP3_PromocionID ,
                                                                                      string aP4_FacturaNo ,
                                                                                      string aP5_FiltroEstatus )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_ListaUsuarios, aP3_PromocionID, aP4_FacturaNo, aP5_FiltroEstatus, out aP6_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<int> aP2_ListaUsuarios ,
                                 GxSimpleCollection<int> aP3_PromocionID ,
                                 string aP4_FacturaNo ,
                                 string aP5_FiltroEstatus ,
                                 out GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem> aP6_Gxm2rootcol )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV8ListaUsuarios = aP2_ListaUsuarios;
         this.AV9PromocionID = aP3_PromocionID;
         this.AV10FacturaNo = aP4_FacturaNo;
         this.AV12FiltroEstatus = aP5_FiltroEstatus;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem>( context, "SDTFacturaEstatusItem", "Premios") ;
         SubmitImpl();
         aP6_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdtfacturaestatus = new SdtSDTFacturaEstatus_SDTFacturaEstatusItem(context);
         Gxm2rootcol.Add(Gxm1sdtfacturaestatus, 0);
         Gxm1sdtfacturaestatus.gxTpr_Estatus = "Aprobada";
         GXt_int1 = 0;
         new getcantidadporestatusfiltradonew(context ).execute(  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV9PromocionID,  AV10FacturaNo,  AV12FiltroEstatus, out  GXt_int1) ;
         Gxm1sdtfacturaestatus.gxTpr_Cantidad = GXt_int1;
         Gxm1sdtfacturaestatus = new SdtSDTFacturaEstatus_SDTFacturaEstatusItem(context);
         Gxm2rootcol.Add(Gxm1sdtfacturaestatus, 0);
         Gxm1sdtfacturaestatus.gxTpr_Estatus = "En Proceso";
         GXt_int1 = 0;
         new getcantidadporestatusfiltradonew(context ).execute(  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV9PromocionID,  AV10FacturaNo,  AV12FiltroEstatus, out  GXt_int1) ;
         Gxm1sdtfacturaestatus.gxTpr_Cantidad = GXt_int1;
         Gxm1sdtfacturaestatus = new SdtSDTFacturaEstatus_SDTFacturaEstatusItem(context);
         Gxm2rootcol.Add(Gxm1sdtfacturaestatus, 0);
         Gxm1sdtfacturaestatus.gxTpr_Estatus = "Rechazada";
         GXt_int1 = 0;
         new getcantidadporestatusfiltradonew(context ).execute(  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV9PromocionID,  AV10FacturaNo,  AV12FiltroEstatus, out  GXt_int1) ;
         Gxm1sdtfacturaestatus.gxTpr_Cantidad = GXt_int1;
         Gxm1sdtfacturaestatus = new SdtSDTFacturaEstatus_SDTFacturaEstatusItem(context);
         Gxm2rootcol.Add(Gxm1sdtfacturaestatus, 0);
         Gxm1sdtfacturaestatus.gxTpr_Estatus = "Cancelada";
         GXt_int1 = 0;
         new getcantidadporestatusfiltradonew(context ).execute(  "Cancelada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV9PromocionID,  AV10FacturaNo,  AV12FiltroEstatus, out  GXt_int1) ;
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
      private string AV10FacturaNo ;
      private string AV12FiltroEstatus ;
      private DateTime AV6FromDate ;
      private DateTime AV7ToDate ;
      private GxSimpleCollection<int> AV8ListaUsuarios ;
      private GxSimpleCollection<int> AV9PromocionID ;
      private GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem> Gxm2rootcol ;
      private SdtSDTFacturaEstatus_SDTFacturaEstatusItem Gxm1sdtfacturaestatus ;
      private GXBaseCollection<SdtSDTFacturaEstatus_SDTFacturaEstatusItem> aP6_Gxm2rootcol ;
   }

}
