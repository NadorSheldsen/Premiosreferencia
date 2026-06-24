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
   public class dpgraficafacturaspormes : GXProcedure
   {
      public dpgraficafacturaspormes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpgraficafacturaspormes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_Year ,
                           out GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP1_Gxm2rootcol )
      {
         this.AV6Year = aP0_Year;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem>( context, "SDTGraficaFacturasPorMesItem", "Premios") ;
         initialize();
         ExecuteImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> executeUdp( short aP0_Year )
      {
         execute(aP0_Year, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( short aP0_Year ,
                                 out GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP1_Gxm2rootcol )
      {
         this.AV6Year = aP0_Year;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem>( context, "SDTGraficaFacturasPorMesItem", "Premios") ;
         SubmitImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Enero", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  1,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  1,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  1,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Febrero", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  2,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  2,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  2,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Marzo", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  3,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  3,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  3,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Abril", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  4,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  4,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  4,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Mayo", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  5,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  5,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  5,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Junio", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  6,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  6,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  6,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Julio", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  7,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  7,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  7,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Agosto", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  8,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  8,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  8,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Septiembre", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  9,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  9,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  9,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Octubre", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  10,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  10,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  10,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Noviembre", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  11,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  11,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  11,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = GXt_decimal1;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Diciembre", "");
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  12,  AV6Year,  "Aprobada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  12,  AV6Year,  "Rechazada", out  GXt_decimal1) ;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = GXt_decimal1;
         GXt_decimal1 = 0;
         new calculartotalbonopormesestatus(context ).execute(  12,  AV6Year,  "En Proceso", out  GXt_decimal1) ;
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

      private short AV6Year ;
      private decimal GXt_decimal1 ;
      private GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> Gxm2rootcol ;
      private SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem Gxm1sdtgraficafacturaspormes ;
      private GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP1_Gxm2rootcol ;
   }

}
