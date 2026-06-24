using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class wplistaasesoresasignadosgetfilterdata : GXProcedure
   {
      public wplistaasesoresasignadosgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wplistaasesoresasignadosgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV45OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV30Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27MaxItems = 10;
         AV26PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV41SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV24SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? "" : StringUtil.Substring( AV41SearchTxtParms, 3, -1));
         AV25SkipItems = (short)(AV26PageIndex*AV27MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_USUARIONOMBRECOMPLETO") == 0 )
         {
            AV11TFUsuarioNombreCompleto = AV24SearchTxt;
            AV12TFUsuarioNombreCompleto_Sel = "";
            /* Execute user subroutine: 'LOADUSUARIONOMBRECOMPLETOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_USUARIOCORREO") == 0 )
         {
            AV14TFUsuarioCorreo = AV24SearchTxt;
            AV15TFUsuarioCorreo_Sel = "";
            /* Execute user subroutine: 'LOADUSUARIOCORREOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_USUARIOSUCURSAL") == 0 )
         {
            AV17TFUsuarioSucursal = AV24SearchTxt;
            AV18TFUsuarioSucursal_Sel = "";
            /* Execute user subroutine: 'LOADUSUARIOSUCURSALOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_USUARIOROL") == 0 )
         {
            AV20TFUsuarioRol_Sel = "";
            /* Execute user subroutine: 'LOADUSUARIOROLOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_PUESTODESCRIPCION") == 0 )
         {
            AV22TFPuestoDescripcion = AV24SearchTxt;
            AV23TFPuestoDescripcion_Sel = "";
            /* Execute user subroutine: 'LOADPUESTODESCRIPCIONOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV43OptionsJson = AV30Options.ToJSonString(false);
         AV44OptionsDescJson = AV32OptionsDesc.ToJSonString(false);
         AV45OptionIndexesJson = AV33OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("WPListaAsesoresAsignadosGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPListaAsesoresAsignadosGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("WPListaAsesoresAsignadosGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV46FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV11TFUsuarioNombreCompleto = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV12TFUsuarioNombreCompleto_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO") == 0 )
            {
               AV14TFUsuarioCorreo = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO_SEL") == 0 )
            {
               AV15TFUsuarioCorreo_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUSUARIOSUCURSAL") == 0 )
            {
               AV17TFUsuarioSucursal = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUSUARIOSUCURSAL_SEL") == 0 )
            {
               AV18TFUsuarioSucursal_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUSUARIOROL_SEL") == 0 )
            {
               AV20TFUsuarioRol_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPUESTODESCRIPCION") == 0 )
            {
               AV22TFPuestoDescripcion = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPUESTODESCRIPCION_SEL") == 0 )
            {
               AV23TFPuestoDescripcion_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADUSUARIONOMBRECOMPLETOOPTIONS' Routine */
         returnInSub = false;
         AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( AV10UsuarioNombreCompleto)) ? "<#Empty#>" : AV10UsuarioNombreCompleto);
         AV28InsertIndex = 1;
         while ( ( StringUtil.StrCmp(AV29Option, "<#Empty#>") != 0 ) && ( AV28InsertIndex <= AV30Options.Count ) && ( ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), AV29Option) < 0 ) || ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), "<#Empty#>") == 0 ) ) )
         {
            AV28InsertIndex = (int)(AV28InsertIndex+1);
         }
         if ( ( ( AV28InsertIndex == AV30Options.Count + 1 ) ) || ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), AV29Option) != 0 ) )
         {
            AV30Options.Add(AV29Option, AV28InsertIndex);
         }
      }

      protected void S131( )
      {
         /* 'LOADUSUARIOCORREOOPTIONS' Routine */
         returnInSub = false;
         AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( AV13UsuarioCorreo)) ? "<#Empty#>" : AV13UsuarioCorreo);
         AV28InsertIndex = 1;
         while ( ( StringUtil.StrCmp(AV29Option, "<#Empty#>") != 0 ) && ( AV28InsertIndex <= AV30Options.Count ) && ( ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), AV29Option) < 0 ) || ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), "<#Empty#>") == 0 ) ) )
         {
            AV28InsertIndex = (int)(AV28InsertIndex+1);
         }
         if ( ( ( AV28InsertIndex == AV30Options.Count + 1 ) ) || ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), AV29Option) != 0 ) )
         {
            AV30Options.Add(AV29Option, AV28InsertIndex);
         }
      }

      protected void S141( )
      {
         /* 'LOADUSUARIOSUCURSALOPTIONS' Routine */
         returnInSub = false;
         AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( AV16UsuarioSucursal)) ? "<#Empty#>" : AV16UsuarioSucursal);
         AV28InsertIndex = 1;
         while ( ( StringUtil.StrCmp(AV29Option, "<#Empty#>") != 0 ) && ( AV28InsertIndex <= AV30Options.Count ) && ( ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), AV29Option) < 0 ) || ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), "<#Empty#>") == 0 ) ) )
         {
            AV28InsertIndex = (int)(AV28InsertIndex+1);
         }
         if ( ( ( AV28InsertIndex == AV30Options.Count + 1 ) ) || ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), AV29Option) != 0 ) )
         {
            AV30Options.Add(AV29Option, AV28InsertIndex);
         }
      }

      protected void S151( )
      {
         /* 'LOADUSUARIOROLOPTIONS' Routine */
         returnInSub = false;
         AV29Option = AV19UsuarioRol;
         AV31OptionDesc = StringUtil.Trim( context.GetMessage( gxdomainrol.getDescription(context,AV19UsuarioRol), ""));
         AV28InsertIndex = 1;
         while ( ( StringUtil.StrCmp(AV29Option, "<#Empty#>") != 0 ) && ( AV28InsertIndex <= AV30Options.Count ) && ( ( StringUtil.StrCmp(((string)AV32OptionsDesc.Item(AV28InsertIndex)), AV31OptionDesc) < 0 ) || ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), "<#Empty#>") == 0 ) ) )
         {
            AV28InsertIndex = (int)(AV28InsertIndex+1);
         }
         if ( ( ( AV28InsertIndex == AV30Options.Count + 1 ) ) || ( StringUtil.StrCmp(((string)AV32OptionsDesc.Item(AV28InsertIndex)), AV31OptionDesc) != 0 ) )
         {
            AV30Options.Add(AV29Option, AV28InsertIndex);
            AV32OptionsDesc.Add(AV31OptionDesc, AV28InsertIndex);
         }
      }

      protected void S161( )
      {
         /* 'LOADPUESTODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( AV21PuestoDescripcion)) ? "<#Empty#>" : AV21PuestoDescripcion);
         AV28InsertIndex = 1;
         while ( ( StringUtil.StrCmp(AV29Option, "<#Empty#>") != 0 ) && ( AV28InsertIndex <= AV30Options.Count ) && ( ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), AV29Option) < 0 ) || ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), "<#Empty#>") == 0 ) ) )
         {
            AV28InsertIndex = (int)(AV28InsertIndex+1);
         }
         if ( ( ( AV28InsertIndex == AV30Options.Count + 1 ) ) || ( StringUtil.StrCmp(((string)AV30Options.Item(AV28InsertIndex)), AV29Option) != 0 ) )
         {
            AV30Options.Add(AV29Option, AV28InsertIndex);
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
         AV43OptionsJson = "";
         AV44OptionsDescJson = "";
         AV45OptionIndexesJson = "";
         AV30Options = new GxSimpleCollection<string>();
         AV32OptionsDesc = new GxSimpleCollection<string>();
         AV33OptionIndexes = new GxSimpleCollection<string>();
         AV24SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TFUsuarioNombreCompleto = "";
         AV12TFUsuarioNombreCompleto_Sel = "";
         AV14TFUsuarioCorreo = "";
         AV15TFUsuarioCorreo_Sel = "";
         AV17TFUsuarioSucursal = "";
         AV18TFUsuarioSucursal_Sel = "";
         AV20TFUsuarioRol_Sel = "";
         AV22TFPuestoDescripcion = "";
         AV23TFPuestoDescripcion_Sel = "";
         AV35Session = context.GetSession();
         AV37GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV38GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV46FilterFullText = "";
         AV29Option = "";
         AV10UsuarioNombreCompleto = "";
         AV13UsuarioCorreo = "";
         AV16UsuarioSucursal = "";
         AV19UsuarioRol = "";
         AV31OptionDesc = "";
         AV21PuestoDescripcion = "";
         /* GeneXus formulas. */
      }

      private short AV27MaxItems ;
      private short AV26PageIndex ;
      private short AV25SkipItems ;
      private int AV47GXV1 ;
      private int AV28InsertIndex ;
      private string AV17TFUsuarioSucursal ;
      private string AV18TFUsuarioSucursal_Sel ;
      private string AV20TFUsuarioRol_Sel ;
      private string AV16UsuarioSucursal ;
      private string AV19UsuarioRol ;
      private bool returnInSub ;
      private string AV43OptionsJson ;
      private string AV44OptionsDescJson ;
      private string AV45OptionIndexesJson ;
      private string AV40DDOName ;
      private string AV41SearchTxtParms ;
      private string AV42SearchTxtTo ;
      private string AV24SearchTxt ;
      private string AV11TFUsuarioNombreCompleto ;
      private string AV12TFUsuarioNombreCompleto_Sel ;
      private string AV14TFUsuarioCorreo ;
      private string AV15TFUsuarioCorreo_Sel ;
      private string AV22TFPuestoDescripcion ;
      private string AV23TFPuestoDescripcion_Sel ;
      private string AV46FilterFullText ;
      private string AV29Option ;
      private string AV10UsuarioNombreCompleto ;
      private string AV13UsuarioCorreo ;
      private string AV31OptionDesc ;
      private string AV21PuestoDescripcion ;
      private IGxSession AV35Session ;
      private GxSimpleCollection<string> AV30Options ;
      private GxSimpleCollection<string> AV32OptionsDesc ;
      private GxSimpleCollection<string> AV33OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV37GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

}
