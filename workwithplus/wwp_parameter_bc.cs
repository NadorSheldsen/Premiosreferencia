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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameter_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_parameter_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parameter_bc( IGxContext context )
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
         ReadRow0B11( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0B11( ) ;
         standaloneModal( ) ;
         AddRow0B11( ) ;
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
            E110B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z34WWPParameterKey = A34WWPParameterKey;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B11( ) ;
            }
            else
            {
               CheckExtendedTable0B11( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0B11( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0B11( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z36WWPParameterCategory = A36WWPParameterCategory;
            Z37WWPParameterDescription = A37WWPParameterDescription;
            Z38WWPParameterDisableDelete = A38WWPParameterDisableDelete;
            Z39WWPParameterValueTrimmed = A39WWPParameterValueTrimmed;
         }
         if ( GX_JID == -3 )
         {
            Z34WWPParameterKey = A34WWPParameterKey;
            Z36WWPParameterCategory = A36WWPParameterCategory;
            Z37WWPParameterDescription = A37WWPParameterDescription;
            Z35WWPParameterValue = A35WWPParameterValue;
            Z38WWPParameterDisableDelete = A38WWPParameterDisableDelete;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0B11( )
      {
         /* Using cursor BC000B4 */
         pr_default.execute(2, new Object[] {A34WWPParameterKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound11 = 1;
            A36WWPParameterCategory = BC000B4_A36WWPParameterCategory[0];
            A37WWPParameterDescription = BC000B4_A37WWPParameterDescription[0];
            A35WWPParameterValue = BC000B4_A35WWPParameterValue[0];
            A38WWPParameterDisableDelete = BC000B4_A38WWPParameterDisableDelete[0];
            ZM0B11( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0B11( ) ;
      }

      protected void OnLoadActions0B11( )
      {
         if ( StringUtil.Len( A35WWPParameterValue) <= 30 )
         {
            A39WWPParameterValueTrimmed = A35WWPParameterValue;
         }
         else
         {
            A39WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A35WWPParameterValue, 1, 27)) + "...";
         }
      }

      protected void CheckExtendedTable0B11( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A34WWPParameterKey)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_ParameterKey_Attribute_Description", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A35WWPParameterValue) <= 30 )
         {
            A39WWPParameterValueTrimmed = A35WWPParameterValue;
         }
         else
         {
            A39WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A35WWPParameterValue, 1, 27)) + "...";
         }
      }

      protected void CloseExtendedTableCursors0B11( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B11( )
      {
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {A34WWPParameterKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {A34WWPParameterKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B11( 3) ;
            RcdFound11 = 1;
            A34WWPParameterKey = BC000B3_A34WWPParameterKey[0];
            A36WWPParameterCategory = BC000B3_A36WWPParameterCategory[0];
            A37WWPParameterDescription = BC000B3_A37WWPParameterDescription[0];
            A35WWPParameterValue = BC000B3_A35WWPParameterValue[0];
            A38WWPParameterDisableDelete = BC000B3_A38WWPParameterDisableDelete[0];
            Z34WWPParameterKey = A34WWPParameterKey;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0B11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0B11( ) ;
            }
            Gx_mode = sMode11;
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0B11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode11;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B11( ) ;
         if ( RcdFound11 == 0 )
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
         CONFIRM_0B0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0B11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {A34WWPParameterKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Parameter"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z36WWPParameterCategory, BC000B2_A36WWPParameterCategory[0]) != 0 ) || ( StringUtil.StrCmp(Z37WWPParameterDescription, BC000B2_A37WWPParameterDescription[0]) != 0 ) || ( Z38WWPParameterDisableDelete != BC000B2_A38WWPParameterDisableDelete[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Parameter"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B11( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B11( 0) ;
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B6 */
                     pr_default.execute(4, new Object[] {A34WWPParameterKey, A36WWPParameterCategory, A37WWPParameterDescription, A35WWPParameterValue, A38WWPParameterDisableDelete});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
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
               Load0B11( ) ;
            }
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void Update0B11( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B7 */
                     pr_default.execute(5, new Object[] {A36WWPParameterCategory, A37WWPParameterDescription, A35WWPParameterValue, A38WWPParameterDisableDelete, A34WWPParameterKey});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Parameter"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B11( ) ;
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
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void DeferredUpdate0B11( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B11( ) ;
            AfterConfirm0B11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B8 */
                  pr_default.execute(6, new Object[] {A34WWPParameterKey});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B11( ) ;
         Gx_mode = sMode11;
      }

      protected void OnDeleteControls0B11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( StringUtil.Len( A35WWPParameterValue) <= 30 )
            {
               A39WWPParameterValueTrimmed = A35WWPParameterValue;
            }
            else
            {
               A39WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A35WWPParameterValue, 1, 27)) + "...";
            }
         }
      }

      protected void EndLevel0B11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B11( ) ;
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

      public void ScanKeyStart0B11( )
      {
         /* Scan By routine */
         /* Using cursor BC000B9 */
         pr_default.execute(7, new Object[] {A34WWPParameterKey});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound11 = 1;
            A34WWPParameterKey = BC000B9_A34WWPParameterKey[0];
            A36WWPParameterCategory = BC000B9_A36WWPParameterCategory[0];
            A37WWPParameterDescription = BC000B9_A37WWPParameterDescription[0];
            A35WWPParameterValue = BC000B9_A35WWPParameterValue[0];
            A38WWPParameterDisableDelete = BC000B9_A38WWPParameterDisableDelete[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B11( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound11 = 0;
         ScanKeyLoad0B11( ) ;
      }

      protected void ScanKeyLoad0B11( )
      {
         sMode11 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound11 = 1;
            A34WWPParameterKey = BC000B9_A34WWPParameterKey[0];
            A36WWPParameterCategory = BC000B9_A36WWPParameterCategory[0];
            A37WWPParameterDescription = BC000B9_A37WWPParameterDescription[0];
            A35WWPParameterValue = BC000B9_A35WWPParameterValue[0];
            A38WWPParameterDisableDelete = BC000B9_A38WWPParameterDisableDelete[0];
         }
         Gx_mode = sMode11;
      }

      protected void ScanKeyEnd0B11( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0B11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B11( )
      {
      }

      protected void send_integrity_lvl_hashes0B11( )
      {
      }

      protected void AddRow0B11( )
      {
         VarsToRow11( bcworkwithplus_WWP_Parameter) ;
      }

      protected void ReadRow0B11( )
      {
         RowToVars11( bcworkwithplus_WWP_Parameter, 1) ;
      }

      protected void InitializeNonKey0B11( )
      {
         A39WWPParameterValueTrimmed = "";
         A36WWPParameterCategory = "";
         A37WWPParameterDescription = "";
         A35WWPParameterValue = "";
         A38WWPParameterDisableDelete = false;
         Z36WWPParameterCategory = "";
         Z37WWPParameterDescription = "";
         Z38WWPParameterDisableDelete = false;
      }

      protected void InitAll0B11( )
      {
         A34WWPParameterKey = "";
         InitializeNonKey0B11( ) ;
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

      public void VarsToRow11( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj11 )
      {
         obj11.gxTpr_Mode = Gx_mode;
         obj11.gxTpr_Wwpparametervaluetrimmed = A39WWPParameterValueTrimmed;
         obj11.gxTpr_Wwpparametercategory = A36WWPParameterCategory;
         obj11.gxTpr_Wwpparameterdescription = A37WWPParameterDescription;
         obj11.gxTpr_Wwpparametervalue = A35WWPParameterValue;
         obj11.gxTpr_Wwpparameterdisabledelete = A38WWPParameterDisableDelete;
         obj11.gxTpr_Wwpparameterkey = A34WWPParameterKey;
         obj11.gxTpr_Wwpparameterkey_Z = Z34WWPParameterKey;
         obj11.gxTpr_Wwpparametercategory_Z = Z36WWPParameterCategory;
         obj11.gxTpr_Wwpparameterdescription_Z = Z37WWPParameterDescription;
         obj11.gxTpr_Wwpparametervaluetrimmed_Z = Z39WWPParameterValueTrimmed;
         obj11.gxTpr_Wwpparameterdisabledelete_Z = Z38WWPParameterDisableDelete;
         obj11.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow11( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj11 )
      {
         obj11.gxTpr_Wwpparameterkey = A34WWPParameterKey;
         return  ;
      }

      public void RowToVars11( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj11 ,
                               int forceLoad )
      {
         Gx_mode = obj11.gxTpr_Mode;
         A39WWPParameterValueTrimmed = obj11.gxTpr_Wwpparametervaluetrimmed;
         A36WWPParameterCategory = obj11.gxTpr_Wwpparametercategory;
         A37WWPParameterDescription = obj11.gxTpr_Wwpparameterdescription;
         A35WWPParameterValue = obj11.gxTpr_Wwpparametervalue;
         A38WWPParameterDisableDelete = obj11.gxTpr_Wwpparameterdisabledelete;
         A34WWPParameterKey = obj11.gxTpr_Wwpparameterkey;
         Z34WWPParameterKey = obj11.gxTpr_Wwpparameterkey_Z;
         Z36WWPParameterCategory = obj11.gxTpr_Wwpparametercategory_Z;
         Z37WWPParameterDescription = obj11.gxTpr_Wwpparameterdescription_Z;
         Z39WWPParameterValueTrimmed = obj11.gxTpr_Wwpparametervaluetrimmed_Z;
         Z38WWPParameterDisableDelete = obj11.gxTpr_Wwpparameterdisabledelete_Z;
         Gx_mode = obj11.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A34WWPParameterKey = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B11( ) ;
         ScanKeyStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z34WWPParameterKey = A34WWPParameterKey;
         }
         ZM0B11( -3) ;
         OnLoadActions0B11( ) ;
         AddRow0B11( ) ;
         ScanKeyEnd0B11( ) ;
         if ( RcdFound11 == 0 )
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
         RowToVars11( bcworkwithplus_WWP_Parameter, 0) ;
         ScanKeyStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z34WWPParameterKey = A34WWPParameterKey;
         }
         ZM0B11( -3) ;
         OnLoadActions0B11( ) ;
         AddRow0B11( ) ;
         ScanKeyEnd0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0B11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0B11( ) ;
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( StringUtil.StrCmp(A34WWPParameterKey, Z34WWPParameterKey) != 0 )
               {
                  A34WWPParameterKey = Z34WWPParameterKey;
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
                  Update0B11( ) ;
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
                  if ( StringUtil.StrCmp(A34WWPParameterKey, Z34WWPParameterKey) != 0 )
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
                        Insert0B11( ) ;
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
                        Insert0B11( ) ;
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
         RowToVars11( bcworkwithplus_WWP_Parameter, 1) ;
         SaveImpl( ) ;
         VarsToRow11( bcworkwithplus_WWP_Parameter) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars11( bcworkwithplus_WWP_Parameter, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B11( ) ;
         AfterTrn( ) ;
         VarsToRow11( bcworkwithplus_WWP_Parameter) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow11( bcworkwithplus_WWP_Parameter) ;
         }
         else
         {
            GeneXus.Programs.workwithplus.SdtWWP_Parameter auxBC = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A34WWPParameterKey);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcworkwithplus_WWP_Parameter);
               auxBC.Save();
               bcworkwithplus_WWP_Parameter.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars11( bcworkwithplus_WWP_Parameter, 1) ;
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
         RowToVars11( bcworkwithplus_WWP_Parameter, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B11( ) ;
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
               VarsToRow11( bcworkwithplus_WWP_Parameter) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow11( bcworkwithplus_WWP_Parameter) ;
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
         RowToVars11( bcworkwithplus_WWP_Parameter, 0) ;
         GetKey0B11( ) ;
         if ( RcdFound11 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A34WWPParameterKey, Z34WWPParameterKey) != 0 )
            {
               A34WWPParameterKey = Z34WWPParameterKey;
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
            if ( StringUtil.StrCmp(A34WWPParameterKey, Z34WWPParameterKey) != 0 )
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
         context.RollbackDataStores("workwithplus.wwp_parameter_bc",pr_default);
         VarsToRow11( bcworkwithplus_WWP_Parameter) ;
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
         Gx_mode = bcworkwithplus_WWP_Parameter.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcworkwithplus_WWP_Parameter.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcworkwithplus_WWP_Parameter )
         {
            bcworkwithplus_WWP_Parameter = (GeneXus.Programs.workwithplus.SdtWWP_Parameter)(sdt);
            if ( StringUtil.StrCmp(bcworkwithplus_WWP_Parameter.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_WWP_Parameter.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow11( bcworkwithplus_WWP_Parameter) ;
            }
            else
            {
               RowToVars11( bcworkwithplus_WWP_Parameter, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcworkwithplus_WWP_Parameter.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_WWP_Parameter.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars11( bcworkwithplus_WWP_Parameter, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Parameter WWP_Parameter_BC
      {
         get {
            return bcworkwithplus_WWP_Parameter ;
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
         Z34WWPParameterKey = "";
         A34WWPParameterKey = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z36WWPParameterCategory = "";
         A36WWPParameterCategory = "";
         Z37WWPParameterDescription = "";
         A37WWPParameterDescription = "";
         Z39WWPParameterValueTrimmed = "";
         A39WWPParameterValueTrimmed = "";
         Z35WWPParameterValue = "";
         A35WWPParameterValue = "";
         BC000B4_A34WWPParameterKey = new string[] {""} ;
         BC000B4_A36WWPParameterCategory = new string[] {""} ;
         BC000B4_A37WWPParameterDescription = new string[] {""} ;
         BC000B4_A35WWPParameterValue = new string[] {""} ;
         BC000B4_A38WWPParameterDisableDelete = new bool[] {false} ;
         BC000B5_A34WWPParameterKey = new string[] {""} ;
         BC000B3_A34WWPParameterKey = new string[] {""} ;
         BC000B3_A36WWPParameterCategory = new string[] {""} ;
         BC000B3_A37WWPParameterDescription = new string[] {""} ;
         BC000B3_A35WWPParameterValue = new string[] {""} ;
         BC000B3_A38WWPParameterDisableDelete = new bool[] {false} ;
         sMode11 = "";
         BC000B2_A34WWPParameterKey = new string[] {""} ;
         BC000B2_A36WWPParameterCategory = new string[] {""} ;
         BC000B2_A37WWPParameterDescription = new string[] {""} ;
         BC000B2_A35WWPParameterValue = new string[] {""} ;
         BC000B2_A38WWPParameterDisableDelete = new bool[] {false} ;
         BC000B9_A34WWPParameterKey = new string[] {""} ;
         BC000B9_A36WWPParameterCategory = new string[] {""} ;
         BC000B9_A37WWPParameterDescription = new string[] {""} ;
         BC000B9_A35WWPParameterValue = new string[] {""} ;
         BC000B9_A38WWPParameterDisableDelete = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameter_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A34WWPParameterKey, BC000B2_A36WWPParameterCategory, BC000B2_A37WWPParameterDescription, BC000B2_A35WWPParameterValue, BC000B2_A38WWPParameterDisableDelete
               }
               , new Object[] {
               BC000B3_A34WWPParameterKey, BC000B3_A36WWPParameterCategory, BC000B3_A37WWPParameterDescription, BC000B3_A35WWPParameterValue, BC000B3_A38WWPParameterDisableDelete
               }
               , new Object[] {
               BC000B4_A34WWPParameterKey, BC000B4_A36WWPParameterCategory, BC000B4_A37WWPParameterDescription, BC000B4_A35WWPParameterValue, BC000B4_A38WWPParameterDisableDelete
               }
               , new Object[] {
               BC000B5_A34WWPParameterKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B9_A34WWPParameterKey, BC000B9_A36WWPParameterCategory, BC000B9_A37WWPParameterDescription, BC000B9_A35WWPParameterValue, BC000B9_A38WWPParameterDisableDelete
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120B2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound11 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode11 ;
      private bool returnInSub ;
      private bool Z38WWPParameterDisableDelete ;
      private bool A38WWPParameterDisableDelete ;
      private string Z35WWPParameterValue ;
      private string A35WWPParameterValue ;
      private string Z34WWPParameterKey ;
      private string A34WWPParameterKey ;
      private string Z36WWPParameterCategory ;
      private string A36WWPParameterCategory ;
      private string Z37WWPParameterDescription ;
      private string A37WWPParameterDescription ;
      private string Z39WWPParameterValueTrimmed ;
      private string A39WWPParameterValueTrimmed ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] BC000B4_A34WWPParameterKey ;
      private string[] BC000B4_A36WWPParameterCategory ;
      private string[] BC000B4_A37WWPParameterDescription ;
      private string[] BC000B4_A35WWPParameterValue ;
      private bool[] BC000B4_A38WWPParameterDisableDelete ;
      private string[] BC000B5_A34WWPParameterKey ;
      private string[] BC000B3_A34WWPParameterKey ;
      private string[] BC000B3_A36WWPParameterCategory ;
      private string[] BC000B3_A37WWPParameterDescription ;
      private string[] BC000B3_A35WWPParameterValue ;
      private bool[] BC000B3_A38WWPParameterDisableDelete ;
      private string[] BC000B2_A34WWPParameterKey ;
      private string[] BC000B2_A36WWPParameterCategory ;
      private string[] BC000B2_A37WWPParameterDescription ;
      private string[] BC000B2_A35WWPParameterValue ;
      private bool[] BC000B2_A38WWPParameterDisableDelete ;
      private string[] BC000B9_A34WWPParameterKey ;
      private string[] BC000B9_A36WWPParameterCategory ;
      private string[] BC000B9_A37WWPParameterDescription ;
      private string[] BC000B9_A35WWPParameterValue ;
      private bool[] BC000B9_A38WWPParameterDisableDelete ;
      private GeneXus.Programs.workwithplus.SdtWWP_Parameter bcworkwithplus_WWP_Parameter ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_parameter_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC000B2;
          prmBC000B2 = new Object[] {
          new ParDef("@WWPParameterKey",GXType.Char,300,0)
          };
          Object[] prmBC000B3;
          prmBC000B3 = new Object[] {
          new ParDef("@WWPParameterKey",GXType.Char,300,0)
          };
          Object[] prmBC000B4;
          prmBC000B4 = new Object[] {
          new ParDef("@WWPParameterKey",GXType.Char,300,0)
          };
          Object[] prmBC000B5;
          prmBC000B5 = new Object[] {
          new ParDef("@WWPParameterKey",GXType.Char,300,0)
          };
          Object[] prmBC000B6;
          prmBC000B6 = new Object[] {
          new ParDef("@WWPParameterKey",GXType.Char,300,0) ,
          new ParDef("@WWPParameterCategory",GXType.Char,200,0) ,
          new ParDef("@WWPParameterDescription",GXType.Char,200,0) ,
          new ParDef("@WWPParameterValue",GXType.Char,2097152,0) ,
          new ParDef("@WWPParameterDisableDelete",GXType.Byte,4,0)
          };
          Object[] prmBC000B7;
          prmBC000B7 = new Object[] {
          new ParDef("@WWPParameterCategory",GXType.Char,200,0) ,
          new ParDef("@WWPParameterDescription",GXType.Char,200,0) ,
          new ParDef("@WWPParameterValue",GXType.Char,2097152,0) ,
          new ParDef("@WWPParameterDisableDelete",GXType.Byte,4,0) ,
          new ParDef("@WWPParameterKey",GXType.Char,300,0)
          };
          Object[] prmBC000B8;
          prmBC000B8 = new Object[] {
          new ParDef("@WWPParameterKey",GXType.Char,300,0)
          };
          Object[] prmBC000B9;
          prmBC000B9 = new Object[] {
          new ParDef("@WWPParameterKey",GXType.Char,300,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000B2", "SELECT `WWPParameterKey`, `WWPParameterCategory`, `WWPParameterDescription`, `WWPParameterValue`, `WWPParameterDisableDelete` FROM `WWP_Parameter` WHERE `WWPParameterKey` = @WWPParameterKey  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B3", "SELECT `WWPParameterKey`, `WWPParameterCategory`, `WWPParameterDescription`, `WWPParameterValue`, `WWPParameterDisableDelete` FROM `WWP_Parameter` WHERE `WWPParameterKey` = @WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B4", "SELECT TM1.`WWPParameterKey`, TM1.`WWPParameterCategory`, TM1.`WWPParameterDescription`, TM1.`WWPParameterValue`, TM1.`WWPParameterDisableDelete` FROM `WWP_Parameter` TM1 WHERE TM1.`WWPParameterKey` = @WWPParameterKey ORDER BY TM1.`WWPParameterKey` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B5", "SELECT `WWPParameterKey` FROM `WWP_Parameter` WHERE `WWPParameterKey` = @WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B6", "INSERT INTO `WWP_Parameter`(`WWPParameterKey`, `WWPParameterCategory`, `WWPParameterDescription`, `WWPParameterValue`, `WWPParameterDisableDelete`) VALUES(@WWPParameterKey, @WWPParameterCategory, @WWPParameterDescription, @WWPParameterValue, @WWPParameterDisableDelete)", GxErrorMask.GX_NOMASK,prmBC000B6)
             ,new CursorDef("BC000B7", "UPDATE `WWP_Parameter` SET `WWPParameterCategory`=@WWPParameterCategory, `WWPParameterDescription`=@WWPParameterDescription, `WWPParameterValue`=@WWPParameterValue, `WWPParameterDisableDelete`=@WWPParameterDisableDelete  WHERE `WWPParameterKey` = @WWPParameterKey", GxErrorMask.GX_NOMASK,prmBC000B7)
             ,new CursorDef("BC000B8", "DELETE FROM `WWP_Parameter`  WHERE `WWPParameterKey` = @WWPParameterKey", GxErrorMask.GX_NOMASK,prmBC000B8)
             ,new CursorDef("BC000B9", "SELECT TM1.`WWPParameterKey`, TM1.`WWPParameterCategory`, TM1.`WWPParameterDescription`, TM1.`WWPParameterValue`, TM1.`WWPParameterDisableDelete` FROM `WWP_Parameter` TM1 WHERE TM1.`WWPParameterKey` = @WWPParameterKey ORDER BY TM1.`WWPParameterKey` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B9,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                return;
       }
    }

 }

}
