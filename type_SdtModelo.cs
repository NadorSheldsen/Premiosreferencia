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
   [XmlRoot(ElementName = "Modelo" )]
   [XmlType(TypeName =  "Modelo" , Namespace = "Premios" )]
   [Serializable]
   public class SdtModelo : GxSilentTrnSdt
   {
      public SdtModelo( )
      {
      }

      public SdtModelo( IGxContext context )
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

      public void Load( int AV22ModeloID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV22ModeloID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ModeloID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Modelo");
         metadata.Set("BT", "Modelo");
         metadata.Set("PK", "[ \"ModeloID\" ]");
         metadata.Set("PKAssigned", "[ \"ModeloID\" ]");
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
         state.Add("gxTpr_Modeloid_Z");
         state.Add("gxTpr_Modelodescripcion_Z");
         state.Add("gxTpr_Modeloactivo_Z");
         state.Add("gxTpr_Modelosegmento_Z");
         state.Add("gxTpr_Modelomarca_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtModelo sdt;
         sdt = (SdtModelo)(source);
         gxTv_SdtModelo_Modeloid = sdt.gxTv_SdtModelo_Modeloid ;
         gxTv_SdtModelo_Modelodescripcion = sdt.gxTv_SdtModelo_Modelodescripcion ;
         gxTv_SdtModelo_Modeloactivo = sdt.gxTv_SdtModelo_Modeloactivo ;
         gxTv_SdtModelo_Modelosegmento = sdt.gxTv_SdtModelo_Modelosegmento ;
         gxTv_SdtModelo_Modelomarca = sdt.gxTv_SdtModelo_Modelomarca ;
         gxTv_SdtModelo_Mode = sdt.gxTv_SdtModelo_Mode ;
         gxTv_SdtModelo_Initialized = sdt.gxTv_SdtModelo_Initialized ;
         gxTv_SdtModelo_Modeloid_Z = sdt.gxTv_SdtModelo_Modeloid_Z ;
         gxTv_SdtModelo_Modelodescripcion_Z = sdt.gxTv_SdtModelo_Modelodescripcion_Z ;
         gxTv_SdtModelo_Modeloactivo_Z = sdt.gxTv_SdtModelo_Modeloactivo_Z ;
         gxTv_SdtModelo_Modelosegmento_Z = sdt.gxTv_SdtModelo_Modelosegmento_Z ;
         gxTv_SdtModelo_Modelomarca_Z = sdt.gxTv_SdtModelo_Modelomarca_Z ;
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
         AddObjectProperty("ModeloID", gxTv_SdtModelo_Modeloid, false, includeNonInitialized);
         AddObjectProperty("ModeloDescripcion", gxTv_SdtModelo_Modelodescripcion, false, includeNonInitialized);
         AddObjectProperty("ModeloActivo", gxTv_SdtModelo_Modeloactivo, false, includeNonInitialized);
         AddObjectProperty("ModeloSegmento", gxTv_SdtModelo_Modelosegmento, false, includeNonInitialized);
         AddObjectProperty("ModeloMarca", gxTv_SdtModelo_Modelomarca, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtModelo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtModelo_Initialized, false, includeNonInitialized);
            AddObjectProperty("ModeloID_Z", gxTv_SdtModelo_Modeloid_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloDescripcion_Z", gxTv_SdtModelo_Modelodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloActivo_Z", gxTv_SdtModelo_Modeloactivo_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloSegmento_Z", gxTv_SdtModelo_Modelosegmento_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloMarca_Z", gxTv_SdtModelo_Modelomarca_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtModelo sdt )
      {
         if ( sdt.IsDirty("ModeloID") )
         {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modeloid = sdt.gxTv_SdtModelo_Modeloid ;
         }
         if ( sdt.IsDirty("ModeloDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modelodescripcion = sdt.gxTv_SdtModelo_Modelodescripcion ;
         }
         if ( sdt.IsDirty("ModeloActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modeloactivo = sdt.gxTv_SdtModelo_Modeloactivo ;
         }
         if ( sdt.IsDirty("ModeloSegmento") )
         {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modelosegmento = sdt.gxTv_SdtModelo_Modelosegmento ;
         }
         if ( sdt.IsDirty("ModeloMarca") )
         {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modelomarca = sdt.gxTv_SdtModelo_Modelomarca ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ModeloID" )]
      [  XmlElement( ElementName = "ModeloID"   )]
      public int gxTpr_Modeloid
      {
         get {
            return gxTv_SdtModelo_Modeloid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtModelo_Modeloid != value )
            {
               gxTv_SdtModelo_Mode = "INS";
               this.gxTv_SdtModelo_Modeloid_Z_SetNull( );
               this.gxTv_SdtModelo_Modelodescripcion_Z_SetNull( );
               this.gxTv_SdtModelo_Modeloactivo_Z_SetNull( );
               this.gxTv_SdtModelo_Modelosegmento_Z_SetNull( );
               this.gxTv_SdtModelo_Modelomarca_Z_SetNull( );
            }
            gxTv_SdtModelo_Modeloid = value;
            SetDirty("Modeloid");
         }

      }

      [  SoapElement( ElementName = "ModeloDescripcion" )]
      [  XmlElement( ElementName = "ModeloDescripcion"   )]
      public string gxTpr_Modelodescripcion
      {
         get {
            return gxTv_SdtModelo_Modelodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modelodescripcion = value;
            SetDirty("Modelodescripcion");
         }

      }

      [  SoapElement( ElementName = "ModeloActivo" )]
      [  XmlElement( ElementName = "ModeloActivo"   )]
      public bool gxTpr_Modeloactivo
      {
         get {
            return gxTv_SdtModelo_Modeloactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modeloactivo = value;
            SetDirty("Modeloactivo");
         }

      }

      [  SoapElement( ElementName = "ModeloSegmento" )]
      [  XmlElement( ElementName = "ModeloSegmento"   )]
      public string gxTpr_Modelosegmento
      {
         get {
            return gxTv_SdtModelo_Modelosegmento ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modelosegmento = value;
            SetDirty("Modelosegmento");
         }

      }

      [  SoapElement( ElementName = "ModeloMarca" )]
      [  XmlElement( ElementName = "ModeloMarca"   )]
      public string gxTpr_Modelomarca
      {
         get {
            return gxTv_SdtModelo_Modelomarca ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modelomarca = value;
            SetDirty("Modelomarca");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtModelo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtModelo_Mode_SetNull( )
      {
         gxTv_SdtModelo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtModelo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtModelo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtModelo_Initialized_SetNull( )
      {
         gxTv_SdtModelo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtModelo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloID_Z" )]
      [  XmlElement( ElementName = "ModeloID_Z"   )]
      public int gxTpr_Modeloid_Z
      {
         get {
            return gxTv_SdtModelo_Modeloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modeloid_Z = value;
            SetDirty("Modeloid_Z");
         }

      }

      public void gxTv_SdtModelo_Modeloid_Z_SetNull( )
      {
         gxTv_SdtModelo_Modeloid_Z = 0;
         SetDirty("Modeloid_Z");
         return  ;
      }

      public bool gxTv_SdtModelo_Modeloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloDescripcion_Z" )]
      [  XmlElement( ElementName = "ModeloDescripcion_Z"   )]
      public string gxTpr_Modelodescripcion_Z
      {
         get {
            return gxTv_SdtModelo_Modelodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modelodescripcion_Z = value;
            SetDirty("Modelodescripcion_Z");
         }

      }

      public void gxTv_SdtModelo_Modelodescripcion_Z_SetNull( )
      {
         gxTv_SdtModelo_Modelodescripcion_Z = "";
         SetDirty("Modelodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtModelo_Modelodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloActivo_Z" )]
      [  XmlElement( ElementName = "ModeloActivo_Z"   )]
      public bool gxTpr_Modeloactivo_Z
      {
         get {
            return gxTv_SdtModelo_Modeloactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modeloactivo_Z = value;
            SetDirty("Modeloactivo_Z");
         }

      }

      public void gxTv_SdtModelo_Modeloactivo_Z_SetNull( )
      {
         gxTv_SdtModelo_Modeloactivo_Z = false;
         SetDirty("Modeloactivo_Z");
         return  ;
      }

      public bool gxTv_SdtModelo_Modeloactivo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloSegmento_Z" )]
      [  XmlElement( ElementName = "ModeloSegmento_Z"   )]
      public string gxTpr_Modelosegmento_Z
      {
         get {
            return gxTv_SdtModelo_Modelosegmento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modelosegmento_Z = value;
            SetDirty("Modelosegmento_Z");
         }

      }

      public void gxTv_SdtModelo_Modelosegmento_Z_SetNull( )
      {
         gxTv_SdtModelo_Modelosegmento_Z = "";
         SetDirty("Modelosegmento_Z");
         return  ;
      }

      public bool gxTv_SdtModelo_Modelosegmento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloMarca_Z" )]
      [  XmlElement( ElementName = "ModeloMarca_Z"   )]
      public string gxTpr_Modelomarca_Z
      {
         get {
            return gxTv_SdtModelo_Modelomarca_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtModelo_Modelomarca_Z = value;
            SetDirty("Modelomarca_Z");
         }

      }

      public void gxTv_SdtModelo_Modelomarca_Z_SetNull( )
      {
         gxTv_SdtModelo_Modelomarca_Z = "";
         SetDirty("Modelomarca_Z");
         return  ;
      }

      public bool gxTv_SdtModelo_Modelomarca_Z_IsNull( )
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
         gxTv_SdtModelo_Modelodescripcion = "";
         gxTv_SdtModelo_Modelosegmento = "";
         gxTv_SdtModelo_Modelomarca = "";
         gxTv_SdtModelo_Mode = "";
         gxTv_SdtModelo_Modelodescripcion_Z = "";
         gxTv_SdtModelo_Modelosegmento_Z = "";
         gxTv_SdtModelo_Modelomarca_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "modelo", "GeneXus.Programs.modelo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtModelo_Initialized ;
      private int gxTv_SdtModelo_Modeloid ;
      private int gxTv_SdtModelo_Modeloid_Z ;
      private string gxTv_SdtModelo_Modelosegmento ;
      private string gxTv_SdtModelo_Mode ;
      private string gxTv_SdtModelo_Modelosegmento_Z ;
      private bool gxTv_SdtModelo_Modeloactivo ;
      private bool gxTv_SdtModelo_Modeloactivo_Z ;
      private string gxTv_SdtModelo_Modelodescripcion ;
      private string gxTv_SdtModelo_Modelomarca ;
      private string gxTv_SdtModelo_Modelodescripcion_Z ;
      private string gxTv_SdtModelo_Modelomarca_Z ;
   }

   [DataContract(Name = @"Modelo", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtModelo_RESTInterface : GxGenericCollectionItem<SdtModelo>
   {
      public SdtModelo_RESTInterface( ) : base()
      {
      }

      public SdtModelo_RESTInterface( SdtModelo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ModeloID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Modeloid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Modeloid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Modeloid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ModeloDescripcion" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Modelodescripcion
      {
         get {
            return sdt.gxTpr_Modelodescripcion ;
         }

         set {
            sdt.gxTpr_Modelodescripcion = value;
         }

      }

      [DataMember( Name = "ModeloActivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Modeloactivo
      {
         get {
            return sdt.gxTpr_Modeloactivo ;
         }

         set {
            sdt.gxTpr_Modeloactivo = value;
         }

      }

      [DataMember( Name = "ModeloSegmento" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Modelosegmento
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Modelosegmento) ;
         }

         set {
            sdt.gxTpr_Modelosegmento = value;
         }

      }

      [DataMember( Name = "ModeloMarca" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Modelomarca
      {
         get {
            return sdt.gxTpr_Modelomarca ;
         }

         set {
            sdt.gxTpr_Modelomarca = value;
         }

      }

      public SdtModelo sdt
      {
         get {
            return (SdtModelo)Sdt ;
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
            sdt = new SdtModelo() ;
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

   [DataContract(Name = @"Modelo", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtModelo_RESTLInterface : GxGenericCollectionItem<SdtModelo>
   {
      public SdtModelo_RESTLInterface( ) : base()
      {
      }

      public SdtModelo_RESTLInterface( SdtModelo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ModeloDescripcion" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Modelodescripcion
      {
         get {
            return sdt.gxTpr_Modelodescripcion ;
         }

         set {
            sdt.gxTpr_Modelodescripcion = value;
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

      public SdtModelo sdt
      {
         get {
            return (SdtModelo)Sdt ;
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
            sdt = new SdtModelo() ;
         }
      }

   }

}
