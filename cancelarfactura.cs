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
   public class cancelarfactura : GXProcedure
   {
      public cancelarfactura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cancelarfactura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_FacturaID )
      {
         this.AV17FacturaID = aP0_FacturaID;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_FacturaID )
      {
         this.AV17FacturaID = aP0_FacturaID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8LoadSuccess = true;
         AV15Factura.Load(AV17FacturaID);
         AV8LoadSuccess = AV15Factura.Success();
         if ( ! AV8LoadSuccess )
         {
            AV21Messages = AV15Factura.GetMessages();
            /* Execute user subroutine: 'SHOW MESSAGES' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else
         {
            AV15Factura.gxTpr_Facturaestatus = "Cancelada";
            AV15Factura.gxTpr_Motivorechazoid = 0;
            AV15Factura.Save();
            if ( AV15Factura.Success() )
            {
               /* Execute user subroutine: 'AFTER_TRN' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else
            {
               AV21Messages = AV15Factura.GetMessages();
               /* Execute user subroutine: 'SHOW MESSAGES' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV21Messages.Count )
         {
            AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV21Messages.Item(AV26GXV1));
            GX_msglist.addItem(AV20Message.gxTpr_Description);
            AV26GXV1 = (int)(AV26GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("cancelarfactura",pr_default);
         returnInSub = true;
         if (true) return;
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
         AV15Factura = new SdtFactura(context);
         AV21Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV20Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cancelarfactura__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV17FacturaID ;
      private int A19MotivoRechazoID ;
      private int AV26GXV1 ;
      private bool AV8LoadSuccess ;
      private bool returnInSub ;
      private IGxDataStore dsDefault ;
      private SdtFactura AV15Factura ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV21Messages ;
      private GeneXus.Utils.SdtMessages_Message AV20Message ;
      private IDataStoreProvider pr_default ;
   }

   public class cancelarfactura__default : DataStoreHelperBase, IDataStoreHelper
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
