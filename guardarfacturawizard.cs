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
   public class guardarfacturawizard : GXProcedure
   {
      public guardarfacturawizard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public guardarfacturawizard( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtWPFacturaWizardData aP0_WPFacturaWizardData ,
                           int aP1_UsuarioID ,
                           string aP2_FacturaPDF ,
                           out string aP3_Resultado ,
                           out short aP4_ErrorCode )
      {
         this.AV8WPFacturaWizardData = aP0_WPFacturaWizardData;
         this.AV22UsuarioID = aP1_UsuarioID;
         this.AV23FacturaPDF = aP2_FacturaPDF;
         this.AV10Resultado = "" ;
         this.AV11ErrorCode = 0 ;
         initialize();
         ExecuteImpl();
         aP3_Resultado=this.AV10Resultado;
         aP4_ErrorCode=this.AV11ErrorCode;
      }

      public short executeUdp( SdtWPFacturaWizardData aP0_WPFacturaWizardData ,
                               int aP1_UsuarioID ,
                               string aP2_FacturaPDF ,
                               out string aP3_Resultado )
      {
         execute(aP0_WPFacturaWizardData, aP1_UsuarioID, aP2_FacturaPDF, out aP3_Resultado, out aP4_ErrorCode);
         return AV11ErrorCode ;
      }

      public void executeSubmit( SdtWPFacturaWizardData aP0_WPFacturaWizardData ,
                                 int aP1_UsuarioID ,
                                 string aP2_FacturaPDF ,
                                 out string aP3_Resultado ,
                                 out short aP4_ErrorCode )
      {
         this.AV8WPFacturaWizardData = aP0_WPFacturaWizardData;
         this.AV22UsuarioID = aP1_UsuarioID;
         this.AV23FacturaPDF = aP2_FacturaPDF;
         this.AV10Resultado = "" ;
         this.AV11ErrorCode = 0 ;
         SubmitImpl();
         aP3_Resultado=this.AV10Resultado;
         aP4_ErrorCode=this.AV11ErrorCode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Resultado = "";
         AV11ErrorCode = 0;
         AV12Success = true;
         AV13Factura = new SdtFactura(context);
         AV13Factura.gxTpr_Facturano = AV8WPFacturaWizardData.gxTpr_Selecpromo.gxTpr_Facturano;
         AV13Factura.gxTpr_Facturafechafactura = AV8WPFacturaWizardData.gxTpr_Selecpromo.gxTpr_Facturafechafactura;
         AV13Factura.gxTpr_Facturafecharegistro = DateTimeUtil.Today( context);
         AV13Factura.gxTpr_Promocionid = AV8WPFacturaWizardData.gxTpr_Selecpromo.gxTpr_Promocionid;
         AV13Factura.gxTpr_Usuarioid = AV22UsuarioID;
         AV13Factura.gxTpr_Facturapdf = AV23FacturaPDF;
         AV13Factura.gxTpr_Facturapdf_gxi = AV24Facturapdf_GXI;
         AV13Factura.gxTpr_Facturaestatus = "En Proceso";
         AV13Factura.Save();
         if ( AV13Factura.Fail() )
         {
            AV11ErrorCode = 4001;
            AV10Resultado = context.GetMessage( "Error al guardar la factura", "");
            AV14Messages = AV13Factura.GetMessages();
            AV17first = true;
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV14Messages.Count )
            {
               AV18Message = ((GeneXus.Utils.SdtMessages_Message)AV14Messages.Item(AV25GXV1));
               if ( AV17first )
               {
                  AV10Resultado += ": " + AV18Message.gxTpr_Description;
                  AV17first = false;
               }
               else
               {
                  AV10Resultado += "; " + AV18Message.gxTpr_Description;
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
            cleanup();
            if (true) return;
         }
         AV15FacturaID = AV13Factura.gxTpr_Facturaid;
         AV19MedidasList = new GXBCCollection<SdtFacturaMedida>( context, "FacturaMedida", "Premios");
         AV26GXV2 = 1;
         while ( AV26GXV2 <= AV8WPFacturaWizardData.gxTpr_Selecmedidas.gxTpr_Grid.Count )
         {
            AV20MedidaItem = ((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV8WPFacturaWizardData.gxTpr_Selecmedidas.gxTpr_Grid.Item(AV26GXV2));
            if ( AV12Success )
            {
               AV16FacturaMedida = new SdtFacturaMedida(context);
               AV16FacturaMedida.gxTpr_Facturaid = AV15FacturaID;
               AV16FacturaMedida.gxTpr_Medidaid = AV20MedidaItem.gxTpr_Medidaid;
               AV16FacturaMedida.gxTpr_Facturamedidacantidad = AV20MedidaItem.gxTpr_Cantidad;
               AV16FacturaMedida.gxTpr_Facturamedidaprecio = AV20MedidaItem.gxTpr_Precio;
               AV16FacturaMedida.Save();
               if ( AV16FacturaMedida.Fail() )
               {
                  AV12Success = false;
                  AV11ErrorCode = 5001;
                  AV10Resultado = context.GetMessage( "Error al guardar la medida: ", "") + AV9Medida.gxTpr_Medidanombrecompleto;
                  cleanup();
                  if (true) return;
               }
               else
               {
                  AV19MedidasList.Add(AV16FacturaMedida, 0);
               }
            }
            AV26GXV2 = (int)(AV26GXV2+1);
         }
         if ( ! AV12Success )
         {
            AV27GXV3 = 1;
            while ( AV27GXV3 <= AV19MedidasList.Count )
            {
               AV21FM = ((SdtFacturaMedida)AV19MedidasList.Item(AV27GXV3));
               AV21FM.Load(AV21FM.gxTpr_Facturamedidaid);
               AV21FM.Delete();
               AV27GXV3 = (int)(AV27GXV3+1);
            }
            AV13Factura.Delete();
            AV10Resultado = context.GetMessage( "Error general en el proceso, se revirtieron los cambios. Código de error: ", "") + StringUtil.Str( (decimal)(AV11ErrorCode), 4, 0);
         }
         else
         {
            context.CommitDataStores("guardarfacturawizard",pr_default);
            AV10Resultado = context.GetMessage( "La factura fue guardada correctamente.", "");
            AV11ErrorCode = 0;
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
         AV10Resultado = "";
         AV13Factura = new SdtFactura(context);
         AV24Facturapdf_GXI = "";
         AV14Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV19MedidasList = new GXBCCollection<SdtFacturaMedida>( context, "FacturaMedida", "Premios");
         AV20MedidaItem = new SdtWPFacturaWizardData_SelecMedidas_GridItem(context);
         AV16FacturaMedida = new SdtFacturaMedida(context);
         AV9Medida = new SdtMedida(context);
         AV21FM = new SdtFacturaMedida(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.guardarfacturawizard__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11ErrorCode ;
      private int AV22UsuarioID ;
      private int AV25GXV1 ;
      private int AV15FacturaID ;
      private int AV26GXV2 ;
      private int AV27GXV3 ;
      private bool AV12Success ;
      private bool AV17first ;
      private string AV10Resultado ;
      private string AV24Facturapdf_GXI ;
      private string AV23FacturaPDF ;
      private IGxDataStore dsDefault ;
      private SdtWPFacturaWizardData AV8WPFacturaWizardData ;
      private SdtFactura AV13Factura ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV14Messages ;
      private GeneXus.Utils.SdtMessages_Message AV18Message ;
      private GXBCCollection<SdtFacturaMedida> AV19MedidasList ;
      private SdtWPFacturaWizardData_SelecMedidas_GridItem AV20MedidaItem ;
      private SdtFacturaMedida AV16FacturaMedida ;
      private SdtMedida AV9Medida ;
      private SdtFacturaMedida AV21FM ;
      private IDataStoreProvider pr_default ;
      private string aP3_Resultado ;
      private short aP4_ErrorCode ;
   }

   public class guardarfacturawizard__default : DataStoreHelperBase, IDataStoreHelper
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
