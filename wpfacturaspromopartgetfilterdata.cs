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
   public class wpfacturaspromopartgetfilterdata : GXProcedure
   {
      public wpfacturaspromopartgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfacturaspromopartgetfilterdata( IGxContext context )
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
         this.AV58DDOName = aP0_DDOName;
         this.AV59SearchTxtParms = aP1_SearchTxtParms;
         this.AV60SearchTxtTo = aP2_SearchTxtTo;
         this.AV61OptionsJson = "" ;
         this.AV62OptionsDescJson = "" ;
         this.AV63OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV61OptionsJson;
         aP4_OptionsDescJson=this.AV62OptionsDescJson;
         aP5_OptionIndexesJson=this.AV63OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV63OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV58DDOName = aP0_DDOName;
         this.AV59SearchTxtParms = aP1_SearchTxtParms;
         this.AV60SearchTxtTo = aP2_SearchTxtTo;
         this.AV61OptionsJson = "" ;
         this.AV62OptionsDescJson = "" ;
         this.AV63OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV61OptionsJson;
         aP4_OptionsDescJson=this.AV62OptionsDescJson;
         aP5_OptionIndexesJson=this.AV63OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV48Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV50OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV51OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV45MaxItems = 10;
         AV44PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV59SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV59SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV42SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV59SearchTxtParms)) ? "" : StringUtil.Substring( AV59SearchTxtParms, 3, -1));
         AV43SkipItems = (short)(AV44PageIndex*AV45MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV58DDOName), "DDO_PROMOCIONDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV58DDOName), "DDO_FACTURANO") == 0 )
         {
            /* Execute user subroutine: 'LOADFACTURANOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV58DDOName), "DDO_USUARIONOMBRECOMPLETO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIONOMBRECOMPLETOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV61OptionsJson = AV48Options.ToJSonString(false);
         AV62OptionsDescJson = AV50OptionsDesc.ToJSonString(false);
         AV63OptionIndexesJson = AV51OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV53Session.Get("WPFacturasPromoPartGridState"), "") == 0 )
         {
            AV55GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPFacturasPromoPartGridState"), null, "", "");
         }
         else
         {
            AV55GridState.FromXml(AV53Session.Get("WPFacturasPromoPartGridState"), null, "", "");
         }
         AV72GXV1 = 1;
         while ( AV72GXV1 <= AV55GridState.gxTpr_Filtervalues.Count )
         {
            AV56GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV55GridState.gxTpr_Filtervalues.Item(AV72GXV1));
            if ( StringUtil.StrCmp(AV56GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV64FilterFullText = AV56GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV56GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV24TFFacturaFechaRegistro = context.localUtil.CToD( AV56GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV25TFFacturaFechaRegistro_To = context.localUtil.CToD( AV56GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV56GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV14TFPromocionDescripcion = AV56GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV56GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV15TFPromocionDescripcion_Sel = AV56GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV56GridStateFilterValue.gxTpr_Name, "TFFACTURANO") == 0 )
            {
               AV20TFFacturaNo = AV56GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV56GridStateFilterValue.gxTpr_Name, "TFFACTURANO_SEL") == 0 )
            {
               AV21TFFacturaNo_Sel = AV56GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV56GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV22TFFacturaFechaFactura = context.localUtil.CToD( AV56GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV23TFFacturaFechaFactura_To = context.localUtil.CToD( AV56GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV56GridStateFilterValue.gxTpr_Name, "TFESTATUS") == 0 )
            {
               AV67TFEstatusOperator = AV56GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV56GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV28TFUsuarioNombreCompleto = AV56GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV56GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV29TFUsuarioNombreCompleto_Sel = AV56GridStateFilterValue.gxTpr_Value;
            }
            AV72GXV1 = (int)(AV72GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROMOCIONDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFPromocionDescripcion = AV42SearchTxt;
         AV15TFPromocionDescripcion_Sel = "";
         AV74Wpfacturaspromopartds_1_filterfulltext = AV64FilterFullText;
         AV75Wpfacturaspromopartds_2_tffacturafecharegistro = AV24TFFacturaFechaRegistro;
         AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to = AV25TFFacturaFechaRegistro_To;
         AV77Wpfacturaspromopartds_4_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV79Wpfacturaspromopartds_6_tffacturano = AV20TFFacturaNo;
         AV80Wpfacturaspromopartds_7_tffacturano_sel = AV21TFFacturaNo_Sel;
         AV81Wpfacturaspromopartds_8_tffacturafechafactura = AV22TFFacturaFechaFactura;
         AV82Wpfacturaspromopartds_9_tffacturafechafactura_to = AV23TFFacturaFechaFactura_To;
         AV83Wpfacturaspromopartds_10_tfestatus = AV66TFEstatus;
         AV84Wpfacturaspromopartds_11_tfestatusoperator = AV67TFEstatusOperator;
         AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto = AV28TFUsuarioNombreCompleto;
         AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = AV29TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV71ListaUsuarios ,
                                              AV74Wpfacturaspromopartds_1_filterfulltext ,
                                              AV75Wpfacturaspromopartds_2_tffacturafecharegistro ,
                                              AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to ,
                                              AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel ,
                                              AV77Wpfacturaspromopartds_4_tfpromociondescripcion ,
                                              AV80Wpfacturaspromopartds_7_tffacturano_sel ,
                                              AV79Wpfacturaspromopartds_6_tffacturano ,
                                              AV81Wpfacturaspromopartds_8_tffacturafechafactura ,
                                              AV82Wpfacturaspromopartds_9_tffacturafechafactura_to ,
                                              AV84Wpfacturaspromopartds_11_tfestatusoperator ,
                                              AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ,
                                              AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto ,
                                              AV69FromDate ,
                                              AV70ToDate ,
                                              AV71ListaUsuarios.Count ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A93FacturaCompleta ,
                                              AV65PromocionID ,
                                              A41PromocionID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV74Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV74Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV74Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV77Wpfacturaspromopartds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV77Wpfacturaspromopartds_4_tfpromociondescripcion), "%", "");
         lV79Wpfacturaspromopartds_6_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV79Wpfacturaspromopartds_6_tffacturano), 20, "%");
         lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto), "%", "");
         /* Using cursor P002X2 */
         pr_default.execute(0, new Object[] {AV65PromocionID, lV74Wpfacturaspromopartds_1_filterfulltext, lV74Wpfacturaspromopartds_1_filterfulltext, lV74Wpfacturaspromopartds_1_filterfulltext, AV75Wpfacturaspromopartds_2_tffacturafecharegistro, AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to, lV77Wpfacturaspromopartds_4_tfpromociondescripcion, AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel, lV79Wpfacturaspromopartds_6_tffacturano, AV80Wpfacturaspromopartds_7_tffacturano_sel, AV81Wpfacturaspromopartds_8_tffacturafechafactura, AV82Wpfacturaspromopartds_9_tffacturafechafactura_to, lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto, AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, AV69FromDate, AV70ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2X2 = false;
            A41PromocionID = P002X2_A41PromocionID[0];
            A93FacturaCompleta = P002X2_A93FacturaCompleta[0];
            A29UsuarioID = P002X2_A29UsuarioID[0];
            A80FacturaEstatus = P002X2_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P002X2_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P002X2_A72FacturaFechaRegistro[0];
            A71FacturaNo = P002X2_A71FacturaNo[0];
            A42PromocionDescripcion = P002X2_A42PromocionDescripcion[0];
            A51UsuarioApellido = P002X2_A51UsuarioApellido[0];
            A30UsuarioNombre = P002X2_A30UsuarioNombre[0];
            A69FacturaID = P002X2_A69FacturaID[0];
            A42PromocionDescripcion = P002X2_A42PromocionDescripcion[0];
            A51UsuarioApellido = P002X2_A51UsuarioApellido[0];
            A30UsuarioNombre = P002X2_A30UsuarioNombre[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV52count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P002X2_A41PromocionID[0] == A41PromocionID ) )
            {
               BRK2X2 = false;
               A69FacturaID = P002X2_A69FacturaID[0];
               AV52count = (long)(AV52count+1);
               BRK2X2 = true;
               pr_default.readNext(0);
            }
            AV47Option = (String.IsNullOrEmpty(StringUtil.RTrim( A42PromocionDescripcion)) ? "<#Empty#>" : A42PromocionDescripcion);
            AV46InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV47Option, "<#Empty#>") != 0 ) && ( AV46InsertIndex <= AV48Options.Count ) && ( ( StringUtil.StrCmp(((string)AV48Options.Item(AV46InsertIndex)), AV47Option) < 0 ) || ( StringUtil.StrCmp(((string)AV48Options.Item(AV46InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV46InsertIndex = (int)(AV46InsertIndex+1);
            }
            AV48Options.Add(AV47Option, AV46InsertIndex);
            AV51OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV52count), "Z,ZZZ,ZZZ,ZZ9")), AV46InsertIndex);
            if ( AV48Options.Count == AV43SkipItems + 11 )
            {
               AV48Options.RemoveItem(AV48Options.Count);
               AV51OptionIndexes.RemoveItem(AV51OptionIndexes.Count);
            }
            if ( ! BRK2X2 )
            {
               BRK2X2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV43SkipItems > 0 )
         {
            AV48Options.RemoveItem(1);
            AV51OptionIndexes.RemoveItem(1);
            AV43SkipItems = (short)(AV43SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADFACTURANOOPTIONS' Routine */
         returnInSub = false;
         AV20TFFacturaNo = AV42SearchTxt;
         AV21TFFacturaNo_Sel = "";
         AV74Wpfacturaspromopartds_1_filterfulltext = AV64FilterFullText;
         AV75Wpfacturaspromopartds_2_tffacturafecharegistro = AV24TFFacturaFechaRegistro;
         AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to = AV25TFFacturaFechaRegistro_To;
         AV77Wpfacturaspromopartds_4_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV79Wpfacturaspromopartds_6_tffacturano = AV20TFFacturaNo;
         AV80Wpfacturaspromopartds_7_tffacturano_sel = AV21TFFacturaNo_Sel;
         AV81Wpfacturaspromopartds_8_tffacturafechafactura = AV22TFFacturaFechaFactura;
         AV82Wpfacturaspromopartds_9_tffacturafechafactura_to = AV23TFFacturaFechaFactura_To;
         AV83Wpfacturaspromopartds_10_tfestatus = AV66TFEstatus;
         AV84Wpfacturaspromopartds_11_tfestatusoperator = AV67TFEstatusOperator;
         AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto = AV28TFUsuarioNombreCompleto;
         AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = AV29TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV71ListaUsuarios ,
                                              AV74Wpfacturaspromopartds_1_filterfulltext ,
                                              AV75Wpfacturaspromopartds_2_tffacturafecharegistro ,
                                              AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to ,
                                              AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel ,
                                              AV77Wpfacturaspromopartds_4_tfpromociondescripcion ,
                                              AV80Wpfacturaspromopartds_7_tffacturano_sel ,
                                              AV79Wpfacturaspromopartds_6_tffacturano ,
                                              AV81Wpfacturaspromopartds_8_tffacturafechafactura ,
                                              AV82Wpfacturaspromopartds_9_tffacturafechafactura_to ,
                                              AV84Wpfacturaspromopartds_11_tfestatusoperator ,
                                              AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ,
                                              AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto ,
                                              AV69FromDate ,
                                              AV70ToDate ,
                                              AV71ListaUsuarios.Count ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A41PromocionID ,
                                              AV65PromocionID ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV74Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV74Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV77Wpfacturaspromopartds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV77Wpfacturaspromopartds_4_tfpromociondescripcion), "%", "");
         lV79Wpfacturaspromopartds_6_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV79Wpfacturaspromopartds_6_tffacturano), 20, "%");
         lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto), "%", "");
         /* Using cursor P002X3 */
         pr_default.execute(1, new Object[] {AV65PromocionID, lV74Wpfacturaspromopartds_1_filterfulltext, lV74Wpfacturaspromopartds_1_filterfulltext, lV74Wpfacturaspromopartds_1_filterfulltext, AV75Wpfacturaspromopartds_2_tffacturafecharegistro, AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to, lV77Wpfacturaspromopartds_4_tfpromociondescripcion, AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel, lV79Wpfacturaspromopartds_6_tffacturano, AV80Wpfacturaspromopartds_7_tffacturano_sel, AV81Wpfacturaspromopartds_8_tffacturafechafactura, AV82Wpfacturaspromopartds_9_tffacturafechafactura_to, lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto, AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, AV69FromDate, AV70ToDate});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2X4 = false;
            A71FacturaNo = P002X3_A71FacturaNo[0];
            A93FacturaCompleta = P002X3_A93FacturaCompleta[0];
            A29UsuarioID = P002X3_A29UsuarioID[0];
            A41PromocionID = P002X3_A41PromocionID[0];
            A80FacturaEstatus = P002X3_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P002X3_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P002X3_A72FacturaFechaRegistro[0];
            A42PromocionDescripcion = P002X3_A42PromocionDescripcion[0];
            A51UsuarioApellido = P002X3_A51UsuarioApellido[0];
            A30UsuarioNombre = P002X3_A30UsuarioNombre[0];
            A69FacturaID = P002X3_A69FacturaID[0];
            A51UsuarioApellido = P002X3_A51UsuarioApellido[0];
            A30UsuarioNombre = P002X3_A30UsuarioNombre[0];
            A42PromocionDescripcion = P002X3_A42PromocionDescripcion[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV52count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002X3_A71FacturaNo[0], A71FacturaNo) == 0 ) )
            {
               BRK2X4 = false;
               A69FacturaID = P002X3_A69FacturaID[0];
               AV52count = (long)(AV52count+1);
               BRK2X4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV43SkipItems) )
            {
               AV47Option = (String.IsNullOrEmpty(StringUtil.RTrim( A71FacturaNo)) ? "<#Empty#>" : A71FacturaNo);
               AV48Options.Add(AV47Option, 0);
               AV51OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV52count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV48Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV43SkipItems = (short)(AV43SkipItems-1);
            }
            if ( ! BRK2X4 )
            {
               BRK2X4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADUSUARIONOMBRECOMPLETOOPTIONS' Routine */
         returnInSub = false;
         AV28TFUsuarioNombreCompleto = AV42SearchTxt;
         AV29TFUsuarioNombreCompleto_Sel = "";
         AV74Wpfacturaspromopartds_1_filterfulltext = AV64FilterFullText;
         AV75Wpfacturaspromopartds_2_tffacturafecharegistro = AV24TFFacturaFechaRegistro;
         AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to = AV25TFFacturaFechaRegistro_To;
         AV77Wpfacturaspromopartds_4_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV79Wpfacturaspromopartds_6_tffacturano = AV20TFFacturaNo;
         AV80Wpfacturaspromopartds_7_tffacturano_sel = AV21TFFacturaNo_Sel;
         AV81Wpfacturaspromopartds_8_tffacturafechafactura = AV22TFFacturaFechaFactura;
         AV82Wpfacturaspromopartds_9_tffacturafechafactura_to = AV23TFFacturaFechaFactura_To;
         AV83Wpfacturaspromopartds_10_tfestatus = AV66TFEstatus;
         AV84Wpfacturaspromopartds_11_tfestatusoperator = AV67TFEstatusOperator;
         AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto = AV28TFUsuarioNombreCompleto;
         AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = AV29TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV71ListaUsuarios ,
                                              AV74Wpfacturaspromopartds_1_filterfulltext ,
                                              AV75Wpfacturaspromopartds_2_tffacturafecharegistro ,
                                              AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to ,
                                              AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel ,
                                              AV77Wpfacturaspromopartds_4_tfpromociondescripcion ,
                                              AV80Wpfacturaspromopartds_7_tffacturano_sel ,
                                              AV79Wpfacturaspromopartds_6_tffacturano ,
                                              AV81Wpfacturaspromopartds_8_tffacturafechafactura ,
                                              AV82Wpfacturaspromopartds_9_tffacturafechafactura_to ,
                                              AV84Wpfacturaspromopartds_11_tfestatusoperator ,
                                              AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ,
                                              AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto ,
                                              AV69FromDate ,
                                              AV70ToDate ,
                                              AV71ListaUsuarios.Count ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A41PromocionID ,
                                              AV65PromocionID ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV74Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV74Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV77Wpfacturaspromopartds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV77Wpfacturaspromopartds_4_tfpromociondescripcion), "%", "");
         lV79Wpfacturaspromopartds_6_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV79Wpfacturaspromopartds_6_tffacturano), 20, "%");
         lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto), "%", "");
         /* Using cursor P002X4 */
         pr_default.execute(2, new Object[] {AV65PromocionID, lV74Wpfacturaspromopartds_1_filterfulltext, lV74Wpfacturaspromopartds_1_filterfulltext, lV74Wpfacturaspromopartds_1_filterfulltext, AV75Wpfacturaspromopartds_2_tffacturafecharegistro, AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to, lV77Wpfacturaspromopartds_4_tfpromociondescripcion, AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel, lV79Wpfacturaspromopartds_6_tffacturano, AV80Wpfacturaspromopartds_7_tffacturano_sel, AV81Wpfacturaspromopartds_8_tffacturafechafactura, AV82Wpfacturaspromopartds_9_tffacturafechafactura_to, lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto, AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, AV69FromDate, AV70ToDate});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2X6 = false;
            A29UsuarioID = P002X4_A29UsuarioID[0];
            A93FacturaCompleta = P002X4_A93FacturaCompleta[0];
            A41PromocionID = P002X4_A41PromocionID[0];
            A80FacturaEstatus = P002X4_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P002X4_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P002X4_A72FacturaFechaRegistro[0];
            A71FacturaNo = P002X4_A71FacturaNo[0];
            A42PromocionDescripcion = P002X4_A42PromocionDescripcion[0];
            A51UsuarioApellido = P002X4_A51UsuarioApellido[0];
            A30UsuarioNombre = P002X4_A30UsuarioNombre[0];
            A69FacturaID = P002X4_A69FacturaID[0];
            A51UsuarioApellido = P002X4_A51UsuarioApellido[0];
            A30UsuarioNombre = P002X4_A30UsuarioNombre[0];
            A42PromocionDescripcion = P002X4_A42PromocionDescripcion[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV52count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P002X4_A29UsuarioID[0] == A29UsuarioID ) )
            {
               BRK2X6 = false;
               A69FacturaID = P002X4_A69FacturaID[0];
               AV52count = (long)(AV52count+1);
               BRK2X6 = true;
               pr_default.readNext(2);
            }
            AV47Option = (String.IsNullOrEmpty(StringUtil.RTrim( A52UsuarioNombreCompleto)) ? "<#Empty#>" : A52UsuarioNombreCompleto);
            AV46InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV47Option, "<#Empty#>") != 0 ) && ( AV46InsertIndex <= AV48Options.Count ) && ( ( StringUtil.StrCmp(((string)AV48Options.Item(AV46InsertIndex)), AV47Option) < 0 ) || ( StringUtil.StrCmp(((string)AV48Options.Item(AV46InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV46InsertIndex = (int)(AV46InsertIndex+1);
            }
            AV48Options.Add(AV47Option, AV46InsertIndex);
            AV51OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV52count), "Z,ZZZ,ZZZ,ZZ9")), AV46InsertIndex);
            if ( AV48Options.Count == AV43SkipItems + 11 )
            {
               AV48Options.RemoveItem(AV48Options.Count);
               AV51OptionIndexes.RemoveItem(AV51OptionIndexes.Count);
            }
            if ( ! BRK2X6 )
            {
               BRK2X6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV43SkipItems > 0 )
         {
            AV48Options.RemoveItem(1);
            AV51OptionIndexes.RemoveItem(1);
            AV43SkipItems = (short)(AV43SkipItems-1);
         }
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
         AV61OptionsJson = "";
         AV62OptionsDescJson = "";
         AV63OptionIndexesJson = "";
         AV48Options = new GxSimpleCollection<string>();
         AV50OptionsDesc = new GxSimpleCollection<string>();
         AV51OptionIndexes = new GxSimpleCollection<string>();
         AV42SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV53Session = context.GetSession();
         AV55GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV56GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV64FilterFullText = "";
         AV24TFFacturaFechaRegistro = DateTime.MinValue;
         AV25TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV14TFPromocionDescripcion = "";
         AV15TFPromocionDescripcion_Sel = "";
         AV20TFFacturaNo = "";
         AV21TFFacturaNo_Sel = "";
         AV22TFFacturaFechaFactura = DateTime.MinValue;
         AV23TFFacturaFechaFactura_To = DateTime.MinValue;
         AV28TFUsuarioNombreCompleto = "";
         AV29TFUsuarioNombreCompleto_Sel = "";
         AV74Wpfacturaspromopartds_1_filterfulltext = "";
         AV75Wpfacturaspromopartds_2_tffacturafecharegistro = DateTime.MinValue;
         AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to = DateTime.MinValue;
         AV77Wpfacturaspromopartds_4_tfpromociondescripcion = "";
         AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel = "";
         AV79Wpfacturaspromopartds_6_tffacturano = "";
         AV80Wpfacturaspromopartds_7_tffacturano_sel = "";
         AV81Wpfacturaspromopartds_8_tffacturafechafactura = DateTime.MinValue;
         AV82Wpfacturaspromopartds_9_tffacturafechafactura_to = DateTime.MinValue;
         AV83Wpfacturaspromopartds_10_tfestatus = "";
         AV66TFEstatus = "";
         AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto = "";
         AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = "";
         AV71ListaUsuarios = new GxSimpleCollection<int>();
         lV74Wpfacturaspromopartds_1_filterfulltext = "";
         lV77Wpfacturaspromopartds_4_tfpromociondescripcion = "";
         lV79Wpfacturaspromopartds_6_tffacturano = "";
         lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto = "";
         AV69FromDate = DateTime.MinValue;
         AV70ToDate = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A71FacturaNo = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A73FacturaFechaFactura = DateTime.MinValue;
         A80FacturaEstatus = "";
         P002X2_A41PromocionID = new int[1] ;
         P002X2_A93FacturaCompleta = new bool[] {false} ;
         P002X2_A29UsuarioID = new int[1] ;
         P002X2_A80FacturaEstatus = new string[] {""} ;
         P002X2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P002X2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P002X2_A71FacturaNo = new string[] {""} ;
         P002X2_A42PromocionDescripcion = new string[] {""} ;
         P002X2_A51UsuarioApellido = new string[] {""} ;
         P002X2_A30UsuarioNombre = new string[] {""} ;
         P002X2_A69FacturaID = new int[1] ;
         A52UsuarioNombreCompleto = "";
         AV47Option = "";
         P002X3_A71FacturaNo = new string[] {""} ;
         P002X3_A93FacturaCompleta = new bool[] {false} ;
         P002X3_A29UsuarioID = new int[1] ;
         P002X3_A41PromocionID = new int[1] ;
         P002X3_A80FacturaEstatus = new string[] {""} ;
         P002X3_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P002X3_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P002X3_A42PromocionDescripcion = new string[] {""} ;
         P002X3_A51UsuarioApellido = new string[] {""} ;
         P002X3_A30UsuarioNombre = new string[] {""} ;
         P002X3_A69FacturaID = new int[1] ;
         P002X4_A29UsuarioID = new int[1] ;
         P002X4_A93FacturaCompleta = new bool[] {false} ;
         P002X4_A41PromocionID = new int[1] ;
         P002X4_A80FacturaEstatus = new string[] {""} ;
         P002X4_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P002X4_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P002X4_A71FacturaNo = new string[] {""} ;
         P002X4_A42PromocionDescripcion = new string[] {""} ;
         P002X4_A51UsuarioApellido = new string[] {""} ;
         P002X4_A30UsuarioNombre = new string[] {""} ;
         P002X4_A69FacturaID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturaspromopartgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002X2_A41PromocionID, P002X2_A93FacturaCompleta, P002X2_A29UsuarioID, P002X2_A80FacturaEstatus, P002X2_A73FacturaFechaFactura, P002X2_A72FacturaFechaRegistro, P002X2_A71FacturaNo, P002X2_A42PromocionDescripcion, P002X2_A51UsuarioApellido, P002X2_A30UsuarioNombre,
               P002X2_A69FacturaID
               }
               , new Object[] {
               P002X3_A71FacturaNo, P002X3_A93FacturaCompleta, P002X3_A29UsuarioID, P002X3_A41PromocionID, P002X3_A80FacturaEstatus, P002X3_A73FacturaFechaFactura, P002X3_A72FacturaFechaRegistro, P002X3_A42PromocionDescripcion, P002X3_A51UsuarioApellido, P002X3_A30UsuarioNombre,
               P002X3_A69FacturaID
               }
               , new Object[] {
               P002X4_A29UsuarioID, P002X4_A93FacturaCompleta, P002X4_A41PromocionID, P002X4_A80FacturaEstatus, P002X4_A73FacturaFechaFactura, P002X4_A72FacturaFechaRegistro, P002X4_A71FacturaNo, P002X4_A42PromocionDescripcion, P002X4_A51UsuarioApellido, P002X4_A30UsuarioNombre,
               P002X4_A69FacturaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV45MaxItems ;
      private short AV44PageIndex ;
      private short AV43SkipItems ;
      private short AV67TFEstatusOperator ;
      private short AV84Wpfacturaspromopartds_11_tfestatusoperator ;
      private int AV72GXV1 ;
      private int AV71ListaUsuarios_Count ;
      private int A29UsuarioID ;
      private int AV65PromocionID ;
      private int A41PromocionID ;
      private int A69FacturaID ;
      private int AV46InsertIndex ;
      private long AV52count ;
      private string AV20TFFacturaNo ;
      private string AV21TFFacturaNo_Sel ;
      private string AV79Wpfacturaspromopartds_6_tffacturano ;
      private string AV80Wpfacturaspromopartds_7_tffacturano_sel ;
      private string AV83Wpfacturaspromopartds_10_tfestatus ;
      private string AV66TFEstatus ;
      private string lV79Wpfacturaspromopartds_6_tffacturano ;
      private string A71FacturaNo ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string A80FacturaEstatus ;
      private DateTime AV24TFFacturaFechaRegistro ;
      private DateTime AV25TFFacturaFechaRegistro_To ;
      private DateTime AV22TFFacturaFechaFactura ;
      private DateTime AV23TFFacturaFechaFactura_To ;
      private DateTime AV75Wpfacturaspromopartds_2_tffacturafecharegistro ;
      private DateTime AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to ;
      private DateTime AV81Wpfacturaspromopartds_8_tffacturafechafactura ;
      private DateTime AV82Wpfacturaspromopartds_9_tffacturafechafactura_to ;
      private DateTime AV69FromDate ;
      private DateTime AV70ToDate ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool returnInSub ;
      private bool A93FacturaCompleta ;
      private bool BRK2X2 ;
      private bool BRK2X4 ;
      private bool BRK2X6 ;
      private string AV61OptionsJson ;
      private string AV62OptionsDescJson ;
      private string AV63OptionIndexesJson ;
      private string AV58DDOName ;
      private string AV59SearchTxtParms ;
      private string AV60SearchTxtTo ;
      private string AV42SearchTxt ;
      private string AV64FilterFullText ;
      private string AV14TFPromocionDescripcion ;
      private string AV15TFPromocionDescripcion_Sel ;
      private string AV28TFUsuarioNombreCompleto ;
      private string AV29TFUsuarioNombreCompleto_Sel ;
      private string AV74Wpfacturaspromopartds_1_filterfulltext ;
      private string AV77Wpfacturaspromopartds_4_tfpromociondescripcion ;
      private string AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel ;
      private string AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto ;
      private string AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ;
      private string lV74Wpfacturaspromopartds_1_filterfulltext ;
      private string lV77Wpfacturaspromopartds_4_tfpromociondescripcion ;
      private string lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto ;
      private string A42PromocionDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV47Option ;
      private IGxSession AV53Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV48Options ;
      private GxSimpleCollection<string> AV50OptionsDesc ;
      private GxSimpleCollection<string> AV51OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV55GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV56GridStateFilterValue ;
      private GxSimpleCollection<int> AV71ListaUsuarios ;
      private IDataStoreProvider pr_default ;
      private int[] P002X2_A41PromocionID ;
      private bool[] P002X2_A93FacturaCompleta ;
      private int[] P002X2_A29UsuarioID ;
      private string[] P002X2_A80FacturaEstatus ;
      private DateTime[] P002X2_A73FacturaFechaFactura ;
      private DateTime[] P002X2_A72FacturaFechaRegistro ;
      private string[] P002X2_A71FacturaNo ;
      private string[] P002X2_A42PromocionDescripcion ;
      private string[] P002X2_A51UsuarioApellido ;
      private string[] P002X2_A30UsuarioNombre ;
      private int[] P002X2_A69FacturaID ;
      private string[] P002X3_A71FacturaNo ;
      private bool[] P002X3_A93FacturaCompleta ;
      private int[] P002X3_A29UsuarioID ;
      private int[] P002X3_A41PromocionID ;
      private string[] P002X3_A80FacturaEstatus ;
      private DateTime[] P002X3_A73FacturaFechaFactura ;
      private DateTime[] P002X3_A72FacturaFechaRegistro ;
      private string[] P002X3_A42PromocionDescripcion ;
      private string[] P002X3_A51UsuarioApellido ;
      private string[] P002X3_A30UsuarioNombre ;
      private int[] P002X3_A69FacturaID ;
      private int[] P002X4_A29UsuarioID ;
      private bool[] P002X4_A93FacturaCompleta ;
      private int[] P002X4_A41PromocionID ;
      private string[] P002X4_A80FacturaEstatus ;
      private DateTime[] P002X4_A73FacturaFechaFactura ;
      private DateTime[] P002X4_A72FacturaFechaRegistro ;
      private string[] P002X4_A71FacturaNo ;
      private string[] P002X4_A42PromocionDescripcion ;
      private string[] P002X4_A51UsuarioApellido ;
      private string[] P002X4_A30UsuarioNombre ;
      private int[] P002X4_A69FacturaID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpfacturaspromopartgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002X2( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV71ListaUsuarios ,
                                             string AV74Wpfacturaspromopartds_1_filterfulltext ,
                                             DateTime AV75Wpfacturaspromopartds_2_tffacturafecharegistro ,
                                             DateTime AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to ,
                                             string AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel ,
                                             string AV77Wpfacturaspromopartds_4_tfpromociondescripcion ,
                                             string AV80Wpfacturaspromopartds_7_tffacturano_sel ,
                                             string AV79Wpfacturaspromopartds_6_tffacturano ,
                                             DateTime AV81Wpfacturaspromopartds_8_tffacturafechafactura ,
                                             DateTime AV82Wpfacturaspromopartds_9_tffacturafechafactura_to ,
                                             short AV84Wpfacturaspromopartds_11_tfestatusoperator ,
                                             string AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ,
                                             string AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto ,
                                             DateTime AV69FromDate ,
                                             DateTime AV70ToDate ,
                                             int AV71ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             bool A93FacturaCompleta ,
                                             int AV65PromocionID ,
                                             int A41PromocionID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`FacturaCompleta`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T3.`UsuarioApellido`, T3.`UsuarioNombre`, T1.`FacturaID` FROM ((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV65PromocionID)");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV74Wpfacturaspromopartds_1_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV74Wpfacturaspromopartds_1_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like CONCAT('%', @lV74Wpfacturaspromopartds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV75Wpfacturaspromopartds_2_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV75Wpfacturaspromopartds_2_tffacturafecharegistro)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpfacturaspromopartds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV77Wpfacturaspromopartds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpfacturaspromopartds_7_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpfacturaspromopartds_6_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV79Wpfacturaspromopartds_6_tffacturano)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpfacturaspromopartds_7_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV80Wpfacturaspromopartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV80Wpfacturaspromopartds_7_tffacturano_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wpfacturaspromopartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV81Wpfacturaspromopartds_8_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV81Wpfacturaspromopartds_8_tffacturafechafactura)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Wpfacturaspromopartds_9_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV82Wpfacturaspromopartds_9_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like @lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) = @AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T3.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T3.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV69FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV69FromDate)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV70ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV70ToDate)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV71ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`PromocionID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002X3( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV71ListaUsuarios ,
                                             string AV74Wpfacturaspromopartds_1_filterfulltext ,
                                             DateTime AV75Wpfacturaspromopartds_2_tffacturafecharegistro ,
                                             DateTime AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to ,
                                             string AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel ,
                                             string AV77Wpfacturaspromopartds_4_tfpromociondescripcion ,
                                             string AV80Wpfacturaspromopartds_7_tffacturano_sel ,
                                             string AV79Wpfacturaspromopartds_6_tffacturano ,
                                             DateTime AV81Wpfacturaspromopartds_8_tffacturafechafactura ,
                                             DateTime AV82Wpfacturaspromopartds_9_tffacturafechafactura_to ,
                                             short AV84Wpfacturaspromopartds_11_tfestatusoperator ,
                                             string AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ,
                                             string AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto ,
                                             DateTime AV69FromDate ,
                                             DateTime AV70ToDate ,
                                             int AV71ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             int A41PromocionID ,
                                             int AV65PromocionID ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`FacturaNo`, T1.`FacturaCompleta`, T1.`UsuarioID`, T1.`PromocionID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T3.`PromocionDescripcion`, T2.`UsuarioApellido`, T2.`UsuarioNombre`, T1.`FacturaID` FROM ((`Factura` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`) INNER JOIN `Promocion` T3 ON T3.`PromocionID` = T1.`PromocionID`)";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV65PromocionID)");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.`PromocionDescripcion` like CONCAT('%', @lV74Wpfacturaspromopartds_1_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV74Wpfacturaspromopartds_1_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) like CONCAT('%', @lV74Wpfacturaspromopartds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV75Wpfacturaspromopartds_2_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV75Wpfacturaspromopartds_2_tffacturafecharegistro)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpfacturaspromopartds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`PromocionDescripcion` like @lV77Wpfacturaspromopartds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`PromocionDescripcion` = @AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpfacturaspromopartds_7_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpfacturaspromopartds_6_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV79Wpfacturaspromopartds_6_tffacturano)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpfacturaspromopartds_7_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV80Wpfacturaspromopartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV80Wpfacturaspromopartds_7_tffacturano_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wpfacturaspromopartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV81Wpfacturaspromopartds_8_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV81Wpfacturaspromopartds_8_tffacturafechafactura)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Wpfacturaspromopartds_9_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV82Wpfacturaspromopartds_9_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) like @lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) = @AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T2.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T2.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV69FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV69FromDate)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV70ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV70ToDate)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV71ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`FacturaNo`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002X4( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV71ListaUsuarios ,
                                             string AV74Wpfacturaspromopartds_1_filterfulltext ,
                                             DateTime AV75Wpfacturaspromopartds_2_tffacturafecharegistro ,
                                             DateTime AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to ,
                                             string AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel ,
                                             string AV77Wpfacturaspromopartds_4_tfpromociondescripcion ,
                                             string AV80Wpfacturaspromopartds_7_tffacturano_sel ,
                                             string AV79Wpfacturaspromopartds_6_tffacturano ,
                                             DateTime AV81Wpfacturaspromopartds_8_tffacturafechafactura ,
                                             DateTime AV82Wpfacturaspromopartds_9_tffacturafechafactura_to ,
                                             short AV84Wpfacturaspromopartds_11_tfestatusoperator ,
                                             string AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ,
                                             string AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto ,
                                             DateTime AV69FromDate ,
                                             DateTime AV70ToDate ,
                                             int AV71ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             int A41PromocionID ,
                                             int AV65PromocionID ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`UsuarioID`, T1.`FacturaCompleta`, T1.`PromocionID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T1.`FacturaNo`, T3.`PromocionDescripcion`, T2.`UsuarioApellido`, T2.`UsuarioNombre`, T1.`FacturaID` FROM ((`Factura` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`) INNER JOIN `Promocion` T3 ON T3.`PromocionID` = T1.`PromocionID`)";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV65PromocionID)");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpfacturaspromopartds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.`PromocionDescripcion` like CONCAT('%', @lV74Wpfacturaspromopartds_1_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV74Wpfacturaspromopartds_1_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) like CONCAT('%', @lV74Wpfacturaspromopartds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV75Wpfacturaspromopartds_2_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV75Wpfacturaspromopartds_2_tffacturafecharegistro)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpfacturaspromopartds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`PromocionDescripcion` like @lV77Wpfacturaspromopartds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`PromocionDescripcion` = @AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpfacturaspromopartds_7_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpfacturaspromopartds_6_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV79Wpfacturaspromopartds_6_tffacturano)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpfacturaspromopartds_7_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV80Wpfacturaspromopartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV80Wpfacturaspromopartds_7_tffacturano_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wpfacturaspromopartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV81Wpfacturaspromopartds_8_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV81Wpfacturaspromopartds_8_tffacturafechafactura)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Wpfacturaspromopartds_9_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV82Wpfacturaspromopartds_9_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV84Wpfacturaspromopartds_11_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpfacturaspromopartds_12_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) like @lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) = @AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T2.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T2.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV69FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV69FromDate)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV70ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV70ToDate)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV71ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioID`";
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
                     return conditional_P002X2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (bool)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] );
               case 1 :
                     return conditional_P002X3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (bool)dynConstraints[26] );
               case 2 :
                     return conditional_P002X4(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (bool)dynConstraints[26] );
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
          Object[] prmP002X2;
          prmP002X2 = new Object[] {
          new ParDef("@AV65PromocionID",GXType.Int32,9,0) ,
          new ParDef("@lV74Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV74Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV74Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV75Wpfacturaspromopartds_2_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV77Wpfacturaspromopartds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV79Wpfacturaspromopartds_6_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV80Wpfacturaspromopartds_7_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV81Wpfacturaspromopartds_8_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV82Wpfacturaspromopartds_9_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@AV69FromDate",GXType.Date,8,0) ,
          new ParDef("@AV70ToDate",GXType.Date,8,0)
          };
          Object[] prmP002X3;
          prmP002X3 = new Object[] {
          new ParDef("@AV65PromocionID",GXType.Int32,9,0) ,
          new ParDef("@lV74Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV74Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV74Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV75Wpfacturaspromopartds_2_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV77Wpfacturaspromopartds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV79Wpfacturaspromopartds_6_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV80Wpfacturaspromopartds_7_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV81Wpfacturaspromopartds_8_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV82Wpfacturaspromopartds_9_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@AV69FromDate",GXType.Date,8,0) ,
          new ParDef("@AV70ToDate",GXType.Date,8,0)
          };
          Object[] prmP002X4;
          prmP002X4 = new Object[] {
          new ParDef("@AV65PromocionID",GXType.Int32,9,0) ,
          new ParDef("@lV74Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV74Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV74Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV75Wpfacturaspromopartds_2_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV76Wpfacturaspromopartds_3_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV77Wpfacturaspromopartds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV78Wpfacturaspromopartds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV79Wpfacturaspromopartds_6_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV80Wpfacturaspromopartds_7_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV81Wpfacturaspromopartds_8_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV82Wpfacturaspromopartds_9_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@lV85Wpfacturaspromopartds_12_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV86Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@AV69FromDate",GXType.Date,8,0) ,
          new ParDef("@AV70ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002X4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X4,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                ((string[]) buf[9])[0] = rslt.getString(10, 50);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                ((string[]) buf[9])[0] = rslt.getString(10, 50);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                ((string[]) buf[9])[0] = rslt.getString(10, 50);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                return;
       }
    }

 }

}
