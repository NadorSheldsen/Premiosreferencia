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
   public class dpgraficafacturaspormesfiltrado : GXProcedure
   {
      public dpgraficafacturaspormesfiltrado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpgraficafacturaspormesfiltrado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<int> aP2_ListaUsuarios ,
                           out GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP3_Gxm2rootcol )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV8ListaUsuarios = aP2_ListaUsuarios;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem>( context, "SDTGraficaFacturasPorMesItem", "Premios") ;
         initialize();
         ExecuteImpl();
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> executeUdp( DateTime aP0_FromDate ,
                                                                                                    DateTime aP1_ToDate ,
                                                                                                    GxSimpleCollection<int> aP2_ListaUsuarios )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_ListaUsuarios, out aP3_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<int> aP2_ListaUsuarios ,
                                 out GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP3_Gxm2rootcol )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV8ListaUsuarios = aP2_ListaUsuarios;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem>( context, "SDTGraficaFacturasPorMesItem", "Premios") ;
         SubmitImpl();
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Enero", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  1,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  1,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  1,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Febrero", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  2,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  2,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  2,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Marzo", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  3,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  3,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  3,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Abril", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  4,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  4,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  4,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Mayo", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  5,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  5,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  5,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Junio", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  6,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  6,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  6,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Julio", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  7,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  7,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  7,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Agosto", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  8,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  8,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  8,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Septiembre", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  9,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  9,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  9,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Octubre", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  10,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  10,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  10,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Noviembre", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  11,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  11,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  11,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Diciembre", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  12,  "Aprobada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  12,  "Rechazada",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatusfiltrado(context ).execute(  12,  "En Proceso",  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios, out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
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
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         /* GeneXus formulas. */
      }

      private decimal GXt_decimal1 ;
      private DateTime AV6FromDate ;
      private DateTime AV7ToDate ;
      private GxSimpleCollection<int> AV8ListaUsuarios ;
      private GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> Gxm2rootcol ;
      private SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem Gxm1sdtgraficafacturaspormes ;
      private GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP3_Gxm2rootcol ;
   }

}
