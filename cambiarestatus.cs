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
   public class cambiarestatus : GXProcedure
   {
      public cambiarestatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cambiarestatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_FacturaEstatus ,
                           int aP1_FacturaID ,
                           int aP2_MotivoRechazoID ,
                           out bool aP3_Pasa )
      {
         this.AV9FacturaEstatus = aP0_FacturaEstatus;
         this.AV11FacturaID = aP1_FacturaID;
         this.AV12MotivoRechazoID = aP2_MotivoRechazoID;
         this.AV15Pasa = false ;
         initialize();
         ExecuteImpl();
         aP3_Pasa=this.AV15Pasa;
      }

      public bool executeUdp( string aP0_FacturaEstatus ,
                              int aP1_FacturaID ,
                              int aP2_MotivoRechazoID )
      {
         execute(aP0_FacturaEstatus, aP1_FacturaID, aP2_MotivoRechazoID, out aP3_Pasa);
         return AV15Pasa ;
      }

      public void executeSubmit( string aP0_FacturaEstatus ,
                                 int aP1_FacturaID ,
                                 int aP2_MotivoRechazoID ,
                                 out bool aP3_Pasa )
      {
         this.AV9FacturaEstatus = aP0_FacturaEstatus;
         this.AV11FacturaID = aP1_FacturaID;
         this.AV12MotivoRechazoID = aP2_MotivoRechazoID;
         this.AV15Pasa = false ;
         SubmitImpl();
         aP3_Pasa=this.AV15Pasa;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15Pasa = false;
         AV10Factura.Load(AV11FacturaID);
         AV10Factura.gxTpr_Facturaestatus = AV9FacturaEstatus;
         AV10Factura.gxTpr_Motivorechazoid = AV12MotivoRechazoID;
         AV10Factura.Save();
         if ( AV10Factura.Success() )
         {
            AV15Pasa = true;
            context.CommitDataStores("cambiarestatus",pr_default);
         }
         else
         {
            AV13Messages = AV10Factura.GetMessages();
            /* Execute user subroutine: 'SHOW MESSAGES' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV16GXV1 = 1;
         while ( AV16GXV1 <= AV13Messages.Count )
         {
            AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV13Messages.Item(AV16GXV1));
            GX_msglist.addItem(AV14Message.gxTpr_Description);
            AV16GXV1 = (int)(AV16GXV1+1);
         }
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
         AV10Factura = new SdtFactura(context);
         AV13Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cambiarestatus__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV11FacturaID ;
      private int AV12MotivoRechazoID ;
      private int AV16GXV1 ;
      private string AV9FacturaEstatus ;
      private bool AV15Pasa ;
      private bool returnInSub ;
      private IGxDataStore dsDefault ;
      private SdtFactura AV10Factura ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13Messages ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private bool aP3_Pasa ;
   }

   public class cambiarestatus__default : DataStoreHelperBase, IDataStoreHelper
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
