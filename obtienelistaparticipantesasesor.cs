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
   public class obtienelistaparticipantesasesor : GXProcedure
   {
      public obtienelistaparticipantesasesor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtienelistaparticipantesasesor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UsuarioID ,
                           out GxSimpleCollection<int> aP1_ListaUsuariosAsesores )
      {
         this.AV66UsuarioID = aP0_UsuarioID;
         this.AV34ListaUsuariosAsesores = new GxSimpleCollection<int>() ;
         initialize();
         ExecuteImpl();
         aP1_ListaUsuariosAsesores=this.AV34ListaUsuariosAsesores;
      }

      public GxSimpleCollection<int> executeUdp( int aP0_UsuarioID )
      {
         execute(aP0_UsuarioID, out aP1_ListaUsuariosAsesores);
         return AV34ListaUsuariosAsesores ;
      }

      public void executeSubmit( int aP0_UsuarioID ,
                                 out GxSimpleCollection<int> aP1_ListaUsuariosAsesores )
      {
         this.AV66UsuarioID = aP0_UsuarioID;
         this.AV34ListaUsuariosAsesores = new GxSimpleCollection<int>() ;
         SubmitImpl();
         aP1_ListaUsuariosAsesores=this.AV34ListaUsuariosAsesores;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV33ListaDistribuidores.Clear();
         AV34ListaUsuariosAsesores.Clear();
         /* Using cursor P003Z2 */
         pr_default.execute(0, new Object[] {AV66UsuarioID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29UsuarioID = P003Z2_A29UsuarioID[0];
            A10DistribuidorID = P003Z2_A10DistribuidorID[0];
            A81DistribuidoresUsuarioID = P003Z2_A81DistribuidoresUsuarioID[0];
            AV73YaExiste = false;
            AV75GXV1 = 1;
            while ( AV75GXV1 <= AV33ListaDistribuidores.Count )
            {
               AV21DistribuidorID = (int)(AV33ListaDistribuidores.GetNumeric(AV75GXV1));
               if ( AV21DistribuidorID == A10DistribuidorID )
               {
                  AV73YaExiste = true;
                  if (true) break;
               }
               AV75GXV1 = (int)(AV75GXV1+1);
            }
            if ( ! AV73YaExiste )
            {
               AV33ListaDistribuidores.Add(A10DistribuidorID, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A10DistribuidorID ,
                                              AV33ListaDistribuidores ,
                                              A40UsuarioRol } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor P003Z3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A40UsuarioRol = P003Z3_A40UsuarioRol[0];
            A10DistribuidorID = P003Z3_A10DistribuidorID[0];
            A29UsuarioID = P003Z3_A29UsuarioID[0];
            A81DistribuidoresUsuarioID = P003Z3_A81DistribuidoresUsuarioID[0];
            A40UsuarioRol = P003Z3_A40UsuarioRol[0];
            AV42Pasa = false;
            AV77GXV2 = 1;
            while ( AV77GXV2 <= AV34ListaUsuariosAsesores.Count )
            {
               AV70UsuariosListaID = (int)(AV34ListaUsuariosAsesores.GetNumeric(AV77GXV2));
               if ( AV70UsuariosListaID == A29UsuarioID )
               {
                  AV42Pasa = true;
                  if (true) break;
               }
               AV77GXV2 = (int)(AV77GXV2+1);
            }
            if ( ! AV42Pasa )
            {
               AV34ListaUsuariosAsesores.Add(A29UsuarioID, 0);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV34ListaUsuariosAsesores = new GxSimpleCollection<int>();
         AV33ListaDistribuidores = new GxSimpleCollection<int>();
         P003Z2_A29UsuarioID = new int[1] ;
         P003Z2_A10DistribuidorID = new int[1] ;
         P003Z2_A81DistribuidoresUsuarioID = new int[1] ;
         A40UsuarioRol = "";
         P003Z3_A40UsuarioRol = new string[] {""} ;
         P003Z3_A10DistribuidorID = new int[1] ;
         P003Z3_A29UsuarioID = new int[1] ;
         P003Z3_A81DistribuidoresUsuarioID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtienelistaparticipantesasesor__default(),
            new Object[][] {
                new Object[] {
               P003Z2_A29UsuarioID, P003Z2_A10DistribuidorID, P003Z2_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               P003Z3_A40UsuarioRol, P003Z3_A10DistribuidorID, P003Z3_A29UsuarioID, P003Z3_A81DistribuidoresUsuarioID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV66UsuarioID ;
      private int A29UsuarioID ;
      private int A10DistribuidorID ;
      private int A81DistribuidoresUsuarioID ;
      private int AV75GXV1 ;
      private int AV21DistribuidorID ;
      private int AV77GXV2 ;
      private int AV70UsuariosListaID ;
      private string A40UsuarioRol ;
      private bool AV73YaExiste ;
      private bool AV42Pasa ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<int> AV34ListaUsuariosAsesores ;
      private GxSimpleCollection<int> AV33ListaDistribuidores ;
      private IDataStoreProvider pr_default ;
      private int[] P003Z2_A29UsuarioID ;
      private int[] P003Z2_A10DistribuidorID ;
      private int[] P003Z2_A81DistribuidoresUsuarioID ;
      private string[] P003Z3_A40UsuarioRol ;
      private int[] P003Z3_A10DistribuidorID ;
      private int[] P003Z3_A29UsuarioID ;
      private int[] P003Z3_A81DistribuidoresUsuarioID ;
      private GxSimpleCollection<int> aP1_ListaUsuariosAsesores ;
   }

   public class obtienelistaparticipantesasesor__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003Z3( IGxContext context ,
                                             int A10DistribuidorID ,
                                             GxSimpleCollection<int> AV33ListaDistribuidores ,
                                             string A40UsuarioRol )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT T2.`UsuarioRol`, T1.`DistribuidorID`, T1.`UsuarioID`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV33ListaDistribuidores, "T1.`DistribuidorID` IN (", ")")+")");
         AddWhere(sWhereString, "(T2.`UsuarioRol` = 'Participante')");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`DistribuidoresUsuarioID`";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P003Z3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] );
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
          Object[] prmP003Z2;
          prmP003Z2 = new Object[] {
          new ParDef("@AV66UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmP003Z3;
          prmP003Z3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P003Z2", "SELECT `UsuarioID`, `DistribuidorID`, `DistribuidoresUsuarioID` FROM `DistribuidoresUsuario` WHERE `UsuarioID` = @AV66UsuarioID ORDER BY `UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P003Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z3,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
