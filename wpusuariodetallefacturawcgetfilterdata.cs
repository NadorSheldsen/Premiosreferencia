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
   public class wpusuariodetallefacturawcgetfilterdata : GXProcedure
   {
      public wpusuariodetallefacturawcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpusuariodetallefacturawcgetfilterdata( IGxContext context )
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
         this.AV48DDOName = aP0_DDOName;
         this.AV49SearchTxtParms = aP1_SearchTxtParms;
         this.AV50SearchTxtTo = aP2_SearchTxtTo;
         this.AV51OptionsJson = "" ;
         this.AV52OptionsDescJson = "" ;
         this.AV53OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV51OptionsJson;
         aP4_OptionsDescJson=this.AV52OptionsDescJson;
         aP5_OptionIndexesJson=this.AV53OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV53OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV48DDOName = aP0_DDOName;
         this.AV49SearchTxtParms = aP1_SearchTxtParms;
         this.AV50SearchTxtTo = aP2_SearchTxtTo;
         this.AV51OptionsJson = "" ;
         this.AV52OptionsDescJson = "" ;
         this.AV53OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV51OptionsJson;
         aP4_OptionsDescJson=this.AV52OptionsDescJson;
         aP5_OptionIndexesJson=this.AV53OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV38Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35MaxItems = 10;
         AV34PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV49SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV49SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV32SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV49SearchTxtParms)) ? "" : StringUtil.Substring( AV49SearchTxtParms, 3, -1));
         AV33SkipItems = (short)(AV34PageIndex*AV35MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV48DDOName), "DDO_PROMOCIONDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV48DDOName), "DDO_FACTURANO") == 0 )
         {
            /* Execute user subroutine: 'LOADFACTURANOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV51OptionsJson = AV38Options.ToJSonString(false);
         AV52OptionsDescJson = AV40OptionsDesc.ToJSonString(false);
         AV53OptionIndexesJson = AV41OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV43Session.Get("WPUsuarioDetalleFacturaWCGridState"), "") == 0 )
         {
            AV45GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPUsuarioDetalleFacturaWCGridState"), null, "", "");
         }
         else
         {
            AV45GridState.FromXml(AV43Session.Get("WPUsuarioDetalleFacturaWCGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV45GridState.gxTpr_Filtervalues.Count )
         {
            AV46GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV45GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV54FilterFullText = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFFACTURAID") == 0 )
            {
               AV10TFFacturaID = (int)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFFacturaID_To = (int)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV12TFFacturaFechaRegistro = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV13TFFacturaFechaRegistro_To = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV14TFPromocionDescripcion = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV15TFPromocionDescripcion_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFFACTURANO") == 0 )
            {
               AV16TFFacturaNo = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFFACTURANO_SEL") == 0 )
            {
               AV17TFFacturaNo_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV18TFFacturaFechaFactura = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV19TFFacturaFechaFactura_To = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "PARM_&USUARIOID") == 0 )
            {
               AV55UsuarioID = (int)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROMOCIONDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFPromocionDescripcion = AV32SearchTxt;
         AV15TFPromocionDescripcion_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54FilterFullText ,
                                              AV10TFFacturaID ,
                                              AV11TFFacturaID_To ,
                                              AV12TFFacturaFechaRegistro ,
                                              AV13TFFacturaFechaRegistro_To ,
                                              AV15TFPromocionDescripcion_Sel ,
                                              AV14TFPromocionDescripcion ,
                                              AV17TFFacturaNo_Sel ,
                                              AV16TFFacturaNo ,
                                              AV18TFFacturaFechaFactura ,
                                              AV19TFFacturaFechaFactura_To ,
                                              A69FacturaID ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              AV55UsuarioID ,
                                              A29UsuarioID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV14TFPromocionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV14TFPromocionDescripcion), "%", "");
         lV16TFFacturaNo = StringUtil.PadR( StringUtil.RTrim( AV16TFFacturaNo), 20, "%");
         /* Using cursor P00302 */
         pr_default.execute(0, new Object[] {AV55UsuarioID, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, AV10TFFacturaID, AV11TFFacturaID_To, AV12TFFacturaFechaRegistro, AV13TFFacturaFechaRegistro_To, lV14TFPromocionDescripcion, AV15TFPromocionDescripcion_Sel, lV16TFFacturaNo, AV17TFFacturaNo_Sel, AV18TFFacturaFechaFactura, AV19TFFacturaFechaFactura_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK302 = false;
            A29UsuarioID = P00302_A29UsuarioID[0];
            A41PromocionID = P00302_A41PromocionID[0];
            A73FacturaFechaFactura = P00302_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P00302_A72FacturaFechaRegistro[0];
            A71FacturaNo = P00302_A71FacturaNo[0];
            A42PromocionDescripcion = P00302_A42PromocionDescripcion[0];
            A69FacturaID = P00302_A69FacturaID[0];
            A42PromocionDescripcion = P00302_A42PromocionDescripcion[0];
            AV42count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00302_A29UsuarioID[0] == A29UsuarioID ) && ( P00302_A41PromocionID[0] == A41PromocionID ) )
            {
               BRK302 = false;
               A69FacturaID = P00302_A69FacturaID[0];
               AV42count = (long)(AV42count+1);
               BRK302 = true;
               pr_default.readNext(0);
            }
            AV37Option = (String.IsNullOrEmpty(StringUtil.RTrim( A42PromocionDescripcion)) ? "<#Empty#>" : A42PromocionDescripcion);
            AV36InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV37Option, "<#Empty#>") != 0 ) && ( AV36InsertIndex <= AV38Options.Count ) && ( ( StringUtil.StrCmp(((string)AV38Options.Item(AV36InsertIndex)), AV37Option) < 0 ) || ( StringUtil.StrCmp(((string)AV38Options.Item(AV36InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV36InsertIndex = (int)(AV36InsertIndex+1);
            }
            AV38Options.Add(AV37Option, AV36InsertIndex);
            AV41OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), AV36InsertIndex);
            if ( AV38Options.Count == AV33SkipItems + 11 )
            {
               AV38Options.RemoveItem(AV38Options.Count);
               AV41OptionIndexes.RemoveItem(AV41OptionIndexes.Count);
            }
            if ( ! BRK302 )
            {
               BRK302 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV33SkipItems > 0 )
         {
            AV38Options.RemoveItem(1);
            AV41OptionIndexes.RemoveItem(1);
            AV33SkipItems = (short)(AV33SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADFACTURANOOPTIONS' Routine */
         returnInSub = false;
         AV16TFFacturaNo = AV32SearchTxt;
         AV17TFFacturaNo_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54FilterFullText ,
                                              AV10TFFacturaID ,
                                              AV11TFFacturaID_To ,
                                              AV12TFFacturaFechaRegistro ,
                                              AV13TFFacturaFechaRegistro_To ,
                                              AV15TFPromocionDescripcion_Sel ,
                                              AV14TFPromocionDescripcion ,
                                              AV17TFFacturaNo_Sel ,
                                              AV16TFFacturaNo ,
                                              AV18TFFacturaFechaFactura ,
                                              AV19TFFacturaFechaFactura_To ,
                                              A69FacturaID ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              AV55UsuarioID ,
                                              A29UsuarioID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV54FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV54FilterFullText), "%", "");
         lV14TFPromocionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV14TFPromocionDescripcion), "%", "");
         lV16TFFacturaNo = StringUtil.PadR( StringUtil.RTrim( AV16TFFacturaNo), 20, "%");
         /* Using cursor P00303 */
         pr_default.execute(1, new Object[] {AV55UsuarioID, lV54FilterFullText, lV54FilterFullText, lV54FilterFullText, AV10TFFacturaID, AV11TFFacturaID_To, AV12TFFacturaFechaRegistro, AV13TFFacturaFechaRegistro_To, lV14TFPromocionDescripcion, AV15TFPromocionDescripcion_Sel, lV16TFFacturaNo, AV17TFFacturaNo_Sel, AV18TFFacturaFechaFactura, AV19TFFacturaFechaFactura_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK304 = false;
            A41PromocionID = P00303_A41PromocionID[0];
            A29UsuarioID = P00303_A29UsuarioID[0];
            A71FacturaNo = P00303_A71FacturaNo[0];
            A73FacturaFechaFactura = P00303_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P00303_A72FacturaFechaRegistro[0];
            A42PromocionDescripcion = P00303_A42PromocionDescripcion[0];
            A69FacturaID = P00303_A69FacturaID[0];
            A42PromocionDescripcion = P00303_A42PromocionDescripcion[0];
            AV42count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00303_A29UsuarioID[0] == A29UsuarioID ) && ( StringUtil.StrCmp(P00303_A71FacturaNo[0], A71FacturaNo) == 0 ) )
            {
               BRK304 = false;
               A69FacturaID = P00303_A69FacturaID[0];
               AV42count = (long)(AV42count+1);
               BRK304 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV33SkipItems) )
            {
               AV37Option = (String.IsNullOrEmpty(StringUtil.RTrim( A71FacturaNo)) ? "<#Empty#>" : A71FacturaNo);
               AV38Options.Add(AV37Option, 0);
               AV41OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV38Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV33SkipItems = (short)(AV33SkipItems-1);
            }
            if ( ! BRK304 )
            {
               BRK304 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV51OptionsJson = "";
         AV52OptionsDescJson = "";
         AV53OptionIndexesJson = "";
         AV38Options = new GxSimpleCollection<string>();
         AV40OptionsDesc = new GxSimpleCollection<string>();
         AV41OptionIndexes = new GxSimpleCollection<string>();
         AV32SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV43Session = context.GetSession();
         AV45GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV46GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV54FilterFullText = "";
         AV12TFFacturaFechaRegistro = DateTime.MinValue;
         AV13TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV14TFPromocionDescripcion = "";
         AV15TFPromocionDescripcion_Sel = "";
         AV16TFFacturaNo = "";
         AV17TFFacturaNo_Sel = "";
         AV18TFFacturaFechaFactura = DateTime.MinValue;
         AV19TFFacturaFechaFactura_To = DateTime.MinValue;
         lV54FilterFullText = "";
         lV14TFPromocionDescripcion = "";
         lV16TFFacturaNo = "";
         A42PromocionDescripcion = "";
         A71FacturaNo = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A73FacturaFechaFactura = DateTime.MinValue;
         P00302_A29UsuarioID = new int[1] ;
         P00302_A41PromocionID = new int[1] ;
         P00302_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00302_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P00302_A71FacturaNo = new string[] {""} ;
         P00302_A42PromocionDescripcion = new string[] {""} ;
         P00302_A69FacturaID = new int[1] ;
         AV37Option = "";
         P00303_A41PromocionID = new int[1] ;
         P00303_A29UsuarioID = new int[1] ;
         P00303_A71FacturaNo = new string[] {""} ;
         P00303_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00303_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P00303_A42PromocionDescripcion = new string[] {""} ;
         P00303_A69FacturaID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpusuariodetallefacturawcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00302_A29UsuarioID, P00302_A41PromocionID, P00302_A73FacturaFechaFactura, P00302_A72FacturaFechaRegistro, P00302_A71FacturaNo, P00302_A42PromocionDescripcion, P00302_A69FacturaID
               }
               , new Object[] {
               P00303_A41PromocionID, P00303_A29UsuarioID, P00303_A71FacturaNo, P00303_A73FacturaFechaFactura, P00303_A72FacturaFechaRegistro, P00303_A42PromocionDescripcion, P00303_A69FacturaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV35MaxItems ;
      private short AV34PageIndex ;
      private short AV33SkipItems ;
      private int AV56GXV1 ;
      private int AV10TFFacturaID ;
      private int AV11TFFacturaID_To ;
      private int AV55UsuarioID ;
      private int A69FacturaID ;
      private int A29UsuarioID ;
      private int A41PromocionID ;
      private int AV36InsertIndex ;
      private long AV42count ;
      private string AV16TFFacturaNo ;
      private string AV17TFFacturaNo_Sel ;
      private string lV16TFFacturaNo ;
      private string A71FacturaNo ;
      private DateTime AV12TFFacturaFechaRegistro ;
      private DateTime AV13TFFacturaFechaRegistro_To ;
      private DateTime AV18TFFacturaFechaFactura ;
      private DateTime AV19TFFacturaFechaFactura_To ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool returnInSub ;
      private bool BRK302 ;
      private bool BRK304 ;
      private string AV51OptionsJson ;
      private string AV52OptionsDescJson ;
      private string AV53OptionIndexesJson ;
      private string AV48DDOName ;
      private string AV49SearchTxtParms ;
      private string AV50SearchTxtTo ;
      private string AV32SearchTxt ;
      private string AV54FilterFullText ;
      private string AV14TFPromocionDescripcion ;
      private string AV15TFPromocionDescripcion_Sel ;
      private string lV54FilterFullText ;
      private string lV14TFPromocionDescripcion ;
      private string A42PromocionDescripcion ;
      private string AV37Option ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV38Options ;
      private GxSimpleCollection<string> AV40OptionsDesc ;
      private GxSimpleCollection<string> AV41OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV45GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV46GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P00302_A29UsuarioID ;
      private int[] P00302_A41PromocionID ;
      private DateTime[] P00302_A73FacturaFechaFactura ;
      private DateTime[] P00302_A72FacturaFechaRegistro ;
      private string[] P00302_A71FacturaNo ;
      private string[] P00302_A42PromocionDescripcion ;
      private int[] P00302_A69FacturaID ;
      private int[] P00303_A41PromocionID ;
      private int[] P00303_A29UsuarioID ;
      private string[] P00303_A71FacturaNo ;
      private DateTime[] P00303_A73FacturaFechaFactura ;
      private DateTime[] P00303_A72FacturaFechaRegistro ;
      private string[] P00303_A42PromocionDescripcion ;
      private int[] P00303_A69FacturaID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpusuariodetallefacturawcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00302( IGxContext context ,
                                             string AV54FilterFullText ,
                                             int AV10TFFacturaID ,
                                             int AV11TFFacturaID_To ,
                                             DateTime AV12TFFacturaFechaRegistro ,
                                             DateTime AV13TFFacturaFechaRegistro_To ,
                                             string AV15TFPromocionDescripcion_Sel ,
                                             string AV14TFPromocionDescripcion ,
                                             string AV17TFFacturaNo_Sel ,
                                             string AV16TFFacturaNo ,
                                             DateTime AV18TFFacturaFechaFactura ,
                                             DateTime AV19TFFacturaFechaFactura_To ,
                                             int A69FacturaID ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             int AV55UsuarioID ,
                                             int A29UsuarioID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`UsuarioID`, T1.`PromocionID`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T1.`FacturaID` FROM (`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`)";
         AddWhere(sWhereString, "(T1.`UsuarioID` = @AV55UsuarioID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54FilterFullText)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(T1.`FacturaID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV54FilterFullText)) or ( T2.`PromocionDescripcion` like CONCAT('%', @lV54FilterFullText)) or ( T1.`FacturaNo` like CONCAT('%', @lV54FilterFullText)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10TFFacturaID) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` >= @AV10TFFacturaID)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11TFFacturaID_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` <= @AV11TFFacturaID_To)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12TFFacturaFechaRegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV12TFFacturaFechaRegistro)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV13TFFacturaFechaRegistro_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV13TFFacturaFechaRegistro_To)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFFacturaNo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFFacturaNo)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV16TFFacturaNo)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFFacturaNo_Sel)) && ! ( StringUtil.StrCmp(AV17TFFacturaNo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV17TFFacturaNo_Sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV17TFFacturaNo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV18TFFacturaFechaFactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV18TFFacturaFechaFactura)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV19TFFacturaFechaFactura_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV19TFFacturaFechaFactura_To)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioID`, T1.`PromocionID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00303( IGxContext context ,
                                             string AV54FilterFullText ,
                                             int AV10TFFacturaID ,
                                             int AV11TFFacturaID_To ,
                                             DateTime AV12TFFacturaFechaRegistro ,
                                             DateTime AV13TFFacturaFechaRegistro_To ,
                                             string AV15TFPromocionDescripcion_Sel ,
                                             string AV14TFPromocionDescripcion ,
                                             string AV17TFFacturaNo_Sel ,
                                             string AV16TFFacturaNo ,
                                             DateTime AV18TFFacturaFechaFactura ,
                                             DateTime AV19TFFacturaFechaFactura_To ,
                                             int A69FacturaID ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             int AV55UsuarioID ,
                                             int A29UsuarioID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`UsuarioID`, T1.`FacturaNo`, T1.`FacturaFechaFactura`, T1.`FacturaFechaRegistro`, T2.`PromocionDescripcion`, T1.`FacturaID` FROM (`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`)";
         AddWhere(sWhereString, "(T1.`UsuarioID` = @AV55UsuarioID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54FilterFullText)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(T1.`FacturaID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV54FilterFullText)) or ( T2.`PromocionDescripcion` like CONCAT('%', @lV54FilterFullText)) or ( T1.`FacturaNo` like CONCAT('%', @lV54FilterFullText)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10TFFacturaID) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` >= @AV10TFFacturaID)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11TFFacturaID_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` <= @AV11TFFacturaID_To)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12TFFacturaFechaRegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV12TFFacturaFechaRegistro)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV13TFFacturaFechaRegistro_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV13TFFacturaFechaRegistro_To)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFFacturaNo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFFacturaNo)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV16TFFacturaNo)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFFacturaNo_Sel)) && ! ( StringUtil.StrCmp(AV17TFFacturaNo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV17TFFacturaNo_Sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV17TFFacturaNo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV18TFFacturaFechaFactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV18TFFacturaFechaFactura)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV19TFFacturaFechaFactura_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV19TFFacturaFechaFactura_To)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`UsuarioID`, T1.`FacturaNo`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00302(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] );
               case 1 :
                     return conditional_P00303(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00302;
          prmP00302 = new Object[] {
          new ParDef("@AV55UsuarioID",GXType.Int32,9,0) ,
          new ParDef("@lV54FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV54FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV54FilterFullText",GXType.Char,100,0) ,
          new ParDef("@AV10TFFacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV11TFFacturaID_To",GXType.Int32,9,0) ,
          new ParDef("@AV12TFFacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@AV13TFFacturaFechaRegistro_To",GXType.Date,8,0) ,
          new ParDef("@lV14TFPromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@AV15TFPromocionDescripcion_Sel",GXType.Char,80,0) ,
          new ParDef("@lV16TFFacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV17TFFacturaNo_Sel",GXType.Char,20,0) ,
          new ParDef("@AV18TFFacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@AV19TFFacturaFechaFactura_To",GXType.Date,8,0)
          };
          Object[] prmP00303;
          prmP00303 = new Object[] {
          new ParDef("@AV55UsuarioID",GXType.Int32,9,0) ,
          new ParDef("@lV54FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV54FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV54FilterFullText",GXType.Char,100,0) ,
          new ParDef("@AV10TFFacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV11TFFacturaID_To",GXType.Int32,9,0) ,
          new ParDef("@AV12TFFacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@AV13TFFacturaFechaRegistro_To",GXType.Date,8,0) ,
          new ParDef("@lV14TFPromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@AV15TFPromocionDescripcion_Sel",GXType.Char,80,0) ,
          new ParDef("@lV16TFFacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV17TFFacturaNo_Sel",GXType.Char,20,0) ,
          new ParDef("@AV18TFFacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@AV19TFFacturaFechaFactura_To",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00302", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00302,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00303", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00303,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
