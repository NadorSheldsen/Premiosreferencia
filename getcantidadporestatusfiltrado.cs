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
   public class getcantidadporestatusfiltrado : GXProcedure
   {
      public getcantidadporestatusfiltrado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getcantidadporestatusfiltrado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Estatus ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           GxSimpleCollection<int> aP3_ListaUsuarioID ,
                           out long aP4_Cantidad )
      {
         this.AV8Estatus = aP0_Estatus;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV12ListaUsuarioID = aP3_ListaUsuarioID;
         this.AV9Cantidad = 0 ;
         initialize();
         ExecuteImpl();
         aP4_Cantidad=this.AV9Cantidad;
      }

      public long executeUdp( string aP0_Estatus ,
                              DateTime aP1_FromDate ,
                              DateTime aP2_ToDate ,
                              GxSimpleCollection<int> aP3_ListaUsuarioID )
      {
         execute(aP0_Estatus, aP1_FromDate, aP2_ToDate, aP3_ListaUsuarioID, out aP4_Cantidad);
         return AV9Cantidad ;
      }

      public void executeSubmit( string aP0_Estatus ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 GxSimpleCollection<int> aP3_ListaUsuarioID ,
                                 out long aP4_Cantidad )
      {
         this.AV8Estatus = aP0_Estatus;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV12ListaUsuarioID = aP3_ListaUsuarioID;
         this.AV9Cantidad = 0 ;
         SubmitImpl();
         aP4_Cantidad=this.AV9Cantidad;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Cantidad = 0;
         /* Optimized group. */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV12ListaUsuarioID ,
                                              AV8Estatus } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor P00422 */
         pr_default.execute(0, new Object[] {AV8Estatus, AV10FromDate, AV11ToDate});
         cV9Cantidad = P00422_AV9Cantidad[0];
         pr_default.close(0);
         AV9Cantidad = (long)(AV9Cantidad+cV9Cantidad*1);
         /* End optimized group. */
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
         P00422_AV9Cantidad = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getcantidadporestatusfiltrado__default(),
            new Object[][] {
                new Object[] {
               P00422_AV9Cantidad
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A29UsuarioID ;
      private long AV9Cantidad ;
      private long cV9Cantidad ;
      private string AV8Estatus ;
      private DateTime AV10FromDate ;
      private DateTime AV11ToDate ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<int> AV12ListaUsuarioID ;
      private IDataStoreProvider pr_default ;
      private long[] P00422_AV9Cantidad ;
      private long aP4_Cantidad ;
   }

   public class getcantidadporestatusfiltrado__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00422( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV12ListaUsuarioID ,
                                             string AV8Estatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM `Factura`";
         AddWhere(sWhereString, "(`FacturaEstatus` = @AV8Estatus)");
         AddWhere(sWhereString, "(`FacturaFechaFactura` >= @AV10FromDate and `FacturaFechaFactura` <= @AV11ToDate)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV12ListaUsuarioID, "`UsuarioID` IN (", ")")+")");
         scmdbuf += sWhereString;
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
                     return conditional_P00422(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] );
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
          Object[] prmP00422;
          prmP00422 = new Object[] {
          new ParDef("@AV8Estatus",GXType.Char,20,0) ,
          new ParDef("@AV10FromDate",GXType.Date,8,0) ,
          new ParDef("@AV11ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00422", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00422,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
