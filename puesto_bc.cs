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
   public class puesto_bc : GxSilentTrn, IGxSilentTrn
   {
      public puesto_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public puesto_bc( IGxContext context )
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
         ReadRow055( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey055( ) ;
         standaloneModal( ) ;
         AddRow055( ) ;
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
               Z13PuestoID = A13PuestoID;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z15PuestoActivo = A15PuestoActivo;
         }
         if ( GX_JID == -1 )
         {
            Z13PuestoID = A13PuestoID;
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z15PuestoActivo = A15PuestoActivo;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load055( )
      {
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound5 = 1;
            A14PuestoDescripcion = BC00054_A14PuestoDescripcion[0];
            A15PuestoActivo = BC00054_A15PuestoActivo[0];
            ZM055( -1) ;
         }
         pr_default.close(2);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
      }

      protected void CheckExtendedTable055( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors055( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey055( )
      {
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 1) ;
            RcdFound5 = 1;
            A13PuestoID = BC00053_A13PuestoID[0];
            n13PuestoID = BC00053_n13PuestoID[0];
            A14PuestoDescripcion = BC00053_A14PuestoDescripcion[0];
            A15PuestoActivo = BC00053_A15PuestoActivo[0];
            Z13PuestoID = A13PuestoID;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
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
         CONFIRM_050( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {n13PuestoID, A13PuestoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Puesto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z14PuestoDescripcion, BC00052_A14PuestoDescripcion[0]) != 0 ) || ( Z15PuestoActivo != BC00052_A15PuestoActivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Puesto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00056 */
                     pr_default.execute(4, new Object[] {A14PuestoDescripcion, A15PuestoActivo});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00057 */
                     pr_default.execute(5);
                     A13PuestoID = BC00057_A13PuestoID[0];
                     n13PuestoID = BC00057_n13PuestoID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Puesto");
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00058 */
                     pr_default.execute(6, new Object[] {A14PuestoDescripcion, A15PuestoActivo, n13PuestoID, A13PuestoID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Puesto");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Puesto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00059 */
                  pr_default.execute(7, new Object[] {n13PuestoID, A13PuestoID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Puesto");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel055( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000510 */
            pr_default.execute(8, new Object[] {n13PuestoID, A13PuestoID});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Usuario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
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

      public void ScanKeyStart055( )
      {
         /* Using cursor BC000511 */
         pr_default.execute(9, new Object[] {n13PuestoID, A13PuestoID});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound5 = 1;
            A13PuestoID = BC000511_A13PuestoID[0];
            n13PuestoID = BC000511_n13PuestoID[0];
            A14PuestoDescripcion = BC000511_A14PuestoDescripcion[0];
            A15PuestoActivo = BC000511_A15PuestoActivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound5 = 0;
         ScanKeyLoad055( ) ;
      }

      protected void ScanKeyLoad055( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound5 = 1;
            A13PuestoID = BC000511_A13PuestoID[0];
            n13PuestoID = BC000511_n13PuestoID[0];
            A14PuestoDescripcion = BC000511_A14PuestoDescripcion[0];
            A15PuestoActivo = BC000511_A15PuestoActivo[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd055( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void AddRow055( )
      {
         VarsToRow5( bcPuesto) ;
      }

      protected void ReadRow055( )
      {
         RowToVars5( bcPuesto, 1) ;
      }

      protected void InitializeNonKey055( )
      {
         A14PuestoDescripcion = "";
         A15PuestoActivo = false;
         Z14PuestoDescripcion = "";
         Z15PuestoActivo = false;
      }

      protected void InitAll055( )
      {
         A13PuestoID = 0;
         n13PuestoID = false;
         InitializeNonKey055( ) ;
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

      public void VarsToRow5( SdtPuesto obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Puestodescripcion = A14PuestoDescripcion;
         obj5.gxTpr_Puestoactivo = A15PuestoActivo;
         obj5.gxTpr_Puestoid = A13PuestoID;
         obj5.gxTpr_Puestoid_Z = Z13PuestoID;
         obj5.gxTpr_Puestodescripcion_Z = Z14PuestoDescripcion;
         obj5.gxTpr_Puestoactivo_Z = Z15PuestoActivo;
         obj5.gxTpr_Puestoid_N = (short)(Convert.ToInt16(n13PuestoID));
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( SdtPuesto obj5 )
      {
         obj5.gxTpr_Puestoid = A13PuestoID;
         return  ;
      }

      public void RowToVars5( SdtPuesto obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A14PuestoDescripcion = obj5.gxTpr_Puestodescripcion;
         A15PuestoActivo = obj5.gxTpr_Puestoactivo;
         A13PuestoID = obj5.gxTpr_Puestoid;
         n13PuestoID = false;
         Z13PuestoID = obj5.gxTpr_Puestoid_Z;
         Z14PuestoDescripcion = obj5.gxTpr_Puestodescripcion_Z;
         Z15PuestoActivo = obj5.gxTpr_Puestoactivo_Z;
         n13PuestoID = (bool)(Convert.ToBoolean(obj5.gxTpr_Puestoid_N));
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A13PuestoID = (int)getParm(obj,0);
         n13PuestoID = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey055( ) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z13PuestoID = A13PuestoID;
         }
         ZM055( -1) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
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
         RowToVars5( bcPuesto, 0) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z13PuestoID = A13PuestoID;
         }
         ZM055( -1) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert055( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A13PuestoID != Z13PuestoID )
               {
                  A13PuestoID = Z13PuestoID;
                  n13PuestoID = false;
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
                  Update055( ) ;
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
                  if ( A13PuestoID != Z13PuestoID )
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
                        Insert055( ) ;
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
                        Insert055( ) ;
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
         RowToVars5( bcPuesto, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bcPuesto) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bcPuesto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
         AfterTrn( ) ;
         VarsToRow5( bcPuesto) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow5( bcPuesto) ;
         }
         else
         {
            SdtPuesto auxBC = new SdtPuesto(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A13PuestoID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPuesto);
               auxBC.Save();
               bcPuesto.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars5( bcPuesto, 1) ;
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
         RowToVars5( bcPuesto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
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
               VarsToRow5( bcPuesto) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow5( bcPuesto) ;
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
         RowToVars5( bcPuesto, 0) ;
         GetKey055( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A13PuestoID != Z13PuestoID )
            {
               A13PuestoID = Z13PuestoID;
               n13PuestoID = false;
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
            if ( A13PuestoID != Z13PuestoID )
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
         context.RollbackDataStores("puesto_bc",pr_default);
         VarsToRow5( bcPuesto) ;
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
         Gx_mode = bcPuesto.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPuesto.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPuesto )
         {
            bcPuesto = (SdtPuesto)(sdt);
            if ( StringUtil.StrCmp(bcPuesto.gxTpr_Mode, "") == 0 )
            {
               bcPuesto.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bcPuesto) ;
            }
            else
            {
               RowToVars5( bcPuesto, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPuesto.gxTpr_Mode, "") == 0 )
            {
               bcPuesto.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bcPuesto, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPuesto Puesto_BC
      {
         get {
            return bcPuesto ;
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
         Z14PuestoDescripcion = "";
         A14PuestoDescripcion = "";
         BC00054_A13PuestoID = new int[1] ;
         BC00054_n13PuestoID = new bool[] {false} ;
         BC00054_A14PuestoDescripcion = new string[] {""} ;
         BC00054_A15PuestoActivo = new bool[] {false} ;
         BC00055_A13PuestoID = new int[1] ;
         BC00055_n13PuestoID = new bool[] {false} ;
         BC00053_A13PuestoID = new int[1] ;
         BC00053_n13PuestoID = new bool[] {false} ;
         BC00053_A14PuestoDescripcion = new string[] {""} ;
         BC00053_A15PuestoActivo = new bool[] {false} ;
         sMode5 = "";
         BC00052_A13PuestoID = new int[1] ;
         BC00052_n13PuestoID = new bool[] {false} ;
         BC00052_A14PuestoDescripcion = new string[] {""} ;
         BC00052_A15PuestoActivo = new bool[] {false} ;
         BC00057_A13PuestoID = new int[1] ;
         BC00057_n13PuestoID = new bool[] {false} ;
         BC000510_A29UsuarioID = new int[1] ;
         BC000511_A13PuestoID = new int[1] ;
         BC000511_n13PuestoID = new bool[] {false} ;
         BC000511_A14PuestoDescripcion = new string[] {""} ;
         BC000511_A15PuestoActivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.puesto_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A13PuestoID, BC00052_A14PuestoDescripcion, BC00052_A15PuestoActivo
               }
               , new Object[] {
               BC00053_A13PuestoID, BC00053_A14PuestoDescripcion, BC00053_A15PuestoActivo
               }
               , new Object[] {
               BC00054_A13PuestoID, BC00054_A14PuestoDescripcion, BC00054_A15PuestoActivo
               }
               , new Object[] {
               BC00055_A13PuestoID
               }
               , new Object[] {
               }
               , new Object[] {
               BC00057_A13PuestoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000510_A29UsuarioID
               }
               , new Object[] {
               BC000511_A13PuestoID, BC000511_A14PuestoDescripcion, BC000511_A15PuestoActivo
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound5 ;
      private int trnEnded ;
      private int Z13PuestoID ;
      private int A13PuestoID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode5 ;
      private bool Z15PuestoActivo ;
      private bool A15PuestoActivo ;
      private bool n13PuestoID ;
      private string Z14PuestoDescripcion ;
      private string A14PuestoDescripcion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00054_A13PuestoID ;
      private bool[] BC00054_n13PuestoID ;
      private string[] BC00054_A14PuestoDescripcion ;
      private bool[] BC00054_A15PuestoActivo ;
      private int[] BC00055_A13PuestoID ;
      private bool[] BC00055_n13PuestoID ;
      private int[] BC00053_A13PuestoID ;
      private bool[] BC00053_n13PuestoID ;
      private string[] BC00053_A14PuestoDescripcion ;
      private bool[] BC00053_A15PuestoActivo ;
      private int[] BC00052_A13PuestoID ;
      private bool[] BC00052_n13PuestoID ;
      private string[] BC00052_A14PuestoDescripcion ;
      private bool[] BC00052_A15PuestoActivo ;
      private int[] BC00057_A13PuestoID ;
      private bool[] BC00057_n13PuestoID ;
      private int[] BC000510_A29UsuarioID ;
      private int[] BC000511_A13PuestoID ;
      private bool[] BC000511_n13PuestoID ;
      private string[] BC000511_A14PuestoDescripcion ;
      private bool[] BC000511_A15PuestoActivo ;
      private SdtPuesto bcPuesto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class puesto_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00052;
          prmBC00052 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00053;
          prmBC00053 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00054;
          prmBC00054 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00055;
          prmBC00055 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00056;
          prmBC00056 = new Object[] {
          new ParDef("@PuestoDescripcion",GXType.Char,80,0) ,
          new ParDef("@PuestoActivo",GXType.Byte,4,0)
          };
          Object[] prmBC00057;
          prmBC00057 = new Object[] {
          };
          Object[] prmBC00058;
          prmBC00058 = new Object[] {
          new ParDef("@PuestoDescripcion",GXType.Char,80,0) ,
          new ParDef("@PuestoActivo",GXType.Byte,4,0) ,
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00059;
          prmBC00059 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000510;
          prmBC000510 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000511;
          prmBC000511 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC00052", "SELECT `PuestoID`, `PuestoDescripcion`, `PuestoActivo` FROM `Puesto` WHERE `PuestoID` = @PuestoID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00053", "SELECT `PuestoID`, `PuestoDescripcion`, `PuestoActivo` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00054", "SELECT TM1.`PuestoID`, TM1.`PuestoDescripcion`, TM1.`PuestoActivo` FROM `Puesto` TM1 WHERE TM1.`PuestoID` = @PuestoID ORDER BY TM1.`PuestoID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00055", "SELECT `PuestoID` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00056", "INSERT INTO `Puesto`(`PuestoDescripcion`, `PuestoActivo`) VALUES(@PuestoDescripcion, @PuestoActivo)", GxErrorMask.GX_NOMASK,prmBC00056)
             ,new CursorDef("BC00057", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00058", "UPDATE `Puesto` SET `PuestoDescripcion`=@PuestoDescripcion, `PuestoActivo`=@PuestoActivo  WHERE `PuestoID` = @PuestoID", GxErrorMask.GX_NOMASK,prmBC00058)
             ,new CursorDef("BC00059", "DELETE FROM `Puesto`  WHERE `PuestoID` = @PuestoID", GxErrorMask.GX_NOMASK,prmBC00059)
             ,new CursorDef("BC000510", "SELECT `UsuarioID` FROM `Usuario` WHERE `PuestoID` = @PuestoID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000510,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000511", "SELECT TM1.`PuestoID`, TM1.`PuestoDescripcion`, TM1.`PuestoActivo` FROM `Puesto` TM1 WHERE TM1.`PuestoID` = @PuestoID ORDER BY TM1.`PuestoID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000511,100, GxCacheFrequency.OFF ,true,false )
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
