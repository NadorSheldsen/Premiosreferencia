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
   public class modelo_bc : GxSilentTrn, IGxSilentTrn
   {
      public modelo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public modelo_bc( IGxContext context )
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
         ReadRow088( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey088( ) ;
         standaloneModal( ) ;
         AddRow088( ) ;
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
               Z22ModeloID = A22ModeloID;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls088( ) ;
            }
            else
            {
               CheckExtendedTable088( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors088( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z23ModeloDescripcion = A23ModeloDescripcion;
            Z24ModeloActivo = A24ModeloActivo;
            Z25ModeloSegmento = A25ModeloSegmento;
            Z84ModeloMarca = A84ModeloMarca;
         }
         if ( GX_JID == -2 )
         {
            Z22ModeloID = A22ModeloID;
            Z23ModeloDescripcion = A23ModeloDescripcion;
            Z24ModeloActivo = A24ModeloActivo;
            Z25ModeloSegmento = A25ModeloSegmento;
            Z84ModeloMarca = A84ModeloMarca;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load088( )
      {
         /* Using cursor BC00084 */
         pr_default.execute(2, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound8 = 1;
            A23ModeloDescripcion = BC00084_A23ModeloDescripcion[0];
            A24ModeloActivo = BC00084_A24ModeloActivo[0];
            A25ModeloSegmento = BC00084_A25ModeloSegmento[0];
            A84ModeloMarca = BC00084_A84ModeloMarca[0];
            ZM088( -2) ;
         }
         pr_default.close(2);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
      }

      protected void CheckExtendedTable088( )
      {
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A25ModeloSegmento, "AUTO") == 0 ) || ( StringUtil.StrCmp(A25ModeloSegmento, "CAMIONETA") == 0 ) || ( StringUtil.StrCmp(A25ModeloSegmento, "CAMIÓN") == 0 ) || ( StringUtil.StrCmp(A25ModeloSegmento, "AGRÍCOLA") == 0 ) || ( StringUtil.StrCmp(A25ModeloSegmento, "INDUSTRIAL") == 0 ) || ( StringUtil.StrCmp(A25ModeloSegmento, "OTR") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Modelo Segmento", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors088( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey088( )
      {
         /* Using cursor BC00085 */
         pr_default.execute(3, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00083 */
         pr_default.execute(1, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 2) ;
            RcdFound8 = 1;
            A22ModeloID = BC00083_A22ModeloID[0];
            A23ModeloDescripcion = BC00083_A23ModeloDescripcion[0];
            A24ModeloActivo = BC00083_A24ModeloActivo[0];
            A25ModeloSegmento = BC00083_A25ModeloSegmento[0];
            A84ModeloMarca = BC00083_A84ModeloMarca[0];
            Z22ModeloID = A22ModeloID;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_080( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00082 */
            pr_default.execute(0, new Object[] {A22ModeloID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Modelo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z23ModeloDescripcion, BC00082_A23ModeloDescripcion[0]) != 0 ) || ( Z24ModeloActivo != BC00082_A24ModeloActivo[0] ) || ( StringUtil.StrCmp(Z25ModeloSegmento, BC00082_A25ModeloSegmento[0]) != 0 ) || ( StringUtil.StrCmp(Z84ModeloMarca, BC00082_A84ModeloMarca[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Modelo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00086 */
                     pr_default.execute(4, new Object[] {A23ModeloDescripcion, A24ModeloActivo, A25ModeloSegmento, A84ModeloMarca});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00087 */
                     pr_default.execute(5);
                     A22ModeloID = BC00087_A22ModeloID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Modelo");
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00088 */
                     pr_default.execute(6, new Object[] {A23ModeloDescripcion, A24ModeloActivo, A25ModeloSegmento, A84ModeloMarca, A22ModeloID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Modelo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Modelo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00089 */
                  pr_default.execute(7, new Object[] {A22ModeloID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Modelo");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel088( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000810 */
            pr_default.execute(8, new Object[] {A22ModeloID});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Promocion Modelo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000811 */
            pr_default.execute(9, new Object[] {A22ModeloID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Medida", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
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

      public void ScanKeyStart088( )
      {
         /* Using cursor BC000812 */
         pr_default.execute(10, new Object[] {A22ModeloID});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
            A22ModeloID = BC000812_A22ModeloID[0];
            A23ModeloDescripcion = BC000812_A23ModeloDescripcion[0];
            A24ModeloActivo = BC000812_A24ModeloActivo[0];
            A25ModeloSegmento = BC000812_A25ModeloSegmento[0];
            A84ModeloMarca = BC000812_A84ModeloMarca[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound8 = 0;
         ScanKeyLoad088( ) ;
      }

      protected void ScanKeyLoad088( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound8 = 1;
            A22ModeloID = BC000812_A22ModeloID[0];
            A23ModeloDescripcion = BC000812_A23ModeloDescripcion[0];
            A24ModeloActivo = BC000812_A24ModeloActivo[0];
            A25ModeloSegmento = BC000812_A25ModeloSegmento[0];
            A84ModeloMarca = BC000812_A84ModeloMarca[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd088( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void AddRow088( )
      {
         VarsToRow8( bcModelo) ;
      }

      protected void ReadRow088( )
      {
         RowToVars8( bcModelo, 1) ;
      }

      protected void InitializeNonKey088( )
      {
         A23ModeloDescripcion = "";
         A24ModeloActivo = false;
         A25ModeloSegmento = "";
         A84ModeloMarca = "";
         Z23ModeloDescripcion = "";
         Z24ModeloActivo = false;
         Z25ModeloSegmento = "";
         Z84ModeloMarca = "";
      }

      protected void InitAll088( )
      {
         A22ModeloID = 0;
         InitializeNonKey088( ) ;
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

      public void VarsToRow8( SdtModelo obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Modelodescripcion = A23ModeloDescripcion;
         obj8.gxTpr_Modeloactivo = A24ModeloActivo;
         obj8.gxTpr_Modelosegmento = A25ModeloSegmento;
         obj8.gxTpr_Modelomarca = A84ModeloMarca;
         obj8.gxTpr_Modeloid = A22ModeloID;
         obj8.gxTpr_Modeloid_Z = Z22ModeloID;
         obj8.gxTpr_Modelodescripcion_Z = Z23ModeloDescripcion;
         obj8.gxTpr_Modeloactivo_Z = Z24ModeloActivo;
         obj8.gxTpr_Modelosegmento_Z = Z25ModeloSegmento;
         obj8.gxTpr_Modelomarca_Z = Z84ModeloMarca;
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( SdtModelo obj8 )
      {
         obj8.gxTpr_Modeloid = A22ModeloID;
         return  ;
      }

      public void RowToVars8( SdtModelo obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A23ModeloDescripcion = obj8.gxTpr_Modelodescripcion;
         A24ModeloActivo = obj8.gxTpr_Modeloactivo;
         A25ModeloSegmento = obj8.gxTpr_Modelosegmento;
         A84ModeloMarca = obj8.gxTpr_Modelomarca;
         A22ModeloID = obj8.gxTpr_Modeloid;
         Z22ModeloID = obj8.gxTpr_Modeloid_Z;
         Z23ModeloDescripcion = obj8.gxTpr_Modelodescripcion_Z;
         Z24ModeloActivo = obj8.gxTpr_Modeloactivo_Z;
         Z25ModeloSegmento = obj8.gxTpr_Modelosegmento_Z;
         Z84ModeloMarca = obj8.gxTpr_Modelomarca_Z;
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A22ModeloID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey088( ) ;
         ScanKeyStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z22ModeloID = A22ModeloID;
         }
         ZM088( -2) ;
         OnLoadActions088( ) ;
         AddRow088( ) ;
         ScanKeyEnd088( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcModelo, 0) ;
         ScanKeyStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z22ModeloID = A22ModeloID;
         }
         ZM088( -2) ;
         OnLoadActions088( ) ;
         AddRow088( ) ;
         ScanKeyEnd088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert088( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A22ModeloID != Z22ModeloID )
               {
                  A22ModeloID = Z22ModeloID;
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
                  Update088( ) ;
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
                  if ( A22ModeloID != Z22ModeloID )
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
                        Insert088( ) ;
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
                        Insert088( ) ;
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
         RowToVars8( bcModelo, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcModelo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars8( bcModelo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert088( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcModelo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow8( bcModelo) ;
         }
         else
         {
            SdtModelo auxBC = new SdtModelo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A22ModeloID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcModelo);
               auxBC.Save();
               bcModelo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars8( bcModelo, 1) ;
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
         RowToVars8( bcModelo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert088( ) ;
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
               VarsToRow8( bcModelo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow8( bcModelo) ;
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
         RowToVars8( bcModelo, 0) ;
         GetKey088( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A22ModeloID != Z22ModeloID )
            {
               A22ModeloID = Z22ModeloID;
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
            if ( A22ModeloID != Z22ModeloID )
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
         context.RollbackDataStores("modelo_bc",pr_default);
         VarsToRow8( bcModelo) ;
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
         Gx_mode = bcModelo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcModelo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcModelo )
         {
            bcModelo = (SdtModelo)(sdt);
            if ( StringUtil.StrCmp(bcModelo.gxTpr_Mode, "") == 0 )
            {
               bcModelo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcModelo) ;
            }
            else
            {
               RowToVars8( bcModelo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcModelo.gxTpr_Mode, "") == 0 )
            {
               bcModelo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcModelo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtModelo Modelo_BC
      {
         get {
            return bcModelo ;
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
         Z23ModeloDescripcion = "";
         A23ModeloDescripcion = "";
         Z25ModeloSegmento = "";
         A25ModeloSegmento = "";
         Z84ModeloMarca = "";
         A84ModeloMarca = "";
         BC00084_A22ModeloID = new int[1] ;
         BC00084_A23ModeloDescripcion = new string[] {""} ;
         BC00084_A24ModeloActivo = new bool[] {false} ;
         BC00084_A25ModeloSegmento = new string[] {""} ;
         BC00084_A84ModeloMarca = new string[] {""} ;
         BC00085_A22ModeloID = new int[1] ;
         BC00083_A22ModeloID = new int[1] ;
         BC00083_A23ModeloDescripcion = new string[] {""} ;
         BC00083_A24ModeloActivo = new bool[] {false} ;
         BC00083_A25ModeloSegmento = new string[] {""} ;
         BC00083_A84ModeloMarca = new string[] {""} ;
         sMode8 = "";
         BC00082_A22ModeloID = new int[1] ;
         BC00082_A23ModeloDescripcion = new string[] {""} ;
         BC00082_A24ModeloActivo = new bool[] {false} ;
         BC00082_A25ModeloSegmento = new string[] {""} ;
         BC00082_A84ModeloMarca = new string[] {""} ;
         BC00087_A22ModeloID = new int[1] ;
         BC000810_A48PromocionModeloID = new int[1] ;
         BC000811_A26MedidaID = new int[1] ;
         BC000812_A22ModeloID = new int[1] ;
         BC000812_A23ModeloDescripcion = new string[] {""} ;
         BC000812_A24ModeloActivo = new bool[] {false} ;
         BC000812_A25ModeloSegmento = new string[] {""} ;
         BC000812_A84ModeloMarca = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.modelo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00082_A22ModeloID, BC00082_A23ModeloDescripcion, BC00082_A24ModeloActivo, BC00082_A25ModeloSegmento, BC00082_A84ModeloMarca
               }
               , new Object[] {
               BC00083_A22ModeloID, BC00083_A23ModeloDescripcion, BC00083_A24ModeloActivo, BC00083_A25ModeloSegmento, BC00083_A84ModeloMarca
               }
               , new Object[] {
               BC00084_A22ModeloID, BC00084_A23ModeloDescripcion, BC00084_A24ModeloActivo, BC00084_A25ModeloSegmento, BC00084_A84ModeloMarca
               }
               , new Object[] {
               BC00085_A22ModeloID
               }
               , new Object[] {
               }
               , new Object[] {
               BC00087_A22ModeloID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000810_A48PromocionModeloID
               }
               , new Object[] {
               BC000811_A26MedidaID
               }
               , new Object[] {
               BC000812_A22ModeloID, BC000812_A23ModeloDescripcion, BC000812_A24ModeloActivo, BC000812_A25ModeloSegmento, BC000812_A84ModeloMarca
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound8 ;
      private int trnEnded ;
      private int Z22ModeloID ;
      private int A22ModeloID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z25ModeloSegmento ;
      private string A25ModeloSegmento ;
      private string sMode8 ;
      private bool Z24ModeloActivo ;
      private bool A24ModeloActivo ;
      private string Z23ModeloDescripcion ;
      private string A23ModeloDescripcion ;
      private string Z84ModeloMarca ;
      private string A84ModeloMarca ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00084_A22ModeloID ;
      private string[] BC00084_A23ModeloDescripcion ;
      private bool[] BC00084_A24ModeloActivo ;
      private string[] BC00084_A25ModeloSegmento ;
      private string[] BC00084_A84ModeloMarca ;
      private int[] BC00085_A22ModeloID ;
      private int[] BC00083_A22ModeloID ;
      private string[] BC00083_A23ModeloDescripcion ;
      private bool[] BC00083_A24ModeloActivo ;
      private string[] BC00083_A25ModeloSegmento ;
      private string[] BC00083_A84ModeloMarca ;
      private int[] BC00082_A22ModeloID ;
      private string[] BC00082_A23ModeloDescripcion ;
      private bool[] BC00082_A24ModeloActivo ;
      private string[] BC00082_A25ModeloSegmento ;
      private string[] BC00082_A84ModeloMarca ;
      private int[] BC00087_A22ModeloID ;
      private int[] BC000810_A48PromocionModeloID ;
      private int[] BC000811_A26MedidaID ;
      private int[] BC000812_A22ModeloID ;
      private string[] BC000812_A23ModeloDescripcion ;
      private bool[] BC000812_A24ModeloActivo ;
      private string[] BC000812_A25ModeloSegmento ;
      private string[] BC000812_A84ModeloMarca ;
      private SdtModelo bcModelo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class modelo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00082;
          prmBC00082 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC00083;
          prmBC00083 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC00084;
          prmBC00084 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC00085;
          prmBC00085 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC00086;
          prmBC00086 = new Object[] {
          new ParDef("@ModeloDescripcion",GXType.Char,80,0) ,
          new ParDef("@ModeloActivo",GXType.Byte,4,0) ,
          new ParDef("@ModeloSegmento",GXType.Char,20,0) ,
          new ParDef("@ModeloMarca",GXType.Char,80,0)
          };
          Object[] prmBC00087;
          prmBC00087 = new Object[] {
          };
          Object[] prmBC00088;
          prmBC00088 = new Object[] {
          new ParDef("@ModeloDescripcion",GXType.Char,80,0) ,
          new ParDef("@ModeloActivo",GXType.Byte,4,0) ,
          new ParDef("@ModeloSegmento",GXType.Char,20,0) ,
          new ParDef("@ModeloMarca",GXType.Char,80,0) ,
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC00089;
          prmBC00089 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000810;
          prmBC000810 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000811;
          prmBC000811 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000812;
          prmBC000812 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00082", "SELECT `ModeloID`, `ModeloDescripcion`, `ModeloActivo`, `ModeloSegmento`, `ModeloMarca` FROM `Modelo` WHERE `ModeloID` = @ModeloID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00083", "SELECT `ModeloID`, `ModeloDescripcion`, `ModeloActivo`, `ModeloSegmento`, `ModeloMarca` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00084", "SELECT TM1.`ModeloID`, TM1.`ModeloDescripcion`, TM1.`ModeloActivo`, TM1.`ModeloSegmento`, TM1.`ModeloMarca` FROM `Modelo` TM1 WHERE TM1.`ModeloID` = @ModeloID ORDER BY TM1.`ModeloID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00084,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00085", "SELECT `ModeloID` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00086", "INSERT INTO `Modelo`(`ModeloDescripcion`, `ModeloActivo`, `ModeloSegmento`, `ModeloMarca`) VALUES(@ModeloDescripcion, @ModeloActivo, @ModeloSegmento, @ModeloMarca)", GxErrorMask.GX_NOMASK,prmBC00086)
             ,new CursorDef("BC00087", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00087,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00088", "UPDATE `Modelo` SET `ModeloDescripcion`=@ModeloDescripcion, `ModeloActivo`=@ModeloActivo, `ModeloSegmento`=@ModeloSegmento, `ModeloMarca`=@ModeloMarca  WHERE `ModeloID` = @ModeloID", GxErrorMask.GX_NOMASK,prmBC00088)
             ,new CursorDef("BC00089", "DELETE FROM `Modelo`  WHERE `ModeloID` = @ModeloID", GxErrorMask.GX_NOMASK,prmBC00089)
             ,new CursorDef("BC000810", "SELECT `PromocionModeloID` FROM `PromocionModelo` WHERE `ModeloID` = @ModeloID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000810,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000811", "SELECT `MedidaID` FROM `Medida` WHERE `ModeloID` = @ModeloID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000811,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000812", "SELECT TM1.`ModeloID`, TM1.`ModeloDescripcion`, TM1.`ModeloActivo`, TM1.`ModeloSegmento`, TM1.`ModeloMarca` FROM `Modelo` TM1 WHERE TM1.`ModeloID` = @ModeloID ORDER BY TM1.`ModeloID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000812,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
