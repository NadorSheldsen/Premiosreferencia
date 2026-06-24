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
   public class wpfacturaspartgetfilterdata : GXProcedure
   {
      public wpfacturaspartgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfacturaspartgetfilterdata( IGxContext context )
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
         this.AV52DDOName = aP0_DDOName;
         this.AV53SearchTxtParms = aP1_SearchTxtParms;
         this.AV54SearchTxtTo = aP2_SearchTxtTo;
         this.AV55OptionsJson = "" ;
         this.AV56OptionsDescJson = "" ;
         this.AV57OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV55OptionsJson;
         aP4_OptionsDescJson=this.AV56OptionsDescJson;
         aP5_OptionIndexesJson=this.AV57OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV57OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV52DDOName = aP0_DDOName;
         this.AV53SearchTxtParms = aP1_SearchTxtParms;
         this.AV54SearchTxtTo = aP2_SearchTxtTo;
         this.AV55OptionsJson = "" ;
         this.AV56OptionsDescJson = "" ;
         this.AV57OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV55OptionsJson;
         aP4_OptionsDescJson=this.AV56OptionsDescJson;
         aP5_OptionIndexesJson=this.AV57OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV42Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV44OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV45OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39MaxItems = 10;
         AV38PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV53SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV53SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV36SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV53SearchTxtParms)) ? "" : StringUtil.Substring( AV53SearchTxtParms, 3, -1));
         AV37SkipItems = (short)(AV38PageIndex*AV39MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV52DDOName), "DDO_PROMOCIONDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV52DDOName), "DDO_FACTURANO") == 0 )
         {
            /* Execute user subroutine: 'LOADFACTURANOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV52DDOName), "DDO_USUARIONOMBRECOMPLETO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIONOMBRECOMPLETOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV55OptionsJson = AV42Options.ToJSonString(false);
         AV56OptionsDescJson = AV44OptionsDesc.ToJSonString(false);
         AV57OptionIndexesJson = AV45OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV47Session.Get("WPFacturasPartGridState"), "") == 0 )
         {
            AV49GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPFacturasPartGridState"), null, "", "");
         }
         else
         {
            AV49GridState.FromXml(AV47Session.Get("WPFacturasPartGridState"), null, "", "");
         }
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV49GridState.gxTpr_Filtervalues.Count )
         {
            AV50GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV49GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV58FilterFullText = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV12TFFacturaFechaRegistro = context.localUtil.CToD( AV50GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV13TFFacturaFechaRegistro_To = context.localUtil.CToD( AV50GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV14TFPromocionDescripcion = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV15TFPromocionDescripcion_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFFACTURANO") == 0 )
            {
               AV16TFFacturaNo = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFFACTURANO_SEL") == 0 )
            {
               AV17TFFacturaNo_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV18TFFacturaFechaFactura = context.localUtil.CToD( AV50GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV19TFFacturaFechaFactura_To = context.localUtil.CToD( AV50GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFESTATUS") == 0 )
            {
               AV21TFEstatusOperator = AV50GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV32TFUsuarioNombreCompleto = AV50GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV33TFUsuarioNombreCompleto_Sel = AV50GridStateFilterValue.gxTpr_Value;
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROMOCIONDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFPromocionDescripcion = AV36SearchTxt;
         AV15TFPromocionDescripcion_Sel = "";
         AV65Wpfacturaspartds_1_filterfulltext = AV58FilterFullText;
         AV66Wpfacturaspartds_2_tffacturafecharegistro = AV12TFFacturaFechaRegistro;
         AV67Wpfacturaspartds_3_tffacturafecharegistro_to = AV13TFFacturaFechaRegistro_To;
         AV68Wpfacturaspartds_4_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV69Wpfacturaspartds_5_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV70Wpfacturaspartds_6_tffacturano = AV16TFFacturaNo;
         AV71Wpfacturaspartds_7_tffacturano_sel = AV17TFFacturaNo_Sel;
         AV72Wpfacturaspartds_8_tffacturafechafactura = AV18TFFacturaFechaFactura;
         AV73Wpfacturaspartds_9_tffacturafechafactura_to = AV19TFFacturaFechaFactura_To;
         AV74Wpfacturaspartds_10_tfestatus = AV20TFEstatus;
         AV75Wpfacturaspartds_11_tfestatusoperator = AV21TFEstatusOperator;
         AV76Wpfacturaspartds_12_tfusuarionombrecompleto = AV32TFUsuarioNombreCompleto;
         AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel = AV33TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV62ListaUsuarios ,
                                              AV65Wpfacturaspartds_1_filterfulltext ,
                                              AV66Wpfacturaspartds_2_tffacturafecharegistro ,
                                              AV67Wpfacturaspartds_3_tffacturafecharegistro_to ,
                                              AV69Wpfacturaspartds_5_tfpromociondescripcion_sel ,
                                              AV68Wpfacturaspartds_4_tfpromociondescripcion ,
                                              AV71Wpfacturaspartds_7_tffacturano_sel ,
                                              AV70Wpfacturaspartds_6_tffacturano ,
                                              AV72Wpfacturaspartds_8_tffacturafechafactura ,
                                              AV73Wpfacturaspartds_9_tffacturafechafactura_to ,
                                              AV75Wpfacturaspartds_11_tfestatusoperator ,
                                              AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel ,
                                              AV76Wpfacturaspartds_12_tfusuarionombrecompleto ,
                                              AV60FromDate ,
                                              AV61ToDate ,
                                              AV62ListaUsuarios.Count ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV65Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext), "%", "");
         lV65Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext), "%", "");
         lV65Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext), "%", "");
         lV68Wpfacturaspartds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV68Wpfacturaspartds_4_tfpromociondescripcion), "%", "");
         lV70Wpfacturaspartds_6_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV70Wpfacturaspartds_6_tffacturano), 20, "%");
         lV76Wpfacturaspartds_12_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV76Wpfacturaspartds_12_tfusuarionombrecompleto), "%", "");
         /* Using cursor P00362 */
         pr_default.execute(0, new Object[] {lV65Wpfacturaspartds_1_filterfulltext, lV65Wpfacturaspartds_1_filterfulltext, lV65Wpfacturaspartds_1_filterfulltext, AV66Wpfacturaspartds_2_tffacturafecharegistro, AV67Wpfacturaspartds_3_tffacturafecharegistro_to, lV68Wpfacturaspartds_4_tfpromociondescripcion, AV69Wpfacturaspartds_5_tfpromociondescripcion_sel, lV70Wpfacturaspartds_6_tffacturano, AV71Wpfacturaspartds_7_tffacturano_sel, AV72Wpfacturaspartds_8_tffacturafechafactura, AV73Wpfacturaspartds_9_tffacturafechafactura_to, lV76Wpfacturaspartds_12_tfusuarionombrecompleto, AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel, AV60FromDate, AV61ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK362 = false;
            A41PromocionID = P00362_A41PromocionID[0];
            A93FacturaCompleta = P00362_A93FacturaCompleta[0];
            A29UsuarioID = P00362_A29UsuarioID[0];
            A80FacturaEstatus = P00362_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P00362_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P00362_A72FacturaFechaRegistro[0];
            A71FacturaNo = P00362_A71FacturaNo[0];
            A42PromocionDescripcion = P00362_A42PromocionDescripcion[0];
            A51UsuarioApellido = P00362_A51UsuarioApellido[0];
            A30UsuarioNombre = P00362_A30UsuarioNombre[0];
            A69FacturaID = P00362_A69FacturaID[0];
            A42PromocionDescripcion = P00362_A42PromocionDescripcion[0];
            A51UsuarioApellido = P00362_A51UsuarioApellido[0];
            A30UsuarioNombre = P00362_A30UsuarioNombre[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV46count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00362_A41PromocionID[0] == A41PromocionID ) )
            {
               BRK362 = false;
               A69FacturaID = P00362_A69FacturaID[0];
               AV46count = (long)(AV46count+1);
               BRK362 = true;
               pr_default.readNext(0);
            }
            AV41Option = (String.IsNullOrEmpty(StringUtil.RTrim( A42PromocionDescripcion)) ? "<#Empty#>" : A42PromocionDescripcion);
            AV40InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV41Option, "<#Empty#>") != 0 ) && ( AV40InsertIndex <= AV42Options.Count ) && ( ( StringUtil.StrCmp(((string)AV42Options.Item(AV40InsertIndex)), AV41Option) < 0 ) || ( StringUtil.StrCmp(((string)AV42Options.Item(AV40InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV40InsertIndex = (int)(AV40InsertIndex+1);
            }
            AV42Options.Add(AV41Option, AV40InsertIndex);
            AV45OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV46count), "Z,ZZZ,ZZZ,ZZ9")), AV40InsertIndex);
            if ( AV42Options.Count == AV37SkipItems + 11 )
            {
               AV42Options.RemoveItem(AV42Options.Count);
               AV45OptionIndexes.RemoveItem(AV45OptionIndexes.Count);
            }
            if ( ! BRK362 )
            {
               BRK362 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV37SkipItems > 0 )
         {
            AV42Options.RemoveItem(1);
            AV45OptionIndexes.RemoveItem(1);
            AV37SkipItems = (short)(AV37SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADFACTURANOOPTIONS' Routine */
         returnInSub = false;
         AV16TFFacturaNo = AV36SearchTxt;
         AV17TFFacturaNo_Sel = "";
         AV65Wpfacturaspartds_1_filterfulltext = AV58FilterFullText;
         AV66Wpfacturaspartds_2_tffacturafecharegistro = AV12TFFacturaFechaRegistro;
         AV67Wpfacturaspartds_3_tffacturafecharegistro_to = AV13TFFacturaFechaRegistro_To;
         AV68Wpfacturaspartds_4_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV69Wpfacturaspartds_5_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV70Wpfacturaspartds_6_tffacturano = AV16TFFacturaNo;
         AV71Wpfacturaspartds_7_tffacturano_sel = AV17TFFacturaNo_Sel;
         AV72Wpfacturaspartds_8_tffacturafechafactura = AV18TFFacturaFechaFactura;
         AV73Wpfacturaspartds_9_tffacturafechafactura_to = AV19TFFacturaFechaFactura_To;
         AV74Wpfacturaspartds_10_tfestatus = AV20TFEstatus;
         AV75Wpfacturaspartds_11_tfestatusoperator = AV21TFEstatusOperator;
         AV76Wpfacturaspartds_12_tfusuarionombrecompleto = AV32TFUsuarioNombreCompleto;
         AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel = AV33TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV62ListaUsuarios ,
                                              AV65Wpfacturaspartds_1_filterfulltext ,
                                              AV66Wpfacturaspartds_2_tffacturafecharegistro ,
                                              AV67Wpfacturaspartds_3_tffacturafecharegistro_to ,
                                              AV69Wpfacturaspartds_5_tfpromociondescripcion_sel ,
                                              AV68Wpfacturaspartds_4_tfpromociondescripcion ,
                                              AV71Wpfacturaspartds_7_tffacturano_sel ,
                                              AV70Wpfacturaspartds_6_tffacturano ,
                                              AV72Wpfacturaspartds_8_tffacturafechafactura ,
                                              AV73Wpfacturaspartds_9_tffacturafechafactura_to ,
                                              AV75Wpfacturaspartds_11_tfestatusoperator ,
                                              AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel ,
                                              AV76Wpfacturaspartds_12_tfusuarionombrecompleto ,
                                              AV60FromDate ,
                                              AV61ToDate ,
                                              AV62ListaUsuarios.Count ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV65Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext), "%", "");
         lV65Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext), "%", "");
         lV65Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext), "%", "");
         lV68Wpfacturaspartds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV68Wpfacturaspartds_4_tfpromociondescripcion), "%", "");
         lV70Wpfacturaspartds_6_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV70Wpfacturaspartds_6_tffacturano), 20, "%");
         lV76Wpfacturaspartds_12_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV76Wpfacturaspartds_12_tfusuarionombrecompleto), "%", "");
         /* Using cursor P00363 */
         pr_default.execute(1, new Object[] {lV65Wpfacturaspartds_1_filterfulltext, lV65Wpfacturaspartds_1_filterfulltext, lV65Wpfacturaspartds_1_filterfulltext, AV66Wpfacturaspartds_2_tffacturafecharegistro, AV67Wpfacturaspartds_3_tffacturafecharegistro_to, lV68Wpfacturaspartds_4_tfpromociondescripcion, AV69Wpfacturaspartds_5_tfpromociondescripcion_sel, lV70Wpfacturaspartds_6_tffacturano, AV71Wpfacturaspartds_7_tffacturano_sel, AV72Wpfacturaspartds_8_tffacturafechafactura, AV73Wpfacturaspartds_9_tffacturafechafactura_to, lV76Wpfacturaspartds_12_tfusuarionombrecompleto, AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel, AV60FromDate, AV61ToDate});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK364 = false;
            A41PromocionID = P00363_A41PromocionID[0];
            A71FacturaNo = P00363_A71FacturaNo[0];
            A93FacturaCompleta = P00363_A93FacturaCompleta[0];
            A29UsuarioID = P00363_A29UsuarioID[0];
            A80FacturaEstatus = P00363_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P00363_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P00363_A72FacturaFechaRegistro[0];
            A42PromocionDescripcion = P00363_A42PromocionDescripcion[0];
            A51UsuarioApellido = P00363_A51UsuarioApellido[0];
            A30UsuarioNombre = P00363_A30UsuarioNombre[0];
            A69FacturaID = P00363_A69FacturaID[0];
            A42PromocionDescripcion = P00363_A42PromocionDescripcion[0];
            A51UsuarioApellido = P00363_A51UsuarioApellido[0];
            A30UsuarioNombre = P00363_A30UsuarioNombre[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV46count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00363_A71FacturaNo[0], A71FacturaNo) == 0 ) )
            {
               BRK364 = false;
               A69FacturaID = P00363_A69FacturaID[0];
               AV46count = (long)(AV46count+1);
               BRK364 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV37SkipItems) )
            {
               AV41Option = (String.IsNullOrEmpty(StringUtil.RTrim( A71FacturaNo)) ? "<#Empty#>" : A71FacturaNo);
               AV42Options.Add(AV41Option, 0);
               AV45OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV46count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV42Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV37SkipItems = (short)(AV37SkipItems-1);
            }
            if ( ! BRK364 )
            {
               BRK364 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADUSUARIONOMBRECOMPLETOOPTIONS' Routine */
         returnInSub = false;
         AV32TFUsuarioNombreCompleto = AV36SearchTxt;
         AV33TFUsuarioNombreCompleto_Sel = "";
         AV65Wpfacturaspartds_1_filterfulltext = AV58FilterFullText;
         AV66Wpfacturaspartds_2_tffacturafecharegistro = AV12TFFacturaFechaRegistro;
         AV67Wpfacturaspartds_3_tffacturafecharegistro_to = AV13TFFacturaFechaRegistro_To;
         AV68Wpfacturaspartds_4_tfpromociondescripcion = AV14TFPromocionDescripcion;
         AV69Wpfacturaspartds_5_tfpromociondescripcion_sel = AV15TFPromocionDescripcion_Sel;
         AV70Wpfacturaspartds_6_tffacturano = AV16TFFacturaNo;
         AV71Wpfacturaspartds_7_tffacturano_sel = AV17TFFacturaNo_Sel;
         AV72Wpfacturaspartds_8_tffacturafechafactura = AV18TFFacturaFechaFactura;
         AV73Wpfacturaspartds_9_tffacturafechafactura_to = AV19TFFacturaFechaFactura_To;
         AV74Wpfacturaspartds_10_tfestatus = AV20TFEstatus;
         AV75Wpfacturaspartds_11_tfestatusoperator = AV21TFEstatusOperator;
         AV76Wpfacturaspartds_12_tfusuarionombrecompleto = AV32TFUsuarioNombreCompleto;
         AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel = AV33TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV62ListaUsuarios ,
                                              AV65Wpfacturaspartds_1_filterfulltext ,
                                              AV66Wpfacturaspartds_2_tffacturafecharegistro ,
                                              AV67Wpfacturaspartds_3_tffacturafecharegistro_to ,
                                              AV69Wpfacturaspartds_5_tfpromociondescripcion_sel ,
                                              AV68Wpfacturaspartds_4_tfpromociondescripcion ,
                                              AV71Wpfacturaspartds_7_tffacturano_sel ,
                                              AV70Wpfacturaspartds_6_tffacturano ,
                                              AV72Wpfacturaspartds_8_tffacturafechafactura ,
                                              AV73Wpfacturaspartds_9_tffacturafechafactura_to ,
                                              AV75Wpfacturaspartds_11_tfestatusoperator ,
                                              AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel ,
                                              AV76Wpfacturaspartds_12_tfusuarionombrecompleto ,
                                              AV60FromDate ,
                                              AV61ToDate ,
                                              AV62ListaUsuarios.Count ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV65Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext), "%", "");
         lV65Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext), "%", "");
         lV65Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext), "%", "");
         lV68Wpfacturaspartds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV68Wpfacturaspartds_4_tfpromociondescripcion), "%", "");
         lV70Wpfacturaspartds_6_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV70Wpfacturaspartds_6_tffacturano), 20, "%");
         lV76Wpfacturaspartds_12_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV76Wpfacturaspartds_12_tfusuarionombrecompleto), "%", "");
         /* Using cursor P00364 */
         pr_default.execute(2, new Object[] {lV65Wpfacturaspartds_1_filterfulltext, lV65Wpfacturaspartds_1_filterfulltext, lV65Wpfacturaspartds_1_filterfulltext, AV66Wpfacturaspartds_2_tffacturafecharegistro, AV67Wpfacturaspartds_3_tffacturafecharegistro_to, lV68Wpfacturaspartds_4_tfpromociondescripcion, AV69Wpfacturaspartds_5_tfpromociondescripcion_sel, lV70Wpfacturaspartds_6_tffacturano, AV71Wpfacturaspartds_7_tffacturano_sel, AV72Wpfacturaspartds_8_tffacturafechafactura, AV73Wpfacturaspartds_9_tffacturafechafactura_to, lV76Wpfacturaspartds_12_tfusuarionombrecompleto, AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel, AV60FromDate, AV61ToDate});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK366 = false;
            A41PromocionID = P00364_A41PromocionID[0];
            A29UsuarioID = P00364_A29UsuarioID[0];
            A93FacturaCompleta = P00364_A93FacturaCompleta[0];
            A80FacturaEstatus = P00364_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P00364_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P00364_A72FacturaFechaRegistro[0];
            A71FacturaNo = P00364_A71FacturaNo[0];
            A42PromocionDescripcion = P00364_A42PromocionDescripcion[0];
            A51UsuarioApellido = P00364_A51UsuarioApellido[0];
            A30UsuarioNombre = P00364_A30UsuarioNombre[0];
            A69FacturaID = P00364_A69FacturaID[0];
            A42PromocionDescripcion = P00364_A42PromocionDescripcion[0];
            A51UsuarioApellido = P00364_A51UsuarioApellido[0];
            A30UsuarioNombre = P00364_A30UsuarioNombre[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV46count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00364_A29UsuarioID[0] == A29UsuarioID ) )
            {
               BRK366 = false;
               A69FacturaID = P00364_A69FacturaID[0];
               AV46count = (long)(AV46count+1);
               BRK366 = true;
               pr_default.readNext(2);
            }
            AV41Option = (String.IsNullOrEmpty(StringUtil.RTrim( A52UsuarioNombreCompleto)) ? "<#Empty#>" : A52UsuarioNombreCompleto);
            AV40InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV41Option, "<#Empty#>") != 0 ) && ( AV40InsertIndex <= AV42Options.Count ) && ( ( StringUtil.StrCmp(((string)AV42Options.Item(AV40InsertIndex)), AV41Option) < 0 ) || ( StringUtil.StrCmp(((string)AV42Options.Item(AV40InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV40InsertIndex = (int)(AV40InsertIndex+1);
            }
            AV42Options.Add(AV41Option, AV40InsertIndex);
            AV45OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV46count), "Z,ZZZ,ZZZ,ZZ9")), AV40InsertIndex);
            if ( AV42Options.Count == AV37SkipItems + 11 )
            {
               AV42Options.RemoveItem(AV42Options.Count);
               AV45OptionIndexes.RemoveItem(AV45OptionIndexes.Count);
            }
            if ( ! BRK366 )
            {
               BRK366 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV37SkipItems > 0 )
         {
            AV42Options.RemoveItem(1);
            AV45OptionIndexes.RemoveItem(1);
            AV37SkipItems = (short)(AV37SkipItems-1);
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
         AV55OptionsJson = "";
         AV56OptionsDescJson = "";
         AV57OptionIndexesJson = "";
         AV42Options = new GxSimpleCollection<string>();
         AV44OptionsDesc = new GxSimpleCollection<string>();
         AV45OptionIndexes = new GxSimpleCollection<string>();
         AV36SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV47Session = context.GetSession();
         AV49GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV50GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV58FilterFullText = "";
         AV12TFFacturaFechaRegistro = DateTime.MinValue;
         AV13TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV14TFPromocionDescripcion = "";
         AV15TFPromocionDescripcion_Sel = "";
         AV16TFFacturaNo = "";
         AV17TFFacturaNo_Sel = "";
         AV18TFFacturaFechaFactura = DateTime.MinValue;
         AV19TFFacturaFechaFactura_To = DateTime.MinValue;
         AV32TFUsuarioNombreCompleto = "";
         AV33TFUsuarioNombreCompleto_Sel = "";
         AV65Wpfacturaspartds_1_filterfulltext = "";
         AV66Wpfacturaspartds_2_tffacturafecharegistro = DateTime.MinValue;
         AV67Wpfacturaspartds_3_tffacturafecharegistro_to = DateTime.MinValue;
         AV68Wpfacturaspartds_4_tfpromociondescripcion = "";
         AV69Wpfacturaspartds_5_tfpromociondescripcion_sel = "";
         AV70Wpfacturaspartds_6_tffacturano = "";
         AV71Wpfacturaspartds_7_tffacturano_sel = "";
         AV72Wpfacturaspartds_8_tffacturafechafactura = DateTime.MinValue;
         AV73Wpfacturaspartds_9_tffacturafechafactura_to = DateTime.MinValue;
         AV74Wpfacturaspartds_10_tfestatus = "";
         AV20TFEstatus = "";
         AV76Wpfacturaspartds_12_tfusuarionombrecompleto = "";
         AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel = "";
         AV62ListaUsuarios = new GxSimpleCollection<int>();
         lV65Wpfacturaspartds_1_filterfulltext = "";
         lV68Wpfacturaspartds_4_tfpromociondescripcion = "";
         lV70Wpfacturaspartds_6_tffacturano = "";
         lV76Wpfacturaspartds_12_tfusuarionombrecompleto = "";
         AV60FromDate = DateTime.MinValue;
         AV61ToDate = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A71FacturaNo = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A73FacturaFechaFactura = DateTime.MinValue;
         A80FacturaEstatus = "";
         P00362_A41PromocionID = new int[1] ;
         P00362_A93FacturaCompleta = new bool[] {false} ;
         P00362_A29UsuarioID = new int[1] ;
         P00362_A80FacturaEstatus = new string[] {""} ;
         P00362_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00362_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P00362_A71FacturaNo = new string[] {""} ;
         P00362_A42PromocionDescripcion = new string[] {""} ;
         P00362_A51UsuarioApellido = new string[] {""} ;
         P00362_A30UsuarioNombre = new string[] {""} ;
         P00362_A69FacturaID = new int[1] ;
         A52UsuarioNombreCompleto = "";
         AV41Option = "";
         P00363_A41PromocionID = new int[1] ;
         P00363_A71FacturaNo = new string[] {""} ;
         P00363_A93FacturaCompleta = new bool[] {false} ;
         P00363_A29UsuarioID = new int[1] ;
         P00363_A80FacturaEstatus = new string[] {""} ;
         P00363_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00363_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P00363_A42PromocionDescripcion = new string[] {""} ;
         P00363_A51UsuarioApellido = new string[] {""} ;
         P00363_A30UsuarioNombre = new string[] {""} ;
         P00363_A69FacturaID = new int[1] ;
         P00364_A41PromocionID = new int[1] ;
         P00364_A29UsuarioID = new int[1] ;
         P00364_A93FacturaCompleta = new bool[] {false} ;
         P00364_A80FacturaEstatus = new string[] {""} ;
         P00364_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00364_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P00364_A71FacturaNo = new string[] {""} ;
         P00364_A42PromocionDescripcion = new string[] {""} ;
         P00364_A51UsuarioApellido = new string[] {""} ;
         P00364_A30UsuarioNombre = new string[] {""} ;
         P00364_A69FacturaID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturaspartgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00362_A41PromocionID, P00362_A93FacturaCompleta, P00362_A29UsuarioID, P00362_A80FacturaEstatus, P00362_A73FacturaFechaFactura, P00362_A72FacturaFechaRegistro, P00362_A71FacturaNo, P00362_A42PromocionDescripcion, P00362_A51UsuarioApellido, P00362_A30UsuarioNombre,
               P00362_A69FacturaID
               }
               , new Object[] {
               P00363_A41PromocionID, P00363_A71FacturaNo, P00363_A93FacturaCompleta, P00363_A29UsuarioID, P00363_A80FacturaEstatus, P00363_A73FacturaFechaFactura, P00363_A72FacturaFechaRegistro, P00363_A42PromocionDescripcion, P00363_A51UsuarioApellido, P00363_A30UsuarioNombre,
               P00363_A69FacturaID
               }
               , new Object[] {
               P00364_A41PromocionID, P00364_A29UsuarioID, P00364_A93FacturaCompleta, P00364_A80FacturaEstatus, P00364_A73FacturaFechaFactura, P00364_A72FacturaFechaRegistro, P00364_A71FacturaNo, P00364_A42PromocionDescripcion, P00364_A51UsuarioApellido, P00364_A30UsuarioNombre,
               P00364_A69FacturaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV39MaxItems ;
      private short AV38PageIndex ;
      private short AV37SkipItems ;
      private short AV21TFEstatusOperator ;
      private short AV75Wpfacturaspartds_11_tfestatusoperator ;
      private int AV63GXV1 ;
      private int AV62ListaUsuarios_Count ;
      private int A29UsuarioID ;
      private int A41PromocionID ;
      private int A69FacturaID ;
      private int AV40InsertIndex ;
      private long AV46count ;
      private string AV16TFFacturaNo ;
      private string AV17TFFacturaNo_Sel ;
      private string AV70Wpfacturaspartds_6_tffacturano ;
      private string AV71Wpfacturaspartds_7_tffacturano_sel ;
      private string AV74Wpfacturaspartds_10_tfestatus ;
      private string AV20TFEstatus ;
      private string lV70Wpfacturaspartds_6_tffacturano ;
      private string A71FacturaNo ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string A80FacturaEstatus ;
      private DateTime AV12TFFacturaFechaRegistro ;
      private DateTime AV13TFFacturaFechaRegistro_To ;
      private DateTime AV18TFFacturaFechaFactura ;
      private DateTime AV19TFFacturaFechaFactura_To ;
      private DateTime AV66Wpfacturaspartds_2_tffacturafecharegistro ;
      private DateTime AV67Wpfacturaspartds_3_tffacturafecharegistro_to ;
      private DateTime AV72Wpfacturaspartds_8_tffacturafechafactura ;
      private DateTime AV73Wpfacturaspartds_9_tffacturafechafactura_to ;
      private DateTime AV60FromDate ;
      private DateTime AV61ToDate ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool returnInSub ;
      private bool A93FacturaCompleta ;
      private bool BRK362 ;
      private bool BRK364 ;
      private bool BRK366 ;
      private string AV55OptionsJson ;
      private string AV56OptionsDescJson ;
      private string AV57OptionIndexesJson ;
      private string AV52DDOName ;
      private string AV53SearchTxtParms ;
      private string AV54SearchTxtTo ;
      private string AV36SearchTxt ;
      private string AV58FilterFullText ;
      private string AV14TFPromocionDescripcion ;
      private string AV15TFPromocionDescripcion_Sel ;
      private string AV32TFUsuarioNombreCompleto ;
      private string AV33TFUsuarioNombreCompleto_Sel ;
      private string AV65Wpfacturaspartds_1_filterfulltext ;
      private string AV68Wpfacturaspartds_4_tfpromociondescripcion ;
      private string AV69Wpfacturaspartds_5_tfpromociondescripcion_sel ;
      private string AV76Wpfacturaspartds_12_tfusuarionombrecompleto ;
      private string AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel ;
      private string lV65Wpfacturaspartds_1_filterfulltext ;
      private string lV68Wpfacturaspartds_4_tfpromociondescripcion ;
      private string lV76Wpfacturaspartds_12_tfusuarionombrecompleto ;
      private string A42PromocionDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV41Option ;
      private IGxSession AV47Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV42Options ;
      private GxSimpleCollection<string> AV44OptionsDesc ;
      private GxSimpleCollection<string> AV45OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV49GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV50GridStateFilterValue ;
      private GxSimpleCollection<int> AV62ListaUsuarios ;
      private IDataStoreProvider pr_default ;
      private int[] P00362_A41PromocionID ;
      private bool[] P00362_A93FacturaCompleta ;
      private int[] P00362_A29UsuarioID ;
      private string[] P00362_A80FacturaEstatus ;
      private DateTime[] P00362_A73FacturaFechaFactura ;
      private DateTime[] P00362_A72FacturaFechaRegistro ;
      private string[] P00362_A71FacturaNo ;
      private string[] P00362_A42PromocionDescripcion ;
      private string[] P00362_A51UsuarioApellido ;
      private string[] P00362_A30UsuarioNombre ;
      private int[] P00362_A69FacturaID ;
      private int[] P00363_A41PromocionID ;
      private string[] P00363_A71FacturaNo ;
      private bool[] P00363_A93FacturaCompleta ;
      private int[] P00363_A29UsuarioID ;
      private string[] P00363_A80FacturaEstatus ;
      private DateTime[] P00363_A73FacturaFechaFactura ;
      private DateTime[] P00363_A72FacturaFechaRegistro ;
      private string[] P00363_A42PromocionDescripcion ;
      private string[] P00363_A51UsuarioApellido ;
      private string[] P00363_A30UsuarioNombre ;
      private int[] P00363_A69FacturaID ;
      private int[] P00364_A41PromocionID ;
      private int[] P00364_A29UsuarioID ;
      private bool[] P00364_A93FacturaCompleta ;
      private string[] P00364_A80FacturaEstatus ;
      private DateTime[] P00364_A73FacturaFechaFactura ;
      private DateTime[] P00364_A72FacturaFechaRegistro ;
      private string[] P00364_A71FacturaNo ;
      private string[] P00364_A42PromocionDescripcion ;
      private string[] P00364_A51UsuarioApellido ;
      private string[] P00364_A30UsuarioNombre ;
      private int[] P00364_A69FacturaID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpfacturaspartgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00362( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV62ListaUsuarios ,
                                             string AV65Wpfacturaspartds_1_filterfulltext ,
                                             DateTime AV66Wpfacturaspartds_2_tffacturafecharegistro ,
                                             DateTime AV67Wpfacturaspartds_3_tffacturafecharegistro_to ,
                                             string AV69Wpfacturaspartds_5_tfpromociondescripcion_sel ,
                                             string AV68Wpfacturaspartds_4_tfpromociondescripcion ,
                                             string AV71Wpfacturaspartds_7_tffacturano_sel ,
                                             string AV70Wpfacturaspartds_6_tffacturano ,
                                             DateTime AV72Wpfacturaspartds_8_tffacturafechafactura ,
                                             DateTime AV73Wpfacturaspartds_9_tffacturafechafactura_to ,
                                             short AV75Wpfacturaspartds_11_tfestatusoperator ,
                                             string AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel ,
                                             string AV76Wpfacturaspartds_12_tfusuarionombrecompleto ,
                                             DateTime AV60FromDate ,
                                             DateTime AV61ToDate ,
                                             int AV62ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`FacturaCompleta`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T3.`UsuarioApellido`, T3.`UsuarioNombre`, T1.`FacturaID` FROM ((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV65Wpfacturaspartds_1_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV65Wpfacturaspartds_1_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like CONCAT('%', @lV65Wpfacturaspartds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Wpfacturaspartds_2_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV66Wpfacturaspartds_2_tffacturafecharegistro)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Wpfacturaspartds_3_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV67Wpfacturaspartds_3_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpfacturaspartds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpfacturaspartds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV68Wpfacturaspartds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpfacturaspartds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV69Wpfacturaspartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV69Wpfacturaspartds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wpfacturaspartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpfacturaspartds_7_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpfacturaspartds_6_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV70Wpfacturaspartds_6_tffacturano)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpfacturaspartds_7_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV71Wpfacturaspartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV71Wpfacturaspartds_7_tffacturano_sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV71Wpfacturaspartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV72Wpfacturaspartds_8_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV72Wpfacturaspartds_8_tffacturafechafactura)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Wpfacturaspartds_9_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV73Wpfacturaspartds_9_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpfacturaspartds_12_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like @lV76Wpfacturaspartds_12_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) = @AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T3.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T3.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV60FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV60FromDate)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV61ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV61ToDate)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV62ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV62ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`PromocionID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00363( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV62ListaUsuarios ,
                                             string AV65Wpfacturaspartds_1_filterfulltext ,
                                             DateTime AV66Wpfacturaspartds_2_tffacturafecharegistro ,
                                             DateTime AV67Wpfacturaspartds_3_tffacturafecharegistro_to ,
                                             string AV69Wpfacturaspartds_5_tfpromociondescripcion_sel ,
                                             string AV68Wpfacturaspartds_4_tfpromociondescripcion ,
                                             string AV71Wpfacturaspartds_7_tffacturano_sel ,
                                             string AV70Wpfacturaspartds_6_tffacturano ,
                                             DateTime AV72Wpfacturaspartds_8_tffacturafechafactura ,
                                             DateTime AV73Wpfacturaspartds_9_tffacturafechafactura_to ,
                                             short AV75Wpfacturaspartds_11_tfestatusoperator ,
                                             string AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel ,
                                             string AV76Wpfacturaspartds_12_tfusuarionombrecompleto ,
                                             DateTime AV60FromDate ,
                                             DateTime AV61ToDate ,
                                             int AV62ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`FacturaNo`, T1.`FacturaCompleta`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T2.`PromocionDescripcion`, T3.`UsuarioApellido`, T3.`UsuarioNombre`, T1.`FacturaID` FROM ((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV65Wpfacturaspartds_1_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV65Wpfacturaspartds_1_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like CONCAT('%', @lV65Wpfacturaspartds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Wpfacturaspartds_2_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV66Wpfacturaspartds_2_tffacturafecharegistro)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Wpfacturaspartds_3_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV67Wpfacturaspartds_3_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpfacturaspartds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpfacturaspartds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV68Wpfacturaspartds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpfacturaspartds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV69Wpfacturaspartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV69Wpfacturaspartds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wpfacturaspartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpfacturaspartds_7_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpfacturaspartds_6_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV70Wpfacturaspartds_6_tffacturano)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpfacturaspartds_7_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV71Wpfacturaspartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV71Wpfacturaspartds_7_tffacturano_sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV71Wpfacturaspartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV72Wpfacturaspartds_8_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV72Wpfacturaspartds_8_tffacturafechafactura)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Wpfacturaspartds_9_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV73Wpfacturaspartds_9_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpfacturaspartds_12_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like @lV76Wpfacturaspartds_12_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) = @AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T3.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T3.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV60FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV60FromDate)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV61ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV61ToDate)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV62ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV62ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`FacturaNo`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00364( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV62ListaUsuarios ,
                                             string AV65Wpfacturaspartds_1_filterfulltext ,
                                             DateTime AV66Wpfacturaspartds_2_tffacturafecharegistro ,
                                             DateTime AV67Wpfacturaspartds_3_tffacturafecharegistro_to ,
                                             string AV69Wpfacturaspartds_5_tfpromociondescripcion_sel ,
                                             string AV68Wpfacturaspartds_4_tfpromociondescripcion ,
                                             string AV71Wpfacturaspartds_7_tffacturano_sel ,
                                             string AV70Wpfacturaspartds_6_tffacturano ,
                                             DateTime AV72Wpfacturaspartds_8_tffacturafechafactura ,
                                             DateTime AV73Wpfacturaspartds_9_tffacturafechafactura_to ,
                                             short AV75Wpfacturaspartds_11_tfestatusoperator ,
                                             string AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel ,
                                             string AV76Wpfacturaspartds_12_tfusuarionombrecompleto ,
                                             DateTime AV60FromDate ,
                                             DateTime AV61ToDate ,
                                             int AV62ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`UsuarioID`, T1.`FacturaCompleta`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T3.`UsuarioApellido`, T3.`UsuarioNombre`, T1.`FacturaID` FROM ((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpfacturaspartds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV65Wpfacturaspartds_1_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV65Wpfacturaspartds_1_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like CONCAT('%', @lV65Wpfacturaspartds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Wpfacturaspartds_2_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV66Wpfacturaspartds_2_tffacturafecharegistro)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Wpfacturaspartds_3_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV67Wpfacturaspartds_3_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpfacturaspartds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpfacturaspartds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV68Wpfacturaspartds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpfacturaspartds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV69Wpfacturaspartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV69Wpfacturaspartds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wpfacturaspartds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpfacturaspartds_7_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpfacturaspartds_6_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV70Wpfacturaspartds_6_tffacturano)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpfacturaspartds_7_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV71Wpfacturaspartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV71Wpfacturaspartds_7_tffacturano_sel)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV71Wpfacturaspartds_7_tffacturano_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV72Wpfacturaspartds_8_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV72Wpfacturaspartds_8_tffacturafechafactura)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Wpfacturaspartds_9_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV73Wpfacturaspartds_9_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV75Wpfacturaspartds_11_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpfacturaspartds_12_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like @lV76Wpfacturaspartds_12_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) = @AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T3.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T3.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV60FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV60FromDate)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV61ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV61ToDate)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV62ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV62ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
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
                     return conditional_P00362(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (bool)dynConstraints[24] );
               case 1 :
                     return conditional_P00363(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (bool)dynConstraints[24] );
               case 2 :
                     return conditional_P00364(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00362;
          prmP00362 = new Object[] {
          new ParDef("@lV65Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV65Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV65Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV66Wpfacturaspartds_2_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV67Wpfacturaspartds_3_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV68Wpfacturaspartds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV69Wpfacturaspartds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV70Wpfacturaspartds_6_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV71Wpfacturaspartds_7_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV72Wpfacturaspartds_8_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV73Wpfacturaspartds_9_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@lV76Wpfacturaspartds_12_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@AV60FromDate",GXType.Date,8,0) ,
          new ParDef("@AV61ToDate",GXType.Date,8,0)
          };
          Object[] prmP00363;
          prmP00363 = new Object[] {
          new ParDef("@lV65Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV65Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV65Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV66Wpfacturaspartds_2_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV67Wpfacturaspartds_3_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV68Wpfacturaspartds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV69Wpfacturaspartds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV70Wpfacturaspartds_6_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV71Wpfacturaspartds_7_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV72Wpfacturaspartds_8_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV73Wpfacturaspartds_9_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@lV76Wpfacturaspartds_12_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@AV60FromDate",GXType.Date,8,0) ,
          new ParDef("@AV61ToDate",GXType.Date,8,0)
          };
          Object[] prmP00364;
          prmP00364 = new Object[] {
          new ParDef("@lV65Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV65Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV65Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV66Wpfacturaspartds_2_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV67Wpfacturaspartds_3_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV68Wpfacturaspartds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV69Wpfacturaspartds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV70Wpfacturaspartds_6_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV71Wpfacturaspartds_7_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV72Wpfacturaspartds_8_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV73Wpfacturaspartds_9_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@lV76Wpfacturaspartds_12_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV77Wpfacturaspartds_13_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@AV60FromDate",GXType.Date,8,0) ,
          new ParDef("@AV61ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00362", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00362,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00363", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00363,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00364", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00364,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
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
