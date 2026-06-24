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
   public class wplistaparticipantesgetfilterdata : GXProcedure
   {
      public wplistaparticipantesgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wplistaparticipantesgetfilterdata( IGxContext context )
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
         this.AV42DDOName = aP0_DDOName;
         this.AV43SearchTxtParms = aP1_SearchTxtParms;
         this.AV44SearchTxtTo = aP2_SearchTxtTo;
         this.AV45OptionsJson = "" ;
         this.AV46OptionsDescJson = "" ;
         this.AV47OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV45OptionsJson;
         aP4_OptionsDescJson=this.AV46OptionsDescJson;
         aP5_OptionIndexesJson=this.AV47OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV47OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV42DDOName = aP0_DDOName;
         this.AV43SearchTxtParms = aP1_SearchTxtParms;
         this.AV44SearchTxtTo = aP2_SearchTxtTo;
         this.AV45OptionsJson = "" ;
         this.AV46OptionsDescJson = "" ;
         this.AV47OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV45OptionsJson;
         aP4_OptionsDescJson=this.AV46OptionsDescJson;
         aP5_OptionIndexesJson=this.AV47OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV32Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29MaxItems = 10;
         AV28PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV43SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV43SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV26SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV43SearchTxtParms)) ? "" : StringUtil.Substring( AV43SearchTxtParms, 3, -1));
         AV27SkipItems = (short)(AV28PageIndex*AV29MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV42DDOName), "DDO_USUARIONOMBRECOMPLETO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIONOMBRECOMPLETOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV42DDOName), "DDO_USUARIOCORREO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIOCORREOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV42DDOName), "DDO_PUESTODESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPUESTODESCRIPCIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV42DDOName), "DDO_USUARIOSUCURSAL") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIOSUCURSALOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV45OptionsJson = AV32Options.ToJSonString(false);
         AV46OptionsDescJson = AV34OptionsDesc.ToJSonString(false);
         AV47OptionIndexesJson = AV35OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get("WPListaParticipantesGridState"), "") == 0 )
         {
            AV39GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPListaParticipantesGridState"), null, "", "");
         }
         else
         {
            AV39GridState.FromXml(AV37Session.Get("WPListaParticipantesGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV39GridState.gxTpr_Filtervalues.Count )
         {
            AV40GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV39GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV48FilterFullText = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV10TFUsuarioNombreCompleto = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV11TFUsuarioNombreCompleto_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFUSUARIOROL_SEL") == 0 )
            {
               AV12TFUsuarioRol_SelsJson = AV40GridStateFilterValue.gxTpr_Value;
               AV13TFUsuarioRol_Sels.FromJSonString(AV12TFUsuarioRol_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO") == 0 )
            {
               AV14TFUsuarioCorreo = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO_SEL") == 0 )
            {
               AV15TFUsuarioCorreo_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPUESTODESCRIPCION") == 0 )
            {
               AV16TFPuestoDescripcion = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPUESTODESCRIPCION_SEL") == 0 )
            {
               AV17TFPuestoDescripcion_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFUSUARIOGENERO_SEL") == 0 )
            {
               AV18TFUsuarioGenero_SelsJson = AV40GridStateFilterValue.gxTpr_Value;
               AV19TFUsuarioGenero_Sels.FromJSonString(AV18TFUsuarioGenero_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFUSUARIOCELULAR") == 0 )
            {
               AV22TFUsuarioCelular = (long)(Math.Round(NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV23TFUsuarioCelular_To = (long)(Math.Round(NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFUSUARIOSUCURSAL") == 0 )
            {
               AV24TFUsuarioSucursal = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFUSUARIOSUCURSAL_SEL") == 0 )
            {
               AV25TFUsuarioSucursal_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADUSUARIONOMBRECOMPLETOOPTIONS' Routine */
         returnInSub = false;
         AV10TFUsuarioNombreCompleto = AV26SearchTxt;
         AV11TFUsuarioNombreCompleto_Sel = "";
         AV52Wplistaparticipantesds_1_filterfulltext = AV48FilterFullText;
         AV53Wplistaparticipantesds_2_tfusuarionombrecompleto = AV10TFUsuarioNombreCompleto;
         AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV11TFUsuarioNombreCompleto_Sel;
         AV55Wplistaparticipantesds_4_tfusuariorol_sels = AV13TFUsuarioRol_Sels;
         AV56Wplistaparticipantesds_5_tfusuariocorreo = AV14TFUsuarioCorreo;
         AV57Wplistaparticipantesds_6_tfusuariocorreo_sel = AV15TFUsuarioCorreo_Sel;
         AV58Wplistaparticipantesds_7_tfpuestodescripcion = AV16TFPuestoDescripcion;
         AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV17TFPuestoDescripcion_Sel;
         AV60Wplistaparticipantesds_9_tfusuariogenero_sels = AV19TFUsuarioGenero_Sels;
         AV61Wplistaparticipantesds_10_tfusuariocelular = AV22TFUsuarioCelular;
         AV62Wplistaparticipantesds_11_tfusuariocelular_to = AV23TFUsuarioCelular_To;
         AV63Wplistaparticipantesds_12_tfusuariosucursal = AV24TFUsuarioSucursal;
         AV64Wplistaparticipantesds_13_tfusuariosucursal_sel = AV25TFUsuarioSucursal_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV49ListaUsuariosAsesores ,
                                              A40UsuarioRol ,
                                              AV55Wplistaparticipantesds_4_tfusuariorol_sels ,
                                              A53UsuarioGenero ,
                                              AV60Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                              AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                              AV53Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                              AV55Wplistaparticipantesds_4_tfusuariorol_sels.Count ,
                                              AV57Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                              AV56Wplistaparticipantesds_5_tfusuariocorreo ,
                                              AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                              AV58Wplistaparticipantesds_7_tfpuestodescripcion ,
                                              AV60Wplistaparticipantesds_9_tfusuariogenero_sels.Count ,
                                              AV61Wplistaparticipantesds_10_tfusuariocelular ,
                                              AV62Wplistaparticipantesds_11_tfusuariocelular_to ,
                                              AV64Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                              AV63Wplistaparticipantesds_12_tfusuariosucursal ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A14PuestoDescripcion ,
                                              A64UsuarioCelular ,
                                              A66UsuarioSucursal ,
                                              AV52Wplistaparticipantesds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV53Wplistaparticipantesds_2_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV53Wplistaparticipantesds_2_tfusuarionombrecompleto), "%", "");
         lV56Wplistaparticipantesds_5_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV56Wplistaparticipantesds_5_tfusuariocorreo), "%", "");
         lV58Wplistaparticipantesds_7_tfpuestodescripcion = StringUtil.Concat( StringUtil.RTrim( AV58Wplistaparticipantesds_7_tfpuestodescripcion), "%", "");
         lV63Wplistaparticipantesds_12_tfusuariosucursal = StringUtil.PadR( StringUtil.RTrim( AV63Wplistaparticipantesds_12_tfusuariosucursal), 20, "%");
         /* Using cursor P00382 */
         pr_default.execute(0, new Object[] {lV53Wplistaparticipantesds_2_tfusuarionombrecompleto, AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, lV56Wplistaparticipantesds_5_tfusuariocorreo, AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, lV58Wplistaparticipantesds_7_tfpuestodescripcion, AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, AV61Wplistaparticipantesds_10_tfusuariocelular, AV62Wplistaparticipantesds_11_tfusuariocelular_to, lV63Wplistaparticipantesds_12_tfusuariosucursal, AV64Wplistaparticipantesds_13_tfusuariosucursal_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A13PuestoID = P00382_A13PuestoID[0];
            n13PuestoID = P00382_n13PuestoID[0];
            A29UsuarioID = P00382_A29UsuarioID[0];
            A64UsuarioCelular = P00382_A64UsuarioCelular[0];
            A66UsuarioSucursal = P00382_A66UsuarioSucursal[0];
            A53UsuarioGenero = P00382_A53UsuarioGenero[0];
            A14PuestoDescripcion = P00382_A14PuestoDescripcion[0];
            A31UsuarioCorreo = P00382_A31UsuarioCorreo[0];
            A40UsuarioRol = P00382_A40UsuarioRol[0];
            A52UsuarioNombreCompleto = P00382_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00382_A30UsuarioNombre[0];
            A51UsuarioApellido = P00382_A51UsuarioApellido[0];
            A14PuestoDescripcion = P00382_A14PuestoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wplistaparticipantesds_1_filterfulltext)) || ( ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A14PuestoDescripcion , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A53UsuarioGenero)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "masculino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Masculino", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "femenino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Femenino", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A66UsuarioSucursal , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV31Option = (String.IsNullOrEmpty(StringUtil.RTrim( A52UsuarioNombreCompleto)) ? "<#Empty#>" : A52UsuarioNombreCompleto);
               AV30InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV31Option, "<#Empty#>") != 0 ) && ( AV30InsertIndex <= AV32Options.Count ) && ( ( StringUtil.StrCmp(((string)AV32Options.Item(AV30InsertIndex)), AV31Option) < 0 ) || ( StringUtil.StrCmp(((string)AV32Options.Item(AV30InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV30InsertIndex = (int)(AV30InsertIndex+1);
               }
               if ( ( AV30InsertIndex <= AV32Options.Count ) && ( StringUtil.StrCmp(((string)AV32Options.Item(AV30InsertIndex)), AV31Option) == 0 ) )
               {
                  AV36count = (long)(Math.Round(NumberUtil.Val( ((string)AV35OptionIndexes.Item(AV30InsertIndex)), "."), 18, MidpointRounding.ToEven));
                  AV36count = (long)(AV36count+1);
                  AV35OptionIndexes.RemoveItem(AV30InsertIndex);
                  AV35OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), AV30InsertIndex);
               }
               else
               {
                  AV32Options.Add(AV31Option, AV30InsertIndex);
                  AV35OptionIndexes.Add("1", AV30InsertIndex);
               }
               if ( AV32Options.Count == AV27SkipItems + 11 )
               {
                  AV32Options.RemoveItem(AV32Options.Count);
                  AV35OptionIndexes.RemoveItem(AV35OptionIndexes.Count);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         while ( AV27SkipItems > 0 )
         {
            AV32Options.RemoveItem(1);
            AV35OptionIndexes.RemoveItem(1);
            AV27SkipItems = (short)(AV27SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADUSUARIOCORREOOPTIONS' Routine */
         returnInSub = false;
         AV14TFUsuarioCorreo = AV26SearchTxt;
         AV15TFUsuarioCorreo_Sel = "";
         AV52Wplistaparticipantesds_1_filterfulltext = AV48FilterFullText;
         AV53Wplistaparticipantesds_2_tfusuarionombrecompleto = AV10TFUsuarioNombreCompleto;
         AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV11TFUsuarioNombreCompleto_Sel;
         AV55Wplistaparticipantesds_4_tfusuariorol_sels = AV13TFUsuarioRol_Sels;
         AV56Wplistaparticipantesds_5_tfusuariocorreo = AV14TFUsuarioCorreo;
         AV57Wplistaparticipantesds_6_tfusuariocorreo_sel = AV15TFUsuarioCorreo_Sel;
         AV58Wplistaparticipantesds_7_tfpuestodescripcion = AV16TFPuestoDescripcion;
         AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV17TFPuestoDescripcion_Sel;
         AV60Wplistaparticipantesds_9_tfusuariogenero_sels = AV19TFUsuarioGenero_Sels;
         AV61Wplistaparticipantesds_10_tfusuariocelular = AV22TFUsuarioCelular;
         AV62Wplistaparticipantesds_11_tfusuariocelular_to = AV23TFUsuarioCelular_To;
         AV63Wplistaparticipantesds_12_tfusuariosucursal = AV24TFUsuarioSucursal;
         AV64Wplistaparticipantesds_13_tfusuariosucursal_sel = AV25TFUsuarioSucursal_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV49ListaUsuariosAsesores ,
                                              A40UsuarioRol ,
                                              AV55Wplistaparticipantesds_4_tfusuariorol_sels ,
                                              A53UsuarioGenero ,
                                              AV60Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                              AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                              AV53Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                              AV55Wplistaparticipantesds_4_tfusuariorol_sels.Count ,
                                              AV57Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                              AV56Wplistaparticipantesds_5_tfusuariocorreo ,
                                              AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                              AV58Wplistaparticipantesds_7_tfpuestodescripcion ,
                                              AV60Wplistaparticipantesds_9_tfusuariogenero_sels.Count ,
                                              AV61Wplistaparticipantesds_10_tfusuariocelular ,
                                              AV62Wplistaparticipantesds_11_tfusuariocelular_to ,
                                              AV64Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                              AV63Wplistaparticipantesds_12_tfusuariosucursal ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A14PuestoDescripcion ,
                                              A64UsuarioCelular ,
                                              A66UsuarioSucursal ,
                                              AV52Wplistaparticipantesds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV53Wplistaparticipantesds_2_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV53Wplistaparticipantesds_2_tfusuarionombrecompleto), "%", "");
         lV56Wplistaparticipantesds_5_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV56Wplistaparticipantesds_5_tfusuariocorreo), "%", "");
         lV58Wplistaparticipantesds_7_tfpuestodescripcion = StringUtil.Concat( StringUtil.RTrim( AV58Wplistaparticipantesds_7_tfpuestodescripcion), "%", "");
         lV63Wplistaparticipantesds_12_tfusuariosucursal = StringUtil.PadR( StringUtil.RTrim( AV63Wplistaparticipantesds_12_tfusuariosucursal), 20, "%");
         /* Using cursor P00383 */
         pr_default.execute(1, new Object[] {lV53Wplistaparticipantesds_2_tfusuarionombrecompleto, AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, lV56Wplistaparticipantesds_5_tfusuariocorreo, AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, lV58Wplistaparticipantesds_7_tfpuestodescripcion, AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, AV61Wplistaparticipantesds_10_tfusuariocelular, AV62Wplistaparticipantesds_11_tfusuariocelular_to, lV63Wplistaparticipantesds_12_tfusuariosucursal, AV64Wplistaparticipantesds_13_tfusuariosucursal_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK383 = false;
            A13PuestoID = P00383_A13PuestoID[0];
            n13PuestoID = P00383_n13PuestoID[0];
            A31UsuarioCorreo = P00383_A31UsuarioCorreo[0];
            A29UsuarioID = P00383_A29UsuarioID[0];
            A64UsuarioCelular = P00383_A64UsuarioCelular[0];
            A66UsuarioSucursal = P00383_A66UsuarioSucursal[0];
            A53UsuarioGenero = P00383_A53UsuarioGenero[0];
            A14PuestoDescripcion = P00383_A14PuestoDescripcion[0];
            A40UsuarioRol = P00383_A40UsuarioRol[0];
            A52UsuarioNombreCompleto = P00383_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00383_A30UsuarioNombre[0];
            A51UsuarioApellido = P00383_A51UsuarioApellido[0];
            A14PuestoDescripcion = P00383_A14PuestoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wplistaparticipantesds_1_filterfulltext)) || ( ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A14PuestoDescripcion , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A53UsuarioGenero)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "masculino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Masculino", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "femenino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Femenino", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A66UsuarioSucursal , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV36count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00383_A31UsuarioCorreo[0], A31UsuarioCorreo) == 0 ) )
               {
                  BRK383 = false;
                  A29UsuarioID = P00383_A29UsuarioID[0];
                  if ( (AV49ListaUsuariosAsesores.IndexOf(A29UsuarioID)>0) )
                  {
                     AV36count = (long)(AV36count+1);
                  }
                  BRK383 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV27SkipItems) )
               {
                  AV31Option = (String.IsNullOrEmpty(StringUtil.RTrim( A31UsuarioCorreo)) ? "<#Empty#>" : A31UsuarioCorreo);
                  AV32Options.Add(AV31Option, 0);
                  AV35OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV32Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV27SkipItems = (short)(AV27SkipItems-1);
               }
            }
            if ( ! BRK383 )
            {
               BRK383 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPUESTODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV16TFPuestoDescripcion = AV26SearchTxt;
         AV17TFPuestoDescripcion_Sel = "";
         AV52Wplistaparticipantesds_1_filterfulltext = AV48FilterFullText;
         AV53Wplistaparticipantesds_2_tfusuarionombrecompleto = AV10TFUsuarioNombreCompleto;
         AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV11TFUsuarioNombreCompleto_Sel;
         AV55Wplistaparticipantesds_4_tfusuariorol_sels = AV13TFUsuarioRol_Sels;
         AV56Wplistaparticipantesds_5_tfusuariocorreo = AV14TFUsuarioCorreo;
         AV57Wplistaparticipantesds_6_tfusuariocorreo_sel = AV15TFUsuarioCorreo_Sel;
         AV58Wplistaparticipantesds_7_tfpuestodescripcion = AV16TFPuestoDescripcion;
         AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV17TFPuestoDescripcion_Sel;
         AV60Wplistaparticipantesds_9_tfusuariogenero_sels = AV19TFUsuarioGenero_Sels;
         AV61Wplistaparticipantesds_10_tfusuariocelular = AV22TFUsuarioCelular;
         AV62Wplistaparticipantesds_11_tfusuariocelular_to = AV23TFUsuarioCelular_To;
         AV63Wplistaparticipantesds_12_tfusuariosucursal = AV24TFUsuarioSucursal;
         AV64Wplistaparticipantesds_13_tfusuariosucursal_sel = AV25TFUsuarioSucursal_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV49ListaUsuariosAsesores ,
                                              A40UsuarioRol ,
                                              AV55Wplistaparticipantesds_4_tfusuariorol_sels ,
                                              A53UsuarioGenero ,
                                              AV60Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                              AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                              AV53Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                              AV55Wplistaparticipantesds_4_tfusuariorol_sels.Count ,
                                              AV57Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                              AV56Wplistaparticipantesds_5_tfusuariocorreo ,
                                              AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                              AV58Wplistaparticipantesds_7_tfpuestodescripcion ,
                                              AV60Wplistaparticipantesds_9_tfusuariogenero_sels.Count ,
                                              AV61Wplistaparticipantesds_10_tfusuariocelular ,
                                              AV62Wplistaparticipantesds_11_tfusuariocelular_to ,
                                              AV64Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                              AV63Wplistaparticipantesds_12_tfusuariosucursal ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A14PuestoDescripcion ,
                                              A64UsuarioCelular ,
                                              A66UsuarioSucursal ,
                                              AV52Wplistaparticipantesds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV53Wplistaparticipantesds_2_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV53Wplistaparticipantesds_2_tfusuarionombrecompleto), "%", "");
         lV56Wplistaparticipantesds_5_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV56Wplistaparticipantesds_5_tfusuariocorreo), "%", "");
         lV58Wplistaparticipantesds_7_tfpuestodescripcion = StringUtil.Concat( StringUtil.RTrim( AV58Wplistaparticipantesds_7_tfpuestodescripcion), "%", "");
         lV63Wplistaparticipantesds_12_tfusuariosucursal = StringUtil.PadR( StringUtil.RTrim( AV63Wplistaparticipantesds_12_tfusuariosucursal), 20, "%");
         /* Using cursor P00384 */
         pr_default.execute(2, new Object[] {lV53Wplistaparticipantesds_2_tfusuarionombrecompleto, AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, lV56Wplistaparticipantesds_5_tfusuariocorreo, AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, lV58Wplistaparticipantesds_7_tfpuestodescripcion, AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, AV61Wplistaparticipantesds_10_tfusuariocelular, AV62Wplistaparticipantesds_11_tfusuariocelular_to, lV63Wplistaparticipantesds_12_tfusuariosucursal, AV64Wplistaparticipantesds_13_tfusuariosucursal_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK385 = false;
            A13PuestoID = P00384_A13PuestoID[0];
            n13PuestoID = P00384_n13PuestoID[0];
            A29UsuarioID = P00384_A29UsuarioID[0];
            A64UsuarioCelular = P00384_A64UsuarioCelular[0];
            A66UsuarioSucursal = P00384_A66UsuarioSucursal[0];
            A53UsuarioGenero = P00384_A53UsuarioGenero[0];
            A14PuestoDescripcion = P00384_A14PuestoDescripcion[0];
            A31UsuarioCorreo = P00384_A31UsuarioCorreo[0];
            A40UsuarioRol = P00384_A40UsuarioRol[0];
            A52UsuarioNombreCompleto = P00384_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00384_A30UsuarioNombre[0];
            A51UsuarioApellido = P00384_A51UsuarioApellido[0];
            A14PuestoDescripcion = P00384_A14PuestoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wplistaparticipantesds_1_filterfulltext)) || ( ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A14PuestoDescripcion , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A53UsuarioGenero)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "masculino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Masculino", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "femenino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Femenino", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A66UsuarioSucursal , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV36count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P00384_A13PuestoID[0] == A13PuestoID ) )
               {
                  BRK385 = false;
                  A29UsuarioID = P00384_A29UsuarioID[0];
                  if ( (AV49ListaUsuariosAsesores.IndexOf(A29UsuarioID)>0) )
                  {
                     AV36count = (long)(AV36count+1);
                  }
                  BRK385 = true;
                  pr_default.readNext(2);
               }
               AV31Option = (String.IsNullOrEmpty(StringUtil.RTrim( A14PuestoDescripcion)) ? "<#Empty#>" : A14PuestoDescripcion);
               AV30InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV31Option, "<#Empty#>") != 0 ) && ( AV30InsertIndex <= AV32Options.Count ) && ( ( StringUtil.StrCmp(((string)AV32Options.Item(AV30InsertIndex)), AV31Option) < 0 ) || ( StringUtil.StrCmp(((string)AV32Options.Item(AV30InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV30InsertIndex = (int)(AV30InsertIndex+1);
               }
               AV32Options.Add(AV31Option, AV30InsertIndex);
               AV35OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), AV30InsertIndex);
               if ( AV32Options.Count == AV27SkipItems + 11 )
               {
                  AV32Options.RemoveItem(AV32Options.Count);
                  AV35OptionIndexes.RemoveItem(AV35OptionIndexes.Count);
               }
            }
            if ( ! BRK385 )
            {
               BRK385 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV27SkipItems > 0 )
         {
            AV32Options.RemoveItem(1);
            AV35OptionIndexes.RemoveItem(1);
            AV27SkipItems = (short)(AV27SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADUSUARIOSUCURSALOPTIONS' Routine */
         returnInSub = false;
         AV24TFUsuarioSucursal = AV26SearchTxt;
         AV25TFUsuarioSucursal_Sel = "";
         AV52Wplistaparticipantesds_1_filterfulltext = AV48FilterFullText;
         AV53Wplistaparticipantesds_2_tfusuarionombrecompleto = AV10TFUsuarioNombreCompleto;
         AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV11TFUsuarioNombreCompleto_Sel;
         AV55Wplistaparticipantesds_4_tfusuariorol_sels = AV13TFUsuarioRol_Sels;
         AV56Wplistaparticipantesds_5_tfusuariocorreo = AV14TFUsuarioCorreo;
         AV57Wplistaparticipantesds_6_tfusuariocorreo_sel = AV15TFUsuarioCorreo_Sel;
         AV58Wplistaparticipantesds_7_tfpuestodescripcion = AV16TFPuestoDescripcion;
         AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV17TFPuestoDescripcion_Sel;
         AV60Wplistaparticipantesds_9_tfusuariogenero_sels = AV19TFUsuarioGenero_Sels;
         AV61Wplistaparticipantesds_10_tfusuariocelular = AV22TFUsuarioCelular;
         AV62Wplistaparticipantesds_11_tfusuariocelular_to = AV23TFUsuarioCelular_To;
         AV63Wplistaparticipantesds_12_tfusuariosucursal = AV24TFUsuarioSucursal;
         AV64Wplistaparticipantesds_13_tfusuariosucursal_sel = AV25TFUsuarioSucursal_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV49ListaUsuariosAsesores ,
                                              A40UsuarioRol ,
                                              AV55Wplistaparticipantesds_4_tfusuariorol_sels ,
                                              A53UsuarioGenero ,
                                              AV60Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                              AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                              AV53Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                              AV55Wplistaparticipantesds_4_tfusuariorol_sels.Count ,
                                              AV57Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                              AV56Wplistaparticipantesds_5_tfusuariocorreo ,
                                              AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                              AV58Wplistaparticipantesds_7_tfpuestodescripcion ,
                                              AV60Wplistaparticipantesds_9_tfusuariogenero_sels.Count ,
                                              AV61Wplistaparticipantesds_10_tfusuariocelular ,
                                              AV62Wplistaparticipantesds_11_tfusuariocelular_to ,
                                              AV64Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                              AV63Wplistaparticipantesds_12_tfusuariosucursal ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A14PuestoDescripcion ,
                                              A64UsuarioCelular ,
                                              A66UsuarioSucursal ,
                                              AV52Wplistaparticipantesds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV53Wplistaparticipantesds_2_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV53Wplistaparticipantesds_2_tfusuarionombrecompleto), "%", "");
         lV56Wplistaparticipantesds_5_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV56Wplistaparticipantesds_5_tfusuariocorreo), "%", "");
         lV58Wplistaparticipantesds_7_tfpuestodescripcion = StringUtil.Concat( StringUtil.RTrim( AV58Wplistaparticipantesds_7_tfpuestodescripcion), "%", "");
         lV63Wplistaparticipantesds_12_tfusuariosucursal = StringUtil.PadR( StringUtil.RTrim( AV63Wplistaparticipantesds_12_tfusuariosucursal), 20, "%");
         /* Using cursor P00385 */
         pr_default.execute(3, new Object[] {lV53Wplistaparticipantesds_2_tfusuarionombrecompleto, AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, lV56Wplistaparticipantesds_5_tfusuariocorreo, AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, lV58Wplistaparticipantesds_7_tfpuestodescripcion, AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, AV61Wplistaparticipantesds_10_tfusuariocelular, AV62Wplistaparticipantesds_11_tfusuariocelular_to, lV63Wplistaparticipantesds_12_tfusuariosucursal, AV64Wplistaparticipantesds_13_tfusuariosucursal_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK387 = false;
            A13PuestoID = P00385_A13PuestoID[0];
            n13PuestoID = P00385_n13PuestoID[0];
            A66UsuarioSucursal = P00385_A66UsuarioSucursal[0];
            A29UsuarioID = P00385_A29UsuarioID[0];
            A64UsuarioCelular = P00385_A64UsuarioCelular[0];
            A53UsuarioGenero = P00385_A53UsuarioGenero[0];
            A14PuestoDescripcion = P00385_A14PuestoDescripcion[0];
            A31UsuarioCorreo = P00385_A31UsuarioCorreo[0];
            A40UsuarioRol = P00385_A40UsuarioRol[0];
            A52UsuarioNombreCompleto = P00385_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00385_A30UsuarioNombre[0];
            A51UsuarioApellido = P00385_A51UsuarioApellido[0];
            A14PuestoDescripcion = P00385_A14PuestoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wplistaparticipantesds_1_filterfulltext)) || ( ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A14PuestoDescripcion , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A53UsuarioGenero)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "masculino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Masculino", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "femenino", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, context.GetMessage( "Femenino", "")) == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A66UsuarioSucursal , StringUtil.PadR( "%" + AV52Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV36count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00385_A66UsuarioSucursal[0], A66UsuarioSucursal) == 0 ) )
               {
                  BRK387 = false;
                  A29UsuarioID = P00385_A29UsuarioID[0];
                  if ( (AV49ListaUsuariosAsesores.IndexOf(A29UsuarioID)>0) )
                  {
                     AV36count = (long)(AV36count+1);
                  }
                  BRK387 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV27SkipItems) )
               {
                  AV31Option = (String.IsNullOrEmpty(StringUtil.RTrim( A66UsuarioSucursal)) ? "<#Empty#>" : A66UsuarioSucursal);
                  AV32Options.Add(AV31Option, 0);
                  AV35OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV32Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV27SkipItems = (short)(AV27SkipItems-1);
               }
            }
            if ( ! BRK387 )
            {
               BRK387 = true;
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
         AV45OptionsJson = "";
         AV46OptionsDescJson = "";
         AV47OptionIndexesJson = "";
         AV32Options = new GxSimpleCollection<string>();
         AV34OptionsDesc = new GxSimpleCollection<string>();
         AV35OptionIndexes = new GxSimpleCollection<string>();
         AV26SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV39GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV40GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV48FilterFullText = "";
         AV10TFUsuarioNombreCompleto = "";
         AV11TFUsuarioNombreCompleto_Sel = "";
         AV12TFUsuarioRol_SelsJson = "";
         AV13TFUsuarioRol_Sels = new GxSimpleCollection<string>();
         AV14TFUsuarioCorreo = "";
         AV15TFUsuarioCorreo_Sel = "";
         AV16TFPuestoDescripcion = "";
         AV17TFPuestoDescripcion_Sel = "";
         AV18TFUsuarioGenero_SelsJson = "";
         AV19TFUsuarioGenero_Sels = new GxSimpleCollection<string>();
         AV24TFUsuarioSucursal = "";
         AV25TFUsuarioSucursal_Sel = "";
         AV52Wplistaparticipantesds_1_filterfulltext = "";
         AV53Wplistaparticipantesds_2_tfusuarionombrecompleto = "";
         AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = "";
         AV55Wplistaparticipantesds_4_tfusuariorol_sels = new GxSimpleCollection<string>();
         AV56Wplistaparticipantesds_5_tfusuariocorreo = "";
         AV57Wplistaparticipantesds_6_tfusuariocorreo_sel = "";
         AV58Wplistaparticipantesds_7_tfpuestodescripcion = "";
         AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel = "";
         AV60Wplistaparticipantesds_9_tfusuariogenero_sels = new GxSimpleCollection<string>();
         AV63Wplistaparticipantesds_12_tfusuariosucursal = "";
         AV64Wplistaparticipantesds_13_tfusuariosucursal_sel = "";
         lV52Wplistaparticipantesds_1_filterfulltext = "";
         lV53Wplistaparticipantesds_2_tfusuarionombrecompleto = "";
         lV56Wplistaparticipantesds_5_tfusuariocorreo = "";
         lV58Wplistaparticipantesds_7_tfpuestodescripcion = "";
         lV63Wplistaparticipantesds_12_tfusuariosucursal = "";
         AV49ListaUsuariosAsesores = new GxSimpleCollection<int>();
         A40UsuarioRol = "";
         A53UsuarioGenero = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A31UsuarioCorreo = "";
         A14PuestoDescripcion = "";
         A66UsuarioSucursal = "";
         A52UsuarioNombreCompleto = "";
         P00382_A13PuestoID = new int[1] ;
         P00382_n13PuestoID = new bool[] {false} ;
         P00382_A29UsuarioID = new int[1] ;
         P00382_A64UsuarioCelular = new long[1] ;
         P00382_A66UsuarioSucursal = new string[] {""} ;
         P00382_A53UsuarioGenero = new string[] {""} ;
         P00382_A14PuestoDescripcion = new string[] {""} ;
         P00382_A31UsuarioCorreo = new string[] {""} ;
         P00382_A40UsuarioRol = new string[] {""} ;
         P00382_A52UsuarioNombreCompleto = new string[] {""} ;
         P00382_A30UsuarioNombre = new string[] {""} ;
         P00382_A51UsuarioApellido = new string[] {""} ;
         AV31Option = "";
         P00383_A13PuestoID = new int[1] ;
         P00383_n13PuestoID = new bool[] {false} ;
         P00383_A31UsuarioCorreo = new string[] {""} ;
         P00383_A29UsuarioID = new int[1] ;
         P00383_A64UsuarioCelular = new long[1] ;
         P00383_A66UsuarioSucursal = new string[] {""} ;
         P00383_A53UsuarioGenero = new string[] {""} ;
         P00383_A14PuestoDescripcion = new string[] {""} ;
         P00383_A40UsuarioRol = new string[] {""} ;
         P00383_A52UsuarioNombreCompleto = new string[] {""} ;
         P00383_A30UsuarioNombre = new string[] {""} ;
         P00383_A51UsuarioApellido = new string[] {""} ;
         P00384_A13PuestoID = new int[1] ;
         P00384_n13PuestoID = new bool[] {false} ;
         P00384_A29UsuarioID = new int[1] ;
         P00384_A64UsuarioCelular = new long[1] ;
         P00384_A66UsuarioSucursal = new string[] {""} ;
         P00384_A53UsuarioGenero = new string[] {""} ;
         P00384_A14PuestoDescripcion = new string[] {""} ;
         P00384_A31UsuarioCorreo = new string[] {""} ;
         P00384_A40UsuarioRol = new string[] {""} ;
         P00384_A52UsuarioNombreCompleto = new string[] {""} ;
         P00384_A30UsuarioNombre = new string[] {""} ;
         P00384_A51UsuarioApellido = new string[] {""} ;
         P00385_A13PuestoID = new int[1] ;
         P00385_n13PuestoID = new bool[] {false} ;
         P00385_A66UsuarioSucursal = new string[] {""} ;
         P00385_A29UsuarioID = new int[1] ;
         P00385_A64UsuarioCelular = new long[1] ;
         P00385_A53UsuarioGenero = new string[] {""} ;
         P00385_A14PuestoDescripcion = new string[] {""} ;
         P00385_A31UsuarioCorreo = new string[] {""} ;
         P00385_A40UsuarioRol = new string[] {""} ;
         P00385_A52UsuarioNombreCompleto = new string[] {""} ;
         P00385_A30UsuarioNombre = new string[] {""} ;
         P00385_A51UsuarioApellido = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistaparticipantesgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00382_A13PuestoID, P00382_n13PuestoID, P00382_A29UsuarioID, P00382_A64UsuarioCelular, P00382_A66UsuarioSucursal, P00382_A53UsuarioGenero, P00382_A14PuestoDescripcion, P00382_A31UsuarioCorreo, P00382_A40UsuarioRol, P00382_A52UsuarioNombreCompleto,
               P00382_A30UsuarioNombre, P00382_A51UsuarioApellido
               }
               , new Object[] {
               P00383_A13PuestoID, P00383_n13PuestoID, P00383_A31UsuarioCorreo, P00383_A29UsuarioID, P00383_A64UsuarioCelular, P00383_A66UsuarioSucursal, P00383_A53UsuarioGenero, P00383_A14PuestoDescripcion, P00383_A40UsuarioRol, P00383_A52UsuarioNombreCompleto,
               P00383_A30UsuarioNombre, P00383_A51UsuarioApellido
               }
               , new Object[] {
               P00384_A13PuestoID, P00384_n13PuestoID, P00384_A29UsuarioID, P00384_A64UsuarioCelular, P00384_A66UsuarioSucursal, P00384_A53UsuarioGenero, P00384_A14PuestoDescripcion, P00384_A31UsuarioCorreo, P00384_A40UsuarioRol, P00384_A52UsuarioNombreCompleto,
               P00384_A30UsuarioNombre, P00384_A51UsuarioApellido
               }
               , new Object[] {
               P00385_A13PuestoID, P00385_n13PuestoID, P00385_A66UsuarioSucursal, P00385_A29UsuarioID, P00385_A64UsuarioCelular, P00385_A53UsuarioGenero, P00385_A14PuestoDescripcion, P00385_A31UsuarioCorreo, P00385_A40UsuarioRol, P00385_A52UsuarioNombreCompleto,
               P00385_A30UsuarioNombre, P00385_A51UsuarioApellido
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV29MaxItems ;
      private short AV28PageIndex ;
      private short AV27SkipItems ;
      private int AV50GXV1 ;
      private int AV55Wplistaparticipantesds_4_tfusuariorol_sels_Count ;
      private int AV60Wplistaparticipantesds_9_tfusuariogenero_sels_Count ;
      private int A29UsuarioID ;
      private int A13PuestoID ;
      private int AV30InsertIndex ;
      private long AV22TFUsuarioCelular ;
      private long AV23TFUsuarioCelular_To ;
      private long AV61Wplistaparticipantesds_10_tfusuariocelular ;
      private long AV62Wplistaparticipantesds_11_tfusuariocelular_to ;
      private long A64UsuarioCelular ;
      private long AV36count ;
      private string AV24TFUsuarioSucursal ;
      private string AV25TFUsuarioSucursal_Sel ;
      private string AV63Wplistaparticipantesds_12_tfusuariosucursal ;
      private string AV64Wplistaparticipantesds_13_tfusuariosucursal_sel ;
      private string lV63Wplistaparticipantesds_12_tfusuariosucursal ;
      private string A40UsuarioRol ;
      private string A53UsuarioGenero ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string A66UsuarioSucursal ;
      private bool returnInSub ;
      private bool n13PuestoID ;
      private bool BRK383 ;
      private bool BRK385 ;
      private bool BRK387 ;
      private string AV45OptionsJson ;
      private string AV46OptionsDescJson ;
      private string AV47OptionIndexesJson ;
      private string AV12TFUsuarioRol_SelsJson ;
      private string AV18TFUsuarioGenero_SelsJson ;
      private string AV42DDOName ;
      private string AV43SearchTxtParms ;
      private string AV44SearchTxtTo ;
      private string AV26SearchTxt ;
      private string AV48FilterFullText ;
      private string AV10TFUsuarioNombreCompleto ;
      private string AV11TFUsuarioNombreCompleto_Sel ;
      private string AV14TFUsuarioCorreo ;
      private string AV15TFUsuarioCorreo_Sel ;
      private string AV16TFPuestoDescripcion ;
      private string AV17TFPuestoDescripcion_Sel ;
      private string AV52Wplistaparticipantesds_1_filterfulltext ;
      private string AV53Wplistaparticipantesds_2_tfusuarionombrecompleto ;
      private string AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ;
      private string AV56Wplistaparticipantesds_5_tfusuariocorreo ;
      private string AV57Wplistaparticipantesds_6_tfusuariocorreo_sel ;
      private string AV58Wplistaparticipantesds_7_tfpuestodescripcion ;
      private string AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel ;
      private string lV52Wplistaparticipantesds_1_filterfulltext ;
      private string lV53Wplistaparticipantesds_2_tfusuarionombrecompleto ;
      private string lV56Wplistaparticipantesds_5_tfusuariocorreo ;
      private string lV58Wplistaparticipantesds_7_tfpuestodescripcion ;
      private string A31UsuarioCorreo ;
      private string A14PuestoDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV31Option ;
      private IGxSession AV37Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV32Options ;
      private GxSimpleCollection<string> AV34OptionsDesc ;
      private GxSimpleCollection<string> AV35OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV39GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV40GridStateFilterValue ;
      private GxSimpleCollection<string> AV13TFUsuarioRol_Sels ;
      private GxSimpleCollection<string> AV19TFUsuarioGenero_Sels ;
      private GxSimpleCollection<string> AV55Wplistaparticipantesds_4_tfusuariorol_sels ;
      private GxSimpleCollection<string> AV60Wplistaparticipantesds_9_tfusuariogenero_sels ;
      private GxSimpleCollection<int> AV49ListaUsuariosAsesores ;
      private IDataStoreProvider pr_default ;
      private int[] P00382_A13PuestoID ;
      private bool[] P00382_n13PuestoID ;
      private int[] P00382_A29UsuarioID ;
      private long[] P00382_A64UsuarioCelular ;
      private string[] P00382_A66UsuarioSucursal ;
      private string[] P00382_A53UsuarioGenero ;
      private string[] P00382_A14PuestoDescripcion ;
      private string[] P00382_A31UsuarioCorreo ;
      private string[] P00382_A40UsuarioRol ;
      private string[] P00382_A52UsuarioNombreCompleto ;
      private string[] P00382_A30UsuarioNombre ;
      private string[] P00382_A51UsuarioApellido ;
      private int[] P00383_A13PuestoID ;
      private bool[] P00383_n13PuestoID ;
      private string[] P00383_A31UsuarioCorreo ;
      private int[] P00383_A29UsuarioID ;
      private long[] P00383_A64UsuarioCelular ;
      private string[] P00383_A66UsuarioSucursal ;
      private string[] P00383_A53UsuarioGenero ;
      private string[] P00383_A14PuestoDescripcion ;
      private string[] P00383_A40UsuarioRol ;
      private string[] P00383_A52UsuarioNombreCompleto ;
      private string[] P00383_A30UsuarioNombre ;
      private string[] P00383_A51UsuarioApellido ;
      private int[] P00384_A13PuestoID ;
      private bool[] P00384_n13PuestoID ;
      private int[] P00384_A29UsuarioID ;
      private long[] P00384_A64UsuarioCelular ;
      private string[] P00384_A66UsuarioSucursal ;
      private string[] P00384_A53UsuarioGenero ;
      private string[] P00384_A14PuestoDescripcion ;
      private string[] P00384_A31UsuarioCorreo ;
      private string[] P00384_A40UsuarioRol ;
      private string[] P00384_A52UsuarioNombreCompleto ;
      private string[] P00384_A30UsuarioNombre ;
      private string[] P00384_A51UsuarioApellido ;
      private int[] P00385_A13PuestoID ;
      private bool[] P00385_n13PuestoID ;
      private string[] P00385_A66UsuarioSucursal ;
      private int[] P00385_A29UsuarioID ;
      private long[] P00385_A64UsuarioCelular ;
      private string[] P00385_A53UsuarioGenero ;
      private string[] P00385_A14PuestoDescripcion ;
      private string[] P00385_A31UsuarioCorreo ;
      private string[] P00385_A40UsuarioRol ;
      private string[] P00385_A52UsuarioNombreCompleto ;
      private string[] P00385_A30UsuarioNombre ;
      private string[] P00385_A51UsuarioApellido ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wplistaparticipantesgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00382( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV49ListaUsuariosAsesores ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV55Wplistaparticipantesds_4_tfusuariorol_sels ,
                                             string A53UsuarioGenero ,
                                             GxSimpleCollection<string> AV60Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                             string AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                             string AV53Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                             int AV55Wplistaparticipantesds_4_tfusuariorol_sels_Count ,
                                             string AV57Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                             string AV56Wplistaparticipantesds_5_tfusuariocorreo ,
                                             string AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                             string AV58Wplistaparticipantesds_7_tfpuestodescripcion ,
                                             int AV60Wplistaparticipantesds_9_tfusuariogenero_sels_Count ,
                                             long AV61Wplistaparticipantesds_10_tfusuariocelular ,
                                             long AV62Wplistaparticipantesds_11_tfusuariocelular_to ,
                                             string AV64Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                             string AV63Wplistaparticipantesds_12_tfusuariosucursal ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             string A14PuestoDescripcion ,
                                             long A64UsuarioCelular ,
                                             string A66UsuarioSucursal ,
                                             string AV52Wplistaparticipantesds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`PuestoID`, T1.`UsuarioID`, T1.`UsuarioCelular`, T1.`UsuarioSucursal`, T1.`UsuarioGenero`, T2.`PuestoDescripcion`, T1.`UsuarioCorreo`, T1.`UsuarioRol`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM (`Usuario` T1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = T1.`PuestoID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV49ListaUsuariosAsesores, "T1.`UsuarioID` IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wplistaparticipantesds_2_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV53Wplistaparticipantesds_2_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( AV55Wplistaparticipantesds_4_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV55Wplistaparticipantesds_4_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wplistaparticipantesds_5_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV56Wplistaparticipantesds_5_tfusuariocorreo)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wplistaparticipantesds_7_tfpuestodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` like @lV58Wplistaparticipantesds_7_tfpuestodescripcion)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ! ( StringUtil.StrCmp(AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` = @AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` IS NULL or (LENGTH(TRIM(T2.`PuestoDescripcion`))=0))");
         }
         if ( AV60Wplistaparticipantesds_9_tfusuariogenero_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV60Wplistaparticipantesds_9_tfusuariogenero_sels, "T1.`UsuarioGenero` IN (", ")")+")");
         }
         if ( ! (0==AV61Wplistaparticipantesds_10_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV61Wplistaparticipantesds_10_tfusuariocelular)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV62Wplistaparticipantesds_11_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV62Wplistaparticipantesds_11_tfusuariocelular_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wplistaparticipantesds_12_tfusuariosucursal)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` like @lV63Wplistaparticipantesds_12_tfusuariosucursal)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ! ( StringUtil.StrCmp(AV64Wplistaparticipantesds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` = @AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Wplistaparticipantesds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioSucursal`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00383( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV49ListaUsuariosAsesores ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV55Wplistaparticipantesds_4_tfusuariorol_sels ,
                                             string A53UsuarioGenero ,
                                             GxSimpleCollection<string> AV60Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                             string AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                             string AV53Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                             int AV55Wplistaparticipantesds_4_tfusuariorol_sels_Count ,
                                             string AV57Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                             string AV56Wplistaparticipantesds_5_tfusuariocorreo ,
                                             string AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                             string AV58Wplistaparticipantesds_7_tfpuestodescripcion ,
                                             int AV60Wplistaparticipantesds_9_tfusuariogenero_sels_Count ,
                                             long AV61Wplistaparticipantesds_10_tfusuariocelular ,
                                             long AV62Wplistaparticipantesds_11_tfusuariocelular_to ,
                                             string AV64Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                             string AV63Wplistaparticipantesds_12_tfusuariosucursal ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             string A14PuestoDescripcion ,
                                             long A64UsuarioCelular ,
                                             string A66UsuarioSucursal ,
                                             string AV52Wplistaparticipantesds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`PuestoID`, T1.`UsuarioCorreo`, T1.`UsuarioID`, T1.`UsuarioCelular`, T1.`UsuarioSucursal`, T1.`UsuarioGenero`, T2.`PuestoDescripcion`, T1.`UsuarioRol`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM (`Usuario` T1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = T1.`PuestoID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV49ListaUsuariosAsesores, "T1.`UsuarioID` IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wplistaparticipantesds_2_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV53Wplistaparticipantesds_2_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( AV55Wplistaparticipantesds_4_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV55Wplistaparticipantesds_4_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wplistaparticipantesds_5_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV56Wplistaparticipantesds_5_tfusuariocorreo)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wplistaparticipantesds_7_tfpuestodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` like @lV58Wplistaparticipantesds_7_tfpuestodescripcion)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ! ( StringUtil.StrCmp(AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` = @AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` IS NULL or (LENGTH(TRIM(T2.`PuestoDescripcion`))=0))");
         }
         if ( AV60Wplistaparticipantesds_9_tfusuariogenero_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV60Wplistaparticipantesds_9_tfusuariogenero_sels, "T1.`UsuarioGenero` IN (", ")")+")");
         }
         if ( ! (0==AV61Wplistaparticipantesds_10_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV61Wplistaparticipantesds_10_tfusuariocelular)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV62Wplistaparticipantesds_11_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV62Wplistaparticipantesds_11_tfusuariocelular_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wplistaparticipantesds_12_tfusuariosucursal)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` like @lV63Wplistaparticipantesds_12_tfusuariosucursal)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ! ( StringUtil.StrCmp(AV64Wplistaparticipantesds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` = @AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Wplistaparticipantesds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioSucursal`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioCorreo`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00384( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV49ListaUsuariosAsesores ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV55Wplistaparticipantesds_4_tfusuariorol_sels ,
                                             string A53UsuarioGenero ,
                                             GxSimpleCollection<string> AV60Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                             string AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                             string AV53Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                             int AV55Wplistaparticipantesds_4_tfusuariorol_sels_Count ,
                                             string AV57Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                             string AV56Wplistaparticipantesds_5_tfusuariocorreo ,
                                             string AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                             string AV58Wplistaparticipantesds_7_tfpuestodescripcion ,
                                             int AV60Wplistaparticipantesds_9_tfusuariogenero_sels_Count ,
                                             long AV61Wplistaparticipantesds_10_tfusuariocelular ,
                                             long AV62Wplistaparticipantesds_11_tfusuariocelular_to ,
                                             string AV64Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                             string AV63Wplistaparticipantesds_12_tfusuariosucursal ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             string A14PuestoDescripcion ,
                                             long A64UsuarioCelular ,
                                             string A66UsuarioSucursal ,
                                             string AV52Wplistaparticipantesds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`PuestoID`, T1.`UsuarioID`, T1.`UsuarioCelular`, T1.`UsuarioSucursal`, T1.`UsuarioGenero`, T2.`PuestoDescripcion`, T1.`UsuarioCorreo`, T1.`UsuarioRol`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM (`Usuario` T1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = T1.`PuestoID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV49ListaUsuariosAsesores, "T1.`UsuarioID` IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wplistaparticipantesds_2_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV53Wplistaparticipantesds_2_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( AV55Wplistaparticipantesds_4_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV55Wplistaparticipantesds_4_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wplistaparticipantesds_5_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV56Wplistaparticipantesds_5_tfusuariocorreo)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wplistaparticipantesds_7_tfpuestodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` like @lV58Wplistaparticipantesds_7_tfpuestodescripcion)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ! ( StringUtil.StrCmp(AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` = @AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` IS NULL or (LENGTH(TRIM(T2.`PuestoDescripcion`))=0))");
         }
         if ( AV60Wplistaparticipantesds_9_tfusuariogenero_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV60Wplistaparticipantesds_9_tfusuariogenero_sels, "T1.`UsuarioGenero` IN (", ")")+")");
         }
         if ( ! (0==AV61Wplistaparticipantesds_10_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV61Wplistaparticipantesds_10_tfusuariocelular)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV62Wplistaparticipantesds_11_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV62Wplistaparticipantesds_11_tfusuariocelular_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wplistaparticipantesds_12_tfusuariosucursal)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` like @lV63Wplistaparticipantesds_12_tfusuariosucursal)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ! ( StringUtil.StrCmp(AV64Wplistaparticipantesds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` = @AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Wplistaparticipantesds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioSucursal`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`PuestoID`";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00385( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV49ListaUsuariosAsesores ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV55Wplistaparticipantesds_4_tfusuariorol_sels ,
                                             string A53UsuarioGenero ,
                                             GxSimpleCollection<string> AV60Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                             string AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                             string AV53Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                             int AV55Wplistaparticipantesds_4_tfusuariorol_sels_Count ,
                                             string AV57Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                             string AV56Wplistaparticipantesds_5_tfusuariocorreo ,
                                             string AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                             string AV58Wplistaparticipantesds_7_tfpuestodescripcion ,
                                             int AV60Wplistaparticipantesds_9_tfusuariogenero_sels_Count ,
                                             long AV61Wplistaparticipantesds_10_tfusuariocelular ,
                                             long AV62Wplistaparticipantesds_11_tfusuariocelular_to ,
                                             string AV64Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                             string AV63Wplistaparticipantesds_12_tfusuariosucursal ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             string A14PuestoDescripcion ,
                                             long A64UsuarioCelular ,
                                             string A66UsuarioSucursal ,
                                             string AV52Wplistaparticipantesds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[10];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.`PuestoID`, T1.`UsuarioSucursal`, T1.`UsuarioID`, T1.`UsuarioCelular`, T1.`UsuarioGenero`, T2.`PuestoDescripcion`, T1.`UsuarioCorreo`, T1.`UsuarioRol`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM (`Usuario` T1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = T1.`PuestoID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV49ListaUsuariosAsesores, "T1.`UsuarioID` IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wplistaparticipantesds_2_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV53Wplistaparticipantesds_2_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( AV55Wplistaparticipantesds_4_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV55Wplistaparticipantesds_4_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wplistaparticipantesds_5_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV56Wplistaparticipantesds_5_tfusuariocorreo)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV57Wplistaparticipantesds_6_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wplistaparticipantesds_6_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wplistaparticipantesds_7_tfpuestodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` like @lV58Wplistaparticipantesds_7_tfpuestodescripcion)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ! ( StringUtil.StrCmp(AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` = @AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.`PuestoDescripcion` IS NULL or (LENGTH(TRIM(T2.`PuestoDescripcion`))=0))");
         }
         if ( AV60Wplistaparticipantesds_9_tfusuariogenero_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV60Wplistaparticipantesds_9_tfusuariogenero_sels, "T1.`UsuarioGenero` IN (", ")")+")");
         }
         if ( ! (0==AV61Wplistaparticipantesds_10_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV61Wplistaparticipantesds_10_tfusuariocelular)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV62Wplistaparticipantesds_11_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV62Wplistaparticipantesds_11_tfusuariocelular_to)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wplistaparticipantesds_12_tfusuariosucursal)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` like @lV63Wplistaparticipantesds_12_tfusuariosucursal)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ! ( StringUtil.StrCmp(AV64Wplistaparticipantesds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` = @AV64Wplistaparticipantesds_13_tfusuariosucursal_sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Wplistaparticipantesds_13_tfusuariosucursal_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
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
                     return conditional_P00382(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 1 :
                     return conditional_P00383(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 2 :
                     return conditional_P00384(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 3 :
                     return conditional_P00385(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
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
          Object[] prmP00382;
          prmP00382 = new Object[] {
          new ParDef("@lV53Wplistaparticipantesds_2_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV56Wplistaparticipantesds_5_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV57Wplistaparticipantesds_6_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@lV58Wplistaparticipantesds_7_tfpuestodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV61Wplistaparticipantesds_10_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV62Wplistaparticipantesds_11_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV63Wplistaparticipantesds_12_tfusuariosucursal",GXType.Char,20,0) ,
          new ParDef("@AV64Wplistaparticipantesds_13_tfusuariosucursal_sel",GXType.Char,20,0)
          };
          Object[] prmP00383;
          prmP00383 = new Object[] {
          new ParDef("@lV53Wplistaparticipantesds_2_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV56Wplistaparticipantesds_5_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV57Wplistaparticipantesds_6_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@lV58Wplistaparticipantesds_7_tfpuestodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV61Wplistaparticipantesds_10_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV62Wplistaparticipantesds_11_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV63Wplistaparticipantesds_12_tfusuariosucursal",GXType.Char,20,0) ,
          new ParDef("@AV64Wplistaparticipantesds_13_tfusuariosucursal_sel",GXType.Char,20,0)
          };
          Object[] prmP00384;
          prmP00384 = new Object[] {
          new ParDef("@lV53Wplistaparticipantesds_2_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV56Wplistaparticipantesds_5_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV57Wplistaparticipantesds_6_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@lV58Wplistaparticipantesds_7_tfpuestodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV61Wplistaparticipantesds_10_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV62Wplistaparticipantesds_11_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV63Wplistaparticipantesds_12_tfusuariosucursal",GXType.Char,20,0) ,
          new ParDef("@AV64Wplistaparticipantesds_13_tfusuariosucursal_sel",GXType.Char,20,0)
          };
          Object[] prmP00385;
          prmP00385 = new Object[] {
          new ParDef("@lV53Wplistaparticipantesds_2_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV54Wplistaparticipantesds_3_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV56Wplistaparticipantesds_5_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV57Wplistaparticipantesds_6_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@lV58Wplistaparticipantesds_7_tfpuestodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV59Wplistaparticipantesds_8_tfpuestodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV61Wplistaparticipantesds_10_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV62Wplistaparticipantesds_11_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV63Wplistaparticipantesds_12_tfusuariosucursal",GXType.Char,20,0) ,
          new ParDef("@AV64Wplistaparticipantesds_13_tfusuariosucursal_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00382", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00382,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00383", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00383,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00384", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00384,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00385", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00385,100, GxCacheFrequency.OFF ,true,false )
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
