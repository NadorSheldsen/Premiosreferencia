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
   public class ciudad_bc : GxSilentTrn, IGxSilentTrn
   {
      public ciudad_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ciudad_bc( IGxContext context )
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
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
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
               Z4CiudadID = A4CiudadID;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
                  ZM022( 2) ;
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z6CiudadActivo = A6CiudadActivo;
            Z1EstadoID = A1EstadoID;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z16PaisID = A16PaisID;
         }
         if ( GX_JID == -1 )
         {
            Z4CiudadID = A4CiudadID;
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z6CiudadActivo = A6CiudadActivo;
            Z1EstadoID = A1EstadoID;
            Z16PaisID = A16PaisID;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load022( )
      {
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A5CiudadDescripcion = BC00025_A5CiudadDescripcion[0];
            A6CiudadActivo = BC00025_A6CiudadActivo[0];
            A1EstadoID = BC00025_A1EstadoID[0];
            A16PaisID = BC00025_A16PaisID[0];
            ZM022( -1) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
            AnyError = 1;
         }
         A16PaisID = BC00024_A16PaisID[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 1) ;
            RcdFound2 = 1;
            A4CiudadID = BC00023_A4CiudadID[0];
            n4CiudadID = BC00023_n4CiudadID[0];
            A5CiudadDescripcion = BC00023_A5CiudadDescripcion[0];
            A6CiudadActivo = BC00023_A6CiudadActivo[0];
            A1EstadoID = BC00023_A1EstadoID[0];
            Z4CiudadID = A4CiudadID;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         CONFIRM_020( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {n4CiudadID, A4CiudadID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ciudad"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z5CiudadDescripcion, BC00022_A5CiudadDescripcion[0]) != 0 ) || ( Z6CiudadActivo != BC00022_A6CiudadActivo[0] ) || ( Z1EstadoID != BC00022_A1EstadoID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Ciudad"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00027 */
                     pr_default.execute(5, new Object[] {A5CiudadDescripcion, A6CiudadActivo, A1EstadoID});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00028 */
                     pr_default.execute(6);
                     A4CiudadID = BC00028_A4CiudadID[0];
                     n4CiudadID = BC00028_n4CiudadID[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Ciudad");
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00029 */
                     pr_default.execute(7, new Object[] {A5CiudadDescripcion, A6CiudadActivo, A1EstadoID, n4CiudadID, A4CiudadID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Ciudad");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ciudad"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000210 */
                  pr_default.execute(8, new Object[] {n4CiudadID, A4CiudadID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Ciudad");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000211 */
            pr_default.execute(9, new Object[] {A1EstadoID});
            A16PaisID = BC000211_A16PaisID[0];
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000212 */
            pr_default.execute(10, new Object[] {n4CiudadID, A4CiudadID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Usuario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
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

      public void ScanKeyStart022( )
      {
         /* Using cursor BC000213 */
         pr_default.execute(11, new Object[] {n4CiudadID, A4CiudadID});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound2 = 1;
            A4CiudadID = BC000213_A4CiudadID[0];
            n4CiudadID = BC000213_n4CiudadID[0];
            A5CiudadDescripcion = BC000213_A5CiudadDescripcion[0];
            A6CiudadActivo = BC000213_A6CiudadActivo[0];
            A1EstadoID = BC000213_A1EstadoID[0];
            A16PaisID = BC000213_A16PaisID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound2 = 1;
            A4CiudadID = BC000213_A4CiudadID[0];
            n4CiudadID = BC000213_n4CiudadID[0];
            A5CiudadDescripcion = BC000213_A5CiudadDescripcion[0];
            A6CiudadActivo = BC000213_A6CiudadActivo[0];
            A1EstadoID = BC000213_A1EstadoID[0];
            A16PaisID = BC000213_A16PaisID[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcCiudad) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcCiudad, 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A1EstadoID = 0;
         A16PaisID = 0;
         A5CiudadDescripcion = "";
         A6CiudadActivo = false;
         Z5CiudadDescripcion = "";
         Z6CiudadActivo = false;
         Z1EstadoID = 0;
      }

      protected void InitAll022( )
      {
         A4CiudadID = 0;
         n4CiudadID = false;
         InitializeNonKey022( ) ;
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

      public void VarsToRow2( SdtCiudad obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Estadoid = A1EstadoID;
         obj2.gxTpr_Paisid = A16PaisID;
         obj2.gxTpr_Ciudaddescripcion = A5CiudadDescripcion;
         obj2.gxTpr_Ciudadactivo = A6CiudadActivo;
         obj2.gxTpr_Ciudadid = A4CiudadID;
         obj2.gxTpr_Ciudadid_Z = Z4CiudadID;
         obj2.gxTpr_Estadoid_Z = Z1EstadoID;
         obj2.gxTpr_Paisid_Z = Z16PaisID;
         obj2.gxTpr_Ciudaddescripcion_Z = Z5CiudadDescripcion;
         obj2.gxTpr_Ciudadactivo_Z = Z6CiudadActivo;
         obj2.gxTpr_Ciudadid_N = (short)(Convert.ToInt16(n4CiudadID));
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( SdtCiudad obj2 )
      {
         obj2.gxTpr_Ciudadid = A4CiudadID;
         return  ;
      }

      public void RowToVars2( SdtCiudad obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A1EstadoID = obj2.gxTpr_Estadoid;
         A16PaisID = obj2.gxTpr_Paisid;
         A5CiudadDescripcion = obj2.gxTpr_Ciudaddescripcion;
         A6CiudadActivo = obj2.gxTpr_Ciudadactivo;
         A4CiudadID = obj2.gxTpr_Ciudadid;
         n4CiudadID = false;
         Z4CiudadID = obj2.gxTpr_Ciudadid_Z;
         Z1EstadoID = obj2.gxTpr_Estadoid_Z;
         Z16PaisID = obj2.gxTpr_Paisid_Z;
         Z5CiudadDescripcion = obj2.gxTpr_Ciudaddescripcion_Z;
         Z6CiudadActivo = obj2.gxTpr_Ciudadactivo_Z;
         n4CiudadID = (bool)(Convert.ToBoolean(obj2.gxTpr_Ciudadid_N));
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A4CiudadID = (int)getParm(obj,0);
         n4CiudadID = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4CiudadID = A4CiudadID;
         }
         ZM022( -1) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
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
         RowToVars2( bcCiudad, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4CiudadID = A4CiudadID;
         }
         ZM022( -1) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A4CiudadID != Z4CiudadID )
               {
                  A4CiudadID = Z4CiudadID;
                  n4CiudadID = false;
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
                  Update022( ) ;
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
                  if ( A4CiudadID != Z4CiudadID )
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
                        Insert022( ) ;
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
                        Insert022( ) ;
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
         RowToVars2( bcCiudad, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcCiudad) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcCiudad, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcCiudad) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow2( bcCiudad) ;
         }
         else
         {
            SdtCiudad auxBC = new SdtCiudad(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A4CiudadID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCiudad);
               auxBC.Save();
               bcCiudad.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars2( bcCiudad, 1) ;
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
         RowToVars2( bcCiudad, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
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
               VarsToRow2( bcCiudad) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow2( bcCiudad) ;
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
         RowToVars2( bcCiudad, 0) ;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A4CiudadID != Z4CiudadID )
            {
               A4CiudadID = Z4CiudadID;
               n4CiudadID = false;
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
            if ( A4CiudadID != Z4CiudadID )
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
         context.RollbackDataStores("ciudad_bc",pr_default);
         VarsToRow2( bcCiudad) ;
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
         Gx_mode = bcCiudad.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCiudad.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCiudad )
         {
            bcCiudad = (SdtCiudad)(sdt);
            if ( StringUtil.StrCmp(bcCiudad.gxTpr_Mode, "") == 0 )
            {
               bcCiudad.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcCiudad) ;
            }
            else
            {
               RowToVars2( bcCiudad, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCiudad.gxTpr_Mode, "") == 0 )
            {
               bcCiudad.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcCiudad, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCiudad Ciudad_BC
      {
         get {
            return bcCiudad ;
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
         Z5CiudadDescripcion = "";
         A5CiudadDescripcion = "";
         BC00025_A4CiudadID = new int[1] ;
         BC00025_n4CiudadID = new bool[] {false} ;
         BC00025_A5CiudadDescripcion = new string[] {""} ;
         BC00025_A6CiudadActivo = new bool[] {false} ;
         BC00025_A1EstadoID = new int[1] ;
         BC00025_A16PaisID = new int[1] ;
         BC00024_A16PaisID = new int[1] ;
         BC00026_A4CiudadID = new int[1] ;
         BC00026_n4CiudadID = new bool[] {false} ;
         BC00023_A4CiudadID = new int[1] ;
         BC00023_n4CiudadID = new bool[] {false} ;
         BC00023_A5CiudadDescripcion = new string[] {""} ;
         BC00023_A6CiudadActivo = new bool[] {false} ;
         BC00023_A1EstadoID = new int[1] ;
         sMode2 = "";
         BC00022_A4CiudadID = new int[1] ;
         BC00022_n4CiudadID = new bool[] {false} ;
         BC00022_A5CiudadDescripcion = new string[] {""} ;
         BC00022_A6CiudadActivo = new bool[] {false} ;
         BC00022_A1EstadoID = new int[1] ;
         BC00028_A4CiudadID = new int[1] ;
         BC00028_n4CiudadID = new bool[] {false} ;
         BC000211_A16PaisID = new int[1] ;
         BC000212_A29UsuarioID = new int[1] ;
         BC000213_A4CiudadID = new int[1] ;
         BC000213_n4CiudadID = new bool[] {false} ;
         BC000213_A5CiudadDescripcion = new string[] {""} ;
         BC000213_A6CiudadActivo = new bool[] {false} ;
         BC000213_A1EstadoID = new int[1] ;
         BC000213_A16PaisID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ciudad_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A4CiudadID, BC00022_A5CiudadDescripcion, BC00022_A6CiudadActivo, BC00022_A1EstadoID
               }
               , new Object[] {
               BC00023_A4CiudadID, BC00023_A5CiudadDescripcion, BC00023_A6CiudadActivo, BC00023_A1EstadoID
               }
               , new Object[] {
               BC00024_A16PaisID
               }
               , new Object[] {
               BC00025_A4CiudadID, BC00025_A5CiudadDescripcion, BC00025_A6CiudadActivo, BC00025_A1EstadoID, BC00025_A16PaisID
               }
               , new Object[] {
               BC00026_A4CiudadID
               }
               , new Object[] {
               }
               , new Object[] {
               BC00028_A4CiudadID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000211_A16PaisID
               }
               , new Object[] {
               BC000212_A29UsuarioID
               }
               , new Object[] {
               BC000213_A4CiudadID, BC000213_A5CiudadDescripcion, BC000213_A6CiudadActivo, BC000213_A1EstadoID, BC000213_A16PaisID
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound2 ;
      private int trnEnded ;
      private int Z4CiudadID ;
      private int A4CiudadID ;
      private int Z1EstadoID ;
      private int A1EstadoID ;
      private int Z16PaisID ;
      private int A16PaisID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode2 ;
      private bool Z6CiudadActivo ;
      private bool A6CiudadActivo ;
      private bool n4CiudadID ;
      private string Z5CiudadDescripcion ;
      private string A5CiudadDescripcion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00025_A4CiudadID ;
      private bool[] BC00025_n4CiudadID ;
      private string[] BC00025_A5CiudadDescripcion ;
      private bool[] BC00025_A6CiudadActivo ;
      private int[] BC00025_A1EstadoID ;
      private int[] BC00025_A16PaisID ;
      private int[] BC00024_A16PaisID ;
      private int[] BC00026_A4CiudadID ;
      private bool[] BC00026_n4CiudadID ;
      private int[] BC00023_A4CiudadID ;
      private bool[] BC00023_n4CiudadID ;
      private string[] BC00023_A5CiudadDescripcion ;
      private bool[] BC00023_A6CiudadActivo ;
      private int[] BC00023_A1EstadoID ;
      private int[] BC00022_A4CiudadID ;
      private bool[] BC00022_n4CiudadID ;
      private string[] BC00022_A5CiudadDescripcion ;
      private bool[] BC00022_A6CiudadActivo ;
      private int[] BC00022_A1EstadoID ;
      private int[] BC00028_A4CiudadID ;
      private bool[] BC00028_n4CiudadID ;
      private int[] BC000211_A16PaisID ;
      private int[] BC000212_A29UsuarioID ;
      private int[] BC000213_A4CiudadID ;
      private bool[] BC000213_n4CiudadID ;
      private string[] BC000213_A5CiudadDescripcion ;
      private bool[] BC000213_A6CiudadActivo ;
      private int[] BC000213_A1EstadoID ;
      private int[] BC000213_A16PaisID ;
      private SdtCiudad bcCiudad ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class ciudad_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00022;
          prmBC00022 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00023;
          prmBC00023 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00024;
          prmBC00024 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC00025;
          prmBC00025 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00026;
          prmBC00026 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00027;
          prmBC00027 = new Object[] {
          new ParDef("@CiudadDescripcion",GXType.Char,80,0) ,
          new ParDef("@CiudadActivo",GXType.Byte,4,0) ,
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC00028;
          prmBC00028 = new Object[] {
          };
          Object[] prmBC00029;
          prmBC00029 = new Object[] {
          new ParDef("@CiudadDescripcion",GXType.Char,80,0) ,
          new ParDef("@CiudadActivo",GXType.Byte,4,0) ,
          new ParDef("@EstadoID",GXType.Int32,9,0) ,
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000210;
          prmBC000210 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000211;
          prmBC000211 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000212;
          prmBC000212 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000213;
          prmBC000213 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT `CiudadID`, `CiudadDescripcion`, `CiudadActivo`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT `CiudadID`, `CiudadDescripcion`, `CiudadActivo`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00024", "SELECT `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT TM1.`CiudadID`, TM1.`CiudadDescripcion`, TM1.`CiudadActivo`, TM1.`EstadoID`, T2.`PaisID` FROM (`Ciudad` TM1 INNER JOIN `Estado` T2 ON T2.`EstadoID` = TM1.`EstadoID`) WHERE TM1.`CiudadID` = @CiudadID ORDER BY TM1.`CiudadID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00026", "SELECT `CiudadID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00027", "INSERT INTO `Ciudad`(`CiudadDescripcion`, `CiudadActivo`, `EstadoID`) VALUES(@CiudadDescripcion, @CiudadActivo, @EstadoID)", GxErrorMask.GX_NOMASK,prmBC00027)
             ,new CursorDef("BC00028", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00029", "UPDATE `Ciudad` SET `CiudadDescripcion`=@CiudadDescripcion, `CiudadActivo`=@CiudadActivo, `EstadoID`=@EstadoID  WHERE `CiudadID` = @CiudadID", GxErrorMask.GX_NOMASK,prmBC00029)
             ,new CursorDef("BC000210", "DELETE FROM `Ciudad`  WHERE `CiudadID` = @CiudadID", GxErrorMask.GX_NOMASK,prmBC000210)
             ,new CursorDef("BC000211", "SELECT `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000211,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000212", "SELECT `UsuarioID` FROM `Usuario` WHERE `CiudadID` = @CiudadID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000213", "SELECT TM1.`CiudadID`, TM1.`CiudadDescripcion`, TM1.`CiudadActivo`, TM1.`EstadoID`, T2.`PaisID` FROM (`Ciudad` TM1 INNER JOIN `Estado` T2 ON T2.`EstadoID` = TM1.`EstadoID`) WHERE TM1.`CiudadID` = @CiudadID ORDER BY TM1.`CiudadID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000213,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
