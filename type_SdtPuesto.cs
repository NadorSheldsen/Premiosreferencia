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
   [XmlRoot(ElementName = "Puesto" )]
   [XmlType(TypeName =  "Puesto" , Namespace = "Premios" )]
   [Serializable]
   public class SdtPuesto : GxSilentTrnSdt
   {
      public SdtPuesto( )
      {
      }

      public SdtPuesto( IGxContext context )
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

      public void Load( int AV13PuestoID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV13PuestoID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PuestoID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Puesto");
         metadata.Set("BT", "Puesto");
         metadata.Set("PK", "[ \"PuestoID\" ]");
         metadata.Set("PKAssigned", "[ \"PuestoID\" ]");
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
         state.Add("gxTpr_Puestoid_Z");
         state.Add("gxTpr_Puestodescripcion_Z");
         state.Add("gxTpr_Puestoactivo_Z");
         state.Add("gxTpr_Puestoid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPuesto sdt;
         sdt = (SdtPuesto)(source);
         gxTv_SdtPuesto_Puestoid = sdt.gxTv_SdtPuesto_Puestoid ;
         gxTv_SdtPuesto_Puestodescripcion = sdt.gxTv_SdtPuesto_Puestodescripcion ;
         gxTv_SdtPuesto_Puestoactivo = sdt.gxTv_SdtPuesto_Puestoactivo ;
         gxTv_SdtPuesto_Mode = sdt.gxTv_SdtPuesto_Mode ;
         gxTv_SdtPuesto_Initialized = sdt.gxTv_SdtPuesto_Initialized ;
         gxTv_SdtPuesto_Puestoid_Z = sdt.gxTv_SdtPuesto_Puestoid_Z ;
         gxTv_SdtPuesto_Puestodescripcion_Z = sdt.gxTv_SdtPuesto_Puestodescripcion_Z ;
         gxTv_SdtPuesto_Puestoactivo_Z = sdt.gxTv_SdtPuesto_Puestoactivo_Z ;
         gxTv_SdtPuesto_Puestoid_N = sdt.gxTv_SdtPuesto_Puestoid_N ;
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
         AddObjectProperty("PuestoID", gxTv_SdtPuesto_Puestoid, false, includeNonInitialized);
         AddObjectProperty("PuestoID_N", gxTv_SdtPuesto_Puestoid_N, false, includeNonInitialized);
         AddObjectProperty("PuestoDescripcion", gxTv_SdtPuesto_Puestodescripcion, false, includeNonInitialized);
         AddObjectProperty("PuestoActivo", gxTv_SdtPuesto_Puestoactivo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPuesto_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPuesto_Initialized, false, includeNonInitialized);
            AddObjectProperty("PuestoID_Z", gxTv_SdtPuesto_Puestoid_Z, false, includeNonInitialized);
            AddObjectProperty("PuestoDescripcion_Z", gxTv_SdtPuesto_Puestodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PuestoActivo_Z", gxTv_SdtPuesto_Puestoactivo_Z, false, includeNonInitialized);
            AddObjectProperty("PuestoID_N", gxTv_SdtPuesto_Puestoid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPuesto sdt )
      {
         if ( sdt.IsDirty("PuestoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Puestoid = sdt.gxTv_SdtPuesto_Puestoid ;
         }
         if ( sdt.IsDirty("PuestoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Puestodescripcion = sdt.gxTv_SdtPuesto_Puestodescripcion ;
         }
         if ( sdt.IsDirty("PuestoActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Puestoactivo = sdt.gxTv_SdtPuesto_Puestoactivo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PuestoID" )]
      [  XmlElement( ElementName = "PuestoID"   )]
      public int gxTpr_Puestoid
      {
         get {
            return gxTv_SdtPuesto_Puestoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPuesto_Puestoid != value )
            {
               gxTv_SdtPuesto_Mode = "INS";
               this.gxTv_SdtPuesto_Puestoid_Z_SetNull( );
               this.gxTv_SdtPuesto_Puestodescripcion_Z_SetNull( );
               this.gxTv_SdtPuesto_Puestoactivo_Z_SetNull( );
            }
            gxTv_SdtPuesto_Puestoid = value;
            SetDirty("Puestoid");
         }

      }

      [  SoapElement( ElementName = "PuestoDescripcion" )]
      [  XmlElement( ElementName = "PuestoDescripcion"   )]
      public string gxTpr_Puestodescripcion
      {
         get {
            return gxTv_SdtPuesto_Puestodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Puestodescripcion = value;
            SetDirty("Puestodescripcion");
         }

      }

      [  SoapElement( ElementName = "PuestoActivo" )]
      [  XmlElement( ElementName = "PuestoActivo"   )]
      public bool gxTpr_Puestoactivo
      {
         get {
            return gxTv_SdtPuesto_Puestoactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Puestoactivo = value;
            SetDirty("Puestoactivo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPuesto_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPuesto_Mode_SetNull( )
      {
         gxTv_SdtPuesto_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPuesto_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPuesto_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPuesto_Initialized_SetNull( )
      {
         gxTv_SdtPuesto_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPuesto_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PuestoID_Z" )]
      [  XmlElement( ElementName = "PuestoID_Z"   )]
      public int gxTpr_Puestoid_Z
      {
         get {
            return gxTv_SdtPuesto_Puestoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Puestoid_Z = value;
            SetDirty("Puestoid_Z");
         }

      }

      public void gxTv_SdtPuesto_Puestoid_Z_SetNull( )
      {
         gxTv_SdtPuesto_Puestoid_Z = 0;
         SetDirty("Puestoid_Z");
         return  ;
      }

      public bool gxTv_SdtPuesto_Puestoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PuestoDescripcion_Z" )]
      [  XmlElement( ElementName = "PuestoDescripcion_Z"   )]
      public string gxTpr_Puestodescripcion_Z
      {
         get {
            return gxTv_SdtPuesto_Puestodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Puestodescripcion_Z = value;
            SetDirty("Puestodescripcion_Z");
         }

      }

      public void gxTv_SdtPuesto_Puestodescripcion_Z_SetNull( )
      {
         gxTv_SdtPuesto_Puestodescripcion_Z = "";
         SetDirty("Puestodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtPuesto_Puestodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PuestoActivo_Z" )]
      [  XmlElement( ElementName = "PuestoActivo_Z"   )]
      public bool gxTpr_Puestoactivo_Z
      {
         get {
            return gxTv_SdtPuesto_Puestoactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Puestoactivo_Z = value;
            SetDirty("Puestoactivo_Z");
         }

      }

      public void gxTv_SdtPuesto_Puestoactivo_Z_SetNull( )
      {
         gxTv_SdtPuesto_Puestoactivo_Z = false;
         SetDirty("Puestoactivo_Z");
         return  ;
      }

      public bool gxTv_SdtPuesto_Puestoactivo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PuestoID_N" )]
      [  XmlElement( ElementName = "PuestoID_N"   )]
      public short gxTpr_Puestoid_N
      {
         get {
            return gxTv_SdtPuesto_Puestoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPuesto_Puestoid_N = value;
            SetDirty("Puestoid_N");
         }

      }

      public void gxTv_SdtPuesto_Puestoid_N_SetNull( )
      {
         gxTv_SdtPuesto_Puestoid_N = 0;
         SetDirty("Puestoid_N");
         return  ;
      }

      public bool gxTv_SdtPuesto_Puestoid_N_IsNull( )
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
         gxTv_SdtPuesto_Puestodescripcion = "";
         gxTv_SdtPuesto_Mode = "";
         gxTv_SdtPuesto_Puestodescripcion_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "puesto", "GeneXus.Programs.puesto_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPuesto_Initialized ;
      private short gxTv_SdtPuesto_Puestoid_N ;
      private int gxTv_SdtPuesto_Puestoid ;
      private int gxTv_SdtPuesto_Puestoid_Z ;
      private string gxTv_SdtPuesto_Mode ;
      private bool gxTv_SdtPuesto_Puestoactivo ;
      private bool gxTv_SdtPuesto_Puestoactivo_Z ;
      private string gxTv_SdtPuesto_Puestodescripcion ;
      private string gxTv_SdtPuesto_Puestodescripcion_Z ;
   }

   [DataContract(Name = @"Puesto", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtPuesto_RESTInterface : GxGenericCollectionItem<SdtPuesto>
   {
      public SdtPuesto_RESTInterface( ) : base()
      {
      }

      public SdtPuesto_RESTInterface( SdtPuesto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PuestoID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Puestoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Puestoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Puestoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PuestoDescripcion" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Puestodescripcion
      {
         get {
            return sdt.gxTpr_Puestodescripcion ;
         }

         set {
            sdt.gxTpr_Puestodescripcion = value;
         }

      }

      [DataMember( Name = "PuestoActivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Puestoactivo
      {
         get {
            return sdt.gxTpr_Puestoactivo ;
         }

         set {
            sdt.gxTpr_Puestoactivo = value;
         }

      }

      public SdtPuesto sdt
      {
         get {
            return (SdtPuesto)Sdt ;
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
            sdt = new SdtPuesto() ;
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

   [DataContract(Name = @"Puesto", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtPuesto_RESTLInterface : GxGenericCollectionItem<SdtPuesto>
   {
      public SdtPuesto_RESTLInterface( ) : base()
      {
      }

      public SdtPuesto_RESTLInterface( SdtPuesto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PuestoDescripcion" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Puestodescripcion
      {
         get {
            return sdt.gxTpr_Puestodescripcion ;
         }

         set {
            sdt.gxTpr_Puestodescripcion = value;
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

      public SdtPuesto sdt
      {
         get {
            return (SdtPuesto)Sdt ;
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
            sdt = new SdtPuesto() ;
         }
      }

   }

}
