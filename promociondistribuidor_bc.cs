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
   public class promociondistribuidor_bc : GxSilentTrn, IGxSilentTrn
   {
      public promociondistribuidor_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public promociondistribuidor_bc( IGxContext context )
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
         ReadRow0D13( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0D13( ) ;
         standaloneModal( ) ;
         AddRow0D13( ) ;
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
               Z47PromocionDistribuidorID = A47PromocionDistribuidorID;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D13( ) ;
            }
            else
            {
               CheckExtendedTable0D13( ) ;
               if ( AnyError == 0 )
               {
                  ZM0D13( 2) ;
                  ZM0D13( 3) ;
               }
               CloseExtendedTableCursors0D13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0D13( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z41PromocionID = A41PromocionID;
            Z10DistribuidorID = A10DistribuidorID;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z11DistribuidorDescripcion = A11DistribuidorDescripcion;
         }
         if ( GX_JID == -1 )
         {
            Z47PromocionDistribuidorID = A47PromocionDistribuidorID;
            Z41PromocionID = A41PromocionID;
            Z10DistribuidorID = A10DistribuidorID;
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z44PromocionArte = A44PromocionArte;
            Z40000PromocionArte_GXI = A40000PromocionArte_GXI;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z11DistribuidorDescripcion = A11DistribuidorDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0D13( )
      {
         /* Using cursor BC000D6 */
         pr_default.execute(4, new Object[] {A47PromocionDistribuidorID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound13 = 1;
            A42PromocionDescripcion = BC000D6_A42PromocionDescripcion[0];
            A43PromocionBase = BC000D6_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000D6_A40000PromocionArte_GXI[0];
            A45PromocionFechaInicio = BC000D6_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000D6_A46PromocionFechaFin[0];
            A11DistribuidorDescripcion = BC000D6_A11DistribuidorDescripcion[0];
            A41PromocionID = BC000D6_A41PromocionID[0];
            A10DistribuidorID = BC000D6_A10DistribuidorID[0];
            A44PromocionArte = BC000D6_A44PromocionArte[0];
            ZM0D13( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0D13( ) ;
      }

      protected void OnLoadActions0D13( )
      {
      }

      protected void CheckExtendedTable0D13( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000D4 */
         pr_default.execute(2, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
         }
         A42PromocionDescripcion = BC000D4_A42PromocionDescripcion[0];
         A43PromocionBase = BC000D4_A43PromocionBase[0];
         A40000PromocionArte_GXI = BC000D4_A40000PromocionArte_GXI[0];
         A45PromocionFechaInicio = BC000D4_A45PromocionFechaInicio[0];
         A46PromocionFechaFin = BC000D4_A46PromocionFechaFin[0];
         A44PromocionArte = BC000D4_A44PromocionArte[0];
         pr_default.close(2);
         /* Using cursor BC000D5 */
         pr_default.execute(3, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DISTRIBUIDORID");
            AnyError = 1;
         }
         A11DistribuidorDescripcion = BC000D5_A11DistribuidorDescripcion[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0D13( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D13( )
      {
         /* Using cursor BC000D7 */
         pr_default.execute(5, new Object[] {A47PromocionDistribuidorID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000D3 */
         pr_default.execute(1, new Object[] {A47PromocionDistribuidorID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D13( 1) ;
            RcdFound13 = 1;
            A47PromocionDistribuidorID = BC000D3_A47PromocionDistribuidorID[0];
            A41PromocionID = BC000D3_A41PromocionID[0];
            A10DistribuidorID = BC000D3_A10DistribuidorID[0];
            Z47PromocionDistribuidorID = A47PromocionDistribuidorID;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0D13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0D13( ) ;
            }
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0D13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode13;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D13( ) ;
         if ( RcdFound13 == 0 )
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
         CONFIRM_0D0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0D13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D2 */
            pr_default.execute(0, new Object[] {A47PromocionDistribuidorID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromocionDistribuidor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z41PromocionID != BC000D2_A41PromocionID[0] ) || ( Z10DistribuidorID != BC000D2_A10DistribuidorID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PromocionDistribuidor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D13( 0) ;
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D8 */
                     pr_default.execute(6, new Object[] {A41PromocionID, A10DistribuidorID});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000D9 */
                     pr_default.execute(7);
                     A47PromocionDistribuidorID = BC000D9_A47PromocionDistribuidorID[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("PromocionDistribuidor");
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
               Load0D13( ) ;
            }
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void Update0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D10 */
                     pr_default.execute(8, new Object[] {A41PromocionID, A10DistribuidorID, A47PromocionDistribuidorID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("PromocionDistribuidor");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromocionDistribuidor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D13( ) ;
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
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void DeferredUpdate0D13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D13( ) ;
            AfterConfirm0D13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000D11 */
                  pr_default.execute(9, new Object[] {A47PromocionDistribuidorID});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("PromocionDistribuidor");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D13( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0D13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000D12 */
            pr_default.execute(10, new Object[] {A41PromocionID});
            A42PromocionDescripcion = BC000D12_A42PromocionDescripcion[0];
            A43PromocionBase = BC000D12_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000D12_A40000PromocionArte_GXI[0];
            A45PromocionFechaInicio = BC000D12_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000D12_A46PromocionFechaFin[0];
            A44PromocionArte = BC000D12_A44PromocionArte[0];
            pr_default.close(10);
            /* Using cursor BC000D13 */
            pr_default.execute(11, new Object[] {A10DistribuidorID});
            A11DistribuidorDescripcion = BC000D13_A11DistribuidorDescripcion[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel0D13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D13( ) ;
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

      public void ScanKeyStart0D13( )
      {
         /* Using cursor BC000D14 */
         pr_default.execute(12, new Object[] {A47PromocionDistribuidorID});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound13 = 1;
            A47PromocionDistribuidorID = BC000D14_A47PromocionDistribuidorID[0];
            A42PromocionDescripcion = BC000D14_A42PromocionDescripcion[0];
            A43PromocionBase = BC000D14_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000D14_A40000PromocionArte_GXI[0];
            A45PromocionFechaInicio = BC000D14_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000D14_A46PromocionFechaFin[0];
            A11DistribuidorDescripcion = BC000D14_A11DistribuidorDescripcion[0];
            A41PromocionID = BC000D14_A41PromocionID[0];
            A10DistribuidorID = BC000D14_A10DistribuidorID[0];
            A44PromocionArte = BC000D14_A44PromocionArte[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D13( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound13 = 0;
         ScanKeyLoad0D13( ) ;
      }

      protected void ScanKeyLoad0D13( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound13 = 1;
            A47PromocionDistribuidorID = BC000D14_A47PromocionDistribuidorID[0];
            A42PromocionDescripcion = BC000D14_A42PromocionDescripcion[0];
            A43PromocionBase = BC000D14_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000D14_A40000PromocionArte_GXI[0];
            A45PromocionFechaInicio = BC000D14_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000D14_A46PromocionFechaFin[0];
            A11DistribuidorDescripcion = BC000D14_A11DistribuidorDescripcion[0];
            A41PromocionID = BC000D14_A41PromocionID[0];
            A10DistribuidorID = BC000D14_A10DistribuidorID[0];
            A44PromocionArte = BC000D14_A44PromocionArte[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0D13( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0D13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D13( )
      {
      }

      protected void send_integrity_lvl_hashes0D13( )
      {
      }

      protected void AddRow0D13( )
      {
         VarsToRow13( bcPromocionDistribuidor) ;
      }

      protected void ReadRow0D13( )
      {
         RowToVars13( bcPromocionDistribuidor, 1) ;
      }

      protected void InitializeNonKey0D13( )
      {
         A41PromocionID = 0;
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A44PromocionArte = "";
         A40000PromocionArte_GXI = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         A10DistribuidorID = 0;
         A11DistribuidorDescripcion = "";
         Z41PromocionID = 0;
         Z10DistribuidorID = 0;
      }

      protected void InitAll0D13( )
      {
         A47PromocionDistribuidorID = 0;
         InitializeNonKey0D13( ) ;
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

      public void VarsToRow13( SdtPromocionDistribuidor obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Promocionid = A41PromocionID;
         obj13.gxTpr_Promociondescripcion = A42PromocionDescripcion;
         obj13.gxTpr_Promocionbase = A43PromocionBase;
         obj13.gxTpr_Promocionarte = A44PromocionArte;
         obj13.gxTpr_Promocionarte_gxi = A40000PromocionArte_GXI;
         obj13.gxTpr_Promocionfechainicio = A45PromocionFechaInicio;
         obj13.gxTpr_Promocionfechafin = A46PromocionFechaFin;
         obj13.gxTpr_Distribuidorid = A10DistribuidorID;
         obj13.gxTpr_Distribuidordescripcion = A11DistribuidorDescripcion;
         obj13.gxTpr_Promociondistribuidorid = A47PromocionDistribuidorID;
         obj13.gxTpr_Promociondistribuidorid_Z = Z47PromocionDistribuidorID;
         obj13.gxTpr_Promocionid_Z = Z41PromocionID;
         obj13.gxTpr_Promociondescripcion_Z = Z42PromocionDescripcion;
         obj13.gxTpr_Promocionbase_Z = Z43PromocionBase;
         obj13.gxTpr_Promocionfechainicio_Z = Z45PromocionFechaInicio;
         obj13.gxTpr_Promocionfechafin_Z = Z46PromocionFechaFin;
         obj13.gxTpr_Distribuidorid_Z = Z10DistribuidorID;
         obj13.gxTpr_Distribuidordescripcion_Z = Z11DistribuidorDescripcion;
         obj13.gxTpr_Promocionarte_gxi_Z = Z40000PromocionArte_GXI;
         obj13.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow13( SdtPromocionDistribuidor obj13 )
      {
         obj13.gxTpr_Promociondistribuidorid = A47PromocionDistribuidorID;
         return  ;
      }

      public void RowToVars13( SdtPromocionDistribuidor obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A41PromocionID = obj13.gxTpr_Promocionid;
         A42PromocionDescripcion = obj13.gxTpr_Promociondescripcion;
         A43PromocionBase = obj13.gxTpr_Promocionbase;
         A44PromocionArte = obj13.gxTpr_Promocionarte;
         A40000PromocionArte_GXI = obj13.gxTpr_Promocionarte_gxi;
         A45PromocionFechaInicio = obj13.gxTpr_Promocionfechainicio;
         A46PromocionFechaFin = obj13.gxTpr_Promocionfechafin;
         A10DistribuidorID = obj13.gxTpr_Distribuidorid;
         A11DistribuidorDescripcion = obj13.gxTpr_Distribuidordescripcion;
         A47PromocionDistribuidorID = obj13.gxTpr_Promociondistribuidorid;
         Z47PromocionDistribuidorID = obj13.gxTpr_Promociondistribuidorid_Z;
         Z41PromocionID = obj13.gxTpr_Promocionid_Z;
         Z42PromocionDescripcion = obj13.gxTpr_Promociondescripcion_Z;
         Z43PromocionBase = obj13.gxTpr_Promocionbase_Z;
         Z45PromocionFechaInicio = obj13.gxTpr_Promocionfechainicio_Z;
         Z46PromocionFechaFin = obj13.gxTpr_Promocionfechafin_Z;
         Z10DistribuidorID = obj13.gxTpr_Distribuidorid_Z;
         Z11DistribuidorDescripcion = obj13.gxTpr_Distribuidordescripcion_Z;
         Z40000PromocionArte_GXI = obj13.gxTpr_Promocionarte_gxi_Z;
         Gx_mode = obj13.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A47PromocionDistribuidorID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0D13( ) ;
         ScanKeyStart0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z47PromocionDistribuidorID = A47PromocionDistribuidorID;
         }
         ZM0D13( -1) ;
         OnLoadActions0D13( ) ;
         AddRow0D13( ) ;
         ScanKeyEnd0D13( ) ;
         if ( RcdFound13 == 0 )
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
         RowToVars13( bcPromocionDistribuidor, 0) ;
         ScanKeyStart0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z47PromocionDistribuidorID = A47PromocionDistribuidorID;
         }
         ZM0D13( -1) ;
         OnLoadActions0D13( ) ;
         AddRow0D13( ) ;
         ScanKeyEnd0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0D13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0D13( ) ;
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A47PromocionDistribuidorID != Z47PromocionDistribuidorID )
               {
                  A47PromocionDistribuidorID = Z47PromocionDistribuidorID;
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
                  Update0D13( ) ;
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
                  if ( A47PromocionDistribuidorID != Z47PromocionDistribuidorID )
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
                        Insert0D13( ) ;
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
                        Insert0D13( ) ;
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
         RowToVars13( bcPromocionDistribuidor, 1) ;
         SaveImpl( ) ;
         VarsToRow13( bcPromocionDistribuidor) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcPromocionDistribuidor, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D13( ) ;
         AfterTrn( ) ;
         VarsToRow13( bcPromocionDistribuidor) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow13( bcPromocionDistribuidor) ;
         }
         else
         {
            SdtPromocionDistribuidor auxBC = new SdtPromocionDistribuidor(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A47PromocionDistribuidorID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPromocionDistribuidor);
               auxBC.Save();
               bcPromocionDistribuidor.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars13( bcPromocionDistribuidor, 1) ;
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
         RowToVars13( bcPromocionDistribuidor, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D13( ) ;
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
               VarsToRow13( bcPromocionDistribuidor) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow13( bcPromocionDistribuidor) ;
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
         RowToVars13( bcPromocionDistribuidor, 0) ;
         GetKey0D13( ) ;
         if ( RcdFound13 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A47PromocionDistribuidorID != Z47PromocionDistribuidorID )
            {
               A47PromocionDistribuidorID = Z47PromocionDistribuidorID;
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
            if ( A47PromocionDistribuidorID != Z47PromocionDistribuidorID )
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
         context.RollbackDataStores("promociondistribuidor_bc",pr_default);
         VarsToRow13( bcPromocionDistribuidor) ;
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
         Gx_mode = bcPromocionDistribuidor.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPromocionDistribuidor.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPromocionDistribuidor )
         {
            bcPromocionDistribuidor = (SdtPromocionDistribuidor)(sdt);
            if ( StringUtil.StrCmp(bcPromocionDistribuidor.gxTpr_Mode, "") == 0 )
            {
               bcPromocionDistribuidor.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow13( bcPromocionDistribuidor) ;
            }
            else
            {
               RowToVars13( bcPromocionDistribuidor, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPromocionDistribuidor.gxTpr_Mode, "") == 0 )
            {
               bcPromocionDistribuidor.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars13( bcPromocionDistribuidor, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPromocionDistribuidor PromocionDistribuidor_BC
      {
         get {
            return bcPromocionDistribuidor ;
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
         pr_default.close(10);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z42PromocionDescripcion = "";
         A42PromocionDescripcion = "";
         Z43PromocionBase = "";
         A43PromocionBase = "";
         Z45PromocionFechaInicio = DateTime.MinValue;
         A45PromocionFechaInicio = DateTime.MinValue;
         Z46PromocionFechaFin = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         Z11DistribuidorDescripcion = "";
         A11DistribuidorDescripcion = "";
         Z44PromocionArte = "";
         A44PromocionArte = "";
         Z40000PromocionArte_GXI = "";
         A40000PromocionArte_GXI = "";
         BC000D6_A47PromocionDistribuidorID = new int[1] ;
         BC000D6_A42PromocionDescripcion = new string[] {""} ;
         BC000D6_A43PromocionBase = new string[] {""} ;
         BC000D6_A40000PromocionArte_GXI = new string[] {""} ;
         BC000D6_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000D6_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000D6_A11DistribuidorDescripcion = new string[] {""} ;
         BC000D6_A41PromocionID = new int[1] ;
         BC000D6_A10DistribuidorID = new int[1] ;
         BC000D6_A44PromocionArte = new string[] {""} ;
         BC000D4_A42PromocionDescripcion = new string[] {""} ;
         BC000D4_A43PromocionBase = new string[] {""} ;
         BC000D4_A40000PromocionArte_GXI = new string[] {""} ;
         BC000D4_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000D4_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000D4_A44PromocionArte = new string[] {""} ;
         BC000D5_A11DistribuidorDescripcion = new string[] {""} ;
         BC000D7_A47PromocionDistribuidorID = new int[1] ;
         BC000D3_A47PromocionDistribuidorID = new int[1] ;
         BC000D3_A41PromocionID = new int[1] ;
         BC000D3_A10DistribuidorID = new int[1] ;
         sMode13 = "";
         BC000D2_A47PromocionDistribuidorID = new int[1] ;
         BC000D2_A41PromocionID = new int[1] ;
         BC000D2_A10DistribuidorID = new int[1] ;
         BC000D9_A47PromocionDistribuidorID = new int[1] ;
         BC000D12_A42PromocionDescripcion = new string[] {""} ;
         BC000D12_A43PromocionBase = new string[] {""} ;
         BC000D12_A40000PromocionArte_GXI = new string[] {""} ;
         BC000D12_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000D12_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000D12_A44PromocionArte = new string[] {""} ;
         BC000D13_A11DistribuidorDescripcion = new string[] {""} ;
         BC000D14_A47PromocionDistribuidorID = new int[1] ;
         BC000D14_A42PromocionDescripcion = new string[] {""} ;
         BC000D14_A43PromocionBase = new string[] {""} ;
         BC000D14_A40000PromocionArte_GXI = new string[] {""} ;
         BC000D14_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000D14_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000D14_A11DistribuidorDescripcion = new string[] {""} ;
         BC000D14_A41PromocionID = new int[1] ;
         BC000D14_A10DistribuidorID = new int[1] ;
         BC000D14_A44PromocionArte = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promociondistribuidor_bc__default(),
            new Object[][] {
                new Object[] {
               BC000D2_A47PromocionDistribuidorID, BC000D2_A41PromocionID, BC000D2_A10DistribuidorID
               }
               , new Object[] {
               BC000D3_A47PromocionDistribuidorID, BC000D3_A41PromocionID, BC000D3_A10DistribuidorID
               }
               , new Object[] {
               BC000D4_A42PromocionDescripcion, BC000D4_A43PromocionBase, BC000D4_A40000PromocionArte_GXI, BC000D4_A45PromocionFechaInicio, BC000D4_A46PromocionFechaFin, BC000D4_A44PromocionArte
               }
               , new Object[] {
               BC000D5_A11DistribuidorDescripcion
               }
               , new Object[] {
               BC000D6_A47PromocionDistribuidorID, BC000D6_A42PromocionDescripcion, BC000D6_A43PromocionBase, BC000D6_A40000PromocionArte_GXI, BC000D6_A45PromocionFechaInicio, BC000D6_A46PromocionFechaFin, BC000D6_A11DistribuidorDescripcion, BC000D6_A41PromocionID, BC000D6_A10DistribuidorID, BC000D6_A44PromocionArte
               }
               , new Object[] {
               BC000D7_A47PromocionDistribuidorID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D9_A47PromocionDistribuidorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D12_A42PromocionDescripcion, BC000D12_A43PromocionBase, BC000D12_A40000PromocionArte_GXI, BC000D12_A45PromocionFechaInicio, BC000D12_A46PromocionFechaFin, BC000D12_A44PromocionArte
               }
               , new Object[] {
               BC000D13_A11DistribuidorDescripcion
               }
               , new Object[] {
               BC000D14_A47PromocionDistribuidorID, BC000D14_A42PromocionDescripcion, BC000D14_A43PromocionBase, BC000D14_A40000PromocionArte_GXI, BC000D14_A45PromocionFechaInicio, BC000D14_A46PromocionFechaFin, BC000D14_A11DistribuidorDescripcion, BC000D14_A41PromocionID, BC000D14_A10DistribuidorID, BC000D14_A44PromocionArte
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound13 ;
      private int trnEnded ;
      private int Z47PromocionDistribuidorID ;
      private int A47PromocionDistribuidorID ;
      private int Z41PromocionID ;
      private int A41PromocionID ;
      private int Z10DistribuidorID ;
      private int A10DistribuidorID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode13 ;
      private DateTime Z45PromocionFechaInicio ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime Z46PromocionFechaFin ;
      private DateTime A46PromocionFechaFin ;
      private string Z42PromocionDescripcion ;
      private string A42PromocionDescripcion ;
      private string Z43PromocionBase ;
      private string A43PromocionBase ;
      private string Z11DistribuidorDescripcion ;
      private string A11DistribuidorDescripcion ;
      private string Z40000PromocionArte_GXI ;
      private string A40000PromocionArte_GXI ;
      private string Z44PromocionArte ;
      private string A44PromocionArte ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000D6_A47PromocionDistribuidorID ;
      private string[] BC000D6_A42PromocionDescripcion ;
      private string[] BC000D6_A43PromocionBase ;
      private string[] BC000D6_A40000PromocionArte_GXI ;
      private DateTime[] BC000D6_A45PromocionFechaInicio ;
      private DateTime[] BC000D6_A46PromocionFechaFin ;
      private string[] BC000D6_A11DistribuidorDescripcion ;
      private int[] BC000D6_A41PromocionID ;
      private int[] BC000D6_A10DistribuidorID ;
      private string[] BC000D6_A44PromocionArte ;
      private string[] BC000D4_A42PromocionDescripcion ;
      private string[] BC000D4_A43PromocionBase ;
      private string[] BC000D4_A40000PromocionArte_GXI ;
      private DateTime[] BC000D4_A45PromocionFechaInicio ;
      private DateTime[] BC000D4_A46PromocionFechaFin ;
      private string[] BC000D4_A44PromocionArte ;
      private string[] BC000D5_A11DistribuidorDescripcion ;
      private int[] BC000D7_A47PromocionDistribuidorID ;
      private int[] BC000D3_A47PromocionDistribuidorID ;
      private int[] BC000D3_A41PromocionID ;
      private int[] BC000D3_A10DistribuidorID ;
      private int[] BC000D2_A47PromocionDistribuidorID ;
      private int[] BC000D2_A41PromocionID ;
      private int[] BC000D2_A10DistribuidorID ;
      private int[] BC000D9_A47PromocionDistribuidorID ;
      private string[] BC000D12_A42PromocionDescripcion ;
      private string[] BC000D12_A43PromocionBase ;
      private string[] BC000D12_A40000PromocionArte_GXI ;
      private DateTime[] BC000D12_A45PromocionFechaInicio ;
      private DateTime[] BC000D12_A46PromocionFechaFin ;
      private string[] BC000D12_A44PromocionArte ;
      private string[] BC000D13_A11DistribuidorDescripcion ;
      private int[] BC000D14_A47PromocionDistribuidorID ;
      private string[] BC000D14_A42PromocionDescripcion ;
      private string[] BC000D14_A43PromocionBase ;
      private string[] BC000D14_A40000PromocionArte_GXI ;
      private DateTime[] BC000D14_A45PromocionFechaInicio ;
      private DateTime[] BC000D14_A46PromocionFechaFin ;
      private string[] BC000D14_A11DistribuidorDescripcion ;
      private int[] BC000D14_A41PromocionID ;
      private int[] BC000D14_A10DistribuidorID ;
      private string[] BC000D14_A44PromocionArte ;
      private SdtPromocionDistribuidor bcPromocionDistribuidor ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class promociondistribuidor_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000D2;
          prmBC000D2 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000D3;
          prmBC000D3 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000D4;
          prmBC000D4 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000D5;
          prmBC000D5 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000D6;
          prmBC000D6 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000D7;
          prmBC000D7 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000D8;
          prmBC000D8 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000D9;
          prmBC000D9 = new Object[] {
          };
          Object[] prmBC000D10;
          prmBC000D10 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@DistribuidorID",GXType.Int32,9,0) ,
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000D11;
          prmBC000D11 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000D12;
          prmBC000D12 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000D13;
          prmBC000D13 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000D14;
          prmBC000D14 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000D2", "SELECT `PromocionDistribuidorID`, `PromocionID`, `DistribuidorID` FROM `PromocionDistribuidor` WHERE `PromocionDistribuidorID` = @PromocionDistribuidorID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D3", "SELECT `PromocionDistribuidorID`, `PromocionID`, `DistribuidorID` FROM `PromocionDistribuidor` WHERE `PromocionDistribuidorID` = @PromocionDistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D4", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D5", "SELECT `DistribuidorDescripcion` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D6", "SELECT TM1.`PromocionDistribuidorID`, T2.`PromocionDescripcion`, T2.`PromocionBase`, T2.`PromocionArte_GXI`, T2.`PromocionFechaInicio`, T2.`PromocionFechaFin`, T3.`DistribuidorDescripcion`, TM1.`PromocionID`, TM1.`DistribuidorID`, T2.`PromocionArte` FROM ((`PromocionDistribuidor` TM1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = TM1.`PromocionID`) INNER JOIN `Distribuidor` T3 ON T3.`DistribuidorID` = TM1.`DistribuidorID`) WHERE TM1.`PromocionDistribuidorID` = @PromocionDistribuidorID ORDER BY TM1.`PromocionDistribuidorID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D7", "SELECT `PromocionDistribuidorID` FROM `PromocionDistribuidor` WHERE `PromocionDistribuidorID` = @PromocionDistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D8", "INSERT INTO `PromocionDistribuidor`(`PromocionID`, `DistribuidorID`) VALUES(@PromocionID, @DistribuidorID)", GxErrorMask.GX_NOMASK,prmBC000D8)
             ,new CursorDef("BC000D9", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D10", "UPDATE `PromocionDistribuidor` SET `PromocionID`=@PromocionID, `DistribuidorID`=@DistribuidorID  WHERE `PromocionDistribuidorID` = @PromocionDistribuidorID", GxErrorMask.GX_NOMASK,prmBC000D10)
             ,new CursorDef("BC000D11", "DELETE FROM `PromocionDistribuidor`  WHERE `PromocionDistribuidorID` = @PromocionDistribuidorID", GxErrorMask.GX_NOMASK,prmBC000D11)
             ,new CursorDef("BC000D12", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D13", "SELECT `DistribuidorDescripcion` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D14", "SELECT TM1.`PromocionDistribuidorID`, T2.`PromocionDescripcion`, T2.`PromocionBase`, T2.`PromocionArte_GXI`, T2.`PromocionFechaInicio`, T2.`PromocionFechaFin`, T3.`DistribuidorDescripcion`, TM1.`PromocionID`, TM1.`DistribuidorID`, T2.`PromocionArte` FROM ((`PromocionDistribuidor` TM1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = TM1.`PromocionID`) INNER JOIN `Distribuidor` T3 ON T3.`DistribuidorID` = TM1.`DistribuidorID`) WHERE TM1.`PromocionDistribuidorID` = @PromocionDistribuidorID ORDER BY TM1.`PromocionDistribuidorID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D14,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
                return;
       }
    }

 }

}
