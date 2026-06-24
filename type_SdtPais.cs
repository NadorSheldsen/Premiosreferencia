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
   [XmlRoot(ElementName = "Pais" )]
   [XmlType(TypeName =  "Pais" , Namespace = "Premios" )]
   [Serializable]
   public class SdtPais : GxSilentTrnSdt
   {
      public SdtPais( )
      {
      }

      public SdtPais( IGxContext context )
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

      public void Load( int AV16PaisID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV16PaisID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PaisID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Pais");
         metadata.Set("BT", "Pais");
         metadata.Set("PK", "[ \"PaisID\" ]");
         metadata.Set("PKAssigned", "[ \"PaisID\" ]");
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
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisdescripcion_Z");
         state.Add("gxTpr_Paisactivo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPais sdt;
         sdt = (SdtPais)(source);
         gxTv_SdtPais_Paisid = sdt.gxTv_SdtPais_Paisid ;
         gxTv_SdtPais_Paisdescripcion = sdt.gxTv_SdtPais_Paisdescripcion ;
         gxTv_SdtPais_Paisactivo = sdt.gxTv_SdtPais_Paisactivo ;
         gxTv_SdtPais_Mode = sdt.gxTv_SdtPais_Mode ;
         gxTv_SdtPais_Initialized = sdt.gxTv_SdtPais_Initialized ;
         gxTv_SdtPais_Paisid_Z = sdt.gxTv_SdtPais_Paisid_Z ;
         gxTv_SdtPais_Paisdescripcion_Z = sdt.gxTv_SdtPais_Paisdescripcion_Z ;
         gxTv_SdtPais_Paisactivo_Z = sdt.gxTv_SdtPais_Paisactivo_Z ;
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
         AddObjectProperty("PaisID", gxTv_SdtPais_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisDescripcion", gxTv_SdtPais_Paisdescripcion, false, includeNonInitialized);
         AddObjectProperty("PaisActivo", gxTv_SdtPais_Paisactivo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPais_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPais_Initialized, false, includeNonInitialized);
            AddObjectProperty("PaisID_Z", gxTv_SdtPais_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisDescripcion_Z", gxTv_SdtPais_Paisdescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PaisActivo_Z", gxTv_SdtPais_Paisactivo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPais sdt )
      {
         if ( sdt.IsDirty("PaisID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisid = sdt.gxTv_SdtPais_Paisid ;
         }
         if ( sdt.IsDirty("PaisDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisdescripcion = sdt.gxTv_SdtPais_Paisdescripcion ;
         }
         if ( sdt.IsDirty("PaisActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisactivo = sdt.gxTv_SdtPais_Paisactivo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PaisID" )]
      [  XmlElement( ElementName = "PaisID"   )]
      public int gxTpr_Paisid
      {
         get {
            return gxTv_SdtPais_Paisid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPais_Paisid != value )
            {
               gxTv_SdtPais_Mode = "INS";
               this.gxTv_SdtPais_Paisid_Z_SetNull( );
               this.gxTv_SdtPais_Paisdescripcion_Z_SetNull( );
               this.gxTv_SdtPais_Paisactivo_Z_SetNull( );
            }
            gxTv_SdtPais_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisDescripcion" )]
      [  XmlElement( ElementName = "PaisDescripcion"   )]
      public string gxTpr_Paisdescripcion
      {
         get {
            return gxTv_SdtPais_Paisdescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisdescripcion = value;
            SetDirty("Paisdescripcion");
         }

      }

      [  SoapElement( ElementName = "PaisActivo" )]
      [  XmlElement( ElementName = "PaisActivo"   )]
      public bool gxTpr_Paisactivo
      {
         get {
            return gxTv_SdtPais_Paisactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisactivo = value;
            SetDirty("Paisactivo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPais_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPais_Mode_SetNull( )
      {
         gxTv_SdtPais_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPais_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPais_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPais_Initialized_SetNull( )
      {
         gxTv_SdtPais_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPais_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisID_Z" )]
      [  XmlElement( ElementName = "PaisID_Z"   )]
      public int gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtPais_Paisid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtPais_Paisid_Z_SetNull( )
      {
         gxTv_SdtPais_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisDescripcion_Z" )]
      [  XmlElement( ElementName = "PaisDescripcion_Z"   )]
      public string gxTpr_Paisdescripcion_Z
      {
         get {
            return gxTv_SdtPais_Paisdescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisdescripcion_Z = value;
            SetDirty("Paisdescripcion_Z");
         }

      }

      public void gxTv_SdtPais_Paisdescripcion_Z_SetNull( )
      {
         gxTv_SdtPais_Paisdescripcion_Z = "";
         SetDirty("Paisdescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisdescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisActivo_Z" )]
      [  XmlElement( ElementName = "PaisActivo_Z"   )]
      public bool gxTpr_Paisactivo_Z
      {
         get {
            return gxTv_SdtPais_Paisactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPais_Paisactivo_Z = value;
            SetDirty("Paisactivo_Z");
         }

      }

      public void gxTv_SdtPais_Paisactivo_Z_SetNull( )
      {
         gxTv_SdtPais_Paisactivo_Z = false;
         SetDirty("Paisactivo_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisactivo_Z_IsNull( )
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
         gxTv_SdtPais_Paisdescripcion = "";
         gxTv_SdtPais_Mode = "";
         gxTv_SdtPais_Paisdescripcion_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "pais", "GeneXus.Programs.pais_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPais_Initialized ;
      private int gxTv_SdtPais_Paisid ;
      private int gxTv_SdtPais_Paisid_Z ;
      private string gxTv_SdtPais_Mode ;
      private bool gxTv_SdtPais_Paisactivo ;
      private bool gxTv_SdtPais_Paisactivo_Z ;
      private string gxTv_SdtPais_Paisdescripcion ;
      private string gxTv_SdtPais_Paisdescripcion_Z ;
   }

   [DataContract(Name = @"Pais", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtPais_RESTInterface : GxGenericCollectionItem<SdtPais>
   {
      public SdtPais_RESTInterface( ) : base()
      {
      }

      public SdtPais_RESTInterface( SdtPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisID" , Order = 0 )]
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

      [DataMember( Name = "PaisDescripcion" , Order = 1 )]
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

      [DataMember( Name = "PaisActivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Paisactivo
      {
         get {
            return sdt.gxTpr_Paisactivo ;
         }

         set {
            sdt.gxTpr_Paisactivo = value;
         }

      }

      public SdtPais sdt
      {
         get {
            return (SdtPais)Sdt ;
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
            sdt = new SdtPais() ;
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

   [DataContract(Name = @"Pais", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtPais_RESTLInterface : GxGenericCollectionItem<SdtPais>
   {
      public SdtPais_RESTLInterface( ) : base()
      {
      }

      public SdtPais_RESTLInterface( SdtPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisDescripcion" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtPais sdt
      {
         get {
            return (SdtPais)Sdt ;
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
            sdt = new SdtPais() ;
         }
      }

   }

}
