using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Estado" )]
   [XmlType(TypeName =  "Estado" , Namespace = "Premios" )]
   [Serializable]
   public class SdtEstado : GxSilentTrnSdt
   {
      public SdtEstado( )
      {
      }

      public SdtEstado( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( int AV1EstadoID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1EstadoID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EstadoID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Estado");
         metadata.Set("BT", "Estado");
         metadata.Set("PK", "[ \"EstadoID\" ]");
         metadata.Set("PKAssigned", "[ \"EstadoID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PaisID\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Estadoid_Z");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisdescripcion_Z");
         state.Add("gxTpr_Estadodescripcion_Z");
         state.Add("gxTpr_Estadoactivo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEstado sdt;
         sdt = (SdtEstado)(source);
         gxTv_SdtEstado_Estadoid = sdt.gxTv_SdtEstado_Estadoid ;
         gxTv_SdtEstado_Paisid = sdt.gxTv_SdtEstado_Paisid ;
         gxTv_SdtEstado_Paisdescripcion = sdt.gxTv_SdtEstado_Paisdescripcion ;
         gxTv_SdtEstado_Estadodescripcion = sdt.gxTv_SdtEstado_Estadodescripcion ;
         gxTv_SdtEstado_Estadoactivo = sdt.gxTv_SdtEstado_Estadoactivo ;
         gxTv_SdtEstado_Mode = sdt.gxTv_SdtEstado_Mode ;
         gxTv_SdtEstado_Initialized = sdt.gxTv_SdtEstado_Initialized ;
         gxTv_SdtEstado_Estadoid_Z = sdt.gxTv_SdtEstado_Estadoid_Z ;
         gxTv_SdtEstado_Paisid_Z = sdt.gxTv_SdtEstado_Paisid_Z ;
         gxTv_SdtEstado_Paisdescripcion_Z = sdt.gxTv_SdtEstado_Paisdescripcion_Z ;
         gxTv_SdtEstado_Estadodescripcion_Z = sdt.gxTv_SdtEstado_Estadodescripcion_Z ;
         gxTv_SdtEstado_Estadoactivo_Z = sdt.gxTv_SdtEstado_Estadoactivo_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("EstadoID", gxTv_SdtEstado_Estadoid, false, includeNonInitialized);
         AddObjectProperty("PaisID", gxTv_SdtEstado_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisDescripcion", gxTv_SdtEstado_Paisdescripcion, false, includeNonInitialized);
         AddObjectProperty("EstadoDescripcion", gxTv_SdtEstado_Estadodescripcion, false, includeNonInitialized);
         AddObjectProperty("EstadoActivo", gxTv_SdtEstado_Estadoactivo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEstado_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEstado_Initialized, false, includeNonInitialized);
            AddObjectProperty("EstadoID_Z", gxTv_SdtEstado_Estadoid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisID_Z", gxTv_SdtEstado_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisDescripcion_Z", gxTv_SdtEstado_Paisdescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("EstadoDescripcion_Z", gxTv_SdtEstado_Estadodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("EstadoActivo_Z", gxTv_SdtEstado_Estadoactivo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEstado sdt )
      {
         if ( sdt.IsDirty("EstadoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtEstado_Estadoid = sdt.gxTv_SdtEstado_Estadoid ;
         }
         if ( sdt.IsDirty("PaisID") )
         {
            sdtIsNull = 0;
            gxTv_SdtEstado_Paisid = sdt.gxTv_SdtEstado_Paisid ;
         }
         if ( sdt.IsDirty("PaisDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtEstado_Paisdescripcion = sdt.gxTv_SdtEstado_Paisdescripcion ;
         }
         if ( sdt.IsDirty("EstadoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtEstado_Estadodescripcion = sdt.gxTv_SdtEstado_Estadodescripcion ;
         }
         if ( sdt.IsDirty("EstadoActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtEstado_Estadoactivo = sdt.gxTv_SdtEstado_Estadoactivo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EstadoID" )]
      [  XmlElement( ElementName = "EstadoID"   )]
      public int gxTpr_Estadoid
      {
         get {
            return gxTv_SdtEstado_Estadoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEstado_Estadoid != value )
            {
               gxTv_SdtEstado_Mode = "INS";
               this.gxTv_SdtEstado_Estadoid_Z_SetNull( );
               this.gxTv_SdtEstado_Paisid_Z_SetNull( );
               this.gxTv_SdtEstado_Paisdescripcion_Z_SetNull( );
               this.gxTv_SdtEstado_Estadodescripcion_Z_SetNull( );
               this.gxTv_SdtEstado_Estadoactivo_Z_SetNull( );
            }
            gxTv_SdtEstado_Estadoid = value;
            SetDirty("Estadoid");
         }

      }

      [  SoapElement( ElementName = "PaisID" )]
      [  XmlElement( ElementName = "PaisID"   )]
      public int gxTpr_Paisid
      {
         get {
            return gxTv_SdtEstado_Paisid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisDescripcion" )]
      [  XmlElement( ElementName = "PaisDescripcion"   )]
      public string gxTpr_Paisdescripcion
      {
         get {
            return gxTv_SdtEstado_Paisdescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Paisdescripcion = value;
            SetDirty("Paisdescripcion");
         }

      }

      [  SoapElement( ElementName = "EstadoDescripcion" )]
      [  XmlElement( ElementName = "EstadoDescripcion"   )]
      public string gxTpr_Estadodescripcion
      {
         get {
            return gxTv_SdtEstado_Estadodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Estadodescripcion = value;
            SetDirty("Estadodescripcion");
         }

      }

      [  SoapElement( ElementName = "EstadoActivo" )]
      [  XmlElement( ElementName = "EstadoActivo"   )]
      public bool gxTpr_Estadoactivo
      {
         get {
            return gxTv_SdtEstado_Estadoactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Estadoactivo = value;
            SetDirty("Estadoactivo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEstado_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEstado_Mode_SetNull( )
      {
         gxTv_SdtEstado_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEstado_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEstado_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEstado_Initialized_SetNull( )
      {
         gxTv_SdtEstado_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEstado_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoID_Z" )]
      [  XmlElement( ElementName = "EstadoID_Z"   )]
      public int gxTpr_Estadoid_Z
      {
         get {
            return gxTv_SdtEstado_Estadoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Estadoid_Z = value;
            SetDirty("Estadoid_Z");
         }

      }

      public void gxTv_SdtEstado_Estadoid_Z_SetNull( )
      {
         gxTv_SdtEstado_Estadoid_Z = 0;
         SetDirty("Estadoid_Z");
         return  ;
      }

      public bool gxTv_SdtEstado_Estadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisID_Z" )]
      [  XmlElement( ElementName = "PaisID_Z"   )]
      public int gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtEstado_Paisid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtEstado_Paisid_Z_SetNull( )
      {
         gxTv_SdtEstado_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtEstado_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisDescripcion_Z" )]
      [  XmlElement( ElementName = "PaisDescripcion_Z"   )]
      public string gxTpr_Paisdescripcion_Z
      {
         get {
            return gxTv_SdtEstado_Paisdescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Paisdescripcion_Z = value;
            SetDirty("Paisdescripcion_Z");
         }

      }

      public void gxTv_SdtEstado_Paisdescripcion_Z_SetNull( )
      {
         gxTv_SdtEstado_Paisdescripcion_Z = "";
         SetDirty("Paisdescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtEstado_Paisdescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoDescripcion_Z" )]
      [  XmlElement( ElementName = "EstadoDescripcion_Z"   )]
      public string gxTpr_Estadodescripcion_Z
      {
         get {
            return gxTv_SdtEstado_Estadodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Estadodescripcion_Z = value;
            SetDirty("Estadodescripcion_Z");
         }

      }

      public void gxTv_SdtEstado_Estadodescripcion_Z_SetNull( )
      {
         gxTv_SdtEstado_Estadodescripcion_Z = "";
         SetDirty("Estadodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtEstado_Estadodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoActivo_Z" )]
      [  XmlElement( ElementName = "EstadoActivo_Z"   )]
      public bool gxTpr_Estadoactivo_Z
      {
         get {
            return gxTv_SdtEstado_Estadoactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEstado_Estadoactivo_Z = value;
            SetDirty("Estadoactivo_Z");
         }

      }

      public void gxTv_SdtEstado_Estadoactivo_Z_SetNull( )
      {
         gxTv_SdtEstado_Estadoactivo_Z = false;
         SetDirty("Estadoactivo_Z");
         return  ;
      }

      public bool gxTv_SdtEstado_Estadoactivo_Z_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtEstado_Paisdescripcion = "";
         gxTv_SdtEstado_Estadodescripcion = "";
         gxTv_SdtEstado_Mode = "";
         gxTv_SdtEstado_Paisdescripcion_Z = "";
         gxTv_SdtEstado_Estadodescripcion_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "estado", "GeneXus.Programs.estado_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtEstado_Initialized ;
      private int gxTv_SdtEstado_Estadoid ;
      private int gxTv_SdtEstado_Paisid ;
      private int gxTv_SdtEstado_Estadoid_Z ;
      private int gxTv_SdtEstado_Paisid_Z ;
      private string gxTv_SdtEstado_Mode ;
      private bool gxTv_SdtEstado_Estadoactivo ;
      private bool gxTv_SdtEstado_Estadoactivo_Z ;
      private string gxTv_SdtEstado_Paisdescripcion ;
      private string gxTv_SdtEstado_Estadodescripcion ;
      private string gxTv_SdtEstado_Paisdescripcion_Z ;
      private string gxTv_SdtEstado_Estadodescripcion_Z ;
   }

   [DataContract(Name = @"Estado", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtEstado_RESTInterface : GxGenericCollectionItem<SdtEstado>
   {
      public SdtEstado_RESTInterface( ) : base()
      {
      }

      public SdtEstado_RESTInterface( SdtEstado psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EstadoID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Estadoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Estadoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Estadoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PaisID" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Paisid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Paisid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Paisid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PaisDescripcion" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Paisdescripcion
      {
         get {
            return sdt.gxTpr_Paisdescripcion ;
         }

         set {
            sdt.gxTpr_Paisdescripcion = value;
         }

      }

      [DataMember( Name = "EstadoDescripcion" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Estadodescripcion
      {
         get {
            return sdt.gxTpr_Estadodescripcion ;
         }

         set {
            sdt.gxTpr_Estadodescripcion = value;
         }

      }

      [DataMember( Name = "EstadoActivo" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Estadoactivo
      {
         get {
            return sdt.gxTpr_Estadoactivo ;
         }

         set {
            sdt.gxTpr_Estadoactivo = value;
         }

      }

      public SdtEstado sdt
      {
         get {
            return (SdtEstado)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtEstado() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Estado", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtEstado_RESTLInterface : GxGenericCollectionItem<SdtEstado>
   {
      public SdtEstado_RESTLInterface( ) : base()
      {
      }

      public SdtEstado_RESTLInterface( SdtEstado psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EstadoDescripcion" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Estadodescripcion
      {
         get {
            return sdt.gxTpr_Estadodescripcion ;
         }

         set {
            sdt.gxTpr_Estadodescripcion = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtEstado sdt
      {
         get {
            return (SdtEstado)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtEstado() ;
         }
      }

   }

}
