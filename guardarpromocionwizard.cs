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
   public class guardarpromocionwizard : GXProcedure
   {
      public guardarpromocionwizard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public guardarpromocionwizard( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtWPWizardPromoData aP0_WizardData ,
                           string aP1_PromocionArte ,
                           out string aP2_Resultado ,
                           out short aP3_ErrorCode )
      {
         this.AV8WizardData = aP0_WizardData;
         this.AV28PromocionArte = aP1_PromocionArte;
         this.AV9Resultado = "" ;
         this.AV26ErrorCode = 0 ;
         initialize();
         ExecuteImpl();
         aP2_Resultado=this.AV9Resultado;
         aP3_ErrorCode=this.AV26ErrorCode;
      }

      public short executeUdp( SdtWPWizardPromoData aP0_WizardData ,
                               string aP1_PromocionArte ,
                               out string aP2_Resultado )
      {
         execute(aP0_WizardData, aP1_PromocionArte, out aP2_Resultado, out aP3_ErrorCode);
         return AV26ErrorCode ;
      }

      public void executeSubmit( SdtWPWizardPromoData aP0_WizardData ,
                                 string aP1_PromocionArte ,
                                 out string aP2_Resultado ,
                                 out short aP3_ErrorCode )
      {
         this.AV8WizardData = aP0_WizardData;
         this.AV28PromocionArte = aP1_PromocionArte;
         this.AV9Resultado = "" ;
         this.AV26ErrorCode = 0 ;
         SubmitImpl();
         aP2_Resultado=this.AV9Resultado;
         aP3_ErrorCode=this.AV26ErrorCode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Resultado = "";
         AV26ErrorCode = 0;
         AV10Success = true;
         AV11Promocion = new SdtPromocion(context);
         AV11Promocion.gxTpr_Promociondescripcion = AV8WizardData.gxTpr_Infogeneral.gxTpr_Promodescripcion;
         AV11Promocion.gxTpr_Promocionbase = AV8WizardData.gxTpr_Infogeneral.gxTpr_Promobase;
         AV11Promocion.gxTpr_Promocionarte = AV8WizardData.gxTpr_Infogeneral.gxTpr_Promoarte;
         AV11Promocion.gxTpr_Promocionarte_gxi = GXDbFile.GetUriFromFile( "", "", AV8WizardData.gxTpr_Infogeneral.gxTpr_Promoarte);
         AV11Promocion.gxTpr_Promocionfechainicio = AV8WizardData.gxTpr_Infogeneral.gxTpr_Iniciopromo;
         AV11Promocion.gxTpr_Promocionfechafin = AV8WizardData.gxTpr_Infogeneral.gxTpr_Finpromo;
         AV30PromocionSegmentosJson = AV8WizardData.gxTpr_Segmentos.gxTpr_Grid.ToJSonString(false);
         AV11Promocion.gxTpr_Promocionsegmentosjson = AV30PromocionSegmentosJson;
         AV11Promocion.Save();
         if ( AV11Promocion.Fail() )
         {
            AV26ErrorCode = 1001;
            AV9Resultado = context.GetMessage( "Error al guardar la promoción: ", "");
            AV24Messages = AV11Promocion.GetMessages();
            AV27first = true;
            AV31GXV1 = 1;
            while ( AV31GXV1 <= AV24Messages.Count )
            {
               AV25Message = ((GeneXus.Utils.SdtMessages_Message)AV24Messages.Item(AV31GXV1));
               if ( AV27first )
               {
                  AV9Resultado += AV25Message.gxTpr_Description;
                  AV27first = false;
               }
               else
               {
                  AV9Resultado += "; " + AV25Message.gxTpr_Description;
               }
               AV31GXV1 = (int)(AV31GXV1+1);
            }
            cleanup();
            if (true) return;
         }
         AV13PromocionID = AV11Promocion.gxTpr_Promocionid;
         AV17PromoDistList = new GXBCCollection<SdtPromocionDistribuidor>( context, "PromocionDistribuidor", "Premios");
         AV21PromoModelList = new GXBCCollection<SdtPromocionModelo>( context, "PromocionModelo", "Premios");
         AV32GXV2 = 1;
         while ( AV32GXV2 <= AV8WizardData.gxTpr_Infogeneral.gxTpr_Distribuidorid.Count )
         {
            AV23DistribuidorID = (int)(AV8WizardData.gxTpr_Infogeneral.gxTpr_Distribuidorid.GetNumeric(AV32GXV2));
            if ( AV10Success )
            {
               AV16PromocionDistribuidor = new SdtPromocionDistribuidor(context);
               AV16PromocionDistribuidor.gxTpr_Promocionid = AV13PromocionID;
               AV16PromocionDistribuidor.gxTpr_Distribuidorid = AV23DistribuidorID;
               AV16PromocionDistribuidor.Save();
               if ( AV16PromocionDistribuidor.Fail() )
               {
                  AV10Success = false;
                  AV26ErrorCode = 2001;
                  AV9Resultado = context.GetMessage( "Error al guardar el distribuidor con ID: ", "") + StringUtil.Str( (decimal)(AV23DistribuidorID), 9, 0);
                  cleanup();
                  if (true) return;
               }
               else
               {
                  AV17PromoDistList.Add(AV16PromocionDistribuidor, 0);
               }
            }
            AV32GXV2 = (int)(AV32GXV2+1);
         }
         AV33GXV3 = 1;
         while ( AV33GXV3 <= AV8WizardData.gxTpr_Modelos.gxTpr_Grid.Count )
         {
            AV20ModeloRow = ((SdtWPWizardPromoData_Modelos_GridItem)AV8WizardData.gxTpr_Modelos.gxTpr_Grid.Item(AV33GXV3));
            if ( AV10Success )
            {
               AV19PromocionModelo = new SdtPromocionModelo(context);
               AV19PromocionModelo.gxTpr_Promocionid = AV13PromocionID;
               AV19PromocionModelo.gxTpr_Modeloid = AV20ModeloRow.gxTpr_Modeloid;
               AV19PromocionModelo.gxTpr_Promocionmodeloprecio = AV20ModeloRow.gxTpr_Precio;
               AV19PromocionModelo.Save();
               if ( AV19PromocionModelo.Fail() )
               {
                  AV10Success = false;
                  AV26ErrorCode = 3001;
                  AV9Resultado = context.GetMessage( "Error al guardar el modelo con ID: ", "") + StringUtil.Str( (decimal)(AV20ModeloRow.gxTpr_Modeloid), 9, 0);
                  cleanup();
                  if (true) return;
               }
               else
               {
                  AV21PromoModelList.Add(AV19PromocionModelo, 0);
               }
            }
            AV33GXV3 = (int)(AV33GXV3+1);
         }
         if ( ! AV10Success )
         {
            AV34GXV4 = 1;
            while ( AV34GXV4 <= AV21PromoModelList.Count )
            {
               AV22PM = ((SdtPromocionModelo)AV21PromoModelList.Item(AV34GXV4));
               AV22PM.Load(AV22PM.gxTpr_Promocionmodeloid);
               AV22PM.Delete();
               AV34GXV4 = (int)(AV34GXV4+1);
            }
            AV35GXV5 = 1;
            while ( AV35GXV5 <= AV17PromoDistList.Count )
            {
               AV18PD = ((SdtPromocionDistribuidor)AV17PromoDistList.Item(AV35GXV5));
               AV18PD.Load(AV18PD.gxTpr_Promociondistribuidorid);
               AV18PD.Delete();
               AV35GXV5 = (int)(AV35GXV5+1);
            }
            AV11Promocion.Delete();
            AV9Resultado = context.GetMessage( "Error general en el proceso, se revirtieron los cambios. Código de error: ", "") + StringUtil.Str( (decimal)(AV26ErrorCode), 4, 0);
         }
         else
         {
            context.CommitDataStores("guardarpromocionwizard",pr_default);
            AV26ErrorCode = 0;
            AV9Resultado = context.GetMessage( "La promoción fue guardada correctamente.", "");
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
         ExitApp();
      }

      public override void initialize( )
      {
         AV9Resultado = "";
         AV11Promocion = new SdtPromocion(context);
         AV30PromocionSegmentosJson = "";
         AV24Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV25Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV17PromoDistList = new GXBCCollection<SdtPromocionDistribuidor>( context, "PromocionDistribuidor", "Premios");
         AV21PromoModelList = new GXBCCollection<SdtPromocionModelo>( context, "PromocionModelo", "Premios");
         AV16PromocionDistribuidor = new SdtPromocionDistribuidor(context);
         AV20ModeloRow = new SdtWPWizardPromoData_Modelos_GridItem(context);
         AV19PromocionModelo = new SdtPromocionModelo(context);
         AV22PM = new SdtPromocionModelo(context);
         AV18PD = new SdtPromocionDistribuidor(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.guardarpromocionwizard__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26ErrorCode ;
      private int AV31GXV1 ;
      private int AV13PromocionID ;
      private int AV32GXV2 ;
      private int AV23DistribuidorID ;
      private int AV33GXV3 ;
      private int AV34GXV4 ;
      private int AV35GXV5 ;
      private bool AV10Success ;
      private bool AV27first ;
      private string AV30PromocionSegmentosJson ;
      private string AV9Resultado ;
      private string AV28PromocionArte ;
      private IGxDataStore dsDefault ;
      private SdtWPWizardPromoData AV8WizardData ;
      private SdtPromocion AV11Promocion ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV24Messages ;
      private GeneXus.Utils.SdtMessages_Message AV25Message ;
      private GXBCCollection<SdtPromocionDistribuidor> AV17PromoDistList ;
      private GXBCCollection<SdtPromocionModelo> AV21PromoModelList ;
      private SdtPromocionDistribuidor AV16PromocionDistribuidor ;
      private SdtWPWizardPromoData_Modelos_GridItem AV20ModeloRow ;
      private SdtPromocionModelo AV19PromocionModelo ;
      private SdtPromocionModelo AV22PM ;
      private SdtPromocionDistribuidor AV18PD ;
      private IDataStoreProvider pr_default ;
      private string aP2_Resultado ;
      private short aP3_ErrorCode ;
   }

   public class guardarpromocionwizard__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
