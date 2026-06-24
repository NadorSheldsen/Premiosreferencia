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
   public class calculartotalbonopormesestatusfiltradonew : GXProcedure
   {
      public calculartotalbonopormesestatusfiltradonew( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public calculartotalbonopormesestatusfiltradonew( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Mes ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           GxSimpleCollection<int> aP3_ListaUsuarios ,
                           GxSimpleCollection<int> aP4_PromocionID ,
                           string aP5_FacturaNo ,
                           string aP6_FiltroEstatus ,
                           out SdtSDTTotalesBonoMes aP7_Tot )
      {
         this.AV14Mes = aP0_Mes;
         this.AV18FromDate = aP1_FromDate;
         this.AV19ToDate = aP2_ToDate;
         this.AV20ListaUsuarios = aP3_ListaUsuarios;
         this.AV12PromocionID = aP4_PromocionID;
         this.AV23FacturaNo = aP5_FacturaNo;
         this.AV22FiltroEstatus = aP6_FiltroEstatus;
         this.AV21Tot = new SdtSDTTotalesBonoMes(context) ;
         initialize();
         ExecuteImpl();
         aP7_Tot=this.AV21Tot;
      }

      public SdtSDTTotalesBonoMes executeUdp( short aP0_Mes ,
                                              DateTime aP1_FromDate ,
                                              DateTime aP2_ToDate ,
                                              GxSimpleCollection<int> aP3_ListaUsuarios ,
                                              GxSimpleCollection<int> aP4_PromocionID ,
                                              string aP5_FacturaNo ,
                                              string aP6_FiltroEstatus )
      {
         execute(aP0_Mes, aP1_FromDate, aP2_ToDate, aP3_ListaUsuarios, aP4_PromocionID, aP5_FacturaNo, aP6_FiltroEstatus, out aP7_Tot);
         return AV21Tot ;
      }

      public void executeSubmit( short aP0_Mes ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 GxSimpleCollection<int> aP3_ListaUsuarios ,
                                 GxSimpleCollection<int> aP4_PromocionID ,
                                 string aP5_FacturaNo ,
                                 string aP6_FiltroEstatus ,
                                 out SdtSDTTotalesBonoMes aP7_Tot )
      {
         this.AV14Mes = aP0_Mes;
         this.AV18FromDate = aP1_FromDate;
         this.AV19ToDate = aP2_ToDate;
         this.AV20ListaUsuarios = aP3_ListaUsuarios;
         this.AV12PromocionID = aP4_PromocionID;
         this.AV23FacturaNo = aP5_FacturaNo;
         this.AV22FiltroEstatus = aP6_FiltroEstatus;
         this.AV21Tot = new SdtSDTTotalesBonoMes(context) ;
         SubmitImpl();
         aP7_Tot=this.AV21Tot;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Tot = new SdtSDTTotalesBonoMes(context);
         AV21Tot.gxTpr_Montoaprobado = (decimal)(0);
         AV21Tot.gxTpr_Montorechazado = (decimal)(0);
         AV21Tot.gxTpr_Montoenproceso = (decimal)(0);
         AV24FiltraSoloUno = (bool)(!String.IsNullOrEmpty(StringUtil.RTrim( AV22FiltroEstatus)));
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV20ListaUsuarios ,
                                              A41PromocionID ,
                                              AV12PromocionID ,
                                              AV18FromDate ,
                                              AV19ToDate ,
                                              AV20ListaUsuarios.Count ,
                                              AV12PromocionID.Count ,
                                              AV23FacturaNo ,
                                              AV24FiltraSoloUno ,
                                              A73FacturaFechaFactura ,
                                              A71FacturaNo ,
                                              A80FacturaEstatus ,
                                              AV22FiltroEstatus ,
                                              AV14Mes ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P004A2 */
         pr_default.execute(0, new Object[] {AV14Mes, AV18FromDate, AV19ToDate, AV23FacturaNo, AV22FiltroEstatus});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A93FacturaCompleta = P004A2_A93FacturaCompleta[0];
            A80FacturaEstatus = P004A2_A80FacturaEstatus[0];
            A71FacturaNo = P004A2_A71FacturaNo[0];
            A41PromocionID = P004A2_A41PromocionID[0];
            A29UsuarioID = P004A2_A29UsuarioID[0];
            A73FacturaFechaFactura = P004A2_A73FacturaFechaFactura[0];
            A69FacturaID = P004A2_A69FacturaID[0];
            AV17BonoFactura = 0;
            new calculartotalbonofactura(context ).execute(  A69FacturaID, out  AV17BonoFactura) ;
            if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
            {
               AV21Tot.gxTpr_Montoaprobado = (decimal)(AV21Tot.gxTpr_Montoaprobado+AV17BonoFactura);
            }
            else if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
            {
               AV21Tot.gxTpr_Montorechazado = (decimal)(AV21Tot.gxTpr_Montorechazado+AV17BonoFactura);
            }
            else if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
            {
               AV21Tot.gxTpr_Montoenproceso = (decimal)(AV21Tot.gxTpr_Montoenproceso+AV17BonoFactura);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
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
         AV21Tot = new SdtSDTTotalesBonoMes(context);
         A73FacturaFechaFactura = DateTime.MinValue;
         A71FacturaNo = "";
         A80FacturaEstatus = "";
         P004A2_A93FacturaCompleta = new bool[] {false} ;
         P004A2_A80FacturaEstatus = new string[] {""} ;
         P004A2_A71FacturaNo = new string[] {""} ;
         P004A2_A41PromocionID = new int[1] ;
         P004A2_A29UsuarioID = new int[1] ;
         P004A2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P004A2_A69FacturaID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.calculartotalbonopormesestatusfiltradonew__default(),
            new Object[][] {
                new Object[] {
               P004A2_A93FacturaCompleta, P004A2_A80FacturaEstatus, P004A2_A71FacturaNo, P004A2_A41PromocionID, P004A2_A29UsuarioID, P004A2_A73FacturaFechaFactura, P004A2_A69FacturaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14Mes ;
      private int AV20ListaUsuarios_Count ;
      private int AV12PromocionID_Count ;
      private int A29UsuarioID ;
      private int A41PromocionID ;
      private int A69FacturaID ;
      private decimal AV17BonoFactura ;
      private string AV23FacturaNo ;
      private string AV22FiltroEstatus ;
      private string A71FacturaNo ;
      private string A80FacturaEstatus ;
      private DateTime AV18FromDate ;
      private DateTime AV19ToDate ;
      private DateTime A73FacturaFechaFactura ;
      private bool AV24FiltraSoloUno ;
      private bool A93FacturaCompleta ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<int> AV20ListaUsuarios ;
      private GxSimpleCollection<int> AV12PromocionID ;
      private SdtSDTTotalesBonoMes AV21Tot ;
      private IDataStoreProvider pr_default ;
      private bool[] P004A2_A93FacturaCompleta ;
      private string[] P004A2_A80FacturaEstatus ;
      private string[] P004A2_A71FacturaNo ;
      private int[] P004A2_A41PromocionID ;
      private int[] P004A2_A29UsuarioID ;
      private DateTime[] P004A2_A73FacturaFechaFactura ;
      private int[] P004A2_A69FacturaID ;
      private SdtSDTTotalesBonoMes aP7_Tot ;
   }

   public class calculartotalbonopormesestatusfiltradonew__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004A2( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV20ListaUsuarios ,
                                             int A41PromocionID ,
                                             GxSimpleCollection<int> AV12PromocionID ,
                                             DateTime AV18FromDate ,
                                             DateTime AV19ToDate ,
                                             int AV20ListaUsuarios_Count ,
                                             int AV12PromocionID_Count ,
                                             string AV23FacturaNo ,
                                             bool AV24FiltraSoloUno ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A71FacturaNo ,
                                             string A80FacturaEstatus ,
                                             string AV22FiltroEstatus ,
                                             short AV14Mes ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `FacturaCompleta`, `FacturaEstatus`, `FacturaNo`, `PromocionID`, `UsuarioID`, `FacturaFechaFactura`, `FacturaID` FROM `Factura`";
         AddWhere(sWhereString, "(month(`FacturaFechaFactura`) = @AV14Mes)");
         AddWhere(sWhereString, "(`FacturaCompleta` = 1)");
         if ( ! (DateTime.MinValue==AV18FromDate) )
         {
            AddWhere(sWhereString, "(`FacturaFechaFactura` >= @AV18FromDate)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV19ToDate) )
         {
            AddWhere(sWhereString, "(`FacturaFechaFactura` <= @AV19ToDate)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV20ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20ListaUsuarios, "`UsuarioID` IN (", ")")+")");
         }
         if ( AV12PromocionID_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV12PromocionID, "`PromocionID` IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23FacturaNo)) )
         {
            AddWhere(sWhereString, "(`FacturaNo` = @AV23FacturaNo)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV24FiltraSoloUno )
         {
            AddWhere(sWhereString, "(`FacturaEstatus` = @AV22FiltroEstatus)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `FacturaID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004A2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (GxSimpleCollection<int>)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004A2;
          prmP004A2 = new Object[] {
          new ParDef("@AV14Mes",GXType.Int16,4,0) ,
          new ParDef("@AV18FromDate",GXType.Date,8,0) ,
          new ParDef("@AV19ToDate",GXType.Date,8,0) ,
          new ParDef("@AV23FacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV22FiltroEstatus",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004A2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
