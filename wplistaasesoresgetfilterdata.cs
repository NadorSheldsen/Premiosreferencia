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
   public class wplistaasesoresgetfilterdata : GXProcedure
   {
      public wplistaasesoresgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wplistaasesoresgetfilterdata( IGxContext context )
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
         this.AV86DDOName = aP0_DDOName;
         this.AV87SearchTxtParms = aP1_SearchTxtParms;
         this.AV88SearchTxtTo = aP2_SearchTxtTo;
         this.AV89OptionsJson = "" ;
         this.AV90OptionsDescJson = "" ;
         this.AV91OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV89OptionsJson;
         aP4_OptionsDescJson=this.AV90OptionsDescJson;
         aP5_OptionIndexesJson=this.AV91OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV91OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV86DDOName = aP0_DDOName;
         this.AV87SearchTxtParms = aP1_SearchTxtParms;
         this.AV88SearchTxtTo = aP2_SearchTxtTo;
         this.AV89OptionsJson = "" ;
         this.AV90OptionsDescJson = "" ;
         this.AV91OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV89OptionsJson;
         aP4_OptionsDescJson=this.AV90OptionsDescJson;
         aP5_OptionIndexesJson=this.AV91OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV76Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV78OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV79OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV73MaxItems = 10;
         AV72PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV87SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV87SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV70SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV87SearchTxtParms)) ? "" : StringUtil.Substring( AV87SearchTxtParms, 3, -1));
         AV71SkipItems = (short)(AV72PageIndex*AV73MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV86DDOName), "DDO_USUARIONOMBRECOMPLETO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIONOMBRECOMPLETOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV86DDOName), "DDO_USUARIOCORREO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIOCORREOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV86DDOName), "DDO_PUESTODESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPUESTODESCRIPCIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV86DDOName), "DDO_USUARIOSUCURSAL") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIOSUCURSALOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV89OptionsJson = AV76Options.ToJSonString(false);
         AV90OptionsDescJson = AV78OptionsDesc.ToJSonString(false);
         AV91OptionIndexesJson = AV79OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV81Session.Get("WPListaAsesoresGridState"), "") == 0 )
         {
            AV83GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPListaAsesoresGridState"), null, "", "");
         }
         else
         {
            AV83GridState.FromXml(AV81Session.Get("WPListaAsesoresGridState"), null, "", "");
         }
         AV94GXV1 = 1;
         while ( AV94GXV1 <= AV83GridState.gxTpr_Filtervalues.Count )
         {
            AV84GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV83GridState.gxTpr_Filtervalues.Item(AV94GXV1));
            if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV92FilterFullText = AV84GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV16TFUsuarioNombreCompleto = AV84GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV17TFUsuarioNombreCompleto_Sel = AV84GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFUSUARIOROL_SEL") == 0 )
            {
               AV68TFUsuarioRol_SelsJson = AV84GridStateFilterValue.gxTpr_Value;
               AV69TFUsuarioRol_Sels.FromJSonString(AV68TFUsuarioRol_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO") == 0 )
            {
               AV18TFUsuarioCorreo = AV84GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO_SEL") == 0 )
            {
               AV19TFUsuarioCorreo_Sel = AV84GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFPUESTODESCRIPCION") == 0 )
            {
               AV26TFPuestoDescripcion = AV84GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFPUESTODESCRIPCION_SEL") == 0 )
            {
               AV27TFPuestoDescripcion_Sel = AV84GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFUSUARIOGENERO_SEL") == 0 )
            {
               AV28TFUsuarioGenero_SelsJson = AV84GridStateFilterValue.gxTpr_Value;
               AV29TFUsuarioGenero_Sels.FromJSonString(AV28TFUsuarioGenero_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFUSUARIOCELULAR") == 0 )
            {
               AV48TFUsuarioCelular = (long)(Math.Round(NumberUtil.Val( AV84GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV49TFUsuarioCelular_To = (long)(Math.Round(NumberUtil.Val( AV84GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFUSUARIOSUCURSAL") == 0 )
            {
               AV64TFUsuarioSucursal = AV84GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV84GridStateFilterValue.gxTpr_Name, "TFUSUARIOSUCURSAL_SEL") == 0 )
            {
               AV65TFUsuarioSucursal_Sel = AV84GridStateFilterValue.gxTpr_Value;
            }
            AV94GXV1 = (int)(AV94GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADUSUARIONOMBRECOMPLETOOPTIONS' Routine */
         returnInSub = false;
         AV16TFUsuarioNombreCompleto = AV70SearchTxt;
         AV17TFUsuarioNombreCompleto_Sel = "";
         AV96Wplistaasesoresds_1_filterfulltext = AV92FilterFullText;
         AV97Wplistaasesoresds_2_tfusuarionombrecompleto = AV16TFUsuarioNombreCompleto;
         AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel = AV17TFUsuarioNombreCompleto_Sel;
         AV99Wplistaasesoresds_4_tfusuariorol_sels = AV69TFUsuarioRol_Sels;
         AV100Wplistaasesoresds_5_tfusuariocorreo = AV18TFUsuarioCorreo;
         AV101Wplistaasesoresds_6_tfusuariocorreo_sel = AV19TFUsuarioCorreo_Sel;
         AV102Wplistaasesoresds_7_tfpuestodescripcion = AV26TFPuestoDescripcion;
         AV103Wplistaasesoresds_8_tfpuestodescripcion_sel = AV27TFPuestoDescripcion_Sel;
         AV104Wplistaasesoresds_9_tfusuariogenero_sels = AV29TFUsuarioGenero_Sels;
         AV105Wplistaasesoresds_10_tfusuariocelular = AV48TFUsuarioCelular;
         AV106Wplistaasesoresds_11_tfusuariocelular_to = AV49TFUsuarioCelular_To;
         AV107Wplistaasesoresds_12_tfusuariosucursal = AV64TFUsuarioSucursal;
         AV108Wplistaasesoresds_13_tfusuariosucursal_sel = AV65TFUsuarioSucursal_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV93ListaUsuariosAsesores ,
                                              A40UsuarioRol ,
                                              AV99Wplistaasesoresds_4_tfusuariorol_sels ,
                                              A53UsuarioGenero ,
                                              AV104Wplistaasesoresds_9_tfusuariogenero_sels ,
                                              AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel ,
                                              AV97Wplistaasesoresds_2_tfusuarionombrecompleto ,
                                              AV99Wplistaasesoresds_4_tfusuariorol_sels.Count ,
                                              AV101Wplistaasesoresds_6_tfusuariocorreo_sel ,
                                              AV100Wplistaasesoresds_5_tfusuariocorreo ,
                                              AV103Wplistaasesoresds_8_tfpuestodescripcion_sel ,
                                              AV102Wplistaasesoresds_7_tfpuestodescripcion ,
                                              AV104Wplistaasesoresds_9_tfusuariogenero_sels.Count ,
                                              AV105Wplistaasesoresds_10_tfusuariocelular ,
                                              AV106Wplistaasesoresds_11_tfusuariocelular_to ,
                                              AV108Wplistaasesoresds_13_tfusuariosucursal_sel ,
                                              AV107Wplistaasesoresds_12_tfusuariosucursal ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A14PuestoDescripcion ,
                                              A64UsuarioCelular ,
                                              A66UsuarioSucursal ,
                                              AV96Wplistaasesoresds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV97Wplistaasesoresds_2_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV97Wplistaasesoresds_2_tfusuarionombrecompleto), "%", "");
         lV100Wplistaasesoresds_5_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV100Wplistaasesoresds_5_tfusuariocorreo), "%", "");
         lV102Wplistaasesoresds_7_tfpuestodescripcion = StringUtil.Concat( StringUtil.RTrim( AV102Wplistaasesoresds_7_tfpuestodescripcion), "%", "");
         lV107Wplistaasesoresds_12_tfusuariosucursal = StringUtil.PadR( StringUtil.RTrim( AV107Wplistaasesoresds_12_tfusuariosucursal), 20, "%");
         /* Using cursor P00372 */
         pr_default.execute(0, new Object[] {lV97Wplistaasesoresds_2_tfusuarionombrecompleto, AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, lV100Wplistaasesoresds_5_tfusuariocorreo, AV101Wplistaasesoresds_6_tfusuariocorreo_sel, lV102Wplistaasesoresds_7_tfpuestodescripcion, AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, AV105Wplistaasesoresds_10_tfusuariocelular, AV106Wplistaasesoresds_11_tfusuariocelular_to, lV107Wplistaasesoresds_12_tfusuariosucursal, AV108Wplistaasesoresds_13_tfusuariosucursal_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A13PuestoID = P00372_A13PuestoID[0];
            n13PuestoID = P00372_n13PuestoID[0];
            A29UsuarioID = P00372_A29UsuarioID[0];
            A64UsuarioCelular = P00372_A64UsuarioCelular[0];
            A66UsuarioSucursal = P00372_A66UsuarioSucursal[0];
            A53UsuarioGenero = P00372_A53UsuarioGenero[0];
            A14PuestoDescripcion = P00372_A14PuestoDescripcion[0];
            A31UsuarioCorreo = P00372_A31UsuarioCorreo[0];
            A40UsuarioRol = P00372_A40UsuarioRol[0];
            A52UsuarioNombreCompleto = P00372_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00372_A30UsuarioNombre[0];
            A51UsuarioApellido = P00372_A51UsuarioApellido[0];
            A14PuestoDescripcion = P00372_A14PuestoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Wplistaasesoresds_1_filterfulltext)) || ( ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A14PuestoDescripcion , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A53UsuarioGenero)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "masculino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Masculino", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "femenino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Femenino", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A66UsuarioSucursal , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV75Option = (String.IsNullOrEmpty(StringUtil.RTrim( A52UsuarioNombreCompleto)) ? "<#Empty#>" : A52UsuarioNombreCompleto);
               AV74InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV75Option, "<#Empty#>") != 0 ) && ( AV74InsertIndex <= AV76Options.Count ) && ( ( StringUtil.StrCmp(((string)AV76Options.Item(AV74InsertIndex)), AV75Option) < 0 ) || ( StringUtil.StrCmp(((string)AV76Options.Item(AV74InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV74InsertIndex = (int)(AV74InsertIndex+1);
               }
               if ( ( AV74InsertIndex <= AV76Options.Count ) && ( StringUtil.StrCmp(((string)AV76Options.Item(AV74InsertIndex)), AV75Option) == 0 ) )
               {
                  AV80count = (long)(Math.Round(NumberUtil.Val( ((string)AV79OptionIndexes.Item(AV74InsertIndex)), "."), 18, MidpointRounding.ToEven));
                  AV80count = (long)(AV80count+1);
                  AV79OptionIndexes.RemoveItem(AV74InsertIndex);
                  AV79OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV80count), "Z,ZZZ,ZZZ,ZZ9")), AV74InsertIndex);
               }
               else
               {
                  AV76Options.Add(AV75Option, AV74InsertIndex);
                  AV79OptionIndexes.Add("1", AV74InsertIndex);
               }
               if ( AV76Options.Count == AV71SkipItems + 11 )
               {
                  AV76Options.RemoveItem(AV76Options.Count);
                  AV79OptionIndexes.RemoveItem(AV79OptionIndexes.Count);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         while ( AV71SkipItems > 0 )
         {
            AV76Options.RemoveItem(1);
            AV79OptionIndexes.RemoveItem(1);
            AV71SkipItems = (short)(AV71SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADUSUARIOCORREOOPTIONS' Routine */
         returnInSub = false;
         AV18TFUsuarioCorreo = AV70SearchTxt;
         AV19TFUsuarioCorreo_Sel = "";
         AV96Wplistaasesoresds_1_filterfulltext = AV92FilterFullText;
         AV97Wplistaasesoresds_2_tfusuarionombrecompleto = AV16TFUsuarioNombreCompleto;
         AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel = AV17TFUsuarioNombreCompleto_Sel;
         AV99Wplistaasesoresds_4_tfusuariorol_sels = AV69TFUsuarioRol_Sels;
         AV100Wplistaasesoresds_5_tfusuariocorreo = AV18TFUsuarioCorreo;
         AV101Wplistaasesoresds_6_tfusuariocorreo_sel = AV19TFUsuarioCorreo_Sel;
         AV102Wplistaasesoresds_7_tfpuestodescripcion = AV26TFPuestoDescripcion;
         AV103Wplistaasesoresds_8_tfpuestodescripcion_sel = AV27TFPuestoDescripcion_Sel;
         AV104Wplistaasesoresds_9_tfusuariogenero_sels = AV29TFUsuarioGenero_Sels;
         AV105Wplistaasesoresds_10_tfusuariocelular = AV48TFUsuarioCelular;
         AV106Wplistaasesoresds_11_tfusuariocelular_to = AV49TFUsuarioCelular_To;
         AV107Wplistaasesoresds_12_tfusuariosucursal = AV64TFUsuarioSucursal;
         AV108Wplistaasesoresds_13_tfusuariosucursal_sel = AV65TFUsuarioSucursal_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV93ListaUsuariosAsesores ,
                                              A40UsuarioRol ,
                                              AV99Wplistaasesoresds_4_tfusuariorol_sels ,
                                              A53UsuarioGenero ,
                                              AV104Wplistaasesoresds_9_tfusuariogenero_sels ,
                                              AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel ,
                                              AV97Wplistaasesoresds_2_tfusuarionombrecompleto ,
                                              AV99Wplistaasesoresds_4_tfusuariorol_sels.Count ,
                                              AV101Wplistaasesoresds_6_tfusuariocorreo_sel ,
                                              AV100Wplistaasesoresds_5_tfusuariocorreo ,
                                              AV103Wplistaasesoresds_8_tfpuestodescripcion_sel ,
                                              AV102Wplistaasesoresds_7_tfpuestodescripcion ,
                                              AV104Wplistaasesoresds_9_tfusuariogenero_sels.Count ,
                                              AV105Wplistaasesoresds_10_tfusuariocelular ,
                                              AV106Wplistaasesoresds_11_tfusuariocelular_to ,
                                              AV108Wplistaasesoresds_13_tfusuariosucursal_sel ,
                                              AV107Wplistaasesoresds_12_tfusuariosucursal ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A14PuestoDescripcion ,
                                              A64UsuarioCelular ,
                                              A66UsuarioSucursal ,
                                              AV96Wplistaasesoresds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV97Wplistaasesoresds_2_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV97Wplistaasesoresds_2_tfusuarionombrecompleto), "%", "");
         lV100Wplistaasesoresds_5_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV100Wplistaasesoresds_5_tfusuariocorreo), "%", "");
         lV102Wplistaasesoresds_7_tfpuestodescripcion = StringUtil.Concat( StringUtil.RTrim( AV102Wplistaasesoresds_7_tfpuestodescripcion), "%", "");
         lV107Wplistaasesoresds_12_tfusuariosucursal = StringUtil.PadR( StringUtil.RTrim( AV107Wplistaasesoresds_12_tfusuariosucursal), 20, "%");
         /* Using cursor P00373 */
         pr_default.execute(1, new Object[] {lV97Wplistaasesoresds_2_tfusuarionombrecompleto, AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, lV100Wplistaasesoresds_5_tfusuariocorreo, AV101Wplistaasesoresds_6_tfusuariocorreo_sel, lV102Wplistaasesoresds_7_tfpuestodescripcion, AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, AV105Wplistaasesoresds_10_tfusuariocelular, AV106Wplistaasesoresds_11_tfusuariocelular_to, lV107Wplistaasesoresds_12_tfusuariosucursal, AV108Wplistaasesoresds_13_tfusuariosucursal_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK373 = false;
            A13PuestoID = P00373_A13PuestoID[0];
            n13PuestoID = P00373_n13PuestoID[0];
            A31UsuarioCorreo = P00373_A31UsuarioCorreo[0];
            A29UsuarioID = P00373_A29UsuarioID[0];
            A64UsuarioCelular = P00373_A64UsuarioCelular[0];
            A66UsuarioSucursal = P00373_A66UsuarioSucursal[0];
            A53UsuarioGenero = P00373_A53UsuarioGenero[0];
            A14PuestoDescripcion = P00373_A14PuestoDescripcion[0];
            A40UsuarioRol = P00373_A40UsuarioRol[0];
            A52UsuarioNombreCompleto = P00373_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00373_A30UsuarioNombre[0];
            A51UsuarioApellido = P00373_A51UsuarioApellido[0];
            A14PuestoDescripcion = P00373_A14PuestoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Wplistaasesoresds_1_filterfulltext)) || ( ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A14PuestoDescripcion , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A53UsuarioGenero)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "masculino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Masculino", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "femenino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Femenino", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A66UsuarioSucursal , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV80count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00373_A31UsuarioCorreo[0], A31UsuarioCorreo) == 0 ) )
               {
                  BRK373 = false;
                  A29UsuarioID = P00373_A29UsuarioID[0];
                  if ( (AV93ListaUsuariosAsesores.IndexOf(A29UsuarioID)>0) )
                  {
                     AV80count = (long)(AV80count+1);
                  }
                  BRK373 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV71SkipItems) )
               {
                  AV75Option = (String.IsNullOrEmpty(StringUtil.RTrim( A31UsuarioCorreo)) ? "<#Empty#>" : A31UsuarioCorreo);
                  AV76Options.Add(AV75Option, 0);
                  AV79OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV80count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV76Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV71SkipItems = (short)(AV71SkipItems-1);
               }
            }
            if ( ! BRK373 )
            {
               BRK373 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPUESTODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV26TFPuestoDescripcion = AV70SearchTxt;
         AV27TFPuestoDescripcion_Sel = "";
         AV96Wplistaasesoresds_1_filterfulltext = AV92FilterFullText;
         AV97Wplistaasesoresds_2_tfusuarionombrecompleto = AV16TFUsuarioNombreCompleto;
         AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel = AV17TFUsuarioNombreCompleto_Sel;
         AV99Wplistaasesoresds_4_tfusuariorol_sels = AV69TFUsuarioRol_Sels;
         AV100Wplistaasesoresds_5_tfusuariocorreo = AV18TFUsuarioCorreo;
         AV101Wplistaasesoresds_6_tfusuariocorreo_sel = AV19TFUsuarioCorreo_Sel;
         AV102Wplistaasesoresds_7_tfpuestodescripcion = AV26TFPuestoDescripcion;
         AV103Wplistaasesoresds_8_tfpuestodescripcion_sel = AV27TFPuestoDescripcion_Sel;
         AV104Wplistaasesoresds_9_tfusuariogenero_sels = AV29TFUsuarioGenero_Sels;
         AV105Wplistaasesoresds_10_tfusuariocelular = AV48TFUsuarioCelular;
         AV106Wplistaasesoresds_11_tfusuariocelular_to = AV49TFUsuarioCelular_To;
         AV107Wplistaasesoresds_12_tfusuariosucursal = AV64TFUsuarioSucursal;
         AV108Wplistaasesoresds_13_tfusuariosucursal_sel = AV65TFUsuarioSucursal_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV93ListaUsuariosAsesores ,
                                              A40UsuarioRol ,
                                              AV99Wplistaasesoresds_4_tfusuariorol_sels ,
                                              A53UsuarioGenero ,
                                              AV104Wplistaasesoresds_9_tfusuariogenero_sels ,
                                              AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel ,
                                              AV97Wplistaasesoresds_2_tfusuarionombrecompleto ,
                                              AV99Wplistaasesoresds_4_tfusuariorol_sels.Count ,
                                              AV101Wplistaasesoresds_6_tfusuariocorreo_sel ,
                                              AV100Wplistaasesoresds_5_tfusuariocorreo ,
                                              AV103Wplistaasesoresds_8_tfpuestodescripcion_sel ,
                                              AV102Wplistaasesoresds_7_tfpuestodescripcion ,
                                              AV104Wplistaasesoresds_9_tfusuariogenero_sels.Count ,
                                              AV105Wplistaasesoresds_10_tfusuariocelular ,
                                              AV106Wplistaasesoresds_11_tfusuariocelular_to ,
                                              AV108Wplistaasesoresds_13_tfusuariosucursal_sel ,
                                              AV107Wplistaasesoresds_12_tfusuariosucursal ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A14PuestoDescripcion ,
                                              A64UsuarioCelular ,
                                              A66UsuarioSucursal ,
                                              AV96Wplistaasesoresds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV97Wplistaasesoresds_2_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV97Wplistaasesoresds_2_tfusuarionombrecompleto), "%", "");
         lV100Wplistaasesoresds_5_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV100Wplistaasesoresds_5_tfusuariocorreo), "%", "");
         lV102Wplistaasesoresds_7_tfpuestodescripcion = StringUtil.Concat( StringUtil.RTrim( AV102Wplistaasesoresds_7_tfpuestodescripcion), "%", "");
         lV107Wplistaasesoresds_12_tfusuariosucursal = StringUtil.PadR( StringUtil.RTrim( AV107Wplistaasesoresds_12_tfusuariosucursal), 20, "%");
         /* Using cursor P00374 */
         pr_default.execute(2, new Object[] {lV97Wplistaasesoresds_2_tfusuarionombrecompleto, AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, lV100Wplistaasesoresds_5_tfusuariocorreo, AV101Wplistaasesoresds_6_tfusuariocorreo_sel, lV102Wplistaasesoresds_7_tfpuestodescripcion, AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, AV105Wplistaasesoresds_10_tfusuariocelular, AV106Wplistaasesoresds_11_tfusuariocelular_to, lV107Wplistaasesoresds_12_tfusuariosucursal, AV108Wplistaasesoresds_13_tfusuariosucursal_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK375 = false;
            A13PuestoID = P00374_A13PuestoID[0];
            n13PuestoID = P00374_n13PuestoID[0];
            A29UsuarioID = P00374_A29UsuarioID[0];
            A64UsuarioCelular = P00374_A64UsuarioCelular[0];
            A66UsuarioSucursal = P00374_A66UsuarioSucursal[0];
            A53UsuarioGenero = P00374_A53UsuarioGenero[0];
            A14PuestoDescripcion = P00374_A14PuestoDescripcion[0];
            A31UsuarioCorreo = P00374_A31UsuarioCorreo[0];
            A40UsuarioRol = P00374_A40UsuarioRol[0];
            A52UsuarioNombreCompleto = P00374_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00374_A30UsuarioNombre[0];
            A51UsuarioApellido = P00374_A51UsuarioApellido[0];
            A14PuestoDescripcion = P00374_A14PuestoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Wplistaasesoresds_1_filterfulltext)) || ( ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A14PuestoDescripcion , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A53UsuarioGenero)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "masculino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Masculino", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "femenino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Femenino", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A66UsuarioSucursal , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV80count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P00374_A13PuestoID[0] == A13PuestoID ) )
               {
                  BRK375 = false;
                  A29UsuarioID = P00374_A29UsuarioID[0];
                  if ( (AV93ListaUsuariosAsesores.IndexOf(A29UsuarioID)>0) )
                  {
                     AV80count = (long)(AV80count+1);
                  }
                  BRK375 = true;
                  pr_default.readNext(2);
               }
               AV75Option = (String.IsNullOrEmpty(StringUtil.RTrim( A14PuestoDescripcion)) ? "<#Empty#>" : A14PuestoDescripcion);
               AV74InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV75Option, "<#Empty#>") != 0 ) && ( AV74InsertIndex <= AV76Options.Count ) && ( ( StringUtil.StrCmp(((string)AV76Options.Item(AV74InsertIndex)), AV75Option) < 0 ) || ( StringUtil.StrCmp(((string)AV76Options.Item(AV74InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV74InsertIndex = (int)(AV74InsertIndex+1);
               }
               AV76Options.Add(AV75Option, AV74InsertIndex);
               AV79OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV80count), "Z,ZZZ,ZZZ,ZZ9")), AV74InsertIndex);
               if ( AV76Options.Count == AV71SkipItems + 11 )
               {
                  AV76Options.RemoveItem(AV76Options.Count);
                  AV79OptionIndexes.RemoveItem(AV79OptionIndexes.Count);
               }
            }
            if ( ! BRK375 )
            {
               BRK375 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV71SkipItems > 0 )
         {
            AV76Options.RemoveItem(1);
            AV79OptionIndexes.RemoveItem(1);
            AV71SkipItems = (short)(AV71SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADUSUARIOSUCURSALOPTIONS' Routine */
         returnInSub = false;
         AV64TFUsuarioSucursal = AV70SearchTxt;
         AV65TFUsuarioSucursal_Sel = "";
         AV96Wplistaasesoresds_1_filterfulltext = AV92FilterFullText;
         AV97Wplistaasesoresds_2_tfusuarionombrecompleto = AV16TFUsuarioNombreCompleto;
         AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel = AV17TFUsuarioNombreCompleto_Sel;
         AV99Wplistaasesoresds_4_tfusuariorol_sels = AV69TFUsuarioRol_Sels;
         AV100Wplistaasesoresds_5_tfusuariocorreo = AV18TFUsuarioCorreo;
         AV101Wplistaasesoresds_6_tfusuariocorreo_sel = AV19TFUsuarioCorreo_Sel;
         AV102Wplistaasesoresds_7_tfpuestodescripcion = AV26TFPuestoDescripcion;
         AV103Wplistaasesoresds_8_tfpuestodescripcion_sel = AV27TFPuestoDescripcion_Sel;
         AV104Wplistaasesoresds_9_tfusuariogenero_sels = AV29TFUsuarioGenero_Sels;
         AV105Wplistaasesoresds_10_tfusuariocelular = AV48TFUsuarioCelular;
         AV106Wplistaasesoresds_11_tfusuariocelular_to = AV49TFUsuarioCelular_To;
         AV107Wplistaasesoresds_12_tfusuariosucursal = AV64TFUsuarioSucursal;
         AV108Wplistaasesoresds_13_tfusuariosucursal_sel = AV65TFUsuarioSucursal_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV93ListaUsuariosAsesores ,
                                              A40UsuarioRol ,
                                              AV99Wplistaasesoresds_4_tfusuariorol_sels ,
                                              A53UsuarioGenero ,
                                              AV104Wplistaasesoresds_9_tfusuariogenero_sels ,
                                              AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel ,
                                              AV97Wplistaasesoresds_2_tfusuarionombrecompleto ,
                                              AV99Wplistaasesoresds_4_tfusuariorol_sels.Count ,
                                              AV101Wplistaasesoresds_6_tfusuariocorreo_sel ,
                                              AV100Wplistaasesoresds_5_tfusuariocorreo ,
                                              AV103Wplistaasesoresds_8_tfpuestodescripcion_sel ,
                                              AV102Wplistaasesoresds_7_tfpuestodescripcion ,
                                              AV104Wplistaasesoresds_9_tfusuariogenero_sels.Count ,
                                              AV105Wplistaasesoresds_10_tfusuariocelular ,
                                              AV106Wplistaasesoresds_11_tfusuariocelular_to ,
                                              AV108Wplistaasesoresds_13_tfusuariosucursal_sel ,
                                              AV107Wplistaasesoresds_12_tfusuariosucursal ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A14PuestoDescripcion ,
                                              A64UsuarioCelular ,
                                              A66UsuarioSucursal ,
                                              AV96Wplistaasesoresds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV97Wplistaasesoresds_2_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV97Wplistaasesoresds_2_tfusuarionombrecompleto), "%", "");
         lV100Wplistaasesoresds_5_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV100Wplistaasesoresds_5_tfusuariocorreo), "%", "");
         lV102Wplistaasesoresds_7_tfpuestodescripcion = StringUtil.Concat( StringUtil.RTrim( AV102Wplistaasesoresds_7_tfpuestodescripcion), "%", "");
         lV107Wplistaasesoresds_12_tfusuariosucursal = StringUtil.PadR( StringUtil.RTrim( AV107Wplistaasesoresds_12_tfusuariosucursal), 20, "%");
         /* Using cursor P00375 */
         pr_default.execute(3, new Object[] {lV97Wplistaasesoresds_2_tfusuarionombrecompleto, AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, lV100Wplistaasesoresds_5_tfusuariocorreo, AV101Wplistaasesoresds_6_tfusuariocorreo_sel, lV102Wplistaasesoresds_7_tfpuestodescripcion, AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, AV105Wplistaasesoresds_10_tfusuariocelular, AV106Wplistaasesoresds_11_tfusuariocelular_to, lV107Wplistaasesoresds_12_tfusuariosucursal, AV108Wplistaasesoresds_13_tfusuariosucursal_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK377 = false;
            A13PuestoID = P00375_A13PuestoID[0];
            n13PuestoID = P00375_n13PuestoID[0];
            A66UsuarioSucursal = P00375_A66UsuarioSucursal[0];
            A29UsuarioID = P00375_A29UsuarioID[0];
            A64UsuarioCelular = P00375_A64UsuarioCelular[0];
            A53UsuarioGenero = P00375_A53UsuarioGenero[0];
            A14PuestoDescripcion = P00375_A14PuestoDescripcion[0];
            A31UsuarioCorreo = P00375_A31UsuarioCorreo[0];
            A40UsuarioRol = P00375_A40UsuarioRol[0];
            A52UsuarioNombreCompleto = P00375_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00375_A30UsuarioNombre[0];
            A51UsuarioApellido = P00375_A51UsuarioApellido[0];
            A14PuestoDescripcion = P00375_A14PuestoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Wplistaasesoresds_1_filterfulltext)) || ( ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A14PuestoDescripcion , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A53UsuarioGenero)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "masculino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Masculino", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "femenino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Wplistaasesoresds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Femenino", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A66UsuarioSucursal , StringUtil.PadR( "%" + AV96Wplistaasesoresds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV80count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00375_A66UsuarioSucursal[0], A66UsuarioSucursal) == 0 ) )
               {
                  BRK377 = false;
                  A29UsuarioID = P00375_A29UsuarioID[0];
                  if ( (AV93ListaUsuariosAsesores.IndexOf(A29UsuarioID)>0) )
                  {
                     AV80count = (long)(AV80count+1);
                  }
                  BRK377 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV71SkipItems) )
               {
                  AV75Option = (String.IsNullOrEmpty(StringUtil.RTrim( A66UsuarioSucursal)) ? "<#Empty#>" : A66UsuarioSucursal);
                  AV76Options.Add(AV75Option, 0);
                  AV79OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV80count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV76Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV71SkipItems = (short)(AV71SkipItems-1);
               }
            }
            if ( ! BRK377 )
            {
               BRK377 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV89OptionsJson = "";
         AV90OptionsDescJson = "";
         AV91OptionIndexesJson = "";
         AV76Options = new GxSimpleCollection<string>();
         AV78OptionsDesc = new GxSimpleCollection<string>();
         AV79OptionIndexes = new GxSimpleCollection<string>();
         AV70SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV81Session = context.GetSession();
         AV83GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV84GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV92FilterFullText = "";
         AV16TFUsuarioNombreCompleto = "";
         AV17TFUsuarioNombreCompleto_Sel = "";
         AV68TFUsuarioRol_SelsJson = "";
         AV69TFUsuarioRol_Sels = new GxSimpleCollection<string>();
         AV18TFUsuarioCorreo = "";
         AV19TFUsuarioCorreo_Sel = "";
         AV26TFPuestoDescripcion = "";
         AV27TFPuestoDescripcion_Sel = "";
         AV28TFUsuarioGenero_SelsJson = "";
         AV29TFUsuarioGenero_Sels = new GxSimpleCollection<string>();
         AV64TFUsuarioSucursal = "";
         AV65TFUsuarioSucursal_Sel = "";
         AV96Wplistaasesoresds_1_filterfulltext = "";
         AV97Wplistaasesoresds_2_tfusuarionombrecompleto = "";
         AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel = "";
         AV99Wplistaasesoresds_4_tfusuariorol_sels = new GxSimpleCollection<string>();
         AV100Wplistaasesoresds_5_tfusuariocorreo = "";
         AV101Wplistaasesoresds_6_tfusuariocorreo_sel = "";
         AV102Wplistaasesoresds_7_tfpuestodescripcion = "";
         AV103Wplistaasesoresds_8_tfpuestodescripcion_sel = "";
         AV104Wplistaasesoresds_9_tfusuariogenero_sels = new GxSimpleCollection<string>();
         AV107Wplistaasesoresds_12_tfusuariosucursal = "";
         AV108Wplistaasesoresds_13_tfusuariosucursal_sel = "";
         lV96Wplistaasesoresds_1_filterfulltext = "";
         lV97Wplistaasesoresds_2_tfusuarionombrecompleto = "";
         lV100Wplistaasesoresds_5_tfusuariocorreo = "";
         lV102Wplistaasesoresds_7_tfpuestodescripcion = "";
         lV107Wplistaasesoresds_12_tfusuariosucursal = "";
         AV93ListaUsuariosAsesores = new GxSimpleCollection<int>();
         A40UsuarioRol = "";
         A53UsuarioGenero = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A31UsuarioCorreo = "";
         A14PuestoDescripcion = "";
         A66UsuarioSucursal = "";
         A52UsuarioNombreCompleto = "";
         P00372_A13PuestoID = new int[1] ;
         P00372_n13PuestoID = new bool[] {false} ;
         P00372_A29UsuarioID = new int[1] ;
         P00372_A64UsuarioCelular = new long[1] ;
         P00372_A66UsuarioSucursal = new string[] {""} ;
         P00372_A53UsuarioGenero = new string[] {""} ;
         P00372_A14PuestoDescripcion = new string[] {""} ;
         P00372_A31UsuarioCorreo = new string[] {""} ;
         P00372_A40UsuarioRol = new string[] {""} ;
         P00372_A52UsuarioNombreCompleto = new string[] {""} ;
         P00372_A30UsuarioNombre = new string[] {""} ;
         P00372_A51UsuarioApellido = new string[] {""} ;
         AV75Option = "";
         P00373_A13PuestoID = new int[1] ;
         P00373_n13PuestoID = new bool[] {false} ;
         P00373_A31UsuarioCorreo = new string[] {""} ;
         P00373_A29UsuarioID = new int[1] ;
         P00373_A64UsuarioCelular = new long[1] ;
         P00373_A66UsuarioSucursal = new string[] {""} ;
         P00373_A53UsuarioGenero = new string[] {""} ;
         P00373_A14PuestoDescripcion = new string[] {""} ;
         P00373_A40UsuarioRol = new string[] {""} ;
         P00373_A52UsuarioNombreCompleto = new string[] {""} ;
         P00373_A30UsuarioNombre = new string[] {""} ;
         P00373_A51UsuarioApellido = new string[] {""} ;
         P00374_A13PuestoID = new int[1] ;
         P00374_n13PuestoID = new bool[] {false} ;
         P00374_A29UsuarioID = new int[1] ;
         P00374_A64UsuarioCelular = new long[1] ;
         P00374_A66UsuarioSucursal = new string[] {""} ;
         P00374_A53UsuarioGenero = new string[] {""} ;
         P00374_A14PuestoDescripcion = new string[] {""} ;
         P00374_A31UsuarioCorreo = new string[] {""} ;
         P00374_A40UsuarioRol = new string[] {""} ;
         P00374_A52UsuarioNombreCompleto = new string[] {""} ;
         P00374_A30UsuarioNombre = new string[] {""} ;
         P00374_A51UsuarioApellido = new string[] {""} ;
         P00375_A13PuestoID = new int[1] ;
         P00375_n13PuestoID = new bool[] {false} ;
         P00375_A66UsuarioSucursal = new string[] {""} ;
         P00375_A29UsuarioID = new int[1] ;
         P00375_A64UsuarioCelular = new long[1] ;
         P00375_A53UsuarioGenero = new string[] {""} ;
         P00375_A14PuestoDescripcion = new string[] {""} ;
         P00375_A31UsuarioCorreo = new string[] {""} ;
         P00375_A40UsuarioRol = new string[] {""} ;
         P00375_A52UsuarioNombreCompleto = new string[] {""} ;
         P00375_A30UsuarioNombre = new string[] {""} ;
         P00375_A51UsuarioApellido = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistaasesoresgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00372_A13PuestoID, P00372_n13PuestoID, P00372_A29UsuarioID, P00372_A64UsuarioCelular, P00372_A66UsuarioSucursal, P00372_A53UsuarioGenero, P00372_A14PuestoDescripcion, P00372_A31UsuarioCorreo, P00372_A40UsuarioRol, P00372_A52UsuarioNombreCompleto,
               P00372_A30UsuarioNombre, P00372_A51UsuarioApellido
               }
               , new Object[] {
               P00373_A13PuestoID, P00373_n13PuestoID, P00373_A31UsuarioCorreo, P00373_A29UsuarioID, P00373_A64UsuarioCelular, P00373_A66UsuarioSucursal, P00373_A53UsuarioGenero, P00373_A14PuestoDescripcion, P00373_A40UsuarioRol, P00373_A52UsuarioNombreCompleto,
               P00373_A30UsuarioNombre, P00373_A51UsuarioApellido
               }
               , new Object[] {
               P00374_A13PuestoID, P00374_n13PuestoID, P00374_A29UsuarioID, P00374_A64UsuarioCelular, P00374_A66UsuarioSucursal, P00374_A53UsuarioGenero, P00374_A14PuestoDescripcion, P00374_A31UsuarioCorreo, P00374_A40UsuarioRol, P00374_A52UsuarioNombreCompleto,
               P00374_A30UsuarioNombre, P00374_A51UsuarioApellido
               }
               , new Object[] {
               P00375_A13PuestoID, P00375_n13PuestoID, P00375_A66UsuarioSucursal, P00375_A29UsuarioID, P00375_A64UsuarioCelular, P00375_A53UsuarioGenero, P00375_A14PuestoDescripcion, P00375_A31UsuarioCorreo, P00375_A40UsuarioRol, P00375_A52UsuarioNombreCompleto,
               P00375_A30UsuarioNombre, P00375_A51UsuarioApellido
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV73MaxItems ;
      private short AV72PageIndex ;
      private short AV71SkipItems ;
      private int AV94GXV1 ;
      private int AV99Wplistaasesoresds_4_tfusuariorol_sels_Count ;
      private int AV104Wplistaasesoresds_9_tfusuariogenero_sels_Count ;
      private int A29UsuarioID ;
      private int A13PuestoID ;
      private int AV74InsertIndex ;
      private long AV48TFUsuarioCelular ;
      private long AV49TFUsuarioCelular_To ;
      private long AV105Wplistaasesoresds_10_tfusuariocelular ;
      private long AV106Wplistaasesoresds_11_tfusuariocelular_to ;
      private long A64UsuarioCelular ;
      private long AV80count ;
      private string AV64TFUsuarioSucursal ;
      private string AV65TFUsuarioSucursal_Sel ;
      private string AV107Wplistaasesoresds_12_tfusuariosucursal ;
      private string AV108Wplistaasesoresds_13_tfusuariosucursal_sel ;
      private string lV107Wplistaasesoresds_12_tfusuariosucursal ;
      private string A40UsuarioRol ;
      private string A53UsuarioGenero ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string A66UsuarioSucursal ;
      private bool returnInSub ;
      private bool n13PuestoID ;
      private bool BRK373 ;
      private bool BRK375 ;
      private bool BRK377 ;
      private string AV89OptionsJson ;
      private string AV90OptionsDescJson ;
      private string AV91OptionIndexesJson ;
      private string AV68TFUsuarioRol_SelsJson ;
      private string AV28TFUsuarioGenero_SelsJson ;
      private string AV86DDOName ;
      private string AV87SearchTxtParms ;
      private string AV88SearchTxtTo ;
      private string AV70SearchTxt ;
      private string AV92FilterFullText ;
      private string AV16TFUsuarioNombreCompleto ;
      private string AV17TFUsuarioNombreCompleto_Sel ;
      private string AV18TFUsuarioCorreo ;
      private string AV19TFUsuarioCorreo_Sel ;
      private string AV26TFPuestoDescripcion ;
      private string AV27TFPuestoDescripcion_Sel ;
      private string AV96Wplistaasesoresds_1_filterfulltext ;
      private string AV97Wplistaasesoresds_2_tfusuarionombrecompleto ;
      private string AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel ;
      private string AV100Wplistaasesoresds_5_tfusuariocorreo ;
      private string AV101Wplistaasesoresds_6_tfusuariocorreo_sel ;
      private string AV102Wplistaasesoresds_7_tfpuestodescripcion ;
      private string AV103Wplistaasesoresds_8_tfpuestodescripcion_sel ;
      private string lV96Wplistaasesoresds_1_filterfulltext ;
      private string lV97Wplistaasesoresds_2_tfusuarionombrecompleto ;
      private string lV100Wplistaasesoresds_5_tfusuariocorreo ;
      private string lV102Wplistaasesoresds_7_tfpuestodescripcion ;
      private string A31UsuarioCorreo ;
      private string A14PuestoDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV75Option ;
      private IGxSession AV81Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV76Options ;
      private GxSimpleCollection<string> AV78OptionsDesc ;
      private GxSimpleCollection<string> AV79OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV83GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV84GridStateFilterValue ;
      private GxSimpleCollection<string> AV69TFUsuarioRol_Sels ;
      private GxSimpleCollection<string> AV29TFUsuarioGenero_Sels ;
      private GxSimpleCollection<string> AV99Wplistaasesoresds_4_tfusuariorol_sels ;
      private GxSimpleCollection<string> AV104Wplistaasesoresds_9_tfusuariogenero_sels ;
      private GxSimpleCollection<int> AV93ListaUsuariosAsesores ;
      private IDataStoreProvider pr_default ;
      private int[] P00372_A13PuestoID ;
      private bool[] P00372_n13PuestoID ;
      private int[] P00372_A29UsuarioID ;
      private long[] P00372_A64UsuarioCelular ;
      private string[] P00372_A66UsuarioSucursal ;
      private string[] P00372_A53UsuarioGenero ;
      private string[] P00372_A14PuestoDescripcion ;
      private string[] P00372_A31UsuarioCorreo ;
      private string[] P00372_A40UsuarioRol ;
      private string[] P00372_A52UsuarioNombreCompleto ;
      private string[] P00372_A30UsuarioNombre ;
      private string[] P00372_A51UsuarioApellido ;
      private int[] P00373_A13PuestoID ;
      private bool[] P00373_n13PuestoID ;
      private string[] P00373_A31UsuarioCorreo ;
      private int[] P00373_A29UsuarioID ;
      private long[] P00373_A64UsuarioCelular ;
      private string[] P00373_A66UsuarioSucursal ;
      private string[] P00373_A53UsuarioGenero ;
      private string[] P00373_A14PuestoDescripcion ;
      private string[] P00373_A40UsuarioRol ;
      private string[] P00373_A52UsuarioNombreCompleto ;
      private string[] P00373_A30UsuarioNombre ;
      private string[] P00373_A51UsuarioApellido ;
      private int[] P00374_A13PuestoID ;
      private bool[] P00374_n13PuestoID ;
      private int[] P00374_A29UsuarioID ;
      private long[] P00374_A64UsuarioCelular ;
      private string[] P00374_A66UsuarioSucursal ;
      private string[] P00374_A53UsuarioGenero ;
      private string[] P00374_A14PuestoDescripcion ;
      private string[] P00374_A31UsuarioCorreo ;
      private string[] P00374_A40UsuarioRol ;
      private string[] P00374_A52UsuarioNombreCompleto ;
      private string[] P00374_A30UsuarioNombre ;
      private string[] P00374_A51UsuarioApellido ;
      private int[] P00375_A13PuestoID ;
      private bool[] P00375_n13PuestoID ;
      private string[] P00375_A66UsuarioSucursal ;
      private int[] P00375_A29UsuarioID ;
      private long[] P00375_A64UsuarioCelular ;
      private string[] P00375_A53UsuarioGenero ;
      private string[] P00375_A14PuestoDescripcion ;
      private string[] P00375_A31UsuarioCorreo ;
      private string[] P00375_A40UsuarioRol ;
      private string[] P00375_A52UsuarioNombreCompleto ;
      private string[] P00375_A30UsuarioNombre ;
      private string[] P00375_A51UsuarioApellido ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wplistaasesoresgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00372( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV93ListaUsuariosAsesores ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV99Wplistaasesoresds_4_tfusuariorol_sels ,
                                             string A53UsuarioGenero ,
                                             GxSimpleCollection<string> AV104Wplistaasesoresds_9_tfusuariogenero_sels ,
                                             string AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel ,
                                             string AV97Wplistaasesoresds_2_tfusuarionombrecompleto ,
                                             int AV99Wplistaasesoresds_4_tfusuariorol_sels_Count ,
                                             string AV101Wplistaasesoresds_6_tfusuariocorreo_sel ,
                                             string AV100Wplistaasesoresds_5_tfusuariocorreo ,
                                             string AV103Wplistaasesoresds_8_tfpuestodescripcion_sel ,
                                             string AV102Wplistaasesoresds_7_tfpuestodescripcion ,
                                             int AV104Wplistaasesoresds_9_tfusuariogenero_sels_Count ,
                                             long AV105Wplistaasesoresds_10_tfusuariocelular ,
                                             long AV106Wplistaasesoresds_11_tfusuariocelular_to ,
                                             string AV108Wplistaasesoresds_13_tfusuariosucursal_sel ,
                                             string AV107Wplistaasesoresds_12_tfusuariosucursal ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             string A14PuestoDescripcion ,
                                             long A64UsuarioCelular ,
                                             string A66UsuarioSucursal ,
                                             string AV96Wplistaasesoresds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`PuestoID`, T1.`UsuarioID`, T1.`UsuarioCelular`, T1.`UsuarioSucursal`, T1.`UsuarioGenero`, T2.`PuestoDescripcion`, T1.`UsuarioCorreo`, T1.`UsuarioRol`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM (`Usuario` T1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = T1.`PuestoID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV93ListaUsuariosAsesores, "T1.`UsuarioID` IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wplistaasesoresds_2_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV97Wplistaasesoresds_2_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( AV99Wplistaasesoresds_4_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV99Wplistaasesoresds_4_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Wplistaasesoresds_6_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wplistaasesoresds_5_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV100Wplistaasesoresds_5_tfusuariocorreo)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wplistaasesoresds_6_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV101Wplistaasesoresds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV101Wplistaasesoresds_6_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV101Wplistaasesoresds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wplistaasesoresds_7_tfpuestodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` like @lV102Wplistaasesoresds_7_tfpuestodescripcion)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)) && ! ( StringUtil.StrCmp(AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` = @AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` IS NULL or (LENGTH(TRIM(T2.`PuestoDescripcion`))=0))");
         }
         if ( AV104Wplistaasesoresds_9_tfusuariogenero_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV104Wplistaasesoresds_9_tfusuariogenero_sels, "T1.`UsuarioGenero` IN (", ")")+")");
         }
         if ( ! (0==AV105Wplistaasesoresds_10_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV105Wplistaasesoresds_10_tfusuariocelular)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV106Wplistaasesoresds_11_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV106Wplistaasesoresds_11_tfusuariocelular_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Wplistaasesoresds_13_tfusuariosucursal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wplistaasesoresds_12_tfusuariosucursal)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` like @lV107Wplistaasesoresds_12_tfusuariosucursal)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wplistaasesoresds_13_tfusuariosucursal_sel)) && ! ( StringUtil.StrCmp(AV108Wplistaasesoresds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` = @AV108Wplistaasesoresds_13_tfusuariosucursal_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV108Wplistaasesoresds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioSucursal`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00373( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV93ListaUsuariosAsesores ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV99Wplistaasesoresds_4_tfusuariorol_sels ,
                                             string A53UsuarioGenero ,
                                             GxSimpleCollection<string> AV104Wplistaasesoresds_9_tfusuariogenero_sels ,
                                             string AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel ,
                                             string AV97Wplistaasesoresds_2_tfusuarionombrecompleto ,
                                             int AV99Wplistaasesoresds_4_tfusuariorol_sels_Count ,
                                             string AV101Wplistaasesoresds_6_tfusuariocorreo_sel ,
                                             string AV100Wplistaasesoresds_5_tfusuariocorreo ,
                                             string AV103Wplistaasesoresds_8_tfpuestodescripcion_sel ,
                                             string AV102Wplistaasesoresds_7_tfpuestodescripcion ,
                                             int AV104Wplistaasesoresds_9_tfusuariogenero_sels_Count ,
                                             long AV105Wplistaasesoresds_10_tfusuariocelular ,
                                             long AV106Wplistaasesoresds_11_tfusuariocelular_to ,
                                             string AV108Wplistaasesoresds_13_tfusuariosucursal_sel ,
                                             string AV107Wplistaasesoresds_12_tfusuariosucursal ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             string A14PuestoDescripcion ,
                                             long A64UsuarioCelular ,
                                             string A66UsuarioSucursal ,
                                             string AV96Wplistaasesoresds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`PuestoID`, T1.`UsuarioCorreo`, T1.`UsuarioID`, T1.`UsuarioCelular`, T1.`UsuarioSucursal`, T1.`UsuarioGenero`, T2.`PuestoDescripcion`, T1.`UsuarioRol`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM (`Usuario` T1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = T1.`PuestoID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV93ListaUsuariosAsesores, "T1.`UsuarioID` IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wplistaasesoresds_2_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV97Wplistaasesoresds_2_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( AV99Wplistaasesoresds_4_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV99Wplistaasesoresds_4_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Wplistaasesoresds_6_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wplistaasesoresds_5_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV100Wplistaasesoresds_5_tfusuariocorreo)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wplistaasesoresds_6_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV101Wplistaasesoresds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV101Wplistaasesoresds_6_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV101Wplistaasesoresds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wplistaasesoresds_7_tfpuestodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` like @lV102Wplistaasesoresds_7_tfpuestodescripcion)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)) && ! ( StringUtil.StrCmp(AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` = @AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` IS NULL or (LENGTH(TRIM(T2.`PuestoDescripcion`))=0))");
         }
         if ( AV104Wplistaasesoresds_9_tfusuariogenero_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV104Wplistaasesoresds_9_tfusuariogenero_sels, "T1.`UsuarioGenero` IN (", ")")+")");
         }
         if ( ! (0==AV105Wplistaasesoresds_10_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV105Wplistaasesoresds_10_tfusuariocelular)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV106Wplistaasesoresds_11_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV106Wplistaasesoresds_11_tfusuariocelular_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Wplistaasesoresds_13_tfusuariosucursal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wplistaasesoresds_12_tfusuariosucursal)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` like @lV107Wplistaasesoresds_12_tfusuariosucursal)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wplistaasesoresds_13_tfusuariosucursal_sel)) && ! ( StringUtil.StrCmp(AV108Wplistaasesoresds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` = @AV108Wplistaasesoresds_13_tfusuariosucursal_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV108Wplistaasesoresds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioSucursal`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioCorreo`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00374( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV93ListaUsuariosAsesores ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV99Wplistaasesoresds_4_tfusuariorol_sels ,
                                             string A53UsuarioGenero ,
                                             GxSimpleCollection<string> AV104Wplistaasesoresds_9_tfusuariogenero_sels ,
                                             string AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel ,
                                             string AV97Wplistaasesoresds_2_tfusuarionombrecompleto ,
                                             int AV99Wplistaasesoresds_4_tfusuariorol_sels_Count ,
                                             string AV101Wplistaasesoresds_6_tfusuariocorreo_sel ,
                                             string AV100Wplistaasesoresds_5_tfusuariocorreo ,
                                             string AV103Wplistaasesoresds_8_tfpuestodescripcion_sel ,
                                             string AV102Wplistaasesoresds_7_tfpuestodescripcion ,
                                             int AV104Wplistaasesoresds_9_tfusuariogenero_sels_Count ,
                                             long AV105Wplistaasesoresds_10_tfusuariocelular ,
                                             long AV106Wplistaasesoresds_11_tfusuariocelular_to ,
                                             string AV108Wplistaasesoresds_13_tfusuariosucursal_sel ,
                                             string AV107Wplistaasesoresds_12_tfusuariosucursal ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             string A14PuestoDescripcion ,
                                             long A64UsuarioCelular ,
                                             string A66UsuarioSucursal ,
                                             string AV96Wplistaasesoresds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`PuestoID`, T1.`UsuarioID`, T1.`UsuarioCelular`, T1.`UsuarioSucursal`, T1.`UsuarioGenero`, T2.`PuestoDescripcion`, T1.`UsuarioCorreo`, T1.`UsuarioRol`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM (`Usuario` T1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = T1.`PuestoID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV93ListaUsuariosAsesores, "T1.`UsuarioID` IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wplistaasesoresds_2_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV97Wplistaasesoresds_2_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( AV99Wplistaasesoresds_4_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV99Wplistaasesoresds_4_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Wplistaasesoresds_6_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wplistaasesoresds_5_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV100Wplistaasesoresds_5_tfusuariocorreo)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wplistaasesoresds_6_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV101Wplistaasesoresds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV101Wplistaasesoresds_6_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV101Wplistaasesoresds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wplistaasesoresds_7_tfpuestodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` like @lV102Wplistaasesoresds_7_tfpuestodescripcion)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)) && ! ( StringUtil.StrCmp(AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` = @AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` IS NULL or (LENGTH(TRIM(T2.`PuestoDescripcion`))=0))");
         }
         if ( AV104Wplistaasesoresds_9_tfusuariogenero_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV104Wplistaasesoresds_9_tfusuariogenero_sels, "T1.`UsuarioGenero` IN (", ")")+")");
         }
         if ( ! (0==AV105Wplistaasesoresds_10_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV105Wplistaasesoresds_10_tfusuariocelular)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV106Wplistaasesoresds_11_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV106Wplistaasesoresds_11_tfusuariocelular_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Wplistaasesoresds_13_tfusuariosucursal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wplistaasesoresds_12_tfusuariosucursal)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` like @lV107Wplistaasesoresds_12_tfusuariosucursal)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wplistaasesoresds_13_tfusuariosucursal_sel)) && ! ( StringUtil.StrCmp(AV108Wplistaasesoresds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` = @AV108Wplistaasesoresds_13_tfusuariosucursal_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV108Wplistaasesoresds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioSucursal`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`PuestoID`";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00375( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV93ListaUsuariosAsesores ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV99Wplistaasesoresds_4_tfusuariorol_sels ,
                                             string A53UsuarioGenero ,
                                             GxSimpleCollection<string> AV104Wplistaasesoresds_9_tfusuariogenero_sels ,
                                             string AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel ,
                                             string AV97Wplistaasesoresds_2_tfusuarionombrecompleto ,
                                             int AV99Wplistaasesoresds_4_tfusuariorol_sels_Count ,
                                             string AV101Wplistaasesoresds_6_tfusuariocorreo_sel ,
                                             string AV100Wplistaasesoresds_5_tfusuariocorreo ,
                                             string AV103Wplistaasesoresds_8_tfpuestodescripcion_sel ,
                                             string AV102Wplistaasesoresds_7_tfpuestodescripcion ,
                                             int AV104Wplistaasesoresds_9_tfusuariogenero_sels_Count ,
                                             long AV105Wplistaasesoresds_10_tfusuariocelular ,
                                             long AV106Wplistaasesoresds_11_tfusuariocelular_to ,
                                             string AV108Wplistaasesoresds_13_tfusuariosucursal_sel ,
                                             string AV107Wplistaasesoresds_12_tfusuariosucursal ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             string A14PuestoDescripcion ,
                                             long A64UsuarioCelular ,
                                             string A66UsuarioSucursal ,
                                             string AV96Wplistaasesoresds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[10];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.`PuestoID`, T1.`UsuarioSucursal`, T1.`UsuarioID`, T1.`UsuarioCelular`, T1.`UsuarioGenero`, T2.`PuestoDescripcion`, T1.`UsuarioCorreo`, T1.`UsuarioRol`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM (`Usuario` T1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = T1.`PuestoID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV93ListaUsuariosAsesores, "T1.`UsuarioID` IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wplistaasesoresds_2_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV97Wplistaasesoresds_2_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( AV99Wplistaasesoresds_4_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV99Wplistaasesoresds_4_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Wplistaasesoresds_6_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wplistaasesoresds_5_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV100Wplistaasesoresds_5_tfusuariocorreo)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wplistaasesoresds_6_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV101Wplistaasesoresds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV101Wplistaasesoresds_6_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV101Wplistaasesoresds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wplistaasesoresds_7_tfpuestodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` like @lV102Wplistaasesoresds_7_tfpuestodescripcion)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)) && ! ( StringUtil.StrCmp(AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` = @AV103Wplistaasesoresds_8_tfpuestodescripcion_sel)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV103Wplistaasesoresds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` IS NULL or (LENGTH(TRIM(T2.`PuestoDescripcion`))=0))");
         }
         if ( AV104Wplistaasesoresds_9_tfusuariogenero_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV104Wplistaasesoresds_9_tfusuariogenero_sels, "T1.`UsuarioGenero` IN (", ")")+")");
         }
         if ( ! (0==AV105Wplistaasesoresds_10_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV105Wplistaasesoresds_10_tfusuariocelular)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV106Wplistaasesoresds_11_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV106Wplistaasesoresds_11_tfusuariocelular_to)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Wplistaasesoresds_13_tfusuariosucursal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wplistaasesoresds_12_tfusuariosucursal)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` like @lV107Wplistaasesoresds_12_tfusuariosucursal)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wplistaasesoresds_13_tfusuariosucursal_sel)) && ! ( StringUtil.StrCmp(AV108Wplistaasesoresds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` = @AV108Wplistaasesoresds_13_tfusuariosucursal_sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV108Wplistaasesoresds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioSucursal`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioSucursal`";
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
                     return conditional_P00372(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 1 :
                     return conditional_P00373(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 2 :
                     return conditional_P00374(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 3 :
                     return conditional_P00375(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
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
          Object[] prmP00372;
          prmP00372 = new Object[] {
          new ParDef("@lV97Wplistaasesoresds_2_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV100Wplistaasesoresds_5_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV101Wplistaasesoresds_6_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@lV102Wplistaasesoresds_7_tfpuestodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV103Wplistaasesoresds_8_tfpuestodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV105Wplistaasesoresds_10_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV106Wplistaasesoresds_11_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV107Wplistaasesoresds_12_tfusuariosucursal",GXType.Char,20,0) ,
          new ParDef("@AV108Wplistaasesoresds_13_tfusuariosucursal_sel",GXType.Char,20,0)
          };
          Object[] prmP00373;
          prmP00373 = new Object[] {
          new ParDef("@lV97Wplistaasesoresds_2_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV100Wplistaasesoresds_5_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV101Wplistaasesoresds_6_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@lV102Wplistaasesoresds_7_tfpuestodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV103Wplistaasesoresds_8_tfpuestodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV105Wplistaasesoresds_10_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV106Wplistaasesoresds_11_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV107Wplistaasesoresds_12_tfusuariosucursal",GXType.Char,20,0) ,
          new ParDef("@AV108Wplistaasesoresds_13_tfusuariosucursal_sel",GXType.Char,20,0)
          };
          Object[] prmP00374;
          prmP00374 = new Object[] {
          new ParDef("@lV97Wplistaasesoresds_2_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV100Wplistaasesoresds_5_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV101Wplistaasesoresds_6_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@lV102Wplistaasesoresds_7_tfpuestodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV103Wplistaasesoresds_8_tfpuestodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV105Wplistaasesoresds_10_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV106Wplistaasesoresds_11_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV107Wplistaasesoresds_12_tfusuariosucursal",GXType.Char,20,0) ,
          new ParDef("@AV108Wplistaasesoresds_13_tfusuariosucursal_sel",GXType.Char,20,0)
          };
          Object[] prmP00375;
          prmP00375 = new Object[] {
          new ParDef("@lV97Wplistaasesoresds_2_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV98Wplistaasesoresds_3_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV100Wplistaasesoresds_5_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV101Wplistaasesoresds_6_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@lV102Wplistaasesoresds_7_tfpuestodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV103Wplistaasesoresds_8_tfpuestodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV105Wplistaasesoresds_10_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV106Wplistaasesoresds_11_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV107Wplistaasesoresds_12_tfusuariosucursal",GXType.Char,20,0) ,
          new ParDef("@AV108Wplistaasesoresds_13_tfusuariosucursal_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00372", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00372,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00373", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00373,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00374", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00374,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00375", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00375,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 40);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 50);
                ((string[]) buf[11])[0] = rslt.getString(11, 50);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 40);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 50);
                ((string[]) buf[11])[0] = rslt.getString(11, 50);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 40);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 50);
                ((string[]) buf[11])[0] = rslt.getString(11, 50);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 40);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 50);
                ((string[]) buf[11])[0] = rslt.getString(11, 50);
                return;
       }
    }

 }

}
