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
   public class calculartotalbonopormesestatusfiltrado : GXProcedure
   {
      public calculartotalbonopormesestatusfiltrado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public calculartotalbonopormesestatusfiltrado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Mes ,
                           string aP1_Estatus ,
                           DateTime aP2_FromDate ,
                           DateTime aP3_ToDate ,
                           GxSimpleCollection<int> aP4_ListaUsuarios ,
                           out decimal aP5_TotalBono )
      {
         this.AV14Mes = aP0_Mes;
         this.AV15Estatus = aP1_Estatus;
         this.AV18FromDate = aP2_FromDate;
         this.AV19ToDate = aP3_ToDate;
         this.AV20ListaUsuarios = aP4_ListaUsuarios;
         this.AV13TotalBono = 0 ;
         initialize();
         ExecuteImpl();
         aP5_TotalBono=this.AV13TotalBono;
      }

      public decimal executeUdp( short aP0_Mes ,
                                 string aP1_Estatus ,
                                 DateTime aP2_FromDate ,
                                 DateTime aP3_ToDate ,
                                 GxSimpleCollection<int> aP4_ListaUsuarios )
      {
         execute(aP0_Mes, aP1_Estatus, aP2_FromDate, aP3_ToDate, aP4_ListaUsuarios, out aP5_TotalBono);
         return AV13TotalBono ;
      }

      public void executeSubmit( short aP0_Mes ,
                                 string aP1_Estatus ,
                                 DateTime aP2_FromDate ,
                                 DateTime aP3_ToDate ,
                                 GxSimpleCollection<int> aP4_ListaUsuarios ,
                                 out decimal aP5_TotalBono )
      {
         this.AV14Mes = aP0_Mes;
         this.AV15Estatus = aP1_Estatus;
         this.AV18FromDate = aP2_FromDate;
         this.AV19ToDate = aP3_ToDate;
         this.AV20ListaUsuarios = aP4_ListaUsuarios;
         this.AV13TotalBono = 0 ;
         SubmitImpl();
         aP5_TotalBono=this.AV13TotalBono;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13TotalBono = 0;
         AV17BonoFactura = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV20ListaUsuarios ,
                                              A73FacturaFechaFactura ,
                                              AV14Mes ,
                                              AV18FromDate ,
                                              AV19ToDate ,
                                              A80FacturaEstatus ,
                                              AV15Estatus ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00432 */
         pr_default.execute(0, new Object[] {AV14Mes, AV18FromDate, AV19ToDate, AV15Estatus});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A93FacturaCompleta = P00432_A93FacturaCompleta[0];
            A29UsuarioID = P00432_A29UsuarioID[0];
            A80FacturaEstatus = P00432_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P00432_A73FacturaFechaFactura[0];
            A69FacturaID = P00432_A69FacturaID[0];
            AV17BonoFactura = 0;
            new calculartotalbonofactura(context ).execute(  A69FacturaID, out  AV17BonoFactura) ;
            AV13TotalBono = (decimal)(AV13TotalBono+AV17BonoFactura);
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
         A73FacturaFechaFactura = DateTime.MinValue;
         A80FacturaEstatus = "";
         P00432_A93FacturaCompleta = new bool[] {false} ;
         P00432_A29UsuarioID = new int[1] ;
         P00432_A80FacturaEstatus = new string[] {""} ;
         P00432_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00432_A69FacturaID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.calculartotalbonopormesestatusfiltrado__default(),
            new Object[][] {
                new Object[] {
               P00432_A93FacturaCompleta, P00432_A29UsuarioID, P00432_A80FacturaEstatus, P00432_A73FacturaFechaFactura, P00432_A69FacturaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14Mes ;
      private int A29UsuarioID ;
      private int A69FacturaID ;
      private decimal AV13TotalBono ;
      private decimal AV17BonoFactura ;
      private string AV15Estatus ;
      private string A80FacturaEstatus ;
      private DateTime AV18FromDate ;
      private DateTime AV19ToDate ;
      private DateTime A73FacturaFechaFactura ;
      private bool A93FacturaCompleta ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<int> AV20ListaUsuarios ;
      private IDataStoreProvider pr_default ;
      private bool[] P00432_A93FacturaCompleta ;
      private int[] P00432_A29UsuarioID ;
      private string[] P00432_A80FacturaEstatus ;
      private DateTime[] P00432_A73FacturaFechaFactura ;
      private int[] P00432_A69FacturaID ;
      private decimal aP5_TotalBono ;
   }

   public class calculartotalbonopormesestatusfiltrado__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00432( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV20ListaUsuarios ,
                                             DateTime A73FacturaFechaFactura ,
                                             short AV14Mes ,
                                             DateTime AV18FromDate ,
                                             DateTime AV19ToDate ,
                                             string A80FacturaEstatus ,
                                             string AV15Estatus ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `FacturaCompleta`, `UsuarioID`, `FacturaEstatus`, `FacturaFechaFactura`, `FacturaID` FROM `Factura`";
         AddWhere(sWhereString, "(month(`FacturaFechaFactura`) = @AV14Mes)");
         AddWhere(sWhereString, "(`FacturaFechaFactura` >= @AV18FromDate)");
         AddWhere(sWhereString, "(`FacturaFechaFactura` <= @AV19ToDate)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20ListaUsuarios, "`UsuarioID` IN (", ")")+")");
         AddWhere(sWhereString, "(`FacturaEstatus` = @AV15Estatus)");
         AddWhere(sWhereString, "(`FacturaCompleta` = 1)");
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
                     return conditional_P00432(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (DateTime)dynConstraints[2] , (short)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] );
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
          Object[] prmP00432;
          prmP00432 = new Object[] {
          new ParDef("@AV14Mes",GXType.Int16,4,0) ,
          new ParDef("@AV18FromDate",GXType.Date,8,0) ,
          new ParDef("@AV19ToDate",GXType.Date,8,0) ,
          new ParDef("@AV15Estatus",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00432", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00432,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
