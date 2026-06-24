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
   public class wpfacturasgetfilterdata : GXProcedure
   {
      public wpfacturasgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfacturasgetfilterdata( IGxContext context )
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
         this.AV56DDOName = aP0_DDOName;
         this.AV57SearchTxtParms = aP1_SearchTxtParms;
         this.AV58SearchTxtTo = aP2_SearchTxtTo;
         this.AV59OptionsJson = "" ;
         this.AV60OptionsDescJson = "" ;
         this.AV61OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV59OptionsJson;
         aP4_OptionsDescJson=this.AV60OptionsDescJson;
         aP5_OptionIndexesJson=this.AV61OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV61OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV56DDOName = aP0_DDOName;
         this.AV57SearchTxtParms = aP1_SearchTxtParms;
         this.AV58SearchTxtTo = aP2_SearchTxtTo;
         this.AV59OptionsJson = "" ;
         this.AV60OptionsDescJson = "" ;
         this.AV61OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV59OptionsJson;
         aP4_OptionsDescJson=this.AV60OptionsDescJson;
         aP5_OptionIndexesJson=this.AV61OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV46Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV48OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV49OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV43MaxItems = 10;
         AV42PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV57SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV57SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV40SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV57SearchTxtParms)) ? "" : StringUtil.Substring( AV57SearchTxtParms, 3, -1));
         AV41SkipItems = (short)(AV42PageIndex*AV43MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV56DDOName), "DDO_PROMOCIONDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV56DDOName), "DDO_FACTURANO") == 0 )
         {
            /* Execute user subroutine: 'LOADFACTURANOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV56DDOName), "DDO_USUARIONOMBRECOMPLETO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIONOMBRECOMPLETOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV59OptionsJson = AV46Options.ToJSonString(false);
         AV60OptionsDescJson = AV48OptionsDesc.ToJSonString(false);
         AV61OptionIndexesJson = AV49OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV51Session.Get("WPFacturasGridState"), "") == 0 )
         {
            AV53GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPFacturasGridState"), null, "", "");
         }
         else
         {
            AV53GridState.FromXml(AV51Session.Get("WPFacturasGridState"), null, "", "");
         }
         AV98GXV1 = 1;
         while ( AV98GXV1 <= AV53GridState.gxTpr_Filtervalues.Count )
         {
            AV54GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV53GridState.gxTpr_Filtervalues.Item(AV98GXV1));
            if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV62FilterFullText = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFFACTURAID") == 0 )
            {
               AV96TFFacturaID = (int)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV97TFFacturaID_To = (int)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV24TFFacturaFechaRegistro = context.localUtil.CToD( AV54GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV25TFFacturaFechaRegistro_To = context.localUtil.CToD( AV54GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV14TFPromocionDescripcion = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV15TFPromocionDescripcion_Sel = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFFACTURANO") == 0 )
            {
               AV20TFFacturaNo = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFFACTURANO_SEL") == 0 )
            {
               AV21TFFacturaNo_Sel = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV22TFFacturaFechaFactura = context.localUtil.CToD( AV54GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV23TFFacturaFechaFactura_To = context.localUtil.CToD( AV54GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFESTATUS") == 0 )
            {
               AV66TFEstatusOperator = AV54GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV28TFUsuarioNombreCompleto = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV29TFUsuarioNombreCompleto_Sel = AV54GridStateFilterValue.gxTpr_Value;
            }
            AV98GXV1 = (int)(AV98GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROMOCIONDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFPromocionDescripcion = AV40SearchTxt;
         AV15TFPromocionDescripcion_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV95ListaUsuarios ,
                                              AV62FilterFullText ,
                                              AV96TFFacturaID ,
                                              AV97TFFacturaID_To ,
                                              AV24TFFacturaFechaRegistro ,
                                              AV25TFFacturaFechaRegistro_To ,
                                              AV15TFPromocionDescripcion_Sel ,
                                              AV14TFPromocionDescripcion ,
                                              AV21TFFacturaNo_Sel ,
                                              AV20TFFacturaNo ,
                                              AV22TFFacturaFechaFactura ,
                                              AV23TFFacturaFechaFactura_To ,
                                              AV66TFEstatusOperator ,
                                              AV29TFUsuarioNombreCompleto_Sel ,
                                              AV28TFUsuarioNombreCompleto ,
                                              AV93FromDate ,
                                              AV94ToDate ,
                                              AV95ListaUsuarios.Count ,
                                              A69FacturaID ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV14TFPromocionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV14TFPromocionDescripcion), "%", "");
         lV20TFFacturaNo = StringUtil.PadR( StringUtil.RTrim( AV20TFFacturaNo), 20, "%");
         lV28TFUsuarioNombreCompleto = StringUtil.Concat( StringUtil.RTrim( AV28TFUsuarioNombreCompleto), "%", "");
         /* Using cursor P002W2 */
         pr_default.execute(0, new Object[] {lV62FilterFullText, lV62FilterFullText, lV62FilterFullText, lV62FilterFullText, AV96TFFacturaID, AV97TFFacturaID_To, AV24TFFacturaFechaRegistro, AV25TFFacturaFechaRegistro_To, lV14TFPromocionDescripcion, AV15TFPromocionDescripcion_Sel, lV20TFFacturaNo, AV21TFFacturaNo_Sel, AV22TFFacturaFechaFactura, AV23TFFacturaFechaFactura_To, lV28TFUsuarioNombreCompleto, AV29TFUsuarioNombreCompleto_Sel, AV93FromDate, AV94ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2W2 = false;
            A41PromocionID = P002W2_A41PromocionID[0];
            A93FacturaCompleta = P002W2_A93FacturaCompleta[0];
            A29UsuarioID = P002W2_A29UsuarioID[0];
            A80FacturaEstatus = P002W2_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P002W2_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P002W2_A72FacturaFechaRegistro[0];
            A71FacturaNo = P002W2_A71FacturaNo[0];
            A42PromocionDescripcion = P002W2_A42PromocionDescripcion[0];
            A69FacturaID = P002W2_A69FacturaID[0];
            A51UsuarioApellido = P002W2_A51UsuarioApellido[0];
            A30UsuarioNombre = P002W2_A30UsuarioNombre[0];
            A42PromocionDescripcion = P002W2_A42PromocionDescripcion[0];
            A51UsuarioApellido = P002W2_A51UsuarioApellido[0];
            A30UsuarioNombre = P002W2_A30UsuarioNombre[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV50count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P002W2_A41PromocionID[0] == A41PromocionID ) )
            {
               BRK2W2 = false;
               A69FacturaID = P002W2_A69FacturaID[0];
               AV50count = (long)(AV50count+1);
               BRK2W2 = true;
               pr_default.readNext(0);
            }
            AV45Option = (String.IsNullOrEmpty(StringUtil.RTrim( A42PromocionDescripcion)) ? "<#Empty#>" : A42PromocionDescripcion);
            AV44InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV45Option, "<#Empty#>") != 0 ) && ( AV44InsertIndex <= AV46Options.Count ) && ( ( StringUtil.StrCmp(((string)AV46Options.Item(AV44InsertIndex)), AV45Option) < 0 ) || ( StringUtil.StrCmp(((string)AV46Options.Item(AV44InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV44InsertIndex = (int)(AV44InsertIndex+1);
            }
            AV46Options.Add(AV45Option, AV44InsertIndex);
            AV49OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV50count), "Z,ZZZ,ZZZ,ZZ9")), AV44InsertIndex);
            if ( AV46Options.Count == AV41SkipItems + 11 )
            {
               AV46Options.RemoveItem(AV46Options.Count);
               AV49OptionIndexes.RemoveItem(AV49OptionIndexes.Count);
            }
            if ( ! BRK2W2 )
            {
               BRK2W2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV41SkipItems > 0 )
         {
            AV46Options.RemoveItem(1);
            AV49OptionIndexes.RemoveItem(1);
            AV41SkipItems = (short)(AV41SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADFACTURANOOPTIONS' Routine */
         returnInSub = false;
         AV20TFFacturaNo = AV40SearchTxt;
         AV21TFFacturaNo_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV95ListaUsuarios ,
                                              AV62FilterFullText ,
                                              AV96TFFacturaID ,
                                              AV97TFFacturaID_To ,
                                              AV24TFFacturaFechaRegistro ,
                                              AV25TFFacturaFechaRegistro_To ,
                                              AV15TFPromocionDescripcion_Sel ,
                                              AV14TFPromocionDescripcion ,
                                              AV21TFFacturaNo_Sel ,
                                              AV20TFFacturaNo ,
                                              AV22TFFacturaFechaFactura ,
                                              AV23TFFacturaFechaFactura_To ,
                                              AV66TFEstatusOperator ,
                                              AV29TFUsuarioNombreCompleto_Sel ,
                                              AV28TFUsuarioNombreCompleto ,
                                              AV93FromDate ,
                                              AV94ToDate ,
                                              AV95ListaUsuarios.Count ,
                                              A69FacturaID ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV14TFPromocionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV14TFPromocionDescripcion), "%", "");
         lV20TFFacturaNo = StringUtil.PadR( StringUtil.RTrim( AV20TFFacturaNo), 20, "%");
         lV28TFUsuarioNombreCompleto = StringUtil.Concat( StringUtil.RTrim( AV28TFUsuarioNombreCompleto), "%", "");
         /* Using cursor P002W3 */
         pr_default.execute(1, new Object[] {lV62FilterFullText, lV62FilterFullText, lV62FilterFullText, lV62FilterFullText, AV96TFFacturaID, AV97TFFacturaID_To, AV24TFFacturaFechaRegistro, AV25TFFacturaFechaRegistro_To, lV14TFPromocionDescripcion, AV15TFPromocionDescripcion_Sel, lV20TFFacturaNo, AV21TFFacturaNo_Sel, AV22TFFacturaFechaFactura, AV23TFFacturaFechaFactura_To, lV28TFUsuarioNombreCompleto, AV29TFUsuarioNombreCompleto_Sel, AV93FromDate, AV94ToDate});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2W4 = false;
            A41PromocionID = P002W3_A41PromocionID[0];
            A71FacturaNo = P002W3_A71FacturaNo[0];
            A93FacturaCompleta = P002W3_A93FacturaCompleta[0];
            A29UsuarioID = P002W3_A29UsuarioID[0];
            A80FacturaEstatus = P002W3_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P002W3_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P002W3_A72FacturaFechaRegistro[0];
            A42PromocionDescripcion = P002W3_A42PromocionDescripcion[0];
            A69FacturaID = P002W3_A69FacturaID[0];
            A51UsuarioApellido = P002W3_A51UsuarioApellido[0];
            A30UsuarioNombre = P002W3_A30UsuarioNombre[0];
            A42PromocionDescripcion = P002W3_A42PromocionDescripcion[0];
            A51UsuarioApellido = P002W3_A51UsuarioApellido[0];
            A30UsuarioNombre = P002W3_A30UsuarioNombre[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV50count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002W3_A71FacturaNo[0], A71FacturaNo) == 0 ) )
            {
               BRK2W4 = false;
               A69FacturaID = P002W3_A69FacturaID[0];
               AV50count = (long)(AV50count+1);
               BRK2W4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV41SkipItems) )
            {
               AV45Option = (String.IsNullOrEmpty(StringUtil.RTrim( A71FacturaNo)) ? "<#Empty#>" : A71FacturaNo);
               AV46Options.Add(AV45Option, 0);
               AV49OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV50count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV46Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV41SkipItems = (short)(AV41SkipItems-1);
            }
            if ( ! BRK2W4 )
            {
               BRK2W4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADUSUARIONOMBRECOMPLETOOPTIONS' Routine */
         returnInSub = false;
         AV28TFUsuarioNombreCompleto = AV40SearchTxt;
         AV29TFUsuarioNombreCompleto_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV95ListaUsuarios ,
                                              AV62FilterFullText ,
                                              AV96TFFacturaID ,
                                              AV97TFFacturaID_To ,
                                              AV24TFFacturaFechaRegistro ,
                                              AV25TFFacturaFechaRegistro_To ,
                                              AV15TFPromocionDescripcion_Sel ,
                                              AV14TFPromocionDescripcion ,
                                              AV21TFFacturaNo_Sel ,
                                              AV20TFFacturaNo ,
                                              AV22TFFacturaFechaFactura ,
                                              AV23TFFacturaFechaFactura_To ,
                                              AV66TFEstatusOperator ,
                                              AV29TFUsuarioNombreCompleto_Sel ,
                                              AV28TFUsuarioNombreCompleto ,
                                              AV93FromDate ,
                                              AV94ToDate ,
                                              AV95ListaUsuarios.Count ,
                                              A69FacturaID ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV62FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV62FilterFullText), "%", "");
         lV14TFPromocionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV14TFPromocionDescripcion), "%", "");
         lV20TFFacturaNo = StringUtil.PadR( StringUtil.RTrim( AV20TFFacturaNo), 20, "%");
         lV28TFUsuarioNombreCompleto = StringUtil.Concat( StringUtil.RTrim( AV28TFUsuarioNombreCompleto), "%", "");
         /* Using cursor P002W4 */
         pr_default.execute(2, new Object[] {lV62FilterFullText, lV62FilterFullText, lV62FilterFullText, lV62FilterFullText, AV96TFFacturaID, AV97TFFacturaID_To, AV24TFFacturaFechaRegistro, AV25TFFacturaFechaRegistro_To, lV14TFPromocionDescripcion, AV15TFPromocionDescripcion_Sel, lV20TFFacturaNo, AV21TFFacturaNo_Sel, AV22TFFacturaFechaFactura, AV23TFFacturaFechaFactura_To, lV28TFUsuarioNombreCompleto, AV29TFUsuarioNombreCompleto_Sel, AV93FromDate, AV94ToDate});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2W6 = false;
            A41PromocionID = P002W4_A41PromocionID[0];
            A29UsuarioID = P002W4_A29UsuarioID[0];
            A93FacturaCompleta = P002W4_A93FacturaCompleta[0];
            A80FacturaEstatus = P002W4_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P002W4_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P002W4_A72FacturaFechaRegistro[0];
            A71FacturaNo = P002W4_A71FacturaNo[0];
            A42PromocionDescripcion = P002W4_A42PromocionDescripcion[0];
            A69FacturaID = P002W4_A69FacturaID[0];
            A51UsuarioApellido = P002W4_A51UsuarioApellido[0];
            A30UsuarioNombre = P002W4_A30UsuarioNombre[0];
            A42PromocionDescripcion = P002W4_A42PromocionDescripcion[0];
            A51UsuarioApellido = P002W4_A51UsuarioApellido[0];
            A30UsuarioNombre = P002W4_A30UsuarioNombre[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV50count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P002W4_A29UsuarioID[0] == A29UsuarioID ) )
            {
               BRK2W6 = false;
               A69FacturaID = P002W4_A69FacturaID[0];
               AV50count = (long)(AV50count+1);
               BRK2W6 = true;
               pr_default.readNext(2);
            }
            AV45Option = (String.IsNullOrEmpty(StringUtil.RTrim( A52UsuarioNombreCompleto)) ? "<#Empty#>" : A52UsuarioNombreCompleto);
            AV44InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV45Option, "<#Empty#>") != 0 ) && ( AV44InsertIndex <= AV46Options.Count ) && ( ( StringUtil.StrCmp(((string)AV46Options.Item(AV44InsertIndex)), AV45Option) < 0 ) || ( StringUtil.StrCmp(((string)AV46Options.Item(AV44InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV44InsertIndex = (int)(AV44InsertIndex+1);
            }
            AV46Options.Add(AV45Option, AV44InsertIndex);
            AV49OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV50count), "Z,ZZZ,ZZZ,ZZ9")), AV44InsertIndex);
            if ( AV46Options.Count == AV41SkipItems + 11 )
            {
               AV46Options.RemoveItem(AV46Options.Count);
               AV49OptionIndexes.RemoveItem(AV49OptionIndexes.Count);
            }
            if ( ! BRK2W6 )
            {
               BRK2W6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV41SkipItems > 0 )
         {
            AV46Options.RemoveItem(1);
            AV49OptionIndexes.RemoveItem(1);
            AV41SkipItems = (short)(AV41SkipItems-1);
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
         AV59OptionsJson = "";
         AV60OptionsDescJson = "";
         AV61OptionIndexesJson = "";
         AV46Options = new GxSimpleCollection<string>();
         AV48OptionsDesc = new GxSimpleCollection<string>();
         AV49OptionIndexes = new GxSimpleCollection<string>();
         AV40SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV51Session = context.GetSession();
         AV53GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV54GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV62FilterFullText = "";
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
         AV95ListaUsuarios = new GxSimpleCollection<int>();
         lV62FilterFullText = "";
         lV14TFPromocionDescripcion = "";
         lV20TFFacturaNo = "";
         lV28TFUsuarioNombreCompleto = "";
         AV93FromDate = DateTime.MinValue;
         AV94ToDate = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A71FacturaNo = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A73FacturaFechaFactura = DateTime.MinValue;
         A80FacturaEstatus = "";
         P002W2_A41PromocionID = new int[1] ;
         P002W2_A93FacturaCompleta = new bool[] {false} ;
         P002W2_A29UsuarioID = new int[1] ;
         P002W2_A80FacturaEstatus = new string[] {""} ;
         P002W2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P002W2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P002W2_A71FacturaNo = new string[] {""} ;
         P002W2_A42PromocionDescripcion = new string[] {""} ;
         P002W2_A69FacturaID = new int[1] ;
         P002W2_A51UsuarioApellido = new string[] {""} ;
         P002W2_A30UsuarioNombre = new string[] {""} ;
         A52UsuarioNombreCompleto = "";
         AV45Option = "";
         P002W3_A41PromocionID = new int[1] ;
         P002W3_A71FacturaNo = new string[] {""} ;
         P002W3_A93FacturaCompleta = new bool[] {false} ;
         P002W3_A29UsuarioID = new int[1] ;
         P002W3_A80FacturaEstatus = new string[] {""} ;
         P002W3_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P002W3_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P002W3_A42PromocionDescripcion = new string[] {""} ;
         P002W3_A69FacturaID = new int[1] ;
         P002W3_A51UsuarioApellido = new string[] {""} ;
         P002W3_A30UsuarioNombre = new string[] {""} ;
         P002W4_A41PromocionID = new int[1] ;
         P002W4_A29UsuarioID = new int[1] ;
         P002W4_A93FacturaCompleta = new bool[] {false} ;
         P002W4_A80FacturaEstatus = new string[] {""} ;
         P002W4_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P002W4_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P002W4_A71FacturaNo = new string[] {""} ;
         P002W4_A42PromocionDescripcion = new string[] {""} ;
         P002W4_A69FacturaID = new int[1] ;
         P002W4_A51UsuarioApellido = new string[] {""} ;
         P002W4_A30UsuarioNombre = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturasgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002W2_A41PromocionID, P002W2_A93FacturaCompleta, P002W2_A29UsuarioID, P002W2_A80FacturaEstatus, P002W2_A73FacturaFechaFactura, P002W2_A72FacturaFechaRegistro, P002W2_A71FacturaNo, P002W2_A42PromocionDescripcion, P002W2_A69FacturaID, P002W2_A51UsuarioApellido,
               P002W2_A30UsuarioNombre
               }
               , new Object[] {
               P002W3_A41PromocionID, P002W3_A71FacturaNo, P002W3_A93FacturaCompleta, P002W3_A29UsuarioID, P002W3_A80FacturaEstatus, P002W3_A73FacturaFechaFactura, P002W3_A72FacturaFechaRegistro, P002W3_A42PromocionDescripcion, P002W3_A69FacturaID, P002W3_A51UsuarioApellido,
               P002W3_A30UsuarioNombre
               }
               , new Object[] {
               P002W4_A41PromocionID, P002W4_A29UsuarioID, P002W4_A93FacturaCompleta, P002W4_A80FacturaEstatus, P002W4_A73FacturaFechaFactura, P002W4_A72FacturaFechaRegistro, P002W4_A71FacturaNo, P002W4_A42PromocionDescripcion, P002W4_A69FacturaID, P002W4_A51UsuarioApellido,
               P002W4_A30UsuarioNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV43MaxItems ;
      private short AV42PageIndex ;
      private short AV41SkipItems ;
      private short AV66TFEstatusOperator ;
      private int AV98GXV1 ;
      private int AV96TFFacturaID ;
      private int AV97TFFacturaID_To ;
      private int AV95ListaUsuarios_Count ;
      private int A29UsuarioID ;
      private int A69FacturaID ;
      private int A41PromocionID ;
      private int AV44InsertIndex ;
      private long AV50count ;
      private string AV20TFFacturaNo ;
      private string AV21TFFacturaNo_Sel ;
      private string lV20TFFacturaNo ;
      private string A71FacturaNo ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string A80FacturaEstatus ;
      private DateTime AV24TFFacturaFechaRegistro ;
      private DateTime AV25TFFacturaFechaRegistro_To ;
      private DateTime AV22TFFacturaFechaFactura ;
      private DateTime AV23TFFacturaFechaFactura_To ;
      private DateTime AV93FromDate ;
      private DateTime AV94ToDate ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool returnInSub ;
      private bool A93FacturaCompleta ;
      private bool BRK2W2 ;
      private bool BRK2W4 ;
      private bool BRK2W6 ;
      private string AV59OptionsJson ;
      private string AV60OptionsDescJson ;
      private string AV61OptionIndexesJson ;
      private string AV56DDOName ;
      private string AV57SearchTxtParms ;
      private string AV58SearchTxtTo ;
      private string AV40SearchTxt ;
      private string AV62FilterFullText ;
      private string AV14TFPromocionDescripcion ;
      private string AV15TFPromocionDescripcion_Sel ;
      private string AV28TFUsuarioNombreCompleto ;
      private string AV29TFUsuarioNombreCompleto_Sel ;
      private string lV62FilterFullText ;
      private string lV14TFPromocionDescripcion ;
      private string lV28TFUsuarioNombreCompleto ;
      private string A42PromocionDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV45Option ;
      private IGxSession AV51Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV46Options ;
      private GxSimpleCollection<string> AV48OptionsDesc ;
      private GxSimpleCollection<string> AV49OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV53GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV54GridStateFilterValue ;
      private GxSimpleCollection<int> AV95ListaUsuarios ;
      private IDataStoreProvider pr_default ;
      private int[] P002W2_A41PromocionID ;
      private bool[] P002W2_A93FacturaCompleta ;
      private int[] P002W2_A29UsuarioID ;
      private string[] P002W2_A80FacturaEstatus ;
      private DateTime[] P002W2_A73FacturaFechaFactura ;
      private DateTime[] P002W2_A72FacturaFechaRegistro ;
      private string[] P002W2_A71FacturaNo ;
      private string[] P002W2_A42PromocionDescripcion ;
      private int[] P002W2_A69FacturaID ;
      private string[] P002W2_A51UsuarioApellido ;
      private string[] P002W2_A30UsuarioNombre ;
      private int[] P002W3_A41PromocionID ;
      private string[] P002W3_A71FacturaNo ;
      private bool[] P002W3_A93FacturaCompleta ;
      private int[] P002W3_A29UsuarioID ;
      private string[] P002W3_A80FacturaEstatus ;
      private DateTime[] P002W3_A73FacturaFechaFactura ;
      private DateTime[] P002W3_A72FacturaFechaRegistro ;
      private string[] P002W3_A42PromocionDescripcion ;
      private int[] P002W3_A69FacturaID ;
      private string[] P002W3_A51UsuarioApellido ;
      private string[] P002W3_A30UsuarioNombre ;
      private int[] P002W4_A41PromocionID ;
      private int[] P002W4_A29UsuarioID ;
      private bool[] P002W4_A93FacturaCompleta ;
      private string[] P002W4_A80FacturaEstatus ;
      private DateTime[] P002W4_A73FacturaFechaFactura ;
      private DateTime[] P002W4_A72FacturaFechaRegistro ;
      private string[] P002W4_A71FacturaNo ;
      private string[] P002W4_A42PromocionDescripcion ;
      private int[] P002W4_A69FacturaID ;
      private string[] P002W4_A51UsuarioApellido ;
      private string[] P002W4_A30UsuarioNombre ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpfacturasgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002W2( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV95ListaUsuarios ,
                                             string AV62FilterFullText ,
                                             int AV96TFFacturaID ,
                                             int AV97TFFacturaID_To ,
                                             DateTime AV24TFFacturaFechaRegistro ,
                                             DateTime AV25TFFacturaFechaRegistro_To ,
                                             string AV15TFPromocionDescripcion_Sel ,
                                             string AV14TFPromocionDescripcion ,
                                             string AV21TFFacturaNo_Sel ,
                                             string AV20TFFacturaNo ,
                                             DateTime AV22TFFacturaFechaFactura ,
                                             DateTime AV23TFFacturaFechaFactura_To ,
                                             short AV66TFEstatusOperator ,
                                             string AV29TFUsuarioNombreCompleto_Sel ,
                                             string AV28TFUsuarioNombreCompleto ,
                                             DateTime AV93FromDate ,
                                             DateTime AV94ToDate ,
                                             int AV95ListaUsuarios_Count ,
                                             int A69FacturaID ,
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
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`FacturaCompleta`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T1.`FacturaID`, T3.`UsuarioApellido`, T3.`UsuarioNombre` FROM ((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62FilterFullText)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(T1.`FacturaID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV62FilterFullText)) or ( T2.`PromocionDescripcion` like CONCAT('%', @lV62FilterFullText)) or ( T1.`FacturaNo` like CONCAT('%', @lV62FilterFullText)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like CONCAT('%', @lV62FilterFullText)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV96TFFacturaID) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` >= @AV96TFFacturaID)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV97TFFacturaID_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` <= @AV97TFFacturaID_To)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV24TFFacturaFechaRegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV24TFFacturaFechaRegistro)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV25TFFacturaFechaRegistro_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV25TFFacturaFechaRegistro_To)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFPromocionDescripcion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFPromocionDescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV14TFPromocionDescripcion)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFPromocionDescripcion_Sel)) && ! ( StringUtil.StrCmp(AV15TFPromocionDescripcion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV15TFPromocionDescripcion_Sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV15TFPromocionDescripcion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFFacturaNo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFFacturaNo)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV20TFFacturaNo)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFFacturaNo_Sel)) && ! ( StringUtil.StrCmp(AV21TFFacturaNo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV21TFFacturaNo_Sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFFacturaNo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV22TFFacturaFechaFactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV22TFFacturaFechaFactura)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV23TFFacturaFechaFactura_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV23TFFacturaFechaFactura_To)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV66TFEstatusOperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV66TFEstatusOperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV66TFEstatusOperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV66TFEstatusOperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFUsuarioNombreCompleto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFUsuarioNombreCompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like @lV28TFUsuarioNombreCompleto)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFUsuarioNombreCompleto_Sel)) && ! ( StringUtil.StrCmp(AV29TFUsuarioNombreCompleto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) = @AV29TFUsuarioNombreCompleto_Sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV29TFUsuarioNombreCompleto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T3.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T3.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV93FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV93FromDate)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV94ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV94ToDate)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV95ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`PromocionID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002W3( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV95ListaUsuarios ,
                                             string AV62FilterFullText ,
                                             int AV96TFFacturaID ,
                                             int AV97TFFacturaID_To ,
                                             DateTime AV24TFFacturaFechaRegistro ,
                                             DateTime AV25TFFacturaFechaRegistro_To ,
                                             string AV15TFPromocionDescripcion_Sel ,
                                             string AV14TFPromocionDescripcion ,
                                             string AV21TFFacturaNo_Sel ,
                                             string AV20TFFacturaNo ,
                                             DateTime AV22TFFacturaFechaFactura ,
                                             DateTime AV23TFFacturaFechaFactura_To ,
                                             short AV66TFEstatusOperator ,
                                             string AV29TFUsuarioNombreCompleto_Sel ,
                                             string AV28TFUsuarioNombreCompleto ,
                                             DateTime AV93FromDate ,
                                             DateTime AV94ToDate ,
                                             int AV95ListaUsuarios_Count ,
                                             int A69FacturaID ,
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
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`FacturaNo`, T1.`FacturaCompleta`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T2.`PromocionDescripcion`, T1.`FacturaID`, T3.`UsuarioApellido`, T3.`UsuarioNombre` FROM ((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62FilterFullText)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(T1.`FacturaID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV62FilterFullText)) or ( T2.`PromocionDescripcion` like CONCAT('%', @lV62FilterFullText)) or ( T1.`FacturaNo` like CONCAT('%', @lV62FilterFullText)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like CONCAT('%', @lV62FilterFullText)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV96TFFacturaID) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` >= @AV96TFFacturaID)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV97TFFacturaID_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` <= @AV97TFFacturaID_To)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV24TFFacturaFechaRegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV24TFFacturaFechaRegistro)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV25TFFacturaFechaRegistro_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV25TFFacturaFechaRegistro_To)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFPromocionDescripcion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFPromocionDescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV14TFPromocionDescripcion)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFPromocionDescripcion_Sel)) && ! ( StringUtil.StrCmp(AV15TFPromocionDescripcion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV15TFPromocionDescripcion_Sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV15TFPromocionDescripcion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFFacturaNo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFFacturaNo)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV20TFFacturaNo)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFFacturaNo_Sel)) && ! ( StringUtil.StrCmp(AV21TFFacturaNo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV21TFFacturaNo_Sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFFacturaNo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV22TFFacturaFechaFactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV22TFFacturaFechaFactura)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV23TFFacturaFechaFactura_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV23TFFacturaFechaFactura_To)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV66TFEstatusOperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV66TFEstatusOperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV66TFEstatusOperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV66TFEstatusOperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFUsuarioNombreCompleto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFUsuarioNombreCompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like @lV28TFUsuarioNombreCompleto)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFUsuarioNombreCompleto_Sel)) && ! ( StringUtil.StrCmp(AV29TFUsuarioNombreCompleto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) = @AV29TFUsuarioNombreCompleto_Sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV29TFUsuarioNombreCompleto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T3.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T3.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV93FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV93FromDate)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV94ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV94ToDate)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV95ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`FacturaNo`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002W4( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV95ListaUsuarios ,
                                             string AV62FilterFullText ,
                                             int AV96TFFacturaID ,
                                             int AV97TFFacturaID_To ,
                                             DateTime AV24TFFacturaFechaRegistro ,
                                             DateTime AV25TFFacturaFechaRegistro_To ,
                                             string AV15TFPromocionDescripcion_Sel ,
                                             string AV14TFPromocionDescripcion ,
                                             string AV21TFFacturaNo_Sel ,
                                             string AV20TFFacturaNo ,
                                             DateTime AV22TFFacturaFechaFactura ,
                                             DateTime AV23TFFacturaFechaFactura_To ,
                                             short AV66TFEstatusOperator ,
                                             string AV29TFUsuarioNombreCompleto_Sel ,
                                             string AV28TFUsuarioNombreCompleto ,
                                             DateTime AV93FromDate ,
                                             DateTime AV94ToDate ,
                                             int AV95ListaUsuarios_Count ,
                                             int A69FacturaID ,
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
         short[] GXv_int5 = new short[18];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`UsuarioID`, T1.`FacturaCompleta`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T1.`FacturaID`, T3.`UsuarioApellido`, T3.`UsuarioNombre` FROM ((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62FilterFullText)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(T1.`FacturaID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV62FilterFullText)) or ( T2.`PromocionDescripcion` like CONCAT('%', @lV62FilterFullText)) or ( T1.`FacturaNo` like CONCAT('%', @lV62FilterFullText)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like CONCAT('%', @lV62FilterFullText)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV96TFFacturaID) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` >= @AV96TFFacturaID)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV97TFFacturaID_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` <= @AV97TFFacturaID_To)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV24TFFacturaFechaRegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV24TFFacturaFechaRegistro)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV25TFFacturaFechaRegistro_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV25TFFacturaFechaRegistro_To)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFPromocionDescripcion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFPromocionDescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV14TFPromocionDescripcion)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFPromocionDescripcion_Sel)) && ! ( StringUtil.StrCmp(AV15TFPromocionDescripcion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV15TFPromocionDescripcion_Sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV15TFPromocionDescripcion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFFacturaNo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFFacturaNo)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV20TFFacturaNo)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFFacturaNo_Sel)) && ! ( StringUtil.StrCmp(AV21TFFacturaNo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV21TFFacturaNo_Sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFFacturaNo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV22TFFacturaFechaFactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV22TFFacturaFechaFactura)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV23TFFacturaFechaFactura_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV23TFFacturaFechaFactura_To)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV66TFEstatusOperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV66TFEstatusOperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV66TFEstatusOperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV66TFEstatusOperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFUsuarioNombreCompleto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFUsuarioNombreCompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) like @lV28TFUsuarioNombreCompleto)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFUsuarioNombreCompleto_Sel)) && ! ( StringUtil.StrCmp(AV29TFUsuarioNombreCompleto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T3.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T3.`UsuarioApellido`))) = @AV29TFUsuarioNombreCompleto_Sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV29TFUsuarioNombreCompleto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T3.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T3.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV93FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV93FromDate)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV94ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV94ToDate)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV95ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
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
                     return conditional_P002W2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] );
               case 1 :
                     return conditional_P002W3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] );
               case 2 :
                     return conditional_P002W4(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP002W2;
          prmP002W2 = new Object[] {
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@AV96TFFacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV97TFFacturaID_To",GXType.Int32,9,0) ,
          new ParDef("@AV24TFFacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@AV25TFFacturaFechaRegistro_To",GXType.Date,8,0) ,
          new ParDef("@lV14TFPromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@AV15TFPromocionDescripcion_Sel",GXType.Char,80,0) ,
          new ParDef("@lV20TFFacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV21TFFacturaNo_Sel",GXType.Char,20,0) ,
          new ParDef("@AV22TFFacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@AV23TFFacturaFechaFactura_To",GXType.Date,8,0) ,
          new ParDef("@lV28TFUsuarioNombreCompleto",GXType.Char,40,0) ,
          new ParDef("@AV29TFUsuarioNombreCompleto_Sel",GXType.Char,40,0) ,
          new ParDef("@AV93FromDate",GXType.Date,8,0) ,
          new ParDef("@AV94ToDate",GXType.Date,8,0)
          };
          Object[] prmP002W3;
          prmP002W3 = new Object[] {
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@AV96TFFacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV97TFFacturaID_To",GXType.Int32,9,0) ,
          new ParDef("@AV24TFFacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@AV25TFFacturaFechaRegistro_To",GXType.Date,8,0) ,
          new ParDef("@lV14TFPromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@AV15TFPromocionDescripcion_Sel",GXType.Char,80,0) ,
          new ParDef("@lV20TFFacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV21TFFacturaNo_Sel",GXType.Char,20,0) ,
          new ParDef("@AV22TFFacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@AV23TFFacturaFechaFactura_To",GXType.Date,8,0) ,
          new ParDef("@lV28TFUsuarioNombreCompleto",GXType.Char,40,0) ,
          new ParDef("@AV29TFUsuarioNombreCompleto_Sel",GXType.Char,40,0) ,
          new ParDef("@AV93FromDate",GXType.Date,8,0) ,
          new ParDef("@AV94ToDate",GXType.Date,8,0)
          };
          Object[] prmP002W4;
          prmP002W4 = new Object[] {
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV62FilterFullText",GXType.Char,100,0) ,
          new ParDef("@AV96TFFacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV97TFFacturaID_To",GXType.Int32,9,0) ,
          new ParDef("@AV24TFFacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@AV25TFFacturaFechaRegistro_To",GXType.Date,8,0) ,
          new ParDef("@lV14TFPromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@AV15TFPromocionDescripcion_Sel",GXType.Char,80,0) ,
          new ParDef("@lV20TFFacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV21TFFacturaNo_Sel",GXType.Char,20,0) ,
          new ParDef("@AV22TFFacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@AV23TFFacturaFechaFactura_To",GXType.Date,8,0) ,
          new ParDef("@lV28TFUsuarioNombreCompleto",GXType.Char,40,0) ,
          new ParDef("@AV29TFUsuarioNombreCompleto_Sel",GXType.Char,40,0) ,
          new ParDef("@AV93FromDate",GXType.Date,8,0) ,
          new ParDef("@AV94ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002W2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002W3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002W4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002W4,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 50);
                ((string[]) buf[10])[0] = rslt.getString(11, 50);
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
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 50);
                ((string[]) buf[10])[0] = rslt.getString(11, 50);
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
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 50);
                ((string[]) buf[10])[0] = rslt.getString(11, 50);
                return;
       }
    }

 }

}
