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
   public class dpgraficafacturaspormesfiltradonew : GXProcedure
   {
      public dpgraficafacturaspormesfiltradonew( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpgraficafacturaspormesfiltradonew( IGxContext context )
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
                           out GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP6_Gxm2rootcol )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV8ListaUsuarios = aP2_ListaUsuarios;
         this.AV10PromocionID = aP3_PromocionID;
         this.AV11FacturaNo = aP4_FacturaNo;
         this.AV12FiltroEstatus = aP5_FiltroEstatus;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem>( context, "SDTGraficaFacturasPorMesItem", "Premios") ;
         initialize();
         ExecuteImpl();
         aP6_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> executeUdp( DateTime aP0_FromDate ,
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
                                 out GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP6_Gxm2rootcol )
      {
         this.AV6FromDate = aP0_FromDate;
         this.AV7ToDate = aP1_ToDate;
         this.AV8ListaUsuarios = aP2_ListaUsuarios;
         this.AV10PromocionID = aP3_PromocionID;
         this.AV11FacturaNo = aP4_FacturaNo;
         this.AV12FiltroEstatus = aP5_FiltroEstatus;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem>( context, "SDTGraficaFacturasPorMesItem", "Premios") ;
         SubmitImpl();
         aP6_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Enero", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  1,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Febrero", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  2,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Marzo", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  3,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Abril", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  4,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Mayo", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  5,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Junio", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  6,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Julio", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  7,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Agosto", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  8,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Septiembre", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  9,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Octubre", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  10,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Noviembre", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  11,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
         Gxm1sdtgraficafacturaspormes = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(context);
         Gxm2rootcol.Add(Gxm1sdtgraficafacturaspormes, 0);
         Gxm1sdtgraficafacturaspormes.gxTpr_Mes = context.GetMessage( "Diciembre", "");
         GXt_SdtSDTTotalesBonoMes1 = AV13Tot;
         new calculartotalbonopormesestatusfiltradonew(context ).execute(  12,  AV6FromDate,  AV7ToDate,  AV8ListaUsuarios,  AV10PromocionID,  AV11FacturaNo,  AV12FiltroEstatus, out  GXt_SdtSDTTotalesBonoMes1) ;
         AV13Tot = GXt_SdtSDTTotalesBonoMes1;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoaprobada = AV13Tot.gxTpr_Montoaprobado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montorechazada = AV13Tot.gxTpr_Montorechazado;
         Gxm1sdtgraficafacturaspormes.gxTpr_Montoenproceso = AV13Tot.gxTpr_Montoenproceso;
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
         AV13Tot = new SdtSDTTotalesBonoMes(context);
         GXt_SdtSDTTotalesBonoMes1 = new SdtSDTTotalesBonoMes(context);
         /* GeneXus formulas. */
      }

      private string AV11FacturaNo ;
      private string AV12FiltroEstatus ;
      private DateTime AV6FromDate ;
      private DateTime AV7ToDate ;
      private GxSimpleCollection<int> AV8ListaUsuarios ;
      private GxSimpleCollection<int> AV10PromocionID ;
      private GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> Gxm2rootcol ;
      private SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem Gxm1sdtgraficafacturaspormes ;
      private SdtSDTTotalesBonoMes AV13Tot ;
      private SdtSDTTotalesBonoMes GXt_SdtSDTTotalesBonoMes1 ;
      private GXBaseCollection<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem> aP6_Gxm2rootcol ;
   }

}
