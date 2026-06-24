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
   public class getcantidadporestatusfiltradonew : GXProcedure
   {
      public getcantidadporestatusfiltradonew( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getcantidadporestatusfiltradonew( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Estatus ,
                           [GxJsonFormat("yyyy-MM-dd")] DateTime aP1_FromDate ,
                           [GxJsonFormat("yyyy-MM-dd")] DateTime aP2_ToDate ,
                           GxSimpleCollection<int> aP3_ListaUsuarioID ,
                           GxSimpleCollection<int> aP4_PromocionID ,
                           string aP5_FacturaNo ,
                           string aP6_FiltroEstatus ,
                           out long aP7_Cantidad )
      {
         this.AV8Estatus = aP0_Estatus;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV12ListaUsuarioID = aP3_ListaUsuarioID;
         this.AV13PromocionID = aP4_PromocionID;
         this.AV14FacturaNo = aP5_FacturaNo;
         this.AV15FiltroEstatus = aP6_FiltroEstatus;
         this.AV9Cantidad = 0 ;
         initialize();
         ExecuteImpl();
         aP7_Cantidad=this.AV9Cantidad;
      }

      public long executeUdp( string aP0_Estatus ,
                              DateTime aP1_FromDate ,
                              DateTime aP2_ToDate ,
                              GxSimpleCollection<int> aP3_ListaUsuarioID ,
                              GxSimpleCollection<int> aP4_PromocionID ,
                              string aP5_FacturaNo ,
                              string aP6_FiltroEstatus )
      {
         execute(aP0_Estatus, aP1_FromDate, aP2_ToDate, aP3_ListaUsuarioID, aP4_PromocionID, aP5_FacturaNo, aP6_FiltroEstatus, out aP7_Cantidad);
         return AV9Cantidad ;
      }

      public void executeSubmit( string aP0_Estatus ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 GxSimpleCollection<int> aP3_ListaUsuarioID ,
                                 GxSimpleCollection<int> aP4_PromocionID ,
                                 string aP5_FacturaNo ,
                                 string aP6_FiltroEstatus ,
                                 out long aP7_Cantidad )
      {
         this.AV8Estatus = aP0_Estatus;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV12ListaUsuarioID = aP3_ListaUsuarioID;
         this.AV13PromocionID = aP4_PromocionID;
         this.AV14FacturaNo = aP5_FacturaNo;
         this.AV15FiltroEstatus = aP6_FiltroEstatus;
         this.AV9Cantidad = 0 ;
         SubmitImpl();
         aP7_Cantidad=this.AV9Cantidad;
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
                                              A41PromocionID ,
                                              AV13PromocionID ,
                                              AV10FromDate ,
                                              AV11ToDate ,
                                              AV12ListaUsuarioID.Count ,
                                              AV13PromocionID.Count ,
                                              AV14FacturaNo ,
                                              AV15FiltroEstatus ,
                                              A73FacturaFechaFactura ,
                                              A71FacturaNo ,
                                              A80FacturaEstatus ,
                                              AV8Estatus } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00492 */
         pr_default.execute(0, new Object[] {AV8Estatus, AV10FromDate, AV11ToDate, AV14FacturaNo, AV15FiltroEstatus});
         cV9Cantidad = P00492_AV9Cantidad[0];
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
         A73FacturaFechaFactura = DateTime.MinValue;
         A71FacturaNo = "";
         A80FacturaEstatus = "";
         P00492_AV9Cantidad = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getcantidadporestatusfiltradonew__default(),
            new Object[][] {
                new Object[] {
               P00492_AV9Cantidad
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV12ListaUsuarioID_Count ;
      private int AV13PromocionID_Count ;
      private int A29UsuarioID ;
      private int A41PromocionID ;
      private long AV9Cantidad ;
      private long cV9Cantidad ;
      private string AV8Estatus ;
      private string AV14FacturaNo ;
      private string AV15FiltroEstatus ;
      private string A71FacturaNo ;
      private string A80FacturaEstatus ;
      private DateTime AV10FromDate ;
      private DateTime AV11ToDate ;
      private DateTime A73FacturaFechaFactura ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<int> AV12ListaUsuarioID ;
      private GxSimpleCollection<int> AV13PromocionID ;
      private IDataStoreProvider pr_default ;
      private long[] P00492_AV9Cantidad ;
      private long aP7_Cantidad ;
   }

   public class getcantidadporestatusfiltradonew__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00492( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV12ListaUsuarioID ,
                                             int A41PromocionID ,
                                             GxSimpleCollection<int> AV13PromocionID ,
                                             DateTime AV10FromDate ,
                                             DateTime AV11ToDate ,
                                             int AV12ListaUsuarioID_Count ,
                                             int AV13PromocionID_Count ,
                                             string AV14FacturaNo ,
                                             string AV15FiltroEstatus ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A71FacturaNo ,
                                             string A80FacturaEstatus ,
                                             string AV8Estatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM `Factura`";
         AddWhere(sWhereString, "(`FacturaEstatus` = @AV8Estatus)");
         if ( ! (DateTime.MinValue==AV10FromDate) )
         {
            AddWhere(sWhereString, "(`FacturaFechaFactura` >= @AV10FromDate)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV11ToDate) )
         {
            AddWhere(sWhereString, "(`FacturaFechaFactura` <= @AV11ToDate)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV12ListaUsuarioID_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV12ListaUsuarioID, "`UsuarioID` IN (", ")")+")");
         }
         if ( AV13PromocionID_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV13PromocionID, "`PromocionID` IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FacturaNo)) )
         {
            AddWhere(sWhereString, "(`FacturaNo` = @AV14FacturaNo)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15FiltroEstatus)) )
         {
            AddWhere(sWhereString, "(`FacturaEstatus` = @AV15FiltroEstatus)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
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
                     return conditional_P00492(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (GxSimpleCollection<int>)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmP00492;
          prmP00492 = new Object[] {
          new ParDef("@AV8Estatus",GXType.Char,20,0) ,
          new ParDef("@AV10FromDate",GXType.Date,8,0) ,
          new ParDef("@AV11ToDate",GXType.Date,8,0) ,
          new ParDef("@AV14FacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV15FiltroEstatus",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00492", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00492,1, GxCacheFrequency.OFF ,true,false )
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
