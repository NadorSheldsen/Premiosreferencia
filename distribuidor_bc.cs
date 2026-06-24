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
   public class distribuidor_bc : GxSilentTrn, IGxSilentTrn
   {
      public distribuidor_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public distribuidor_bc( IGxContext context )
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
         ReadRow044( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey044( ) ;
         standaloneModal( ) ;
         AddRow044( ) ;
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
               Z10DistribuidorID = A10DistribuidorID;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z11DistribuidorDescripcion = A11DistribuidorDescripcion;
            Z12DistribuidorRFC = A12DistribuidorRFC;
         }
         if ( GX_JID == -1 )
         {
            Z10DistribuidorID = A10DistribuidorID;
            Z11DistribuidorDescripcion = A11DistribuidorDescripcion;
            Z12DistribuidorRFC = A12DistribuidorRFC;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load044( )
      {
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound4 = 1;
            A11DistribuidorDescripcion = BC00044_A11DistribuidorDescripcion[0];
            A12DistribuidorRFC = BC00044_A12DistribuidorRFC[0];
            ZM044( -1) ;
         }
         pr_default.close(2);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors044( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 1) ;
            RcdFound4 = 1;
            A10DistribuidorID = BC00043_A10DistribuidorID[0];
            A11DistribuidorDescripcion = BC00043_A11DistribuidorDescripcion[0];
            A12DistribuidorRFC = BC00043_A12DistribuidorRFC[0];
            Z10DistribuidorID = A10DistribuidorID;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         CONFIRM_040( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A10DistribuidorID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Distribuidor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z11DistribuidorDescripcion, BC00042_A11DistribuidorDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z12DistribuidorRFC, BC00042_A12DistribuidorRFC[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Distribuidor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00046 */
                     pr_default.execute(4, new Object[] {A11DistribuidorDescripcion, A12DistribuidorRFC});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00047 */
                     pr_default.execute(5);
                     A10DistribuidorID = BC00047_A10DistribuidorID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Distribuidor");
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00048 */
                     pr_default.execute(6, new Object[] {A11DistribuidorDescripcion, A12DistribuidorRFC, A10DistribuidorID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Distribuidor");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Distribuidor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00049 */
                  pr_default.execute(7, new Object[] {A10DistribuidorID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Distribuidor");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel044( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000410 */
            pr_default.execute(8, new Object[] {A10DistribuidorID});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Promocion Distribuidor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000411 */
            pr_default.execute(9, new Object[] {A10DistribuidorID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "DistribuidoresUsuario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
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

      public void ScanKeyStart044( )
      {
         /* Using cursor BC000412 */
         pr_default.execute(10, new Object[] {A10DistribuidorID});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound4 = 1;
            A10DistribuidorID = BC000412_A10DistribuidorID[0];
            A11DistribuidorDescripcion = BC000412_A11DistribuidorDescripcion[0];
            A12DistribuidorRFC = BC000412_A12DistribuidorRFC[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound4 = 0;
         ScanKeyLoad044( ) ;
      }

      protected void ScanKeyLoad044( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound4 = 1;
            A10DistribuidorID = BC000412_A10DistribuidorID[0];
            A11DistribuidorDescripcion = BC000412_A11DistribuidorDescripcion[0];
            A12DistribuidorRFC = BC000412_A12DistribuidorRFC[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd044( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void AddRow044( )
      {
         VarsToRow4( bcDistribuidor) ;
      }

      protected void ReadRow044( )
      {
         RowToVars4( bcDistribuidor, 1) ;
      }

      protected void InitializeNonKey044( )
      {
         A11DistribuidorDescripcion = "";
         A12DistribuidorRFC = "";
         Z11DistribuidorDescripcion = "";
         Z12DistribuidorRFC = "";
      }

      protected void InitAll044( )
      {
         A10DistribuidorID = 0;
         InitializeNonKey044( ) ;
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

      public void VarsToRow4( SdtDistribuidor obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Distribuidordescripcion = A11DistribuidorDescripcion;
         obj4.gxTpr_Distribuidorrfc = A12DistribuidorRFC;
         obj4.gxTpr_Distribuidorid = A10DistribuidorID;
         obj4.gxTpr_Distribuidorid_Z = Z10DistribuidorID;
         obj4.gxTpr_Distribuidordescripcion_Z = Z11DistribuidorDescripcion;
         obj4.gxTpr_Distribuidorrfc_Z = Z12DistribuidorRFC;
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( SdtDistribuidor obj4 )
      {
         obj4.gxTpr_Distribuidorid = A10DistribuidorID;
         return  ;
      }

      public void RowToVars4( SdtDistribuidor obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A11DistribuidorDescripcion = obj4.gxTpr_Distribuidordescripcion;
         A12DistribuidorRFC = obj4.gxTpr_Distribuidorrfc;
         A10DistribuidorID = obj4.gxTpr_Distribuidorid;
         Z10DistribuidorID = obj4.gxTpr_Distribuidorid_Z;
         Z11DistribuidorDescripcion = obj4.gxTpr_Distribuidordescripcion_Z;
         Z12DistribuidorRFC = obj4.gxTpr_Distribuidorrfc_Z;
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A10DistribuidorID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey044( ) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z10DistribuidorID = A10DistribuidorID;
         }
         ZM044( -1) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
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
         RowToVars4( bcDistribuidor, 0) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z10DistribuidorID = A10DistribuidorID;
         }
         ZM044( -1) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert044( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A10DistribuidorID != Z10DistribuidorID )
               {
                  A10DistribuidorID = Z10DistribuidorID;
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
                  Update044( ) ;
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
                  if ( A10DistribuidorID != Z10DistribuidorID )
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
                        Insert044( ) ;
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
                        Insert044( ) ;
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
         RowToVars4( bcDistribuidor, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcDistribuidor) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcDistribuidor, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcDistribuidor) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow4( bcDistribuidor) ;
         }
         else
         {
            SdtDistribuidor auxBC = new SdtDistribuidor(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A10DistribuidorID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDistribuidor);
               auxBC.Save();
               bcDistribuidor.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars4( bcDistribuidor, 1) ;
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
         RowToVars4( bcDistribuidor, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
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
               VarsToRow4( bcDistribuidor) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow4( bcDistribuidor) ;
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
         RowToVars4( bcDistribuidor, 0) ;
         GetKey044( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A10DistribuidorID != Z10DistribuidorID )
            {
               A10DistribuidorID = Z10DistribuidorID;
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
            if ( A10DistribuidorID != Z10DistribuidorID )
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
         context.RollbackDataStores("distribuidor_bc",pr_default);
         VarsToRow4( bcDistribuidor) ;
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
         Gx_mode = bcDistribuidor.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDistribuidor.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDistribuidor )
         {
            bcDistribuidor = (SdtDistribuidor)(sdt);
            if ( StringUtil.StrCmp(bcDistribuidor.gxTpr_Mode, "") == 0 )
            {
               bcDistribuidor.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcDistribuidor) ;
            }
            else
            {
               RowToVars4( bcDistribuidor, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDistribuidor.gxTpr_Mode, "") == 0 )
            {
               bcDistribuidor.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcDistribuidor, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtDistribuidor Distribuidor_BC
      {
         get {
            return bcDistribuidor ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z11DistribuidorDescripcion = "";
         A11DistribuidorDescripcion = "";
         Z12DistribuidorRFC = "";
         A12DistribuidorRFC = "";
         BC00044_A10DistribuidorID = new int[1] ;
         BC00044_A11DistribuidorDescripcion = new string[] {""} ;
         BC00044_A12DistribuidorRFC = new string[] {""} ;
         BC00045_A10DistribuidorID = new int[1] ;
         BC00043_A10DistribuidorID = new int[1] ;
         BC00043_A11DistribuidorDescripcion = new string[] {""} ;
         BC00043_A12DistribuidorRFC = new string[] {""} ;
         sMode4 = "";
         BC00042_A10DistribuidorID = new int[1] ;
         BC00042_A11DistribuidorDescripcion = new string[] {""} ;
         BC00042_A12DistribuidorRFC = new string[] {""} ;
         BC00047_A10DistribuidorID = new int[1] ;
         BC000410_A47PromocionDistribuidorID = new int[1] ;
         BC000411_A81DistribuidoresUsuarioID = new int[1] ;
         BC000412_A10DistribuidorID = new int[1] ;
         BC000412_A11DistribuidorDescripcion = new string[] {""} ;
         BC000412_A12DistribuidorRFC = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.distribuidor_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A10DistribuidorID, BC00042_A11DistribuidorDescripcion, BC00042_A12DistribuidorRFC
               }
               , new Object[] {
               BC00043_A10DistribuidorID, BC00043_A11DistribuidorDescripcion, BC00043_A12DistribuidorRFC
               }
               , new Object[] {
               BC00044_A10DistribuidorID, BC00044_A11DistribuidorDescripcion, BC00044_A12DistribuidorRFC
               }
               , new Object[] {
               BC00045_A10DistribuidorID
               }
               , new Object[] {
               }
               , new Object[] {
               BC00047_A10DistribuidorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000410_A47PromocionDistribuidorID
               }
               , new Object[] {
               BC000411_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               BC000412_A10DistribuidorID, BC000412_A11DistribuidorDescripcion, BC000412_A12DistribuidorRFC
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound4 ;
      private int trnEnded ;
      private int Z10DistribuidorID ;
      private int A10DistribuidorID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z12DistribuidorRFC ;
      private string A12DistribuidorRFC ;
      private string sMode4 ;
      private string Z11DistribuidorDescripcion ;
      private string A11DistribuidorDescripcion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00044_A10DistribuidorID ;
      private string[] BC00044_A11DistribuidorDescripcion ;
      private string[] BC00044_A12DistribuidorRFC ;
      private int[] BC00045_A10DistribuidorID ;
      private int[] BC00043_A10DistribuidorID ;
      private string[] BC00043_A11DistribuidorDescripcion ;
      private string[] BC00043_A12DistribuidorRFC ;
      private int[] BC00042_A10DistribuidorID ;
      private string[] BC00042_A11DistribuidorDescripcion ;
      private string[] BC00042_A12DistribuidorRFC ;
      private int[] BC00047_A10DistribuidorID ;
      private int[] BC000410_A47PromocionDistribuidorID ;
      private int[] BC000411_A81DistribuidoresUsuarioID ;
      private int[] BC000412_A10DistribuidorID ;
      private string[] BC000412_A11DistribuidorDescripcion ;
      private string[] BC000412_A12DistribuidorRFC ;
      private SdtDistribuidor bcDistribuidor ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class distribuidor_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00042;
          prmBC00042 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC00043;
          prmBC00043 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC00044;
          prmBC00044 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC00045;
          prmBC00045 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC00046;
          prmBC00046 = new Object[] {
          new ParDef("@DistribuidorDescripcion",GXType.Char,80,0) ,
          new ParDef("@DistribuidorRFC",GXType.Char,13,0)
          };
          Object[] prmBC00047;
          prmBC00047 = new Object[] {
          };
          Object[] prmBC00048;
          prmBC00048 = new Object[] {
          new ParDef("@DistribuidorDescripcion",GXType.Char,80,0) ,
          new ParDef("@DistribuidorRFC",GXType.Char,13,0) ,
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC00049;
          prmBC00049 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000410;
          prmBC000410 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000411;
          prmBC000411 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000412;
          prmBC000412 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00042", "SELECT `DistribuidorID`, `DistribuidorDescripcion`, `DistribuidorRFC` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00043", "SELECT `DistribuidorID`, `DistribuidorDescripcion`, `DistribuidorRFC` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00044", "SELECT TM1.`DistribuidorID`, TM1.`DistribuidorDescripcion`, TM1.`DistribuidorRFC` FROM `Distribuidor` TM1 WHERE TM1.`DistribuidorID` = @DistribuidorID ORDER BY TM1.`DistribuidorID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00045", "SELECT `DistribuidorID` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00046", "INSERT INTO `Distribuidor`(`DistribuidorDescripcion`, `DistribuidorRFC`) VALUES(@DistribuidorDescripcion, @DistribuidorRFC)", GxErrorMask.GX_NOMASK,prmBC00046)
             ,new CursorDef("BC00047", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00048", "UPDATE `Distribuidor` SET `DistribuidorDescripcion`=@DistribuidorDescripcion, `DistribuidorRFC`=@DistribuidorRFC  WHERE `DistribuidorID` = @DistribuidorID", GxErrorMask.GX_NOMASK,prmBC00048)
             ,new CursorDef("BC00049", "DELETE FROM `Distribuidor`  WHERE `DistribuidorID` = @DistribuidorID", GxErrorMask.GX_NOMASK,prmBC00049)
             ,new CursorDef("BC000410", "SELECT `PromocionDistribuidorID` FROM `PromocionDistribuidor` WHERE `DistribuidorID` = @DistribuidorID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000410,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000411", "SELECT `DistribuidoresUsuarioID` FROM `DistribuidoresUsuario` WHERE `DistribuidorID` = @DistribuidorID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000411,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000412", "SELECT TM1.`DistribuidorID`, TM1.`DistribuidorDescripcion`, TM1.`DistribuidorRFC` FROM `Distribuidor` TM1 WHERE TM1.`DistribuidorID` = @DistribuidorID ORDER BY TM1.`DistribuidorID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000412,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 13);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 13);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 13);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 13);
                return;
       }
    }

 }

}
