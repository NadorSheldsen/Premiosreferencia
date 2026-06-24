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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class medida_bc : GxSilentTrn, IGxSilentTrn
   {
      public medida_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public medida_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow099( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey099( ) ;
         standaloneModal( ) ;
         AddRow099( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z26MedidaID = A26MedidaID;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_090( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls099( ) ;
            }
            else
            {
               CheckExtendedTable099( ) ;
               if ( AnyError == 0 )
               {
                  ZM099( 3) ;
               }
               CloseExtendedTableCursors099( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z27MedidaCodigo = A27MedidaCodigo;
            Z28MedidaDescripcion = A28MedidaDescripcion;
            Z74MedidaRin = A74MedidaRin;
            Z85MedidaComentario = A85MedidaComentario;
            Z86MedidaActivo = A86MedidaActivo;
            Z22ModeloID = A22ModeloID;
            Z76MedidaNombreCompleto = A76MedidaNombreCompleto;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z23ModeloDescripcion = A23ModeloDescripcion;
            Z25ModeloSegmento = A25ModeloSegmento;
            Z76MedidaNombreCompleto = A76MedidaNombreCompleto;
         }
         if ( GX_JID == -2 )
         {
            Z26MedidaID = A26MedidaID;
            Z27MedidaCodigo = A27MedidaCodigo;
            Z28MedidaDescripcion = A28MedidaDescripcion;
            Z74MedidaRin = A74MedidaRin;
            Z85MedidaComentario = A85MedidaComentario;
            Z86MedidaActivo = A86MedidaActivo;
            Z22ModeloID = A22ModeloID;
            Z23ModeloDescripcion = A23ModeloDescripcion;
            Z25ModeloSegmento = A25ModeloSegmento;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load099( )
      {
         /* Using cursor BC00095 */
         pr_default.execute(3, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A27MedidaCodigo = BC00095_A27MedidaCodigo[0];
            A28MedidaDescripcion = BC00095_A28MedidaDescripcion[0];
            A74MedidaRin = BC00095_A74MedidaRin[0];
            A23ModeloDescripcion = BC00095_A23ModeloDescripcion[0];
            A25ModeloSegmento = BC00095_A25ModeloSegmento[0];
            A85MedidaComentario = BC00095_A85MedidaComentario[0];
            A86MedidaActivo = BC00095_A86MedidaActivo[0];
            A22ModeloID = BC00095_A22ModeloID[0];
            ZM099( -2) ;
         }
         pr_default.close(3);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
         A76MedidaNombreCompleto = StringUtil.Trim( A23ModeloDescripcion) + " / " + StringUtil.Trim( A28MedidaDescripcion) + " / " + StringUtil.Trim( A27MedidaCodigo);
      }

      protected void CheckExtendedTable099( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00094 */
         pr_default.execute(2, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
         }
         A23ModeloDescripcion = BC00094_A23ModeloDescripcion[0];
         A25ModeloSegmento = BC00094_A25ModeloSegmento[0];
         pr_default.close(2);
         A76MedidaNombreCompleto = StringUtil.Trim( A23ModeloDescripcion) + " / " + StringUtil.Trim( A28MedidaDescripcion) + " / " + StringUtil.Trim( A27MedidaCodigo);
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey099( )
      {
         /* Using cursor BC00096 */
         pr_default.execute(4, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00093 */
         pr_default.execute(1, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 2) ;
            RcdFound9 = 1;
            A26MedidaID = BC00093_A26MedidaID[0];
            A27MedidaCodigo = BC00093_A27MedidaCodigo[0];
            A28MedidaDescripcion = BC00093_A28MedidaDescripcion[0];
            A74MedidaRin = BC00093_A74MedidaRin[0];
            A85MedidaComentario = BC00093_A85MedidaComentario[0];
            A86MedidaActivo = BC00093_A86MedidaActivo[0];
            A22ModeloID = BC00093_A22ModeloID[0];
            Z26MedidaID = A26MedidaID;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_090( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00092 */
            pr_default.execute(0, new Object[] {A26MedidaID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Medida"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z27MedidaCodigo, BC00092_A27MedidaCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z28MedidaDescripcion, BC00092_A28MedidaDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z74MedidaRin, BC00092_A74MedidaRin[0]) != 0 ) || ( StringUtil.StrCmp(Z85MedidaComentario, BC00092_A85MedidaComentario[0]) != 0 ) || ( Z86MedidaActivo != BC00092_A86MedidaActivo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z22ModeloID != BC00092_A22ModeloID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Medida"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00097 */
                     pr_default.execute(5, new Object[] {A27MedidaCodigo, A28MedidaDescripcion, A74MedidaRin, A85MedidaComentario, A86MedidaActivo, A22ModeloID});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00098 */
                     pr_default.execute(6);
                     A26MedidaID = BC00098_A26MedidaID[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Medida");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00099 */
                     pr_default.execute(7, new Object[] {A27MedidaCodigo, A28MedidaDescripcion, A74MedidaRin, A85MedidaComentario, A86MedidaActivo, A22ModeloID, A26MedidaID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Medida");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Medida"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000910 */
                  pr_default.execute(8, new Object[] {A26MedidaID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Medida");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel099( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000911 */
            pr_default.execute(9, new Object[] {A22ModeloID});
            A23ModeloDescripcion = BC000911_A23ModeloDescripcion[0];
            A25ModeloSegmento = BC000911_A25ModeloSegmento[0];
            pr_default.close(9);
            A76MedidaNombreCompleto = StringUtil.Trim( A23ModeloDescripcion) + " / " + StringUtil.Trim( A28MedidaDescripcion) + " / " + StringUtil.Trim( A27MedidaCodigo);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000912 */
            pr_default.execute(10, new Object[] {A26MedidaID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Factura Medida", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart099( )
      {
         /* Using cursor BC000913 */
         pr_default.execute(11, new Object[] {A26MedidaID});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
            A26MedidaID = BC000913_A26MedidaID[0];
            A27MedidaCodigo = BC000913_A27MedidaCodigo[0];
            A28MedidaDescripcion = BC000913_A28MedidaDescripcion[0];
            A74MedidaRin = BC000913_A74MedidaRin[0];
            A23ModeloDescripcion = BC000913_A23ModeloDescripcion[0];
            A25ModeloSegmento = BC000913_A25ModeloSegmento[0];
            A85MedidaComentario = BC000913_A85MedidaComentario[0];
            A86MedidaActivo = BC000913_A86MedidaActivo[0];
            A22ModeloID = BC000913_A22ModeloID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound9 = 0;
         ScanKeyLoad099( ) ;
      }

      protected void ScanKeyLoad099( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
            A26MedidaID = BC000913_A26MedidaID[0];
            A27MedidaCodigo = BC000913_A27MedidaCodigo[0];
            A28MedidaDescripcion = BC000913_A28MedidaDescripcion[0];
            A74MedidaRin = BC000913_A74MedidaRin[0];
            A23ModeloDescripcion = BC000913_A23ModeloDescripcion[0];
            A25ModeloSegmento = BC000913_A25ModeloSegmento[0];
            A85MedidaComentario = BC000913_A85MedidaComentario[0];
            A86MedidaActivo = BC000913_A86MedidaActivo[0];
            A22ModeloID = BC000913_A22ModeloID[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd099( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void AddRow099( )
      {
         VarsToRow9( bcMedida) ;
      }

      protected void ReadRow099( )
      {
         RowToVars9( bcMedida, 1) ;
      }

      protected void InitializeNonKey099( )
      {
         A76MedidaNombreCompleto = "";
         A27MedidaCodigo = "";
         A28MedidaDescripcion = "";
         A22ModeloID = 0;
         A74MedidaRin = "";
         A23ModeloDescripcion = "";
         A25ModeloSegmento = "";
         A85MedidaComentario = "";
         A86MedidaActivo = false;
         Z27MedidaCodigo = "";
         Z28MedidaDescripcion = "";
         Z74MedidaRin = "";
         Z85MedidaComentario = "";
         Z86MedidaActivo = false;
         Z22ModeloID = 0;
      }

      protected void InitAll099( )
      {
         A26MedidaID = 0;
         InitializeNonKey099( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow9( SdtMedida obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Medidanombrecompleto = A76MedidaNombreCompleto;
         obj9.gxTpr_Medidacodigo = A27MedidaCodigo;
         obj9.gxTpr_Medidadescripcion = A28MedidaDescripcion;
         obj9.gxTpr_Modeloid = A22ModeloID;
         obj9.gxTpr_Medidarin = A74MedidaRin;
         obj9.gxTpr_Modelodescripcion = A23ModeloDescripcion;
         obj9.gxTpr_Modelosegmento = A25ModeloSegmento;
         obj9.gxTpr_Medidacomentario = A85MedidaComentario;
         obj9.gxTpr_Medidaactivo = A86MedidaActivo;
         obj9.gxTpr_Medidaid = A26MedidaID;
         obj9.gxTpr_Medidaid_Z = Z26MedidaID;
         obj9.gxTpr_Medidacodigo_Z = Z27MedidaCodigo;
         obj9.gxTpr_Medidadescripcion_Z = Z28MedidaDescripcion;
         obj9.gxTpr_Modeloid_Z = Z22ModeloID;
         obj9.gxTpr_Medidarin_Z = Z74MedidaRin;
         obj9.gxTpr_Modelodescripcion_Z = Z23ModeloDescripcion;
         obj9.gxTpr_Modelosegmento_Z = Z25ModeloSegmento;
         obj9.gxTpr_Medidanombrecompleto_Z = Z76MedidaNombreCompleto;
         obj9.gxTpr_Medidacomentario_Z = Z85MedidaComentario;
         obj9.gxTpr_Medidaactivo_Z = Z86MedidaActivo;
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtMedida obj9 )
      {
         obj9.gxTpr_Medidaid = A26MedidaID;
         return  ;
      }

      public void RowToVars9( SdtMedida obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A76MedidaNombreCompleto = obj9.gxTpr_Medidanombrecompleto;
         A27MedidaCodigo = obj9.gxTpr_Medidacodigo;
         A28MedidaDescripcion = obj9.gxTpr_Medidadescripcion;
         A22ModeloID = obj9.gxTpr_Modeloid;
         A74MedidaRin = obj9.gxTpr_Medidarin;
         A23ModeloDescripcion = obj9.gxTpr_Modelodescripcion;
         A25ModeloSegmento = obj9.gxTpr_Modelosegmento;
         A85MedidaComentario = obj9.gxTpr_Medidacomentario;
         A86MedidaActivo = obj9.gxTpr_Medidaactivo;
         A26MedidaID = obj9.gxTpr_Medidaid;
         Z26MedidaID = obj9.gxTpr_Medidaid_Z;
         Z27MedidaCodigo = obj9.gxTpr_Medidacodigo_Z;
         Z28MedidaDescripcion = obj9.gxTpr_Medidadescripcion_Z;
         Z22ModeloID = obj9.gxTpr_Modeloid_Z;
         Z74MedidaRin = obj9.gxTpr_Medidarin_Z;
         Z23ModeloDescripcion = obj9.gxTpr_Modelodescripcion_Z;
         Z25ModeloSegmento = obj9.gxTpr_Modelosegmento_Z;
         Z76MedidaNombreCompleto = obj9.gxTpr_Medidanombrecompleto_Z;
         Z85MedidaComentario = obj9.gxTpr_Medidacomentario_Z;
         Z86MedidaActivo = obj9.gxTpr_Medidaactivo_Z;
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A26MedidaID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey099( ) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z26MedidaID = A26MedidaID;
         }
         ZM099( -2) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars9( bcMedida, 0) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z26MedidaID = A26MedidaID;
         }
         ZM099( -2) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert099( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A26MedidaID != Z26MedidaID )
               {
                  A26MedidaID = Z26MedidaID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update099( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A26MedidaID != Z26MedidaID )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert099( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert099( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcMedida, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcMedida) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcMedida, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcMedida) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow9( bcMedida) ;
         }
         else
         {
            SdtMedida auxBC = new SdtMedida(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A26MedidaID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcMedida);
               auxBC.Save();
               bcMedida.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcMedida, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcMedida, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow9( bcMedida) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow9( bcMedida) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcMedida, 0) ;
         GetKey099( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A26MedidaID != Z26MedidaID )
            {
               A26MedidaID = Z26MedidaID;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A26MedidaID != Z26MedidaID )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("medida_bc",pr_default);
         VarsToRow9( bcMedida) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcMedida.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcMedida.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcMedida )
         {
            bcMedida = (SdtMedida)(sdt);
            if ( StringUtil.StrCmp(bcMedida.gxTpr_Mode, "") == 0 )
            {
               bcMedida.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcMedida) ;
            }
            else
            {
               RowToVars9( bcMedida, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcMedida.gxTpr_Mode, "") == 0 )
            {
               bcMedida.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcMedida, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtMedida Medida_BC
      {
         get {
            return bcMedida ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z27MedidaCodigo = "";
         A27MedidaCodigo = "";
         Z28MedidaDescripcion = "";
         A28MedidaDescripcion = "";
         Z74MedidaRin = "";
         A74MedidaRin = "";
         Z85MedidaComentario = "";
         A85MedidaComentario = "";
         Z76MedidaNombreCompleto = "";
         A76MedidaNombreCompleto = "";
         Z23ModeloDescripcion = "";
         A23ModeloDescripcion = "";
         Z25ModeloSegmento = "";
         A25ModeloSegmento = "";
         BC00095_A26MedidaID = new int[1] ;
         BC00095_A27MedidaCodigo = new string[] {""} ;
         BC00095_A28MedidaDescripcion = new string[] {""} ;
         BC00095_A74MedidaRin = new string[] {""} ;
         BC00095_A23ModeloDescripcion = new string[] {""} ;
         BC00095_A25ModeloSegmento = new string[] {""} ;
         BC00095_A85MedidaComentario = new string[] {""} ;
         BC00095_A86MedidaActivo = new bool[] {false} ;
         BC00095_A22ModeloID = new int[1] ;
         BC00094_A23ModeloDescripcion = new string[] {""} ;
         BC00094_A25ModeloSegmento = new string[] {""} ;
         BC00096_A26MedidaID = new int[1] ;
         BC00093_A26MedidaID = new int[1] ;
         BC00093_A27MedidaCodigo = new string[] {""} ;
         BC00093_A28MedidaDescripcion = new string[] {""} ;
         BC00093_A74MedidaRin = new string[] {""} ;
         BC00093_A85MedidaComentario = new string[] {""} ;
         BC00093_A86MedidaActivo = new bool[] {false} ;
         BC00093_A22ModeloID = new int[1] ;
         sMode9 = "";
         BC00092_A26MedidaID = new int[1] ;
         BC00092_A27MedidaCodigo = new string[] {""} ;
         BC00092_A28MedidaDescripcion = new string[] {""} ;
         BC00092_A74MedidaRin = new string[] {""} ;
         BC00092_A85MedidaComentario = new string[] {""} ;
         BC00092_A86MedidaActivo = new bool[] {false} ;
         BC00092_A22ModeloID = new int[1] ;
         BC00098_A26MedidaID = new int[1] ;
         BC000911_A23ModeloDescripcion = new string[] {""} ;
         BC000911_A25ModeloSegmento = new string[] {""} ;
         BC000912_A77FacturaMedidaID = new int[1] ;
         BC000913_A26MedidaID = new int[1] ;
         BC000913_A27MedidaCodigo = new string[] {""} ;
         BC000913_A28MedidaDescripcion = new string[] {""} ;
         BC000913_A74MedidaRin = new string[] {""} ;
         BC000913_A23ModeloDescripcion = new string[] {""} ;
         BC000913_A25ModeloSegmento = new string[] {""} ;
         BC000913_A85MedidaComentario = new string[] {""} ;
         BC000913_A86MedidaActivo = new bool[] {false} ;
         BC000913_A22ModeloID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.medida_bc__default(),
            new Object[][] {
                new Object[] {
               BC00092_A26MedidaID, BC00092_A27MedidaCodigo, BC00092_A28MedidaDescripcion, BC00092_A74MedidaRin, BC00092_A85MedidaComentario, BC00092_A86MedidaActivo, BC00092_A22ModeloID
               }
               , new Object[] {
               BC00093_A26MedidaID, BC00093_A27MedidaCodigo, BC00093_A28MedidaDescripcion, BC00093_A74MedidaRin, BC00093_A85MedidaComentario, BC00093_A86MedidaActivo, BC00093_A22ModeloID
               }
               , new Object[] {
               BC00094_A23ModeloDescripcion, BC00094_A25ModeloSegmento
               }
               , new Object[] {
               BC00095_A26MedidaID, BC00095_A27MedidaCodigo, BC00095_A28MedidaDescripcion, BC00095_A74MedidaRin, BC00095_A23ModeloDescripcion, BC00095_A25ModeloSegmento, BC00095_A85MedidaComentario, BC00095_A86MedidaActivo, BC00095_A22ModeloID
               }
               , new Object[] {
               BC00096_A26MedidaID
               }
               , new Object[] {
               }
               , new Object[] {
               BC00098_A26MedidaID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000911_A23ModeloDescripcion, BC000911_A25ModeloSegmento
               }
               , new Object[] {
               BC000912_A77FacturaMedidaID
               }
               , new Object[] {
               BC000913_A26MedidaID, BC000913_A27MedidaCodigo, BC000913_A28MedidaDescripcion, BC000913_A74MedidaRin, BC000913_A23ModeloDescripcion, BC000913_A25ModeloSegmento, BC000913_A85MedidaComentario, BC000913_A86MedidaActivo, BC000913_A22ModeloID
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound9 ;
      private int trnEnded ;
      private int Z26MedidaID ;
      private int A26MedidaID ;
      private int Z22ModeloID ;
      private int A22ModeloID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z27MedidaCodigo ;
      private string A27MedidaCodigo ;
      private string Z74MedidaRin ;
      private string A74MedidaRin ;
      private string Z25ModeloSegmento ;
      private string A25ModeloSegmento ;
      private string sMode9 ;
      private bool Z86MedidaActivo ;
      private bool A86MedidaActivo ;
      private bool Gx_longc ;
      private string Z28MedidaDescripcion ;
      private string A28MedidaDescripcion ;
      private string Z85MedidaComentario ;
      private string A85MedidaComentario ;
      private string Z76MedidaNombreCompleto ;
      private string A76MedidaNombreCompleto ;
      private string Z23ModeloDescripcion ;
      private string A23ModeloDescripcion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00095_A26MedidaID ;
      private string[] BC00095_A27MedidaCodigo ;
      private string[] BC00095_A28MedidaDescripcion ;
      private string[] BC00095_A74MedidaRin ;
      private string[] BC00095_A23ModeloDescripcion ;
      private string[] BC00095_A25ModeloSegmento ;
      private string[] BC00095_A85MedidaComentario ;
      private bool[] BC00095_A86MedidaActivo ;
      private int[] BC00095_A22ModeloID ;
      private string[] BC00094_A23ModeloDescripcion ;
      private string[] BC00094_A25ModeloSegmento ;
      private int[] BC00096_A26MedidaID ;
      private int[] BC00093_A26MedidaID ;
      private string[] BC00093_A27MedidaCodigo ;
      private string[] BC00093_A28MedidaDescripcion ;
      private string[] BC00093_A74MedidaRin ;
      private string[] BC00093_A85MedidaComentario ;
      private bool[] BC00093_A86MedidaActivo ;
      private int[] BC00093_A22ModeloID ;
      private int[] BC00092_A26MedidaID ;
      private string[] BC00092_A27MedidaCodigo ;
      private string[] BC00092_A28MedidaDescripcion ;
      private string[] BC00092_A74MedidaRin ;
      private string[] BC00092_A85MedidaComentario ;
      private bool[] BC00092_A86MedidaActivo ;
      private int[] BC00092_A22ModeloID ;
      private int[] BC00098_A26MedidaID ;
      private string[] BC000911_A23ModeloDescripcion ;
      private string[] BC000911_A25ModeloSegmento ;
      private int[] BC000912_A77FacturaMedidaID ;
      private int[] BC000913_A26MedidaID ;
      private string[] BC000913_A27MedidaCodigo ;
      private string[] BC000913_A28MedidaDescripcion ;
      private string[] BC000913_A74MedidaRin ;
      private string[] BC000913_A23ModeloDescripcion ;
      private string[] BC000913_A25ModeloSegmento ;
      private string[] BC000913_A85MedidaComentario ;
      private bool[] BC000913_A86MedidaActivo ;
      private int[] BC000913_A22ModeloID ;
      private SdtMedida bcMedida ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class medida_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00092;
          prmBC00092 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC00093;
          prmBC00093 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC00094;
          prmBC00094 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC00095;
          prmBC00095 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC00096;
          prmBC00096 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC00097;
          prmBC00097 = new Object[] {
          new ParDef("@MedidaCodigo",GXType.Char,20,0) ,
          new ParDef("@MedidaDescripcion",GXType.Char,80,0) ,
          new ParDef("@MedidaRin",GXType.Char,20,0) ,
          new ParDef("@MedidaComentario",GXType.Char,80,0) ,
          new ParDef("@MedidaActivo",GXType.Byte,4,0) ,
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC00098;
          prmBC00098 = new Object[] {
          };
          Object[] prmBC00099;
          prmBC00099 = new Object[] {
          new ParDef("@MedidaCodigo",GXType.Char,20,0) ,
          new ParDef("@MedidaDescripcion",GXType.Char,80,0) ,
          new ParDef("@MedidaRin",GXType.Char,20,0) ,
          new ParDef("@MedidaComentario",GXType.Char,80,0) ,
          new ParDef("@MedidaActivo",GXType.Byte,4,0) ,
          new ParDef("@ModeloID",GXType.Int32,9,0) ,
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000910;
          prmBC000910 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000911;
          prmBC000911 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000912;
          prmBC000912 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000913;
          prmBC000913 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00092", "SELECT `MedidaID`, `MedidaCodigo`, `MedidaDescripcion`, `MedidaRin`, `MedidaComentario`, `MedidaActivo`, `ModeloID` FROM `Medida` WHERE `MedidaID` = @MedidaID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00093", "SELECT `MedidaID`, `MedidaCodigo`, `MedidaDescripcion`, `MedidaRin`, `MedidaComentario`, `MedidaActivo`, `ModeloID` FROM `Medida` WHERE `MedidaID` = @MedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00094", "SELECT `ModeloDescripcion`, `ModeloSegmento` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00095", "SELECT TM1.`MedidaID`, TM1.`MedidaCodigo`, TM1.`MedidaDescripcion`, TM1.`MedidaRin`, T2.`ModeloDescripcion`, T2.`ModeloSegmento`, TM1.`MedidaComentario`, TM1.`MedidaActivo`, TM1.`ModeloID` FROM (`Medida` TM1 INNER JOIN `Modelo` T2 ON T2.`ModeloID` = TM1.`ModeloID`) WHERE TM1.`MedidaID` = @MedidaID ORDER BY TM1.`MedidaID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00095,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00096", "SELECT `MedidaID` FROM `Medida` WHERE `MedidaID` = @MedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00096,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00097", "INSERT INTO `Medida`(`MedidaCodigo`, `MedidaDescripcion`, `MedidaRin`, `MedidaComentario`, `MedidaActivo`, `ModeloID`) VALUES(@MedidaCodigo, @MedidaDescripcion, @MedidaRin, @MedidaComentario, @MedidaActivo, @ModeloID)", GxErrorMask.GX_NOMASK,prmBC00097)
             ,new CursorDef("BC00098", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00098,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00099", "UPDATE `Medida` SET `MedidaCodigo`=@MedidaCodigo, `MedidaDescripcion`=@MedidaDescripcion, `MedidaRin`=@MedidaRin, `MedidaComentario`=@MedidaComentario, `MedidaActivo`=@MedidaActivo, `ModeloID`=@ModeloID  WHERE `MedidaID` = @MedidaID", GxErrorMask.GX_NOMASK,prmBC00099)
             ,new CursorDef("BC000910", "DELETE FROM `Medida`  WHERE `MedidaID` = @MedidaID", GxErrorMask.GX_NOMASK,prmBC000910)
             ,new CursorDef("BC000911", "SELECT `ModeloDescripcion`, `ModeloSegmento` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000911,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000912", "SELECT `FacturaMedidaID` FROM `FacturaMedida` WHERE `MedidaID` = @MedidaID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000912,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000913", "SELECT TM1.`MedidaID`, TM1.`MedidaCodigo`, TM1.`MedidaDescripcion`, TM1.`MedidaRin`, T2.`ModeloDescripcion`, T2.`ModeloSegmento`, TM1.`MedidaComentario`, TM1.`MedidaActivo`, TM1.`ModeloID` FROM (`Medida` TM1 INNER JOIN `Modelo` T2 ON T2.`ModeloID` = TM1.`ModeloID`) WHERE TM1.`MedidaID` = @MedidaID ORDER BY TM1.`MedidaID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000913,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
