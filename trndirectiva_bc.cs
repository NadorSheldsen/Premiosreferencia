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
   public class trndirectiva_bc : GxSilentTrn, IGxSilentTrn
   {
      public trndirectiva_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trndirectiva_bc( IGxContext context )
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
         ReadRow0J19( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0J19( ) ;
         standaloneModal( ) ;
         AddRow0J19( ) ;
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
            /* Execute user event: After Trn */
            E110J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z89TrnDirectivaTitle = A89TrnDirectivaTitle;
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J19( ) ;
            }
            else
            {
               CheckExtendedTable0J19( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0J19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0J19( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z90TrnDirectivaValue = A90TrnDirectivaValue;
         }
         if ( GX_JID == -3 )
         {
            Z89TrnDirectivaTitle = A89TrnDirectivaTitle;
            Z90TrnDirectivaValue = A90TrnDirectivaValue;
            Z91TrnDirectivaDescripcion = A91TrnDirectivaDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0J19( )
      {
         /* Using cursor BC000J4 */
         pr_default.execute(2, new Object[] {A89TrnDirectivaTitle});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A90TrnDirectivaValue = BC000J4_A90TrnDirectivaValue[0];
            A91TrnDirectivaDescripcion = BC000J4_A91TrnDirectivaDescripcion[0];
            ZM0J19( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0J19( ) ;
      }

      protected void OnLoadActions0J19( )
      {
      }

      protected void CheckExtendedTable0J19( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A89TrnDirectivaTitle)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Directiva", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A90TrnDirectivaValue)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Valor", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0J19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0J19( )
      {
         /* Using cursor BC000J5 */
         pr_default.execute(3, new Object[] {A89TrnDirectivaTitle});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000J3 */
         pr_default.execute(1, new Object[] {A89TrnDirectivaTitle});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J19( 3) ;
            RcdFound19 = 1;
            A89TrnDirectivaTitle = BC000J3_A89TrnDirectivaTitle[0];
            A90TrnDirectivaValue = BC000J3_A90TrnDirectivaValue[0];
            A91TrnDirectivaDescripcion = BC000J3_A91TrnDirectivaDescripcion[0];
            Z89TrnDirectivaTitle = A89TrnDirectivaTitle;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0J19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0J19( ) ;
            }
            Gx_mode = sMode19;
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0J19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode19;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J19( ) ;
         if ( RcdFound19 == 0 )
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
         CONFIRM_0J0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0J19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000J2 */
            pr_default.execute(0, new Object[] {A89TrnDirectivaTitle});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrnDirectiva"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z90TrnDirectivaValue, BC000J2_A90TrnDirectivaValue[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrnDirectiva"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J19( )
      {
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J19( 0) ;
            CheckOptimisticConcurrency0J19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J6 */
                     pr_default.execute(4, new Object[] {A89TrnDirectivaTitle, A90TrnDirectivaValue, A91TrnDirectivaDescripcion});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("TrnDirectiva");
                     if ( (pr_default.getStatus(4) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load0J19( ) ;
            }
            EndLevel0J19( ) ;
         }
         CloseExtendedTableCursors0J19( ) ;
      }

      protected void Update0J19( )
      {
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J7 */
                     pr_default.execute(5, new Object[] {A90TrnDirectivaValue, A91TrnDirectivaDescripcion, A89TrnDirectivaTitle});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("TrnDirectiva");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrnDirectiva"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J19( ) ;
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
            EndLevel0J19( ) ;
         }
         CloseExtendedTableCursors0J19( ) ;
      }

      protected void DeferredUpdate0J19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J19( ) ;
            AfterConfirm0J19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000J8 */
                  pr_default.execute(6, new Object[] {A89TrnDirectivaTitle});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("TrnDirectiva");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0J19( ) ;
         Gx_mode = sMode19;
      }

      protected void OnDeleteControls0J19( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0J19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J19( ) ;
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

      public void ScanKeyStart0J19( )
      {
         /* Scan By routine */
         /* Using cursor BC000J9 */
         pr_default.execute(7, new Object[] {A89TrnDirectivaTitle});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound19 = 1;
            A89TrnDirectivaTitle = BC000J9_A89TrnDirectivaTitle[0];
            A90TrnDirectivaValue = BC000J9_A90TrnDirectivaValue[0];
            A91TrnDirectivaDescripcion = BC000J9_A91TrnDirectivaDescripcion[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0J19( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound19 = 0;
         ScanKeyLoad0J19( ) ;
      }

      protected void ScanKeyLoad0J19( )
      {
         sMode19 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound19 = 1;
            A89TrnDirectivaTitle = BC000J9_A89TrnDirectivaTitle[0];
            A90TrnDirectivaValue = BC000J9_A90TrnDirectivaValue[0];
            A91TrnDirectivaDescripcion = BC000J9_A91TrnDirectivaDescripcion[0];
         }
         Gx_mode = sMode19;
      }

      protected void ScanKeyEnd0J19( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0J19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J19( )
      {
      }

      protected void send_integrity_lvl_hashes0J19( )
      {
      }

      protected void AddRow0J19( )
      {
         VarsToRow19( bcTrnDirectiva) ;
      }

      protected void ReadRow0J19( )
      {
         RowToVars19( bcTrnDirectiva, 1) ;
      }

      protected void InitializeNonKey0J19( )
      {
         A90TrnDirectivaValue = "";
         A91TrnDirectivaDescripcion = "";
         Z90TrnDirectivaValue = "";
      }

      protected void InitAll0J19( )
      {
         A89TrnDirectivaTitle = "";
         InitializeNonKey0J19( ) ;
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

      public void VarsToRow19( SdtTrnDirectiva obj19 )
      {
         obj19.gxTpr_Mode = Gx_mode;
         obj19.gxTpr_Trndirectivavalue = A90TrnDirectivaValue;
         obj19.gxTpr_Trndirectivadescripcion = A91TrnDirectivaDescripcion;
         obj19.gxTpr_Trndirectivatitle = A89TrnDirectivaTitle;
         obj19.gxTpr_Trndirectivatitle_Z = Z89TrnDirectivaTitle;
         obj19.gxTpr_Trndirectivavalue_Z = Z90TrnDirectivaValue;
         obj19.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow19( SdtTrnDirectiva obj19 )
      {
         obj19.gxTpr_Trndirectivatitle = A89TrnDirectivaTitle;
         return  ;
      }

      public void RowToVars19( SdtTrnDirectiva obj19 ,
                               int forceLoad )
      {
         Gx_mode = obj19.gxTpr_Mode;
         A90TrnDirectivaValue = obj19.gxTpr_Trndirectivavalue;
         A91TrnDirectivaDescripcion = obj19.gxTpr_Trndirectivadescripcion;
         A89TrnDirectivaTitle = obj19.gxTpr_Trndirectivatitle;
         Z89TrnDirectivaTitle = obj19.gxTpr_Trndirectivatitle_Z;
         Z90TrnDirectivaValue = obj19.gxTpr_Trndirectivavalue_Z;
         Gx_mode = obj19.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A89TrnDirectivaTitle = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0J19( ) ;
         ScanKeyStart0J19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z89TrnDirectivaTitle = A89TrnDirectivaTitle;
         }
         ZM0J19( -3) ;
         OnLoadActions0J19( ) ;
         AddRow0J19( ) ;
         ScanKeyEnd0J19( ) ;
         if ( RcdFound19 == 0 )
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
         RowToVars19( bcTrnDirectiva, 0) ;
         ScanKeyStart0J19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z89TrnDirectivaTitle = A89TrnDirectivaTitle;
         }
         ZM0J19( -3) ;
         OnLoadActions0J19( ) ;
         AddRow0J19( ) ;
         ScanKeyEnd0J19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0J19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0J19( ) ;
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( StringUtil.StrCmp(A89TrnDirectivaTitle, Z89TrnDirectivaTitle) != 0 )
               {
                  A89TrnDirectivaTitle = Z89TrnDirectivaTitle;
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
                  Update0J19( ) ;
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
                  if ( StringUtil.StrCmp(A89TrnDirectivaTitle, Z89TrnDirectivaTitle) != 0 )
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
                        Insert0J19( ) ;
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
                        Insert0J19( ) ;
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
         RowToVars19( bcTrnDirectiva, 1) ;
         SaveImpl( ) ;
         VarsToRow19( bcTrnDirectiva) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars19( bcTrnDirectiva, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J19( ) ;
         AfterTrn( ) ;
         VarsToRow19( bcTrnDirectiva) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow19( bcTrnDirectiva) ;
         }
         else
         {
            SdtTrnDirectiva auxBC = new SdtTrnDirectiva(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A89TrnDirectivaTitle);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrnDirectiva);
               auxBC.Save();
               bcTrnDirectiva.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars19( bcTrnDirectiva, 1) ;
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
         RowToVars19( bcTrnDirectiva, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J19( ) ;
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
               VarsToRow19( bcTrnDirectiva) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow19( bcTrnDirectiva) ;
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
         RowToVars19( bcTrnDirectiva, 0) ;
         GetKey0J19( ) ;
         if ( RcdFound19 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A89TrnDirectivaTitle, Z89TrnDirectivaTitle) != 0 )
            {
               A89TrnDirectivaTitle = Z89TrnDirectivaTitle;
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
            if ( StringUtil.StrCmp(A89TrnDirectivaTitle, Z89TrnDirectivaTitle) != 0 )
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
         context.RollbackDataStores("trndirectiva_bc",pr_default);
         VarsToRow19( bcTrnDirectiva) ;
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
         Gx_mode = bcTrnDirectiva.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrnDirectiva.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrnDirectiva )
         {
            bcTrnDirectiva = (SdtTrnDirectiva)(sdt);
            if ( StringUtil.StrCmp(bcTrnDirectiva.gxTpr_Mode, "") == 0 )
            {
               bcTrnDirectiva.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow19( bcTrnDirectiva) ;
            }
            else
            {
               RowToVars19( bcTrnDirectiva, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrnDirectiva.gxTpr_Mode, "") == 0 )
            {
               bcTrnDirectiva.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars19( bcTrnDirectiva, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrnDirectiva TrnDirectiva_BC
      {
         get {
            return bcTrnDirectiva ;
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
         Z89TrnDirectivaTitle = "";
         A89TrnDirectivaTitle = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z90TrnDirectivaValue = "";
         A90TrnDirectivaValue = "";
         Z91TrnDirectivaDescripcion = "";
         A91TrnDirectivaDescripcion = "";
         BC000J4_A89TrnDirectivaTitle = new string[] {""} ;
         BC000J4_A90TrnDirectivaValue = new string[] {""} ;
         BC000J4_A91TrnDirectivaDescripcion = new string[] {""} ;
         BC000J5_A89TrnDirectivaTitle = new string[] {""} ;
         BC000J3_A89TrnDirectivaTitle = new string[] {""} ;
         BC000J3_A90TrnDirectivaValue = new string[] {""} ;
         BC000J3_A91TrnDirectivaDescripcion = new string[] {""} ;
         sMode19 = "";
         BC000J2_A89TrnDirectivaTitle = new string[] {""} ;
         BC000J2_A90TrnDirectivaValue = new string[] {""} ;
         BC000J2_A91TrnDirectivaDescripcion = new string[] {""} ;
         BC000J9_A89TrnDirectivaTitle = new string[] {""} ;
         BC000J9_A90TrnDirectivaValue = new string[] {""} ;
         BC000J9_A91TrnDirectivaDescripcion = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trndirectiva_bc__default(),
            new Object[][] {
                new Object[] {
               BC000J2_A89TrnDirectivaTitle, BC000J2_A90TrnDirectivaValue, BC000J2_A91TrnDirectivaDescripcion
               }
               , new Object[] {
               BC000J3_A89TrnDirectivaTitle, BC000J3_A90TrnDirectivaValue, BC000J3_A91TrnDirectivaDescripcion
               }
               , new Object[] {
               BC000J4_A89TrnDirectivaTitle, BC000J4_A90TrnDirectivaValue, BC000J4_A91TrnDirectivaDescripcion
               }
               , new Object[] {
               BC000J5_A89TrnDirectivaTitle
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000J9_A89TrnDirectivaTitle, BC000J9_A90TrnDirectivaValue, BC000J9_A91TrnDirectivaDescripcion
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120J2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound19 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode19 ;
      private bool returnInSub ;
      private string Z91TrnDirectivaDescripcion ;
      private string A91TrnDirectivaDescripcion ;
      private string Z89TrnDirectivaTitle ;
      private string A89TrnDirectivaTitle ;
      private string Z90TrnDirectivaValue ;
      private string A90TrnDirectivaValue ;
      private IGxSession AV11WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] BC000J4_A89TrnDirectivaTitle ;
      private string[] BC000J4_A90TrnDirectivaValue ;
      private string[] BC000J4_A91TrnDirectivaDescripcion ;
      private string[] BC000J5_A89TrnDirectivaTitle ;
      private string[] BC000J3_A89TrnDirectivaTitle ;
      private string[] BC000J3_A90TrnDirectivaValue ;
      private string[] BC000J3_A91TrnDirectivaDescripcion ;
      private string[] BC000J2_A89TrnDirectivaTitle ;
      private string[] BC000J2_A90TrnDirectivaValue ;
      private string[] BC000J2_A91TrnDirectivaDescripcion ;
      private string[] BC000J9_A89TrnDirectivaTitle ;
      private string[] BC000J9_A90TrnDirectivaValue ;
      private string[] BC000J9_A91TrnDirectivaDescripcion ;
      private SdtTrnDirectiva bcTrnDirectiva ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trndirectiva_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000J2;
          prmBC000J2 = new Object[] {
          new ParDef("@TrnDirectivaTitle",GXType.Char,100,0)
          };
          Object[] prmBC000J3;
          prmBC000J3 = new Object[] {
          new ParDef("@TrnDirectivaTitle",GXType.Char,100,0)
          };
          Object[] prmBC000J4;
          prmBC000J4 = new Object[] {
          new ParDef("@TrnDirectivaTitle",GXType.Char,100,0)
          };
          Object[] prmBC000J5;
          prmBC000J5 = new Object[] {
          new ParDef("@TrnDirectivaTitle",GXType.Char,100,0)
          };
          Object[] prmBC000J6;
          prmBC000J6 = new Object[] {
          new ParDef("@TrnDirectivaTitle",GXType.Char,100,0) ,
          new ParDef("@TrnDirectivaValue",GXType.Char,100,0) ,
          new ParDef("@TrnDirectivaDescripcion",GXType.Char,2097152,0)
          };
          Object[] prmBC000J7;
          prmBC000J7 = new Object[] {
          new ParDef("@TrnDirectivaValue",GXType.Char,100,0) ,
          new ParDef("@TrnDirectivaDescripcion",GXType.Char,2097152,0) ,
          new ParDef("@TrnDirectivaTitle",GXType.Char,100,0)
          };
          Object[] prmBC000J8;
          prmBC000J8 = new Object[] {
          new ParDef("@TrnDirectivaTitle",GXType.Char,100,0)
          };
          Object[] prmBC000J9;
          prmBC000J9 = new Object[] {
          new ParDef("@TrnDirectivaTitle",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000J2", "SELECT `TrnDirectivaTitle`, `TrnDirectivaValue`, `TrnDirectivaDescripcion` FROM `TrnDirectiva` WHERE `TrnDirectivaTitle` = @TrnDirectivaTitle  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J3", "SELECT `TrnDirectivaTitle`, `TrnDirectivaValue`, `TrnDirectivaDescripcion` FROM `TrnDirectiva` WHERE `TrnDirectivaTitle` = @TrnDirectivaTitle ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J4", "SELECT TM1.`TrnDirectivaTitle`, TM1.`TrnDirectivaValue`, TM1.`TrnDirectivaDescripcion` FROM `TrnDirectiva` TM1 WHERE TM1.`TrnDirectivaTitle` = @TrnDirectivaTitle ORDER BY TM1.`TrnDirectivaTitle` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J5", "SELECT `TrnDirectivaTitle` FROM `TrnDirectiva` WHERE `TrnDirectivaTitle` = @TrnDirectivaTitle ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J6", "INSERT INTO `TrnDirectiva`(`TrnDirectivaTitle`, `TrnDirectivaValue`, `TrnDirectivaDescripcion`) VALUES(@TrnDirectivaTitle, @TrnDirectivaValue, @TrnDirectivaDescripcion)", GxErrorMask.GX_NOMASK,prmBC000J6)
             ,new CursorDef("BC000J7", "UPDATE `TrnDirectiva` SET `TrnDirectivaValue`=@TrnDirectivaValue, `TrnDirectivaDescripcion`=@TrnDirectivaDescripcion  WHERE `TrnDirectivaTitle` = @TrnDirectivaTitle", GxErrorMask.GX_NOMASK,prmBC000J7)
             ,new CursorDef("BC000J8", "DELETE FROM `TrnDirectiva`  WHERE `TrnDirectivaTitle` = @TrnDirectivaTitle", GxErrorMask.GX_NOMASK,prmBC000J8)
             ,new CursorDef("BC000J9", "SELECT TM1.`TrnDirectivaTitle`, TM1.`TrnDirectivaValue`, TM1.`TrnDirectivaDescripcion` FROM `TrnDirectiva` TM1 WHERE TM1.`TrnDirectivaTitle` = @TrnDirectivaTitle ORDER BY TM1.`TrnDirectivaTitle` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J9,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
       }
    }

 }

}
