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
   [XmlRoot(ElementName = "Ciudad" )]
   [XmlType(TypeName =  "Ciudad" , Namespace = "Premios" )]
   [Serializable]
   public class SdtCiudad : GxSilentTrnSdt
   {
      public SdtCiudad( )
      {
      }

      public SdtCiudad( IGxContext context )
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

      public void Load( int AV4CiudadID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV4CiudadID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CiudadID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Ciudad");
         metadata.Set("BT", "Ciudad");
         metadata.Set("PK", "[ \"CiudadID\" ]");
         metadata.Set("PKAssigned", "[ \"CiudadID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EstadoID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Ciudadid_Z");
         state.Add("gxTpr_Estadoid_Z");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Ciudaddescripcion_Z");
         state.Add("gxTpr_Ciudadactivo_Z");
         state.Add("gxTpr_Ciudadid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCiudad sdt;
         sdt = (SdtCiudad)(source);
         gxTv_SdtCiudad_Ciudadid = sdt.gxTv_SdtCiudad_Ciudadid ;
         gxTv_SdtCiudad_Estadoid = sdt.gxTv_SdtCiudad_Estadoid ;
         gxTv_SdtCiudad_Paisid = sdt.gxTv_SdtCiudad_Paisid ;
         gxTv_SdtCiudad_Ciudaddescripcion = sdt.gxTv_SdtCiudad_Ciudaddescripcion ;
         gxTv_SdtCiudad_Ciudadactivo = sdt.gxTv_SdtCiudad_Ciudadactivo ;
         gxTv_SdtCiudad_Mode = sdt.gxTv_SdtCiudad_Mode ;
         gxTv_SdtCiudad_Initialized = sdt.gxTv_SdtCiudad_Initialized ;
         gxTv_SdtCiudad_Ciudadid_Z = sdt.gxTv_SdtCiudad_Ciudadid_Z ;
         gxTv_SdtCiudad_Estadoid_Z = sdt.gxTv_SdtCiudad_Estadoid_Z ;
         gxTv_SdtCiudad_Paisid_Z = sdt.gxTv_SdtCiudad_Paisid_Z ;
         gxTv_SdtCiudad_Ciudaddescripcion_Z = sdt.gxTv_SdtCiudad_Ciudaddescripcion_Z ;
         gxTv_SdtCiudad_Ciudadactivo_Z = sdt.gxTv_SdtCiudad_Ciudadactivo_Z ;
         gxTv_SdtCiudad_Ciudadid_N = sdt.gxTv_SdtCiudad_Ciudadid_N ;
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
         AddObjectProperty("CiudadID", gxTv_SdtCiudad_Ciudadid, false, includeNonInitialized);
         AddObjectProperty("CiudadID_N", gxTv_SdtCiudad_Ciudadid_N, false, includeNonInitialized);
         AddObjectProperty("EstadoID", gxTv_SdtCiudad_Estadoid, false, includeNonInitialized);
         AddObjectProperty("PaisID", gxTv_SdtCiudad_Paisid, false, includeNonInitialized);
         AddObjectProperty("CiudadDescripcion", gxTv_SdtCiudad_Ciudaddescripcion, false, includeNonInitialized);
         AddObjectProperty("CiudadActivo", gxTv_SdtCiudad_Ciudadactivo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCiudad_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCiudad_Initialized, false, includeNonInitialized);
            AddObjectProperty("CiudadID_Z", gxTv_SdtCiudad_Ciudadid_Z, false, includeNonInitialized);
            AddObjectProperty("EstadoID_Z", gxTv_SdtCiudad_Estadoid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisID_Z", gxTv_SdtCiudad_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("CiudadDescripcion_Z", gxTv_SdtCiudad_Ciudaddescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("CiudadActivo_Z", gxTv_SdtCiudad_Ciudadactivo_Z, false, includeNonInitialized);
            AddObjectProperty("CiudadID_N", gxTv_SdtCiudad_Ciudadid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCiudad sdt )
      {
         if ( sdt.IsDirty("CiudadID") )
         {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Ciudadid = sdt.gxTv_SdtCiudad_Ciudadid ;
         }
         if ( sdt.IsDirty("EstadoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Estadoid = sdt.gxTv_SdtCiudad_Estadoid ;
         }
         if ( sdt.IsDirty("PaisID") )
         {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Paisid = sdt.gxTv_SdtCiudad_Paisid ;
         }
         if ( sdt.IsDirty("CiudadDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Ciudaddescripcion = sdt.gxTv_SdtCiudad_Ciudaddescripcion ;
         }
         if ( sdt.IsDirty("CiudadActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Ciudadactivo = sdt.gxTv_SdtCiudad_Ciudadactivo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CiudadID" )]
      [  XmlElement( ElementName = "CiudadID"   )]
      public int gxTpr_Ciudadid
      {
         get {
            return gxTv_SdtCiudad_Ciudadid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCiudad_Ciudadid != value )
            {
               gxTv_SdtCiudad_Mode = "INS";
               this.gxTv_SdtCiudad_Ciudadid_Z_SetNull( );
               this.gxTv_SdtCiudad_Estadoid_Z_SetNull( );
               this.gxTv_SdtCiudad_Paisid_Z_SetNull( );
               this.gxTv_SdtCiudad_Ciudaddescripcion_Z_SetNull( );
               this.gxTv_SdtCiudad_Ciudadactivo_Z_SetNull( );
            }
            gxTv_SdtCiudad_Ciudadid = value;
            SetDirty("Ciudadid");
         }

      }

      [  SoapElement( ElementName = "EstadoID" )]
      [  XmlElement( ElementName = "EstadoID"   )]
      public int gxTpr_Estadoid
      {
         get {
            return gxTv_SdtCiudad_Estadoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Estadoid = value;
            SetDirty("Estadoid");
         }

      }

      [  SoapElement( ElementName = "PaisID" )]
      [  XmlElement( ElementName = "PaisID"   )]
      public int gxTpr_Paisid
      {
         get {
            return gxTv_SdtCiudad_Paisid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "CiudadDescripcion" )]
      [  XmlElement( ElementName = "CiudadDescripcion"   )]
      public string gxTpr_Ciudaddescripcion
      {
         get {
            return gxTv_SdtCiudad_Ciudaddescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Ciudaddescripcion = value;
            SetDirty("Ciudaddescripcion");
         }

      }

      [  SoapElement( ElementName = "CiudadActivo" )]
      [  XmlElement( ElementName = "CiudadActivo"   )]
      public bool gxTpr_Ciudadactivo
      {
         get {
            return gxTv_SdtCiudad_Ciudadactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Ciudadactivo = value;
            SetDirty("Ciudadactivo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCiudad_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCiudad_Mode_SetNull( )
      {
         gxTv_SdtCiudad_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCiudad_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCiudad_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCiudad_Initialized_SetNull( )
      {
         gxTv_SdtCiudad_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCiudad_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadID_Z" )]
      [  XmlElement( ElementName = "CiudadID_Z"   )]
      public int gxTpr_Ciudadid_Z
      {
         get {
            return gxTv_SdtCiudad_Ciudadid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Ciudadid_Z = value;
            SetDirty("Ciudadid_Z");
         }

      }

      public void gxTv_SdtCiudad_Ciudadid_Z_SetNull( )
      {
         gxTv_SdtCiudad_Ciudadid_Z = 0;
         SetDirty("Ciudadid_Z");
         return  ;
      }

      public bool gxTv_SdtCiudad_Ciudadid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoID_Z" )]
      [  XmlElement( ElementName = "EstadoID_Z"   )]
      public int gxTpr_Estadoid_Z
      {
         get {
            return gxTv_SdtCiudad_Estadoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Estadoid_Z = value;
            SetDirty("Estadoid_Z");
         }

      }

      public void gxTv_SdtCiudad_Estadoid_Z_SetNull( )
      {
         gxTv_SdtCiudad_Estadoid_Z = 0;
         SetDirty("Estadoid_Z");
         return  ;
      }

      public bool gxTv_SdtCiudad_Estadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisID_Z" )]
      [  XmlElement( ElementName = "PaisID_Z"   )]
      public int gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtCiudad_Paisid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtCiudad_Paisid_Z_SetNull( )
      {
         gxTv_SdtCiudad_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtCiudad_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadDescripcion_Z" )]
      [  XmlElement( ElementName = "CiudadDescripcion_Z"   )]
      public string gxTpr_Ciudaddescripcion_Z
      {
         get {
            return gxTv_SdtCiudad_Ciudaddescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Ciudaddescripcion_Z = value;
            SetDirty("Ciudaddescripcion_Z");
         }

      }

      public void gxTv_SdtCiudad_Ciudaddescripcion_Z_SetNull( )
      {
         gxTv_SdtCiudad_Ciudaddescripcion_Z = "";
         SetDirty("Ciudaddescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtCiudad_Ciudaddescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadActivo_Z" )]
      [  XmlElement( ElementName = "CiudadActivo_Z"   )]
      public bool gxTpr_Ciudadactivo_Z
      {
         get {
            return gxTv_SdtCiudad_Ciudadactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Ciudadactivo_Z = value;
            SetDirty("Ciudadactivo_Z");
         }

      }

      public void gxTv_SdtCiudad_Ciudadactivo_Z_SetNull( )
      {
         gxTv_SdtCiudad_Ciudadactivo_Z = false;
         SetDirty("Ciudadactivo_Z");
         return  ;
      }

      public bool gxTv_SdtCiudad_Ciudadactivo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadID_N" )]
      [  XmlElement( ElementName = "CiudadID_N"   )]
      public short gxTpr_Ciudadid_N
      {
         get {
            return gxTv_SdtCiudad_Ciudadid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCiudad_Ciudadid_N = value;
            SetDirty("Ciudadid_N");
         }

      }

      public void gxTv_SdtCiudad_Ciudadid_N_SetNull( )
      {
         gxTv_SdtCiudad_Ciudadid_N = 0;
         SetDirty("Ciudadid_N");
         return  ;
      }

      public bool gxTv_SdtCiudad_Ciudadid_N_IsNull( )
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
         gxTv_SdtCiudad_Ciudaddescripcion = "";
         gxTv_SdtCiudad_Mode = "";
         gxTv_SdtCiudad_Ciudaddescripcion_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "ciudad", "GeneXus.Programs.ciudad_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtCiudad_Initialized ;
      private short gxTv_SdtCiudad_Ciudadid_N ;
      private int gxTv_SdtCiudad_Ciudadid ;
      private int gxTv_SdtCiudad_Estadoid ;
      private int gxTv_SdtCiudad_Paisid ;
      private int gxTv_SdtCiudad_Ciudadid_Z ;
      private int gxTv_SdtCiudad_Estadoid_Z ;
      private int gxTv_SdtCiudad_Paisid_Z ;
      private string gxTv_SdtCiudad_Mode ;
      private bool gxTv_SdtCiudad_Ciudadactivo ;
      private bool gxTv_SdtCiudad_Ciudadactivo_Z ;
      private string gxTv_SdtCiudad_Ciudaddescripcion ;
      private string gxTv_SdtCiudad_Ciudaddescripcion_Z ;
   }

   [DataContract(Name = @"Ciudad", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtCiudad_RESTInterface : GxGenericCollectionItem<SdtCiudad>
   {
      public SdtCiudad_RESTInterface( ) : base()
      {
      }

      public SdtCiudad_RESTInterface( SdtCiudad psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CiudadID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ciudadid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ciudadid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Ciudadid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EstadoID" , Order = 1 )]
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

      [DataMember( Name = "PaisID" , Order = 2 )]
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

      [DataMember( Name = "CiudadDescripcion" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Ciudaddescripcion
      {
         get {
            return sdt.gxTpr_Ciudaddescripcion ;
         }

         set {
            sdt.gxTpr_Ciudaddescripcion = value;
         }

      }

      [DataMember( Name = "CiudadActivo" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Ciudadactivo
      {
         get {
            return sdt.gxTpr_Ciudadactivo ;
         }

         set {
            sdt.gxTpr_Ciudadactivo = value;
         }

      }

      public SdtCiudad sdt
      {
         get {
            return (SdtCiudad)Sdt ;
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
            sdt = new SdtCiudad() ;
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

   [DataContract(Name = @"Ciudad", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtCiudad_RESTLInterface : GxGenericCollectionItem<SdtCiudad>
   {
      public SdtCiudad_RESTLInterface( ) : base()
      {
      }

      public SdtCiudad_RESTLInterface( SdtCiudad psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CiudadDescripcion" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ciudaddescripcion
      {
         get {
            return sdt.gxTpr_Ciudaddescripcion ;
         }

         set {
            sdt.gxTpr_Ciudaddescripcion = value;
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

      public SdtCiudad sdt
      {
         get {
            return (SdtCiudad)Sdt ;
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
            sdt = new SdtCiudad() ;
         }
      }

   }

}
