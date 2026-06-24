using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class GxFullTextSearchReindexer
   {
      public static int Reindex( IGxContext context )
      {
         GxSilentTrnSdt obj;
         IGxSilentTrn trn;
         bool result;
         obj = new SdtCiudad(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtEscolaridad(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtDistribuidor(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtPuesto(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtMedida(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtMotivoRechazo(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtModelo(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtEstado(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtPais(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtPromocionDistribuidor(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtPromocionModelo(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtPromocion(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtFactura(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtUsuario(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtDistribuidoresUsuario(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtFacturaMedida(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtTrnDirectiva(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         return 1 ;
      }

   }

}
