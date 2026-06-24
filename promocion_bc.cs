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
   public class promocion_bc : GxSilentTrn, IGxSilentTrn
   {
      public promocion_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public promocion_bc( IGxContext context )
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
         ReadRow0C12( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C12( ) ;
         standaloneModal( ) ;
         AddRow0C12( ) ;
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
            E110C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z41PromocionID = A41PromocionID;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C12( ) ;
            }
            else
            {
               CheckExtendedTable0C12( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0C12( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0C12( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z70PromocionVigencia = A70PromocionVigencia;
         }
         if ( GX_JID == -4 )
         {
            Z41PromocionID = A41PromocionID;
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z44PromocionArte = A44PromocionArte;
            Z40000PromocionArte_GXI = A40000PromocionArte_GXI;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z68PromocionSegmentosJson = A68PromocionSegmentosJson;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0C12( )
      {
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound12 = 1;
            A42PromocionDescripcion = BC000C4_A42PromocionDescripcion[0];
            A43PromocionBase = BC000C4_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000C4_A40000PromocionArte_GXI[0];
            A45PromocionFechaInicio = BC000C4_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000C4_A46PromocionFechaFin[0];
            A68PromocionSegmentosJson = BC000C4_A68PromocionSegmentosJson[0];
            A44PromocionArte = BC000C4_A44PromocionArte[0];
            ZM0C12( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0C12( ) ;
      }

      protected void OnLoadActions0C12( )
      {
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
      }

      protected void CheckExtendedTable0C12( )
      {
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A45PromocionFechaInicio) || ( DateTimeUtil.ResetTime ( A45PromocionFechaInicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Inicio de la promoción", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         if ( ! ( (DateTime.MinValue==A46PromocionFechaFin) || ( DateTimeUtil.ResetTime ( A46PromocionFechaFin ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fin de la promoción", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0C12( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C12( )
      {
         /* Using cursor BC000C5 */
         pr_default.execute(3, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C12( 4) ;
            RcdFound12 = 1;
            A41PromocionID = BC000C3_A41PromocionID[0];
            A42PromocionDescripcion = BC000C3_A42PromocionDescripcion[0];
            A43PromocionBase = BC000C3_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000C3_A40000PromocionArte_GXI[0];
            A45PromocionFechaInicio = BC000C3_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000C3_A46PromocionFechaFin[0];
            A68PromocionSegmentosJson = BC000C3_A68PromocionSegmentosJson[0];
            A44PromocionArte = BC000C3_A44PromocionArte[0];
            Z41PromocionID = A41PromocionID;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0C12( ) ;
            }
            Gx_mode = sMode12;
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0C12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode12;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C12( ) ;
         if ( RcdFound12 == 0 )
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
         CONFIRM_0C0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0C12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {A41PromocionID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promocion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z42PromocionDescripcion, BC000C2_A42PromocionDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z43PromocionBase, BC000C2_A43PromocionBase[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z45PromocionFechaInicio ) != DateTimeUtil.ResetTime ( BC000C2_A45PromocionFechaInicio[0] ) ) || ( DateTimeUtil.ResetTime ( Z46PromocionFechaFin ) != DateTimeUtil.ResetTime ( BC000C2_A46PromocionFechaFin[0] ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Promocion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C12( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C12( 0) ;
            CheckOptimisticConcurrency0C12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C6 */
                     pr_default.execute(4, new Object[] {A42PromocionDescripcion, A43PromocionBase, A44PromocionArte, A40000PromocionArte_GXI, A45PromocionFechaInicio, A46PromocionFechaFin, A68PromocionSegmentosJson});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000C7 */
                     pr_default.execute(5);
                     A41PromocionID = BC000C7_A41PromocionID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Promocion");
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
               Load0C12( ) ;
            }
            EndLevel0C12( ) ;
         }
         CloseExtendedTableCursors0C12( ) ;
      }

      protected void Update0C12( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C8 */
                     pr_default.execute(6, new Object[] {A42PromocionDescripcion, A43PromocionBase, A45PromocionFechaInicio, A46PromocionFechaFin, A68PromocionSegmentosJson, A41PromocionID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Promocion");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promocion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C12( ) ;
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
            EndLevel0C12( ) ;
         }
         CloseExtendedTableCursors0C12( ) ;
      }

      protected void DeferredUpdate0C12( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000C9 */
            pr_default.execute(7, new Object[] {A44PromocionArte, A40000PromocionArte_GXI, A41PromocionID});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Promocion");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C12( ) ;
            AfterConfirm0C12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C10 */
                  pr_default.execute(8, new Object[] {A41PromocionID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Promocion");
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C12( ) ;
         Gx_mode = sMode12;
      }

      protected void OnDeleteControls0C12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000C11 */
            pr_default.execute(9, new Object[] {A41PromocionID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Factura", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000C12 */
            pr_default.execute(10, new Object[] {A41PromocionID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Promocion Modelo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000C13 */
            pr_default.execute(11, new Object[] {A41PromocionID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Promocion Distribuidor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0C12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C12( ) ;
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

      public void ScanKeyStart0C12( )
      {
         /* Scan By routine */
         /* Using cursor BC000C14 */
         pr_default.execute(12, new Object[] {A41PromocionID});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound12 = 1;
            A41PromocionID = BC000C14_A41PromocionID[0];
            A42PromocionDescripcion = BC000C14_A42PromocionDescripcion[0];
            A43PromocionBase = BC000C14_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000C14_A40000PromocionArte_GXI[0];
            A45PromocionFechaInicio = BC000C14_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000C14_A46PromocionFechaFin[0];
            A68PromocionSegmentosJson = BC000C14_A68PromocionSegmentosJson[0];
            A44PromocionArte = BC000C14_A44PromocionArte[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C12( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound12 = 0;
         ScanKeyLoad0C12( ) ;
      }

      protected void ScanKeyLoad0C12( )
      {
         sMode12 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound12 = 1;
            A41PromocionID = BC000C14_A41PromocionID[0];
            A42PromocionDescripcion = BC000C14_A42PromocionDescripcion[0];
            A43PromocionBase = BC000C14_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000C14_A40000PromocionArte_GXI[0];
            A45PromocionFechaInicio = BC000C14_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000C14_A46PromocionFechaFin[0];
            A68PromocionSegmentosJson = BC000C14_A68PromocionSegmentosJson[0];
            A44PromocionArte = BC000C14_A44PromocionArte[0];
         }
         Gx_mode = sMode12;
      }

      protected void ScanKeyEnd0C12( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0C12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C12( )
      {
      }

      protected void send_integrity_lvl_hashes0C12( )
      {
      }

      protected void AddRow0C12( )
      {
         VarsToRow12( bcPromocion) ;
      }

      protected void ReadRow0C12( )
      {
         RowToVars12( bcPromocion, 1) ;
      }

      protected void InitializeNonKey0C12( )
      {
         A70PromocionVigencia = "";
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A44PromocionArte = "";
         A40000PromocionArte_GXI = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         A68PromocionSegmentosJson = "";
         Z42PromocionDescripcion = "";
         Z43PromocionBase = "";
         Z45PromocionFechaInicio = DateTime.MinValue;
         Z46PromocionFechaFin = DateTime.MinValue;
      }

      protected void InitAll0C12( )
      {
         A41PromocionID = 0;
         InitializeNonKey0C12( ) ;
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

      public void VarsToRow12( SdtPromocion obj12 )
      {
         obj12.gxTpr_Mode = Gx_mode;
         obj12.gxTpr_Promocionvigencia = A70PromocionVigencia;
         obj12.gxTpr_Promociondescripcion = A42PromocionDescripcion;
         obj12.gxTpr_Promocionbase = A43PromocionBase;
         obj12.gxTpr_Promocionarte = A44PromocionArte;
         obj12.gxTpr_Promocionarte_gxi = A40000PromocionArte_GXI;
         obj12.gxTpr_Promocionfechainicio = A45PromocionFechaInicio;
         obj12.gxTpr_Promocionfechafin = A46PromocionFechaFin;
         obj12.gxTpr_Promocionsegmentosjson = A68PromocionSegmentosJson;
         obj12.gxTpr_Promocionid = A41PromocionID;
         obj12.gxTpr_Promocionid_Z = Z41PromocionID;
         obj12.gxTpr_Promociondescripcion_Z = Z42PromocionDescripcion;
         obj12.gxTpr_Promocionbase_Z = Z43PromocionBase;
         obj12.gxTpr_Promocionfechainicio_Z = Z45PromocionFechaInicio;
         obj12.gxTpr_Promocionfechafin_Z = Z46PromocionFechaFin;
         obj12.gxTpr_Promocionvigencia_Z = Z70PromocionVigencia;
         obj12.gxTpr_Promocionarte_gxi_Z = Z40000PromocionArte_GXI;
         obj12.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow12( SdtPromocion obj12 )
      {
         obj12.gxTpr_Promocionid = A41PromocionID;
         return  ;
      }

      public void RowToVars12( SdtPromocion obj12 ,
                               int forceLoad )
      {
         Gx_mode = obj12.gxTpr_Mode;
         A70PromocionVigencia = obj12.gxTpr_Promocionvigencia;
         A42PromocionDescripcion = obj12.gxTpr_Promociondescripcion;
         A43PromocionBase = obj12.gxTpr_Promocionbase;
         A44PromocionArte = obj12.gxTpr_Promocionarte;
         A40000PromocionArte_GXI = obj12.gxTpr_Promocionarte_gxi;
         A45PromocionFechaInicio = obj12.gxTpr_Promocionfechainicio;
         A46PromocionFechaFin = obj12.gxTpr_Promocionfechafin;
         A68PromocionSegmentosJson = obj12.gxTpr_Promocionsegmentosjson;
         A41PromocionID = obj12.gxTpr_Promocionid;
         Z41PromocionID = obj12.gxTpr_Promocionid_Z;
         Z42PromocionDescripcion = obj12.gxTpr_Promociondescripcion_Z;
         Z43PromocionBase = obj12.gxTpr_Promocionbase_Z;
         Z45PromocionFechaInicio = obj12.gxTpr_Promocionfechainicio_Z;
         Z46PromocionFechaFin = obj12.gxTpr_Promocionfechafin_Z;
         Z70PromocionVigencia = obj12.gxTpr_Promocionvigencia_Z;
         Z40000PromocionArte_GXI = obj12.gxTpr_Promocionarte_gxi_Z;
         Gx_mode = obj12.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A41PromocionID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C12( ) ;
         ScanKeyStart0C12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z41PromocionID = A41PromocionID;
         }
         ZM0C12( -4) ;
         OnLoadActions0C12( ) ;
         AddRow0C12( ) ;
         ScanKeyEnd0C12( ) ;
         if ( RcdFound12 == 0 )
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
         RowToVars12( bcPromocion, 0) ;
         ScanKeyStart0C12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z41PromocionID = A41PromocionID;
         }
         ZM0C12( -4) ;
         OnLoadActions0C12( ) ;
         AddRow0C12( ) ;
         ScanKeyEnd0C12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0C12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C12( ) ;
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A41PromocionID != Z41PromocionID )
               {
                  A41PromocionID = Z41PromocionID;
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
                  Update0C12( ) ;
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
                  if ( A41PromocionID != Z41PromocionID )
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
                        Insert0C12( ) ;
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
                        Insert0C12( ) ;
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
         RowToVars12( bcPromocion, 1) ;
         SaveImpl( ) ;
         VarsToRow12( bcPromocion) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars12( bcPromocion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C12( ) ;
         AfterTrn( ) ;
         VarsToRow12( bcPromocion) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow12( bcPromocion) ;
         }
         else
         {
            SdtPromocion auxBC = new SdtPromocion(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A41PromocionID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPromocion);
               auxBC.Save();
               bcPromocion.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars12( bcPromocion, 1) ;
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
         RowToVars12( bcPromocion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C12( ) ;
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
               VarsToRow12( bcPromocion) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow12( bcPromocion) ;
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
         RowToVars12( bcPromocion, 0) ;
         GetKey0C12( ) ;
         if ( RcdFound12 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A41PromocionID != Z41PromocionID )
            {
               A41PromocionID = Z41PromocionID;
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
            if ( A41PromocionID != Z41PromocionID )
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
         context.RollbackDataStores("promocion_bc",pr_default);
         VarsToRow12( bcPromocion) ;
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
         Gx_mode = bcPromocion.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPromocion.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPromocion )
         {
            bcPromocion = (SdtPromocion)(sdt);
            if ( StringUtil.StrCmp(bcPromocion.gxTpr_Mode, "") == 0 )
            {
               bcPromocion.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow12( bcPromocion) ;
            }
            else
            {
               RowToVars12( bcPromocion, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPromocion.gxTpr_Mode, "") == 0 )
            {
               bcPromocion.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars12( bcPromocion, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPromocion Promocion_BC
      {
         get {
            return bcPromocion ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z42PromocionDescripcion = "";
         A42PromocionDescripcion = "";
         Z43PromocionBase = "";
         A43PromocionBase = "";
         Z45PromocionFechaInicio = DateTime.MinValue;
         A45PromocionFechaInicio = DateTime.MinValue;
         Z46PromocionFechaFin = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         Z70PromocionVigencia = "";
         A70PromocionVigencia = "";
         Z44PromocionArte = "";
         A44PromocionArte = "";
         Z40000PromocionArte_GXI = "";
         A40000PromocionArte_GXI = "";
         Z68PromocionSegmentosJson = "";
         A68PromocionSegmentosJson = "";
         BC000C4_A41PromocionID = new int[1] ;
         BC000C4_A42PromocionDescripcion = new string[] {""} ;
         BC000C4_A43PromocionBase = new string[] {""} ;
         BC000C4_A40000PromocionArte_GXI = new string[] {""} ;
         BC000C4_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000C4_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000C4_A68PromocionSegmentosJson = new string[] {""} ;
         BC000C4_A44PromocionArte = new string[] {""} ;
         BC000C5_A41PromocionID = new int[1] ;
         BC000C3_A41PromocionID = new int[1] ;
         BC000C3_A42PromocionDescripcion = new string[] {""} ;
         BC000C3_A43PromocionBase = new string[] {""} ;
         BC000C3_A40000PromocionArte_GXI = new string[] {""} ;
         BC000C3_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000C3_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000C3_A68PromocionSegmentosJson = new string[] {""} ;
         BC000C3_A44PromocionArte = new string[] {""} ;
         sMode12 = "";
         BC000C2_A41PromocionID = new int[1] ;
         BC000C2_A42PromocionDescripcion = new string[] {""} ;
         BC000C2_A43PromocionBase = new string[] {""} ;
         BC000C2_A40000PromocionArte_GXI = new string[] {""} ;
         BC000C2_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000C2_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000C2_A68PromocionSegmentosJson = new string[] {""} ;
         BC000C2_A44PromocionArte = new string[] {""} ;
         BC000C7_A41PromocionID = new int[1] ;
         BC000C11_A69FacturaID = new int[1] ;
         BC000C12_A48PromocionModeloID = new int[1] ;
         BC000C13_A47PromocionDistribuidorID = new int[1] ;
         BC000C14_A41PromocionID = new int[1] ;
         BC000C14_A42PromocionDescripcion = new string[] {""} ;
         BC000C14_A43PromocionBase = new string[] {""} ;
         BC000C14_A40000PromocionArte_GXI = new string[] {""} ;
         BC000C14_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000C14_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000C14_A68PromocionSegmentosJson = new string[] {""} ;
         BC000C14_A44PromocionArte = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promocion_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A41PromocionID, BC000C2_A42PromocionDescripcion, BC000C2_A43PromocionBase, BC000C2_A40000PromocionArte_GXI, BC000C2_A45PromocionFechaInicio, BC000C2_A46PromocionFechaFin, BC000C2_A68PromocionSegmentosJson, BC000C2_A44PromocionArte
               }
               , new Object[] {
               BC000C3_A41PromocionID, BC000C3_A42PromocionDescripcion, BC000C3_A43PromocionBase, BC000C3_A40000PromocionArte_GXI, BC000C3_A45PromocionFechaInicio, BC000C3_A46PromocionFechaFin, BC000C3_A68PromocionSegmentosJson, BC000C3_A44PromocionArte
               }
               , new Object[] {
               BC000C4_A41PromocionID, BC000C4_A42PromocionDescripcion, BC000C4_A43PromocionBase, BC000C4_A40000PromocionArte_GXI, BC000C4_A45PromocionFechaInicio, BC000C4_A46PromocionFechaFin, BC000C4_A68PromocionSegmentosJson, BC000C4_A44PromocionArte
               }
               , new Object[] {
               BC000C5_A41PromocionID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C7_A41PromocionID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C11_A69FacturaID
               }
               , new Object[] {
               BC000C12_A48PromocionModeloID
               }
               , new Object[] {
               BC000C13_A47PromocionDistribuidorID
               }
               , new Object[] {
               BC000C14_A41PromocionID, BC000C14_A42PromocionDescripcion, BC000C14_A43PromocionBase, BC000C14_A40000PromocionArte_GXI, BC000C14_A45PromocionFechaInicio, BC000C14_A46PromocionFechaFin, BC000C14_A68PromocionSegmentosJson, BC000C14_A44PromocionArte
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120C2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound12 ;
      private int trnEnded ;
      private int Z41PromocionID ;
      private int A41PromocionID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode12 ;
      private DateTime Z45PromocionFechaInicio ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime Z46PromocionFechaFin ;
      private DateTime A46PromocionFechaFin ;
      private bool returnInSub ;
      private string Z68PromocionSegmentosJson ;
      private string A68PromocionSegmentosJson ;
      private string Z42PromocionDescripcion ;
      private string A42PromocionDescripcion ;
      private string Z43PromocionBase ;
      private string A43PromocionBase ;
      private string Z70PromocionVigencia ;
      private string A70PromocionVigencia ;
      private string Z40000PromocionArte_GXI ;
      private string A40000PromocionArte_GXI ;
      private string Z44PromocionArte ;
      private string A44PromocionArte ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC000C4_A41PromocionID ;
      private string[] BC000C4_A42PromocionDescripcion ;
      private string[] BC000C4_A43PromocionBase ;
      private string[] BC000C4_A40000PromocionArte_GXI ;
      private DateTime[] BC000C4_A45PromocionFechaInicio ;
      private DateTime[] BC000C4_A46PromocionFechaFin ;
      private string[] BC000C4_A68PromocionSegmentosJson ;
      private string[] BC000C4_A44PromocionArte ;
      private int[] BC000C5_A41PromocionID ;
      private int[] BC000C3_A41PromocionID ;
      private string[] BC000C3_A42PromocionDescripcion ;
      private string[] BC000C3_A43PromocionBase ;
      private string[] BC000C3_A40000PromocionArte_GXI ;
      private DateTime[] BC000C3_A45PromocionFechaInicio ;
      private DateTime[] BC000C3_A46PromocionFechaFin ;
      private string[] BC000C3_A68PromocionSegmentosJson ;
      private string[] BC000C3_A44PromocionArte ;
      private int[] BC000C2_A41PromocionID ;
      private string[] BC000C2_A42PromocionDescripcion ;
      private string[] BC000C2_A43PromocionBase ;
      private string[] BC000C2_A40000PromocionArte_GXI ;
      private DateTime[] BC000C2_A45PromocionFechaInicio ;
      private DateTime[] BC000C2_A46PromocionFechaFin ;
      private string[] BC000C2_A68PromocionSegmentosJson ;
      private string[] BC000C2_A44PromocionArte ;
      private int[] BC000C7_A41PromocionID ;
      private int[] BC000C11_A69FacturaID ;
      private int[] BC000C12_A48PromocionModeloID ;
      private int[] BC000C13_A47PromocionDistribuidorID ;
      private int[] BC000C14_A41PromocionID ;
      private string[] BC000C14_A42PromocionDescripcion ;
      private string[] BC000C14_A43PromocionBase ;
      private string[] BC000C14_A40000PromocionArte_GXI ;
      private DateTime[] BC000C14_A45PromocionFechaInicio ;
      private DateTime[] BC000C14_A46PromocionFechaFin ;
      private string[] BC000C14_A68PromocionSegmentosJson ;
      private string[] BC000C14_A44PromocionArte ;
      private SdtPromocion bcPromocion ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class promocion_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
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
          Object[] prmBC000C2;
          prmBC000C2 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000C3;
          prmBC000C3 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000C4;
          prmBC000C4 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000C5;
          prmBC000C5 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000C6;
          prmBC000C6 = new Object[] {
          new ParDef("@PromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@PromocionBase",GXType.Char,700,0) ,
          new ParDef("@PromocionArte",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromocionArte_GXI",GXType.Char,2048,0){AddAtt=true, ImgIdx=2, Tbl="Promocion", Fld="PromocionArte"} ,
          new ParDef("@PromocionFechaInicio",GXType.Date,8,0) ,
          new ParDef("@PromocionFechaFin",GXType.Date,8,0) ,
          new ParDef("@PromocionSegmentosJson",GXType.Char,2097152,0)
          };
          Object[] prmBC000C7;
          prmBC000C7 = new Object[] {
          };
          Object[] prmBC000C8;
          prmBC000C8 = new Object[] {
          new ParDef("@PromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@PromocionBase",GXType.Char,700,0) ,
          new ParDef("@PromocionFechaInicio",GXType.Date,8,0) ,
          new ParDef("@PromocionFechaFin",GXType.Date,8,0) ,
          new ParDef("@PromocionSegmentosJson",GXType.Char,2097152,0) ,
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000C9;
          prmBC000C9 = new Object[] {
          new ParDef("@PromocionArte",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromocionArte_GXI",GXType.Char,2048,0){AddAtt=true, ImgIdx=0, Tbl="Promocion", Fld="PromocionArte"} ,
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000C10;
          prmBC000C10 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000C11;
          prmBC000C11 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000C12;
          prmBC000C12 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000C13;
          prmBC000C13 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000C14;
          prmBC000C14 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000C2", "SELECT `PromocionID`, `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionSegmentosJson`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C3", "SELECT `PromocionID`, `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionSegmentosJson`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C4", "SELECT TM1.`PromocionID`, TM1.`PromocionDescripcion`, TM1.`PromocionBase`, TM1.`PromocionArte_GXI`, TM1.`PromocionFechaInicio`, TM1.`PromocionFechaFin`, TM1.`PromocionSegmentosJson`, TM1.`PromocionArte` FROM `Promocion` TM1 WHERE TM1.`PromocionID` = @PromocionID ORDER BY TM1.`PromocionID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C5", "SELECT `PromocionID` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C6", "INSERT INTO `Promocion`(`PromocionDescripcion`, `PromocionBase`, `PromocionArte`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionSegmentosJson`) VALUES(@PromocionDescripcion, @PromocionBase, @PromocionArte, @PromocionArte_GXI, @PromocionFechaInicio, @PromocionFechaFin, @PromocionSegmentosJson)", GxErrorMask.GX_NOMASK,prmBC000C6)
             ,new CursorDef("BC000C7", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C8", "UPDATE `Promocion` SET `PromocionDescripcion`=@PromocionDescripcion, `PromocionBase`=@PromocionBase, `PromocionFechaInicio`=@PromocionFechaInicio, `PromocionFechaFin`=@PromocionFechaFin, `PromocionSegmentosJson`=@PromocionSegmentosJson  WHERE `PromocionID` = @PromocionID", GxErrorMask.GX_NOMASK,prmBC000C8)
             ,new CursorDef("BC000C9", "UPDATE `Promocion` SET `PromocionArte`=@PromocionArte, `PromocionArte_GXI`=@PromocionArte_GXI  WHERE `PromocionID` = @PromocionID", GxErrorMask.GX_NOMASK,prmBC000C9)
             ,new CursorDef("BC000C10", "DELETE FROM `Promocion`  WHERE `PromocionID` = @PromocionID", GxErrorMask.GX_NOMASK,prmBC000C10)
             ,new CursorDef("BC000C11", "SELECT `FacturaID` FROM `Factura` WHERE `PromocionID` = @PromocionID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000C12", "SELECT `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionID` = @PromocionID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000C13", "SELECT `PromocionDistribuidorID` FROM `PromocionDistribuidor` WHERE `PromocionID` = @PromocionID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000C14", "SELECT TM1.`PromocionID`, TM1.`PromocionDescripcion`, TM1.`PromocionBase`, TM1.`PromocionArte_GXI`, TM1.`PromocionFechaInicio`, TM1.`PromocionFechaFin`, TM1.`PromocionSegmentosJson`, TM1.`PromocionArte` FROM `Promocion` TM1 WHERE TM1.`PromocionID` = @PromocionID ORDER BY TM1.`PromocionID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C14,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
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
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
                return;
       }
    }

 }

}
