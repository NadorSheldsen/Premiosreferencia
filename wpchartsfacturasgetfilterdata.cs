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
   public class wpchartsfacturasgetfilterdata : GXProcedure
   {
      public wpchartsfacturasgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpchartsfacturasgetfilterdata( IGxContext context )
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
         this.AV63DDOName = aP0_DDOName;
         this.AV64SearchTxtParms = aP1_SearchTxtParms;
         this.AV65SearchTxtTo = aP2_SearchTxtTo;
         this.AV66OptionsJson = "" ;
         this.AV67OptionsDescJson = "" ;
         this.AV68OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV66OptionsJson;
         aP4_OptionsDescJson=this.AV67OptionsDescJson;
         aP5_OptionIndexesJson=this.AV68OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV68OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV63DDOName = aP0_DDOName;
         this.AV64SearchTxtParms = aP1_SearchTxtParms;
         this.AV65SearchTxtTo = aP2_SearchTxtTo;
         this.AV66OptionsJson = "" ;
         this.AV67OptionsDescJson = "" ;
         this.AV68OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV66OptionsJson;
         aP4_OptionsDescJson=this.AV67OptionsDescJson;
         aP5_OptionIndexesJson=this.AV68OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV53Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV55OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV56OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV50MaxItems = 10;
         AV49PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV64SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV64SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV47SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV64SearchTxtParms)) ? "" : StringUtil.Substring( AV64SearchTxtParms, 3, -1));
         AV48SkipItems = (short)(AV49PageIndex*AV50MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV63DDOName), "DDO_PROMOCIONDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV63DDOName), "DDO_FACTURANO") == 0 )
         {
            /* Execute user subroutine: 'LOADFACTURANOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV63DDOName), "DDO_USUARIONOMBRECOMPLETO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIONOMBRECOMPLETOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV63DDOName), "DDO_MOTIVORECHAZODESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADMOTIVORECHAZODESCRIPCIONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV66OptionsJson = AV53Options.ToJSonString(false);
         AV67OptionsDescJson = AV55OptionsDesc.ToJSonString(false);
         AV68OptionIndexesJson = AV56OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV58Session.Get("WPChartsFacturasGridState"), "") == 0 )
         {
            AV60GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPChartsFacturasGridState"), null, "", "");
         }
         else
         {
            AV60GridState.FromXml(AV58Session.Get("WPChartsFacturasGridState"), null, "", "");
         }
         AV74GXV1 = 1;
         while ( AV74GXV1 <= AV60GridState.gxTpr_Filtervalues.Count )
         {
            AV61GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV60GridState.gxTpr_Filtervalues.Item(AV74GXV1));
            if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV69FilterFullText = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV14TFPromocionDescripcion = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV15TFPromocionDescripcion_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFFACTURAESTATUS_SEL") == 0 )
            {
               AV40TFFacturaEstatus_SelsJson = AV61GridStateFilterValue.gxTpr_Value;
               AV41TFFacturaEstatus_Sels.FromJSonString(AV40TFFacturaEstatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV22TFFacturaFechaFactura = context.localUtil.CToD( AV61GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV23TFFacturaFechaFactura_To = context.localUtil.CToD( AV61GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV24TFFacturaFechaRegistro = context.localUtil.CToD( AV61GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV25TFFacturaFechaRegistro_To = context.localUtil.CToD( AV61GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFFACTURANO") == 0 )
            {
               AV20TFFacturaNo = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFFACTURANO_SEL") == 0 )
            {
               AV21TFFacturaNo_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV28TFUsuarioNombreCompleto = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV29TFUsuarioNombreCompleto_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFMOTIVORECHAZODESCRIPCION") == 0 )
            {
               AV44TFMotivoRechazoDescripcion = AV61GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV61GridStateFilterValue.gxTpr_Name, "TFMOTIVORECHAZODESCRIPCION_SEL") == 0 )
            {
               AV45TFMotivoRechazoDescripcion_Sel = AV61GridStateFilterValue.gxTpr_Value;
            }
            AV74GXV1 = (int)(AV74GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROMOCIONDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFPromocionDescripcion = AV47SearchTxt;
         AV15TFPromocionDescripcion_Sel = "";
         AV76Wpchartsfacturasds_1_filterfulltext = AV69FilterFullText;
         AV77Wpchartsfacturasds_2_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV79Wpchartsfacturasds_4_tffacturaestatus_sels = AV41TFFacturaEstatus_Sels;
         AV80Wpchartsfacturasds_5_tffacturafechafactura = AV22TFFacturaFechaFactura;
         AV81Wpchartsfacturasds_6_tffacturafechafactura_to = AV23TFFacturaFechaFactura_To;
         AV82Wpchartsfacturasds_7_tffacturafecharegistro = AV24TFFacturaFechaRegistro;
         AV83Wpchartsfacturasds_8_tffacturafecharegistro_to = AV25TFFacturaFechaRegistro_To;
         AV84Wpchartsfacturasds_9_tffacturano = AV20TFFacturaNo;
         AV85Wpchartsfacturasds_10_tffacturano_sel = AV21TFFacturaNo_Sel;
         AV86Wpchartsfacturasds_11_tfusuarionombrecompleto = AV28TFUsuarioNombreCompleto;
         AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV29TFUsuarioNombreCompleto_Sel;
         AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV44TFMotivoRechazoDescripcion;
         AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV45TFMotivoRechazoDescripcion_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV73ListaUsuarios ,
                                              A80FacturaEstatus ,
                                              AV79Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                              AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                              AV77Wpchartsfacturasds_2_tfpromociondescripcion ,
                                              AV79Wpchartsfacturasds_4_tffacturaestatus_sels.Count ,
                                              AV80Wpchartsfacturasds_5_tffacturafechafactura ,
                                              AV81Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                              AV82Wpchartsfacturasds_7_tffacturafecharegistro ,
                                              AV83Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                              AV85Wpchartsfacturasds_10_tffacturano_sel ,
                                              AV84Wpchartsfacturasds_9_tffacturano ,
                                              AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                              AV86Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                              AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                              AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                              A42PromocionDescripcion ,
                                              A73FacturaFechaFactura ,
                                              A72FacturaFechaRegistro ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A20MotivoRechazoDescripcion ,
                                              AV76Wpchartsfacturasds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto ,
                                              AV70FromDate ,
                                              AV71ToDate ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV77Wpchartsfacturasds_2_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV77Wpchartsfacturasds_2_tfpromociondescripcion), "%", "");
         lV84Wpchartsfacturasds_9_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV84Wpchartsfacturasds_9_tffacturano), 20, "%");
         lV86Wpchartsfacturasds_11_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV86Wpchartsfacturasds_11_tfusuarionombrecompleto), "%", "");
         lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion = StringUtil.Concat( StringUtil.RTrim( AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion), "%", "");
         /* Using cursor P00412 */
         pr_default.execute(0, new Object[] {AV70FromDate, AV71ToDate, lV77Wpchartsfacturasds_2_tfpromociondescripcion, AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, AV80Wpchartsfacturasds_5_tffacturafechafactura, AV81Wpchartsfacturasds_6_tffacturafechafactura_to, AV82Wpchartsfacturasds_7_tffacturafecharegistro, AV83Wpchartsfacturasds_8_tffacturafecharegistro_to, lV84Wpchartsfacturasds_9_tffacturano, AV85Wpchartsfacturasds_10_tffacturano_sel, lV86Wpchartsfacturasds_11_tfusuarionombrecompleto, AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion, AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK412 = false;
            A19MotivoRechazoID = P00412_A19MotivoRechazoID[0];
            A41PromocionID = P00412_A41PromocionID[0];
            A29UsuarioID = P00412_A29UsuarioID[0];
            A93FacturaCompleta = P00412_A93FacturaCompleta[0];
            A72FacturaFechaRegistro = P00412_A72FacturaFechaRegistro[0];
            A73FacturaFechaFactura = P00412_A73FacturaFechaFactura[0];
            A20MotivoRechazoDescripcion = P00412_A20MotivoRechazoDescripcion[0];
            A52UsuarioNombreCompleto = P00412_A52UsuarioNombreCompleto[0];
            A71FacturaNo = P00412_A71FacturaNo[0];
            A80FacturaEstatus = P00412_A80FacturaEstatus[0];
            A42PromocionDescripcion = P00412_A42PromocionDescripcion[0];
            A30UsuarioNombre = P00412_A30UsuarioNombre[0];
            A51UsuarioApellido = P00412_A51UsuarioApellido[0];
            A69FacturaID = P00412_A69FacturaID[0];
            A20MotivoRechazoDescripcion = P00412_A20MotivoRechazoDescripcion[0];
            A42PromocionDescripcion = P00412_A42PromocionDescripcion[0];
            A52UsuarioNombreCompleto = P00412_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00412_A30UsuarioNombre[0];
            A51UsuarioApellido = P00412_A51UsuarioApellido[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpchartsfacturasds_1_filterfulltext)) || ( ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A80FacturaEstatus)) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "en proceso", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "En Proceso", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "aprobada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Aprobada", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "rechazada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Rechazada", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "cancelada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Cancelada", "")) == 0 ) ) || ( StringUtil.Like( A71FacturaNo , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A20MotivoRechazoDescripcion , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               AV57count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00412_A41PromocionID[0] == A41PromocionID ) )
               {
                  BRK412 = false;
                  A69FacturaID = P00412_A69FacturaID[0];
                  AV57count = (long)(AV57count+1);
                  BRK412 = true;
                  pr_default.readNext(0);
               }
               AV52Option = (String.IsNullOrEmpty(StringUtil.RTrim( A42PromocionDescripcion)) ? "<#Empty#>" : A42PromocionDescripcion);
               AV51InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV52Option, "<#Empty#>") != 0 ) && ( AV51InsertIndex <= AV53Options.Count ) && ( ( StringUtil.StrCmp(((string)AV53Options.Item(AV51InsertIndex)), AV52Option) < 0 ) || ( StringUtil.StrCmp(((string)AV53Options.Item(AV51InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV51InsertIndex = (int)(AV51InsertIndex+1);
               }
               AV53Options.Add(AV52Option, AV51InsertIndex);
               AV56OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV57count), "Z,ZZZ,ZZZ,ZZ9")), AV51InsertIndex);
               if ( AV53Options.Count == AV48SkipItems + 11 )
               {
                  AV53Options.RemoveItem(AV53Options.Count);
                  AV56OptionIndexes.RemoveItem(AV56OptionIndexes.Count);
               }
            }
            if ( ! BRK412 )
            {
               BRK412 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV48SkipItems > 0 )
         {
            AV53Options.RemoveItem(1);
            AV56OptionIndexes.RemoveItem(1);
            AV48SkipItems = (short)(AV48SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADFACTURANOOPTIONS' Routine */
         returnInSub = false;
         AV20TFFacturaNo = AV47SearchTxt;
         AV21TFFacturaNo_Sel = "";
         AV76Wpchartsfacturasds_1_filterfulltext = AV69FilterFullText;
         AV77Wpchartsfacturasds_2_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV79Wpchartsfacturasds_4_tffacturaestatus_sels = AV41TFFacturaEstatus_Sels;
         AV80Wpchartsfacturasds_5_tffacturafechafactura = AV22TFFacturaFechaFactura;
         AV81Wpchartsfacturasds_6_tffacturafechafactura_to = AV23TFFacturaFechaFactura_To;
         AV82Wpchartsfacturasds_7_tffacturafecharegistro = AV24TFFacturaFechaRegistro;
         AV83Wpchartsfacturasds_8_tffacturafecharegistro_to = AV25TFFacturaFechaRegistro_To;
         AV84Wpchartsfacturasds_9_tffacturano = AV20TFFacturaNo;
         AV85Wpchartsfacturasds_10_tffacturano_sel = AV21TFFacturaNo_Sel;
         AV86Wpchartsfacturasds_11_tfusuarionombrecompleto = AV28TFUsuarioNombreCompleto;
         AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV29TFUsuarioNombreCompleto_Sel;
         AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV44TFMotivoRechazoDescripcion;
         AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV45TFMotivoRechazoDescripcion_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV73ListaUsuarios ,
                                              A80FacturaEstatus ,
                                              AV79Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                              AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                              AV77Wpchartsfacturasds_2_tfpromociondescripcion ,
                                              AV79Wpchartsfacturasds_4_tffacturaestatus_sels.Count ,
                                              AV80Wpchartsfacturasds_5_tffacturafechafactura ,
                                              AV81Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                              AV82Wpchartsfacturasds_7_tffacturafecharegistro ,
                                              AV83Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                              AV85Wpchartsfacturasds_10_tffacturano_sel ,
                                              AV84Wpchartsfacturasds_9_tffacturano ,
                                              AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                              AV86Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                              AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                              AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                              A42PromocionDescripcion ,
                                              A73FacturaFechaFactura ,
                                              A72FacturaFechaRegistro ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A20MotivoRechazoDescripcion ,
                                              AV76Wpchartsfacturasds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto ,
                                              AV70FromDate ,
                                              AV71ToDate ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV77Wpchartsfacturasds_2_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV77Wpchartsfacturasds_2_tfpromociondescripcion), "%", "");
         lV84Wpchartsfacturasds_9_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV84Wpchartsfacturasds_9_tffacturano), 20, "%");
         lV86Wpchartsfacturasds_11_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV86Wpchartsfacturasds_11_tfusuarionombrecompleto), "%", "");
         lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion = StringUtil.Concat( StringUtil.RTrim( AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion), "%", "");
         /* Using cursor P00413 */
         pr_default.execute(1, new Object[] {AV70FromDate, AV71ToDate, lV77Wpchartsfacturasds_2_tfpromociondescripcion, AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, AV80Wpchartsfacturasds_5_tffacturafechafactura, AV81Wpchartsfacturasds_6_tffacturafechafactura_to, AV82Wpchartsfacturasds_7_tffacturafecharegistro, AV83Wpchartsfacturasds_8_tffacturafecharegistro_to, lV84Wpchartsfacturasds_9_tffacturano, AV85Wpchartsfacturasds_10_tffacturano_sel, lV86Wpchartsfacturasds_11_tfusuarionombrecompleto, AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion, AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK414 = false;
            A41PromocionID = P00413_A41PromocionID[0];
            A19MotivoRechazoID = P00413_A19MotivoRechazoID[0];
            A71FacturaNo = P00413_A71FacturaNo[0];
            A29UsuarioID = P00413_A29UsuarioID[0];
            A93FacturaCompleta = P00413_A93FacturaCompleta[0];
            A72FacturaFechaRegistro = P00413_A72FacturaFechaRegistro[0];
            A73FacturaFechaFactura = P00413_A73FacturaFechaFactura[0];
            A20MotivoRechazoDescripcion = P00413_A20MotivoRechazoDescripcion[0];
            A52UsuarioNombreCompleto = P00413_A52UsuarioNombreCompleto[0];
            A80FacturaEstatus = P00413_A80FacturaEstatus[0];
            A42PromocionDescripcion = P00413_A42PromocionDescripcion[0];
            A30UsuarioNombre = P00413_A30UsuarioNombre[0];
            A51UsuarioApellido = P00413_A51UsuarioApellido[0];
            A69FacturaID = P00413_A69FacturaID[0];
            A42PromocionDescripcion = P00413_A42PromocionDescripcion[0];
            A20MotivoRechazoDescripcion = P00413_A20MotivoRechazoDescripcion[0];
            A52UsuarioNombreCompleto = P00413_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00413_A30UsuarioNombre[0];
            A51UsuarioApellido = P00413_A51UsuarioApellido[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpchartsfacturasds_1_filterfulltext)) || ( ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A80FacturaEstatus)) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "en proceso", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "En Proceso", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "aprobada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Aprobada", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "rechazada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Rechazada", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "cancelada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Cancelada", "")) == 0 ) ) || ( StringUtil.Like( A71FacturaNo , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A20MotivoRechazoDescripcion , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               AV57count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00413_A71FacturaNo[0], A71FacturaNo) == 0 ) )
               {
                  BRK414 = false;
                  A69FacturaID = P00413_A69FacturaID[0];
                  AV57count = (long)(AV57count+1);
                  BRK414 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV48SkipItems) )
               {
                  AV52Option = (String.IsNullOrEmpty(StringUtil.RTrim( A71FacturaNo)) ? "<#Empty#>" : A71FacturaNo);
                  AV53Options.Add(AV52Option, 0);
                  AV56OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV57count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV53Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV48SkipItems = (short)(AV48SkipItems-1);
               }
            }
            if ( ! BRK414 )
            {
               BRK414 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADUSUARIONOMBRECOMPLETOOPTIONS' Routine */
         returnInSub = false;
         AV28TFUsuarioNombreCompleto = AV47SearchTxt;
         AV29TFUsuarioNombreCompleto_Sel = "";
         AV76Wpchartsfacturasds_1_filterfulltext = AV69FilterFullText;
         AV77Wpchartsfacturasds_2_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV79Wpchartsfacturasds_4_tffacturaestatus_sels = AV41TFFacturaEstatus_Sels;
         AV80Wpchartsfacturasds_5_tffacturafechafactura = AV22TFFacturaFechaFactura;
         AV81Wpchartsfacturasds_6_tffacturafechafactura_to = AV23TFFacturaFechaFactura_To;
         AV82Wpchartsfacturasds_7_tffacturafecharegistro = AV24TFFacturaFechaRegistro;
         AV83Wpchartsfacturasds_8_tffacturafecharegistro_to = AV25TFFacturaFechaRegistro_To;
         AV84Wpchartsfacturasds_9_tffacturano = AV20TFFacturaNo;
         AV85Wpchartsfacturasds_10_tffacturano_sel = AV21TFFacturaNo_Sel;
         AV86Wpchartsfacturasds_11_tfusuarionombrecompleto = AV28TFUsuarioNombreCompleto;
         AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV29TFUsuarioNombreCompleto_Sel;
         AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV44TFMotivoRechazoDescripcion;
         AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV45TFMotivoRechazoDescripcion_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV73ListaUsuarios ,
                                              A80FacturaEstatus ,
                                              AV79Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                              AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                              AV77Wpchartsfacturasds_2_tfpromociondescripcion ,
                                              AV79Wpchartsfacturasds_4_tffacturaestatus_sels.Count ,
                                              AV80Wpchartsfacturasds_5_tffacturafechafactura ,
                                              AV81Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                              AV82Wpchartsfacturasds_7_tffacturafecharegistro ,
                                              AV83Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                              AV85Wpchartsfacturasds_10_tffacturano_sel ,
                                              AV84Wpchartsfacturasds_9_tffacturano ,
                                              AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                              AV86Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                              AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                              AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                              A42PromocionDescripcion ,
                                              A73FacturaFechaFactura ,
                                              A72FacturaFechaRegistro ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A20MotivoRechazoDescripcion ,
                                              AV76Wpchartsfacturasds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto ,
                                              AV70FromDate ,
                                              AV71ToDate ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV77Wpchartsfacturasds_2_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV77Wpchartsfacturasds_2_tfpromociondescripcion), "%", "");
         lV84Wpchartsfacturasds_9_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV84Wpchartsfacturasds_9_tffacturano), 20, "%");
         lV86Wpchartsfacturasds_11_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV86Wpchartsfacturasds_11_tfusuarionombrecompleto), "%", "");
         lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion = StringUtil.Concat( StringUtil.RTrim( AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion), "%", "");
         /* Using cursor P00414 */
         pr_default.execute(2, new Object[] {AV70FromDate, AV71ToDate, lV77Wpchartsfacturasds_2_tfpromociondescripcion, AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, AV80Wpchartsfacturasds_5_tffacturafechafactura, AV81Wpchartsfacturasds_6_tffacturafechafactura_to, AV82Wpchartsfacturasds_7_tffacturafecharegistro, AV83Wpchartsfacturasds_8_tffacturafecharegistro_to, lV84Wpchartsfacturasds_9_tffacturano, AV85Wpchartsfacturasds_10_tffacturano_sel, lV86Wpchartsfacturasds_11_tfusuarionombrecompleto, AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion, AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK416 = false;
            A41PromocionID = P00414_A41PromocionID[0];
            A19MotivoRechazoID = P00414_A19MotivoRechazoID[0];
            A29UsuarioID = P00414_A29UsuarioID[0];
            A93FacturaCompleta = P00414_A93FacturaCompleta[0];
            A72FacturaFechaRegistro = P00414_A72FacturaFechaRegistro[0];
            A73FacturaFechaFactura = P00414_A73FacturaFechaFactura[0];
            A20MotivoRechazoDescripcion = P00414_A20MotivoRechazoDescripcion[0];
            A52UsuarioNombreCompleto = P00414_A52UsuarioNombreCompleto[0];
            A71FacturaNo = P00414_A71FacturaNo[0];
            A80FacturaEstatus = P00414_A80FacturaEstatus[0];
            A42PromocionDescripcion = P00414_A42PromocionDescripcion[0];
            A30UsuarioNombre = P00414_A30UsuarioNombre[0];
            A51UsuarioApellido = P00414_A51UsuarioApellido[0];
            A69FacturaID = P00414_A69FacturaID[0];
            A42PromocionDescripcion = P00414_A42PromocionDescripcion[0];
            A20MotivoRechazoDescripcion = P00414_A20MotivoRechazoDescripcion[0];
            A52UsuarioNombreCompleto = P00414_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00414_A30UsuarioNombre[0];
            A51UsuarioApellido = P00414_A51UsuarioApellido[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpchartsfacturasds_1_filterfulltext)) || ( ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A80FacturaEstatus)) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "en proceso", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "En Proceso", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "aprobada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Aprobada", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "rechazada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Rechazada", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "cancelada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Cancelada", "")) == 0 ) ) || ( StringUtil.Like( A71FacturaNo , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A20MotivoRechazoDescripcion , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               AV57count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P00414_A29UsuarioID[0] == A29UsuarioID ) )
               {
                  BRK416 = false;
                  A69FacturaID = P00414_A69FacturaID[0];
                  AV57count = (long)(AV57count+1);
                  BRK416 = true;
                  pr_default.readNext(2);
               }
               AV52Option = (String.IsNullOrEmpty(StringUtil.RTrim( A52UsuarioNombreCompleto)) ? "<#Empty#>" : A52UsuarioNombreCompleto);
               AV51InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV52Option, "<#Empty#>") != 0 ) && ( AV51InsertIndex <= AV53Options.Count ) && ( ( StringUtil.StrCmp(((string)AV53Options.Item(AV51InsertIndex)), AV52Option) < 0 ) || ( StringUtil.StrCmp(((string)AV53Options.Item(AV51InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV51InsertIndex = (int)(AV51InsertIndex+1);
               }
               AV53Options.Add(AV52Option, AV51InsertIndex);
               AV56OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV57count), "Z,ZZZ,ZZZ,ZZ9")), AV51InsertIndex);
               if ( AV53Options.Count == AV48SkipItems + 11 )
               {
                  AV53Options.RemoveItem(AV53Options.Count);
                  AV56OptionIndexes.RemoveItem(AV56OptionIndexes.Count);
               }
            }
            if ( ! BRK416 )
            {
               BRK416 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV48SkipItems > 0 )
         {
            AV53Options.RemoveItem(1);
            AV56OptionIndexes.RemoveItem(1);
            AV48SkipItems = (short)(AV48SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADMOTIVORECHAZODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV44TFMotivoRechazoDescripcion = AV47SearchTxt;
         AV45TFMotivoRechazoDescripcion_Sel = "";
         AV76Wpchartsfacturasds_1_filterfulltext = AV69FilterFullText;
         AV77Wpchartsfacturasds_2_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV79Wpchartsfacturasds_4_tffacturaestatus_sels = AV41TFFacturaEstatus_Sels;
         AV80Wpchartsfacturasds_5_tffacturafechafactura = AV22TFFacturaFechaFactura;
         AV81Wpchartsfacturasds_6_tffacturafechafactura_to = AV23TFFacturaFechaFactura_To;
         AV82Wpchartsfacturasds_7_tffacturafecharegistro = AV24TFFacturaFechaRegistro;
         AV83Wpchartsfacturasds_8_tffacturafecharegistro_to = AV25TFFacturaFechaRegistro_To;
         AV84Wpchartsfacturasds_9_tffacturano = AV20TFFacturaNo;
         AV85Wpchartsfacturasds_10_tffacturano_sel = AV21TFFacturaNo_Sel;
         AV86Wpchartsfacturasds_11_tfusuarionombrecompleto = AV28TFUsuarioNombreCompleto;
         AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV29TFUsuarioNombreCompleto_Sel;
         AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV44TFMotivoRechazoDescripcion;
         AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV45TFMotivoRechazoDescripcion_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV73ListaUsuarios ,
                                              A80FacturaEstatus ,
                                              AV79Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                              AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                              AV77Wpchartsfacturasds_2_tfpromociondescripcion ,
                                              AV79Wpchartsfacturasds_4_tffacturaestatus_sels.Count ,
                                              AV80Wpchartsfacturasds_5_tffacturafechafactura ,
                                              AV81Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                              AV82Wpchartsfacturasds_7_tffacturafecharegistro ,
                                              AV83Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                              AV85Wpchartsfacturasds_10_tffacturano_sel ,
                                              AV84Wpchartsfacturasds_9_tffacturano ,
                                              AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                              AV86Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                              AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                              AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                              A42PromocionDescripcion ,
                                              A73FacturaFechaFactura ,
                                              A72FacturaFechaRegistro ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A20MotivoRechazoDescripcion ,
                                              AV76Wpchartsfacturasds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto ,
                                              AV70FromDate ,
                                              AV71ToDate ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV77Wpchartsfacturasds_2_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV77Wpchartsfacturasds_2_tfpromociondescripcion), "%", "");
         lV84Wpchartsfacturasds_9_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV84Wpchartsfacturasds_9_tffacturano), 20, "%");
         lV86Wpchartsfacturasds_11_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV86Wpchartsfacturasds_11_tfusuarionombrecompleto), "%", "");
         lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion = StringUtil.Concat( StringUtil.RTrim( AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion), "%", "");
         /* Using cursor P00415 */
         pr_default.execute(3, new Object[] {AV70FromDate, AV71ToDate, lV77Wpchartsfacturasds_2_tfpromociondescripcion, AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, AV80Wpchartsfacturasds_5_tffacturafechafactura, AV81Wpchartsfacturasds_6_tffacturafechafactura_to, AV82Wpchartsfacturasds_7_tffacturafecharegistro, AV83Wpchartsfacturasds_8_tffacturafecharegistro_to, lV84Wpchartsfacturasds_9_tffacturano, AV85Wpchartsfacturasds_10_tffacturano_sel, lV86Wpchartsfacturasds_11_tfusuarionombrecompleto, AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion, AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK418 = false;
            A41PromocionID = P00415_A41PromocionID[0];
            A19MotivoRechazoID = P00415_A19MotivoRechazoID[0];
            A29UsuarioID = P00415_A29UsuarioID[0];
            A93FacturaCompleta = P00415_A93FacturaCompleta[0];
            A72FacturaFechaRegistro = P00415_A72FacturaFechaRegistro[0];
            A73FacturaFechaFactura = P00415_A73FacturaFechaFactura[0];
            A20MotivoRechazoDescripcion = P00415_A20MotivoRechazoDescripcion[0];
            A52UsuarioNombreCompleto = P00415_A52UsuarioNombreCompleto[0];
            A71FacturaNo = P00415_A71FacturaNo[0];
            A80FacturaEstatus = P00415_A80FacturaEstatus[0];
            A42PromocionDescripcion = P00415_A42PromocionDescripcion[0];
            A30UsuarioNombre = P00415_A30UsuarioNombre[0];
            A51UsuarioApellido = P00415_A51UsuarioApellido[0];
            A69FacturaID = P00415_A69FacturaID[0];
            A42PromocionDescripcion = P00415_A42PromocionDescripcion[0];
            A20MotivoRechazoDescripcion = P00415_A20MotivoRechazoDescripcion[0];
            A52UsuarioNombreCompleto = P00415_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00415_A30UsuarioNombre[0];
            A51UsuarioApellido = P00415_A51UsuarioApellido[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpchartsfacturasds_1_filterfulltext)) || ( ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A80FacturaEstatus)) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "en proceso", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "En Proceso", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "aprobada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Aprobada", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "rechazada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Rechazada", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "cancelada", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, context.GetMessage( "Cancelada", "")) == 0 ) ) || ( StringUtil.Like( A71FacturaNo , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A20MotivoRechazoDescripcion , StringUtil.PadR( "%" + AV76Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               AV57count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( P00415_A19MotivoRechazoID[0] == A19MotivoRechazoID ) )
               {
                  BRK418 = false;
                  A69FacturaID = P00415_A69FacturaID[0];
                  AV57count = (long)(AV57count+1);
                  BRK418 = true;
                  pr_default.readNext(3);
               }
               AV52Option = (String.IsNullOrEmpty(StringUtil.RTrim( A20MotivoRechazoDescripcion)) ? "<#Empty#>" : A20MotivoRechazoDescripcion);
               AV51InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV52Option, "<#Empty#>") != 0 ) && ( AV51InsertIndex <= AV53Options.Count ) && ( ( StringUtil.StrCmp(((string)AV53Options.Item(AV51InsertIndex)), AV52Option) < 0 ) || ( StringUtil.StrCmp(((string)AV53Options.Item(AV51InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV51InsertIndex = (int)(AV51InsertIndex+1);
               }
               AV53Options.Add(AV52Option, AV51InsertIndex);
               AV56OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV57count), "Z,ZZZ,ZZZ,ZZ9")), AV51InsertIndex);
               if ( AV53Options.Count == AV48SkipItems + 11 )
               {
                  AV53Options.RemoveItem(AV53Options.Count);
                  AV56OptionIndexes.RemoveItem(AV56OptionIndexes.Count);
               }
            }
            if ( ! BRK418 )
            {
               BRK418 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
         while ( AV48SkipItems > 0 )
         {
            AV53Options.RemoveItem(1);
            AV56OptionIndexes.RemoveItem(1);
            AV48SkipItems = (short)(AV48SkipItems-1);
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
         AV66OptionsJson = "";
         AV67OptionsDescJson = "";
         AV68OptionIndexesJson = "";
         AV53Options = new GxSimpleCollection<string>();
         AV55OptionsDesc = new GxSimpleCollection<string>();
         AV56OptionIndexes = new GxSimpleCollection<string>();
         AV47SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV58Session = context.GetSession();
         AV60GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV61GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV69FilterFullText = "";
         AV14TFPromocionDescripcion = "";
         AV15TFPromocionDescripcion_Sel = "";
         AV40TFFacturaEstatus_SelsJson = "";
         AV41TFFacturaEstatus_Sels = new GxSimpleCollection<string>();
         AV22TFFacturaFechaFactura = DateTime.MinValue;
         AV23TFFacturaFechaFactura_To = DateTime.MinValue;
         AV24TFFacturaFechaRegistro = DateTime.MinValue;
         AV25TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV20TFFacturaNo = "";
         AV21TFFacturaNo_Sel = "";
         AV28TFUsuarioNombreCompleto = "";
         AV29TFUsuarioNombreCompleto_Sel = "";
         AV44TFMotivoRechazoDescripcion = "";
         AV45TFMotivoRechazoDescripcion_Sel = "";
         AV76Wpchartsfacturasds_1_filterfulltext = "";
         AV77Wpchartsfacturasds_2_tfpromociondescripcion = "";
         AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel = "";
         AV79Wpchartsfacturasds_4_tffacturaestatus_sels = new GxSimpleCollection<string>();
         AV80Wpchartsfacturasds_5_tffacturafechafactura = DateTime.MinValue;
         AV81Wpchartsfacturasds_6_tffacturafechafactura_to = DateTime.MinValue;
         AV82Wpchartsfacturasds_7_tffacturafecharegistro = DateTime.MinValue;
         AV83Wpchartsfacturasds_8_tffacturafecharegistro_to = DateTime.MinValue;
         AV84Wpchartsfacturasds_9_tffacturano = "";
         AV85Wpchartsfacturasds_10_tffacturano_sel = "";
         AV86Wpchartsfacturasds_11_tfusuarionombrecompleto = "";
         AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = "";
         AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion = "";
         AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = "";
         lV76Wpchartsfacturasds_1_filterfulltext = "";
         lV77Wpchartsfacturasds_2_tfpromociondescripcion = "";
         lV84Wpchartsfacturasds_9_tffacturano = "";
         lV86Wpchartsfacturasds_11_tfusuarionombrecompleto = "";
         lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion = "";
         AV73ListaUsuarios = new GxSimpleCollection<int>();
         A80FacturaEstatus = "";
         A42PromocionDescripcion = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         A72FacturaFechaRegistro = DateTime.MinValue;
         A71FacturaNo = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A20MotivoRechazoDescripcion = "";
         A52UsuarioNombreCompleto = "";
         AV70FromDate = DateTime.MinValue;
         AV71ToDate = DateTime.MinValue;
         P00412_A19MotivoRechazoID = new int[1] ;
         P00412_A41PromocionID = new int[1] ;
         P00412_A29UsuarioID = new int[1] ;
         P00412_A93FacturaCompleta = new bool[] {false} ;
         P00412_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P00412_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00412_A20MotivoRechazoDescripcion = new string[] {""} ;
         P00412_A52UsuarioNombreCompleto = new string[] {""} ;
         P00412_A71FacturaNo = new string[] {""} ;
         P00412_A80FacturaEstatus = new string[] {""} ;
         P00412_A42PromocionDescripcion = new string[] {""} ;
         P00412_A30UsuarioNombre = new string[] {""} ;
         P00412_A51UsuarioApellido = new string[] {""} ;
         P00412_A69FacturaID = new int[1] ;
         AV52Option = "";
         P00413_A41PromocionID = new int[1] ;
         P00413_A19MotivoRechazoID = new int[1] ;
         P00413_A71FacturaNo = new string[] {""} ;
         P00413_A29UsuarioID = new int[1] ;
         P00413_A93FacturaCompleta = new bool[] {false} ;
         P00413_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P00413_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00413_A20MotivoRechazoDescripcion = new string[] {""} ;
         P00413_A52UsuarioNombreCompleto = new string[] {""} ;
         P00413_A80FacturaEstatus = new string[] {""} ;
         P00413_A42PromocionDescripcion = new string[] {""} ;
         P00413_A30UsuarioNombre = new string[] {""} ;
         P00413_A51UsuarioApellido = new string[] {""} ;
         P00413_A69FacturaID = new int[1] ;
         P00414_A41PromocionID = new int[1] ;
         P00414_A19MotivoRechazoID = new int[1] ;
         P00414_A29UsuarioID = new int[1] ;
         P00414_A93FacturaCompleta = new bool[] {false} ;
         P00414_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P00414_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00414_A20MotivoRechazoDescripcion = new string[] {""} ;
         P00414_A52UsuarioNombreCompleto = new string[] {""} ;
         P00414_A71FacturaNo = new string[] {""} ;
         P00414_A80FacturaEstatus = new string[] {""} ;
         P00414_A42PromocionDescripcion = new string[] {""} ;
         P00414_A30UsuarioNombre = new string[] {""} ;
         P00414_A51UsuarioApellido = new string[] {""} ;
         P00414_A69FacturaID = new int[1] ;
         P00415_A41PromocionID = new int[1] ;
         P00415_A19MotivoRechazoID = new int[1] ;
         P00415_A29UsuarioID = new int[1] ;
         P00415_A93FacturaCompleta = new bool[] {false} ;
         P00415_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P00415_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00415_A20MotivoRechazoDescripcion = new string[] {""} ;
         P00415_A52UsuarioNombreCompleto = new string[] {""} ;
         P00415_A71FacturaNo = new string[] {""} ;
         P00415_A80FacturaEstatus = new string[] {""} ;
         P00415_A42PromocionDescripcion = new string[] {""} ;
         P00415_A30UsuarioNombre = new string[] {""} ;
         P00415_A51UsuarioApellido = new string[] {""} ;
         P00415_A69FacturaID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpchartsfacturasgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00412_A19MotivoRechazoID, P00412_A41PromocionID, P00412_A29UsuarioID, P00412_A93FacturaCompleta, P00412_A72FacturaFechaRegistro, P00412_A73FacturaFechaFactura, P00412_A20MotivoRechazoDescripcion, P00412_A52UsuarioNombreCompleto, P00412_A71FacturaNo, P00412_A80FacturaEstatus,
               P00412_A42PromocionDescripcion, P00412_A30UsuarioNombre, P00412_A51UsuarioApellido, P00412_A69FacturaID
               }
               , new Object[] {
               P00413_A41PromocionID, P00413_A19MotivoRechazoID, P00413_A71FacturaNo, P00413_A29UsuarioID, P00413_A93FacturaCompleta, P00413_A72FacturaFechaRegistro, P00413_A73FacturaFechaFactura, P00413_A20MotivoRechazoDescripcion, P00413_A52UsuarioNombreCompleto, P00413_A80FacturaEstatus,
               P00413_A42PromocionDescripcion, P00413_A30UsuarioNombre, P00413_A51UsuarioApellido, P00413_A69FacturaID
               }
               , new Object[] {
               P00414_A41PromocionID, P00414_A19MotivoRechazoID, P00414_A29UsuarioID, P00414_A93FacturaCompleta, P00414_A72FacturaFechaRegistro, P00414_A73FacturaFechaFactura, P00414_A20MotivoRechazoDescripcion, P00414_A52UsuarioNombreCompleto, P00414_A71FacturaNo, P00414_A80FacturaEstatus,
               P00414_A42PromocionDescripcion, P00414_A30UsuarioNombre, P00414_A51UsuarioApellido, P00414_A69FacturaID
               }
               , new Object[] {
               P00415_A41PromocionID, P00415_A19MotivoRechazoID, P00415_A29UsuarioID, P00415_A93FacturaCompleta, P00415_A72FacturaFechaRegistro, P00415_A73FacturaFechaFactura, P00415_A20MotivoRechazoDescripcion, P00415_A52UsuarioNombreCompleto, P00415_A71FacturaNo, P00415_A80FacturaEstatus,
               P00415_A42PromocionDescripcion, P00415_A30UsuarioNombre, P00415_A51UsuarioApellido, P00415_A69FacturaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV50MaxItems ;
      private short AV49PageIndex ;
      private short AV48SkipItems ;
      private int AV74GXV1 ;
      private int AV79Wpchartsfacturasds_4_tffacturaestatus_sels_Count ;
      private int A29UsuarioID ;
      private int A19MotivoRechazoID ;
      private int A41PromocionID ;
      private int A69FacturaID ;
      private int AV51InsertIndex ;
      private long AV57count ;
      private string AV20TFFacturaNo ;
      private string AV21TFFacturaNo_Sel ;
      private string AV84Wpchartsfacturasds_9_tffacturano ;
      private string AV85Wpchartsfacturasds_10_tffacturano_sel ;
      private string lV84Wpchartsfacturasds_9_tffacturano ;
      private string A80FacturaEstatus ;
      private string A71FacturaNo ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private DateTime AV22TFFacturaFechaFactura ;
      private DateTime AV23TFFacturaFechaFactura_To ;
      private DateTime AV24TFFacturaFechaRegistro ;
      private DateTime AV25TFFacturaFechaRegistro_To ;
      private DateTime AV80Wpchartsfacturasds_5_tffacturafechafactura ;
      private DateTime AV81Wpchartsfacturasds_6_tffacturafechafactura_to ;
      private DateTime AV82Wpchartsfacturasds_7_tffacturafecharegistro ;
      private DateTime AV83Wpchartsfacturasds_8_tffacturafecharegistro_to ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime AV70FromDate ;
      private DateTime AV71ToDate ;
      private bool returnInSub ;
      private bool A93FacturaCompleta ;
      private bool BRK412 ;
      private bool BRK414 ;
      private bool BRK416 ;
      private bool BRK418 ;
      private string AV66OptionsJson ;
      private string AV67OptionsDescJson ;
      private string AV68OptionIndexesJson ;
      private string AV40TFFacturaEstatus_SelsJson ;
      private string AV63DDOName ;
      private string AV64SearchTxtParms ;
      private string AV65SearchTxtTo ;
      private string AV47SearchTxt ;
      private string AV69FilterFullText ;
      private string AV14TFPromocionDescripcion ;
      private string AV15TFPromocionDescripcion_Sel ;
      private string AV28TFUsuarioNombreCompleto ;
      private string AV29TFUsuarioNombreCompleto_Sel ;
      private string AV44TFMotivoRechazoDescripcion ;
      private string AV45TFMotivoRechazoDescripcion_Sel ;
      private string AV76Wpchartsfacturasds_1_filterfulltext ;
      private string AV77Wpchartsfacturasds_2_tfpromociondescripcion ;
      private string AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel ;
      private string AV86Wpchartsfacturasds_11_tfusuarionombrecompleto ;
      private string AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ;
      private string AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion ;
      private string AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ;
      private string lV76Wpchartsfacturasds_1_filterfulltext ;
      private string lV77Wpchartsfacturasds_2_tfpromociondescripcion ;
      private string lV86Wpchartsfacturasds_11_tfusuarionombrecompleto ;
      private string lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion ;
      private string A42PromocionDescripcion ;
      private string A20MotivoRechazoDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV52Option ;
      private IGxSession AV58Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV53Options ;
      private GxSimpleCollection<string> AV55OptionsDesc ;
      private GxSimpleCollection<string> AV56OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV60GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV61GridStateFilterValue ;
      private GxSimpleCollection<string> AV41TFFacturaEstatus_Sels ;
      private GxSimpleCollection<string> AV79Wpchartsfacturasds_4_tffacturaestatus_sels ;
      private GxSimpleCollection<int> AV73ListaUsuarios ;
      private IDataStoreProvider pr_default ;
      private int[] P00412_A19MotivoRechazoID ;
      private int[] P00412_A41PromocionID ;
      private int[] P00412_A29UsuarioID ;
      private bool[] P00412_A93FacturaCompleta ;
      private DateTime[] P00412_A72FacturaFechaRegistro ;
      private DateTime[] P00412_A73FacturaFechaFactura ;
      private string[] P00412_A20MotivoRechazoDescripcion ;
      private string[] P00412_A52UsuarioNombreCompleto ;
      private string[] P00412_A71FacturaNo ;
      private string[] P00412_A80FacturaEstatus ;
      private string[] P00412_A42PromocionDescripcion ;
      private string[] P00412_A30UsuarioNombre ;
      private string[] P00412_A51UsuarioApellido ;
      private int[] P00412_A69FacturaID ;
      private int[] P00413_A41PromocionID ;
      private int[] P00413_A19MotivoRechazoID ;
      private string[] P00413_A71FacturaNo ;
      private int[] P00413_A29UsuarioID ;
      private bool[] P00413_A93FacturaCompleta ;
      private DateTime[] P00413_A72FacturaFechaRegistro ;
      private DateTime[] P00413_A73FacturaFechaFactura ;
      private string[] P00413_A20MotivoRechazoDescripcion ;
      private string[] P00413_A52UsuarioNombreCompleto ;
      private string[] P00413_A80FacturaEstatus ;
      private string[] P00413_A42PromocionDescripcion ;
      private string[] P00413_A30UsuarioNombre ;
      private string[] P00413_A51UsuarioApellido ;
      private int[] P00413_A69FacturaID ;
      private int[] P00414_A41PromocionID ;
      private int[] P00414_A19MotivoRechazoID ;
      private int[] P00414_A29UsuarioID ;
      private bool[] P00414_A93FacturaCompleta ;
      private DateTime[] P00414_A72FacturaFechaRegistro ;
      private DateTime[] P00414_A73FacturaFechaFactura ;
      private string[] P00414_A20MotivoRechazoDescripcion ;
      private string[] P00414_A52UsuarioNombreCompleto ;
      private string[] P00414_A71FacturaNo ;
      private string[] P00414_A80FacturaEstatus ;
      private string[] P00414_A42PromocionDescripcion ;
      private string[] P00414_A30UsuarioNombre ;
      private string[] P00414_A51UsuarioApellido ;
      private int[] P00414_A69FacturaID ;
      private int[] P00415_A41PromocionID ;
      private int[] P00415_A19MotivoRechazoID ;
      private int[] P00415_A29UsuarioID ;
      private bool[] P00415_A93FacturaCompleta ;
      private DateTime[] P00415_A72FacturaFechaRegistro ;
      private DateTime[] P00415_A73FacturaFechaFactura ;
      private string[] P00415_A20MotivoRechazoDescripcion ;
      private string[] P00415_A52UsuarioNombreCompleto ;
      private string[] P00415_A71FacturaNo ;
      private string[] P00415_A80FacturaEstatus ;
      private string[] P00415_A42PromocionDescripcion ;
      private string[] P00415_A30UsuarioNombre ;
      private string[] P00415_A51UsuarioApellido ;
      private int[] P00415_A69FacturaID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpchartsfacturasgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00412( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV73ListaUsuarios ,
                                             string A80FacturaEstatus ,
                                             GxSimpleCollection<string> AV79Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                             string AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                             string AV77Wpchartsfacturasds_2_tfpromociondescripcion ,
                                             int AV79Wpchartsfacturasds_4_tffacturaestatus_sels_Count ,
                                             DateTime AV80Wpchartsfacturasds_5_tffacturafechafactura ,
                                             DateTime AV81Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                             DateTime AV82Wpchartsfacturasds_7_tffacturafecharegistro ,
                                             DateTime AV83Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                             string AV85Wpchartsfacturasds_10_tffacturano_sel ,
                                             string AV84Wpchartsfacturasds_9_tffacturano ,
                                             string AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                             string AV86Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                             string AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                             string AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                             string A42PromocionDescripcion ,
                                             DateTime A73FacturaFechaFactura ,
                                             DateTime A72FacturaFechaRegistro ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A20MotivoRechazoDescripcion ,
                                             string AV76Wpchartsfacturasds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto ,
                                             DateTime AV70FromDate ,
                                             DateTime AV71ToDate ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`MotivoRechazoID`, T1.`PromocionID`, T1.`UsuarioID`, T1.`FacturaCompleta`, T1.`FacturaFechaRegistro`, T1.`FacturaFechaFactura`, T2.`MotivoRechazoDescripcion`, CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`FacturaNo`, T1.`FacturaEstatus`, T3.`PromocionDescripcion`, T4.`UsuarioNombre`, T4.`UsuarioApellido`, T1.`FacturaID` FROM (((`Factura` T1 INNER JOIN `MotivoRechazo` T2 ON T2.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Promocion` T3 ON T3.`PromocionID` = T1.`PromocionID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV70FromDate)");
         AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV71ToDate)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpchartsfacturasds_2_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`PromocionDescripcion` like @lV77Wpchartsfacturasds_2_tfpromociondescripcion)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`PromocionDescripcion` = @AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`PromocionDescripcion`))=0))");
         }
         if ( AV79Wpchartsfacturasds_4_tffacturaestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Wpchartsfacturasds_4_tffacturaestatus_sels, "T1.`FacturaEstatus` IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV80Wpchartsfacturasds_5_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV80Wpchartsfacturasds_5_tffacturafechafactura)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Wpchartsfacturasds_6_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV81Wpchartsfacturasds_6_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Wpchartsfacturasds_7_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV82Wpchartsfacturasds_7_tffacturafecharegistro)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wpchartsfacturasds_8_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV83Wpchartsfacturasds_8_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpchartsfacturasds_10_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpchartsfacturasds_9_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV84Wpchartsfacturasds_9_tffacturano)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpchartsfacturasds_10_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV85Wpchartsfacturasds_10_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV85Wpchartsfacturasds_10_tffacturano_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wpchartsfacturasds_10_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpchartsfacturasds_11_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV86Wpchartsfacturasds_11_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`MotivoRechazoDescripcion` like @lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ! ( StringUtil.StrCmp(AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MotivoRechazoDescripcion` = @AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MotivoRechazoDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`PromocionID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00413( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV73ListaUsuarios ,
                                             string A80FacturaEstatus ,
                                             GxSimpleCollection<string> AV79Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                             string AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                             string AV77Wpchartsfacturasds_2_tfpromociondescripcion ,
                                             int AV79Wpchartsfacturasds_4_tffacturaestatus_sels_Count ,
                                             DateTime AV80Wpchartsfacturasds_5_tffacturafechafactura ,
                                             DateTime AV81Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                             DateTime AV82Wpchartsfacturasds_7_tffacturafecharegistro ,
                                             DateTime AV83Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                             string AV85Wpchartsfacturasds_10_tffacturano_sel ,
                                             string AV84Wpchartsfacturasds_9_tffacturano ,
                                             string AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                             string AV86Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                             string AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                             string AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                             string A42PromocionDescripcion ,
                                             DateTime A73FacturaFechaFactura ,
                                             DateTime A72FacturaFechaRegistro ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A20MotivoRechazoDescripcion ,
                                             string AV76Wpchartsfacturasds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto ,
                                             DateTime AV70FromDate ,
                                             DateTime AV71ToDate ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`MotivoRechazoID`, T1.`FacturaNo`, T1.`UsuarioID`, T1.`FacturaCompleta`, T1.`FacturaFechaRegistro`, T1.`FacturaFechaFactura`, T3.`MotivoRechazoDescripcion`, CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`FacturaEstatus`, T2.`PromocionDescripcion`, T4.`UsuarioNombre`, T4.`UsuarioApellido`, T1.`FacturaID` FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV70FromDate)");
         AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV71ToDate)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpchartsfacturasds_2_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV77Wpchartsfacturasds_2_tfpromociondescripcion)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( AV79Wpchartsfacturasds_4_tffacturaestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Wpchartsfacturasds_4_tffacturaestatus_sels, "T1.`FacturaEstatus` IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV80Wpchartsfacturasds_5_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV80Wpchartsfacturasds_5_tffacturafechafactura)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Wpchartsfacturasds_6_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV81Wpchartsfacturasds_6_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Wpchartsfacturasds_7_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV82Wpchartsfacturasds_7_tffacturafecharegistro)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wpchartsfacturasds_8_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV83Wpchartsfacturasds_8_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpchartsfacturasds_10_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpchartsfacturasds_9_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV84Wpchartsfacturasds_9_tffacturano)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpchartsfacturasds_10_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV85Wpchartsfacturasds_10_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV85Wpchartsfacturasds_10_tffacturano_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wpchartsfacturasds_10_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpchartsfacturasds_11_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV86Wpchartsfacturasds_11_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`MotivoRechazoDescripcion` like @lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ! ( StringUtil.StrCmp(AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`MotivoRechazoDescripcion` = @AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`MotivoRechazoDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`FacturaNo`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00414( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV73ListaUsuarios ,
                                             string A80FacturaEstatus ,
                                             GxSimpleCollection<string> AV79Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                             string AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                             string AV77Wpchartsfacturasds_2_tfpromociondescripcion ,
                                             int AV79Wpchartsfacturasds_4_tffacturaestatus_sels_Count ,
                                             DateTime AV80Wpchartsfacturasds_5_tffacturafechafactura ,
                                             DateTime AV81Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                             DateTime AV82Wpchartsfacturasds_7_tffacturafecharegistro ,
                                             DateTime AV83Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                             string AV85Wpchartsfacturasds_10_tffacturano_sel ,
                                             string AV84Wpchartsfacturasds_9_tffacturano ,
                                             string AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                             string AV86Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                             string AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                             string AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                             string A42PromocionDescripcion ,
                                             DateTime A73FacturaFechaFactura ,
                                             DateTime A72FacturaFechaRegistro ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A20MotivoRechazoDescripcion ,
                                             string AV76Wpchartsfacturasds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto ,
                                             DateTime AV70FromDate ,
                                             DateTime AV71ToDate ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`MotivoRechazoID`, T1.`UsuarioID`, T1.`FacturaCompleta`, T1.`FacturaFechaRegistro`, T1.`FacturaFechaFactura`, T3.`MotivoRechazoDescripcion`, CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`FacturaNo`, T1.`FacturaEstatus`, T2.`PromocionDescripcion`, T4.`UsuarioNombre`, T4.`UsuarioApellido`, T1.`FacturaID` FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV70FromDate)");
         AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV71ToDate)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpchartsfacturasds_2_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV77Wpchartsfacturasds_2_tfpromociondescripcion)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( AV79Wpchartsfacturasds_4_tffacturaestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Wpchartsfacturasds_4_tffacturaestatus_sels, "T1.`FacturaEstatus` IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV80Wpchartsfacturasds_5_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV80Wpchartsfacturasds_5_tffacturafechafactura)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Wpchartsfacturasds_6_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV81Wpchartsfacturasds_6_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Wpchartsfacturasds_7_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV82Wpchartsfacturasds_7_tffacturafecharegistro)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wpchartsfacturasds_8_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV83Wpchartsfacturasds_8_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpchartsfacturasds_10_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpchartsfacturasds_9_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV84Wpchartsfacturasds_9_tffacturano)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpchartsfacturasds_10_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV85Wpchartsfacturasds_10_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV85Wpchartsfacturasds_10_tffacturano_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wpchartsfacturasds_10_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpchartsfacturasds_11_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV86Wpchartsfacturasds_11_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`MotivoRechazoDescripcion` like @lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ! ( StringUtil.StrCmp(AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`MotivoRechazoDescripcion` = @AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`MotivoRechazoDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioID`";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00415( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV73ListaUsuarios ,
                                             string A80FacturaEstatus ,
                                             GxSimpleCollection<string> AV79Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                             string AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                             string AV77Wpchartsfacturasds_2_tfpromociondescripcion ,
                                             int AV79Wpchartsfacturasds_4_tffacturaestatus_sels_Count ,
                                             DateTime AV80Wpchartsfacturasds_5_tffacturafechafactura ,
                                             DateTime AV81Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                             DateTime AV82Wpchartsfacturasds_7_tffacturafecharegistro ,
                                             DateTime AV83Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                             string AV85Wpchartsfacturasds_10_tffacturano_sel ,
                                             string AV84Wpchartsfacturasds_9_tffacturano ,
                                             string AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                             string AV86Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                             string AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                             string AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                             string A42PromocionDescripcion ,
                                             DateTime A73FacturaFechaFactura ,
                                             DateTime A72FacturaFechaRegistro ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A20MotivoRechazoDescripcion ,
                                             string AV76Wpchartsfacturasds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto ,
                                             DateTime AV70FromDate ,
                                             DateTime AV71ToDate ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[14];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`MotivoRechazoID`, T1.`UsuarioID`, T1.`FacturaCompleta`, T1.`FacturaFechaRegistro`, T1.`FacturaFechaFactura`, T3.`MotivoRechazoDescripcion`, CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`FacturaNo`, T1.`FacturaEstatus`, T2.`PromocionDescripcion`, T4.`UsuarioNombre`, T4.`UsuarioApellido`, T1.`FacturaID` FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV70FromDate)");
         AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV71ToDate)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpchartsfacturasds_2_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV77Wpchartsfacturasds_2_tfpromociondescripcion)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( AV79Wpchartsfacturasds_4_tffacturaestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Wpchartsfacturasds_4_tffacturaestatus_sels, "T1.`FacturaEstatus` IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV80Wpchartsfacturasds_5_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV80Wpchartsfacturasds_5_tffacturafechafactura)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Wpchartsfacturasds_6_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV81Wpchartsfacturasds_6_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Wpchartsfacturasds_7_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV82Wpchartsfacturasds_7_tffacturafecharegistro)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Wpchartsfacturasds_8_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV83Wpchartsfacturasds_8_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpchartsfacturasds_10_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpchartsfacturasds_9_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV84Wpchartsfacturasds_9_tffacturano)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpchartsfacturasds_10_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV85Wpchartsfacturasds_10_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV85Wpchartsfacturasds_10_tffacturano_sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wpchartsfacturasds_10_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpchartsfacturasds_11_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV86Wpchartsfacturasds_11_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpchartsfacturasds_13_tfmotivorechazodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`MotivoRechazoDescripcion` like @lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ! ( StringUtil.StrCmp(AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`MotivoRechazoDescripcion` = @AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`MotivoRechazoDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`MotivoRechazoID`";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00412(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (bool)dynConstraints[28] );
               case 1 :
                     return conditional_P00413(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (bool)dynConstraints[28] );
               case 2 :
                     return conditional_P00414(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (bool)dynConstraints[28] );
               case 3 :
                     return conditional_P00415(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (bool)dynConstraints[28] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00412;
          prmP00412 = new Object[] {
          new ParDef("@AV70FromDate",GXType.Date,8,0) ,
          new ParDef("@AV71ToDate",GXType.Date,8,0) ,
          new ParDef("@lV77Wpchartsfacturasds_2_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV80Wpchartsfacturasds_5_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV81Wpchartsfacturasds_6_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@AV82Wpchartsfacturasds_7_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV83Wpchartsfacturasds_8_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV84Wpchartsfacturasds_9_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV85Wpchartsfacturasds_10_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@lV86Wpchartsfacturasds_11_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel",GXType.Char,80,0)
          };
          Object[] prmP00413;
          prmP00413 = new Object[] {
          new ParDef("@AV70FromDate",GXType.Date,8,0) ,
          new ParDef("@AV71ToDate",GXType.Date,8,0) ,
          new ParDef("@lV77Wpchartsfacturasds_2_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV80Wpchartsfacturasds_5_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV81Wpchartsfacturasds_6_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@AV82Wpchartsfacturasds_7_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV83Wpchartsfacturasds_8_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV84Wpchartsfacturasds_9_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV85Wpchartsfacturasds_10_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@lV86Wpchartsfacturasds_11_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel",GXType.Char,80,0)
          };
          Object[] prmP00414;
          prmP00414 = new Object[] {
          new ParDef("@AV70FromDate",GXType.Date,8,0) ,
          new ParDef("@AV71ToDate",GXType.Date,8,0) ,
          new ParDef("@lV77Wpchartsfacturasds_2_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV80Wpchartsfacturasds_5_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV81Wpchartsfacturasds_6_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@AV82Wpchartsfacturasds_7_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV83Wpchartsfacturasds_8_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV84Wpchartsfacturasds_9_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV85Wpchartsfacturasds_10_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@lV86Wpchartsfacturasds_11_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel",GXType.Char,80,0)
          };
          Object[] prmP00415;
          prmP00415 = new Object[] {
          new ParDef("@AV70FromDate",GXType.Date,8,0) ,
          new ParDef("@AV71ToDate",GXType.Date,8,0) ,
          new ParDef("@lV77Wpchartsfacturasds_2_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV78Wpchartsfacturasds_3_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV80Wpchartsfacturasds_5_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV81Wpchartsfacturasds_6_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@AV82Wpchartsfacturasds_7_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV83Wpchartsfacturasds_8_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV84Wpchartsfacturasds_9_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV85Wpchartsfacturasds_10_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@lV86Wpchartsfacturasds_11_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV87Wpchartsfacturasds_12_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV88Wpchartsfacturasds_13_tfmotivorechazodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV89Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel",GXType.Char,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00412", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00412,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00413", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00413,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00414", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00414,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00415", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00415,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 50);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                ((int[]) buf[13])[0] = rslt.getInt(14);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 50);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                ((int[]) buf[13])[0] = rslt.getInt(14);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 50);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                ((int[]) buf[13])[0] = rslt.getInt(14);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 50);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                ((int[]) buf[13])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
