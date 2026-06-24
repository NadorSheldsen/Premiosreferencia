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
   public class wpfacturamedidagetfilterdata : GXProcedure
   {
      public wpfacturamedidagetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfacturamedidagetfilterdata( IGxContext context )
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
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV43OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV28Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25MaxItems = 10;
         AV24PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV39SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV22SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? "" : StringUtil.Substring( AV39SearchTxtParms, 3, -1));
         AV23SkipItems = (short)(AV24PageIndex*AV25MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_MODELODESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADMODELODESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_MEDIDADESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDIDADESCRIPCIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_MEDIDARIN") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDIDARINOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV41OptionsJson = AV28Options.ToJSonString(false);
         AV42OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV43OptionIndexesJson = AV31OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("WPFacturaMedidaGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPFacturaMedidaGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("WPFacturaMedidaGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFFACTURAMEDIDAID") == 0 )
            {
               AV10TFFacturaMedidaID = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFFacturaMedidaID_To = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMODELODESCRIPCION") == 0 )
            {
               AV12TFModeloDescripcion = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMODELODESCRIPCION_SEL") == 0 )
            {
               AV13TFModeloDescripcion_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMEDIDADESCRIPCION") == 0 )
            {
               AV14TFMedidaDescripcion = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMEDIDADESCRIPCION_SEL") == 0 )
            {
               AV15TFMedidaDescripcion_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMEDIDARIN") == 0 )
            {
               AV16TFMedidaRin = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMEDIDARIN_SEL") == 0 )
            {
               AV17TFMedidaRin_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFFACTURAMEDIDACANTIDAD") == 0 )
            {
               AV18TFFacturaMedidaCantidad = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV19TFFacturaMedidaCantidad_To = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFFACTURAMEDIDAPRECIO") == 0 )
            {
               AV20TFFacturaMedidaPrecio = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV21TFFacturaMedidaPrecio_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMODELODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFModeloDescripcion = AV22SearchTxt;
         AV13TFModeloDescripcion_Sel = "";
         AV48Wpfacturamedidads_1_tffacturamedidaid = AV10TFFacturaMedidaID;
         AV49Wpfacturamedidads_2_tffacturamedidaid_to = AV11TFFacturaMedidaID_To;
         AV50Wpfacturamedidads_3_tfmodelodescripcion = AV12TFModeloDescripcion;
         AV51Wpfacturamedidads_4_tfmodelodescripcion_sel = AV13TFModeloDescripcion_Sel;
         AV52Wpfacturamedidads_5_tfmedidadescripcion = AV14TFMedidaDescripcion;
         AV53Wpfacturamedidads_6_tfmedidadescripcion_sel = AV15TFMedidaDescripcion_Sel;
         AV54Wpfacturamedidads_7_tfmedidarin = AV16TFMedidaRin;
         AV55Wpfacturamedidads_8_tfmedidarin_sel = AV17TFMedidaRin_Sel;
         AV56Wpfacturamedidads_9_tffacturamedidacantidad = AV18TFFacturaMedidaCantidad;
         AV57Wpfacturamedidads_10_tffacturamedidacantidad_to = AV19TFFacturaMedidaCantidad_To;
         AV58Wpfacturamedidads_11_tffacturamedidaprecio = AV20TFFacturaMedidaPrecio;
         AV59Wpfacturamedidads_12_tffacturamedidaprecio_to = AV21TFFacturaMedidaPrecio_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV48Wpfacturamedidads_1_tffacturamedidaid ,
                                              AV49Wpfacturamedidads_2_tffacturamedidaid_to ,
                                              AV51Wpfacturamedidads_4_tfmodelodescripcion_sel ,
                                              AV50Wpfacturamedidads_3_tfmodelodescripcion ,
                                              AV53Wpfacturamedidads_6_tfmedidadescripcion_sel ,
                                              AV52Wpfacturamedidads_5_tfmedidadescripcion ,
                                              AV55Wpfacturamedidads_8_tfmedidarin_sel ,
                                              AV54Wpfacturamedidads_7_tfmedidarin ,
                                              AV56Wpfacturamedidads_9_tffacturamedidacantidad ,
                                              AV57Wpfacturamedidads_10_tffacturamedidacantidad_to ,
                                              AV58Wpfacturamedidads_11_tffacturamedidaprecio ,
                                              AV59Wpfacturamedidads_12_tffacturamedidaprecio_to ,
                                              A77FacturaMedidaID ,
                                              A23ModeloDescripcion ,
                                              A28MedidaDescripcion ,
                                              A74MedidaRin ,
                                              A78FacturaMedidaCantidad ,
                                              A79FacturaMedidaPrecio ,
                                              A69FacturaID ,
                                              AV45FacturaID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         lV50Wpfacturamedidads_3_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV50Wpfacturamedidads_3_tfmodelodescripcion), "%", "");
         lV52Wpfacturamedidads_5_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV52Wpfacturamedidads_5_tfmedidadescripcion), "%", "");
         lV54Wpfacturamedidads_7_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV54Wpfacturamedidads_7_tfmedidarin), 20, "%");
         /* Using cursor P00452 */
         pr_default.execute(0, new Object[] {AV45FacturaID, AV48Wpfacturamedidads_1_tffacturamedidaid, AV49Wpfacturamedidads_2_tffacturamedidaid_to, lV50Wpfacturamedidads_3_tfmodelodescripcion, AV51Wpfacturamedidads_4_tfmodelodescripcion_sel, lV52Wpfacturamedidads_5_tfmedidadescripcion, AV53Wpfacturamedidads_6_tfmedidadescripcion_sel, lV54Wpfacturamedidads_7_tfmedidarin, AV55Wpfacturamedidads_8_tfmedidarin_sel, AV56Wpfacturamedidads_9_tffacturamedidacantidad, AV57Wpfacturamedidads_10_tffacturamedidacantidad_to, AV58Wpfacturamedidads_11_tffacturamedidaprecio, AV59Wpfacturamedidads_12_tffacturamedidaprecio_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK452 = false;
            A26MedidaID = P00452_A26MedidaID[0];
            A22ModeloID = P00452_A22ModeloID[0];
            A69FacturaID = P00452_A69FacturaID[0];
            A23ModeloDescripcion = P00452_A23ModeloDescripcion[0];
            A79FacturaMedidaPrecio = P00452_A79FacturaMedidaPrecio[0];
            A78FacturaMedidaCantidad = P00452_A78FacturaMedidaCantidad[0];
            A74MedidaRin = P00452_A74MedidaRin[0];
            A28MedidaDescripcion = P00452_A28MedidaDescripcion[0];
            A77FacturaMedidaID = P00452_A77FacturaMedidaID[0];
            A22ModeloID = P00452_A22ModeloID[0];
            A74MedidaRin = P00452_A74MedidaRin[0];
            A28MedidaDescripcion = P00452_A28MedidaDescripcion[0];
            A23ModeloDescripcion = P00452_A23ModeloDescripcion[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00452_A23ModeloDescripcion[0], A23ModeloDescripcion) == 0 ) )
            {
               BRK452 = false;
               A26MedidaID = P00452_A26MedidaID[0];
               A22ModeloID = P00452_A22ModeloID[0];
               A77FacturaMedidaID = P00452_A77FacturaMedidaID[0];
               A22ModeloID = P00452_A22ModeloID[0];
               AV32count = (long)(AV32count+1);
               BRK452 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A23ModeloDescripcion)) ? "<#Empty#>" : A23ModeloDescripcion);
               AV28Options.Add(AV27Option, 0);
               AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV28Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV23SkipItems = (short)(AV23SkipItems-1);
            }
            if ( ! BRK452 )
            {
               BRK452 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMEDIDADESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFMedidaDescripcion = AV22SearchTxt;
         AV15TFMedidaDescripcion_Sel = "";
         AV48Wpfacturamedidads_1_tffacturamedidaid = AV10TFFacturaMedidaID;
         AV49Wpfacturamedidads_2_tffacturamedidaid_to = AV11TFFacturaMedidaID_To;
         AV50Wpfacturamedidads_3_tfmodelodescripcion = AV12TFModeloDescripcion;
         AV51Wpfacturamedidads_4_tfmodelodescripcion_sel = AV13TFModeloDescripcion_Sel;
         AV52Wpfacturamedidads_5_tfmedidadescripcion = AV14TFMedidaDescripcion;
         AV53Wpfacturamedidads_6_tfmedidadescripcion_sel = AV15TFMedidaDescripcion_Sel;
         AV54Wpfacturamedidads_7_tfmedidarin = AV16TFMedidaRin;
         AV55Wpfacturamedidads_8_tfmedidarin_sel = AV17TFMedidaRin_Sel;
         AV56Wpfacturamedidads_9_tffacturamedidacantidad = AV18TFFacturaMedidaCantidad;
         AV57Wpfacturamedidads_10_tffacturamedidacantidad_to = AV19TFFacturaMedidaCantidad_To;
         AV58Wpfacturamedidads_11_tffacturamedidaprecio = AV20TFFacturaMedidaPrecio;
         AV59Wpfacturamedidads_12_tffacturamedidaprecio_to = AV21TFFacturaMedidaPrecio_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV48Wpfacturamedidads_1_tffacturamedidaid ,
                                              AV49Wpfacturamedidads_2_tffacturamedidaid_to ,
                                              AV51Wpfacturamedidads_4_tfmodelodescripcion_sel ,
                                              AV50Wpfacturamedidads_3_tfmodelodescripcion ,
                                              AV53Wpfacturamedidads_6_tfmedidadescripcion_sel ,
                                              AV52Wpfacturamedidads_5_tfmedidadescripcion ,
                                              AV55Wpfacturamedidads_8_tfmedidarin_sel ,
                                              AV54Wpfacturamedidads_7_tfmedidarin ,
                                              AV56Wpfacturamedidads_9_tffacturamedidacantidad ,
                                              AV57Wpfacturamedidads_10_tffacturamedidacantidad_to ,
                                              AV58Wpfacturamedidads_11_tffacturamedidaprecio ,
                                              AV59Wpfacturamedidads_12_tffacturamedidaprecio_to ,
                                              A77FacturaMedidaID ,
                                              A23ModeloDescripcion ,
                                              A28MedidaDescripcion ,
                                              A74MedidaRin ,
                                              A78FacturaMedidaCantidad ,
                                              A79FacturaMedidaPrecio ,
                                              A69FacturaID ,
                                              AV45FacturaID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         lV50Wpfacturamedidads_3_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV50Wpfacturamedidads_3_tfmodelodescripcion), "%", "");
         lV52Wpfacturamedidads_5_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV52Wpfacturamedidads_5_tfmedidadescripcion), "%", "");
         lV54Wpfacturamedidads_7_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV54Wpfacturamedidads_7_tfmedidarin), 20, "%");
         /* Using cursor P00453 */
         pr_default.execute(1, new Object[] {AV45FacturaID, AV48Wpfacturamedidads_1_tffacturamedidaid, AV49Wpfacturamedidads_2_tffacturamedidaid_to, lV50Wpfacturamedidads_3_tfmodelodescripcion, AV51Wpfacturamedidads_4_tfmodelodescripcion_sel, lV52Wpfacturamedidads_5_tfmedidadescripcion, AV53Wpfacturamedidads_6_tfmedidadescripcion_sel, lV54Wpfacturamedidads_7_tfmedidarin, AV55Wpfacturamedidads_8_tfmedidarin_sel, AV56Wpfacturamedidads_9_tffacturamedidacantidad, AV57Wpfacturamedidads_10_tffacturamedidacantidad_to, AV58Wpfacturamedidads_11_tffacturamedidaprecio, AV59Wpfacturamedidads_12_tffacturamedidaprecio_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK454 = false;
            A26MedidaID = P00453_A26MedidaID[0];
            A22ModeloID = P00453_A22ModeloID[0];
            A69FacturaID = P00453_A69FacturaID[0];
            A28MedidaDescripcion = P00453_A28MedidaDescripcion[0];
            A79FacturaMedidaPrecio = P00453_A79FacturaMedidaPrecio[0];
            A78FacturaMedidaCantidad = P00453_A78FacturaMedidaCantidad[0];
            A74MedidaRin = P00453_A74MedidaRin[0];
            A23ModeloDescripcion = P00453_A23ModeloDescripcion[0];
            A77FacturaMedidaID = P00453_A77FacturaMedidaID[0];
            A22ModeloID = P00453_A22ModeloID[0];
            A28MedidaDescripcion = P00453_A28MedidaDescripcion[0];
            A74MedidaRin = P00453_A74MedidaRin[0];
            A23ModeloDescripcion = P00453_A23ModeloDescripcion[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00453_A28MedidaDescripcion[0], A28MedidaDescripcion) == 0 ) )
            {
               BRK454 = false;
               A26MedidaID = P00453_A26MedidaID[0];
               A77FacturaMedidaID = P00453_A77FacturaMedidaID[0];
               AV32count = (long)(AV32count+1);
               BRK454 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A28MedidaDescripcion)) ? "<#Empty#>" : A28MedidaDescripcion);
               AV28Options.Add(AV27Option, 0);
               AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV28Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV23SkipItems = (short)(AV23SkipItems-1);
            }
            if ( ! BRK454 )
            {
               BRK454 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADMEDIDARINOPTIONS' Routine */
         returnInSub = false;
         AV16TFMedidaRin = AV22SearchTxt;
         AV17TFMedidaRin_Sel = "";
         AV48Wpfacturamedidads_1_tffacturamedidaid = AV10TFFacturaMedidaID;
         AV49Wpfacturamedidads_2_tffacturamedidaid_to = AV11TFFacturaMedidaID_To;
         AV50Wpfacturamedidads_3_tfmodelodescripcion = AV12TFModeloDescripcion;
         AV51Wpfacturamedidads_4_tfmodelodescripcion_sel = AV13TFModeloDescripcion_Sel;
         AV52Wpfacturamedidads_5_tfmedidadescripcion = AV14TFMedidaDescripcion;
         AV53Wpfacturamedidads_6_tfmedidadescripcion_sel = AV15TFMedidaDescripcion_Sel;
         AV54Wpfacturamedidads_7_tfmedidarin = AV16TFMedidaRin;
         AV55Wpfacturamedidads_8_tfmedidarin_sel = AV17TFMedidaRin_Sel;
         AV56Wpfacturamedidads_9_tffacturamedidacantidad = AV18TFFacturaMedidaCantidad;
         AV57Wpfacturamedidads_10_tffacturamedidacantidad_to = AV19TFFacturaMedidaCantidad_To;
         AV58Wpfacturamedidads_11_tffacturamedidaprecio = AV20TFFacturaMedidaPrecio;
         AV59Wpfacturamedidads_12_tffacturamedidaprecio_to = AV21TFFacturaMedidaPrecio_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV48Wpfacturamedidads_1_tffacturamedidaid ,
                                              AV49Wpfacturamedidads_2_tffacturamedidaid_to ,
                                              AV51Wpfacturamedidads_4_tfmodelodescripcion_sel ,
                                              AV50Wpfacturamedidads_3_tfmodelodescripcion ,
                                              AV53Wpfacturamedidads_6_tfmedidadescripcion_sel ,
                                              AV52Wpfacturamedidads_5_tfmedidadescripcion ,
                                              AV55Wpfacturamedidads_8_tfmedidarin_sel ,
                                              AV54Wpfacturamedidads_7_tfmedidarin ,
                                              AV56Wpfacturamedidads_9_tffacturamedidacantidad ,
                                              AV57Wpfacturamedidads_10_tffacturamedidacantidad_to ,
                                              AV58Wpfacturamedidads_11_tffacturamedidaprecio ,
                                              AV59Wpfacturamedidads_12_tffacturamedidaprecio_to ,
                                              A77FacturaMedidaID ,
                                              A23ModeloDescripcion ,
                                              A28MedidaDescripcion ,
                                              A74MedidaRin ,
                                              A78FacturaMedidaCantidad ,
                                              A79FacturaMedidaPrecio ,
                                              A69FacturaID ,
                                              AV45FacturaID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         lV50Wpfacturamedidads_3_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV50Wpfacturamedidads_3_tfmodelodescripcion), "%", "");
         lV52Wpfacturamedidads_5_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV52Wpfacturamedidads_5_tfmedidadescripcion), "%", "");
         lV54Wpfacturamedidads_7_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV54Wpfacturamedidads_7_tfmedidarin), 20, "%");
         /* Using cursor P00454 */
         pr_default.execute(2, new Object[] {AV45FacturaID, AV48Wpfacturamedidads_1_tffacturamedidaid, AV49Wpfacturamedidads_2_tffacturamedidaid_to, lV50Wpfacturamedidads_3_tfmodelodescripcion, AV51Wpfacturamedidads_4_tfmodelodescripcion_sel, lV52Wpfacturamedidads_5_tfmedidadescripcion, AV53Wpfacturamedidads_6_tfmedidadescripcion_sel, lV54Wpfacturamedidads_7_tfmedidarin, AV55Wpfacturamedidads_8_tfmedidarin_sel, AV56Wpfacturamedidads_9_tffacturamedidacantidad, AV57Wpfacturamedidads_10_tffacturamedidacantidad_to, AV58Wpfacturamedidads_11_tffacturamedidaprecio, AV59Wpfacturamedidads_12_tffacturamedidaprecio_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK456 = false;
            A26MedidaID = P00454_A26MedidaID[0];
            A22ModeloID = P00454_A22ModeloID[0];
            A69FacturaID = P00454_A69FacturaID[0];
            A74MedidaRin = P00454_A74MedidaRin[0];
            A79FacturaMedidaPrecio = P00454_A79FacturaMedidaPrecio[0];
            A78FacturaMedidaCantidad = P00454_A78FacturaMedidaCantidad[0];
            A28MedidaDescripcion = P00454_A28MedidaDescripcion[0];
            A23ModeloDescripcion = P00454_A23ModeloDescripcion[0];
            A77FacturaMedidaID = P00454_A77FacturaMedidaID[0];
            A22ModeloID = P00454_A22ModeloID[0];
            A74MedidaRin = P00454_A74MedidaRin[0];
            A28MedidaDescripcion = P00454_A28MedidaDescripcion[0];
            A23ModeloDescripcion = P00454_A23ModeloDescripcion[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00454_A74MedidaRin[0], A74MedidaRin) == 0 ) )
            {
               BRK456 = false;
               A26MedidaID = P00454_A26MedidaID[0];
               A77FacturaMedidaID = P00454_A77FacturaMedidaID[0];
               AV32count = (long)(AV32count+1);
               BRK456 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A74MedidaRin)) ? "<#Empty#>" : A74MedidaRin);
               AV28Options.Add(AV27Option, 0);
               AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV28Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV23SkipItems = (short)(AV23SkipItems-1);
            }
            if ( ! BRK456 )
            {
               BRK456 = true;
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
         AV41OptionsJson = "";
         AV42OptionsDescJson = "";
         AV43OptionIndexesJson = "";
         AV28Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV31OptionIndexes = new GxSimpleCollection<string>();
         AV22SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Session = context.GetSession();
         AV35GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV36GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV12TFModeloDescripcion = "";
         AV13TFModeloDescripcion_Sel = "";
         AV14TFMedidaDescripcion = "";
         AV15TFMedidaDescripcion_Sel = "";
         AV16TFMedidaRin = "";
         AV17TFMedidaRin_Sel = "";
         AV50Wpfacturamedidads_3_tfmodelodescripcion = "";
         AV51Wpfacturamedidads_4_tfmodelodescripcion_sel = "";
         AV52Wpfacturamedidads_5_tfmedidadescripcion = "";
         AV53Wpfacturamedidads_6_tfmedidadescripcion_sel = "";
         AV54Wpfacturamedidads_7_tfmedidarin = "";
         AV55Wpfacturamedidads_8_tfmedidarin_sel = "";
         lV50Wpfacturamedidads_3_tfmodelodescripcion = "";
         lV52Wpfacturamedidads_5_tfmedidadescripcion = "";
         lV54Wpfacturamedidads_7_tfmedidarin = "";
         A23ModeloDescripcion = "";
         A28MedidaDescripcion = "";
         A74MedidaRin = "";
         P00452_A26MedidaID = new int[1] ;
         P00452_A22ModeloID = new int[1] ;
         P00452_A69FacturaID = new int[1] ;
         P00452_A23ModeloDescripcion = new string[] {""} ;
         P00452_A79FacturaMedidaPrecio = new decimal[1] ;
         P00452_A78FacturaMedidaCantidad = new short[1] ;
         P00452_A74MedidaRin = new string[] {""} ;
         P00452_A28MedidaDescripcion = new string[] {""} ;
         P00452_A77FacturaMedidaID = new int[1] ;
         AV27Option = "";
         P00453_A26MedidaID = new int[1] ;
         P00453_A22ModeloID = new int[1] ;
         P00453_A69FacturaID = new int[1] ;
         P00453_A28MedidaDescripcion = new string[] {""} ;
         P00453_A79FacturaMedidaPrecio = new decimal[1] ;
         P00453_A78FacturaMedidaCantidad = new short[1] ;
         P00453_A74MedidaRin = new string[] {""} ;
         P00453_A23ModeloDescripcion = new string[] {""} ;
         P00453_A77FacturaMedidaID = new int[1] ;
         P00454_A26MedidaID = new int[1] ;
         P00454_A22ModeloID = new int[1] ;
         P00454_A69FacturaID = new int[1] ;
         P00454_A74MedidaRin = new string[] {""} ;
         P00454_A79FacturaMedidaPrecio = new decimal[1] ;
         P00454_A78FacturaMedidaCantidad = new short[1] ;
         P00454_A28MedidaDescripcion = new string[] {""} ;
         P00454_A23ModeloDescripcion = new string[] {""} ;
         P00454_A77FacturaMedidaID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturamedidagetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00452_A26MedidaID, P00452_A22ModeloID, P00452_A69FacturaID, P00452_A23ModeloDescripcion, P00452_A79FacturaMedidaPrecio, P00452_A78FacturaMedidaCantidad, P00452_A74MedidaRin, P00452_A28MedidaDescripcion, P00452_A77FacturaMedidaID
               }
               , new Object[] {
               P00453_A26MedidaID, P00453_A22ModeloID, P00453_A69FacturaID, P00453_A28MedidaDescripcion, P00453_A79FacturaMedidaPrecio, P00453_A78FacturaMedidaCantidad, P00453_A74MedidaRin, P00453_A23ModeloDescripcion, P00453_A77FacturaMedidaID
               }
               , new Object[] {
               P00454_A26MedidaID, P00454_A22ModeloID, P00454_A69FacturaID, P00454_A74MedidaRin, P00454_A79FacturaMedidaPrecio, P00454_A78FacturaMedidaCantidad, P00454_A28MedidaDescripcion, P00454_A23ModeloDescripcion, P00454_A77FacturaMedidaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private short AV18TFFacturaMedidaCantidad ;
      private short AV19TFFacturaMedidaCantidad_To ;
      private short AV56Wpfacturamedidads_9_tffacturamedidacantidad ;
      private short AV57Wpfacturamedidads_10_tffacturamedidacantidad_to ;
      private short A78FacturaMedidaCantidad ;
      private int AV46GXV1 ;
      private int AV10TFFacturaMedidaID ;
      private int AV11TFFacturaMedidaID_To ;
      private int AV48Wpfacturamedidads_1_tffacturamedidaid ;
      private int AV49Wpfacturamedidads_2_tffacturamedidaid_to ;
      private int A77FacturaMedidaID ;
      private int A69FacturaID ;
      private int AV45FacturaID ;
      private int A26MedidaID ;
      private int A22ModeloID ;
      private long AV32count ;
      private decimal AV20TFFacturaMedidaPrecio ;
      private decimal AV21TFFacturaMedidaPrecio_To ;
      private decimal AV58Wpfacturamedidads_11_tffacturamedidaprecio ;
      private decimal AV59Wpfacturamedidads_12_tffacturamedidaprecio_to ;
      private decimal A79FacturaMedidaPrecio ;
      private string AV16TFMedidaRin ;
      private string AV17TFMedidaRin_Sel ;
      private string AV54Wpfacturamedidads_7_tfmedidarin ;
      private string AV55Wpfacturamedidads_8_tfmedidarin_sel ;
      private string lV54Wpfacturamedidads_7_tfmedidarin ;
      private string A74MedidaRin ;
      private bool returnInSub ;
      private bool BRK452 ;
      private bool BRK454 ;
      private bool BRK456 ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV12TFModeloDescripcion ;
      private string AV13TFModeloDescripcion_Sel ;
      private string AV14TFMedidaDescripcion ;
      private string AV15TFMedidaDescripcion_Sel ;
      private string AV50Wpfacturamedidads_3_tfmodelodescripcion ;
      private string AV51Wpfacturamedidads_4_tfmodelodescripcion_sel ;
      private string AV52Wpfacturamedidads_5_tfmedidadescripcion ;
      private string AV53Wpfacturamedidads_6_tfmedidadescripcion_sel ;
      private string lV50Wpfacturamedidads_3_tfmodelodescripcion ;
      private string lV52Wpfacturamedidads_5_tfmedidadescripcion ;
      private string A23ModeloDescripcion ;
      private string A28MedidaDescripcion ;
      private string AV27Option ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV28Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV31OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV35GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P00452_A26MedidaID ;
      private int[] P00452_A22ModeloID ;
      private int[] P00452_A69FacturaID ;
      private string[] P00452_A23ModeloDescripcion ;
      private decimal[] P00452_A79FacturaMedidaPrecio ;
      private short[] P00452_A78FacturaMedidaCantidad ;
      private string[] P00452_A74MedidaRin ;
      private string[] P00452_A28MedidaDescripcion ;
      private int[] P00452_A77FacturaMedidaID ;
      private int[] P00453_A26MedidaID ;
      private int[] P00453_A22ModeloID ;
      private int[] P00453_A69FacturaID ;
      private string[] P00453_A28MedidaDescripcion ;
      private decimal[] P00453_A79FacturaMedidaPrecio ;
      private short[] P00453_A78FacturaMedidaCantidad ;
      private string[] P00453_A74MedidaRin ;
      private string[] P00453_A23ModeloDescripcion ;
      private int[] P00453_A77FacturaMedidaID ;
      private int[] P00454_A26MedidaID ;
      private int[] P00454_A22ModeloID ;
      private int[] P00454_A69FacturaID ;
      private string[] P00454_A74MedidaRin ;
      private decimal[] P00454_A79FacturaMedidaPrecio ;
      private short[] P00454_A78FacturaMedidaCantidad ;
      private string[] P00454_A28MedidaDescripcion ;
      private string[] P00454_A23ModeloDescripcion ;
      private int[] P00454_A77FacturaMedidaID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpfacturamedidagetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00452( IGxContext context ,
                                             int AV48Wpfacturamedidads_1_tffacturamedidaid ,
                                             int AV49Wpfacturamedidads_2_tffacturamedidaid_to ,
                                             string AV51Wpfacturamedidads_4_tfmodelodescripcion_sel ,
                                             string AV50Wpfacturamedidads_3_tfmodelodescripcion ,
                                             string AV53Wpfacturamedidads_6_tfmedidadescripcion_sel ,
                                             string AV52Wpfacturamedidads_5_tfmedidadescripcion ,
                                             string AV55Wpfacturamedidads_8_tfmedidarin_sel ,
                                             string AV54Wpfacturamedidads_7_tfmedidarin ,
                                             short AV56Wpfacturamedidads_9_tffacturamedidacantidad ,
                                             short AV57Wpfacturamedidads_10_tffacturamedidacantidad_to ,
                                             decimal AV58Wpfacturamedidads_11_tffacturamedidaprecio ,
                                             decimal AV59Wpfacturamedidads_12_tffacturamedidaprecio_to ,
                                             int A77FacturaMedidaID ,
                                             string A23ModeloDescripcion ,
                                             string A28MedidaDescripcion ,
                                             string A74MedidaRin ,
                                             short A78FacturaMedidaCantidad ,
                                             decimal A79FacturaMedidaPrecio ,
                                             int A69FacturaID ,
                                             int AV45FacturaID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`MedidaID`, T2.`ModeloID`, T1.`FacturaID`, T3.`ModeloDescripcion`, T1.`FacturaMedidaPrecio`, T1.`FacturaMedidaCantidad`, T2.`MedidaRin`, T2.`MedidaDescripcion`, T1.`FacturaMedidaID` FROM ((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`)";
         AddWhere(sWhereString, "(T1.`FacturaID` = @AV45FacturaID)");
         if ( ! (0==AV48Wpfacturamedidads_1_tffacturamedidaid) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaID` >= @AV48Wpfacturamedidads_1_tffacturamedidaid)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV49Wpfacturamedidads_2_tffacturamedidaid_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaID` <= @AV49Wpfacturamedidads_2_tffacturamedidaid_to)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wpfacturamedidads_4_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wpfacturamedidads_3_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` like @lV50Wpfacturamedidads_3_tfmodelodescripcion)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wpfacturamedidads_4_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV51Wpfacturamedidads_4_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` = @AV51Wpfacturamedidads_4_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wpfacturamedidads_4_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`ModeloDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpfacturamedidads_6_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wpfacturamedidads_5_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` like @lV52Wpfacturamedidads_5_tfmedidadescripcion)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpfacturamedidads_6_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV53Wpfacturamedidads_6_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` = @AV53Wpfacturamedidads_6_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wpfacturamedidads_6_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpfacturamedidads_8_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wpfacturamedidads_7_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` like @lV54Wpfacturamedidads_7_tfmedidarin)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpfacturamedidads_8_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV55Wpfacturamedidads_8_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` = @AV55Wpfacturamedidads_8_tfmedidarin_sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wpfacturamedidads_8_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaRin`))=0))");
         }
         if ( ! (0==AV56Wpfacturamedidads_9_tffacturamedidacantidad) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` >= @AV56Wpfacturamedidads_9_tffacturamedidacantidad)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV57Wpfacturamedidads_10_tffacturamedidacantidad_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` <= @AV57Wpfacturamedidads_10_tffacturamedidacantidad_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV58Wpfacturamedidads_11_tffacturamedidaprecio) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` >= @AV58Wpfacturamedidads_11_tffacturamedidaprecio)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV59Wpfacturamedidads_12_tffacturamedidaprecio_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` <= @AV59Wpfacturamedidads_12_tffacturamedidaprecio_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.`ModeloDescripcion`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00453( IGxContext context ,
                                             int AV48Wpfacturamedidads_1_tffacturamedidaid ,
                                             int AV49Wpfacturamedidads_2_tffacturamedidaid_to ,
                                             string AV51Wpfacturamedidads_4_tfmodelodescripcion_sel ,
                                             string AV50Wpfacturamedidads_3_tfmodelodescripcion ,
                                             string AV53Wpfacturamedidads_6_tfmedidadescripcion_sel ,
                                             string AV52Wpfacturamedidads_5_tfmedidadescripcion ,
                                             string AV55Wpfacturamedidads_8_tfmedidarin_sel ,
                                             string AV54Wpfacturamedidads_7_tfmedidarin ,
                                             short AV56Wpfacturamedidads_9_tffacturamedidacantidad ,
                                             short AV57Wpfacturamedidads_10_tffacturamedidacantidad_to ,
                                             decimal AV58Wpfacturamedidads_11_tffacturamedidaprecio ,
                                             decimal AV59Wpfacturamedidads_12_tffacturamedidaprecio_to ,
                                             int A77FacturaMedidaID ,
                                             string A23ModeloDescripcion ,
                                             string A28MedidaDescripcion ,
                                             string A74MedidaRin ,
                                             short A78FacturaMedidaCantidad ,
                                             decimal A79FacturaMedidaPrecio ,
                                             int A69FacturaID ,
                                             int AV45FacturaID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`MedidaID`, T2.`ModeloID`, T1.`FacturaID`, T2.`MedidaDescripcion`, T1.`FacturaMedidaPrecio`, T1.`FacturaMedidaCantidad`, T2.`MedidaRin`, T3.`ModeloDescripcion`, T1.`FacturaMedidaID` FROM ((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`)";
         AddWhere(sWhereString, "(T1.`FacturaID` = @AV45FacturaID)");
         if ( ! (0==AV48Wpfacturamedidads_1_tffacturamedidaid) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaID` >= @AV48Wpfacturamedidads_1_tffacturamedidaid)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV49Wpfacturamedidads_2_tffacturamedidaid_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaID` <= @AV49Wpfacturamedidads_2_tffacturamedidaid_to)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wpfacturamedidads_4_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wpfacturamedidads_3_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` like @lV50Wpfacturamedidads_3_tfmodelodescripcion)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wpfacturamedidads_4_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV51Wpfacturamedidads_4_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` = @AV51Wpfacturamedidads_4_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wpfacturamedidads_4_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`ModeloDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpfacturamedidads_6_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wpfacturamedidads_5_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` like @lV52Wpfacturamedidads_5_tfmedidadescripcion)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpfacturamedidads_6_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV53Wpfacturamedidads_6_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` = @AV53Wpfacturamedidads_6_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wpfacturamedidads_6_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpfacturamedidads_8_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wpfacturamedidads_7_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` like @lV54Wpfacturamedidads_7_tfmedidarin)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpfacturamedidads_8_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV55Wpfacturamedidads_8_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` = @AV55Wpfacturamedidads_8_tfmedidarin_sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wpfacturamedidads_8_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaRin`))=0))");
         }
         if ( ! (0==AV56Wpfacturamedidads_9_tffacturamedidacantidad) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` >= @AV56Wpfacturamedidads_9_tffacturamedidacantidad)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV57Wpfacturamedidads_10_tffacturamedidacantidad_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` <= @AV57Wpfacturamedidads_10_tffacturamedidacantidad_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV58Wpfacturamedidads_11_tffacturamedidaprecio) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` >= @AV58Wpfacturamedidads_11_tffacturamedidaprecio)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV59Wpfacturamedidads_12_tffacturamedidaprecio_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` <= @AV59Wpfacturamedidads_12_tffacturamedidaprecio_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.`MedidaDescripcion`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00454( IGxContext context ,
                                             int AV48Wpfacturamedidads_1_tffacturamedidaid ,
                                             int AV49Wpfacturamedidads_2_tffacturamedidaid_to ,
                                             string AV51Wpfacturamedidads_4_tfmodelodescripcion_sel ,
                                             string AV50Wpfacturamedidads_3_tfmodelodescripcion ,
                                             string AV53Wpfacturamedidads_6_tfmedidadescripcion_sel ,
                                             string AV52Wpfacturamedidads_5_tfmedidadescripcion ,
                                             string AV55Wpfacturamedidads_8_tfmedidarin_sel ,
                                             string AV54Wpfacturamedidads_7_tfmedidarin ,
                                             short AV56Wpfacturamedidads_9_tffacturamedidacantidad ,
                                             short AV57Wpfacturamedidads_10_tffacturamedidacantidad_to ,
                                             decimal AV58Wpfacturamedidads_11_tffacturamedidaprecio ,
                                             decimal AV59Wpfacturamedidads_12_tffacturamedidaprecio_to ,
                                             int A77FacturaMedidaID ,
                                             string A23ModeloDescripcion ,
                                             string A28MedidaDescripcion ,
                                             string A74MedidaRin ,
                                             short A78FacturaMedidaCantidad ,
                                             decimal A79FacturaMedidaPrecio ,
                                             int A69FacturaID ,
                                             int AV45FacturaID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[13];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`MedidaID`, T2.`ModeloID`, T1.`FacturaID`, T2.`MedidaRin`, T1.`FacturaMedidaPrecio`, T1.`FacturaMedidaCantidad`, T2.`MedidaDescripcion`, T3.`ModeloDescripcion`, T1.`FacturaMedidaID` FROM ((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`)";
         AddWhere(sWhereString, "(T1.`FacturaID` = @AV45FacturaID)");
         if ( ! (0==AV48Wpfacturamedidads_1_tffacturamedidaid) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaID` >= @AV48Wpfacturamedidads_1_tffacturamedidaid)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV49Wpfacturamedidads_2_tffacturamedidaid_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaID` <= @AV49Wpfacturamedidads_2_tffacturamedidaid_to)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wpfacturamedidads_4_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wpfacturamedidads_3_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` like @lV50Wpfacturamedidads_3_tfmodelodescripcion)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wpfacturamedidads_4_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV51Wpfacturamedidads_4_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` = @AV51Wpfacturamedidads_4_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wpfacturamedidads_4_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`ModeloDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpfacturamedidads_6_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wpfacturamedidads_5_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` like @lV52Wpfacturamedidads_5_tfmedidadescripcion)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpfacturamedidads_6_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV53Wpfacturamedidads_6_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` = @AV53Wpfacturamedidads_6_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wpfacturamedidads_6_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpfacturamedidads_8_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wpfacturamedidads_7_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` like @lV54Wpfacturamedidads_7_tfmedidarin)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpfacturamedidads_8_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV55Wpfacturamedidads_8_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` = @AV55Wpfacturamedidads_8_tfmedidarin_sel)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wpfacturamedidads_8_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaRin`))=0))");
         }
         if ( ! (0==AV56Wpfacturamedidads_9_tffacturamedidacantidad) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` >= @AV56Wpfacturamedidads_9_tffacturamedidacantidad)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (0==AV57Wpfacturamedidads_10_tffacturamedidacantidad_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` <= @AV57Wpfacturamedidads_10_tffacturamedidacantidad_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV58Wpfacturamedidads_11_tffacturamedidaprecio) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` >= @AV58Wpfacturamedidads_11_tffacturamedidaprecio)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV59Wpfacturamedidads_12_tffacturamedidaprecio_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` <= @AV59Wpfacturamedidads_12_tffacturamedidaprecio_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.`MedidaRin`";
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
                     return conditional_P00452(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (decimal)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] );
               case 1 :
                     return conditional_P00453(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (decimal)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] );
               case 2 :
                     return conditional_P00454(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (decimal)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] );
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
          Object[] prmP00452;
          prmP00452 = new Object[] {
          new ParDef("@AV45FacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV48Wpfacturamedidads_1_tffacturamedidaid",GXType.Int32,9,0) ,
          new ParDef("@AV49Wpfacturamedidads_2_tffacturamedidaid_to",GXType.Int32,9,0) ,
          new ParDef("@lV50Wpfacturamedidads_3_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV51Wpfacturamedidads_4_tfmodelodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV52Wpfacturamedidads_5_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV53Wpfacturamedidads_6_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV54Wpfacturamedidads_7_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV55Wpfacturamedidads_8_tfmedidarin_sel",GXType.Char,20,0) ,
          new ParDef("@AV56Wpfacturamedidads_9_tffacturamedidacantidad",GXType.Int16,4,0) ,
          new ParDef("@AV57Wpfacturamedidads_10_tffacturamedidacantidad_to",GXType.Int16,4,0) ,
          new ParDef("@AV58Wpfacturamedidads_11_tffacturamedidaprecio",GXType.Number,10,2) ,
          new ParDef("@AV59Wpfacturamedidads_12_tffacturamedidaprecio_to",GXType.Number,10,2)
          };
          Object[] prmP00453;
          prmP00453 = new Object[] {
          new ParDef("@AV45FacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV48Wpfacturamedidads_1_tffacturamedidaid",GXType.Int32,9,0) ,
          new ParDef("@AV49Wpfacturamedidads_2_tffacturamedidaid_to",GXType.Int32,9,0) ,
          new ParDef("@lV50Wpfacturamedidads_3_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV51Wpfacturamedidads_4_tfmodelodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV52Wpfacturamedidads_5_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV53Wpfacturamedidads_6_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV54Wpfacturamedidads_7_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV55Wpfacturamedidads_8_tfmedidarin_sel",GXType.Char,20,0) ,
          new ParDef("@AV56Wpfacturamedidads_9_tffacturamedidacantidad",GXType.Int16,4,0) ,
          new ParDef("@AV57Wpfacturamedidads_10_tffacturamedidacantidad_to",GXType.Int16,4,0) ,
          new ParDef("@AV58Wpfacturamedidads_11_tffacturamedidaprecio",GXType.Number,10,2) ,
          new ParDef("@AV59Wpfacturamedidads_12_tffacturamedidaprecio_to",GXType.Number,10,2)
          };
          Object[] prmP00454;
          prmP00454 = new Object[] {
          new ParDef("@AV45FacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV48Wpfacturamedidads_1_tffacturamedidaid",GXType.Int32,9,0) ,
          new ParDef("@AV49Wpfacturamedidads_2_tffacturamedidaid_to",GXType.Int32,9,0) ,
          new ParDef("@lV50Wpfacturamedidads_3_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV51Wpfacturamedidads_4_tfmodelodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV52Wpfacturamedidads_5_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV53Wpfacturamedidads_6_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV54Wpfacturamedidads_7_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV55Wpfacturamedidads_8_tfmedidarin_sel",GXType.Char,20,0) ,
          new ParDef("@AV56Wpfacturamedidads_9_tffacturamedidacantidad",GXType.Int16,4,0) ,
          new ParDef("@AV57Wpfacturamedidads_10_tffacturamedidacantidad_to",GXType.Int16,4,0) ,
          new ParDef("@AV58Wpfacturamedidads_11_tffacturamedidaprecio",GXType.Number,10,2) ,
          new ParDef("@AV59Wpfacturamedidads_12_tffacturamedidaprecio_to",GXType.Number,10,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00452", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00452,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00453", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00453,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00454", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00454,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
