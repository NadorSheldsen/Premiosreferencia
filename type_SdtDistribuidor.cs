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
   [XmlRoot(ElementName = "Distribuidor" )]
   [XmlType(TypeName =  "Distribuidor" , Namespace = "Premios" )]
   [Serializable]
   public class SdtDistribuidor : GxSilentTrnSdt
   {
      public SdtDistribuidor( )
      {
      }

      public SdtDistribuidor( IGxContext context )
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

      public void Load( int AV10DistribuidorID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV10DistribuidorID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DistribuidorID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Distribuidor");
         metadata.Set("BT", "Distribuidor");
         metadata.Set("PK", "[ \"DistribuidorID\" ]");
         metadata.Set("PKAssigned", "[ \"DistribuidorID\" ]");
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
         state.Add("gxTpr_Distribuidorid_Z");
         state.Add("gxTpr_Distribuidordescripcion_Z");
         state.Add("gxTpr_Distribuidorrfc_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDistribuidor sdt;
         sdt = (SdtDistribuidor)(source);
         gxTv_SdtDistribuidor_Distribuidorid = sdt.gxTv_SdtDistribuidor_Distribuidorid ;
         gxTv_SdtDistribuidor_Distribuidordescripcion = sdt.gxTv_SdtDistribuidor_Distribuidordescripcion ;
         gxTv_SdtDistribuidor_Distribuidorrfc = sdt.gxTv_SdtDistribuidor_Distribuidorrfc ;
         gxTv_SdtDistribuidor_Mode = sdt.gxTv_SdtDistribuidor_Mode ;
         gxTv_SdtDistribuidor_Initialized = sdt.gxTv_SdtDistribuidor_Initialized ;
         gxTv_SdtDistribuidor_Distribuidorid_Z = sdt.gxTv_SdtDistribuidor_Distribuidorid_Z ;
         gxTv_SdtDistribuidor_Distribuidordescripcion_Z = sdt.gxTv_SdtDistribuidor_Distribuidordescripcion_Z ;
         gxTv_SdtDistribuidor_Distribuidorrfc_Z = sdt.gxTv_SdtDistribuidor_Distribuidorrfc_Z ;
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
         AddObjectProperty("DistribuidorID", gxTv_SdtDistribuidor_Distribuidorid, false, includeNonInitialized);
         AddObjectProperty("DistribuidorDescripcion", gxTv_SdtDistribuidor_Distribuidordescripcion, false, includeNonInitialized);
         AddObjectProperty("DistribuidorRFC", gxTv_SdtDistribuidor_Distribuidorrfc, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDistribuidor_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDistribuidor_Initialized, false, includeNonInitialized);
            AddObjectProperty("DistribuidorID_Z", gxTv_SdtDistribuidor_Distribuidorid_Z, false, includeNonInitialized);
            AddObjectProperty("DistribuidorDescripcion_Z", gxTv_SdtDistribuidor_Distribuidordescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("DistribuidorRFC_Z", gxTv_SdtDistribuidor_Distribuidorrfc_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDistribuidor sdt )
      {
         if ( sdt.IsDirty("DistribuidorID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidor_Distribuidorid = sdt.gxTv_SdtDistribuidor_Distribuidorid ;
         }
         if ( sdt.IsDirty("DistribuidorDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidor_Distribuidordescripcion = sdt.gxTv_SdtDistribuidor_Distribuidordescripcion ;
         }
         if ( sdt.IsDirty("DistribuidorRFC") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidor_Distribuidorrfc = sdt.gxTv_SdtDistribuidor_Distribuidorrfc ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DistribuidorID" )]
      [  XmlElement( ElementName = "DistribuidorID"   )]
      public int gxTpr_Distribuidorid
      {
         get {
            return gxTv_SdtDistribuidor_Distribuidorid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtDistribuidor_Distribuidorid != value )
            {
               gxTv_SdtDistribuidor_Mode = "INS";
               this.gxTv_SdtDistribuidor_Distribuidorid_Z_SetNull( );
               this.gxTv_SdtDistribuidor_Distribuidordescripcion_Z_SetNull( );
               this.gxTv_SdtDistribuidor_Distribuidorrfc_Z_SetNull( );
            }
            gxTv_SdtDistribuidor_Distribuidorid = value;
            SetDirty("Distribuidorid");
         }

      }

      [  SoapElement( ElementName = "DistribuidorDescripcion" )]
      [  XmlElement( ElementName = "DistribuidorDescripcion"   )]
      public string gxTpr_Distribuidordescripcion
      {
         get {
            return gxTv_SdtDistribuidor_Distribuidordescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidor_Distribuidordescripcion = value;
            SetDirty("Distribuidordescripcion");
         }

      }

      [  SoapElement( ElementName = "DistribuidorRFC" )]
      [  XmlElement( ElementName = "DistribuidorRFC"   )]
      public string gxTpr_Distribuidorrfc
      {
         get {
            return gxTv_SdtDistribuidor_Distribuidorrfc ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidor_Distribuidorrfc = value;
            SetDirty("Distribuidorrfc");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDistribuidor_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidor_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDistribuidor_Mode_SetNull( )
      {
         gxTv_SdtDistribuidor_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDistribuidor_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDistribuidor_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidor_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDistribuidor_Initialized_SetNull( )
      {
         gxTv_SdtDistribuidor_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDistribuidor_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DistribuidorID_Z" )]
      [  XmlElement( ElementName = "DistribuidorID_Z"   )]
      public int gxTpr_Distribuidorid_Z
      {
         get {
            return gxTv_SdtDistribuidor_Distribuidorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidor_Distribuidorid_Z = value;
            SetDirty("Distribuidorid_Z");
         }

      }

      public void gxTv_SdtDistribuidor_Distribuidorid_Z_SetNull( )
      {
         gxTv_SdtDistribuidor_Distribuidorid_Z = 0;
         SetDirty("Distribuidorid_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidor_Distribuidorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DistribuidorDescripcion_Z" )]
      [  XmlElement( ElementName = "DistribuidorDescripcion_Z"   )]
      public string gxTpr_Distribuidordescripcion_Z
      {
         get {
            return gxTv_SdtDistribuidor_Distribuidordescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidor_Distribuidordescripcion_Z = value;
            SetDirty("Distribuidordescripcion_Z");
         }

      }

      public void gxTv_SdtDistribuidor_Distribuidordescripcion_Z_SetNull( )
      {
         gxTv_SdtDistribuidor_Distribuidordescripcion_Z = "";
         SetDirty("Distribuidordescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidor_Distribuidordescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DistribuidorRFC_Z" )]
      [  XmlElement( ElementName = "DistribuidorRFC_Z"   )]
      public string gxTpr_Distribuidorrfc_Z
      {
         get {
            return gxTv_SdtDistribuidor_Distribuidorrfc_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidor_Distribuidorrfc_Z = value;
            SetDirty("Distribuidorrfc_Z");
         }

      }

      public void gxTv_SdtDistribuidor_Distribuidorrfc_Z_SetNull( )
      {
         gxTv_SdtDistribuidor_Distribuidorrfc_Z = "";
         SetDirty("Distribuidorrfc_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidor_Distribuidorrfc_Z_IsNull( )
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
         gxTv_SdtDistribuidor_Distribuidordescripcion = "";
         gxTv_SdtDistribuidor_Distribuidorrfc = "";
         gxTv_SdtDistribuidor_Mode = "";
         gxTv_SdtDistribuidor_Distribuidordescripcion_Z = "";
         gxTv_SdtDistribuidor_Distribuidorrfc_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "distribuidor", "GeneXus.Programs.distribuidor_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtDistribuidor_Initialized ;
      private int gxTv_SdtDistribuidor_Distribuidorid ;
      private int gxTv_SdtDistribuidor_Distribuidorid_Z ;
      private string gxTv_SdtDistribuidor_Distribuidorrfc ;
      private string gxTv_SdtDistribuidor_Mode ;
      private string gxTv_SdtDistribuidor_Distribuidorrfc_Z ;
      private string gxTv_SdtDistribuidor_Distribuidordescripcion ;
      private string gxTv_SdtDistribuidor_Distribuidordescripcion_Z ;
   }

   [DataContract(Name = @"Distribuidor", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtDistribuidor_RESTInterface : GxGenericCollectionItem<SdtDistribuidor>
   {
      public SdtDistribuidor_RESTInterface( ) : base()
      {
      }

      public SdtDistribuidor_RESTInterface( SdtDistribuidor psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DistribuidorID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Distribuidorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Distribuidorid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Distribuidorid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "DistribuidorDescripcion" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Distribuidordescripcion
      {
         get {
            return sdt.gxTpr_Distribuidordescripcion ;
         }

         set {
            sdt.gxTpr_Distribuidordescripcion = value;
         }

      }

      [DataMember( Name = "DistribuidorRFC" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Distribuidorrfc
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Distribuidorrfc) ;
         }

         set {
            sdt.gxTpr_Distribuidorrfc = value;
         }

      }

      public SdtDistribuidor sdt
      {
         get {
            return (SdtDistribuidor)Sdt ;
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
            sdt = new SdtDistribuidor() ;
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

   [DataContract(Name = @"Distribuidor", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtDistribuidor_RESTLInterface : GxGenericCollectionItem<SdtDistribuidor>
   {
      public SdtDistribuidor_RESTLInterface( ) : base()
      {
      }

      public SdtDistribuidor_RESTLInterface( SdtDistribuidor psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DistribuidorDescripcion" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Distribuidordescripcion
      {
         get {
            return sdt.gxTpr_Distribuidordescripcion ;
         }

         set {
            sdt.gxTpr_Distribuidordescripcion = value;
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

      public SdtDistribuidor sdt
      {
         get {
            return (SdtDistribuidor)Sdt ;
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
            sdt = new SdtDistribuidor() ;
         }
      }

   }

}
