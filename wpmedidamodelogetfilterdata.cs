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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wpmedidamodelogetfilterdata : GXProcedure
   {
      public wpmedidamodelogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpmedidamodelogetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17MaxItems = 10;
         AV16PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV31SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? "" : StringUtil.Substring( AV31SearchTxtParms, 3, -1));
         AV15SkipItems = (short)(AV16PageIndex*AV17MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_MEDIDADESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDIDADESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_MEDIDACODIGO") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDIDACODIGOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_MEDIDARIN") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDIDARINOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV33OptionsJson = AV20Options.ToJSonString(false);
         AV34OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV23OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV25Session.Get("WPMedidaModeloGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPMedidaModeloGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("WPMedidaModeloGridState"), null, "", "");
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV36FilterFullText = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFMEDIDADESCRIPCION") == 0 )
            {
               AV12TFMedidaDescripcion = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFMEDIDADESCRIPCION_SEL") == 0 )
            {
               AV13TFMedidaDescripcion_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFMEDIDACODIGO") == 0 )
            {
               AV10TFMedidaCodigo = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFMEDIDACODIGO_SEL") == 0 )
            {
               AV11TFMedidaCodigo_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFMEDIDARIN") == 0 )
            {
               AV38TFMedidaRin = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFMEDIDARIN_SEL") == 0 )
            {
               AV39TFMedidaRin_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMEDIDADESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFMedidaDescripcion = AV14SearchTxt;
         AV13TFMedidaDescripcion_Sel = "";
         AV42Wpmedidamodelods_1_filterfulltext = AV36FilterFullText;
         AV43Wpmedidamodelods_2_tfmedidadescripcion = AV12TFMedidaDescripcion;
         AV44Wpmedidamodelods_3_tfmedidadescripcion_sel = AV13TFMedidaDescripcion_Sel;
         AV45Wpmedidamodelods_4_tfmedidacodigo = AV10TFMedidaCodigo;
         AV46Wpmedidamodelods_5_tfmedidacodigo_sel = AV11TFMedidaCodigo_Sel;
         AV47Wpmedidamodelods_6_tfmedidarin = AV38TFMedidaRin;
         AV48Wpmedidamodelods_7_tfmedidarin_sel = AV39TFMedidaRin_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV42Wpmedidamodelods_1_filterfulltext ,
                                              AV44Wpmedidamodelods_3_tfmedidadescripcion_sel ,
                                              AV43Wpmedidamodelods_2_tfmedidadescripcion ,
                                              AV46Wpmedidamodelods_5_tfmedidacodigo_sel ,
                                              AV45Wpmedidamodelods_4_tfmedidacodigo ,
                                              AV48Wpmedidamodelods_7_tfmedidarin_sel ,
                                              AV47Wpmedidamodelods_6_tfmedidarin ,
                                              A28MedidaDescripcion ,
                                              A27MedidaCodigo ,
                                              A74MedidaRin ,
                                              A22ModeloID ,
                                              AV37ModeloID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV42Wpmedidamodelods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext), "%", "");
         lV42Wpmedidamodelods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext), "%", "");
         lV42Wpmedidamodelods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext), "%", "");
         lV43Wpmedidamodelods_2_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV43Wpmedidamodelods_2_tfmedidadescripcion), "%", "");
         lV45Wpmedidamodelods_4_tfmedidacodigo = StringUtil.PadR( StringUtil.RTrim( AV45Wpmedidamodelods_4_tfmedidacodigo), 20, "%");
         lV47Wpmedidamodelods_6_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV47Wpmedidamodelods_6_tfmedidarin), 20, "%");
         /* Using cursor P002K2 */
         pr_default.execute(0, new Object[] {AV37ModeloID, lV42Wpmedidamodelods_1_filterfulltext, lV42Wpmedidamodelods_1_filterfulltext, lV42Wpmedidamodelods_1_filterfulltext, lV43Wpmedidamodelods_2_tfmedidadescripcion, AV44Wpmedidamodelods_3_tfmedidadescripcion_sel, lV45Wpmedidamodelods_4_tfmedidacodigo, AV46Wpmedidamodelods_5_tfmedidacodigo_sel, lV47Wpmedidamodelods_6_tfmedidarin, AV48Wpmedidamodelods_7_tfmedidarin_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2K2 = false;
            A22ModeloID = P002K2_A22ModeloID[0];
            A28MedidaDescripcion = P002K2_A28MedidaDescripcion[0];
            A74MedidaRin = P002K2_A74MedidaRin[0];
            A27MedidaCodigo = P002K2_A27MedidaCodigo[0];
            A26MedidaID = P002K2_A26MedidaID[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002K2_A28MedidaDescripcion[0], A28MedidaDescripcion) == 0 ) )
            {
               BRK2K2 = false;
               A26MedidaID = P002K2_A26MedidaID[0];
               AV24count = (long)(AV24count+1);
               BRK2K2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A28MedidaDescripcion)) ? "<#Empty#>" : A28MedidaDescripcion);
               AV20Options.Add(AV19Option, 0);
               AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV20Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRK2K2 )
            {
               BRK2K2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMEDIDACODIGOOPTIONS' Routine */
         returnInSub = false;
         AV10TFMedidaCodigo = AV14SearchTxt;
         AV11TFMedidaCodigo_Sel = "";
         AV42Wpmedidamodelods_1_filterfulltext = AV36FilterFullText;
         AV43Wpmedidamodelods_2_tfmedidadescripcion = AV12TFMedidaDescripcion;
         AV44Wpmedidamodelods_3_tfmedidadescripcion_sel = AV13TFMedidaDescripcion_Sel;
         AV45Wpmedidamodelods_4_tfmedidacodigo = AV10TFMedidaCodigo;
         AV46Wpmedidamodelods_5_tfmedidacodigo_sel = AV11TFMedidaCodigo_Sel;
         AV47Wpmedidamodelods_6_tfmedidarin = AV38TFMedidaRin;
         AV48Wpmedidamodelods_7_tfmedidarin_sel = AV39TFMedidaRin_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV42Wpmedidamodelods_1_filterfulltext ,
                                              AV44Wpmedidamodelods_3_tfmedidadescripcion_sel ,
                                              AV43Wpmedidamodelods_2_tfmedidadescripcion ,
                                              AV46Wpmedidamodelods_5_tfmedidacodigo_sel ,
                                              AV45Wpmedidamodelods_4_tfmedidacodigo ,
                                              AV48Wpmedidamodelods_7_tfmedidarin_sel ,
                                              AV47Wpmedidamodelods_6_tfmedidarin ,
                                              A28MedidaDescripcion ,
                                              A27MedidaCodigo ,
                                              A74MedidaRin ,
                                              A22ModeloID ,
                                              AV37ModeloID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV42Wpmedidamodelods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext), "%", "");
         lV42Wpmedidamodelods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext), "%", "");
         lV42Wpmedidamodelods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext), "%", "");
         lV43Wpmedidamodelods_2_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV43Wpmedidamodelods_2_tfmedidadescripcion), "%", "");
         lV45Wpmedidamodelods_4_tfmedidacodigo = StringUtil.PadR( StringUtil.RTrim( AV45Wpmedidamodelods_4_tfmedidacodigo), 20, "%");
         lV47Wpmedidamodelods_6_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV47Wpmedidamodelods_6_tfmedidarin), 20, "%");
         /* Using cursor P002K3 */
         pr_default.execute(1, new Object[] {AV37ModeloID, lV42Wpmedidamodelods_1_filterfulltext, lV42Wpmedidamodelods_1_filterfulltext, lV42Wpmedidamodelods_1_filterfulltext, lV43Wpmedidamodelods_2_tfmedidadescripcion, AV44Wpmedidamodelods_3_tfmedidadescripcion_sel, lV45Wpmedidamodelods_4_tfmedidacodigo, AV46Wpmedidamodelods_5_tfmedidacodigo_sel, lV47Wpmedidamodelods_6_tfmedidarin, AV48Wpmedidamodelods_7_tfmedidarin_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2K4 = false;
            A22ModeloID = P002K3_A22ModeloID[0];
            A27MedidaCodigo = P002K3_A27MedidaCodigo[0];
            A74MedidaRin = P002K3_A74MedidaRin[0];
            A28MedidaDescripcion = P002K3_A28MedidaDescripcion[0];
            A26MedidaID = P002K3_A26MedidaID[0];
            AV24count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002K3_A27MedidaCodigo[0], A27MedidaCodigo) == 0 ) )
            {
               BRK2K4 = false;
               A26MedidaID = P002K3_A26MedidaID[0];
               AV24count = (long)(AV24count+1);
               BRK2K4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A27MedidaCodigo)) ? "<#Empty#>" : A27MedidaCodigo);
               AV20Options.Add(AV19Option, 0);
               AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV20Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRK2K4 )
            {
               BRK2K4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADMEDIDARINOPTIONS' Routine */
         returnInSub = false;
         AV38TFMedidaRin = AV14SearchTxt;
         AV39TFMedidaRin_Sel = "";
         AV42Wpmedidamodelods_1_filterfulltext = AV36FilterFullText;
         AV43Wpmedidamodelods_2_tfmedidadescripcion = AV12TFMedidaDescripcion;
         AV44Wpmedidamodelods_3_tfmedidadescripcion_sel = AV13TFMedidaDescripcion_Sel;
         AV45Wpmedidamodelods_4_tfmedidacodigo = AV10TFMedidaCodigo;
         AV46Wpmedidamodelods_5_tfmedidacodigo_sel = AV11TFMedidaCodigo_Sel;
         AV47Wpmedidamodelods_6_tfmedidarin = AV38TFMedidaRin;
         AV48Wpmedidamodelods_7_tfmedidarin_sel = AV39TFMedidaRin_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV42Wpmedidamodelods_1_filterfulltext ,
                                              AV44Wpmedidamodelods_3_tfmedidadescripcion_sel ,
                                              AV43Wpmedidamodelods_2_tfmedidadescripcion ,
                                              AV46Wpmedidamodelods_5_tfmedidacodigo_sel ,
                                              AV45Wpmedidamodelods_4_tfmedidacodigo ,
                                              AV48Wpmedidamodelods_7_tfmedidarin_sel ,
                                              AV47Wpmedidamodelods_6_tfmedidarin ,
                                              A28MedidaDescripcion ,
                                              A27MedidaCodigo ,
                                              A74MedidaRin ,
                                              A22ModeloID ,
                                              AV37ModeloID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV42Wpmedidamodelods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext), "%", "");
         lV42Wpmedidamodelods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext), "%", "");
         lV42Wpmedidamodelods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext), "%", "");
         lV43Wpmedidamodelods_2_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV43Wpmedidamodelods_2_tfmedidadescripcion), "%", "");
         lV45Wpmedidamodelods_4_tfmedidacodigo = StringUtil.PadR( StringUtil.RTrim( AV45Wpmedidamodelods_4_tfmedidacodigo), 20, "%");
         lV47Wpmedidamodelods_6_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV47Wpmedidamodelods_6_tfmedidarin), 20, "%");
         /* Using cursor P002K4 */
         pr_default.execute(2, new Object[] {AV37ModeloID, lV42Wpmedidamodelods_1_filterfulltext, lV42Wpmedidamodelods_1_filterfulltext, lV42Wpmedidamodelods_1_filterfulltext, lV43Wpmedidamodelods_2_tfmedidadescripcion, AV44Wpmedidamodelods_3_tfmedidadescripcion_sel, lV45Wpmedidamodelods_4_tfmedidacodigo, AV46Wpmedidamodelods_5_tfmedidacodigo_sel, lV47Wpmedidamodelods_6_tfmedidarin, AV48Wpmedidamodelods_7_tfmedidarin_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2K6 = false;
            A22ModeloID = P002K4_A22ModeloID[0];
            A74MedidaRin = P002K4_A74MedidaRin[0];
            A27MedidaCodigo = P002K4_A27MedidaCodigo[0];
            A28MedidaDescripcion = P002K4_A28MedidaDescripcion[0];
            A26MedidaID = P002K4_A26MedidaID[0];
            AV24count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002K4_A74MedidaRin[0], A74MedidaRin) == 0 ) )
            {
               BRK2K6 = false;
               A26MedidaID = P002K4_A26MedidaID[0];
               AV24count = (long)(AV24count+1);
               BRK2K6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A74MedidaRin)) ? "<#Empty#>" : A74MedidaRin);
               AV20Options.Add(AV19Option, 0);
               AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV20Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRK2K6 )
            {
               BRK2K6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV33OptionsJson = "";
         AV34OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV20Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV23OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Session = context.GetSession();
         AV27GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV28GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV36FilterFullText = "";
         AV12TFMedidaDescripcion = "";
         AV13TFMedidaDescripcion_Sel = "";
         AV10TFMedidaCodigo = "";
         AV11TFMedidaCodigo_Sel = "";
         AV38TFMedidaRin = "";
         AV39TFMedidaRin_Sel = "";
         AV42Wpmedidamodelods_1_filterfulltext = "";
         AV43Wpmedidamodelods_2_tfmedidadescripcion = "";
         AV44Wpmedidamodelods_3_tfmedidadescripcion_sel = "";
         AV45Wpmedidamodelods_4_tfmedidacodigo = "";
         AV46Wpmedidamodelods_5_tfmedidacodigo_sel = "";
         AV47Wpmedidamodelods_6_tfmedidarin = "";
         AV48Wpmedidamodelods_7_tfmedidarin_sel = "";
         lV42Wpmedidamodelods_1_filterfulltext = "";
         lV43Wpmedidamodelods_2_tfmedidadescripcion = "";
         lV45Wpmedidamodelods_4_tfmedidacodigo = "";
         lV47Wpmedidamodelods_6_tfmedidarin = "";
         A28MedidaDescripcion = "";
         A27MedidaCodigo = "";
         A74MedidaRin = "";
         P002K2_A22ModeloID = new int[1] ;
         P002K2_A28MedidaDescripcion = new string[] {""} ;
         P002K2_A74MedidaRin = new string[] {""} ;
         P002K2_A27MedidaCodigo = new string[] {""} ;
         P002K2_A26MedidaID = new int[1] ;
         AV19Option = "";
         P002K3_A22ModeloID = new int[1] ;
         P002K3_A27MedidaCodigo = new string[] {""} ;
         P002K3_A74MedidaRin = new string[] {""} ;
         P002K3_A28MedidaDescripcion = new string[] {""} ;
         P002K3_A26MedidaID = new int[1] ;
         P002K4_A22ModeloID = new int[1] ;
         P002K4_A74MedidaRin = new string[] {""} ;
         P002K4_A27MedidaCodigo = new string[] {""} ;
         P002K4_A28MedidaDescripcion = new string[] {""} ;
         P002K4_A26MedidaID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpmedidamodelogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002K2_A22ModeloID, P002K2_A28MedidaDescripcion, P002K2_A74MedidaRin, P002K2_A27MedidaCodigo, P002K2_A26MedidaID
               }
               , new Object[] {
               P002K3_A22ModeloID, P002K3_A27MedidaCodigo, P002K3_A74MedidaRin, P002K3_A28MedidaDescripcion, P002K3_A26MedidaID
               }
               , new Object[] {
               P002K4_A22ModeloID, P002K4_A74MedidaRin, P002K4_A27MedidaCodigo, P002K4_A28MedidaDescripcion, P002K4_A26MedidaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private int AV40GXV1 ;
      private int A22ModeloID ;
      private int AV37ModeloID ;
      private int A26MedidaID ;
      private long AV24count ;
      private string AV10TFMedidaCodigo ;
      private string AV11TFMedidaCodigo_Sel ;
      private string AV38TFMedidaRin ;
      private string AV39TFMedidaRin_Sel ;
      private string AV45Wpmedidamodelods_4_tfmedidacodigo ;
      private string AV46Wpmedidamodelods_5_tfmedidacodigo_sel ;
      private string AV47Wpmedidamodelods_6_tfmedidarin ;
      private string AV48Wpmedidamodelods_7_tfmedidarin_sel ;
      private string lV45Wpmedidamodelods_4_tfmedidacodigo ;
      private string lV47Wpmedidamodelods_6_tfmedidarin ;
      private string A27MedidaCodigo ;
      private string A74MedidaRin ;
      private bool returnInSub ;
      private bool BRK2K2 ;
      private bool BRK2K4 ;
      private bool BRK2K6 ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV36FilterFullText ;
      private string AV12TFMedidaDescripcion ;
      private string AV13TFMedidaDescripcion_Sel ;
      private string AV42Wpmedidamodelods_1_filterfulltext ;
      private string AV43Wpmedidamodelods_2_tfmedidadescripcion ;
      private string AV44Wpmedidamodelods_3_tfmedidadescripcion_sel ;
      private string lV42Wpmedidamodelods_1_filterfulltext ;
      private string lV43Wpmedidamodelods_2_tfmedidadescripcion ;
      private string A28MedidaDescripcion ;
      private string AV19Option ;
      private IGxSession AV25Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV20Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV23OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV27GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P002K2_A22ModeloID ;
      private string[] P002K2_A28MedidaDescripcion ;
      private string[] P002K2_A74MedidaRin ;
      private string[] P002K2_A27MedidaCodigo ;
      private int[] P002K2_A26MedidaID ;
      private int[] P002K3_A22ModeloID ;
      private string[] P002K3_A27MedidaCodigo ;
      private string[] P002K3_A74MedidaRin ;
      private string[] P002K3_A28MedidaDescripcion ;
      private int[] P002K3_A26MedidaID ;
      private int[] P002K4_A22ModeloID ;
      private string[] P002K4_A74MedidaRin ;
      private string[] P002K4_A27MedidaCodigo ;
      private string[] P002K4_A28MedidaDescripcion ;
      private int[] P002K4_A26MedidaID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpmedidamodelogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002K2( IGxContext context ,
                                             string AV42Wpmedidamodelods_1_filterfulltext ,
                                             string AV44Wpmedidamodelods_3_tfmedidadescripcion_sel ,
                                             string AV43Wpmedidamodelods_2_tfmedidadescripcion ,
                                             string AV46Wpmedidamodelods_5_tfmedidacodigo_sel ,
                                             string AV45Wpmedidamodelods_4_tfmedidacodigo ,
                                             string AV48Wpmedidamodelods_7_tfmedidarin_sel ,
                                             string AV47Wpmedidamodelods_6_tfmedidarin ,
                                             string A28MedidaDescripcion ,
                                             string A27MedidaCodigo ,
                                             string A74MedidaRin ,
                                             int A22ModeloID ,
                                             int AV37ModeloID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `ModeloID`, `MedidaDescripcion`, `MedidaRin`, `MedidaCodigo`, `MedidaID` FROM `Medida`";
         AddWhere(sWhereString, "(`ModeloID` = @AV37ModeloID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( `MedidaDescripcion` like CONCAT('%', @lV42Wpmedidamodelods_1_filterfulltext)) or ( `MedidaCodigo` like CONCAT('%', @lV42Wpmedidamodelods_1_filterfulltext)) or ( `MedidaRin` like CONCAT('%', @lV42Wpmedidamodelods_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpmedidamodelods_3_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wpmedidamodelods_2_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(`MedidaDescripcion` like @lV43Wpmedidamodelods_2_tfmedidadescripcion)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpmedidamodelods_3_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV44Wpmedidamodelods_3_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`MedidaDescripcion` = @AV44Wpmedidamodelods_3_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Wpmedidamodelods_3_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Wpmedidamodelods_5_tfmedidacodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wpmedidamodelods_4_tfmedidacodigo)) ) )
         {
            AddWhere(sWhereString, "(`MedidaCodigo` like @lV45Wpmedidamodelods_4_tfmedidacodigo)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wpmedidamodelods_5_tfmedidacodigo_sel)) && ! ( StringUtil.StrCmp(AV46Wpmedidamodelods_5_tfmedidacodigo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`MedidaCodigo` = @AV46Wpmedidamodelods_5_tfmedidacodigo_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV46Wpmedidamodelods_5_tfmedidacodigo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`MedidaCodigo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wpmedidamodelods_7_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Wpmedidamodelods_6_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(`MedidaRin` like @lV47Wpmedidamodelods_6_tfmedidarin)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wpmedidamodelods_7_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV48Wpmedidamodelods_7_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`MedidaRin` = @AV48Wpmedidamodelods_7_tfmedidarin_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV48Wpmedidamodelods_7_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`MedidaRin`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `MedidaDescripcion`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002K3( IGxContext context ,
                                             string AV42Wpmedidamodelods_1_filterfulltext ,
                                             string AV44Wpmedidamodelods_3_tfmedidadescripcion_sel ,
                                             string AV43Wpmedidamodelods_2_tfmedidadescripcion ,
                                             string AV46Wpmedidamodelods_5_tfmedidacodigo_sel ,
                                             string AV45Wpmedidamodelods_4_tfmedidacodigo ,
                                             string AV48Wpmedidamodelods_7_tfmedidarin_sel ,
                                             string AV47Wpmedidamodelods_6_tfmedidarin ,
                                             string A28MedidaDescripcion ,
                                             string A27MedidaCodigo ,
                                             string A74MedidaRin ,
                                             int A22ModeloID ,
                                             int AV37ModeloID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT `ModeloID`, `MedidaCodigo`, `MedidaRin`, `MedidaDescripcion`, `MedidaID` FROM `Medida`";
         AddWhere(sWhereString, "(`ModeloID` = @AV37ModeloID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( `MedidaDescripcion` like CONCAT('%', @lV42Wpmedidamodelods_1_filterfulltext)) or ( `MedidaCodigo` like CONCAT('%', @lV42Wpmedidamodelods_1_filterfulltext)) or ( `MedidaRin` like CONCAT('%', @lV42Wpmedidamodelods_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpmedidamodelods_3_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wpmedidamodelods_2_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(`MedidaDescripcion` like @lV43Wpmedidamodelods_2_tfmedidadescripcion)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpmedidamodelods_3_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV44Wpmedidamodelods_3_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`MedidaDescripcion` = @AV44Wpmedidamodelods_3_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Wpmedidamodelods_3_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Wpmedidamodelods_5_tfmedidacodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wpmedidamodelods_4_tfmedidacodigo)) ) )
         {
            AddWhere(sWhereString, "(`MedidaCodigo` like @lV45Wpmedidamodelods_4_tfmedidacodigo)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wpmedidamodelods_5_tfmedidacodigo_sel)) && ! ( StringUtil.StrCmp(AV46Wpmedidamodelods_5_tfmedidacodigo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`MedidaCodigo` = @AV46Wpmedidamodelods_5_tfmedidacodigo_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV46Wpmedidamodelods_5_tfmedidacodigo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`MedidaCodigo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wpmedidamodelods_7_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Wpmedidamodelods_6_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(`MedidaRin` like @lV47Wpmedidamodelods_6_tfmedidarin)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wpmedidamodelods_7_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV48Wpmedidamodelods_7_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`MedidaRin` = @AV48Wpmedidamodelods_7_tfmedidarin_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV48Wpmedidamodelods_7_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`MedidaRin`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `MedidaCodigo`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002K4( IGxContext context ,
                                             string AV42Wpmedidamodelods_1_filterfulltext ,
                                             string AV44Wpmedidamodelods_3_tfmedidadescripcion_sel ,
                                             string AV43Wpmedidamodelods_2_tfmedidadescripcion ,
                                             string AV46Wpmedidamodelods_5_tfmedidacodigo_sel ,
                                             string AV45Wpmedidamodelods_4_tfmedidacodigo ,
                                             string AV48Wpmedidamodelods_7_tfmedidarin_sel ,
                                             string AV47Wpmedidamodelods_6_tfmedidarin ,
                                             string A28MedidaDescripcion ,
                                             string A27MedidaCodigo ,
                                             string A74MedidaRin ,
                                             int A22ModeloID ,
                                             int AV37ModeloID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT `ModeloID`, `MedidaRin`, `MedidaCodigo`, `MedidaDescripcion`, `MedidaID` FROM `Medida`";
         AddWhere(sWhereString, "(`ModeloID` = @AV37ModeloID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Wpmedidamodelods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( `MedidaDescripcion` like CONCAT('%', @lV42Wpmedidamodelods_1_filterfulltext)) or ( `MedidaCodigo` like CONCAT('%', @lV42Wpmedidamodelods_1_filterfulltext)) or ( `MedidaRin` like CONCAT('%', @lV42Wpmedidamodelods_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpmedidamodelods_3_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wpmedidamodelods_2_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(`MedidaDescripcion` like @lV43Wpmedidamodelods_2_tfmedidadescripcion)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpmedidamodelods_3_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV44Wpmedidamodelods_3_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`MedidaDescripcion` = @AV44Wpmedidamodelods_3_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Wpmedidamodelods_3_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Wpmedidamodelods_5_tfmedidacodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wpmedidamodelods_4_tfmedidacodigo)) ) )
         {
            AddWhere(sWhereString, "(`MedidaCodigo` like @lV45Wpmedidamodelods_4_tfmedidacodigo)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wpmedidamodelods_5_tfmedidacodigo_sel)) && ! ( StringUtil.StrCmp(AV46Wpmedidamodelods_5_tfmedidacodigo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`MedidaCodigo` = @AV46Wpmedidamodelods_5_tfmedidacodigo_sel)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV46Wpmedidamodelods_5_tfmedidacodigo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`MedidaCodigo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wpmedidamodelods_7_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Wpmedidamodelods_6_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(`MedidaRin` like @lV47Wpmedidamodelods_6_tfmedidarin)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wpmedidamodelods_7_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV48Wpmedidamodelods_7_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`MedidaRin` = @AV48Wpmedidamodelods_7_tfmedidarin_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV48Wpmedidamodelods_7_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`MedidaRin`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `MedidaRin`";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] );
               case 1 :
                     return conditional_P002K3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] );
               case 2 :
                     return conditional_P002K4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002K2;
          prmP002K2 = new Object[] {
          new ParDef("@AV37ModeloID",GXType.Int32,9,0) ,
          new ParDef("@lV42Wpmedidamodelods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV42Wpmedidamodelods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV42Wpmedidamodelods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV43Wpmedidamodelods_2_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV44Wpmedidamodelods_3_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV45Wpmedidamodelods_4_tfmedidacodigo",GXType.Char,20,0) ,
          new ParDef("@AV46Wpmedidamodelods_5_tfmedidacodigo_sel",GXType.Char,20,0) ,
          new ParDef("@lV47Wpmedidamodelods_6_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV48Wpmedidamodelods_7_tfmedidarin_sel",GXType.Char,20,0)
          };
          Object[] prmP002K3;
          prmP002K3 = new Object[] {
          new ParDef("@AV37ModeloID",GXType.Int32,9,0) ,
          new ParDef("@lV42Wpmedidamodelods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV42Wpmedidamodelods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV42Wpmedidamodelods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV43Wpmedidamodelods_2_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV44Wpmedidamodelods_3_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV45Wpmedidamodelods_4_tfmedidacodigo",GXType.Char,20,0) ,
          new ParDef("@AV46Wpmedidamodelods_5_tfmedidacodigo_sel",GXType.Char,20,0) ,
          new ParDef("@lV47Wpmedidamodelods_6_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV48Wpmedidamodelods_7_tfmedidarin_sel",GXType.Char,20,0)
          };
          Object[] prmP002K4;
          prmP002K4 = new Object[] {
          new ParDef("@AV37ModeloID",GXType.Int32,9,0) ,
          new ParDef("@lV42Wpmedidamodelods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV42Wpmedidamodelods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV42Wpmedidamodelods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV43Wpmedidamodelods_2_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV44Wpmedidamodelods_3_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV45Wpmedidamodelods_4_tfmedidacodigo",GXType.Char,20,0) ,
          new ParDef("@AV46Wpmedidamodelods_5_tfmedidacodigo_sel",GXType.Char,20,0) ,
          new ParDef("@lV47Wpmedidamodelods_6_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV48Wpmedidamodelods_7_tfmedidarin_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002K2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002K3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002K4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002K4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
