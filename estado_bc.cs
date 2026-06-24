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
   public class estado_bc : GxSilentTrn, IGxSilentTrn
   {
      public estado_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estado_bc( IGxContext context )
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
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
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
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1EstadoID = A1EstadoID;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
                  ZM011( 4) ;
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            while ( AV20GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "PaisID") == 0 )
               {
                  AV11Insert_PaisID = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV20GXV1 = (int)(AV20GXV1+1);
            }
         }
      }

      protected void E11012( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z3EstadoActivo = A3EstadoActivo;
            Z16PaisID = A16PaisID;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z17PaisDescripcion = A17PaisDescripcion;
         }
         if ( GX_JID == -3 )
         {
            Z1EstadoID = A1EstadoID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z3EstadoActivo = A3EstadoActivo;
            Z16PaisID = A16PaisID;
            Z17PaisDescripcion = A17PaisDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
         AV19Pgmname = "Estado_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
            A17PaisDescripcion = BC00015_A17PaisDescripcion[0];
            A2EstadoDescripcion = BC00015_A2EstadoDescripcion[0];
            A3EstadoActivo = BC00015_A3EstadoActivo[0];
            A16PaisID = BC00015_A16PaisID[0];
            ZM011( -3) ;
         }
         pr_default.close(3);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A17PaisDescripcion = BC00014_A17PaisDescripcion[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00016 */
         pr_default.execute(4, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 3) ;
            RcdFound1 = 1;
            A1EstadoID = BC00013_A1EstadoID[0];
            A2EstadoDescripcion = BC00013_A2EstadoDescripcion[0];
            A3EstadoActivo = BC00013_A3EstadoActivo[0];
            A16PaisID = BC00013_A16PaisID[0];
            Z1EstadoID = A1EstadoID;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         CONFIRM_010( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1EstadoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Estado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2EstadoDescripcion, BC00012_A2EstadoDescripcion[0]) != 0 ) || ( Z3EstadoActivo != BC00012_A3EstadoActivo[0] ) || ( Z16PaisID != BC00012_A16PaisID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Estado"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {A2EstadoDescripcion, A3EstadoActivo, A16PaisID});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00018 */
                     pr_default.execute(6);
                     A1EstadoID = BC00018_A1EstadoID[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Estado");
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00019 */
                     pr_default.execute(7, new Object[] {A2EstadoDescripcion, A3EstadoActivo, A16PaisID, A1EstadoID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Estado");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Estado"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000110 */
                  pr_default.execute(8, new Object[] {A1EstadoID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Estado");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000111 */
            pr_default.execute(9, new Object[] {A16PaisID});
            A17PaisDescripcion = BC000111_A17PaisDescripcion[0];
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000112 */
            pr_default.execute(10, new Object[] {A1EstadoID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Ciudad", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
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

      public void ScanKeyStart011( )
      {
         /* Scan By routine */
         /* Using cursor BC000113 */
         pr_default.execute(11, new Object[] {A1EstadoID});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound1 = 1;
            A1EstadoID = BC000113_A1EstadoID[0];
            A17PaisDescripcion = BC000113_A17PaisDescripcion[0];
            A2EstadoDescripcion = BC000113_A2EstadoDescripcion[0];
            A3EstadoActivo = BC000113_A3EstadoActivo[0];
            A16PaisID = BC000113_A16PaisID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound1 = 1;
            A1EstadoID = BC000113_A1EstadoID[0];
            A17PaisDescripcion = BC000113_A17PaisDescripcion[0];
            A2EstadoDescripcion = BC000113_A2EstadoDescripcion[0];
            A3EstadoActivo = BC000113_A3EstadoActivo[0];
            A16PaisID = BC000113_A16PaisID[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcEstado) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcEstado, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A16PaisID = 0;
         A17PaisDescripcion = "";
         A2EstadoDescripcion = "";
         A3EstadoActivo = false;
         Z2EstadoDescripcion = "";
         Z3EstadoActivo = false;
         Z16PaisID = 0;
      }

      protected void InitAll011( )
      {
         A1EstadoID = 0;
         InitializeNonKey011( ) ;
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

      public void VarsToRow1( SdtEstado obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Paisid = A16PaisID;
         obj1.gxTpr_Paisdescripcion = A17PaisDescripcion;
         obj1.gxTpr_Estadodescripcion = A2EstadoDescripcion;
         obj1.gxTpr_Estadoactivo = A3EstadoActivo;
         obj1.gxTpr_Estadoid = A1EstadoID;
         obj1.gxTpr_Estadoid_Z = Z1EstadoID;
         obj1.gxTpr_Paisid_Z = Z16PaisID;
         obj1.gxTpr_Paisdescripcion_Z = Z17PaisDescripcion;
         obj1.gxTpr_Estadodescripcion_Z = Z2EstadoDescripcion;
         obj1.gxTpr_Estadoactivo_Z = Z3EstadoActivo;
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdtEstado obj1 )
      {
         obj1.gxTpr_Estadoid = A1EstadoID;
         return  ;
      }

      public void RowToVars1( SdtEstado obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A16PaisID = obj1.gxTpr_Paisid;
         A17PaisDescripcion = obj1.gxTpr_Paisdescripcion;
         A2EstadoDescripcion = obj1.gxTpr_Estadodescripcion;
         A3EstadoActivo = obj1.gxTpr_Estadoactivo;
         A1EstadoID = obj1.gxTpr_Estadoid;
         Z1EstadoID = obj1.gxTpr_Estadoid_Z;
         Z16PaisID = obj1.gxTpr_Paisid_Z;
         Z17PaisDescripcion = obj1.gxTpr_Paisdescripcion_Z;
         Z2EstadoDescripcion = obj1.gxTpr_Estadodescripcion_Z;
         Z3EstadoActivo = obj1.gxTpr_Estadoactivo_Z;
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1EstadoID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1EstadoID = A1EstadoID;
         }
         ZM011( -3) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
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
         RowToVars1( bcEstado, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1EstadoID = A1EstadoID;
         }
         ZM011( -3) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1EstadoID != Z1EstadoID )
               {
                  A1EstadoID = Z1EstadoID;
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
                  Update011( ) ;
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
                  if ( A1EstadoID != Z1EstadoID )
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
                        Insert011( ) ;
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
                        Insert011( ) ;
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
         RowToVars1( bcEstado, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcEstado) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcEstado, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcEstado) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow1( bcEstado) ;
         }
         else
         {
            SdtEstado auxBC = new SdtEstado(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1EstadoID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEstado);
               auxBC.Save();
               bcEstado.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars1( bcEstado, 1) ;
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
         RowToVars1( bcEstado, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
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
               VarsToRow1( bcEstado) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow1( bcEstado) ;
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
         RowToVars1( bcEstado, 0) ;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1EstadoID != Z1EstadoID )
            {
               A1EstadoID = Z1EstadoID;
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
            if ( A1EstadoID != Z1EstadoID )
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
         context.RollbackDataStores("estado_bc",pr_default);
         VarsToRow1( bcEstado) ;
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
         Gx_mode = bcEstado.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEstado.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEstado )
         {
            bcEstado = (SdtEstado)(sdt);
            if ( StringUtil.StrCmp(bcEstado.gxTpr_Mode, "") == 0 )
            {
               bcEstado.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcEstado) ;
            }
            else
            {
               RowToVars1( bcEstado, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEstado.gxTpr_Mode, "") == 0 )
            {
               bcEstado.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcEstado, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtEstado Estado_BC
      {
         get {
            return bcEstado ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV19Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z2EstadoDescripcion = "";
         A2EstadoDescripcion = "";
         Z17PaisDescripcion = "";
         A17PaisDescripcion = "";
         BC00015_A1EstadoID = new int[1] ;
         BC00015_A17PaisDescripcion = new string[] {""} ;
         BC00015_A2EstadoDescripcion = new string[] {""} ;
         BC00015_A3EstadoActivo = new bool[] {false} ;
         BC00015_A16PaisID = new int[1] ;
         BC00014_A17PaisDescripcion = new string[] {""} ;
         BC00016_A1EstadoID = new int[1] ;
         BC00013_A1EstadoID = new int[1] ;
         BC00013_A2EstadoDescripcion = new string[] {""} ;
         BC00013_A3EstadoActivo = new bool[] {false} ;
         BC00013_A16PaisID = new int[1] ;
         sMode1 = "";
         BC00012_A1EstadoID = new int[1] ;
         BC00012_A2EstadoDescripcion = new string[] {""} ;
         BC00012_A3EstadoActivo = new bool[] {false} ;
         BC00012_A16PaisID = new int[1] ;
         BC00018_A1EstadoID = new int[1] ;
         BC000111_A17PaisDescripcion = new string[] {""} ;
         BC000112_A4CiudadID = new int[1] ;
         BC000113_A1EstadoID = new int[1] ;
         BC000113_A17PaisDescripcion = new string[] {""} ;
         BC000113_A2EstadoDescripcion = new string[] {""} ;
         BC000113_A3EstadoActivo = new bool[] {false} ;
         BC000113_A16PaisID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estado_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1EstadoID, BC00012_A2EstadoDescripcion, BC00012_A3EstadoActivo, BC00012_A16PaisID
               }
               , new Object[] {
               BC00013_A1EstadoID, BC00013_A2EstadoDescripcion, BC00013_A3EstadoActivo, BC00013_A16PaisID
               }
               , new Object[] {
               BC00014_A17PaisDescripcion
               }
               , new Object[] {
               BC00015_A1EstadoID, BC00015_A17PaisDescripcion, BC00015_A2EstadoDescripcion, BC00015_A3EstadoActivo, BC00015_A16PaisID
               }
               , new Object[] {
               BC00016_A1EstadoID
               }
               , new Object[] {
               }
               , new Object[] {
               BC00018_A1EstadoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000111_A17PaisDescripcion
               }
               , new Object[] {
               BC000112_A4CiudadID
               }
               , new Object[] {
               BC000113_A1EstadoID, BC000113_A17PaisDescripcion, BC000113_A2EstadoDescripcion, BC000113_A3EstadoActivo, BC000113_A16PaisID
               }
            }
         );
         AV19Pgmname = "Estado_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound1 ;
      private int trnEnded ;
      private int Z1EstadoID ;
      private int A1EstadoID ;
      private int AV20GXV1 ;
      private int AV11Insert_PaisID ;
      private int Z16PaisID ;
      private int A16PaisID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19Pgmname ;
      private string sMode1 ;
      private bool returnInSub ;
      private bool Z3EstadoActivo ;
      private bool A3EstadoActivo ;
      private string Z2EstadoDescripcion ;
      private string A2EstadoDescripcion ;
      private string Z17PaisDescripcion ;
      private string A17PaisDescripcion ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC00015_A1EstadoID ;
      private string[] BC00015_A17PaisDescripcion ;
      private string[] BC00015_A2EstadoDescripcion ;
      private bool[] BC00015_A3EstadoActivo ;
      private int[] BC00015_A16PaisID ;
      private string[] BC00014_A17PaisDescripcion ;
      private int[] BC00016_A1EstadoID ;
      private int[] BC00013_A1EstadoID ;
      private string[] BC00013_A2EstadoDescripcion ;
      private bool[] BC00013_A3EstadoActivo ;
      private int[] BC00013_A16PaisID ;
      private int[] BC00012_A1EstadoID ;
      private string[] BC00012_A2EstadoDescripcion ;
      private bool[] BC00012_A3EstadoActivo ;
      private int[] BC00012_A16PaisID ;
      private int[] BC00018_A1EstadoID ;
      private string[] BC000111_A17PaisDescripcion ;
      private int[] BC000112_A4CiudadID ;
      private int[] BC000113_A1EstadoID ;
      private string[] BC000113_A17PaisDescripcion ;
      private string[] BC000113_A2EstadoDescripcion ;
      private bool[] BC000113_A3EstadoActivo ;
      private int[] BC000113_A16PaisID ;
      private SdtEstado bcEstado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class estado_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00012;
          prmBC00012 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC00013;
          prmBC00013 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC00014;
          prmBC00014 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC00015;
          prmBC00015 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC00016;
          prmBC00016 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC00017;
          prmBC00017 = new Object[] {
          new ParDef("@EstadoDescripcion",GXType.Char,80,0) ,
          new ParDef("@EstadoActivo",GXType.Byte,4,0) ,
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC00018;
          prmBC00018 = new Object[] {
          };
          Object[] prmBC00019;
          prmBC00019 = new Object[] {
          new ParDef("@EstadoDescripcion",GXType.Char,80,0) ,
          new ParDef("@EstadoActivo",GXType.Byte,4,0) ,
          new ParDef("@PaisID",GXType.Int32,9,0) ,
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000110;
          prmBC000110 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000111;
          prmBC000111 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC000112;
          prmBC000112 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000113;
          prmBC000113 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00012", "SELECT `EstadoID`, `EstadoDescripcion`, `EstadoActivo`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00013", "SELECT `EstadoID`, `EstadoDescripcion`, `EstadoActivo`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00014", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00015", "SELECT TM1.`EstadoID`, T2.`PaisDescripcion`, TM1.`EstadoDescripcion`, TM1.`EstadoActivo`, TM1.`PaisID` FROM (`Estado` TM1 INNER JOIN `Pais` T2 ON T2.`PaisID` = TM1.`PaisID`) WHERE TM1.`EstadoID` = @EstadoID ORDER BY TM1.`EstadoID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00016", "SELECT `EstadoID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00017", "INSERT INTO `Estado`(`EstadoDescripcion`, `EstadoActivo`, `PaisID`) VALUES(@EstadoDescripcion, @EstadoActivo, @PaisID)", GxErrorMask.GX_NOMASK,prmBC00017)
             ,new CursorDef("BC00018", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00018,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00019", "UPDATE `Estado` SET `EstadoDescripcion`=@EstadoDescripcion, `EstadoActivo`=@EstadoActivo, `PaisID`=@PaisID  WHERE `EstadoID` = @EstadoID", GxErrorMask.GX_NOMASK,prmBC00019)
             ,new CursorDef("BC000110", "DELETE FROM `Estado`  WHERE `EstadoID` = @EstadoID", GxErrorMask.GX_NOMASK,prmBC000110)
             ,new CursorDef("BC000111", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000112", "SELECT `CiudadID` FROM `Ciudad` WHERE `EstadoID` = @EstadoID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000113", "SELECT TM1.`EstadoID`, T2.`PaisDescripcion`, TM1.`EstadoDescripcion`, TM1.`EstadoActivo`, TM1.`PaisID` FROM (`Estado` TM1 INNER JOIN `Pais` T2 ON T2.`PaisID` = TM1.`PaisID`) WHERE TM1.`EstadoID` = @EstadoID ORDER BY TM1.`EstadoID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000113,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
