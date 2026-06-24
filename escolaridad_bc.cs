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
   public class escolaridad_bc : GxSilentTrn, IGxSilentTrn
   {
      public escolaridad_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public escolaridad_bc( IGxContext context )
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
         ReadRow033( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey033( ) ;
         standaloneModal( ) ;
         AddRow033( ) ;
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
               Z7EscolaridadID = A7EscolaridadID;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z8EscolaridadDescripcion = A8EscolaridadDescripcion;
            Z9EscolaridadActivo = A9EscolaridadActivo;
         }
         if ( GX_JID == -1 )
         {
            Z7EscolaridadID = A7EscolaridadID;
            Z8EscolaridadDescripcion = A8EscolaridadDescripcion;
            Z9EscolaridadActivo = A9EscolaridadActivo;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load033( )
      {
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A7EscolaridadID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1;
            A8EscolaridadDescripcion = BC00034_A8EscolaridadDescripcion[0];
            A9EscolaridadActivo = BC00034_A9EscolaridadActivo[0];
            ZM033( -1) ;
         }
         pr_default.close(2);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
      }

      protected void CheckExtendedTable033( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A7EscolaridadID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A7EscolaridadID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 1) ;
            RcdFound3 = 1;
            A7EscolaridadID = BC00033_A7EscolaridadID[0];
            A8EscolaridadDescripcion = BC00033_A8EscolaridadDescripcion[0];
            A9EscolaridadActivo = BC00033_A9EscolaridadActivo[0];
            Z7EscolaridadID = A7EscolaridadID;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         CONFIRM_030( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A7EscolaridadID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Escolaridad"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z8EscolaridadDescripcion, BC00032_A8EscolaridadDescripcion[0]) != 0 ) || ( Z9EscolaridadActivo != BC00032_A9EscolaridadActivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Escolaridad"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00036 */
                     pr_default.execute(4, new Object[] {A8EscolaridadDescripcion, A9EscolaridadActivo});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00037 */
                     pr_default.execute(5);
                     A7EscolaridadID = BC00037_A7EscolaridadID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Escolaridad");
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00038 */
                     pr_default.execute(6, new Object[] {A8EscolaridadDescripcion, A9EscolaridadActivo, A7EscolaridadID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Escolaridad");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Escolaridad"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00039 */
                  pr_default.execute(7, new Object[] {A7EscolaridadID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Escolaridad");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel033( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
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

      public void ScanKeyStart033( )
      {
         /* Using cursor BC000310 */
         pr_default.execute(8, new Object[] {A7EscolaridadID});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound3 = 1;
            A7EscolaridadID = BC000310_A7EscolaridadID[0];
            A8EscolaridadDescripcion = BC000310_A8EscolaridadDescripcion[0];
            A9EscolaridadActivo = BC000310_A9EscolaridadActivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound3 = 0;
         ScanKeyLoad033( ) ;
      }

      protected void ScanKeyLoad033( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound3 = 1;
            A7EscolaridadID = BC000310_A7EscolaridadID[0];
            A8EscolaridadDescripcion = BC000310_A8EscolaridadDescripcion[0];
            A9EscolaridadActivo = BC000310_A9EscolaridadActivo[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd033( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void AddRow033( )
      {
         VarsToRow3( bcEscolaridad) ;
      }

      protected void ReadRow033( )
      {
         RowToVars3( bcEscolaridad, 1) ;
      }

      protected void InitializeNonKey033( )
      {
         A8EscolaridadDescripcion = "";
         A9EscolaridadActivo = false;
         Z8EscolaridadDescripcion = "";
         Z9EscolaridadActivo = false;
      }

      protected void InitAll033( )
      {
         A7EscolaridadID = 0;
         InitializeNonKey033( ) ;
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

      public void VarsToRow3( SdtEscolaridad obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Escolaridaddescripcion = A8EscolaridadDescripcion;
         obj3.gxTpr_Escolaridadactivo = A9EscolaridadActivo;
         obj3.gxTpr_Escolaridadid = A7EscolaridadID;
         obj3.gxTpr_Escolaridadid_Z = Z7EscolaridadID;
         obj3.gxTpr_Escolaridaddescripcion_Z = Z8EscolaridadDescripcion;
         obj3.gxTpr_Escolaridadactivo_Z = Z9EscolaridadActivo;
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( SdtEscolaridad obj3 )
      {
         obj3.gxTpr_Escolaridadid = A7EscolaridadID;
         return  ;
      }

      public void RowToVars3( SdtEscolaridad obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A8EscolaridadDescripcion = obj3.gxTpr_Escolaridaddescripcion;
         A9EscolaridadActivo = obj3.gxTpr_Escolaridadactivo;
         A7EscolaridadID = obj3.gxTpr_Escolaridadid;
         Z7EscolaridadID = obj3.gxTpr_Escolaridadid_Z;
         Z8EscolaridadDescripcion = obj3.gxTpr_Escolaridaddescripcion_Z;
         Z9EscolaridadActivo = obj3.gxTpr_Escolaridadactivo_Z;
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A7EscolaridadID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey033( ) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7EscolaridadID = A7EscolaridadID;
         }
         ZM033( -1) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
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
         RowToVars3( bcEscolaridad, 0) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7EscolaridadID = A7EscolaridadID;
         }
         ZM033( -1) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert033( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A7EscolaridadID != Z7EscolaridadID )
               {
                  A7EscolaridadID = Z7EscolaridadID;
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
                  Update033( ) ;
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
                  if ( A7EscolaridadID != Z7EscolaridadID )
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
                        Insert033( ) ;
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
                        Insert033( ) ;
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
         RowToVars3( bcEscolaridad, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bcEscolaridad) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcEscolaridad, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
         AfterTrn( ) ;
         VarsToRow3( bcEscolaridad) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow3( bcEscolaridad) ;
         }
         else
         {
            SdtEscolaridad auxBC = new SdtEscolaridad(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A7EscolaridadID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEscolaridad);
               auxBC.Save();
               bcEscolaridad.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars3( bcEscolaridad, 1) ;
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
         RowToVars3( bcEscolaridad, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
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
               VarsToRow3( bcEscolaridad) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow3( bcEscolaridad) ;
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
         RowToVars3( bcEscolaridad, 0) ;
         GetKey033( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A7EscolaridadID != Z7EscolaridadID )
            {
               A7EscolaridadID = Z7EscolaridadID;
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
            if ( A7EscolaridadID != Z7EscolaridadID )
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
         context.RollbackDataStores("escolaridad_bc",pr_default);
         VarsToRow3( bcEscolaridad) ;
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
         Gx_mode = bcEscolaridad.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEscolaridad.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEscolaridad )
         {
            bcEscolaridad = (SdtEscolaridad)(sdt);
            if ( StringUtil.StrCmp(bcEscolaridad.gxTpr_Mode, "") == 0 )
            {
               bcEscolaridad.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bcEscolaridad) ;
            }
            else
            {
               RowToVars3( bcEscolaridad, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEscolaridad.gxTpr_Mode, "") == 0 )
            {
               bcEscolaridad.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bcEscolaridad, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtEscolaridad Escolaridad_BC
      {
         get {
            return bcEscolaridad ;
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
         Z8EscolaridadDescripcion = "";
         A8EscolaridadDescripcion = "";
         BC00034_A7EscolaridadID = new int[1] ;
         BC00034_A8EscolaridadDescripcion = new string[] {""} ;
         BC00034_A9EscolaridadActivo = new bool[] {false} ;
         BC00035_A7EscolaridadID = new int[1] ;
         BC00033_A7EscolaridadID = new int[1] ;
         BC00033_A8EscolaridadDescripcion = new string[] {""} ;
         BC00033_A9EscolaridadActivo = new bool[] {false} ;
         sMode3 = "";
         BC00032_A7EscolaridadID = new int[1] ;
         BC00032_A8EscolaridadDescripcion = new string[] {""} ;
         BC00032_A9EscolaridadActivo = new bool[] {false} ;
         BC00037_A7EscolaridadID = new int[1] ;
         BC000310_A7EscolaridadID = new int[1] ;
         BC000310_A8EscolaridadDescripcion = new string[] {""} ;
         BC000310_A9EscolaridadActivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.escolaridad_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A7EscolaridadID, BC00032_A8EscolaridadDescripcion, BC00032_A9EscolaridadActivo
               }
               , new Object[] {
               BC00033_A7EscolaridadID, BC00033_A8EscolaridadDescripcion, BC00033_A9EscolaridadActivo
               }
               , new Object[] {
               BC00034_A7EscolaridadID, BC00034_A8EscolaridadDescripcion, BC00034_A9EscolaridadActivo
               }
               , new Object[] {
               BC00035_A7EscolaridadID
               }
               , new Object[] {
               }
               , new Object[] {
               BC00037_A7EscolaridadID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000310_A7EscolaridadID, BC000310_A8EscolaridadDescripcion, BC000310_A9EscolaridadActivo
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound3 ;
      private int trnEnded ;
      private int Z7EscolaridadID ;
      private int A7EscolaridadID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode3 ;
      private bool Z9EscolaridadActivo ;
      private bool A9EscolaridadActivo ;
      private string Z8EscolaridadDescripcion ;
      private string A8EscolaridadDescripcion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00034_A7EscolaridadID ;
      private string[] BC00034_A8EscolaridadDescripcion ;
      private bool[] BC00034_A9EscolaridadActivo ;
      private int[] BC00035_A7EscolaridadID ;
      private int[] BC00033_A7EscolaridadID ;
      private string[] BC00033_A8EscolaridadDescripcion ;
      private bool[] BC00033_A9EscolaridadActivo ;
      private int[] BC00032_A7EscolaridadID ;
      private string[] BC00032_A8EscolaridadDescripcion ;
      private bool[] BC00032_A9EscolaridadActivo ;
      private int[] BC00037_A7EscolaridadID ;
      private int[] BC000310_A7EscolaridadID ;
      private string[] BC000310_A8EscolaridadDescripcion ;
      private bool[] BC000310_A9EscolaridadActivo ;
      private SdtEscolaridad bcEscolaridad ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class escolaridad_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00032;
          prmBC00032 = new Object[] {
          new ParDef("@EscolaridadID",GXType.Int32,9,0)
          };
          Object[] prmBC00033;
          prmBC00033 = new Object[] {
          new ParDef("@EscolaridadID",GXType.Int32,9,0)
          };
          Object[] prmBC00034;
          prmBC00034 = new Object[] {
          new ParDef("@EscolaridadID",GXType.Int32,9,0)
          };
          Object[] prmBC00035;
          prmBC00035 = new Object[] {
          new ParDef("@EscolaridadID",GXType.Int32,9,0)
          };
          Object[] prmBC00036;
          prmBC00036 = new Object[] {
          new ParDef("@EscolaridadDescripcion",GXType.Char,80,0) ,
          new ParDef("@EscolaridadActivo",GXType.Byte,4,0)
          };
          Object[] prmBC00037;
          prmBC00037 = new Object[] {
          };
          Object[] prmBC00038;
          prmBC00038 = new Object[] {
          new ParDef("@EscolaridadDescripcion",GXType.Char,80,0) ,
          new ParDef("@EscolaridadActivo",GXType.Byte,4,0) ,
          new ParDef("@EscolaridadID",GXType.Int32,9,0)
          };
          Object[] prmBC00039;
          prmBC00039 = new Object[] {
          new ParDef("@EscolaridadID",GXType.Int32,9,0)
          };
          Object[] prmBC000310;
          prmBC000310 = new Object[] {
          new ParDef("@EscolaridadID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00032", "SELECT `EscolaridadID`, `EscolaridadDescripcion`, `EscolaridadActivo` FROM `Escolaridad` WHERE `EscolaridadID` = @EscolaridadID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00033", "SELECT `EscolaridadID`, `EscolaridadDescripcion`, `EscolaridadActivo` FROM `Escolaridad` WHERE `EscolaridadID` = @EscolaridadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00034", "SELECT TM1.`EscolaridadID`, TM1.`EscolaridadDescripcion`, TM1.`EscolaridadActivo` FROM `Escolaridad` TM1 WHERE TM1.`EscolaridadID` = @EscolaridadID ORDER BY TM1.`EscolaridadID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00035", "SELECT `EscolaridadID` FROM `Escolaridad` WHERE `EscolaridadID` = @EscolaridadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00036", "INSERT INTO `Escolaridad`(`EscolaridadDescripcion`, `EscolaridadActivo`) VALUES(@EscolaridadDescripcion, @EscolaridadActivo)", GxErrorMask.GX_NOMASK,prmBC00036)
             ,new CursorDef("BC00037", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00038", "UPDATE `Escolaridad` SET `EscolaridadDescripcion`=@EscolaridadDescripcion, `EscolaridadActivo`=@EscolaridadActivo  WHERE `EscolaridadID` = @EscolaridadID", GxErrorMask.GX_NOMASK,prmBC00038)
             ,new CursorDef("BC00039", "DELETE FROM `Escolaridad`  WHERE `EscolaridadID` = @EscolaridadID", GxErrorMask.GX_NOMASK,prmBC00039)
             ,new CursorDef("BC000310", "SELECT TM1.`EscolaridadID`, TM1.`EscolaridadDescripcion`, TM1.`EscolaridadActivo` FROM `Escolaridad` TM1 WHERE TM1.`EscolaridadID` = @EscolaridadID ORDER BY TM1.`EscolaridadID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000310,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
    }

 }

}
