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
   [XmlRoot(ElementName = "MotivoRechazo" )]
   [XmlType(TypeName =  "MotivoRechazo" , Namespace = "Premios" )]
   [Serializable]
   public class SdtMotivoRechazo : GxSilentTrnSdt
   {
      public SdtMotivoRechazo( )
      {
      }

      public SdtMotivoRechazo( IGxContext context )
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

      public void Load( int AV19MotivoRechazoID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV19MotivoRechazoID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MotivoRechazoID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "MotivoRechazo");
         metadata.Set("BT", "MotivoRechazo");
         metadata.Set("PK", "[ \"MotivoRechazoID\" ]");
         metadata.Set("PKAssigned", "[ \"MotivoRechazoID\" ]");
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
         state.Add("gxTpr_Motivorechazoid_Z");
         state.Add("gxTpr_Motivorechazodescripcion_Z");
         state.Add("gxTpr_Motivorechazoactivo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtMotivoRechazo sdt;
         sdt = (SdtMotivoRechazo)(source);
         gxTv_SdtMotivoRechazo_Motivorechazoid = sdt.gxTv_SdtMotivoRechazo_Motivorechazoid ;
         gxTv_SdtMotivoRechazo_Motivorechazodescripcion = sdt.gxTv_SdtMotivoRechazo_Motivorechazodescripcion ;
         gxTv_SdtMotivoRechazo_Motivorechazoactivo = sdt.gxTv_SdtMotivoRechazo_Motivorechazoactivo ;
         gxTv_SdtMotivoRechazo_Mode = sdt.gxTv_SdtMotivoRechazo_Mode ;
         gxTv_SdtMotivoRechazo_Initialized = sdt.gxTv_SdtMotivoRechazo_Initialized ;
         gxTv_SdtMotivoRechazo_Motivorechazoid_Z = sdt.gxTv_SdtMotivoRechazo_Motivorechazoid_Z ;
         gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z = sdt.gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z ;
         gxTv_SdtMotivoRechazo_Motivorechazoactivo_Z = sdt.gxTv_SdtMotivoRechazo_Motivorechazoactivo_Z ;
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
         AddObjectProperty("MotivoRechazoID", gxTv_SdtMotivoRechazo_Motivorechazoid, false, includeNonInitialized);
         AddObjectProperty("MotivoRechazoDescripcion", gxTv_SdtMotivoRechazo_Motivorechazodescripcion, false, includeNonInitialized);
         AddObjectProperty("MotivoRechazoActivo", gxTv_SdtMotivoRechazo_Motivorechazoactivo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtMotivoRechazo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtMotivoRechazo_Initialized, false, includeNonInitialized);
            AddObjectProperty("MotivoRechazoID_Z", gxTv_SdtMotivoRechazo_Motivorechazoid_Z, false, includeNonInitialized);
            AddObjectProperty("MotivoRechazoDescripcion_Z", gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("MotivoRechazoActivo_Z", gxTv_SdtMotivoRechazo_Motivorechazoactivo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtMotivoRechazo sdt )
      {
         if ( sdt.IsDirty("MotivoRechazoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtMotivoRechazo_Motivorechazoid = sdt.gxTv_SdtMotivoRechazo_Motivorechazoid ;
         }
         if ( sdt.IsDirty("MotivoRechazoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtMotivoRechazo_Motivorechazodescripcion = sdt.gxTv_SdtMotivoRechazo_Motivorechazodescripcion ;
         }
         if ( sdt.IsDirty("MotivoRechazoActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtMotivoRechazo_Motivorechazoactivo = sdt.gxTv_SdtMotivoRechazo_Motivorechazoactivo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MotivoRechazoID" )]
      [  XmlElement( ElementName = "MotivoRechazoID"   )]
      public int gxTpr_Motivorechazoid
      {
         get {
            return gxTv_SdtMotivoRechazo_Motivorechazoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtMotivoRechazo_Motivorechazoid != value )
            {
               gxTv_SdtMotivoRechazo_Mode = "INS";
               this.gxTv_SdtMotivoRechazo_Motivorechazoid_Z_SetNull( );
               this.gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z_SetNull( );
               this.gxTv_SdtMotivoRechazo_Motivorechazoactivo_Z_SetNull( );
            }
            gxTv_SdtMotivoRechazo_Motivorechazoid = value;
            SetDirty("Motivorechazoid");
         }

      }

      [  SoapElement( ElementName = "MotivoRechazoDescripcion" )]
      [  XmlElement( ElementName = "MotivoRechazoDescripcion"   )]
      public string gxTpr_Motivorechazodescripcion
      {
         get {
            return gxTv_SdtMotivoRechazo_Motivorechazodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMotivoRechazo_Motivorechazodescripcion = value;
            SetDirty("Motivorechazodescripcion");
         }

      }

      [  SoapElement( ElementName = "MotivoRechazoActivo" )]
      [  XmlElement( ElementName = "MotivoRechazoActivo"   )]
      public bool gxTpr_Motivorechazoactivo
      {
         get {
            return gxTv_SdtMotivoRechazo_Motivorechazoactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMotivoRechazo_Motivorechazoactivo = value;
            SetDirty("Motivorechazoactivo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtMotivoRechazo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMotivoRechazo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtMotivoRechazo_Mode_SetNull( )
      {
         gxTv_SdtMotivoRechazo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtMotivoRechazo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtMotivoRechazo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMotivoRechazo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtMotivoRechazo_Initialized_SetNull( )
      {
         gxTv_SdtMotivoRechazo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtMotivoRechazo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MotivoRechazoID_Z" )]
      [  XmlElement( ElementName = "MotivoRechazoID_Z"   )]
      public int gxTpr_Motivorechazoid_Z
      {
         get {
            return gxTv_SdtMotivoRechazo_Motivorechazoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMotivoRechazo_Motivorechazoid_Z = value;
            SetDirty("Motivorechazoid_Z");
         }

      }

      public void gxTv_SdtMotivoRechazo_Motivorechazoid_Z_SetNull( )
      {
         gxTv_SdtMotivoRechazo_Motivorechazoid_Z = 0;
         SetDirty("Motivorechazoid_Z");
         return  ;
      }

      public bool gxTv_SdtMotivoRechazo_Motivorechazoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MotivoRechazoDescripcion_Z" )]
      [  XmlElement( ElementName = "MotivoRechazoDescripcion_Z"   )]
      public string gxTpr_Motivorechazodescripcion_Z
      {
         get {
            return gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z = value;
            SetDirty("Motivorechazodescripcion_Z");
         }

      }

      public void gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z_SetNull( )
      {
         gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z = "";
         SetDirty("Motivorechazodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MotivoRechazoActivo_Z" )]
      [  XmlElement( ElementName = "MotivoRechazoActivo_Z"   )]
      public bool gxTpr_Motivorechazoactivo_Z
      {
         get {
            return gxTv_SdtMotivoRechazo_Motivorechazoactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMotivoRechazo_Motivorechazoactivo_Z = value;
            SetDirty("Motivorechazoactivo_Z");
         }

      }

      public void gxTv_SdtMotivoRechazo_Motivorechazoactivo_Z_SetNull( )
      {
         gxTv_SdtMotivoRechazo_Motivorechazoactivo_Z = false;
         SetDirty("Motivorechazoactivo_Z");
         return  ;
      }

      public bool gxTv_SdtMotivoRechazo_Motivorechazoactivo_Z_IsNull( )
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
         gxTv_SdtMotivoRechazo_Motivorechazodescripcion = "";
         gxTv_SdtMotivoRechazo_Mode = "";
         gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "motivorechazo", "GeneXus.Programs.motivorechazo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtMotivoRechazo_Initialized ;
      private int gxTv_SdtMotivoRechazo_Motivorechazoid ;
      private int gxTv_SdtMotivoRechazo_Motivorechazoid_Z ;
      private string gxTv_SdtMotivoRechazo_Mode ;
      private bool gxTv_SdtMotivoRechazo_Motivorechazoactivo ;
      private bool gxTv_SdtMotivoRechazo_Motivorechazoactivo_Z ;
      private string gxTv_SdtMotivoRechazo_Motivorechazodescripcion ;
      private string gxTv_SdtMotivoRechazo_Motivorechazodescripcion_Z ;
   }

   [DataContract(Name = @"MotivoRechazo", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtMotivoRechazo_RESTInterface : GxGenericCollectionItem<SdtMotivoRechazo>
   {
      public SdtMotivoRechazo_RESTInterface( ) : base()
      {
      }

      public SdtMotivoRechazo_RESTInterface( SdtMotivoRechazo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MotivoRechazoID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Motivorechazoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Motivorechazoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Motivorechazoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MotivoRechazoDescripcion" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Motivorechazodescripcion
      {
         get {
            return sdt.gxTpr_Motivorechazodescripcion ;
         }

         set {
            sdt.gxTpr_Motivorechazodescripcion = value;
         }

      }

      [DataMember( Name = "MotivoRechazoActivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Motivorechazoactivo
      {
         get {
            return sdt.gxTpr_Motivorechazoactivo ;
         }

         set {
            sdt.gxTpr_Motivorechazoactivo = value;
         }

      }

      public SdtMotivoRechazo sdt
      {
         get {
            return (SdtMotivoRechazo)Sdt ;
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
            sdt = new SdtMotivoRechazo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
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

   [DataContract(Name = @"MotivoRechazo", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtMotivoRechazo_RESTLInterface : GxGenericCollectionItem<SdtMotivoRechazo>
   {
      public SdtMotivoRechazo_RESTLInterface( ) : base()
      {
      }

      public SdtMotivoRechazo_RESTLInterface( SdtMotivoRechazo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MotivoRechazoDescripcion" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Motivorechazodescripcion
      {
         get {
            return sdt.gxTpr_Motivorechazodescripcion ;
         }

         set {
            sdt.gxTpr_Motivorechazodescripcion = value;
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

      public SdtMotivoRechazo sdt
      {
         get {
            return (SdtMotivoRechazo)Sdt ;
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
            sdt = new SdtMotivoRechazo() ;
         }
      }

   }

}
