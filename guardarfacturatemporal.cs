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
   public class guardarfacturatemporal : GXProcedure
   {
      public guardarfacturatemporal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public guardarfacturatemporal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_FacturaNo ,
                           DateTime aP1_FacturaFechaFactura ,
                           int aP2_PromocionID ,
                           int aP3_UsuarioID ,
                           string aP4_FacturaPDF ,
                           out int aP5_FacturaID ,
                           out string aP6_Resultado ,
                           out short aP7_ErrorCode )
      {
         this.AV27FacturaNo = aP0_FacturaNo;
         this.AV26FacturaFechaFactura = aP1_FacturaFechaFactura;
         this.AV46PromocionID = aP2_PromocionID;
         this.AV55UsuarioID = aP3_UsuarioID;
         this.AV29FacturaPDF = aP4_FacturaPDF;
         this.AV63FacturaID = 0 ;
         this.AV83Resultado = "" ;
         this.AV62ErrorCode = 0 ;
         initialize();
         ExecuteImpl();
         aP5_FacturaID=this.AV63FacturaID;
         aP6_Resultado=this.AV83Resultado;
         aP7_ErrorCode=this.AV62ErrorCode;
      }

      public short executeUdp( string aP0_FacturaNo ,
                               DateTime aP1_FacturaFechaFactura ,
                               int aP2_PromocionID ,
                               int aP3_UsuarioID ,
                               string aP4_FacturaPDF ,
                               out int aP5_FacturaID ,
                               out string aP6_Resultado )
      {
         execute(aP0_FacturaNo, aP1_FacturaFechaFactura, aP2_PromocionID, aP3_UsuarioID, aP4_FacturaPDF, out aP5_FacturaID, out aP6_Resultado, out aP7_ErrorCode);
         return AV62ErrorCode ;
      }

      public void executeSubmit( string aP0_FacturaNo ,
                                 DateTime aP1_FacturaFechaFactura ,
                                 int aP2_PromocionID ,
                                 int aP3_UsuarioID ,
                                 string aP4_FacturaPDF ,
                                 out int aP5_FacturaID ,
                                 out string aP6_Resultado ,
                                 out short aP7_ErrorCode )
      {
         this.AV27FacturaNo = aP0_FacturaNo;
         this.AV26FacturaFechaFactura = aP1_FacturaFechaFactura;
         this.AV46PromocionID = aP2_PromocionID;
         this.AV55UsuarioID = aP3_UsuarioID;
         this.AV29FacturaPDF = aP4_FacturaPDF;
         this.AV63FacturaID = 0 ;
         this.AV83Resultado = "" ;
         this.AV62ErrorCode = 0 ;
         SubmitImpl();
         aP5_FacturaID=this.AV63FacturaID;
         aP6_Resultado=this.AV83Resultado;
         aP7_ErrorCode=this.AV62ErrorCode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV62ErrorCode = 0;
         AV83Resultado = "";
         AV63FacturaID = 0;
         AV25Factura = new SdtFactura(context);
         AV25Factura.gxTpr_Facturano = AV27FacturaNo;
         AV25Factura.gxTpr_Facturafechafactura = AV26FacturaFechaFactura;
         AV25Factura.gxTpr_Facturafecharegistro = DateTimeUtil.Today( context);
         AV25Factura.gxTpr_Promocionid = AV46PromocionID;
         AV25Factura.gxTpr_Usuarioid = AV55UsuarioID;
         AV25Factura.gxTpr_Facturapdf = AV29FacturaPDF;
         AV25Factura.gxTpr_Facturapdf_gxi = AV84Facturapdf_GXI;
         AV25Factura.gxTpr_Facturaestatus = "En Proceso";
         AV25Factura.gxTpr_Facturacompleta = false;
         AV25Factura.Save();
         if ( AV25Factura.Success() )
         {
            context.CommitDataStores("guardarfacturatemporal",pr_default);
            AV63FacturaID = AV25Factura.gxTpr_Facturaid;
            AV83Resultado = context.GetMessage( "Factura temporal guardada correctamente.", "");
         }
         else
         {
            context.RollbackDataStores("guardarfacturatemporal",pr_default);
            AV62ErrorCode = 4001;
            AV83Resultado = context.GetMessage( "Error al guardar temporalmente la factura.", "");
            AV37Messages = AV25Factura.GetMessages();
            AV85GXV1 = 1;
            while ( AV85GXV1 <= AV37Messages.Count )
            {
               AV36Message = ((GeneXus.Utils.SdtMessages_Message)AV37Messages.Item(AV85GXV1));
               AV83Resultado += " " + AV36Message.gxTpr_Description;
               AV85GXV1 = (int)(AV85GXV1+1);
            }
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
         AV83Resultado = "";
         AV25Factura = new SdtFactura(context);
         AV84Facturapdf_GXI = "";
         AV37Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV36Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.guardarfacturatemporal__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV62ErrorCode ;
      private int AV46PromocionID ;
      private int AV55UsuarioID ;
      private int AV63FacturaID ;
      private int AV85GXV1 ;
      private string AV27FacturaNo ;
      private DateTime AV26FacturaFechaFactura ;
      private string AV83Resultado ;
      private string AV84Facturapdf_GXI ;
      private string AV29FacturaPDF ;
      private IGxDataStore dsDefault ;
      private SdtFactura AV25Factura ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV37Messages ;
      private GeneXus.Utils.SdtMessages_Message AV36Message ;
      private int aP5_FacturaID ;
      private string aP6_Resultado ;
      private short aP7_ErrorCode ;
   }

   public class guardarfacturatemporal__default : DataStoreHelperBase, IDataStoreHelper
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
