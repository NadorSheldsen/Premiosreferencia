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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trndirectivawwexport : GXProcedure
   {
      public trndirectivawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trndirectivawwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV12ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13CellRow = 1;
         AV14FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S201 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S161 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S191 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV15Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV11Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV11Filename = GXt_char1 + "TrnDirectivaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
         AV10ExcelDocument.Open(AV11Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TRNDIRECTIVATITLE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV52TrnDirectivaTitle1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TrnDirectivaTitle1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV52TrnDirectivaTitle1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TRNDIRECTIVAVALUE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20TrnDirectivaValue1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TrnDirectivaValue1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV20TrnDirectivaValue1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TRNDIRECTIVATITLE") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV53TrnDirectivaTitle2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53TrnDirectivaTitle2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV53TrnDirectivaTitle2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TRNDIRECTIVAVALUE") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24TrnDirectivaValue2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TrnDirectivaValue2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV24TrnDirectivaValue2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TRNDIRECTIVATITLE") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV54TrnDirectivaTitle3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54TrnDirectivaTitle3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV54TrnDirectivaTitle3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TRNDIRECTIVAVALUE") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28TrnDirectivaValue3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TrnDirectivaValue3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV28TrnDirectivaValue3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFTrnDirectivaTitle_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  context.GetMessage( "Directiva", "")) ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV46TFTrnDirectivaTitle_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV46TFTrnDirectivaTitle_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFTrnDirectivaTitle)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  context.GetMessage( "Directiva", "")) ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV45TFTrnDirectivaTitle, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTrnDirectivaValue_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  context.GetMessage( "Valor", "")) ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTrnDirectivaValue_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV48TFTrnDirectivaValue_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFTrnDirectivaValue)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  context.GetMessage( "Valor", "")) ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV47TFTrnDirectivaValue, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTrnDirectivaDescripcion_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  context.GetMessage( "Descripción", "")) ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTrnDirectivaDescripcion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : StringUtil.Substring( AV51TFTrnDirectivaDescripcion_Sel, 1, 1000)), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTrnDirectivaDescripcion)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  context.GetMessage( "Descripción", "")) ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV50TFTrnDirectivaDescripcion, 1, 1000), out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV42VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV30Session.Get("TrnDirectivaWWColumnsSelector"), "") != 0 )
         {
            AV37ColumnsSelectorXML = AV30Session.Get("TrnDirectivaWWColumnsSelector");
            AV34ColumnsSelector.FromXml(AV37ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV34ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV34ColumnsSelector.gxTpr_Columns.Count )
         {
            AV36ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV34ColumnsSelector.gxTpr_Columns.Item(AV55GXV1));
            if ( AV36ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV42VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelector_Column.gxTpr_Displayname)) ? AV36ColumnsSelector_Column.gxTpr_Columnname : AV36ColumnsSelector_Column.gxTpr_Displayname), "");
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV42VisibleColumnCount), 1, 1).Bold = 1;
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV42VisibleColumnCount), 1, 1).Color = 11;
               AV42VisibleColumnCount = (long)(AV42VisibleColumnCount+1);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV57Trndirectivawwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV58Trndirectivawwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV59Trndirectivawwds_3_trndirectivatitle1 = AV52TrnDirectivaTitle1;
         AV60Trndirectivawwds_4_trndirectivavalue1 = AV20TrnDirectivaValue1;
         AV61Trndirectivawwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV62Trndirectivawwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV63Trndirectivawwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV64Trndirectivawwds_8_trndirectivatitle2 = AV53TrnDirectivaTitle2;
         AV65Trndirectivawwds_9_trndirectivavalue2 = AV24TrnDirectivaValue2;
         AV66Trndirectivawwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Trndirectivawwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Trndirectivawwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Trndirectivawwds_13_trndirectivatitle3 = AV54TrnDirectivaTitle3;
         AV70Trndirectivawwds_14_trndirectivavalue3 = AV28TrnDirectivaValue3;
         AV71Trndirectivawwds_15_tftrndirectivatitle = AV45TFTrnDirectivaTitle;
         AV72Trndirectivawwds_16_tftrndirectivatitle_sel = AV46TFTrnDirectivaTitle_Sel;
         AV73Trndirectivawwds_17_tftrndirectivavalue = AV47TFTrnDirectivaValue;
         AV74Trndirectivawwds_18_tftrndirectivavalue_sel = AV48TFTrnDirectivaValue_Sel;
         AV75Trndirectivawwds_19_tftrndirectivadescripcion = AV50TFTrnDirectivaDescripcion;
         AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel = AV51TFTrnDirectivaDescripcion_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Trndirectivawwds_1_dynamicfiltersselector1 ,
                                              AV58Trndirectivawwds_2_dynamicfiltersoperator1 ,
                                              AV59Trndirectivawwds_3_trndirectivatitle1 ,
                                              AV60Trndirectivawwds_4_trndirectivavalue1 ,
                                              AV61Trndirectivawwds_5_dynamicfiltersenabled2 ,
                                              AV62Trndirectivawwds_6_dynamicfiltersselector2 ,
                                              AV63Trndirectivawwds_7_dynamicfiltersoperator2 ,
                                              AV64Trndirectivawwds_8_trndirectivatitle2 ,
                                              AV65Trndirectivawwds_9_trndirectivavalue2 ,
                                              AV66Trndirectivawwds_10_dynamicfiltersenabled3 ,
                                              AV67Trndirectivawwds_11_dynamicfiltersselector3 ,
                                              AV68Trndirectivawwds_12_dynamicfiltersoperator3 ,
                                              AV69Trndirectivawwds_13_trndirectivatitle3 ,
                                              AV70Trndirectivawwds_14_trndirectivavalue3 ,
                                              AV72Trndirectivawwds_16_tftrndirectivatitle_sel ,
                                              AV71Trndirectivawwds_15_tftrndirectivatitle ,
                                              AV74Trndirectivawwds_18_tftrndirectivavalue_sel ,
                                              AV73Trndirectivawwds_17_tftrndirectivavalue ,
                                              AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel ,
                                              AV75Trndirectivawwds_19_tftrndirectivadescripcion ,
                                              A89TrnDirectivaTitle ,
                                              A90TrnDirectivaValue ,
                                              A91TrnDirectivaDescripcion ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Trndirectivawwds_3_trndirectivatitle1 = StringUtil.Concat( StringUtil.RTrim( AV59Trndirectivawwds_3_trndirectivatitle1), "%", "");
         lV59Trndirectivawwds_3_trndirectivatitle1 = StringUtil.Concat( StringUtil.RTrim( AV59Trndirectivawwds_3_trndirectivatitle1), "%", "");
         lV60Trndirectivawwds_4_trndirectivavalue1 = StringUtil.Concat( StringUtil.RTrim( AV60Trndirectivawwds_4_trndirectivavalue1), "%", "");
         lV60Trndirectivawwds_4_trndirectivavalue1 = StringUtil.Concat( StringUtil.RTrim( AV60Trndirectivawwds_4_trndirectivavalue1), "%", "");
         lV64Trndirectivawwds_8_trndirectivatitle2 = StringUtil.Concat( StringUtil.RTrim( AV64Trndirectivawwds_8_trndirectivatitle2), "%", "");
         lV64Trndirectivawwds_8_trndirectivatitle2 = StringUtil.Concat( StringUtil.RTrim( AV64Trndirectivawwds_8_trndirectivatitle2), "%", "");
         lV65Trndirectivawwds_9_trndirectivavalue2 = StringUtil.Concat( StringUtil.RTrim( AV65Trndirectivawwds_9_trndirectivavalue2), "%", "");
         lV65Trndirectivawwds_9_trndirectivavalue2 = StringUtil.Concat( StringUtil.RTrim( AV65Trndirectivawwds_9_trndirectivavalue2), "%", "");
         lV69Trndirectivawwds_13_trndirectivatitle3 = StringUtil.Concat( StringUtil.RTrim( AV69Trndirectivawwds_13_trndirectivatitle3), "%", "");
         lV69Trndirectivawwds_13_trndirectivatitle3 = StringUtil.Concat( StringUtil.RTrim( AV69Trndirectivawwds_13_trndirectivatitle3), "%", "");
         lV70Trndirectivawwds_14_trndirectivavalue3 = StringUtil.Concat( StringUtil.RTrim( AV70Trndirectivawwds_14_trndirectivavalue3), "%", "");
         lV70Trndirectivawwds_14_trndirectivavalue3 = StringUtil.Concat( StringUtil.RTrim( AV70Trndirectivawwds_14_trndirectivavalue3), "%", "");
         lV71Trndirectivawwds_15_tftrndirectivatitle = StringUtil.Concat( StringUtil.RTrim( AV71Trndirectivawwds_15_tftrndirectivatitle), "%", "");
         lV73Trndirectivawwds_17_tftrndirectivavalue = StringUtil.Concat( StringUtil.RTrim( AV73Trndirectivawwds_17_tftrndirectivavalue), "%", "");
         lV75Trndirectivawwds_19_tftrndirectivadescripcion = StringUtil.Concat( StringUtil.RTrim( AV75Trndirectivawwds_19_tftrndirectivadescripcion), "%", "");
         /* Using cursor P004F2 */
         pr_default.execute(0, new Object[] {lV59Trndirectivawwds_3_trndirectivatitle1, lV59Trndirectivawwds_3_trndirectivatitle1, lV60Trndirectivawwds_4_trndirectivavalue1, lV60Trndirectivawwds_4_trndirectivavalue1, lV64Trndirectivawwds_8_trndirectivatitle2, lV64Trndirectivawwds_8_trndirectivatitle2, lV65Trndirectivawwds_9_trndirectivavalue2, lV65Trndirectivawwds_9_trndirectivavalue2, lV69Trndirectivawwds_13_trndirectivatitle3, lV69Trndirectivawwds_13_trndirectivatitle3, lV70Trndirectivawwds_14_trndirectivavalue3, lV70Trndirectivawwds_14_trndirectivavalue3, lV71Trndirectivawwds_15_tftrndirectivatitle, AV72Trndirectivawwds_16_tftrndirectivatitle_sel, lV73Trndirectivawwds_17_tftrndirectivavalue, AV74Trndirectivawwds_18_tftrndirectivavalue_sel, lV75Trndirectivawwds_19_tftrndirectivadescripcion, AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A91TrnDirectivaDescripcion = P004F2_A91TrnDirectivaDescripcion[0];
            A90TrnDirectivaValue = P004F2_A90TrnDirectivaValue[0];
            A89TrnDirectivaTitle = P004F2_A89TrnDirectivaTitle[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV42VisibleColumnCount = 0;
            AV77GXV2 = 1;
            while ( AV77GXV2 <= AV34ColumnsSelector.gxTpr_Columns.Count )
            {
               AV36ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV34ColumnsSelector.gxTpr_Columns.Item(AV77GXV2));
               if ( AV36ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV36ColumnsSelector_Column.gxTpr_Columnname, "TrnDirectivaTitle") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A89TrnDirectivaTitle, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV42VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV36ColumnsSelector_Column.gxTpr_Columnname, "TrnDirectivaValue") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A90TrnDirectivaValue, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV42VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV36ColumnsSelector_Column.gxTpr_Columnname, "TrnDirectivaDescripcion") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  StringUtil.Substring( A91TrnDirectivaDescripcion, 1, 1000), out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV42VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV42VisibleColumnCount = (long)(AV42VisibleColumnCount+1);
               }
               AV77GXV2 = (int)(AV77GXV2+1);
            }
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S182 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S191( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV10ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Close();
         AV30Session.Set("WWPExportFilePath", AV11Filename);
         AV30Session.Set("WWPExportFileName", "TrnDirectivaWWExport.xlsx");
         AV11Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV10ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV12ErrorMessage = AV10ExcelDocument.ErrDescription;
            AV10ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S151( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV34ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV34ColumnsSelector,  "TrnDirectivaTitle",  "",  "Directiva",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV34ColumnsSelector,  "TrnDirectivaValue",  "",  "Valor",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV34ColumnsSelector,  "TrnDirectivaDescripcion",  "",  "Descripción",  true,  "") ;
         GXt_char1 = AV38UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "TrnDirectivaWWColumnsSelector", out  GXt_char1) ;
         AV38UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38UserCustomValue)) ) )
         {
            AV35ColumnsSelectorAux.FromXml(AV38UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV35ColumnsSelectorAux, ref  AV34ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("TrnDirectivaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "TrnDirectivaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("TrnDirectivaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV78GXV3 = 1;
         while ( AV78GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV78GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVATITLE") == 0 )
            {
               AV45TFTrnDirectivaTitle = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVATITLE_SEL") == 0 )
            {
               AV46TFTrnDirectivaTitle_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVAVALUE") == 0 )
            {
               AV47TFTrnDirectivaValue = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVAVALUE_SEL") == 0 )
            {
               AV48TFTrnDirectivaValue_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVADESCRIPCION") == 0 )
            {
               AV50TFTrnDirectivaDescripcion = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVADESCRIPCION_SEL") == 0 )
            {
               AV51TFTrnDirectivaDescripcion_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV78GXV3 = (int)(AV78GXV3+1);
         }
      }

      protected void S172( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Filename = "";
         AV12ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV32GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV29GridStateDynamicFilter = new WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV52TrnDirectivaTitle1 = "";
         AV20TrnDirectivaValue1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV53TrnDirectivaTitle2 = "";
         AV24TrnDirectivaValue2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV54TrnDirectivaTitle3 = "";
         AV28TrnDirectivaValue3 = "";
         AV46TFTrnDirectivaTitle_Sel = "";
         AV45TFTrnDirectivaTitle = "";
         AV48TFTrnDirectivaValue_Sel = "";
         AV47TFTrnDirectivaValue = "";
         AV51TFTrnDirectivaDescripcion_Sel = "";
         AV50TFTrnDirectivaDescripcion = "";
         AV30Session = context.GetSession();
         AV37ColumnsSelectorXML = "";
         AV34ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV36ColumnsSelector_Column = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column(context);
         AV57Trndirectivawwds_1_dynamicfiltersselector1 = "";
         AV59Trndirectivawwds_3_trndirectivatitle1 = "";
         AV60Trndirectivawwds_4_trndirectivavalue1 = "";
         AV62Trndirectivawwds_6_dynamicfiltersselector2 = "";
         AV64Trndirectivawwds_8_trndirectivatitle2 = "";
         AV65Trndirectivawwds_9_trndirectivavalue2 = "";
         AV67Trndirectivawwds_11_dynamicfiltersselector3 = "";
         AV69Trndirectivawwds_13_trndirectivatitle3 = "";
         AV70Trndirectivawwds_14_trndirectivavalue3 = "";
         AV71Trndirectivawwds_15_tftrndirectivatitle = "";
         AV72Trndirectivawwds_16_tftrndirectivatitle_sel = "";
         AV73Trndirectivawwds_17_tftrndirectivavalue = "";
         AV74Trndirectivawwds_18_tftrndirectivavalue_sel = "";
         AV75Trndirectivawwds_19_tftrndirectivadescripcion = "";
         AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel = "";
         lV59Trndirectivawwds_3_trndirectivatitle1 = "";
         lV60Trndirectivawwds_4_trndirectivavalue1 = "";
         lV64Trndirectivawwds_8_trndirectivatitle2 = "";
         lV65Trndirectivawwds_9_trndirectivavalue2 = "";
         lV69Trndirectivawwds_13_trndirectivatitle3 = "";
         lV70Trndirectivawwds_14_trndirectivavalue3 = "";
         lV71Trndirectivawwds_15_tftrndirectivatitle = "";
         lV73Trndirectivawwds_17_tftrndirectivavalue = "";
         lV75Trndirectivawwds_19_tftrndirectivadescripcion = "";
         A89TrnDirectivaTitle = "";
         A90TrnDirectivaValue = "";
         A91TrnDirectivaDescripcion = "";
         P004F2_A91TrnDirectivaDescripcion = new string[] {""} ;
         P004F2_A90TrnDirectivaValue = new string[] {""} ;
         P004F2_A89TrnDirectivaTitle = new string[] {""} ;
         AV38UserCustomValue = "";
         GXt_char1 = "";
         AV35ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV33GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trndirectivawwexport__default(),
            new Object[][] {
                new Object[] {
               P004F2_A91TrnDirectivaDescripcion, P004F2_A90TrnDirectivaValue, P004F2_A89TrnDirectivaTitle
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV58Trndirectivawwds_2_dynamicfiltersoperator1 ;
      private short AV63Trndirectivawwds_7_dynamicfiltersoperator2 ;
      private short AV68Trndirectivawwds_12_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV55GXV1 ;
      private int AV77GXV2 ;
      private int AV78GXV3 ;
      private long AV42VisibleColumnCount ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV61Trndirectivawwds_5_dynamicfiltersenabled2 ;
      private bool AV66Trndirectivawwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV37ColumnsSelectorXML ;
      private string AV75Trndirectivawwds_19_tftrndirectivadescripcion ;
      private string AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel ;
      private string lV75Trndirectivawwds_19_tftrndirectivadescripcion ;
      private string A91TrnDirectivaDescripcion ;
      private string AV38UserCustomValue ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV52TrnDirectivaTitle1 ;
      private string AV20TrnDirectivaValue1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV53TrnDirectivaTitle2 ;
      private string AV24TrnDirectivaValue2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV54TrnDirectivaTitle3 ;
      private string AV28TrnDirectivaValue3 ;
      private string AV46TFTrnDirectivaTitle_Sel ;
      private string AV45TFTrnDirectivaTitle ;
      private string AV48TFTrnDirectivaValue_Sel ;
      private string AV47TFTrnDirectivaValue ;
      private string AV51TFTrnDirectivaDescripcion_Sel ;
      private string AV50TFTrnDirectivaDescripcion ;
      private string AV57Trndirectivawwds_1_dynamicfiltersselector1 ;
      private string AV59Trndirectivawwds_3_trndirectivatitle1 ;
      private string AV60Trndirectivawwds_4_trndirectivavalue1 ;
      private string AV62Trndirectivawwds_6_dynamicfiltersselector2 ;
      private string AV64Trndirectivawwds_8_trndirectivatitle2 ;
      private string AV65Trndirectivawwds_9_trndirectivavalue2 ;
      private string AV67Trndirectivawwds_11_dynamicfiltersselector3 ;
      private string AV69Trndirectivawwds_13_trndirectivatitle3 ;
      private string AV70Trndirectivawwds_14_trndirectivavalue3 ;
      private string AV71Trndirectivawwds_15_tftrndirectivatitle ;
      private string AV72Trndirectivawwds_16_tftrndirectivatitle_sel ;
      private string AV73Trndirectivawwds_17_tftrndirectivavalue ;
      private string AV74Trndirectivawwds_18_tftrndirectivavalue_sel ;
      private string lV59Trndirectivawwds_3_trndirectivatitle1 ;
      private string lV60Trndirectivawwds_4_trndirectivavalue1 ;
      private string lV64Trndirectivawwds_8_trndirectivatitle2 ;
      private string lV65Trndirectivawwds_9_trndirectivavalue2 ;
      private string lV69Trndirectivawwds_13_trndirectivatitle3 ;
      private string lV70Trndirectivawwds_14_trndirectivavalue3 ;
      private string lV71Trndirectivawwds_15_tftrndirectivatitle ;
      private string lV73Trndirectivawwds_17_tftrndirectivavalue ;
      private string A89TrnDirectivaTitle ;
      private string A90TrnDirectivaValue ;
      private IGxSession AV30Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV32GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV34ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column AV36ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P004F2_A91TrnDirectivaDescripcion ;
      private string[] P004F2_A90TrnDirectivaValue ;
      private string[] P004F2_A89TrnDirectivaTitle ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV35ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class trndirectivawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004F2( IGxContext context ,
                                             string AV57Trndirectivawwds_1_dynamicfiltersselector1 ,
                                             short AV58Trndirectivawwds_2_dynamicfiltersoperator1 ,
                                             string AV59Trndirectivawwds_3_trndirectivatitle1 ,
                                             string AV60Trndirectivawwds_4_trndirectivavalue1 ,
                                             bool AV61Trndirectivawwds_5_dynamicfiltersenabled2 ,
                                             string AV62Trndirectivawwds_6_dynamicfiltersselector2 ,
                                             short AV63Trndirectivawwds_7_dynamicfiltersoperator2 ,
                                             string AV64Trndirectivawwds_8_trndirectivatitle2 ,
                                             string AV65Trndirectivawwds_9_trndirectivavalue2 ,
                                             bool AV66Trndirectivawwds_10_dynamicfiltersenabled3 ,
                                             string AV67Trndirectivawwds_11_dynamicfiltersselector3 ,
                                             short AV68Trndirectivawwds_12_dynamicfiltersoperator3 ,
                                             string AV69Trndirectivawwds_13_trndirectivatitle3 ,
                                             string AV70Trndirectivawwds_14_trndirectivavalue3 ,
                                             string AV72Trndirectivawwds_16_tftrndirectivatitle_sel ,
                                             string AV71Trndirectivawwds_15_tftrndirectivatitle ,
                                             string AV74Trndirectivawwds_18_tftrndirectivavalue_sel ,
                                             string AV73Trndirectivawwds_17_tftrndirectivavalue ,
                                             string AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel ,
                                             string AV75Trndirectivawwds_19_tftrndirectivadescripcion ,
                                             string A89TrnDirectivaTitle ,
                                             string A90TrnDirectivaValue ,
                                             string A91TrnDirectivaDescripcion ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT `TrnDirectivaDescripcion`, `TrnDirectivaValue`, `TrnDirectivaTitle` FROM `TrnDirectiva`";
         if ( ( StringUtil.StrCmp(AV57Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV58Trndirectivawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trndirectivawwds_3_trndirectivatitle1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV59Trndirectivawwds_3_trndirectivatitle1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV58Trndirectivawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trndirectivawwds_3_trndirectivatitle1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV59Trndirectivawwds_3_trndirectivatitle1))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV58Trndirectivawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trndirectivawwds_4_trndirectivavalue1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV60Trndirectivawwds_4_trndirectivavalue1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV58Trndirectivawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trndirectivawwds_4_trndirectivavalue1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV60Trndirectivawwds_4_trndirectivavalue1))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV61Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV63Trndirectivawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trndirectivawwds_8_trndirectivatitle2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV64Trndirectivawwds_8_trndirectivatitle2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV61Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV63Trndirectivawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trndirectivawwds_8_trndirectivatitle2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV64Trndirectivawwds_8_trndirectivatitle2))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV61Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV63Trndirectivawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trndirectivawwds_9_trndirectivavalue2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV65Trndirectivawwds_9_trndirectivavalue2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV61Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV63Trndirectivawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trndirectivawwds_9_trndirectivavalue2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV65Trndirectivawwds_9_trndirectivavalue2))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV66Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV68Trndirectivawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trndirectivawwds_13_trndirectivatitle3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV69Trndirectivawwds_13_trndirectivatitle3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV66Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV68Trndirectivawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trndirectivawwds_13_trndirectivatitle3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV69Trndirectivawwds_13_trndirectivatitle3))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV66Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV68Trndirectivawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trndirectivawwds_14_trndirectivavalue3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV70Trndirectivawwds_14_trndirectivavalue3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV66Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV68Trndirectivawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trndirectivawwds_14_trndirectivavalue3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV70Trndirectivawwds_14_trndirectivavalue3))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trndirectivawwds_16_tftrndirectivatitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trndirectivawwds_15_tftrndirectivatitle)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV71Trndirectivawwds_15_tftrndirectivatitle)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trndirectivawwds_16_tftrndirectivatitle_sel)) && ! ( StringUtil.StrCmp(AV72Trndirectivawwds_16_tftrndirectivatitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` = @AV72Trndirectivawwds_16_tftrndirectivatitle_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trndirectivawwds_16_tftrndirectivatitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaTitle`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trndirectivawwds_18_tftrndirectivavalue_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trndirectivawwds_17_tftrndirectivavalue)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV73Trndirectivawwds_17_tftrndirectivavalue)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trndirectivawwds_18_tftrndirectivavalue_sel)) && ! ( StringUtil.StrCmp(AV74Trndirectivawwds_18_tftrndirectivavalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` = @AV74Trndirectivawwds_18_tftrndirectivavalue_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trndirectivawwds_18_tftrndirectivavalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaValue`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trndirectivawwds_19_tftrndirectivadescripcion)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaDescripcion` like @lV75Trndirectivawwds_19_tftrndirectivadescripcion)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel)) && ! ( StringUtil.StrCmp(AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaDescripcion` = @AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY `TrnDirectivaTitle`";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `TrnDirectivaTitle` DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY `TrnDirectivaValue`";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `TrnDirectivaValue` DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY `TrnDirectivaDescripcion`";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `TrnDirectivaDescripcion` DESC";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004F2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004F2;
          prmP004F2 = new Object[] {
          new ParDef("@lV59Trndirectivawwds_3_trndirectivatitle1",GXType.Char,100,0) ,
          new ParDef("@lV59Trndirectivawwds_3_trndirectivatitle1",GXType.Char,100,0) ,
          new ParDef("@lV60Trndirectivawwds_4_trndirectivavalue1",GXType.Char,100,0) ,
          new ParDef("@lV60Trndirectivawwds_4_trndirectivavalue1",GXType.Char,100,0) ,
          new ParDef("@lV64Trndirectivawwds_8_trndirectivatitle2",GXType.Char,100,0) ,
          new ParDef("@lV64Trndirectivawwds_8_trndirectivatitle2",GXType.Char,100,0) ,
          new ParDef("@lV65Trndirectivawwds_9_trndirectivavalue2",GXType.Char,100,0) ,
          new ParDef("@lV65Trndirectivawwds_9_trndirectivavalue2",GXType.Char,100,0) ,
          new ParDef("@lV69Trndirectivawwds_13_trndirectivatitle3",GXType.Char,100,0) ,
          new ParDef("@lV69Trndirectivawwds_13_trndirectivatitle3",GXType.Char,100,0) ,
          new ParDef("@lV70Trndirectivawwds_14_trndirectivavalue3",GXType.Char,100,0) ,
          new ParDef("@lV70Trndirectivawwds_14_trndirectivavalue3",GXType.Char,100,0) ,
          new ParDef("@lV71Trndirectivawwds_15_tftrndirectivatitle",GXType.Char,100,0) ,
          new ParDef("@AV72Trndirectivawwds_16_tftrndirectivatitle_sel",GXType.Char,100,0) ,
          new ParDef("@lV73Trndirectivawwds_17_tftrndirectivavalue",GXType.Char,100,0) ,
          new ParDef("@AV74Trndirectivawwds_18_tftrndirectivavalue_sel",GXType.Char,100,0) ,
          new ParDef("@lV75Trndirectivawwds_19_tftrndirectivadescripcion",GXType.Char,2097152,0) ,
          new ParDef("@AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel",GXType.Char,2097152,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004F2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
