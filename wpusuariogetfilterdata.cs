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
   public class wpusuariogetfilterdata : GXProcedure
   {
      public wpusuariogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpusuariogetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_USUARIONOMBRECOMPLETO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIONOMBRECOMPLETOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_USUARIOCORREO") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIOCORREOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_ESTADODESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADESTADODESCRIPCIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_USUARIONOCUENTABROXEL") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUARIONOCUENTABROXELOPTIONS' */
            S151 ();
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
         if ( StringUtil.StrCmp(AV31Session.Get("WPUsuarioGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPUsuarioGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("WPUsuarioGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV42FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOID") == 0 )
            {
               AV10TFUsuarioID = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFUsuarioID_To = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV45TFUsuarioNombreCompleto = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV46TFUsuarioNombreCompleto_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO") == 0 )
            {
               AV14TFUsuarioCorreo = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO_SEL") == 0 )
            {
               AV15TFUsuarioCorreo_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOCELULAR") == 0 )
            {
               AV47TFUsuarioCelular = (long)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFUsuarioCelular_To = (long)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTADODESCRIPCION") == 0 )
            {
               AV49TFEstadoDescripcion = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTADODESCRIPCION_SEL") == 0 )
            {
               AV50TFEstadoDescripcion_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOPRODUCTO_SEL") == 0 )
            {
               AV51TFUsuarioProducto_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV52TFUsuarioProducto_Sels.FromJSonString(AV51TFUsuarioProducto_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIONOCUENTABROXEL") == 0 )
            {
               AV53TFUsuarioNoCuentaBROXEL = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIONOCUENTABROXEL_SEL") == 0 )
            {
               AV54TFUsuarioNoCuentaBROXEL_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOROL_SEL") == 0 )
            {
               AV43TFUsuarioRol_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV44TFUsuarioRol_Sels.FromJSonString(AV43TFUsuarioRol_SelsJson, null);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADUSUARIONOMBRECOMPLETOOPTIONS' Routine */
         returnInSub = false;
         AV45TFUsuarioNombreCompleto = AV20SearchTxt;
         AV46TFUsuarioNombreCompleto_Sel = "";
         AV57Wpusuariods_1_filterfulltext = AV42FilterFullText;
         AV58Wpusuariods_2_tfusuarioid = AV10TFUsuarioID;
         AV59Wpusuariods_3_tfusuarioid_to = AV11TFUsuarioID_To;
         AV60Wpusuariods_4_tfusuarionombrecompleto = AV45TFUsuarioNombreCompleto;
         AV61Wpusuariods_5_tfusuarionombrecompleto_sel = AV46TFUsuarioNombreCompleto_Sel;
         AV62Wpusuariods_6_tfusuariocorreo = AV14TFUsuarioCorreo;
         AV63Wpusuariods_7_tfusuariocorreo_sel = AV15TFUsuarioCorreo_Sel;
         AV64Wpusuariods_8_tfusuariocelular = AV47TFUsuarioCelular;
         AV65Wpusuariods_9_tfusuariocelular_to = AV48TFUsuarioCelular_To;
         AV66Wpusuariods_10_tfestadodescripcion = AV49TFEstadoDescripcion;
         AV67Wpusuariods_11_tfestadodescripcion_sel = AV50TFEstadoDescripcion_Sel;
         AV68Wpusuariods_12_tfusuarioproducto_sels = AV52TFUsuarioProducto_Sels;
         AV69Wpusuariods_13_tfusuarionocuentabroxel = AV53TFUsuarioNoCuentaBROXEL;
         AV70Wpusuariods_14_tfusuarionocuentabroxel_sel = AV54TFUsuarioNoCuentaBROXEL_Sel;
         AV71Wpusuariods_15_tfusuariorol_sels = AV44TFUsuarioRol_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A67UsuarioProducto ,
                                              AV68Wpusuariods_12_tfusuarioproducto_sels ,
                                              A40UsuarioRol ,
                                              AV71Wpusuariods_15_tfusuariorol_sels ,
                                              AV58Wpusuariods_2_tfusuarioid ,
                                              AV59Wpusuariods_3_tfusuarioid_to ,
                                              AV61Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                              AV60Wpusuariods_4_tfusuarionombrecompleto ,
                                              AV63Wpusuariods_7_tfusuariocorreo_sel ,
                                              AV62Wpusuariods_6_tfusuariocorreo ,
                                              AV64Wpusuariods_8_tfusuariocelular ,
                                              AV65Wpusuariods_9_tfusuariocelular_to ,
                                              AV67Wpusuariods_11_tfestadodescripcion_sel ,
                                              AV66Wpusuariods_10_tfestadodescripcion ,
                                              AV68Wpusuariods_12_tfusuarioproducto_sels.Count ,
                                              AV70Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                              AV69Wpusuariods_13_tfusuarionocuentabroxel ,
                                              AV71Wpusuariods_15_tfusuariorol_sels.Count ,
                                              A29UsuarioID ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A64UsuarioCelular ,
                                              A2EstadoDescripcion ,
                                              A82UsuarioNoCuentaBROXEL ,
                                              AV57Wpusuariods_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV60Wpusuariods_4_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV60Wpusuariods_4_tfusuarionombrecompleto), "%", "");
         lV62Wpusuariods_6_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV62Wpusuariods_6_tfusuariocorreo), "%", "");
         lV66Wpusuariods_10_tfestadodescripcion = StringUtil.Concat( StringUtil.RTrim( AV66Wpusuariods_10_tfestadodescripcion), "%", "");
         lV69Wpusuariods_13_tfusuarionocuentabroxel = StringUtil.PadR( StringUtil.RTrim( AV69Wpusuariods_13_tfusuarionocuentabroxel), 20, "%");
         /* Using cursor P00262 */
         pr_default.execute(0, new Object[] {AV58Wpusuariods_2_tfusuarioid, AV59Wpusuariods_3_tfusuarioid_to, lV60Wpusuariods_4_tfusuarionombrecompleto, AV61Wpusuariods_5_tfusuarionombrecompleto_sel, lV62Wpusuariods_6_tfusuariocorreo, AV63Wpusuariods_7_tfusuariocorreo_sel, AV64Wpusuariods_8_tfusuariocelular, AV65Wpusuariods_9_tfusuariocelular_to, lV66Wpusuariods_10_tfestadodescripcion, AV67Wpusuariods_11_tfestadodescripcion_sel, lV69Wpusuariods_13_tfusuarionocuentabroxel, AV70Wpusuariods_14_tfusuarionocuentabroxel_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4CiudadID = P00262_A4CiudadID[0];
            n4CiudadID = P00262_n4CiudadID[0];
            A1EstadoID = P00262_A1EstadoID[0];
            A64UsuarioCelular = P00262_A64UsuarioCelular[0];
            A29UsuarioID = P00262_A29UsuarioID[0];
            A40UsuarioRol = P00262_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = P00262_A82UsuarioNoCuentaBROXEL[0];
            A67UsuarioProducto = P00262_A67UsuarioProducto[0];
            n67UsuarioProducto = P00262_n67UsuarioProducto[0];
            A2EstadoDescripcion = P00262_A2EstadoDescripcion[0];
            A31UsuarioCorreo = P00262_A31UsuarioCorreo[0];
            A52UsuarioNombreCompleto = P00262_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00262_A30UsuarioNombre[0];
            A51UsuarioApellido = P00262_A51UsuarioApellido[0];
            A1EstadoID = P00262_A1EstadoID[0];
            A2EstadoDescripcion = P00262_A2EstadoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpusuariods_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A29UsuarioID), 9, 0) , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A2EstadoDescripcion , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "auto y camioneta", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Auto y Camioneta", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "auto y camioneta/camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Auto y Camioneta/Camión", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Camión", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "empleado", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Empleado", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "otr/camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "OTR/Camión", "")) == 0 ) ) || ( StringUtil.Like( A82UsuarioNoCuentaBROXEL , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) )
            )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A52UsuarioNombreCompleto)) ? "<#Empty#>" : A52UsuarioNombreCompleto);
               AV24InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV25Option, "<#Empty#>") != 0 ) && ( AV24InsertIndex <= AV26Options.Count ) && ( ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), AV25Option) < 0 ) || ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV24InsertIndex = (int)(AV24InsertIndex+1);
               }
               if ( ( AV24InsertIndex <= AV26Options.Count ) && ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), AV25Option) == 0 ) )
               {
                  AV30count = (long)(Math.Round(NumberUtil.Val( ((string)AV29OptionIndexes.Item(AV24InsertIndex)), "."), 18, MidpointRounding.ToEven));
                  AV30count = (long)(AV30count+1);
                  AV29OptionIndexes.RemoveItem(AV24InsertIndex);
                  AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), AV24InsertIndex);
               }
               else
               {
                  AV26Options.Add(AV25Option, AV24InsertIndex);
                  AV29OptionIndexes.Add("1", AV24InsertIndex);
               }
               if ( AV26Options.Count == AV21SkipItems + 11 )
               {
                  AV26Options.RemoveItem(AV26Options.Count);
                  AV29OptionIndexes.RemoveItem(AV29OptionIndexes.Count);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         while ( AV21SkipItems > 0 )
         {
            AV26Options.RemoveItem(1);
            AV29OptionIndexes.RemoveItem(1);
            AV21SkipItems = (short)(AV21SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADUSUARIOCORREOOPTIONS' Routine */
         returnInSub = false;
         AV14TFUsuarioCorreo = AV20SearchTxt;
         AV15TFUsuarioCorreo_Sel = "";
         AV57Wpusuariods_1_filterfulltext = AV42FilterFullText;
         AV58Wpusuariods_2_tfusuarioid = AV10TFUsuarioID;
         AV59Wpusuariods_3_tfusuarioid_to = AV11TFUsuarioID_To;
         AV60Wpusuariods_4_tfusuarionombrecompleto = AV45TFUsuarioNombreCompleto;
         AV61Wpusuariods_5_tfusuarionombrecompleto_sel = AV46TFUsuarioNombreCompleto_Sel;
         AV62Wpusuariods_6_tfusuariocorreo = AV14TFUsuarioCorreo;
         AV63Wpusuariods_7_tfusuariocorreo_sel = AV15TFUsuarioCorreo_Sel;
         AV64Wpusuariods_8_tfusuariocelular = AV47TFUsuarioCelular;
         AV65Wpusuariods_9_tfusuariocelular_to = AV48TFUsuarioCelular_To;
         AV66Wpusuariods_10_tfestadodescripcion = AV49TFEstadoDescripcion;
         AV67Wpusuariods_11_tfestadodescripcion_sel = AV50TFEstadoDescripcion_Sel;
         AV68Wpusuariods_12_tfusuarioproducto_sels = AV52TFUsuarioProducto_Sels;
         AV69Wpusuariods_13_tfusuarionocuentabroxel = AV53TFUsuarioNoCuentaBROXEL;
         AV70Wpusuariods_14_tfusuarionocuentabroxel_sel = AV54TFUsuarioNoCuentaBROXEL_Sel;
         AV71Wpusuariods_15_tfusuariorol_sels = AV44TFUsuarioRol_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A67UsuarioProducto ,
                                              AV68Wpusuariods_12_tfusuarioproducto_sels ,
                                              A40UsuarioRol ,
                                              AV71Wpusuariods_15_tfusuariorol_sels ,
                                              AV58Wpusuariods_2_tfusuarioid ,
                                              AV59Wpusuariods_3_tfusuarioid_to ,
                                              AV61Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                              AV60Wpusuariods_4_tfusuarionombrecompleto ,
                                              AV63Wpusuariods_7_tfusuariocorreo_sel ,
                                              AV62Wpusuariods_6_tfusuariocorreo ,
                                              AV64Wpusuariods_8_tfusuariocelular ,
                                              AV65Wpusuariods_9_tfusuariocelular_to ,
                                              AV67Wpusuariods_11_tfestadodescripcion_sel ,
                                              AV66Wpusuariods_10_tfestadodescripcion ,
                                              AV68Wpusuariods_12_tfusuarioproducto_sels.Count ,
                                              AV70Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                              AV69Wpusuariods_13_tfusuarionocuentabroxel ,
                                              AV71Wpusuariods_15_tfusuariorol_sels.Count ,
                                              A29UsuarioID ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A64UsuarioCelular ,
                                              A2EstadoDescripcion ,
                                              A82UsuarioNoCuentaBROXEL ,
                                              AV57Wpusuariods_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV60Wpusuariods_4_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV60Wpusuariods_4_tfusuarionombrecompleto), "%", "");
         lV62Wpusuariods_6_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV62Wpusuariods_6_tfusuariocorreo), "%", "");
         lV66Wpusuariods_10_tfestadodescripcion = StringUtil.Concat( StringUtil.RTrim( AV66Wpusuariods_10_tfestadodescripcion), "%", "");
         lV69Wpusuariods_13_tfusuarionocuentabroxel = StringUtil.PadR( StringUtil.RTrim( AV69Wpusuariods_13_tfusuarionocuentabroxel), 20, "%");
         /* Using cursor P00263 */
         pr_default.execute(1, new Object[] {AV58Wpusuariods_2_tfusuarioid, AV59Wpusuariods_3_tfusuarioid_to, lV60Wpusuariods_4_tfusuarionombrecompleto, AV61Wpusuariods_5_tfusuarionombrecompleto_sel, lV62Wpusuariods_6_tfusuariocorreo, AV63Wpusuariods_7_tfusuariocorreo_sel, AV64Wpusuariods_8_tfusuariocelular, AV65Wpusuariods_9_tfusuariocelular_to, lV66Wpusuariods_10_tfestadodescripcion, AV67Wpusuariods_11_tfestadodescripcion_sel, lV69Wpusuariods_13_tfusuarionocuentabroxel, AV70Wpusuariods_14_tfusuarionocuentabroxel_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK263 = false;
            A4CiudadID = P00263_A4CiudadID[0];
            n4CiudadID = P00263_n4CiudadID[0];
            A1EstadoID = P00263_A1EstadoID[0];
            A31UsuarioCorreo = P00263_A31UsuarioCorreo[0];
            A64UsuarioCelular = P00263_A64UsuarioCelular[0];
            A29UsuarioID = P00263_A29UsuarioID[0];
            A40UsuarioRol = P00263_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = P00263_A82UsuarioNoCuentaBROXEL[0];
            A67UsuarioProducto = P00263_A67UsuarioProducto[0];
            n67UsuarioProducto = P00263_n67UsuarioProducto[0];
            A2EstadoDescripcion = P00263_A2EstadoDescripcion[0];
            A52UsuarioNombreCompleto = P00263_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00263_A30UsuarioNombre[0];
            A51UsuarioApellido = P00263_A51UsuarioApellido[0];
            A1EstadoID = P00263_A1EstadoID[0];
            A2EstadoDescripcion = P00263_A2EstadoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpusuariods_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A29UsuarioID), 9, 0) , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A2EstadoDescripcion , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "auto y camioneta", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Auto y Camioneta", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "auto y camioneta/camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Auto y Camioneta/Camión", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Camión", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "empleado", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Empleado", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "otr/camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "OTR/Camión", "")) == 0 ) ) || ( StringUtil.Like( A82UsuarioNoCuentaBROXEL , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) )
            )
            {
               AV30count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00263_A31UsuarioCorreo[0], A31UsuarioCorreo) == 0 ) )
               {
                  BRK263 = false;
                  A29UsuarioID = P00263_A29UsuarioID[0];
                  AV30count = (long)(AV30count+1);
                  BRK263 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV21SkipItems) )
               {
                  AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A31UsuarioCorreo)) ? "<#Empty#>" : A31UsuarioCorreo);
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
            }
            if ( ! BRK263 )
            {
               BRK263 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADESTADODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV49TFEstadoDescripcion = AV20SearchTxt;
         AV50TFEstadoDescripcion_Sel = "";
         AV57Wpusuariods_1_filterfulltext = AV42FilterFullText;
         AV58Wpusuariods_2_tfusuarioid = AV10TFUsuarioID;
         AV59Wpusuariods_3_tfusuarioid_to = AV11TFUsuarioID_To;
         AV60Wpusuariods_4_tfusuarionombrecompleto = AV45TFUsuarioNombreCompleto;
         AV61Wpusuariods_5_tfusuarionombrecompleto_sel = AV46TFUsuarioNombreCompleto_Sel;
         AV62Wpusuariods_6_tfusuariocorreo = AV14TFUsuarioCorreo;
         AV63Wpusuariods_7_tfusuariocorreo_sel = AV15TFUsuarioCorreo_Sel;
         AV64Wpusuariods_8_tfusuariocelular = AV47TFUsuarioCelular;
         AV65Wpusuariods_9_tfusuariocelular_to = AV48TFUsuarioCelular_To;
         AV66Wpusuariods_10_tfestadodescripcion = AV49TFEstadoDescripcion;
         AV67Wpusuariods_11_tfestadodescripcion_sel = AV50TFEstadoDescripcion_Sel;
         AV68Wpusuariods_12_tfusuarioproducto_sels = AV52TFUsuarioProducto_Sels;
         AV69Wpusuariods_13_tfusuarionocuentabroxel = AV53TFUsuarioNoCuentaBROXEL;
         AV70Wpusuariods_14_tfusuarionocuentabroxel_sel = AV54TFUsuarioNoCuentaBROXEL_Sel;
         AV71Wpusuariods_15_tfusuariorol_sels = AV44TFUsuarioRol_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A67UsuarioProducto ,
                                              AV68Wpusuariods_12_tfusuarioproducto_sels ,
                                              A40UsuarioRol ,
                                              AV71Wpusuariods_15_tfusuariorol_sels ,
                                              AV58Wpusuariods_2_tfusuarioid ,
                                              AV59Wpusuariods_3_tfusuarioid_to ,
                                              AV61Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                              AV60Wpusuariods_4_tfusuarionombrecompleto ,
                                              AV63Wpusuariods_7_tfusuariocorreo_sel ,
                                              AV62Wpusuariods_6_tfusuariocorreo ,
                                              AV64Wpusuariods_8_tfusuariocelular ,
                                              AV65Wpusuariods_9_tfusuariocelular_to ,
                                              AV67Wpusuariods_11_tfestadodescripcion_sel ,
                                              AV66Wpusuariods_10_tfestadodescripcion ,
                                              AV68Wpusuariods_12_tfusuarioproducto_sels.Count ,
                                              AV70Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                              AV69Wpusuariods_13_tfusuarionocuentabroxel ,
                                              AV71Wpusuariods_15_tfusuariorol_sels.Count ,
                                              A29UsuarioID ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A64UsuarioCelular ,
                                              A2EstadoDescripcion ,
                                              A82UsuarioNoCuentaBROXEL ,
                                              AV57Wpusuariods_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV60Wpusuariods_4_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV60Wpusuariods_4_tfusuarionombrecompleto), "%", "");
         lV62Wpusuariods_6_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV62Wpusuariods_6_tfusuariocorreo), "%", "");
         lV66Wpusuariods_10_tfestadodescripcion = StringUtil.Concat( StringUtil.RTrim( AV66Wpusuariods_10_tfestadodescripcion), "%", "");
         lV69Wpusuariods_13_tfusuarionocuentabroxel = StringUtil.PadR( StringUtil.RTrim( AV69Wpusuariods_13_tfusuarionocuentabroxel), 20, "%");
         /* Using cursor P00264 */
         pr_default.execute(2, new Object[] {AV58Wpusuariods_2_tfusuarioid, AV59Wpusuariods_3_tfusuarioid_to, lV60Wpusuariods_4_tfusuarionombrecompleto, AV61Wpusuariods_5_tfusuarionombrecompleto_sel, lV62Wpusuariods_6_tfusuariocorreo, AV63Wpusuariods_7_tfusuariocorreo_sel, AV64Wpusuariods_8_tfusuariocelular, AV65Wpusuariods_9_tfusuariocelular_to, lV66Wpusuariods_10_tfestadodescripcion, AV67Wpusuariods_11_tfestadodescripcion_sel, lV69Wpusuariods_13_tfusuarionocuentabroxel, AV70Wpusuariods_14_tfusuarionocuentabroxel_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK265 = false;
            A4CiudadID = P00264_A4CiudadID[0];
            n4CiudadID = P00264_n4CiudadID[0];
            A1EstadoID = P00264_A1EstadoID[0];
            A2EstadoDescripcion = P00264_A2EstadoDescripcion[0];
            A64UsuarioCelular = P00264_A64UsuarioCelular[0];
            A29UsuarioID = P00264_A29UsuarioID[0];
            A40UsuarioRol = P00264_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = P00264_A82UsuarioNoCuentaBROXEL[0];
            A67UsuarioProducto = P00264_A67UsuarioProducto[0];
            n67UsuarioProducto = P00264_n67UsuarioProducto[0];
            A31UsuarioCorreo = P00264_A31UsuarioCorreo[0];
            A52UsuarioNombreCompleto = P00264_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00264_A30UsuarioNombre[0];
            A51UsuarioApellido = P00264_A51UsuarioApellido[0];
            A1EstadoID = P00264_A1EstadoID[0];
            A2EstadoDescripcion = P00264_A2EstadoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpusuariods_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A29UsuarioID), 9, 0) , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A2EstadoDescripcion , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "auto y camioneta", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Auto y Camioneta", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "auto y camioneta/camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Auto y Camioneta/Camión", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Camión", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "empleado", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Empleado", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "otr/camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "OTR/Camión", "")) == 0 ) ) || ( StringUtil.Like( A82UsuarioNoCuentaBROXEL , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) )
            )
            {
               AV30count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00264_A2EstadoDescripcion[0], A2EstadoDescripcion) == 0 ) )
               {
                  BRK265 = false;
                  A4CiudadID = P00264_A4CiudadID[0];
                  n4CiudadID = P00264_n4CiudadID[0];
                  A1EstadoID = P00264_A1EstadoID[0];
                  A29UsuarioID = P00264_A29UsuarioID[0];
                  A1EstadoID = P00264_A1EstadoID[0];
                  AV30count = (long)(AV30count+1);
                  BRK265 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV21SkipItems) )
               {
                  AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A2EstadoDescripcion)) ? "<#Empty#>" : A2EstadoDescripcion);
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
            }
            if ( ! BRK265 )
            {
               BRK265 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADUSUARIONOCUENTABROXELOPTIONS' Routine */
         returnInSub = false;
         AV53TFUsuarioNoCuentaBROXEL = AV20SearchTxt;
         AV54TFUsuarioNoCuentaBROXEL_Sel = "";
         AV57Wpusuariods_1_filterfulltext = AV42FilterFullText;
         AV58Wpusuariods_2_tfusuarioid = AV10TFUsuarioID;
         AV59Wpusuariods_3_tfusuarioid_to = AV11TFUsuarioID_To;
         AV60Wpusuariods_4_tfusuarionombrecompleto = AV45TFUsuarioNombreCompleto;
         AV61Wpusuariods_5_tfusuarionombrecompleto_sel = AV46TFUsuarioNombreCompleto_Sel;
         AV62Wpusuariods_6_tfusuariocorreo = AV14TFUsuarioCorreo;
         AV63Wpusuariods_7_tfusuariocorreo_sel = AV15TFUsuarioCorreo_Sel;
         AV64Wpusuariods_8_tfusuariocelular = AV47TFUsuarioCelular;
         AV65Wpusuariods_9_tfusuariocelular_to = AV48TFUsuarioCelular_To;
         AV66Wpusuariods_10_tfestadodescripcion = AV49TFEstadoDescripcion;
         AV67Wpusuariods_11_tfestadodescripcion_sel = AV50TFEstadoDescripcion_Sel;
         AV68Wpusuariods_12_tfusuarioproducto_sels = AV52TFUsuarioProducto_Sels;
         AV69Wpusuariods_13_tfusuarionocuentabroxel = AV53TFUsuarioNoCuentaBROXEL;
         AV70Wpusuariods_14_tfusuarionocuentabroxel_sel = AV54TFUsuarioNoCuentaBROXEL_Sel;
         AV71Wpusuariods_15_tfusuariorol_sels = AV44TFUsuarioRol_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A67UsuarioProducto ,
                                              AV68Wpusuariods_12_tfusuarioproducto_sels ,
                                              A40UsuarioRol ,
                                              AV71Wpusuariods_15_tfusuariorol_sels ,
                                              AV58Wpusuariods_2_tfusuarioid ,
                                              AV59Wpusuariods_3_tfusuarioid_to ,
                                              AV61Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                              AV60Wpusuariods_4_tfusuarionombrecompleto ,
                                              AV63Wpusuariods_7_tfusuariocorreo_sel ,
                                              AV62Wpusuariods_6_tfusuariocorreo ,
                                              AV64Wpusuariods_8_tfusuariocelular ,
                                              AV65Wpusuariods_9_tfusuariocelular_to ,
                                              AV67Wpusuariods_11_tfestadodescripcion_sel ,
                                              AV66Wpusuariods_10_tfestadodescripcion ,
                                              AV68Wpusuariods_12_tfusuarioproducto_sels.Count ,
                                              AV70Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                              AV69Wpusuariods_13_tfusuarionocuentabroxel ,
                                              AV71Wpusuariods_15_tfusuariorol_sels.Count ,
                                              A29UsuarioID ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A64UsuarioCelular ,
                                              A2EstadoDescripcion ,
                                              A82UsuarioNoCuentaBROXEL ,
                                              AV57Wpusuariods_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV60Wpusuariods_4_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV60Wpusuariods_4_tfusuarionombrecompleto), "%", "");
         lV62Wpusuariods_6_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV62Wpusuariods_6_tfusuariocorreo), "%", "");
         lV66Wpusuariods_10_tfestadodescripcion = StringUtil.Concat( StringUtil.RTrim( AV66Wpusuariods_10_tfestadodescripcion), "%", "");
         lV69Wpusuariods_13_tfusuarionocuentabroxel = StringUtil.PadR( StringUtil.RTrim( AV69Wpusuariods_13_tfusuarionocuentabroxel), 20, "%");
         /* Using cursor P00265 */
         pr_default.execute(3, new Object[] {AV58Wpusuariods_2_tfusuarioid, AV59Wpusuariods_3_tfusuarioid_to, lV60Wpusuariods_4_tfusuarionombrecompleto, AV61Wpusuariods_5_tfusuarionombrecompleto_sel, lV62Wpusuariods_6_tfusuariocorreo, AV63Wpusuariods_7_tfusuariocorreo_sel, AV64Wpusuariods_8_tfusuariocelular, AV65Wpusuariods_9_tfusuariocelular_to, lV66Wpusuariods_10_tfestadodescripcion, AV67Wpusuariods_11_tfestadodescripcion_sel, lV69Wpusuariods_13_tfusuarionocuentabroxel, AV70Wpusuariods_14_tfusuarionocuentabroxel_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK267 = false;
            A4CiudadID = P00265_A4CiudadID[0];
            n4CiudadID = P00265_n4CiudadID[0];
            A1EstadoID = P00265_A1EstadoID[0];
            A82UsuarioNoCuentaBROXEL = P00265_A82UsuarioNoCuentaBROXEL[0];
            A64UsuarioCelular = P00265_A64UsuarioCelular[0];
            A29UsuarioID = P00265_A29UsuarioID[0];
            A40UsuarioRol = P00265_A40UsuarioRol[0];
            A67UsuarioProducto = P00265_A67UsuarioProducto[0];
            n67UsuarioProducto = P00265_n67UsuarioProducto[0];
            A2EstadoDescripcion = P00265_A2EstadoDescripcion[0];
            A31UsuarioCorreo = P00265_A31UsuarioCorreo[0];
            A52UsuarioNombreCompleto = P00265_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = P00265_A30UsuarioNombre[0];
            A51UsuarioApellido = P00265_A51UsuarioApellido[0];
            A1EstadoID = P00265_A1EstadoID[0];
            A2EstadoDescripcion = P00265_A2EstadoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpusuariods_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A29UsuarioID), 9, 0) , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A2EstadoDescripcion , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "auto y camioneta", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Auto y Camioneta", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "auto y camioneta/camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Auto y Camioneta/Camión", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Camión", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "empleado", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "Empleado", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "otr/camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, context.GetMessage( "OTR/Camión", "")) == 0 ) ) || ( StringUtil.Like( A82UsuarioNoCuentaBROXEL , StringUtil.PadR( "%" + AV57Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "gx_emptyitemtext", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "super administrador", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Super Administrador", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "administrador yokohama", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Administrador Yokohama", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "asesor", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Asesor", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "participante", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, context.GetMessage( "Participante", "")) == 0 ) ) )
            )
            {
               AV30count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00265_A82UsuarioNoCuentaBROXEL[0], A82UsuarioNoCuentaBROXEL) == 0 ) )
               {
                  BRK267 = false;
                  A29UsuarioID = P00265_A29UsuarioID[0];
                  AV30count = (long)(AV30count+1);
                  BRK267 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV21SkipItems) )
               {
                  AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A82UsuarioNoCuentaBROXEL)) ? "<#Empty#>" : A82UsuarioNoCuentaBROXEL);
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
            }
            if ( ! BRK267 )
            {
               BRK267 = true;
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
         AV42FilterFullText = "";
         AV45TFUsuarioNombreCompleto = "";
         AV46TFUsuarioNombreCompleto_Sel = "";
         AV14TFUsuarioCorreo = "";
         AV15TFUsuarioCorreo_Sel = "";
         AV49TFEstadoDescripcion = "";
         AV50TFEstadoDescripcion_Sel = "";
         AV51TFUsuarioProducto_SelsJson = "";
         AV52TFUsuarioProducto_Sels = new GxSimpleCollection<string>();
         AV53TFUsuarioNoCuentaBROXEL = "";
         AV54TFUsuarioNoCuentaBROXEL_Sel = "";
         AV43TFUsuarioRol_SelsJson = "";
         AV44TFUsuarioRol_Sels = new GxSimpleCollection<string>();
         AV57Wpusuariods_1_filterfulltext = "";
         AV60Wpusuariods_4_tfusuarionombrecompleto = "";
         AV61Wpusuariods_5_tfusuarionombrecompleto_sel = "";
         AV62Wpusuariods_6_tfusuariocorreo = "";
         AV63Wpusuariods_7_tfusuariocorreo_sel = "";
         AV66Wpusuariods_10_tfestadodescripcion = "";
         AV67Wpusuariods_11_tfestadodescripcion_sel = "";
         AV68Wpusuariods_12_tfusuarioproducto_sels = new GxSimpleCollection<string>();
         AV69Wpusuariods_13_tfusuarionocuentabroxel = "";
         AV70Wpusuariods_14_tfusuarionocuentabroxel_sel = "";
         AV71Wpusuariods_15_tfusuariorol_sels = new GxSimpleCollection<string>();
         lV60Wpusuariods_4_tfusuarionombrecompleto = "";
         lV62Wpusuariods_6_tfusuariocorreo = "";
         lV66Wpusuariods_10_tfestadodescripcion = "";
         lV69Wpusuariods_13_tfusuarionocuentabroxel = "";
         A67UsuarioProducto = "";
         A40UsuarioRol = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A31UsuarioCorreo = "";
         A2EstadoDescripcion = "";
         A82UsuarioNoCuentaBROXEL = "";
         A52UsuarioNombreCompleto = "";
         P00262_A4CiudadID = new int[1] ;
         P00262_n4CiudadID = new bool[] {false} ;
         P00262_A1EstadoID = new int[1] ;
         P00262_A64UsuarioCelular = new long[1] ;
         P00262_A29UsuarioID = new int[1] ;
         P00262_A40UsuarioRol = new string[] {""} ;
         P00262_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         P00262_A67UsuarioProducto = new string[] {""} ;
         P00262_n67UsuarioProducto = new bool[] {false} ;
         P00262_A2EstadoDescripcion = new string[] {""} ;
         P00262_A31UsuarioCorreo = new string[] {""} ;
         P00262_A52UsuarioNombreCompleto = new string[] {""} ;
         P00262_A30UsuarioNombre = new string[] {""} ;
         P00262_A51UsuarioApellido = new string[] {""} ;
         AV25Option = "";
         P00263_A4CiudadID = new int[1] ;
         P00263_n4CiudadID = new bool[] {false} ;
         P00263_A1EstadoID = new int[1] ;
         P00263_A31UsuarioCorreo = new string[] {""} ;
         P00263_A64UsuarioCelular = new long[1] ;
         P00263_A29UsuarioID = new int[1] ;
         P00263_A40UsuarioRol = new string[] {""} ;
         P00263_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         P00263_A67UsuarioProducto = new string[] {""} ;
         P00263_n67UsuarioProducto = new bool[] {false} ;
         P00263_A2EstadoDescripcion = new string[] {""} ;
         P00263_A52UsuarioNombreCompleto = new string[] {""} ;
         P00263_A30UsuarioNombre = new string[] {""} ;
         P00263_A51UsuarioApellido = new string[] {""} ;
         P00264_A4CiudadID = new int[1] ;
         P00264_n4CiudadID = new bool[] {false} ;
         P00264_A1EstadoID = new int[1] ;
         P00264_A2EstadoDescripcion = new string[] {""} ;
         P00264_A64UsuarioCelular = new long[1] ;
         P00264_A29UsuarioID = new int[1] ;
         P00264_A40UsuarioRol = new string[] {""} ;
         P00264_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         P00264_A67UsuarioProducto = new string[] {""} ;
         P00264_n67UsuarioProducto = new bool[] {false} ;
         P00264_A31UsuarioCorreo = new string[] {""} ;
         P00264_A52UsuarioNombreCompleto = new string[] {""} ;
         P00264_A30UsuarioNombre = new string[] {""} ;
         P00264_A51UsuarioApellido = new string[] {""} ;
         P00265_A4CiudadID = new int[1] ;
         P00265_n4CiudadID = new bool[] {false} ;
         P00265_A1EstadoID = new int[1] ;
         P00265_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         P00265_A64UsuarioCelular = new long[1] ;
         P00265_A29UsuarioID = new int[1] ;
         P00265_A40UsuarioRol = new string[] {""} ;
         P00265_A67UsuarioProducto = new string[] {""} ;
         P00265_n67UsuarioProducto = new bool[] {false} ;
         P00265_A2EstadoDescripcion = new string[] {""} ;
         P00265_A31UsuarioCorreo = new string[] {""} ;
         P00265_A52UsuarioNombreCompleto = new string[] {""} ;
         P00265_A30UsuarioNombre = new string[] {""} ;
         P00265_A51UsuarioApellido = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpusuariogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00262_A4CiudadID, P00262_n4CiudadID, P00262_A1EstadoID, P00262_A64UsuarioCelular, P00262_A29UsuarioID, P00262_A40UsuarioRol, P00262_A82UsuarioNoCuentaBROXEL, P00262_A67UsuarioProducto, P00262_n67UsuarioProducto, P00262_A2EstadoDescripcion,
               P00262_A31UsuarioCorreo, P00262_A52UsuarioNombreCompleto, P00262_A30UsuarioNombre, P00262_A51UsuarioApellido
               }
               , new Object[] {
               P00263_A4CiudadID, P00263_n4CiudadID, P00263_A1EstadoID, P00263_A31UsuarioCorreo, P00263_A64UsuarioCelular, P00263_A29UsuarioID, P00263_A40UsuarioRol, P00263_A82UsuarioNoCuentaBROXEL, P00263_A67UsuarioProducto, P00263_n67UsuarioProducto,
               P00263_A2EstadoDescripcion, P00263_A52UsuarioNombreCompleto, P00263_A30UsuarioNombre, P00263_A51UsuarioApellido
               }
               , new Object[] {
               P00264_A4CiudadID, P00264_n4CiudadID, P00264_A1EstadoID, P00264_A2EstadoDescripcion, P00264_A64UsuarioCelular, P00264_A29UsuarioID, P00264_A40UsuarioRol, P00264_A82UsuarioNoCuentaBROXEL, P00264_A67UsuarioProducto, P00264_n67UsuarioProducto,
               P00264_A31UsuarioCorreo, P00264_A52UsuarioNombreCompleto, P00264_A30UsuarioNombre, P00264_A51UsuarioApellido
               }
               , new Object[] {
               P00265_A4CiudadID, P00265_n4CiudadID, P00265_A1EstadoID, P00265_A82UsuarioNoCuentaBROXEL, P00265_A64UsuarioCelular, P00265_A29UsuarioID, P00265_A40UsuarioRol, P00265_A67UsuarioProducto, P00265_n67UsuarioProducto, P00265_A2EstadoDescripcion,
               P00265_A31UsuarioCorreo, P00265_A52UsuarioNombreCompleto, P00265_A30UsuarioNombre, P00265_A51UsuarioApellido
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23MaxItems ;
      private short AV22PageIndex ;
      private short AV21SkipItems ;
      private int AV55GXV1 ;
      private int AV10TFUsuarioID ;
      private int AV11TFUsuarioID_To ;
      private int AV58Wpusuariods_2_tfusuarioid ;
      private int AV59Wpusuariods_3_tfusuarioid_to ;
      private int AV68Wpusuariods_12_tfusuarioproducto_sels_Count ;
      private int AV71Wpusuariods_15_tfusuariorol_sels_Count ;
      private int A29UsuarioID ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int AV24InsertIndex ;
      private long AV47TFUsuarioCelular ;
      private long AV48TFUsuarioCelular_To ;
      private long AV64Wpusuariods_8_tfusuariocelular ;
      private long AV65Wpusuariods_9_tfusuariocelular_to ;
      private long A64UsuarioCelular ;
      private long AV30count ;
      private string AV53TFUsuarioNoCuentaBROXEL ;
      private string AV54TFUsuarioNoCuentaBROXEL_Sel ;
      private string AV69Wpusuariods_13_tfusuarionocuentabroxel ;
      private string AV70Wpusuariods_14_tfusuarionocuentabroxel_sel ;
      private string lV69Wpusuariods_13_tfusuarionocuentabroxel ;
      private string A40UsuarioRol ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string A82UsuarioNoCuentaBROXEL ;
      private bool returnInSub ;
      private bool n4CiudadID ;
      private bool n67UsuarioProducto ;
      private bool BRK263 ;
      private bool BRK265 ;
      private bool BRK267 ;
      private string AV39OptionsJson ;
      private string AV40OptionsDescJson ;
      private string AV41OptionIndexesJson ;
      private string AV51TFUsuarioProducto_SelsJson ;
      private string AV43TFUsuarioRol_SelsJson ;
      private string AV36DDOName ;
      private string AV37SearchTxtParms ;
      private string AV38SearchTxtTo ;
      private string AV20SearchTxt ;
      private string AV42FilterFullText ;
      private string AV45TFUsuarioNombreCompleto ;
      private string AV46TFUsuarioNombreCompleto_Sel ;
      private string AV14TFUsuarioCorreo ;
      private string AV15TFUsuarioCorreo_Sel ;
      private string AV49TFEstadoDescripcion ;
      private string AV50TFEstadoDescripcion_Sel ;
      private string AV57Wpusuariods_1_filterfulltext ;
      private string AV60Wpusuariods_4_tfusuarionombrecompleto ;
      private string AV61Wpusuariods_5_tfusuarionombrecompleto_sel ;
      private string AV62Wpusuariods_6_tfusuariocorreo ;
      private string AV63Wpusuariods_7_tfusuariocorreo_sel ;
      private string AV66Wpusuariods_10_tfestadodescripcion ;
      private string AV67Wpusuariods_11_tfestadodescripcion_sel ;
      private string lV60Wpusuariods_4_tfusuarionombrecompleto ;
      private string lV62Wpusuariods_6_tfusuariocorreo ;
      private string lV66Wpusuariods_10_tfestadodescripcion ;
      private string A67UsuarioProducto ;
      private string A31UsuarioCorreo ;
      private string A2EstadoDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV25Option ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV26Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV29OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV33GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GxSimpleCollection<string> AV52TFUsuarioProducto_Sels ;
      private GxSimpleCollection<string> AV44TFUsuarioRol_Sels ;
      private GxSimpleCollection<string> AV68Wpusuariods_12_tfusuarioproducto_sels ;
      private GxSimpleCollection<string> AV71Wpusuariods_15_tfusuariorol_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00262_A4CiudadID ;
      private bool[] P00262_n4CiudadID ;
      private int[] P00262_A1EstadoID ;
      private long[] P00262_A64UsuarioCelular ;
      private int[] P00262_A29UsuarioID ;
      private string[] P00262_A40UsuarioRol ;
      private string[] P00262_A82UsuarioNoCuentaBROXEL ;
      private string[] P00262_A67UsuarioProducto ;
      private bool[] P00262_n67UsuarioProducto ;
      private string[] P00262_A2EstadoDescripcion ;
      private string[] P00262_A31UsuarioCorreo ;
      private string[] P00262_A52UsuarioNombreCompleto ;
      private string[] P00262_A30UsuarioNombre ;
      private string[] P00262_A51UsuarioApellido ;
      private int[] P00263_A4CiudadID ;
      private bool[] P00263_n4CiudadID ;
      private int[] P00263_A1EstadoID ;
      private string[] P00263_A31UsuarioCorreo ;
      private long[] P00263_A64UsuarioCelular ;
      private int[] P00263_A29UsuarioID ;
      private string[] P00263_A40UsuarioRol ;
      private string[] P00263_A82UsuarioNoCuentaBROXEL ;
      private string[] P00263_A67UsuarioProducto ;
      private bool[] P00263_n67UsuarioProducto ;
      private string[] P00263_A2EstadoDescripcion ;
      private string[] P00263_A52UsuarioNombreCompleto ;
      private string[] P00263_A30UsuarioNombre ;
      private string[] P00263_A51UsuarioApellido ;
      private int[] P00264_A4CiudadID ;
      private bool[] P00264_n4CiudadID ;
      private int[] P00264_A1EstadoID ;
      private string[] P00264_A2EstadoDescripcion ;
      private long[] P00264_A64UsuarioCelular ;
      private int[] P00264_A29UsuarioID ;
      private string[] P00264_A40UsuarioRol ;
      private string[] P00264_A82UsuarioNoCuentaBROXEL ;
      private string[] P00264_A67UsuarioProducto ;
      private bool[] P00264_n67UsuarioProducto ;
      private string[] P00264_A31UsuarioCorreo ;
      private string[] P00264_A52UsuarioNombreCompleto ;
      private string[] P00264_A30UsuarioNombre ;
      private string[] P00264_A51UsuarioApellido ;
      private int[] P00265_A4CiudadID ;
      private bool[] P00265_n4CiudadID ;
      private int[] P00265_A1EstadoID ;
      private string[] P00265_A82UsuarioNoCuentaBROXEL ;
      private long[] P00265_A64UsuarioCelular ;
      private int[] P00265_A29UsuarioID ;
      private string[] P00265_A40UsuarioRol ;
      private string[] P00265_A67UsuarioProducto ;
      private bool[] P00265_n67UsuarioProducto ;
      private string[] P00265_A2EstadoDescripcion ;
      private string[] P00265_A31UsuarioCorreo ;
      private string[] P00265_A52UsuarioNombreCompleto ;
      private string[] P00265_A30UsuarioNombre ;
      private string[] P00265_A51UsuarioApellido ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpusuariogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00262( IGxContext context ,
                                             string A67UsuarioProducto ,
                                             GxSimpleCollection<string> AV68Wpusuariods_12_tfusuarioproducto_sels ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV71Wpusuariods_15_tfusuariorol_sels ,
                                             int AV58Wpusuariods_2_tfusuarioid ,
                                             int AV59Wpusuariods_3_tfusuarioid_to ,
                                             string AV61Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                             string AV60Wpusuariods_4_tfusuarionombrecompleto ,
                                             string AV63Wpusuariods_7_tfusuariocorreo_sel ,
                                             string AV62Wpusuariods_6_tfusuariocorreo ,
                                             long AV64Wpusuariods_8_tfusuariocelular ,
                                             long AV65Wpusuariods_9_tfusuariocelular_to ,
                                             string AV67Wpusuariods_11_tfestadodescripcion_sel ,
                                             string AV66Wpusuariods_10_tfestadodescripcion ,
                                             int AV68Wpusuariods_12_tfusuarioproducto_sels_Count ,
                                             string AV70Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                             string AV69Wpusuariods_13_tfusuarionocuentabroxel ,
                                             int AV71Wpusuariods_15_tfusuariorol_sels_Count ,
                                             int A29UsuarioID ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             long A64UsuarioCelular ,
                                             string A2EstadoDescripcion ,
                                             string A82UsuarioNoCuentaBROXEL ,
                                             string AV57Wpusuariods_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`CiudadID`, T2.`EstadoID`, T1.`UsuarioCelular`, T1.`UsuarioID`, T1.`UsuarioRol`, T1.`UsuarioNoCuentaBROXEL`, T1.`UsuarioProducto`, T3.`EstadoDescripcion`, T1.`UsuarioCorreo`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM ((`Usuario` T1 LEFT JOIN `Ciudad` T2 ON T2.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T3 ON T3.`EstadoID` = T2.`EstadoID`)";
         if ( ! (0==AV58Wpusuariods_2_tfusuarioid) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` >= @AV58Wpusuariods_2_tfusuarioid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV59Wpusuariods_3_tfusuarioid_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` <= @AV59Wpusuariods_3_tfusuarioid_to)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpusuariods_5_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wpusuariods_4_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV60Wpusuariods_4_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpusuariods_5_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV61Wpusuariods_5_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV61Wpusuariods_5_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wpusuariods_5_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpusuariods_7_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wpusuariods_6_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV62Wpusuariods_6_tfusuariocorreo)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpusuariods_7_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV63Wpusuariods_7_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV63Wpusuariods_7_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wpusuariods_7_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( ! (0==AV64Wpusuariods_8_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV64Wpusuariods_8_tfusuariocelular)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV65Wpusuariods_9_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV65Wpusuariods_9_tfusuariocelular_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpusuariods_11_tfestadodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpusuariods_10_tfestadodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` like @lV66Wpusuariods_10_tfestadodescripcion)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpusuariods_11_tfestadodescripcion_sel)) && ! ( StringUtil.StrCmp(AV67Wpusuariods_11_tfestadodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` = @AV67Wpusuariods_11_tfestadodescripcion_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpusuariods_11_tfestadodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`EstadoDescripcion`))=0))");
         }
         if ( AV68Wpusuariods_12_tfusuarioproducto_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Wpusuariods_12_tfusuarioproducto_sels, "T1.`UsuarioProducto` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpusuariods_13_tfusuarionocuentabroxel)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` like @lV69Wpusuariods_13_tfusuarionocuentabroxel)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ! ( StringUtil.StrCmp(AV70Wpusuariods_14_tfusuarionocuentabroxel_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` = @AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wpusuariods_14_tfusuarionocuentabroxel_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioNoCuentaBROXEL`))=0))");
         }
         if ( AV71Wpusuariods_15_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Wpusuariods_15_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00263( IGxContext context ,
                                             string A67UsuarioProducto ,
                                             GxSimpleCollection<string> AV68Wpusuariods_12_tfusuarioproducto_sels ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV71Wpusuariods_15_tfusuariorol_sels ,
                                             int AV58Wpusuariods_2_tfusuarioid ,
                                             int AV59Wpusuariods_3_tfusuarioid_to ,
                                             string AV61Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                             string AV60Wpusuariods_4_tfusuarionombrecompleto ,
                                             string AV63Wpusuariods_7_tfusuariocorreo_sel ,
                                             string AV62Wpusuariods_6_tfusuariocorreo ,
                                             long AV64Wpusuariods_8_tfusuariocelular ,
                                             long AV65Wpusuariods_9_tfusuariocelular_to ,
                                             string AV67Wpusuariods_11_tfestadodescripcion_sel ,
                                             string AV66Wpusuariods_10_tfestadodescripcion ,
                                             int AV68Wpusuariods_12_tfusuarioproducto_sels_Count ,
                                             string AV70Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                             string AV69Wpusuariods_13_tfusuarionocuentabroxel ,
                                             int AV71Wpusuariods_15_tfusuariorol_sels_Count ,
                                             int A29UsuarioID ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             long A64UsuarioCelular ,
                                             string A2EstadoDescripcion ,
                                             string A82UsuarioNoCuentaBROXEL ,
                                             string AV57Wpusuariods_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`CiudadID`, T2.`EstadoID`, T1.`UsuarioCorreo`, T1.`UsuarioCelular`, T1.`UsuarioID`, T1.`UsuarioRol`, T1.`UsuarioNoCuentaBROXEL`, T1.`UsuarioProducto`, T3.`EstadoDescripcion`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM ((`Usuario` T1 LEFT JOIN `Ciudad` T2 ON T2.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T3 ON T3.`EstadoID` = T2.`EstadoID`)";
         if ( ! (0==AV58Wpusuariods_2_tfusuarioid) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` >= @AV58Wpusuariods_2_tfusuarioid)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV59Wpusuariods_3_tfusuarioid_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` <= @AV59Wpusuariods_3_tfusuarioid_to)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpusuariods_5_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wpusuariods_4_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV60Wpusuariods_4_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpusuariods_5_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV61Wpusuariods_5_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV61Wpusuariods_5_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wpusuariods_5_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpusuariods_7_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wpusuariods_6_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV62Wpusuariods_6_tfusuariocorreo)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpusuariods_7_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV63Wpusuariods_7_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV63Wpusuariods_7_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wpusuariods_7_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( ! (0==AV64Wpusuariods_8_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV64Wpusuariods_8_tfusuariocelular)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV65Wpusuariods_9_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV65Wpusuariods_9_tfusuariocelular_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpusuariods_11_tfestadodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpusuariods_10_tfestadodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` like @lV66Wpusuariods_10_tfestadodescripcion)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpusuariods_11_tfestadodescripcion_sel)) && ! ( StringUtil.StrCmp(AV67Wpusuariods_11_tfestadodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` = @AV67Wpusuariods_11_tfestadodescripcion_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpusuariods_11_tfestadodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`EstadoDescripcion`))=0))");
         }
         if ( AV68Wpusuariods_12_tfusuarioproducto_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Wpusuariods_12_tfusuarioproducto_sels, "T1.`UsuarioProducto` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpusuariods_13_tfusuarionocuentabroxel)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` like @lV69Wpusuariods_13_tfusuarionocuentabroxel)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ! ( StringUtil.StrCmp(AV70Wpusuariods_14_tfusuarionocuentabroxel_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` = @AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wpusuariods_14_tfusuarionocuentabroxel_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioNoCuentaBROXEL`))=0))");
         }
         if ( AV71Wpusuariods_15_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Wpusuariods_15_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioCorreo`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00264( IGxContext context ,
                                             string A67UsuarioProducto ,
                                             GxSimpleCollection<string> AV68Wpusuariods_12_tfusuarioproducto_sels ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV71Wpusuariods_15_tfusuariorol_sels ,
                                             int AV58Wpusuariods_2_tfusuarioid ,
                                             int AV59Wpusuariods_3_tfusuarioid_to ,
                                             string AV61Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                             string AV60Wpusuariods_4_tfusuarionombrecompleto ,
                                             string AV63Wpusuariods_7_tfusuariocorreo_sel ,
                                             string AV62Wpusuariods_6_tfusuariocorreo ,
                                             long AV64Wpusuariods_8_tfusuariocelular ,
                                             long AV65Wpusuariods_9_tfusuariocelular_to ,
                                             string AV67Wpusuariods_11_tfestadodescripcion_sel ,
                                             string AV66Wpusuariods_10_tfestadodescripcion ,
                                             int AV68Wpusuariods_12_tfusuarioproducto_sels_Count ,
                                             string AV70Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                             string AV69Wpusuariods_13_tfusuarionocuentabroxel ,
                                             int AV71Wpusuariods_15_tfusuariorol_sels_Count ,
                                             int A29UsuarioID ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             long A64UsuarioCelular ,
                                             string A2EstadoDescripcion ,
                                             string A82UsuarioNoCuentaBROXEL ,
                                             string AV57Wpusuariods_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`CiudadID`, T2.`EstadoID`, T3.`EstadoDescripcion`, T1.`UsuarioCelular`, T1.`UsuarioID`, T1.`UsuarioRol`, T1.`UsuarioNoCuentaBROXEL`, T1.`UsuarioProducto`, T1.`UsuarioCorreo`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM ((`Usuario` T1 LEFT JOIN `Ciudad` T2 ON T2.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T3 ON T3.`EstadoID` = T2.`EstadoID`)";
         if ( ! (0==AV58Wpusuariods_2_tfusuarioid) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` >= @AV58Wpusuariods_2_tfusuarioid)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (0==AV59Wpusuariods_3_tfusuarioid_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` <= @AV59Wpusuariods_3_tfusuarioid_to)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpusuariods_5_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wpusuariods_4_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV60Wpusuariods_4_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpusuariods_5_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV61Wpusuariods_5_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV61Wpusuariods_5_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wpusuariods_5_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpusuariods_7_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wpusuariods_6_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV62Wpusuariods_6_tfusuariocorreo)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpusuariods_7_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV63Wpusuariods_7_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV63Wpusuariods_7_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wpusuariods_7_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( ! (0==AV64Wpusuariods_8_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV64Wpusuariods_8_tfusuariocelular)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV65Wpusuariods_9_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV65Wpusuariods_9_tfusuariocelular_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpusuariods_11_tfestadodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpusuariods_10_tfestadodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` like @lV66Wpusuariods_10_tfestadodescripcion)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpusuariods_11_tfestadodescripcion_sel)) && ! ( StringUtil.StrCmp(AV67Wpusuariods_11_tfestadodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` = @AV67Wpusuariods_11_tfestadodescripcion_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpusuariods_11_tfestadodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`EstadoDescripcion`))=0))");
         }
         if ( AV68Wpusuariods_12_tfusuarioproducto_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Wpusuariods_12_tfusuarioproducto_sels, "T1.`UsuarioProducto` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpusuariods_13_tfusuarionocuentabroxel)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` like @lV69Wpusuariods_13_tfusuarionocuentabroxel)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ! ( StringUtil.StrCmp(AV70Wpusuariods_14_tfusuarionocuentabroxel_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` = @AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wpusuariods_14_tfusuarionocuentabroxel_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioNoCuentaBROXEL`))=0))");
         }
         if ( AV71Wpusuariods_15_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Wpusuariods_15_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.`EstadoDescripcion`";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00265( IGxContext context ,
                                             string A67UsuarioProducto ,
                                             GxSimpleCollection<string> AV68Wpusuariods_12_tfusuarioproducto_sels ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV71Wpusuariods_15_tfusuariorol_sels ,
                                             int AV58Wpusuariods_2_tfusuarioid ,
                                             int AV59Wpusuariods_3_tfusuarioid_to ,
                                             string AV61Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                             string AV60Wpusuariods_4_tfusuarionombrecompleto ,
                                             string AV63Wpusuariods_7_tfusuariocorreo_sel ,
                                             string AV62Wpusuariods_6_tfusuariocorreo ,
                                             long AV64Wpusuariods_8_tfusuariocelular ,
                                             long AV65Wpusuariods_9_tfusuariocelular_to ,
                                             string AV67Wpusuariods_11_tfestadodescripcion_sel ,
                                             string AV66Wpusuariods_10_tfestadodescripcion ,
                                             int AV68Wpusuariods_12_tfusuarioproducto_sels_Count ,
                                             string AV70Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                             string AV69Wpusuariods_13_tfusuarionocuentabroxel ,
                                             int AV71Wpusuariods_15_tfusuariorol_sels_Count ,
                                             int A29UsuarioID ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             long A64UsuarioCelular ,
                                             string A2EstadoDescripcion ,
                                             string A82UsuarioNoCuentaBROXEL ,
                                             string AV57Wpusuariods_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.`CiudadID`, T2.`EstadoID`, T1.`UsuarioNoCuentaBROXEL`, T1.`UsuarioCelular`, T1.`UsuarioID`, T1.`UsuarioRol`, T1.`UsuarioProducto`, T3.`EstadoDescripcion`, T1.`UsuarioCorreo`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM ((`Usuario` T1 LEFT JOIN `Ciudad` T2 ON T2.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T3 ON T3.`EstadoID` = T2.`EstadoID`)";
         if ( ! (0==AV58Wpusuariods_2_tfusuarioid) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` >= @AV58Wpusuariods_2_tfusuarioid)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (0==AV59Wpusuariods_3_tfusuarioid_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` <= @AV59Wpusuariods_3_tfusuarioid_to)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpusuariods_5_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wpusuariods_4_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV60Wpusuariods_4_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpusuariods_5_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV61Wpusuariods_5_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV61Wpusuariods_5_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wpusuariods_5_tfusuarionombrecompleto_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpusuariods_7_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wpusuariods_6_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV62Wpusuariods_6_tfusuariocorreo)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpusuariods_7_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV63Wpusuariods_7_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV63Wpusuariods_7_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wpusuariods_7_tfusuariocorreo_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( ! (0==AV64Wpusuariods_8_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV64Wpusuariods_8_tfusuariocelular)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV65Wpusuariods_9_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV65Wpusuariods_9_tfusuariocelular_to)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpusuariods_11_tfestadodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpusuariods_10_tfestadodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` like @lV66Wpusuariods_10_tfestadodescripcion)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpusuariods_11_tfestadodescripcion_sel)) && ! ( StringUtil.StrCmp(AV67Wpusuariods_11_tfestadodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` = @AV67Wpusuariods_11_tfestadodescripcion_sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wpusuariods_11_tfestadodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`EstadoDescripcion`))=0))");
         }
         if ( AV68Wpusuariods_12_tfusuarioproducto_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Wpusuariods_12_tfusuarioproducto_sels, "T1.`UsuarioProducto` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpusuariods_13_tfusuarionocuentabroxel)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` like @lV69Wpusuariods_13_tfusuarionocuentabroxel)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ! ( StringUtil.StrCmp(AV70Wpusuariods_14_tfusuarionocuentabroxel_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` = @AV70Wpusuariods_14_tfusuarionocuentabroxel_sel)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Wpusuariods_14_tfusuarionocuentabroxel_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioNoCuentaBROXEL`))=0))");
         }
         if ( AV71Wpusuariods_15_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Wpusuariods_15_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioNoCuentaBROXEL`";
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
                     return conditional_P00262(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 1 :
                     return conditional_P00263(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 2 :
                     return conditional_P00264(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 3 :
                     return conditional_P00265(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
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
          Object[] prmP00262;
          prmP00262 = new Object[] {
          new ParDef("@AV58Wpusuariods_2_tfusuarioid",GXType.Int32,9,0) ,
          new ParDef("@AV59Wpusuariods_3_tfusuarioid_to",GXType.Int32,9,0) ,
          new ParDef("@lV60Wpusuariods_4_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV61Wpusuariods_5_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV62Wpusuariods_6_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV63Wpusuariods_7_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@AV64Wpusuariods_8_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV65Wpusuariods_9_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV66Wpusuariods_10_tfestadodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV67Wpusuariods_11_tfestadodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV69Wpusuariods_13_tfusuarionocuentabroxel",GXType.Char,20,0) ,
          new ParDef("@AV70Wpusuariods_14_tfusuarionocuentabroxel_sel",GXType.Char,20,0)
          };
          Object[] prmP00263;
          prmP00263 = new Object[] {
          new ParDef("@AV58Wpusuariods_2_tfusuarioid",GXType.Int32,9,0) ,
          new ParDef("@AV59Wpusuariods_3_tfusuarioid_to",GXType.Int32,9,0) ,
          new ParDef("@lV60Wpusuariods_4_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV61Wpusuariods_5_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV62Wpusuariods_6_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV63Wpusuariods_7_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@AV64Wpusuariods_8_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV65Wpusuariods_9_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV66Wpusuariods_10_tfestadodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV67Wpusuariods_11_tfestadodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV69Wpusuariods_13_tfusuarionocuentabroxel",GXType.Char,20,0) ,
          new ParDef("@AV70Wpusuariods_14_tfusuarionocuentabroxel_sel",GXType.Char,20,0)
          };
          Object[] prmP00264;
          prmP00264 = new Object[] {
          new ParDef("@AV58Wpusuariods_2_tfusuarioid",GXType.Int32,9,0) ,
          new ParDef("@AV59Wpusuariods_3_tfusuarioid_to",GXType.Int32,9,0) ,
          new ParDef("@lV60Wpusuariods_4_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV61Wpusuariods_5_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV62Wpusuariods_6_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV63Wpusuariods_7_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@AV64Wpusuariods_8_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV65Wpusuariods_9_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV66Wpusuariods_10_tfestadodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV67Wpusuariods_11_tfestadodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV69Wpusuariods_13_tfusuarionocuentabroxel",GXType.Char,20,0) ,
          new ParDef("@AV70Wpusuariods_14_tfusuarionocuentabroxel_sel",GXType.Char,20,0)
          };
          Object[] prmP00265;
          prmP00265 = new Object[] {
          new ParDef("@AV58Wpusuariods_2_tfusuarioid",GXType.Int32,9,0) ,
          new ParDef("@AV59Wpusuariods_3_tfusuarioid_to",GXType.Int32,9,0) ,
          new ParDef("@lV60Wpusuariods_4_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV61Wpusuariods_5_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV62Wpusuariods_6_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV63Wpusuariods_7_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@AV64Wpusuariods_8_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV65Wpusuariods_9_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV66Wpusuariods_10_tfestadodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV67Wpusuariods_11_tfestadodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV69Wpusuariods_13_tfusuarionocuentabroxel",GXType.Char,20,0) ,
          new ParDef("@AV70Wpusuariods_14_tfusuarionocuentabroxel_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00262", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00262,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00263", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00263,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00264", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00264,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00265", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00265,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 40);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 50);
                ((string[]) buf[13])[0] = rslt.getString(12, 50);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 40);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 50);
                ((string[]) buf[13])[0] = rslt.getString(12, 50);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 40);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 50);
                ((string[]) buf[13])[0] = rslt.getString(12, 50);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 40);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 50);
                ((string[]) buf[13])[0] = rslt.getString(12, 50);
                return;
       }
    }

 }

}
