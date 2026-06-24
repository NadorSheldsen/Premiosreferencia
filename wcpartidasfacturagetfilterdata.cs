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
   public class wcpartidasfacturagetfilterdata : GXProcedure
   {
      public wcpartidasfacturagetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcpartidasfacturagetfilterdata( IGxContext context )
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
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV41OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV26Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23MaxItems = 10;
         AV22PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV37SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV20SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? "" : StringUtil.Substring( AV37SearchTxtParms, 3, -1));
         AV21SkipItems = (short)(AV22PageIndex*AV23MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_MODELODESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADMODELODESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_MEDIDADESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDIDADESCRIPCIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_MEDIDARIN") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDIDARINOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV39OptionsJson = AV26Options.ToJSonString(false);
         AV40OptionsDescJson = AV28OptionsDesc.ToJSonString(false);
         AV41OptionIndexesJson = AV29OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("WCPartidasFacturaGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WCPartidasFacturaGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("WCPartidasFacturaGridState"), null, "", "");
         }
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFMODELODESCRIPCION") == 0 )
            {
               AV10TFModeloDescripcion = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFMODELODESCRIPCION_SEL") == 0 )
            {
               AV11TFModeloDescripcion_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFMEDIDADESCRIPCION") == 0 )
            {
               AV12TFMedidaDescripcion = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFMEDIDADESCRIPCION_SEL") == 0 )
            {
               AV13TFMedidaDescripcion_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFMEDIDARIN") == 0 )
            {
               AV14TFMedidaRin = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFMEDIDARIN_SEL") == 0 )
            {
               AV15TFMedidaRin_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFACTURAMEDIDACANTIDAD") == 0 )
            {
               AV16TFFacturaMedidaCantidad = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV17TFFacturaMedidaCantidad_To = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFACTURAMEDIDAPRECIO") == 0 )
            {
               AV18TFFacturaMedidaPrecio = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV19TFFacturaMedidaPrecio_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMODELODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV10TFModeloDescripcion = AV20SearchTxt;
         AV11TFModeloDescripcion_Sel = "";
         AV46Wcpartidasfacturads_1_tfmodelodescripcion = AV10TFModeloDescripcion;
         AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel = AV11TFModeloDescripcion_Sel;
         AV48Wcpartidasfacturads_3_tfmedidadescripcion = AV12TFMedidaDescripcion;
         AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel = AV13TFMedidaDescripcion_Sel;
         AV50Wcpartidasfacturads_5_tfmedidarin = AV14TFMedidaRin;
         AV51Wcpartidasfacturads_6_tfmedidarin_sel = AV15TFMedidaRin_Sel;
         AV52Wcpartidasfacturads_7_tffacturamedidacantidad = AV16TFFacturaMedidaCantidad;
         AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to = AV17TFFacturaMedidaCantidad_To;
         AV54Wcpartidasfacturads_9_tffacturamedidaprecio = AV18TFFacturaMedidaPrecio;
         AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to = AV19TFFacturaMedidaPrecio_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel ,
                                              AV46Wcpartidasfacturads_1_tfmodelodescripcion ,
                                              AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel ,
                                              AV48Wcpartidasfacturads_3_tfmedidadescripcion ,
                                              AV51Wcpartidasfacturads_6_tfmedidarin_sel ,
                                              AV50Wcpartidasfacturads_5_tfmedidarin ,
                                              AV52Wcpartidasfacturads_7_tffacturamedidacantidad ,
                                              AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to ,
                                              AV54Wcpartidasfacturads_9_tffacturamedidaprecio ,
                                              AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to ,
                                              A23ModeloDescripcion ,
                                              A28MedidaDescripcion ,
                                              A74MedidaRin ,
                                              A78FacturaMedidaCantidad ,
                                              A79FacturaMedidaPrecio ,
                                              A69FacturaID ,
                                              AV43FacturaID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV46Wcpartidasfacturads_1_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV46Wcpartidasfacturads_1_tfmodelodescripcion), "%", "");
         lV48Wcpartidasfacturads_3_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV48Wcpartidasfacturads_3_tfmedidadescripcion), "%", "");
         lV50Wcpartidasfacturads_5_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV50Wcpartidasfacturads_5_tfmedidarin), 20, "%");
         /* Using cursor P003A2 */
         pr_default.execute(0, new Object[] {AV43FacturaID, lV46Wcpartidasfacturads_1_tfmodelodescripcion, AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel, lV48Wcpartidasfacturads_3_tfmedidadescripcion, AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel, lV50Wcpartidasfacturads_5_tfmedidarin, AV51Wcpartidasfacturads_6_tfmedidarin_sel, AV52Wcpartidasfacturads_7_tffacturamedidacantidad, AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to, AV54Wcpartidasfacturads_9_tffacturamedidaprecio, AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3A2 = false;
            A26MedidaID = P003A2_A26MedidaID[0];
            A22ModeloID = P003A2_A22ModeloID[0];
            A69FacturaID = P003A2_A69FacturaID[0];
            A23ModeloDescripcion = P003A2_A23ModeloDescripcion[0];
            A79FacturaMedidaPrecio = P003A2_A79FacturaMedidaPrecio[0];
            A78FacturaMedidaCantidad = P003A2_A78FacturaMedidaCantidad[0];
            A74MedidaRin = P003A2_A74MedidaRin[0];
            A28MedidaDescripcion = P003A2_A28MedidaDescripcion[0];
            A77FacturaMedidaID = P003A2_A77FacturaMedidaID[0];
            A22ModeloID = P003A2_A22ModeloID[0];
            A74MedidaRin = P003A2_A74MedidaRin[0];
            A28MedidaDescripcion = P003A2_A28MedidaDescripcion[0];
            A23ModeloDescripcion = P003A2_A23ModeloDescripcion[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003A2_A23ModeloDescripcion[0], A23ModeloDescripcion) == 0 ) )
            {
               BRK3A2 = false;
               A26MedidaID = P003A2_A26MedidaID[0];
               A22ModeloID = P003A2_A22ModeloID[0];
               A77FacturaMedidaID = P003A2_A77FacturaMedidaID[0];
               A22ModeloID = P003A2_A22ModeloID[0];
               AV30count = (long)(AV30count+1);
               BRK3A2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A23ModeloDescripcion)) ? "<#Empty#>" : A23ModeloDescripcion);
               AV26Options.Add(AV25Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRK3A2 )
            {
               BRK3A2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMEDIDADESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFMedidaDescripcion = AV20SearchTxt;
         AV13TFMedidaDescripcion_Sel = "";
         AV46Wcpartidasfacturads_1_tfmodelodescripcion = AV10TFModeloDescripcion;
         AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel = AV11TFModeloDescripcion_Sel;
         AV48Wcpartidasfacturads_3_tfmedidadescripcion = AV12TFMedidaDescripcion;
         AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel = AV13TFMedidaDescripcion_Sel;
         AV50Wcpartidasfacturads_5_tfmedidarin = AV14TFMedidaRin;
         AV51Wcpartidasfacturads_6_tfmedidarin_sel = AV15TFMedidaRin_Sel;
         AV52Wcpartidasfacturads_7_tffacturamedidacantidad = AV16TFFacturaMedidaCantidad;
         AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to = AV17TFFacturaMedidaCantidad_To;
         AV54Wcpartidasfacturads_9_tffacturamedidaprecio = AV18TFFacturaMedidaPrecio;
         AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to = AV19TFFacturaMedidaPrecio_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel ,
                                              AV46Wcpartidasfacturads_1_tfmodelodescripcion ,
                                              AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel ,
                                              AV48Wcpartidasfacturads_3_tfmedidadescripcion ,
                                              AV51Wcpartidasfacturads_6_tfmedidarin_sel ,
                                              AV50Wcpartidasfacturads_5_tfmedidarin ,
                                              AV52Wcpartidasfacturads_7_tffacturamedidacantidad ,
                                              AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to ,
                                              AV54Wcpartidasfacturads_9_tffacturamedidaprecio ,
                                              AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to ,
                                              A23ModeloDescripcion ,
                                              A28MedidaDescripcion ,
                                              A74MedidaRin ,
                                              A78FacturaMedidaCantidad ,
                                              A79FacturaMedidaPrecio ,
                                              A69FacturaID ,
                                              AV43FacturaID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV46Wcpartidasfacturads_1_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV46Wcpartidasfacturads_1_tfmodelodescripcion), "%", "");
         lV48Wcpartidasfacturads_3_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV48Wcpartidasfacturads_3_tfmedidadescripcion), "%", "");
         lV50Wcpartidasfacturads_5_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV50Wcpartidasfacturads_5_tfmedidarin), 20, "%");
         /* Using cursor P003A3 */
         pr_default.execute(1, new Object[] {AV43FacturaID, lV46Wcpartidasfacturads_1_tfmodelodescripcion, AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel, lV48Wcpartidasfacturads_3_tfmedidadescripcion, AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel, lV50Wcpartidasfacturads_5_tfmedidarin, AV51Wcpartidasfacturads_6_tfmedidarin_sel, AV52Wcpartidasfacturads_7_tffacturamedidacantidad, AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to, AV54Wcpartidasfacturads_9_tffacturamedidaprecio, AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3A4 = false;
            A26MedidaID = P003A3_A26MedidaID[0];
            A22ModeloID = P003A3_A22ModeloID[0];
            A69FacturaID = P003A3_A69FacturaID[0];
            A28MedidaDescripcion = P003A3_A28MedidaDescripcion[0];
            A79FacturaMedidaPrecio = P003A3_A79FacturaMedidaPrecio[0];
            A78FacturaMedidaCantidad = P003A3_A78FacturaMedidaCantidad[0];
            A74MedidaRin = P003A3_A74MedidaRin[0];
            A23ModeloDescripcion = P003A3_A23ModeloDescripcion[0];
            A77FacturaMedidaID = P003A3_A77FacturaMedidaID[0];
            A22ModeloID = P003A3_A22ModeloID[0];
            A28MedidaDescripcion = P003A3_A28MedidaDescripcion[0];
            A74MedidaRin = P003A3_A74MedidaRin[0];
            A23ModeloDescripcion = P003A3_A23ModeloDescripcion[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003A3_A28MedidaDescripcion[0], A28MedidaDescripcion) == 0 ) )
            {
               BRK3A4 = false;
               A26MedidaID = P003A3_A26MedidaID[0];
               A77FacturaMedidaID = P003A3_A77FacturaMedidaID[0];
               AV30count = (long)(AV30count+1);
               BRK3A4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A28MedidaDescripcion)) ? "<#Empty#>" : A28MedidaDescripcion);
               AV26Options.Add(AV25Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRK3A4 )
            {
               BRK3A4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADMEDIDARINOPTIONS' Routine */
         returnInSub = false;
         AV14TFMedidaRin = AV20SearchTxt;
         AV15TFMedidaRin_Sel = "";
         AV46Wcpartidasfacturads_1_tfmodelodescripcion = AV10TFModeloDescripcion;
         AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel = AV11TFModeloDescripcion_Sel;
         AV48Wcpartidasfacturads_3_tfmedidadescripcion = AV12TFMedidaDescripcion;
         AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel = AV13TFMedidaDescripcion_Sel;
         AV50Wcpartidasfacturads_5_tfmedidarin = AV14TFMedidaRin;
         AV51Wcpartidasfacturads_6_tfmedidarin_sel = AV15TFMedidaRin_Sel;
         AV52Wcpartidasfacturads_7_tffacturamedidacantidad = AV16TFFacturaMedidaCantidad;
         AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to = AV17TFFacturaMedidaCantidad_To;
         AV54Wcpartidasfacturads_9_tffacturamedidaprecio = AV18TFFacturaMedidaPrecio;
         AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to = AV19TFFacturaMedidaPrecio_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel ,
                                              AV46Wcpartidasfacturads_1_tfmodelodescripcion ,
                                              AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel ,
                                              AV48Wcpartidasfacturads_3_tfmedidadescripcion ,
                                              AV51Wcpartidasfacturads_6_tfmedidarin_sel ,
                                              AV50Wcpartidasfacturads_5_tfmedidarin ,
                                              AV52Wcpartidasfacturads_7_tffacturamedidacantidad ,
                                              AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to ,
                                              AV54Wcpartidasfacturads_9_tffacturamedidaprecio ,
                                              AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to ,
                                              A23ModeloDescripcion ,
                                              A28MedidaDescripcion ,
                                              A74MedidaRin ,
                                              A78FacturaMedidaCantidad ,
                                              A79FacturaMedidaPrecio ,
                                              A69FacturaID ,
                                              AV43FacturaID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV46Wcpartidasfacturads_1_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV46Wcpartidasfacturads_1_tfmodelodescripcion), "%", "");
         lV48Wcpartidasfacturads_3_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV48Wcpartidasfacturads_3_tfmedidadescripcion), "%", "");
         lV50Wcpartidasfacturads_5_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV50Wcpartidasfacturads_5_tfmedidarin), 20, "%");
         /* Using cursor P003A4 */
         pr_default.execute(2, new Object[] {AV43FacturaID, lV46Wcpartidasfacturads_1_tfmodelodescripcion, AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel, lV48Wcpartidasfacturads_3_tfmedidadescripcion, AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel, lV50Wcpartidasfacturads_5_tfmedidarin, AV51Wcpartidasfacturads_6_tfmedidarin_sel, AV52Wcpartidasfacturads_7_tffacturamedidacantidad, AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to, AV54Wcpartidasfacturads_9_tffacturamedidaprecio, AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK3A6 = false;
            A26MedidaID = P003A4_A26MedidaID[0];
            A22ModeloID = P003A4_A22ModeloID[0];
            A69FacturaID = P003A4_A69FacturaID[0];
            A74MedidaRin = P003A4_A74MedidaRin[0];
            A79FacturaMedidaPrecio = P003A4_A79FacturaMedidaPrecio[0];
            A78FacturaMedidaCantidad = P003A4_A78FacturaMedidaCantidad[0];
            A28MedidaDescripcion = P003A4_A28MedidaDescripcion[0];
            A23ModeloDescripcion = P003A4_A23ModeloDescripcion[0];
            A77FacturaMedidaID = P003A4_A77FacturaMedidaID[0];
            A22ModeloID = P003A4_A22ModeloID[0];
            A74MedidaRin = P003A4_A74MedidaRin[0];
            A28MedidaDescripcion = P003A4_A28MedidaDescripcion[0];
            A23ModeloDescripcion = P003A4_A23ModeloDescripcion[0];
            AV30count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P003A4_A74MedidaRin[0], A74MedidaRin) == 0 ) )
            {
               BRK3A6 = false;
               A26MedidaID = P003A4_A26MedidaID[0];
               A77FacturaMedidaID = P003A4_A77FacturaMedidaID[0];
               AV30count = (long)(AV30count+1);
               BRK3A6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A74MedidaRin)) ? "<#Empty#>" : A74MedidaRin);
               AV26Options.Add(AV25Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRK3A6 )
            {
               BRK3A6 = true;
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
         AV39OptionsJson = "";
         AV40OptionsDescJson = "";
         AV41OptionIndexesJson = "";
         AV26Options = new GxSimpleCollection<string>();
         AV28OptionsDesc = new GxSimpleCollection<string>();
         AV29OptionIndexes = new GxSimpleCollection<string>();
         AV20SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV31Session = context.GetSession();
         AV33GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV34GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV10TFModeloDescripcion = "";
         AV11TFModeloDescripcion_Sel = "";
         AV12TFMedidaDescripcion = "";
         AV13TFMedidaDescripcion_Sel = "";
         AV14TFMedidaRin = "";
         AV15TFMedidaRin_Sel = "";
         AV46Wcpartidasfacturads_1_tfmodelodescripcion = "";
         AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel = "";
         AV48Wcpartidasfacturads_3_tfmedidadescripcion = "";
         AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel = "";
         AV50Wcpartidasfacturads_5_tfmedidarin = "";
         AV51Wcpartidasfacturads_6_tfmedidarin_sel = "";
         lV46Wcpartidasfacturads_1_tfmodelodescripcion = "";
         lV48Wcpartidasfacturads_3_tfmedidadescripcion = "";
         lV50Wcpartidasfacturads_5_tfmedidarin = "";
         A23ModeloDescripcion = "";
         A28MedidaDescripcion = "";
         A74MedidaRin = "";
         P003A2_A26MedidaID = new int[1] ;
         P003A2_A22ModeloID = new int[1] ;
         P003A2_A69FacturaID = new int[1] ;
         P003A2_A23ModeloDescripcion = new string[] {""} ;
         P003A2_A79FacturaMedidaPrecio = new decimal[1] ;
         P003A2_A78FacturaMedidaCantidad = new short[1] ;
         P003A2_A74MedidaRin = new string[] {""} ;
         P003A2_A28MedidaDescripcion = new string[] {""} ;
         P003A2_A77FacturaMedidaID = new int[1] ;
         AV25Option = "";
         P003A3_A26MedidaID = new int[1] ;
         P003A3_A22ModeloID = new int[1] ;
         P003A3_A69FacturaID = new int[1] ;
         P003A3_A28MedidaDescripcion = new string[] {""} ;
         P003A3_A79FacturaMedidaPrecio = new decimal[1] ;
         P003A3_A78FacturaMedidaCantidad = new short[1] ;
         P003A3_A74MedidaRin = new string[] {""} ;
         P003A3_A23ModeloDescripcion = new string[] {""} ;
         P003A3_A77FacturaMedidaID = new int[1] ;
         P003A4_A26MedidaID = new int[1] ;
         P003A4_A22ModeloID = new int[1] ;
         P003A4_A69FacturaID = new int[1] ;
         P003A4_A74MedidaRin = new string[] {""} ;
         P003A4_A79FacturaMedidaPrecio = new decimal[1] ;
         P003A4_A78FacturaMedidaCantidad = new short[1] ;
         P003A4_A28MedidaDescripcion = new string[] {""} ;
         P003A4_A23ModeloDescripcion = new string[] {""} ;
         P003A4_A77FacturaMedidaID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcpartidasfacturagetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003A2_A26MedidaID, P003A2_A22ModeloID, P003A2_A69FacturaID, P003A2_A23ModeloDescripcion, P003A2_A79FacturaMedidaPrecio, P003A2_A78FacturaMedidaCantidad, P003A2_A74MedidaRin, P003A2_A28MedidaDescripcion, P003A2_A77FacturaMedidaID
               }
               , new Object[] {
               P003A3_A26MedidaID, P003A3_A22ModeloID, P003A3_A69FacturaID, P003A3_A28MedidaDescripcion, P003A3_A79FacturaMedidaPrecio, P003A3_A78FacturaMedidaCantidad, P003A3_A74MedidaRin, P003A3_A23ModeloDescripcion, P003A3_A77FacturaMedidaID
               }
               , new Object[] {
               P003A4_A26MedidaID, P003A4_A22ModeloID, P003A4_A69FacturaID, P003A4_A74MedidaRin, P003A4_A79FacturaMedidaPrecio, P003A4_A78FacturaMedidaCantidad, P003A4_A28MedidaDescripcion, P003A4_A23ModeloDescripcion, P003A4_A77FacturaMedidaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23MaxItems ;
      private short AV22PageIndex ;
      private short AV21SkipItems ;
      private short AV16TFFacturaMedidaCantidad ;
      private short AV17TFFacturaMedidaCantidad_To ;
      private short AV52Wcpartidasfacturads_7_tffacturamedidacantidad ;
      private short AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to ;
      private short A78FacturaMedidaCantidad ;
      private int AV44GXV1 ;
      private int A69FacturaID ;
      private int AV43FacturaID ;
      private int A26MedidaID ;
      private int A22ModeloID ;
      private int A77FacturaMedidaID ;
      private long AV30count ;
      private decimal AV18TFFacturaMedidaPrecio ;
      private decimal AV19TFFacturaMedidaPrecio_To ;
      private decimal AV54Wcpartidasfacturads_9_tffacturamedidaprecio ;
      private decimal AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to ;
      private decimal A79FacturaMedidaPrecio ;
      private string AV14TFMedidaRin ;
      private string AV15TFMedidaRin_Sel ;
      private string AV50Wcpartidasfacturads_5_tfmedidarin ;
      private string AV51Wcpartidasfacturads_6_tfmedidarin_sel ;
      private string lV50Wcpartidasfacturads_5_tfmedidarin ;
      private string A74MedidaRin ;
      private bool returnInSub ;
      private bool BRK3A2 ;
      private bool BRK3A4 ;
      private bool BRK3A6 ;
      private string AV39OptionsJson ;
      private string AV40OptionsDescJson ;
      private string AV41OptionIndexesJson ;
      private string AV36DDOName ;
      private string AV37SearchTxtParms ;
      private string AV38SearchTxtTo ;
      private string AV20SearchTxt ;
      private string AV10TFModeloDescripcion ;
      private string AV11TFModeloDescripcion_Sel ;
      private string AV12TFMedidaDescripcion ;
      private string AV13TFMedidaDescripcion_Sel ;
      private string AV46Wcpartidasfacturads_1_tfmodelodescripcion ;
      private string AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel ;
      private string AV48Wcpartidasfacturads_3_tfmedidadescripcion ;
      private string AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel ;
      private string lV46Wcpartidasfacturads_1_tfmodelodescripcion ;
      private string lV48Wcpartidasfacturads_3_tfmedidadescripcion ;
      private string A23ModeloDescripcion ;
      private string A28MedidaDescripcion ;
      private string AV25Option ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV26Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV29OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV33GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P003A2_A26MedidaID ;
      private int[] P003A2_A22ModeloID ;
      private int[] P003A2_A69FacturaID ;
      private string[] P003A2_A23ModeloDescripcion ;
      private decimal[] P003A2_A79FacturaMedidaPrecio ;
      private short[] P003A2_A78FacturaMedidaCantidad ;
      private string[] P003A2_A74MedidaRin ;
      private string[] P003A2_A28MedidaDescripcion ;
      private int[] P003A2_A77FacturaMedidaID ;
      private int[] P003A3_A26MedidaID ;
      private int[] P003A3_A22ModeloID ;
      private int[] P003A3_A69FacturaID ;
      private string[] P003A3_A28MedidaDescripcion ;
      private decimal[] P003A3_A79FacturaMedidaPrecio ;
      private short[] P003A3_A78FacturaMedidaCantidad ;
      private string[] P003A3_A74MedidaRin ;
      private string[] P003A3_A23ModeloDescripcion ;
      private int[] P003A3_A77FacturaMedidaID ;
      private int[] P003A4_A26MedidaID ;
      private int[] P003A4_A22ModeloID ;
      private int[] P003A4_A69FacturaID ;
      private string[] P003A4_A74MedidaRin ;
      private decimal[] P003A4_A79FacturaMedidaPrecio ;
      private short[] P003A4_A78FacturaMedidaCantidad ;
      private string[] P003A4_A28MedidaDescripcion ;
      private string[] P003A4_A23ModeloDescripcion ;
      private int[] P003A4_A77FacturaMedidaID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wcpartidasfacturagetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003A2( IGxContext context ,
                                             string AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel ,
                                             string AV46Wcpartidasfacturads_1_tfmodelodescripcion ,
                                             string AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel ,
                                             string AV48Wcpartidasfacturads_3_tfmedidadescripcion ,
                                             string AV51Wcpartidasfacturads_6_tfmedidarin_sel ,
                                             string AV50Wcpartidasfacturads_5_tfmedidarin ,
                                             short AV52Wcpartidasfacturads_7_tffacturamedidacantidad ,
                                             short AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to ,
                                             decimal AV54Wcpartidasfacturads_9_tffacturamedidaprecio ,
                                             decimal AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to ,
                                             string A23ModeloDescripcion ,
                                             string A28MedidaDescripcion ,
                                             string A74MedidaRin ,
                                             short A78FacturaMedidaCantidad ,
                                             decimal A79FacturaMedidaPrecio ,
                                             int A69FacturaID ,
                                             int AV43FacturaID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`MedidaID`, T2.`ModeloID`, T1.`FacturaID`, T3.`ModeloDescripcion`, T1.`FacturaMedidaPrecio`, T1.`FacturaMedidaCantidad`, T2.`MedidaRin`, T2.`MedidaDescripcion`, T1.`FacturaMedidaID` FROM ((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`)";
         AddWhere(sWhereString, "(T1.`FacturaID` = @AV43FacturaID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wcpartidasfacturads_1_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` like @lV46Wcpartidasfacturads_1_tfmodelodescripcion)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` = @AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`ModeloDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wcpartidasfacturads_3_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` like @lV48Wcpartidasfacturads_3_tfmedidadescripcion)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` = @AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wcpartidasfacturads_6_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wcpartidasfacturads_5_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` like @lV50Wcpartidasfacturads_5_tfmedidarin)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wcpartidasfacturads_6_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV51Wcpartidasfacturads_6_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` = @AV51Wcpartidasfacturads_6_tfmedidarin_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wcpartidasfacturads_6_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaRin`))=0))");
         }
         if ( ! (0==AV52Wcpartidasfacturads_7_tffacturamedidacantidad) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` >= @AV52Wcpartidasfacturads_7_tffacturamedidacantidad)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` <= @AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV54Wcpartidasfacturads_9_tffacturamedidaprecio) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` >= @AV54Wcpartidasfacturads_9_tffacturamedidaprecio)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` <= @AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.`ModeloDescripcion`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003A3( IGxContext context ,
                                             string AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel ,
                                             string AV46Wcpartidasfacturads_1_tfmodelodescripcion ,
                                             string AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel ,
                                             string AV48Wcpartidasfacturads_3_tfmedidadescripcion ,
                                             string AV51Wcpartidasfacturads_6_tfmedidarin_sel ,
                                             string AV50Wcpartidasfacturads_5_tfmedidarin ,
                                             short AV52Wcpartidasfacturads_7_tffacturamedidacantidad ,
                                             short AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to ,
                                             decimal AV54Wcpartidasfacturads_9_tffacturamedidaprecio ,
                                             decimal AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to ,
                                             string A23ModeloDescripcion ,
                                             string A28MedidaDescripcion ,
                                             string A74MedidaRin ,
                                             short A78FacturaMedidaCantidad ,
                                             decimal A79FacturaMedidaPrecio ,
                                             int A69FacturaID ,
                                             int AV43FacturaID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`MedidaID`, T2.`ModeloID`, T1.`FacturaID`, T2.`MedidaDescripcion`, T1.`FacturaMedidaPrecio`, T1.`FacturaMedidaCantidad`, T2.`MedidaRin`, T3.`ModeloDescripcion`, T1.`FacturaMedidaID` FROM ((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`)";
         AddWhere(sWhereString, "(T1.`FacturaID` = @AV43FacturaID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wcpartidasfacturads_1_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` like @lV46Wcpartidasfacturads_1_tfmodelodescripcion)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` = @AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( StringUtil.StrCmp(AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`ModeloDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wcpartidasfacturads_3_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` like @lV48Wcpartidasfacturads_3_tfmedidadescripcion)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` = @AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wcpartidasfacturads_6_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wcpartidasfacturads_5_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` like @lV50Wcpartidasfacturads_5_tfmedidarin)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wcpartidasfacturads_6_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV51Wcpartidasfacturads_6_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` = @AV51Wcpartidasfacturads_6_tfmedidarin_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wcpartidasfacturads_6_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaRin`))=0))");
         }
         if ( ! (0==AV52Wcpartidasfacturads_7_tffacturamedidacantidad) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` >= @AV52Wcpartidasfacturads_7_tffacturamedidacantidad)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` <= @AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV54Wcpartidasfacturads_9_tffacturamedidaprecio) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` >= @AV54Wcpartidasfacturads_9_tffacturamedidaprecio)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` <= @AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.`MedidaDescripcion`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P003A4( IGxContext context ,
                                             string AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel ,
                                             string AV46Wcpartidasfacturads_1_tfmodelodescripcion ,
                                             string AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel ,
                                             string AV48Wcpartidasfacturads_3_tfmedidadescripcion ,
                                             string AV51Wcpartidasfacturads_6_tfmedidarin_sel ,
                                             string AV50Wcpartidasfacturads_5_tfmedidarin ,
                                             short AV52Wcpartidasfacturads_7_tffacturamedidacantidad ,
                                             short AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to ,
                                             decimal AV54Wcpartidasfacturads_9_tffacturamedidaprecio ,
                                             decimal AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to ,
                                             string A23ModeloDescripcion ,
                                             string A28MedidaDescripcion ,
                                             string A74MedidaRin ,
                                             short A78FacturaMedidaCantidad ,
                                             decimal A79FacturaMedidaPrecio ,
                                             int A69FacturaID ,
                                             int AV43FacturaID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[11];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`MedidaID`, T2.`ModeloID`, T1.`FacturaID`, T2.`MedidaRin`, T1.`FacturaMedidaPrecio`, T1.`FacturaMedidaCantidad`, T2.`MedidaDescripcion`, T3.`ModeloDescripcion`, T1.`FacturaMedidaID` FROM ((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`)";
         AddWhere(sWhereString, "(T1.`FacturaID` = @AV43FacturaID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wcpartidasfacturads_1_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` like @lV46Wcpartidasfacturads_1_tfmodelodescripcion)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` = @AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( StringUtil.StrCmp(AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`ModeloDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wcpartidasfacturads_3_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` like @lV48Wcpartidasfacturads_3_tfmedidadescripcion)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` = @AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wcpartidasfacturads_6_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wcpartidasfacturads_5_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` like @lV50Wcpartidasfacturads_5_tfmedidarin)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wcpartidasfacturads_6_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV51Wcpartidasfacturads_6_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` = @AV51Wcpartidasfacturads_6_tfmedidarin_sel)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wcpartidasfacturads_6_tfmedidarin_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaRin`))=0))");
         }
         if ( ! (0==AV52Wcpartidasfacturads_7_tffacturamedidacantidad) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` >= @AV52Wcpartidasfacturads_7_tffacturamedidacantidad)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` <= @AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV54Wcpartidasfacturads_9_tffacturamedidaprecio) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` >= @AV54Wcpartidasfacturads_9_tffacturamedidaprecio)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` <= @AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to)");
         }
         else
         {
            GXv_int5[10] = 1;
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
                     return conditional_P003A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] );
               case 1 :
                     return conditional_P003A3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] );
               case 2 :
                     return conditional_P003A4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] );
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
          Object[] prmP003A2;
          prmP003A2 = new Object[] {
          new ParDef("@AV43FacturaID",GXType.Int32,9,0) ,
          new ParDef("@lV46Wcpartidasfacturads_1_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV48Wcpartidasfacturads_3_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV50Wcpartidasfacturads_5_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV51Wcpartidasfacturads_6_tfmedidarin_sel",GXType.Char,20,0) ,
          new ParDef("@AV52Wcpartidasfacturads_7_tffacturamedidacantidad",GXType.Int16,4,0) ,
          new ParDef("@AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to",GXType.Int16,4,0) ,
          new ParDef("@AV54Wcpartidasfacturads_9_tffacturamedidaprecio",GXType.Number,10,2) ,
          new ParDef("@AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to",GXType.Number,10,2)
          };
          Object[] prmP003A3;
          prmP003A3 = new Object[] {
          new ParDef("@AV43FacturaID",GXType.Int32,9,0) ,
          new ParDef("@lV46Wcpartidasfacturads_1_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV48Wcpartidasfacturads_3_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV50Wcpartidasfacturads_5_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV51Wcpartidasfacturads_6_tfmedidarin_sel",GXType.Char,20,0) ,
          new ParDef("@AV52Wcpartidasfacturads_7_tffacturamedidacantidad",GXType.Int16,4,0) ,
          new ParDef("@AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to",GXType.Int16,4,0) ,
          new ParDef("@AV54Wcpartidasfacturads_9_tffacturamedidaprecio",GXType.Number,10,2) ,
          new ParDef("@AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to",GXType.Number,10,2)
          };
          Object[] prmP003A4;
          prmP003A4 = new Object[] {
          new ParDef("@AV43FacturaID",GXType.Int32,9,0) ,
          new ParDef("@lV46Wcpartidasfacturads_1_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV47Wcpartidasfacturads_2_tfmodelodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV48Wcpartidasfacturads_3_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV49Wcpartidasfacturads_4_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV50Wcpartidasfacturads_5_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV51Wcpartidasfacturads_6_tfmedidarin_sel",GXType.Char,20,0) ,
          new ParDef("@AV52Wcpartidasfacturads_7_tffacturamedidacantidad",GXType.Int16,4,0) ,
          new ParDef("@AV53Wcpartidasfacturads_8_tffacturamedidacantidad_to",GXType.Int16,4,0) ,
          new ParDef("@AV54Wcpartidasfacturads_9_tffacturamedidaprecio",GXType.Number,10,2) ,
          new ParDef("@AV55Wcpartidasfacturads_10_tffacturamedidaprecio_to",GXType.Number,10,2)
          };
          def= new CursorDef[] {
              new CursorDef("P003A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003A2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003A3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003A4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003A4,100, GxCacheFrequency.OFF ,true,false )
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
