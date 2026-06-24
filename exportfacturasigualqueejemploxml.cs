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
   public class exportfacturasigualqueejemploxml : GXProcedure
   {
      public exportfacturasigualqueejemploxml( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public exportfacturasigualqueejemploxml( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<int> aP2_UsuariosFiltro ,
                           GxSimpleCollection<int> aP3_PromocionID ,
                           string aP4_FacturaNo ,
                           string aP5_FacturaEstatus )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         this.AV4UsuariosFiltro = aP2_UsuariosFiltro;
         this.AV5PromocionID = aP3_PromocionID;
         this.AV6FacturaNo = aP4_FacturaNo;
         this.AV7FacturaEstatus = aP5_FacturaEstatus;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<int> aP2_UsuariosFiltro ,
                                 GxSimpleCollection<int> aP3_PromocionID ,
                                 string aP4_FacturaNo ,
                                 string aP5_FacturaEstatus )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         this.AV4UsuariosFiltro = aP2_UsuariosFiltro;
         this.AV5PromocionID = aP3_PromocionID;
         this.AV6FacturaNo = aP4_FacturaNo;
         this.AV7FacturaEstatus = aP5_FacturaEstatus;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(DateTime)AV2FromDate,(DateTime)AV3ToDate,(GxSimpleCollection<int>)AV4UsuariosFiltro,(GxSimpleCollection<int>)AV5PromocionID,(string)AV6FacturaNo,(string)AV7FacturaEstatus} ;
         ClassLoader.Execute("aexportfacturasigualqueejemploxml","GeneXus.Programs","aexportfacturasigualqueejemploxml", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 6 ) )
         {
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
      }

      private string AV6FacturaNo ;
      private string AV7FacturaEstatus ;
      private DateTime AV2FromDate ;
      private DateTime AV3ToDate ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<int> AV4UsuariosFiltro ;
      private GxSimpleCollection<int> AV5PromocionID ;
      private Object[] args ;
   }

}
