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
   public class motivorechazo_bc : GxSilentTrn, IGxSilentTrn
   {
      public motivorechazo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public motivorechazo_bc( IGxContext context )
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
         ReadRow077( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey077( ) ;
         standaloneModal( ) ;
         AddRow077( ) ;
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
               Z19MotivoRechazoID = A19MotivoRechazoID;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z20MotivoRechazoDescripcion = A20MotivoRechazoDescripcion;
            Z21MotivoRechazoActivo = A21MotivoRechazoActivo;
         }
         if ( GX_JID == -1 )
         {
            Z19MotivoRechazoID = A19MotivoRechazoID;
            Z20MotivoRechazoDescripcion = A20MotivoRechazoDescripcion;
            Z21MotivoRechazoActivo = A21MotivoRechazoActivo;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load077( )
      {
         /* Using cursor BC00074 */
         pr_default.execute(2, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound7 = 1;
            A20MotivoRechazoDescripcion = BC00074_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC00074_A21MotivoRechazoActivo[0];
            ZM077( -1) ;
         }
         pr_default.close(2);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
      }

      protected void CheckExtendedTable077( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors077( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey077( )
      {
         /* Using cursor BC00075 */
         pr_default.execute(3, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 1) ;
            RcdFound7 = 1;
            A19MotivoRechazoID = BC00073_A19MotivoRechazoID[0];
            A20MotivoRechazoDescripcion = BC00073_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC00073_A21MotivoRechazoActivo[0];
            Z19MotivoRechazoID = A19MotivoRechazoID;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode7;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
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
         CONFIRM_070( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {A19MotivoRechazoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MotivoRechazo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z20MotivoRechazoDescripcion, BC00072_A20MotivoRechazoDescripcion[0]) != 0 ) || ( Z21MotivoRechazoActivo != BC00072_A21MotivoRechazoActivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MotivoRechazo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00076 */
                     pr_default.execute(4, new Object[] {A20MotivoRechazoDescripcion, A21MotivoRechazoActivo});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00077 */
                     pr_default.execute(5);
                     A19MotivoRechazoID = BC00077_A19MotivoRechazoID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("MotivoRechazo");
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00078 */
                     pr_default.execute(6, new Object[] {A20MotivoRechazoDescripcion, A21MotivoRechazoActivo, A19MotivoRechazoID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("MotivoRechazo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MotivoRechazo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00079 */
                  pr_default.execute(7, new Object[] {A19MotivoRechazoID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("MotivoRechazo");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel077( ) ;
         Gx_mode = sMode7;
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000710 */
            pr_default.execute(8, new Object[] {A19MotivoRechazoID});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Factura", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
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

      public void ScanKeyStart077( )
      {
         /* Using cursor BC000711 */
         pr_default.execute(9, new Object[] {A19MotivoRechazoID});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
            A19MotivoRechazoID = BC000711_A19MotivoRechazoID[0];
            A20MotivoRechazoDescripcion = BC000711_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC000711_A21MotivoRechazoActivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound7 = 0;
         ScanKeyLoad077( ) ;
      }

      protected void ScanKeyLoad077( )
      {
         sMode7 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
            A19MotivoRechazoID = BC000711_A19MotivoRechazoID[0];
            A20MotivoRechazoDescripcion = BC000711_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC000711_A21MotivoRechazoActivo[0];
         }
         Gx_mode = sMode7;
      }

      protected void ScanKeyEnd077( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void AddRow077( )
      {
         VarsToRow7( bcMotivoRechazo) ;
      }

      protected void ReadRow077( )
      {
         RowToVars7( bcMotivoRechazo, 1) ;
      }

      protected void InitializeNonKey077( )
      {
         A20MotivoRechazoDescripcion = "";
         A21MotivoRechazoActivo = false;
         Z20MotivoRechazoDescripcion = "";
         Z21MotivoRechazoActivo = false;
      }

      protected void InitAll077( )
      {
         A19MotivoRechazoID = 0;
         InitializeNonKey077( ) ;
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

      public void VarsToRow7( SdtMotivoRechazo obj7 )
      {
         obj7.gxTpr_Mode = Gx_mode;
         obj7.gxTpr_Motivorechazodescripcion = A20MotivoRechazoDescripcion;
         obj7.gxTpr_Motivorechazoactivo = A21MotivoRechazoActivo;
         obj7.gxTpr_Motivorechazoid = A19MotivoRechazoID;
         obj7.gxTpr_Motivorechazoid_Z = Z19MotivoRechazoID;
         obj7.gxTpr_Motivorechazodescripcion_Z = Z20MotivoRechazoDescripcion;
         obj7.gxTpr_Motivorechazoactivo_Z = Z21MotivoRechazoActivo;
         obj7.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow7( SdtMotivoRechazo obj7 )
      {
         obj7.gxTpr_Motivorechazoid = A19MotivoRechazoID;
         return  ;
      }

      public void RowToVars7( SdtMotivoRechazo obj7 ,
                              int forceLoad )
      {
         Gx_mode = obj7.gxTpr_Mode;
         A20MotivoRechazoDescripcion = obj7.gxTpr_Motivorechazodescripcion;
         A21MotivoRechazoActivo = obj7.gxTpr_Motivorechazoactivo;
         A19MotivoRechazoID = obj7.gxTpr_Motivorechazoid;
         Z19MotivoRechazoID = obj7.gxTpr_Motivorechazoid_Z;
         Z20MotivoRechazoDescripcion = obj7.gxTpr_Motivorechazodescripcion_Z;
         Z21MotivoRechazoActivo = obj7.gxTpr_Motivorechazoactivo_Z;
         Gx_mode = obj7.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A19MotivoRechazoID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey077( ) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z19MotivoRechazoID = A19MotivoRechazoID;
         }
         ZM077( -1) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
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
         RowToVars7( bcMotivoRechazo, 0) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z19MotivoRechazoID = A19MotivoRechazoID;
         }
         ZM077( -1) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert077( ) ;
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A19MotivoRechazoID != Z19MotivoRechazoID )
               {
                  A19MotivoRechazoID = Z19MotivoRechazoID;
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
                  Update077( ) ;
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
                  if ( A19MotivoRechazoID != Z19MotivoRechazoID )
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
                        Insert077( ) ;
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
                        Insert077( ) ;
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
         RowToVars7( bcMotivoRechazo, 1) ;
         SaveImpl( ) ;
         VarsToRow7( bcMotivoRechazo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars7( bcMotivoRechazo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
         AfterTrn( ) ;
         VarsToRow7( bcMotivoRechazo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow7( bcMotivoRechazo) ;
         }
         else
         {
            SdtMotivoRechazo auxBC = new SdtMotivoRechazo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A19MotivoRechazoID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcMotivoRechazo);
               auxBC.Save();
               bcMotivoRechazo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars7( bcMotivoRechazo, 1) ;
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
         RowToVars7( bcMotivoRechazo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
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
               VarsToRow7( bcMotivoRechazo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow7( bcMotivoRechazo) ;
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
         RowToVars7( bcMotivoRechazo, 0) ;
         GetKey077( ) ;
         if ( RcdFound7 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A19MotivoRechazoID != Z19MotivoRechazoID )
            {
               A19MotivoRechazoID = Z19MotivoRechazoID;
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
            if ( A19MotivoRechazoID != Z19MotivoRechazoID )
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
         context.RollbackDataStores("motivorechazo_bc",pr_default);
         VarsToRow7( bcMotivoRechazo) ;
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
         Gx_mode = bcMotivoRechazo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcMotivoRechazo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcMotivoRechazo )
         {
            bcMotivoRechazo = (SdtMotivoRechazo)(sdt);
            if ( StringUtil.StrCmp(bcMotivoRechazo.gxTpr_Mode, "") == 0 )
            {
               bcMotivoRechazo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow7( bcMotivoRechazo) ;
            }
            else
            {
               RowToVars7( bcMotivoRechazo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcMotivoRechazo.gxTpr_Mode, "") == 0 )
            {
               bcMotivoRechazo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars7( bcMotivoRechazo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtMotivoRechazo MotivoRechazo_BC
      {
         get {
            return bcMotivoRechazo ;
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
         Z20MotivoRechazoDescripcion = "";
         A20MotivoRechazoDescripcion = "";
         BC00074_A19MotivoRechazoID = new int[1] ;
         BC00074_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC00074_A21MotivoRechazoActivo = new bool[] {false} ;
         BC00075_A19MotivoRechazoID = new int[1] ;
         BC00073_A19MotivoRechazoID = new int[1] ;
         BC00073_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC00073_A21MotivoRechazoActivo = new bool[] {false} ;
         sMode7 = "";
         BC00072_A19MotivoRechazoID = new int[1] ;
         BC00072_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC00072_A21MotivoRechazoActivo = new bool[] {false} ;
         BC00077_A19MotivoRechazoID = new int[1] ;
         BC000710_A69FacturaID = new int[1] ;
         BC000711_A19MotivoRechazoID = new int[1] ;
         BC000711_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC000711_A21MotivoRechazoActivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.motivorechazo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A19MotivoRechazoID, BC00072_A20MotivoRechazoDescripcion, BC00072_A21MotivoRechazoActivo
               }
               , new Object[] {
               BC00073_A19MotivoRechazoID, BC00073_A20MotivoRechazoDescripcion, BC00073_A21MotivoRechazoActivo
               }
               , new Object[] {
               BC00074_A19MotivoRechazoID, BC00074_A20MotivoRechazoDescripcion, BC00074_A21MotivoRechazoActivo
               }
               , new Object[] {
               BC00075_A19MotivoRechazoID
               }
               , new Object[] {
               }
               , new Object[] {
               BC00077_A19MotivoRechazoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000710_A69FacturaID
               }
               , new Object[] {
               BC000711_A19MotivoRechazoID, BC000711_A20MotivoRechazoDescripcion, BC000711_A21MotivoRechazoActivo
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound7 ;
      private int trnEnded ;
      private int Z19MotivoRechazoID ;
      private int A19MotivoRechazoID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode7 ;
      private bool Z21MotivoRechazoActivo ;
      private bool A21MotivoRechazoActivo ;
      private string Z20MotivoRechazoDescripcion ;
      private string A20MotivoRechazoDescripcion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00074_A19MotivoRechazoID ;
      private string[] BC00074_A20MotivoRechazoDescripcion ;
      private bool[] BC00074_A21MotivoRechazoActivo ;
      private int[] BC00075_A19MotivoRechazoID ;
      private int[] BC00073_A19MotivoRechazoID ;
      private string[] BC00073_A20MotivoRechazoDescripcion ;
      private bool[] BC00073_A21MotivoRechazoActivo ;
      private int[] BC00072_A19MotivoRechazoID ;
      private string[] BC00072_A20MotivoRechazoDescripcion ;
      private bool[] BC00072_A21MotivoRechazoActivo ;
      private int[] BC00077_A19MotivoRechazoID ;
      private int[] BC000710_A69FacturaID ;
      private int[] BC000711_A19MotivoRechazoID ;
      private string[] BC000711_A20MotivoRechazoDescripcion ;
      private bool[] BC000711_A21MotivoRechazoActivo ;
      private SdtMotivoRechazo bcMotivoRechazo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class motivorechazo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00072;
          prmBC00072 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC00073;
          prmBC00073 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC00074;
          prmBC00074 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC00075;
          prmBC00075 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC00076;
          prmBC00076 = new Object[] {
          new ParDef("@MotivoRechazoDescripcion",GXType.Char,80,0) ,
          new ParDef("@MotivoRechazoActivo",GXType.Byte,4,0)
          };
          Object[] prmBC00077;
          prmBC00077 = new Object[] {
          };
          Object[] prmBC00078;
          prmBC00078 = new Object[] {
          new ParDef("@MotivoRechazoDescripcion",GXType.Char,80,0) ,
          new ParDef("@MotivoRechazoActivo",GXType.Byte,4,0) ,
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC00079;
          prmBC00079 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC000710;
          prmBC000710 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC000711;
          prmBC000711 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00072", "SELECT `MotivoRechazoID`, `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00073", "SELECT `MotivoRechazoID`, `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00074", "SELECT TM1.`MotivoRechazoID`, TM1.`MotivoRechazoDescripcion`, TM1.`MotivoRechazoActivo` FROM `MotivoRechazo` TM1 WHERE TM1.`MotivoRechazoID` = @MotivoRechazoID ORDER BY TM1.`MotivoRechazoID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00074,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00075", "SELECT `MotivoRechazoID` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00076", "INSERT INTO `MotivoRechazo`(`MotivoRechazoDescripcion`, `MotivoRechazoActivo`) VALUES(@MotivoRechazoDescripcion, @MotivoRechazoActivo)", GxErrorMask.GX_NOMASK,prmBC00076)
             ,new CursorDef("BC00077", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00077,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00078", "UPDATE `MotivoRechazo` SET `MotivoRechazoDescripcion`=@MotivoRechazoDescripcion, `MotivoRechazoActivo`=@MotivoRechazoActivo  WHERE `MotivoRechazoID` = @MotivoRechazoID", GxErrorMask.GX_NOMASK,prmBC00078)
             ,new CursorDef("BC00079", "DELETE FROM `MotivoRechazo`  WHERE `MotivoRechazoID` = @MotivoRechazoID", GxErrorMask.GX_NOMASK,prmBC00079)
             ,new CursorDef("BC000710", "SELECT `FacturaID` FROM `Factura` WHERE `MotivoRechazoID` = @MotivoRechazoID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000710,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000711", "SELECT TM1.`MotivoRechazoID`, TM1.`MotivoRechazoDescripcion`, TM1.`MotivoRechazoActivo` FROM `MotivoRechazo` TM1 WHERE TM1.`MotivoRechazoID` = @MotivoRechazoID ORDER BY TM1.`MotivoRechazoID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000711,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
    }

 }

}
