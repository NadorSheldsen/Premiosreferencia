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
   [XmlRoot(ElementName = "Escolaridad" )]
   [XmlType(TypeName =  "Escolaridad" , Namespace = "Premios" )]
   [Serializable]
   public class SdtEscolaridad : GxSilentTrnSdt
   {
      public SdtEscolaridad( )
      {
      }

      public SdtEscolaridad( IGxContext context )
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

      public void Load( int AV7EscolaridadID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV7EscolaridadID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EscolaridadID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Escolaridad");
         metadata.Set("BT", "Escolaridad");
         metadata.Set("PK", "[ \"EscolaridadID\" ]");
         metadata.Set("PKAssigned", "[ \"EscolaridadID\" ]");
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
         state.Add("gxTpr_Escolaridadid_Z");
         state.Add("gxTpr_Escolaridaddescripcion_Z");
         state.Add("gxTpr_Escolaridadactivo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEscolaridad sdt;
         sdt = (SdtEscolaridad)(source);
         gxTv_SdtEscolaridad_Escolaridadid = sdt.gxTv_SdtEscolaridad_Escolaridadid ;
         gxTv_SdtEscolaridad_Escolaridaddescripcion = sdt.gxTv_SdtEscolaridad_Escolaridaddescripcion ;
         gxTv_SdtEscolaridad_Escolaridadactivo = sdt.gxTv_SdtEscolaridad_Escolaridadactivo ;
         gxTv_SdtEscolaridad_Mode = sdt.gxTv_SdtEscolaridad_Mode ;
         gxTv_SdtEscolaridad_Initialized = sdt.gxTv_SdtEscolaridad_Initialized ;
         gxTv_SdtEscolaridad_Escolaridadid_Z = sdt.gxTv_SdtEscolaridad_Escolaridadid_Z ;
         gxTv_SdtEscolaridad_Escolaridaddescripcion_Z = sdt.gxTv_SdtEscolaridad_Escolaridaddescripcion_Z ;
         gxTv_SdtEscolaridad_Escolaridadactivo_Z = sdt.gxTv_SdtEscolaridad_Escolaridadactivo_Z ;
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
         AddObjectProperty("EscolaridadID", gxTv_SdtEscolaridad_Escolaridadid, false, includeNonInitialized);
         AddObjectProperty("EscolaridadDescripcion", gxTv_SdtEscolaridad_Escolaridaddescripcion, false, includeNonInitialized);
         AddObjectProperty("EscolaridadActivo", gxTv_SdtEscolaridad_Escolaridadactivo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEscolaridad_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEscolaridad_Initialized, false, includeNonInitialized);
            AddObjectProperty("EscolaridadID_Z", gxTv_SdtEscolaridad_Escolaridadid_Z, false, includeNonInitialized);
            AddObjectProperty("EscolaridadDescripcion_Z", gxTv_SdtEscolaridad_Escolaridaddescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("EscolaridadActivo_Z", gxTv_SdtEscolaridad_Escolaridadactivo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEscolaridad sdt )
      {
         if ( sdt.IsDirty("EscolaridadID") )
         {
            sdtIsNull = 0;
            gxTv_SdtEscolaridad_Escolaridadid = sdt.gxTv_SdtEscolaridad_Escolaridadid ;
         }
         if ( sdt.IsDirty("EscolaridadDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtEscolaridad_Escolaridaddescripcion = sdt.gxTv_SdtEscolaridad_Escolaridaddescripcion ;
         }
         if ( sdt.IsDirty("EscolaridadActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtEscolaridad_Escolaridadactivo = sdt.gxTv_SdtEscolaridad_Escolaridadactivo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EscolaridadID" )]
      [  XmlElement( ElementName = "EscolaridadID"   )]
      public int gxTpr_Escolaridadid
      {
         get {
            return gxTv_SdtEscolaridad_Escolaridadid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEscolaridad_Escolaridadid != value )
            {
               gxTv_SdtEscolaridad_Mode = "INS";
               this.gxTv_SdtEscolaridad_Escolaridadid_Z_SetNull( );
               this.gxTv_SdtEscolaridad_Escolaridaddescripcion_Z_SetNull( );
               this.gxTv_SdtEscolaridad_Escolaridadactivo_Z_SetNull( );
            }
            gxTv_SdtEscolaridad_Escolaridadid = value;
            SetDirty("Escolaridadid");
         }

      }

      [  SoapElement( ElementName = "EscolaridadDescripcion" )]
      [  XmlElement( ElementName = "EscolaridadDescripcion"   )]
      public string gxTpr_Escolaridaddescripcion
      {
         get {
            return gxTv_SdtEscolaridad_Escolaridaddescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEscolaridad_Escolaridaddescripcion = value;
            SetDirty("Escolaridaddescripcion");
         }

      }

      [  SoapElement( ElementName = "EscolaridadActivo" )]
      [  XmlElement( ElementName = "EscolaridadActivo"   )]
      public bool gxTpr_Escolaridadactivo
      {
         get {
            return gxTv_SdtEscolaridad_Escolaridadactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEscolaridad_Escolaridadactivo = value;
            SetDirty("Escolaridadactivo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEscolaridad_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEscolaridad_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEscolaridad_Mode_SetNull( )
      {
         gxTv_SdtEscolaridad_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEscolaridad_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEscolaridad_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEscolaridad_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEscolaridad_Initialized_SetNull( )
      {
         gxTv_SdtEscolaridad_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEscolaridad_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EscolaridadID_Z" )]
      [  XmlElement( ElementName = "EscolaridadID_Z"   )]
      public int gxTpr_Escolaridadid_Z
      {
         get {
            return gxTv_SdtEscolaridad_Escolaridadid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEscolaridad_Escolaridadid_Z = value;
            SetDirty("Escolaridadid_Z");
         }

      }

      public void gxTv_SdtEscolaridad_Escolaridadid_Z_SetNull( )
      {
         gxTv_SdtEscolaridad_Escolaridadid_Z = 0;
         SetDirty("Escolaridadid_Z");
         return  ;
      }

      public bool gxTv_SdtEscolaridad_Escolaridadid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EscolaridadDescripcion_Z" )]
      [  XmlElement( ElementName = "EscolaridadDescripcion_Z"   )]
      public string gxTpr_Escolaridaddescripcion_Z
      {
         get {
            return gxTv_SdtEscolaridad_Escolaridaddescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEscolaridad_Escolaridaddescripcion_Z = value;
            SetDirty("Escolaridaddescripcion_Z");
         }

      }

      public void gxTv_SdtEscolaridad_Escolaridaddescripcion_Z_SetNull( )
      {
         gxTv_SdtEscolaridad_Escolaridaddescripcion_Z = "";
         SetDirty("Escolaridaddescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtEscolaridad_Escolaridaddescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EscolaridadActivo_Z" )]
      [  XmlElement( ElementName = "EscolaridadActivo_Z"   )]
      public bool gxTpr_Escolaridadactivo_Z
      {
         get {
            return gxTv_SdtEscolaridad_Escolaridadactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEscolaridad_Escolaridadactivo_Z = value;
            SetDirty("Escolaridadactivo_Z");
         }

      }

      public void gxTv_SdtEscolaridad_Escolaridadactivo_Z_SetNull( )
      {
         gxTv_SdtEscolaridad_Escolaridadactivo_Z = false;
         SetDirty("Escolaridadactivo_Z");
         return  ;
      }

      public bool gxTv_SdtEscolaridad_Escolaridadactivo_Z_IsNull( )
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
         gxTv_SdtEscolaridad_Escolaridaddescripcion = "";
         gxTv_SdtEscolaridad_Mode = "";
         gxTv_SdtEscolaridad_Escolaridaddescripcion_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "escolaridad", "GeneXus.Programs.escolaridad_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtEscolaridad_Initialized ;
      private int gxTv_SdtEscolaridad_Escolaridadid ;
      private int gxTv_SdtEscolaridad_Escolaridadid_Z ;
      private string gxTv_SdtEscolaridad_Mode ;
      private bool gxTv_SdtEscolaridad_Escolaridadactivo ;
      private bool gxTv_SdtEscolaridad_Escolaridadactivo_Z ;
      private string gxTv_SdtEscolaridad_Escolaridaddescripcion ;
      private string gxTv_SdtEscolaridad_Escolaridaddescripcion_Z ;
   }

   [DataContract(Name = @"Escolaridad", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtEscolaridad_RESTInterface : GxGenericCollectionItem<SdtEscolaridad>
   {
      public SdtEscolaridad_RESTInterface( ) : base()
      {
      }

      public SdtEscolaridad_RESTInterface( SdtEscolaridad psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EscolaridadID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Escolaridadid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Escolaridadid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Escolaridadid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EscolaridadDescripcion" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Escolaridaddescripcion
      {
         get {
            return sdt.gxTpr_Escolaridaddescripcion ;
         }

         set {
            sdt.gxTpr_Escolaridaddescripcion = value;
         }

      }

      [DataMember( Name = "EscolaridadActivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Escolaridadactivo
      {
         get {
            return sdt.gxTpr_Escolaridadactivo ;
         }

         set {
            sdt.gxTpr_Escolaridadactivo = value;
         }

      }

      public SdtEscolaridad sdt
      {
         get {
            return (SdtEscolaridad)Sdt ;
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
            sdt = new SdtEscolaridad() ;
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

   [DataContract(Name = @"Escolaridad", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtEscolaridad_RESTLInterface : GxGenericCollectionItem<SdtEscolaridad>
   {
      public SdtEscolaridad_RESTLInterface( ) : base()
      {
      }

      public SdtEscolaridad_RESTLInterface( SdtEscolaridad psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EscolaridadDescripcion" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Escolaridaddescripcion
      {
         get {
            return sdt.gxTpr_Escolaridaddescripcion ;
         }

         set {
            sdt.gxTpr_Escolaridaddescripcion = value;
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

      public SdtEscolaridad sdt
      {
         get {
            return (SdtEscolaridad)Sdt ;
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
            sdt = new SdtEscolaridad() ;
         }
      }

   }

}
