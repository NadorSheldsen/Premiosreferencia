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
   public class wpdetallepromocionadminfacturawcgetfilterdata : GXProcedure
   {
      public wpdetallepromocionadminfacturawcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpdetallepromocionadminfacturawcgetfilterdata( IGxContext context )
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
         this.AV50DDOName = aP0_DDOName;
         this.AV51SearchTxtParms = aP1_SearchTxtParms;
         this.AV52SearchTxtTo = aP2_SearchTxtTo;
         this.AV53OptionsJson = "" ;
         this.AV54OptionsDescJson = "" ;
         this.AV55OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV53OptionsJson;
         aP4_OptionsDescJson=this.AV54OptionsDescJson;
         aP5_OptionIndexesJson=this.AV55OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV55OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV50DDOName = aP0_DDOName;
         this.AV51SearchTxtParms = aP1_SearchTxtParms;
         this.AV52SearchTxtTo = aP2_SearchTxtTo;
         this.AV53OptionsJson = "" ;
         this.AV54OptionsDescJson = "" ;
         this.AV55OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV53OptionsJson;
         aP4_OptionsDescJson=this.AV54OptionsDescJson;
         aP5_OptionIndexesJson=this.AV55OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV40Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV43OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37MaxItems = 10;
         AV36PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV51SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV51SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV34SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV51SearchTxtParms)) ? "" : StringUtil.Substring( AV51SearchTxtParms, 3, -1));
         AV35SkipItems = (short)(AV36PageIndex*AV37MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV50DDOName), "DDO_PROMOCIONDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV50DDOName), "DDO_FACTURANO") == 0 )
         {
            /* Execute user subroutine: 'LOADFACTURANOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV50DDOName), "DDO_USUARIONOMBRECOMPLETO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIONOMBRECOMPLETOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV53OptionsJson = AV40Options.ToJSonString(false);
         AV54OptionsDescJson = AV42OptionsDesc.ToJSonString(false);
         AV55OptionIndexesJson = AV43OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV45Session.Get("WPDetallePromocionAdminFacturaWCGridState"), "") == 0 )
         {
            AV47GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPDetallePromocionAdminFacturaWCGridState"), null, "", "");
         }
         else
         {
            AV47GridState.FromXml(AV45Session.Get("WPDetallePromocionAdminFacturaWCGridState"), null, "", "");
         }
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV47GridState.gxTpr_Filtervalues.Count )
         {
            AV48GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV47GridState.gxTpr_Filtervalues.Item(AV58GXV1));
            if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV56FilterFullText = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV12TFFacturaFechaRegistro = context.localUtil.CToD( AV48GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV13TFFacturaFechaRegistro_To = context.localUtil.CToD( AV48GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV14TFPromocionDescripcion = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV15TFPromocionDescripcion_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFFACTURANO") == 0 )
            {
               AV16TFFacturaNo = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFFACTURANO_SEL") == 0 )
            {
               AV17TFFacturaNo_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV18TFFacturaFechaFactura = context.localUtil.CToD( AV48GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV19TFFacturaFechaFactura_To = context.localUtil.CToD( AV48GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFESTATUS") == 0 )
            {
               AV21TFEstatusOperator = AV48GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV30TFUsuarioNombreCompleto = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV31TFUsuarioNombreCompleto_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "PARM_&PROMOCIONID") == 0 )
            {
               AV57PromocionID = (int)(Math.Round(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROMOCIONDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFPromocionDescripcion = AV34SearchTxt;
         AV15TFPromocionDescripcion_Sel = "";
         AV60Wpdetallepromocionadminfacturawcds_1_promocionid = AV57PromocionID;
         AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = AV56FilterFullText;
         AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = AV12TFFacturaFechaRegistro;
         AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = AV13TFFacturaFechaRegistro_To;
         AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV66Wpdetallepromocionadminfacturawcds_7_tffacturano = AV16TFFacturaNo;
         AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = AV17TFFacturaNo_Sel;
         AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = AV18TFFacturaFechaFactura;
         AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = AV19TFFacturaFechaFactura_To;
         AV70Wpdetallepromocionadminfacturawcds_11_tfestatus = AV20TFEstatus;
         AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator = AV21TFEstatusOperator;
         AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = AV30TFUsuarioNombreCompleto;
         AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = AV31TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext ,
                                              AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ,
                                              AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ,
                                              AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ,
                                              AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ,
                                              AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ,
                                              AV66Wpdetallepromocionadminfacturawcds_7_tffacturano ,
                                              AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ,
                                              AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ,
                                              AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ,
                                              AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ,
                                              AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              AV60Wpdetallepromocionadminfacturawcds_1_promocionid ,
                                              A41PromocionID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion), "%", "");
         lV66Wpdetallepromocionadminfacturawcds_7_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV66Wpdetallepromocionadminfacturawcds_7_tffacturano), 20, "%");
         lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto), "%", "");
         /* Using cursor P003D2 */
         pr_default.execute(0, new Object[] {AV60Wpdetallepromocionadminfacturawcds_1_promocionid, lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext, lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext, lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext, AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro, AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to, lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion, AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, lV66Wpdetallepromocionadminfacturawcds_7_tffacturano, AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura, AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to, lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto, AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3D2 = false;
            A29UsuarioID = P003D2_A29UsuarioID[0];
            A41PromocionID = P003D2_A41PromocionID[0];
            A80FacturaEstatus = P003D2_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P003D2_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P003D2_A72FacturaFechaRegistro[0];
            A71FacturaNo = P003D2_A71FacturaNo[0];
            A42PromocionDescripcion = P003D2_A42PromocionDescripcion[0];
            A51UsuarioApellido = P003D2_A51UsuarioApellido[0];
            A30UsuarioNombre = P003D2_A30UsuarioNombre[0];
            A69FacturaID = P003D2_A69FacturaID[0];
            A51UsuarioApellido = P003D2_A51UsuarioApellido[0];
            A30UsuarioNombre = P003D2_A30UsuarioNombre[0];
            A42PromocionDescripcion = P003D2_A42PromocionDescripcion[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV44count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P003D2_A41PromocionID[0] == A41PromocionID ) )
            {
               BRK3D2 = false;
               A69FacturaID = P003D2_A69FacturaID[0];
               AV44count = (long)(AV44count+1);
               BRK3D2 = true;
               pr_default.readNext(0);
            }
            AV39Option = (String.IsNullOrEmpty(StringUtil.RTrim( A42PromocionDescripcion)) ? "<#Empty#>" : A42PromocionDescripcion);
            AV38InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV39Option, "<#Empty#>") != 0 ) && ( AV38InsertIndex <= AV40Options.Count ) && ( ( StringUtil.StrCmp(((string)AV40Options.Item(AV38InsertIndex)), AV39Option) < 0 ) || ( StringUtil.StrCmp(((string)AV40Options.Item(AV38InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV38InsertIndex = (int)(AV38InsertIndex+1);
            }
            AV40Options.Add(AV39Option, AV38InsertIndex);
            AV43OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), AV38InsertIndex);
            if ( AV40Options.Count == AV35SkipItems + 11 )
            {
               AV40Options.RemoveItem(AV40Options.Count);
               AV43OptionIndexes.RemoveItem(AV43OptionIndexes.Count);
            }
            if ( ! BRK3D2 )
            {
               BRK3D2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV35SkipItems > 0 )
         {
            AV40Options.RemoveItem(1);
            AV43OptionIndexes.RemoveItem(1);
            AV35SkipItems = (short)(AV35SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADFACTURANOOPTIONS' Routine */
         returnInSub = false;
         AV16TFFacturaNo = AV34SearchTxt;
         AV17TFFacturaNo_Sel = "";
         AV60Wpdetallepromocionadminfacturawcds_1_promocionid = AV57PromocionID;
         AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = AV56FilterFullText;
         AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = AV12TFFacturaFechaRegistro;
         AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = AV13TFFacturaFechaRegistro_To;
         AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV66Wpdetallepromocionadminfacturawcds_7_tffacturano = AV16TFFacturaNo;
         AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = AV17TFFacturaNo_Sel;
         AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = AV18TFFacturaFechaFactura;
         AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = AV19TFFacturaFechaFactura_To;
         AV70Wpdetallepromocionadminfacturawcds_11_tfestatus = AV20TFEstatus;
         AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator = AV21TFEstatusOperator;
         AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = AV30TFUsuarioNombreCompleto;
         AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = AV31TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext ,
                                              AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ,
                                              AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ,
                                              AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ,
                                              AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ,
                                              AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ,
                                              AV66Wpdetallepromocionadminfacturawcds_7_tffacturano ,
                                              AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ,
                                              AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ,
                                              AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ,
                                              AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ,
                                              AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              AV60Wpdetallepromocionadminfacturawcds_1_promocionid ,
                                              A41PromocionID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion), "%", "");
         lV66Wpdetallepromocionadminfacturawcds_7_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV66Wpdetallepromocionadminfacturawcds_7_tffacturano), 20, "%");
         lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto), "%", "");
         /* Using cursor P003D3 */
         pr_default.execute(1, new Object[] {AV60Wpdetallepromocionadminfacturawcds_1_promocionid, lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext, lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext, lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext, AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro, AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to, lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion, AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, lV66Wpdetallepromocionadminfacturawcds_7_tffacturano, AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura, AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to, lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto, AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3D4 = false;
            A29UsuarioID = P003D3_A29UsuarioID[0];
            A41PromocionID = P003D3_A41PromocionID[0];
            A71FacturaNo = P003D3_A71FacturaNo[0];
            A80FacturaEstatus = P003D3_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P003D3_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P003D3_A72FacturaFechaRegistro[0];
            A42PromocionDescripcion = P003D3_A42PromocionDescripcion[0];
            A51UsuarioApellido = P003D3_A51UsuarioApellido[0];
            A30UsuarioNombre = P003D3_A30UsuarioNombre[0];
            A69FacturaID = P003D3_A69FacturaID[0];
            A51UsuarioApellido = P003D3_A51UsuarioApellido[0];
            A30UsuarioNombre = P003D3_A30UsuarioNombre[0];
            A42PromocionDescripcion = P003D3_A42PromocionDescripcion[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV44count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P003D3_A41PromocionID[0] == A41PromocionID ) && ( StringUtil.StrCmp(P003D3_A71FacturaNo[0], A71FacturaNo) == 0 ) )
            {
               BRK3D4 = false;
               A69FacturaID = P003D3_A69FacturaID[0];
               AV44count = (long)(AV44count+1);
               BRK3D4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV35SkipItems) )
            {
               AV39Option = (String.IsNullOrEmpty(StringUtil.RTrim( A71FacturaNo)) ? "<#Empty#>" : A71FacturaNo);
               AV40Options.Add(AV39Option, 0);
               AV43OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV40Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV35SkipItems = (short)(AV35SkipItems-1);
            }
            if ( ! BRK3D4 )
            {
               BRK3D4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADUSUARIONOMBRECOMPLETOOPTIONS' Routine */
         returnInSub = false;
         AV30TFUsuarioNombreCompleto = AV34SearchTxt;
         AV31TFUsuarioNombreCompleto_Sel = "";
         AV60Wpdetallepromocionadminfacturawcds_1_promocionid = AV57PromocionID;
         AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = AV56FilterFullText;
         AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = AV12TFFacturaFechaRegistro;
         AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = AV13TFFacturaFechaRegistro_To;
         AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV66Wpdetallepromocionadminfacturawcds_7_tffacturano = AV16TFFacturaNo;
         AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = AV17TFFacturaNo_Sel;
         AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = AV18TFFacturaFechaFactura;
         AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = AV19TFFacturaFechaFactura_To;
         AV70Wpdetallepromocionadminfacturawcds_11_tfestatus = AV20TFEstatus;
         AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator = AV21TFEstatusOperator;
         AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = AV30TFUsuarioNombreCompleto;
         AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = AV31TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext ,
                                              AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ,
                                              AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ,
                                              AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ,
                                              AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ,
                                              AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ,
                                              AV66Wpdetallepromocionadminfacturawcds_7_tffacturano ,
                                              AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ,
                                              AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ,
                                              AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ,
                                              AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ,
                                              AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              AV60Wpdetallepromocionadminfacturawcds_1_promocionid ,
                                              A41PromocionID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion), "%", "");
         lV66Wpdetallepromocionadminfacturawcds_7_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV66Wpdetallepromocionadminfacturawcds_7_tffacturano), 20, "%");
         lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto), "%", "");
         /* Using cursor P003D4 */
         pr_default.execute(2, new Object[] {AV60Wpdetallepromocionadminfacturawcds_1_promocionid, lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext, lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext, lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext, AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro, AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to, lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion, AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, lV66Wpdetallepromocionadminfacturawcds_7_tffacturano, AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura, AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to, lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto, AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK3D6 = false;
            A41PromocionID = P003D4_A41PromocionID[0];
            A29UsuarioID = P003D4_A29UsuarioID[0];
            A80FacturaEstatus = P003D4_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P003D4_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P003D4_A72FacturaFechaRegistro[0];
            A71FacturaNo = P003D4_A71FacturaNo[0];
            A42PromocionDescripcion = P003D4_A42PromocionDescripcion[0];
            A51UsuarioApellido = P003D4_A51UsuarioApellido[0];
            A30UsuarioNombre = P003D4_A30UsuarioNombre[0];
            A69FacturaID = P003D4_A69FacturaID[0];
            A42PromocionDescripcion = P003D4_A42PromocionDescripcion[0];
            A51UsuarioApellido = P003D4_A51UsuarioApellido[0];
            A30UsuarioNombre = P003D4_A30UsuarioNombre[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV44count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P003D4_A41PromocionID[0] == A41PromocionID ) && ( P003D4_A29UsuarioID[0] == A29UsuarioID ) )
            {
               BRK3D6 = false;
               A69FacturaID = P003D4_A69FacturaID[0];
               AV44count = (long)(AV44count+1);
               BRK3D6 = true;
               pr_default.readNext(2);
            }
            AV39Option = (String.IsNullOrEmpty(StringUtil.RTrim( A52UsuarioNombreCompleto)) ? "<#Empty#>" : A52UsuarioNombreCompleto);
            AV38InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV39Option, "<#Empty#>") != 0 ) && ( AV38InsertIndex <= AV40Options.Count ) && ( ( StringUtil.StrCmp(((string)AV40Options.Item(AV38InsertIndex)), AV39Option) < 0 ) || ( StringUtil.StrCmp(((string)AV40Options.Item(AV38InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV38InsertIndex = (int)(AV38InsertIndex+1);
            }
            AV40Options.Add(AV39Option, AV38InsertIndex);
            AV43OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), AV38InsertIndex);
            if ( AV40Options.Count == AV35SkipItems + 11 )
            {
               AV40Options.RemoveItem(AV40Options.Count);
               AV43OptionIndexes.RemoveItem(AV43OptionIndexes.Count);
            }
            if ( ! BRK3D6 )
            {
               BRK3D6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV35SkipItems > 0 )
         {
            AV40Options.RemoveItem(1);
            AV43OptionIndexes.RemoveItem(1);
            AV35SkipItems = (short)(AV35SkipItems-1);
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
         AV53OptionsJson = "";
         AV54OptionsDescJson = "";
         AV55OptionIndexesJson = "";
         AV40Options = new GxSimpleCollection<string>();
         AV42OptionsDesc = new GxSimpleCollection<string>();
         AV43OptionIndexes = new GxSimpleCollection<string>();
         AV34SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV45Session = context.GetSession();
         AV47GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV48GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV56FilterFullText = "";
         AV12TFFacturaFechaRegistro = DateTime.MinValue;
         AV13TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV14TFPromocionDescripcion = "";
         AV15TFPromocionDescripcion_Sel = "";
         AV16TFFacturaNo = "";
         AV17TFFacturaNo_Sel = "";
         AV18TFFacturaFechaFactura = DateTime.MinValue;
         AV19TFFacturaFechaFactura_To = DateTime.MinValue;
         AV30TFUsuarioNombreCompleto = "";
         AV31TFUsuarioNombreCompleto_Sel = "";
         AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = "";
         AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = DateTime.MinValue;
         AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = DateTime.MinValue;
         AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = "";
         AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = "";
         AV66Wpdetallepromocionadminfacturawcds_7_tffacturano = "";
         AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = "";
         AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = DateTime.MinValue;
         AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = DateTime.MinValue;
         AV70Wpdetallepromocionadminfacturawcds_11_tfestatus = "";
         AV20TFEstatus = "";
         AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = "";
         AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = "";
         lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext = "";
         lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = "";
         lV66Wpdetallepromocionadminfacturawcds_7_tffacturano = "";
         lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = "";
         A42PromocionDescripcion = "";
         A71FacturaNo = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A73FacturaFechaFactura = DateTime.MinValue;
         A80FacturaEstatus = "";
         P003D2_A29UsuarioID = new int[1] ;
         P003D2_A41PromocionID = new int[1] ;
         P003D2_A80FacturaEstatus = new string[] {""} ;
         P003D2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P003D2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P003D2_A71FacturaNo = new string[] {""} ;
         P003D2_A42PromocionDescripcion = new string[] {""} ;
         P003D2_A51UsuarioApellido = new string[] {""} ;
         P003D2_A30UsuarioNombre = new string[] {""} ;
         P003D2_A69FacturaID = new int[1] ;
         A52UsuarioNombreCompleto = "";
         AV39Option = "";
         P003D3_A29UsuarioID = new int[1] ;
         P003D3_A41PromocionID = new int[1] ;
         P003D3_A71FacturaNo = new string[] {""} ;
         P003D3_A80FacturaEstatus = new string[] {""} ;
         P003D3_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P003D3_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P003D3_A42PromocionDescripcion = new string[] {""} ;
         P003D3_A51UsuarioApellido = new string[] {""} ;
         P003D3_A30UsuarioNombre = new string[] {""} ;
         P003D3_A69FacturaID = new int[1] ;
         P003D4_A41PromocionID = new int[1] ;
         P003D4_A29UsuarioID = new int[1] ;
         P003D4_A80FacturaEstatus = new string[] {""} ;
         P003D4_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P003D4_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P003D4_A71FacturaNo = new string[] {""} ;
         P003D4_A42PromocionDescripcion = new string[] {""} ;
         P003D4_A51UsuarioApellido = new string[] {""} ;
         P003D4_A30UsuarioNombre = new string[] {""} ;
         P003D4_A69FacturaID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpdetallepromocionadminfacturawcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003D2_A29UsuarioID, P003D2_A41PromocionID, P003D2_A80FacturaEstatus, P003D2_A73FacturaFechaFactura, P003D2_A72FacturaFechaRegistro, P003D2_A71FacturaNo, P003D2_A42PromocionDescripcion, P003D2_A51UsuarioApellido, P003D2_A30UsuarioNombre, P003D2_A69FacturaID
               }
               , new Object[] {
               P003D3_A29UsuarioID, P003D3_A41PromocionID, P003D3_A71FacturaNo, P003D3_A80FacturaEstatus, P003D3_A73FacturaFechaFactura, P003D3_A72FacturaFechaRegistro, P003D3_A42PromocionDescripcion, P003D3_A51UsuarioApellido, P003D3_A30UsuarioNombre, P003D3_A69FacturaID
               }
               , new Object[] {
               P003D4_A41PromocionID, P003D4_A29UsuarioID, P003D4_A80FacturaEstatus, P003D4_A73FacturaFechaFactura, P003D4_A72FacturaFechaRegistro, P003D4_A71FacturaNo, P003D4_A42PromocionDescripcion, P003D4_A51UsuarioApellido, P003D4_A30UsuarioNombre, P003D4_A69FacturaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV37MaxItems ;
      private short AV36PageIndex ;
      private short AV35SkipItems ;
      private short AV21TFEstatusOperator ;
      private short AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ;
      private int AV58GXV1 ;
      private int AV57PromocionID ;
      private int AV60Wpdetallepromocionadminfacturawcds_1_promocionid ;
      private int A41PromocionID ;
      private int A29UsuarioID ;
      private int A69FacturaID ;
      private int AV38InsertIndex ;
      private long AV44count ;
      private string AV16TFFacturaNo ;
      private string AV17TFFacturaNo_Sel ;
      private string AV66Wpdetallepromocionadminfacturawcds_7_tffacturano ;
      private string AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ;
      private string AV70Wpdetallepromocionadminfacturawcds_11_tfestatus ;
      private string AV20TFEstatus ;
      private string lV66Wpdetallepromocionadminfacturawcds_7_tffacturano ;
      private string A71FacturaNo ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string A80FacturaEstatus ;
      private DateTime AV12TFFacturaFechaRegistro ;
      private DateTime AV13TFFacturaFechaRegistro_To ;
      private DateTime AV18TFFacturaFechaFactura ;
      private DateTime AV19TFFacturaFechaFactura_To ;
      private DateTime AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ;
      private DateTime AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ;
      private DateTime AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ;
      private DateTime AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool returnInSub ;
      private bool BRK3D2 ;
      private bool BRK3D4 ;
      private bool BRK3D6 ;
      private string AV53OptionsJson ;
      private string AV54OptionsDescJson ;
      private string AV55OptionIndexesJson ;
      private string AV50DDOName ;
      private string AV51SearchTxtParms ;
      private string AV52SearchTxtTo ;
      private string AV34SearchTxt ;
      private string AV56FilterFullText ;
      private string AV14TFPromocionDescripcion ;
      private string AV15TFPromocionDescripcion_Sel ;
      private string AV30TFUsuarioNombreCompleto ;
      private string AV31TFUsuarioNombreCompleto_Sel ;
      private string AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext ;
      private string AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ;
      private string AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ;
      private string AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ;
      private string AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ;
      private string lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext ;
      private string lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ;
      private string lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ;
      private string A42PromocionDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV39Option ;
      private IGxSession AV45Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV40Options ;
      private GxSimpleCollection<string> AV42OptionsDesc ;
      private GxSimpleCollection<string> AV43OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV47GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV48GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P003D2_A29UsuarioID ;
      private int[] P003D2_A41PromocionID ;
      private string[] P003D2_A80FacturaEstatus ;
      private DateTime[] P003D2_A73FacturaFechaFactura ;
      private DateTime[] P003D2_A72FacturaFechaRegistro ;
      private string[] P003D2_A71FacturaNo ;
      private string[] P003D2_A42PromocionDescripcion ;
      private string[] P003D2_A51UsuarioApellido ;
      private string[] P003D2_A30UsuarioNombre ;
      private int[] P003D2_A69FacturaID ;
      private int[] P003D3_A29UsuarioID ;
      private int[] P003D3_A41PromocionID ;
      private string[] P003D3_A71FacturaNo ;
      private string[] P003D3_A80FacturaEstatus ;
      private DateTime[] P003D3_A73FacturaFechaFactura ;
      private DateTime[] P003D3_A72FacturaFechaRegistro ;
      private string[] P003D3_A42PromocionDescripcion ;
      private string[] P003D3_A51UsuarioApellido ;
      private string[] P003D3_A30UsuarioNombre ;
      private int[] P003D3_A69FacturaID ;
      private int[] P003D4_A41PromocionID ;
      private int[] P003D4_A29UsuarioID ;
      private string[] P003D4_A80FacturaEstatus ;
      private DateTime[] P003D4_A73FacturaFechaFactura ;
      private DateTime[] P003D4_A72FacturaFechaRegistro ;
      private string[] P003D4_A71FacturaNo ;
      private string[] P003D4_A42PromocionDescripcion ;
      private string[] P003D4_A51UsuarioApellido ;
      private string[] P003D4_A30UsuarioNombre ;
      private int[] P003D4_A69FacturaID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpdetallepromocionadminfacturawcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003D2( IGxContext context ,
                                             string AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext ,
                                             DateTime AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ,
                                             DateTime AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ,
                                             string AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ,
                                             string AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ,
                                             string AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ,
                                             string AV66Wpdetallepromocionadminfacturawcds_7_tffacturano ,
                                             DateTime AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ,
                                             DateTime AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ,
                                             short AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ,
                                             string AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ,
                                             string AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             int AV60Wpdetallepromocionadminfacturawcds_1_promocionid ,
                                             int A41PromocionID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`UsuarioID`, T1.`PromocionID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T1.`FacturaNo`, T3.`PromocionDescripcion`, T2.`UsuarioApellido`, T2.`UsuarioNombre`, T1.`FacturaID` FROM ((`Factura` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`) INNER JOIN `Promocion` T3 ON T3.`PromocionID` = T1.`PromocionID`)";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV60Wpdetallepromocionadminfacturawcds_1_promocionid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.`PromocionDescripcion` like CONCAT('%', @lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) like CONCAT('%', @lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`PromocionDescripcion` like @lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`PromocionDescripcion` = @AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpdetallepromocionadminfacturawcds_7_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV66Wpdetallepromocionadminfacturawcds_7_tffacturano)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) like @lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecomplet)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) = @AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecomplet)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T2.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T2.`UsuarioApellido`))))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`PromocionID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003D3( IGxContext context ,
                                             string AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext ,
                                             DateTime AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ,
                                             DateTime AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ,
                                             string AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ,
                                             string AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ,
                                             string AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ,
                                             string AV66Wpdetallepromocionadminfacturawcds_7_tffacturano ,
                                             DateTime AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ,
                                             DateTime AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ,
                                             short AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ,
                                             string AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ,
                                             string AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             int AV60Wpdetallepromocionadminfacturawcds_1_promocionid ,
                                             int A41PromocionID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`UsuarioID`, T1.`PromocionID`, T1.`FacturaNo`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T3.`PromocionDescripcion`, T2.`UsuarioApellido`, T2.`UsuarioNombre`, T1.`FacturaID` FROM ((`Factura` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`) INNER JOIN `Promocion` T3 ON T3.`PromocionID` = T1.`PromocionID`)";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV60Wpdetallepromocionadminfacturawcds_1_promocionid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.`PromocionDescripcion` like CONCAT('%', @lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) like CONCAT('%', @lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`PromocionDescripcion` like @lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`PromocionDescripcion` = @AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpdetallepromocionadminfacturawcds_7_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV66Wpdetallepromocionadminfacturawcds_7_tffacturano)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) like @lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecomplet)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T2.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T2.`UsuarioApellido`))) = @AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecomplet)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T2.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T2.`UsuarioApellido`))))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`PromocionID`, T1.`FacturaNo`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P003D4( IGxContext context ,
                                             string AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext ,
                                             DateTime AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ,
                                             DateTime AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ,
                                             string AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ,
                                             string AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ,
                                             string AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ,
                                             string AV66Wpdetallepromocionadminfacturawcds_7_tffacturano ,
                                             DateTime AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ,
                                             DateTime AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ,
                                             short AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ,
                                             string AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ,
                                             string AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             int AV60Wpdetallepromocionadminfacturawcds_1_promocionid ,
                                             int A41PromocionID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T3.`UsuarioApellido`, T3.`UsuarioNombre`, T1.`FacturaID` FROM ((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV60Wpdetallepromocionadminfacturawcds_1_promocionid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like CONCAT('%', @lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext)))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpdetallepromocionadminfacturawcds_7_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV66Wpdetallepromocionadminfacturawcds_7_tffacturano)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV71Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like @lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecomplet)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) = @AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecomplet)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T3.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T3.`UsuarioApellido`))))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`PromocionID`, T1.`UsuarioID`";
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
                     return conditional_P003D2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] );
               case 1 :
                     return conditional_P003D3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] );
               case 2 :
                     return conditional_P003D4(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] );
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
          Object[] prmP003D2;
          prmP003D2 = new Object[] {
          new ParDef("@AV60Wpdetallepromocionadminfacturawcds_1_promocionid",GXType.Int32,9,0) ,
          new ParDef("@lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_",GXType.Date,8,0) ,
          new ParDef("@lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_",GXType.Char,80,0) ,
          new ParDef("@lV66Wpdetallepromocionadminfacturawcds_7_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_",GXType.Date,8,0) ,
          new ParDef("@lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecomplet",GXType.Char,40,0) ,
          new ParDef("@AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecomplet",GXType.Char,40,0)
          };
          Object[] prmP003D3;
          prmP003D3 = new Object[] {
          new ParDef("@AV60Wpdetallepromocionadminfacturawcds_1_promocionid",GXType.Int32,9,0) ,
          new ParDef("@lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_",GXType.Date,8,0) ,
          new ParDef("@lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_",GXType.Char,80,0) ,
          new ParDef("@lV66Wpdetallepromocionadminfacturawcds_7_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_",GXType.Date,8,0) ,
          new ParDef("@lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecomplet",GXType.Char,40,0) ,
          new ParDef("@AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecomplet",GXType.Char,40,0)
          };
          Object[] prmP003D4;
          prmP003D4 = new Object[] {
          new ParDef("@AV60Wpdetallepromocionadminfacturawcds_1_promocionid",GXType.Int32,9,0) ,
          new ParDef("@lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV61Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV62Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV63Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_",GXType.Date,8,0) ,
          new ParDef("@lV64Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV65Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_",GXType.Char,80,0) ,
          new ParDef("@lV66Wpdetallepromocionadminfacturawcds_7_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV67Wpdetallepromocionadminfacturawcds_8_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV68Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV69Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_",GXType.Date,8,0) ,
          new ParDef("@lV72Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecomplet",GXType.Char,40,0) ,
          new ParDef("@AV73Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecomplet",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003D2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003D3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003D4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003D4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 50);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 50);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 50);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
