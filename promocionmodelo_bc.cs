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
   public class promocionmodelo_bc : GxSilentTrn, IGxSilentTrn
   {
      public promocionmodelo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public promocionmodelo_bc( IGxContext context )
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
         ReadRow0E14( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0E14( ) ;
         standaloneModal( ) ;
         AddRow0E14( ) ;
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
               Z48PromocionModeloID = A48PromocionModeloID;
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E14( ) ;
            }
            else
            {
               CheckExtendedTable0E14( ) ;
               if ( AnyError == 0 )
               {
                  ZM0E14( 2) ;
                  ZM0E14( 3) ;
               }
               CloseExtendedTableCursors0E14( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0E14( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z49PromocionModeloPrecio = A49PromocionModeloPrecio;
            Z41PromocionID = A41PromocionID;
            Z22ModeloID = A22ModeloID;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z23ModeloDescripcion = A23ModeloDescripcion;
            Z25ModeloSegmento = A25ModeloSegmento;
         }
         if ( GX_JID == -1 )
         {
            Z48PromocionModeloID = A48PromocionModeloID;
            Z49PromocionModeloPrecio = A49PromocionModeloPrecio;
            Z41PromocionID = A41PromocionID;
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

      protected void Load0E14( )
      {
         /* Using cursor BC000E6 */
         pr_default.execute(4, new Object[] {A48PromocionModeloID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound14 = 1;
            A23ModeloDescripcion = BC000E6_A23ModeloDescripcion[0];
            A25ModeloSegmento = BC000E6_A25ModeloSegmento[0];
            A49PromocionModeloPrecio = BC000E6_A49PromocionModeloPrecio[0];
            A41PromocionID = BC000E6_A41PromocionID[0];
            A22ModeloID = BC000E6_A22ModeloID[0];
            ZM0E14( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0E14( ) ;
      }

      protected void OnLoadActions0E14( )
      {
      }

      protected void CheckExtendedTable0E14( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000E4 */
         pr_default.execute(2, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC000E5 */
         pr_default.execute(3, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
         }
         A23ModeloDescripcion = BC000E5_A23ModeloDescripcion[0];
         A25ModeloSegmento = BC000E5_A25ModeloSegmento[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0E14( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E14( )
      {
         /* Using cursor BC000E7 */
         pr_default.execute(5, new Object[] {A48PromocionModeloID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000E3 */
         pr_default.execute(1, new Object[] {A48PromocionModeloID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E14( 1) ;
            RcdFound14 = 1;
            A48PromocionModeloID = BC000E3_A48PromocionModeloID[0];
            A49PromocionModeloPrecio = BC000E3_A49PromocionModeloPrecio[0];
            A41PromocionID = BC000E3_A41PromocionID[0];
            A22ModeloID = BC000E3_A22ModeloID[0];
            Z48PromocionModeloID = A48PromocionModeloID;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0E14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0E14( ) ;
            }
            Gx_mode = sMode14;
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0E14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode14;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E14( ) ;
         if ( RcdFound14 == 0 )
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
         CONFIRM_0E0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0E14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000E2 */
            pr_default.execute(0, new Object[] {A48PromocionModeloID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromocionModelo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z49PromocionModeloPrecio != BC000E2_A49PromocionModeloPrecio[0] ) || ( Z41PromocionID != BC000E2_A41PromocionID[0] ) || ( Z22ModeloID != BC000E2_A22ModeloID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PromocionModelo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E14( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E14( 0) ;
            CheckOptimisticConcurrency0E14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E8 */
                     pr_default.execute(6, new Object[] {A49PromocionModeloPrecio, A41PromocionID, A22ModeloID});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000E9 */
                     pr_default.execute(7);
                     A48PromocionModeloID = BC000E9_A48PromocionModeloID[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("PromocionModelo");
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
               Load0E14( ) ;
            }
            EndLevel0E14( ) ;
         }
         CloseExtendedTableCursors0E14( ) ;
      }

      protected void Update0E14( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E10 */
                     pr_default.execute(8, new Object[] {A49PromocionModeloPrecio, A41PromocionID, A22ModeloID, A48PromocionModeloID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("PromocionModelo");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromocionModelo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E14( ) ;
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
            EndLevel0E14( ) ;
         }
         CloseExtendedTableCursors0E14( ) ;
      }

      protected void DeferredUpdate0E14( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E14( ) ;
            AfterConfirm0E14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000E11 */
                  pr_default.execute(9, new Object[] {A48PromocionModeloID});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("PromocionModelo");
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0E14( ) ;
         Gx_mode = sMode14;
      }

      protected void OnDeleteControls0E14( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000E12 */
            pr_default.execute(10, new Object[] {A22ModeloID});
            A23ModeloDescripcion = BC000E12_A23ModeloDescripcion[0];
            A25ModeloSegmento = BC000E12_A25ModeloSegmento[0];
            pr_default.close(10);
         }
      }

      protected void EndLevel0E14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E14( ) ;
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

      public void ScanKeyStart0E14( )
      {
         /* Using cursor BC000E13 */
         pr_default.execute(11, new Object[] {A48PromocionModeloID});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound14 = 1;
            A48PromocionModeloID = BC000E13_A48PromocionModeloID[0];
            A23ModeloDescripcion = BC000E13_A23ModeloDescripcion[0];
            A25ModeloSegmento = BC000E13_A25ModeloSegmento[0];
            A49PromocionModeloPrecio = BC000E13_A49PromocionModeloPrecio[0];
            A41PromocionID = BC000E13_A41PromocionID[0];
            A22ModeloID = BC000E13_A22ModeloID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0E14( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound14 = 0;
         ScanKeyLoad0E14( ) ;
      }

      protected void ScanKeyLoad0E14( )
      {
         sMode14 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound14 = 1;
            A48PromocionModeloID = BC000E13_A48PromocionModeloID[0];
            A23ModeloDescripcion = BC000E13_A23ModeloDescripcion[0];
            A25ModeloSegmento = BC000E13_A25ModeloSegmento[0];
            A49PromocionModeloPrecio = BC000E13_A49PromocionModeloPrecio[0];
            A41PromocionID = BC000E13_A41PromocionID[0];
            A22ModeloID = BC000E13_A22ModeloID[0];
         }
         Gx_mode = sMode14;
      }

      protected void ScanKeyEnd0E14( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0E14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E14( )
      {
      }

      protected void send_integrity_lvl_hashes0E14( )
      {
      }

      protected void AddRow0E14( )
      {
         VarsToRow14( bcPromocionModelo) ;
      }

      protected void ReadRow0E14( )
      {
         RowToVars14( bcPromocionModelo, 1) ;
      }

      protected void InitializeNonKey0E14( )
      {
         A41PromocionID = 0;
         A22ModeloID = 0;
         A23ModeloDescripcion = "";
         A25ModeloSegmento = "";
         A49PromocionModeloPrecio = 0;
         Z49PromocionModeloPrecio = 0;
         Z41PromocionID = 0;
         Z22ModeloID = 0;
      }

      protected void InitAll0E14( )
      {
         A48PromocionModeloID = 0;
         InitializeNonKey0E14( ) ;
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

      public void VarsToRow14( SdtPromocionModelo obj14 )
      {
         obj14.gxTpr_Mode = Gx_mode;
         obj14.gxTpr_Promocionid = A41PromocionID;
         obj14.gxTpr_Modeloid = A22ModeloID;
         obj14.gxTpr_Modelodescripcion = A23ModeloDescripcion;
         obj14.gxTpr_Modelosegmento = A25ModeloSegmento;
         obj14.gxTpr_Promocionmodeloprecio = A49PromocionModeloPrecio;
         obj14.gxTpr_Promocionmodeloid = A48PromocionModeloID;
         obj14.gxTpr_Promocionmodeloid_Z = Z48PromocionModeloID;
         obj14.gxTpr_Promocionid_Z = Z41PromocionID;
         obj14.gxTpr_Modeloid_Z = Z22ModeloID;
         obj14.gxTpr_Modelodescripcion_Z = Z23ModeloDescripcion;
         obj14.gxTpr_Modelosegmento_Z = Z25ModeloSegmento;
         obj14.gxTpr_Promocionmodeloprecio_Z = Z49PromocionModeloPrecio;
         obj14.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow14( SdtPromocionModelo obj14 )
      {
         obj14.gxTpr_Promocionmodeloid = A48PromocionModeloID;
         return  ;
      }

      public void RowToVars14( SdtPromocionModelo obj14 ,
                               int forceLoad )
      {
         Gx_mode = obj14.gxTpr_Mode;
         A41PromocionID = obj14.gxTpr_Promocionid;
         A22ModeloID = obj14.gxTpr_Modeloid;
         A23ModeloDescripcion = obj14.gxTpr_Modelodescripcion;
         A25ModeloSegmento = obj14.gxTpr_Modelosegmento;
         A49PromocionModeloPrecio = obj14.gxTpr_Promocionmodeloprecio;
         A48PromocionModeloID = obj14.gxTpr_Promocionmodeloid;
         Z48PromocionModeloID = obj14.gxTpr_Promocionmodeloid_Z;
         Z41PromocionID = obj14.gxTpr_Promocionid_Z;
         Z22ModeloID = obj14.gxTpr_Modeloid_Z;
         Z23ModeloDescripcion = obj14.gxTpr_Modelodescripcion_Z;
         Z25ModeloSegmento = obj14.gxTpr_Modelosegmento_Z;
         Z49PromocionModeloPrecio = obj14.gxTpr_Promocionmodeloprecio_Z;
         Gx_mode = obj14.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A48PromocionModeloID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0E14( ) ;
         ScanKeyStart0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z48PromocionModeloID = A48PromocionModeloID;
         }
         ZM0E14( -1) ;
         OnLoadActions0E14( ) ;
         AddRow0E14( ) ;
         ScanKeyEnd0E14( ) ;
         if ( RcdFound14 == 0 )
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
         RowToVars14( bcPromocionModelo, 0) ;
         ScanKeyStart0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z48PromocionModeloID = A48PromocionModeloID;
         }
         ZM0E14( -1) ;
         OnLoadActions0E14( ) ;
         AddRow0E14( ) ;
         ScanKeyEnd0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0E14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0E14( ) ;
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( A48PromocionModeloID != Z48PromocionModeloID )
               {
                  A48PromocionModeloID = Z48PromocionModeloID;
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
                  Update0E14( ) ;
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
                  if ( A48PromocionModeloID != Z48PromocionModeloID )
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
                        Insert0E14( ) ;
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
                        Insert0E14( ) ;
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
         RowToVars14( bcPromocionModelo, 1) ;
         SaveImpl( ) ;
         VarsToRow14( bcPromocionModelo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars14( bcPromocionModelo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E14( ) ;
         AfterTrn( ) ;
         VarsToRow14( bcPromocionModelo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow14( bcPromocionModelo) ;
         }
         else
         {
            SdtPromocionModelo auxBC = new SdtPromocionModelo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A48PromocionModeloID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPromocionModelo);
               auxBC.Save();
               bcPromocionModelo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars14( bcPromocionModelo, 1) ;
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
         RowToVars14( bcPromocionModelo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E14( ) ;
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
               VarsToRow14( bcPromocionModelo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow14( bcPromocionModelo) ;
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
         RowToVars14( bcPromocionModelo, 0) ;
         GetKey0E14( ) ;
         if ( RcdFound14 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A48PromocionModeloID != Z48PromocionModeloID )
            {
               A48PromocionModeloID = Z48PromocionModeloID;
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
            if ( A48PromocionModeloID != Z48PromocionModeloID )
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
         context.RollbackDataStores("promocionmodelo_bc",pr_default);
         VarsToRow14( bcPromocionModelo) ;
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
         Gx_mode = bcPromocionModelo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPromocionModelo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPromocionModelo )
         {
            bcPromocionModelo = (SdtPromocionModelo)(sdt);
            if ( StringUtil.StrCmp(bcPromocionModelo.gxTpr_Mode, "") == 0 )
            {
               bcPromocionModelo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow14( bcPromocionModelo) ;
            }
            else
            {
               RowToVars14( bcPromocionModelo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPromocionModelo.gxTpr_Mode, "") == 0 )
            {
               bcPromocionModelo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars14( bcPromocionModelo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPromocionModelo PromocionModelo_BC
      {
         get {
            return bcPromocionModelo ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z23ModeloDescripcion = "";
         A23ModeloDescripcion = "";
         Z25ModeloSegmento = "";
         A25ModeloSegmento = "";
         BC000E6_A48PromocionModeloID = new int[1] ;
         BC000E6_A23ModeloDescripcion = new string[] {""} ;
         BC000E6_A25ModeloSegmento = new string[] {""} ;
         BC000E6_A49PromocionModeloPrecio = new decimal[1] ;
         BC000E6_A41PromocionID = new int[1] ;
         BC000E6_A22ModeloID = new int[1] ;
         BC000E4_A41PromocionID = new int[1] ;
         BC000E5_A23ModeloDescripcion = new string[] {""} ;
         BC000E5_A25ModeloSegmento = new string[] {""} ;
         BC000E7_A48PromocionModeloID = new int[1] ;
         BC000E3_A48PromocionModeloID = new int[1] ;
         BC000E3_A49PromocionModeloPrecio = new decimal[1] ;
         BC000E3_A41PromocionID = new int[1] ;
         BC000E3_A22ModeloID = new int[1] ;
         sMode14 = "";
         BC000E2_A48PromocionModeloID = new int[1] ;
         BC000E2_A49PromocionModeloPrecio = new decimal[1] ;
         BC000E2_A41PromocionID = new int[1] ;
         BC000E2_A22ModeloID = new int[1] ;
         BC000E9_A48PromocionModeloID = new int[1] ;
         BC000E12_A23ModeloDescripcion = new string[] {""} ;
         BC000E12_A25ModeloSegmento = new string[] {""} ;
         BC000E13_A48PromocionModeloID = new int[1] ;
         BC000E13_A23ModeloDescripcion = new string[] {""} ;
         BC000E13_A25ModeloSegmento = new string[] {""} ;
         BC000E13_A49PromocionModeloPrecio = new decimal[1] ;
         BC000E13_A41PromocionID = new int[1] ;
         BC000E13_A22ModeloID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promocionmodelo_bc__default(),
            new Object[][] {
                new Object[] {
               BC000E2_A48PromocionModeloID, BC000E2_A49PromocionModeloPrecio, BC000E2_A41PromocionID, BC000E2_A22ModeloID
               }
               , new Object[] {
               BC000E3_A48PromocionModeloID, BC000E3_A49PromocionModeloPrecio, BC000E3_A41PromocionID, BC000E3_A22ModeloID
               }
               , new Object[] {
               BC000E4_A41PromocionID
               }
               , new Object[] {
               BC000E5_A23ModeloDescripcion, BC000E5_A25ModeloSegmento
               }
               , new Object[] {
               BC000E6_A48PromocionModeloID, BC000E6_A23ModeloDescripcion, BC000E6_A25ModeloSegmento, BC000E6_A49PromocionModeloPrecio, BC000E6_A41PromocionID, BC000E6_A22ModeloID
               }
               , new Object[] {
               BC000E7_A48PromocionModeloID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E9_A48PromocionModeloID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E12_A23ModeloDescripcion, BC000E12_A25ModeloSegmento
               }
               , new Object[] {
               BC000E13_A48PromocionModeloID, BC000E13_A23ModeloDescripcion, BC000E13_A25ModeloSegmento, BC000E13_A49PromocionModeloPrecio, BC000E13_A41PromocionID, BC000E13_A22ModeloID
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound14 ;
      private int trnEnded ;
      private int Z48PromocionModeloID ;
      private int A48PromocionModeloID ;
      private int Z41PromocionID ;
      private int A41PromocionID ;
      private int Z22ModeloID ;
      private int A22ModeloID ;
      private decimal Z49PromocionModeloPrecio ;
      private decimal A49PromocionModeloPrecio ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z25ModeloSegmento ;
      private string A25ModeloSegmento ;
      private string sMode14 ;
      private string Z23ModeloDescripcion ;
      private string A23ModeloDescripcion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000E6_A48PromocionModeloID ;
      private string[] BC000E6_A23ModeloDescripcion ;
      private string[] BC000E6_A25ModeloSegmento ;
      private decimal[] BC000E6_A49PromocionModeloPrecio ;
      private int[] BC000E6_A41PromocionID ;
      private int[] BC000E6_A22ModeloID ;
      private int[] BC000E4_A41PromocionID ;
      private string[] BC000E5_A23ModeloDescripcion ;
      private string[] BC000E5_A25ModeloSegmento ;
      private int[] BC000E7_A48PromocionModeloID ;
      private int[] BC000E3_A48PromocionModeloID ;
      private decimal[] BC000E3_A49PromocionModeloPrecio ;
      private int[] BC000E3_A41PromocionID ;
      private int[] BC000E3_A22ModeloID ;
      private int[] BC000E2_A48PromocionModeloID ;
      private decimal[] BC000E2_A49PromocionModeloPrecio ;
      private int[] BC000E2_A41PromocionID ;
      private int[] BC000E2_A22ModeloID ;
      private int[] BC000E9_A48PromocionModeloID ;
      private string[] BC000E12_A23ModeloDescripcion ;
      private string[] BC000E12_A25ModeloSegmento ;
      private int[] BC000E13_A48PromocionModeloID ;
      private string[] BC000E13_A23ModeloDescripcion ;
      private string[] BC000E13_A25ModeloSegmento ;
      private decimal[] BC000E13_A49PromocionModeloPrecio ;
      private int[] BC000E13_A41PromocionID ;
      private int[] BC000E13_A22ModeloID ;
      private SdtPromocionModelo bcPromocionModelo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class promocionmodelo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000E2;
          prmBC000E2 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000E3;
          prmBC000E3 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000E4;
          prmBC000E4 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000E5;
          prmBC000E5 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000E6;
          prmBC000E6 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000E7;
          prmBC000E7 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000E8;
          prmBC000E8 = new Object[] {
          new ParDef("@PromocionModeloPrecio",GXType.Number,10,2) ,
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000E9;
          prmBC000E9 = new Object[] {
          };
          Object[] prmBC000E10;
          prmBC000E10 = new Object[] {
          new ParDef("@PromocionModeloPrecio",GXType.Number,10,2) ,
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@ModeloID",GXType.Int32,9,0) ,
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000E11;
          prmBC000E11 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000E12;
          prmBC000E12 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000E13;
          prmBC000E13 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000E2", "SELECT `PromocionModeloID`, `PromocionModeloPrecio`, `PromocionID`, `ModeloID` FROM `PromocionModelo` WHERE `PromocionModeloID` = @PromocionModeloID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E3", "SELECT `PromocionModeloID`, `PromocionModeloPrecio`, `PromocionID`, `ModeloID` FROM `PromocionModelo` WHERE `PromocionModeloID` = @PromocionModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E4", "SELECT `PromocionID` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E5", "SELECT `ModeloDescripcion`, `ModeloSegmento` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E6", "SELECT TM1.`PromocionModeloID`, T2.`ModeloDescripcion`, T2.`ModeloSegmento`, TM1.`PromocionModeloPrecio`, TM1.`PromocionID`, TM1.`ModeloID` FROM (`PromocionModelo` TM1 INNER JOIN `Modelo` T2 ON T2.`ModeloID` = TM1.`ModeloID`) WHERE TM1.`PromocionModeloID` = @PromocionModeloID ORDER BY TM1.`PromocionModeloID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E7", "SELECT `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionModeloID` = @PromocionModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E8", "INSERT INTO `PromocionModelo`(`PromocionModeloPrecio`, `PromocionID`, `ModeloID`) VALUES(@PromocionModeloPrecio, @PromocionID, @ModeloID)", GxErrorMask.GX_NOMASK,prmBC000E8)
             ,new CursorDef("BC000E9", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E10", "UPDATE `PromocionModelo` SET `PromocionModeloPrecio`=@PromocionModeloPrecio, `PromocionID`=@PromocionID, `ModeloID`=@ModeloID  WHERE `PromocionModeloID` = @PromocionModeloID", GxErrorMask.GX_NOMASK,prmBC000E10)
             ,new CursorDef("BC000E11", "DELETE FROM `PromocionModelo`  WHERE `PromocionModeloID` = @PromocionModeloID", GxErrorMask.GX_NOMASK,prmBC000E11)
             ,new CursorDef("BC000E12", "SELECT `ModeloDescripcion`, `ModeloSegmento` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E13", "SELECT TM1.`PromocionModeloID`, T2.`ModeloDescripcion`, T2.`ModeloSegmento`, TM1.`PromocionModeloPrecio`, TM1.`PromocionID`, TM1.`ModeloID` FROM (`PromocionModelo` TM1 INNER JOIN `Modelo` T2 ON T2.`ModeloID` = TM1.`ModeloID`) WHERE TM1.`PromocionModeloID` = @PromocionModeloID ORDER BY TM1.`PromocionModeloID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E13,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
