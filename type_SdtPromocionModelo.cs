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
   [XmlRoot(ElementName = "PromocionModelo" )]
   [XmlType(TypeName =  "PromocionModelo" , Namespace = "Premios" )]
   [Serializable]
   public class SdtPromocionModelo : GxSilentTrnSdt
   {
      public SdtPromocionModelo( )
      {
      }

      public SdtPromocionModelo( IGxContext context )
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

      public void Load( int AV48PromocionModeloID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV48PromocionModeloID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PromocionModeloID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PromocionModelo");
         metadata.Set("BT", "PromocionModelo");
         metadata.Set("PK", "[ \"PromocionModeloID\" ]");
         metadata.Set("PKAssigned", "[ \"PromocionModeloID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ModeloID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PromocionID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Promocionmodeloid_Z");
         state.Add("gxTpr_Promocionid_Z");
         state.Add("gxTpr_Modeloid_Z");
         state.Add("gxTpr_Modelodescripcion_Z");
         state.Add("gxTpr_Modelosegmento_Z");
         state.Add("gxTpr_Promocionmodeloprecio_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPromocionModelo sdt;
         sdt = (SdtPromocionModelo)(source);
         gxTv_SdtPromocionModelo_Promocionmodeloid = sdt.gxTv_SdtPromocionModelo_Promocionmodeloid ;
         gxTv_SdtPromocionModelo_Promocionid = sdt.gxTv_SdtPromocionModelo_Promocionid ;
         gxTv_SdtPromocionModelo_Modeloid = sdt.gxTv_SdtPromocionModelo_Modeloid ;
         gxTv_SdtPromocionModelo_Modelodescripcion = sdt.gxTv_SdtPromocionModelo_Modelodescripcion ;
         gxTv_SdtPromocionModelo_Modelosegmento = sdt.gxTv_SdtPromocionModelo_Modelosegmento ;
         gxTv_SdtPromocionModelo_Promocionmodeloprecio = sdt.gxTv_SdtPromocionModelo_Promocionmodeloprecio ;
         gxTv_SdtPromocionModelo_Mode = sdt.gxTv_SdtPromocionModelo_Mode ;
         gxTv_SdtPromocionModelo_Initialized = sdt.gxTv_SdtPromocionModelo_Initialized ;
         gxTv_SdtPromocionModelo_Promocionmodeloid_Z = sdt.gxTv_SdtPromocionModelo_Promocionmodeloid_Z ;
         gxTv_SdtPromocionModelo_Promocionid_Z = sdt.gxTv_SdtPromocionModelo_Promocionid_Z ;
         gxTv_SdtPromocionModelo_Modeloid_Z = sdt.gxTv_SdtPromocionModelo_Modeloid_Z ;
         gxTv_SdtPromocionModelo_Modelodescripcion_Z = sdt.gxTv_SdtPromocionModelo_Modelodescripcion_Z ;
         gxTv_SdtPromocionModelo_Modelosegmento_Z = sdt.gxTv_SdtPromocionModelo_Modelosegmento_Z ;
         gxTv_SdtPromocionModelo_Promocionmodeloprecio_Z = sdt.gxTv_SdtPromocionModelo_Promocionmodeloprecio_Z ;
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
         AddObjectProperty("PromocionModeloID", gxTv_SdtPromocionModelo_Promocionmodeloid, false, includeNonInitialized);
         AddObjectProperty("PromocionID", gxTv_SdtPromocionModelo_Promocionid, false, includeNonInitialized);
         AddObjectProperty("ModeloID", gxTv_SdtPromocionModelo_Modeloid, false, includeNonInitialized);
         AddObjectProperty("ModeloDescripcion", gxTv_SdtPromocionModelo_Modelodescripcion, false, includeNonInitialized);
         AddObjectProperty("ModeloSegmento", gxTv_SdtPromocionModelo_Modelosegmento, false, includeNonInitialized);
         AddObjectProperty("PromocionModeloPrecio", gxTv_SdtPromocionModelo_Promocionmodeloprecio, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPromocionModelo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPromocionModelo_Initialized, false, includeNonInitialized);
            AddObjectProperty("PromocionModeloID_Z", gxTv_SdtPromocionModelo_Promocionmodeloid_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionID_Z", gxTv_SdtPromocionModelo_Promocionid_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloID_Z", gxTv_SdtPromocionModelo_Modeloid_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloDescripcion_Z", gxTv_SdtPromocionModelo_Modelodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloSegmento_Z", gxTv_SdtPromocionModelo_Modelosegmento_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionModeloPrecio_Z", gxTv_SdtPromocionModelo_Promocionmodeloprecio_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPromocionModelo sdt )
      {
         if ( sdt.IsDirty("PromocionModeloID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Promocionmodeloid = sdt.gxTv_SdtPromocionModelo_Promocionmodeloid ;
         }
         if ( sdt.IsDirty("PromocionID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Promocionid = sdt.gxTv_SdtPromocionModelo_Promocionid ;
         }
         if ( sdt.IsDirty("ModeloID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Modeloid = sdt.gxTv_SdtPromocionModelo_Modeloid ;
         }
         if ( sdt.IsDirty("ModeloDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Modelodescripcion = sdt.gxTv_SdtPromocionModelo_Modelodescripcion ;
         }
         if ( sdt.IsDirty("ModeloSegmento") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Modelosegmento = sdt.gxTv_SdtPromocionModelo_Modelosegmento ;
         }
         if ( sdt.IsDirty("PromocionModeloPrecio") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Promocionmodeloprecio = sdt.gxTv_SdtPromocionModelo_Promocionmodeloprecio ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PromocionModeloID" )]
      [  XmlElement( ElementName = "PromocionModeloID"   )]
      public int gxTpr_Promocionmodeloid
      {
         get {
            return gxTv_SdtPromocionModelo_Promocionmodeloid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPromocionModelo_Promocionmodeloid != value )
            {
               gxTv_SdtPromocionModelo_Mode = "INS";
               this.gxTv_SdtPromocionModelo_Promocionmodeloid_Z_SetNull( );
               this.gxTv_SdtPromocionModelo_Promocionid_Z_SetNull( );
               this.gxTv_SdtPromocionModelo_Modeloid_Z_SetNull( );
               this.gxTv_SdtPromocionModelo_Modelodescripcion_Z_SetNull( );
               this.gxTv_SdtPromocionModelo_Modelosegmento_Z_SetNull( );
               this.gxTv_SdtPromocionModelo_Promocionmodeloprecio_Z_SetNull( );
            }
            gxTv_SdtPromocionModelo_Promocionmodeloid = value;
            SetDirty("Promocionmodeloid");
         }

      }

      [  SoapElement( ElementName = "PromocionID" )]
      [  XmlElement( ElementName = "PromocionID"   )]
      public int gxTpr_Promocionid
      {
         get {
            return gxTv_SdtPromocionModelo_Promocionid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Promocionid = value;
            SetDirty("Promocionid");
         }

      }

      [  SoapElement( ElementName = "ModeloID" )]
      [  XmlElement( ElementName = "ModeloID"   )]
      public int gxTpr_Modeloid
      {
         get {
            return gxTv_SdtPromocionModelo_Modeloid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Modeloid = value;
            SetDirty("Modeloid");
         }

      }

      [  SoapElement( ElementName = "ModeloDescripcion" )]
      [  XmlElement( ElementName = "ModeloDescripcion"   )]
      public string gxTpr_Modelodescripcion
      {
         get {
            return gxTv_SdtPromocionModelo_Modelodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Modelodescripcion = value;
            SetDirty("Modelodescripcion");
         }

      }

      [  SoapElement( ElementName = "ModeloSegmento" )]
      [  XmlElement( ElementName = "ModeloSegmento"   )]
      public string gxTpr_Modelosegmento
      {
         get {
            return gxTv_SdtPromocionModelo_Modelosegmento ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Modelosegmento = value;
            SetDirty("Modelosegmento");
         }

      }

      [  SoapElement( ElementName = "PromocionModeloPrecio" )]
      [  XmlElement( ElementName = "PromocionModeloPrecio"   )]
      public decimal gxTpr_Promocionmodeloprecio
      {
         get {
            return gxTv_SdtPromocionModelo_Promocionmodeloprecio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Promocionmodeloprecio = value;
            SetDirty("Promocionmodeloprecio");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPromocionModelo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPromocionModelo_Mode_SetNull( )
      {
         gxTv_SdtPromocionModelo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPromocionModelo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPromocionModelo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPromocionModelo_Initialized_SetNull( )
      {
         gxTv_SdtPromocionModelo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPromocionModelo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionModeloID_Z" )]
      [  XmlElement( ElementName = "PromocionModeloID_Z"   )]
      public int gxTpr_Promocionmodeloid_Z
      {
         get {
            return gxTv_SdtPromocionModelo_Promocionmodeloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Promocionmodeloid_Z = value;
            SetDirty("Promocionmodeloid_Z");
         }

      }

      public void gxTv_SdtPromocionModelo_Promocionmodeloid_Z_SetNull( )
      {
         gxTv_SdtPromocionModelo_Promocionmodeloid_Z = 0;
         SetDirty("Promocionmodeloid_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionModelo_Promocionmodeloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionID_Z" )]
      [  XmlElement( ElementName = "PromocionID_Z"   )]
      public int gxTpr_Promocionid_Z
      {
         get {
            return gxTv_SdtPromocionModelo_Promocionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Promocionid_Z = value;
            SetDirty("Promocionid_Z");
         }

      }

      public void gxTv_SdtPromocionModelo_Promocionid_Z_SetNull( )
      {
         gxTv_SdtPromocionModelo_Promocionid_Z = 0;
         SetDirty("Promocionid_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionModelo_Promocionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloID_Z" )]
      [  XmlElement( ElementName = "ModeloID_Z"   )]
      public int gxTpr_Modeloid_Z
      {
         get {
            return gxTv_SdtPromocionModelo_Modeloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Modeloid_Z = value;
            SetDirty("Modeloid_Z");
         }

      }

      public void gxTv_SdtPromocionModelo_Modeloid_Z_SetNull( )
      {
         gxTv_SdtPromocionModelo_Modeloid_Z = 0;
         SetDirty("Modeloid_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionModelo_Modeloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloDescripcion_Z" )]
      [  XmlElement( ElementName = "ModeloDescripcion_Z"   )]
      public string gxTpr_Modelodescripcion_Z
      {
         get {
            return gxTv_SdtPromocionModelo_Modelodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Modelodescripcion_Z = value;
            SetDirty("Modelodescripcion_Z");
         }

      }

      public void gxTv_SdtPromocionModelo_Modelodescripcion_Z_SetNull( )
      {
         gxTv_SdtPromocionModelo_Modelodescripcion_Z = "";
         SetDirty("Modelodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionModelo_Modelodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloSegmento_Z" )]
      [  XmlElement( ElementName = "ModeloSegmento_Z"   )]
      public string gxTpr_Modelosegmento_Z
      {
         get {
            return gxTv_SdtPromocionModelo_Modelosegmento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Modelosegmento_Z = value;
            SetDirty("Modelosegmento_Z");
         }

      }

      public void gxTv_SdtPromocionModelo_Modelosegmento_Z_SetNull( )
      {
         gxTv_SdtPromocionModelo_Modelosegmento_Z = "";
         SetDirty("Modelosegmento_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionModelo_Modelosegmento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionModeloPrecio_Z" )]
      [  XmlElement( ElementName = "PromocionModeloPrecio_Z"   )]
      public decimal gxTpr_Promocionmodeloprecio_Z
      {
         get {
            return gxTv_SdtPromocionModelo_Promocionmodeloprecio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionModelo_Promocionmodeloprecio_Z = value;
            SetDirty("Promocionmodeloprecio_Z");
         }

      }

      public void gxTv_SdtPromocionModelo_Promocionmodeloprecio_Z_SetNull( )
      {
         gxTv_SdtPromocionModelo_Promocionmodeloprecio_Z = 0;
         SetDirty("Promocionmodeloprecio_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionModelo_Promocionmodeloprecio_Z_IsNull( )
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
         gxTv_SdtPromocionModelo_Modelodescripcion = "";
         gxTv_SdtPromocionModelo_Modelosegmento = "";
         gxTv_SdtPromocionModelo_Mode = "";
         gxTv_SdtPromocionModelo_Modelodescripcion_Z = "";
         gxTv_SdtPromocionModelo_Modelosegmento_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "promocionmodelo", "GeneXus.Programs.promocionmodelo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPromocionModelo_Initialized ;
      private int gxTv_SdtPromocionModelo_Promocionmodeloid ;
      private int gxTv_SdtPromocionModelo_Promocionid ;
      private int gxTv_SdtPromocionModelo_Modeloid ;
      private int gxTv_SdtPromocionModelo_Promocionmodeloid_Z ;
      private int gxTv_SdtPromocionModelo_Promocionid_Z ;
      private int gxTv_SdtPromocionModelo_Modeloid_Z ;
      private decimal gxTv_SdtPromocionModelo_Promocionmodeloprecio ;
      private decimal gxTv_SdtPromocionModelo_Promocionmodeloprecio_Z ;
      private string gxTv_SdtPromocionModelo_Modelosegmento ;
      private string gxTv_SdtPromocionModelo_Mode ;
      private string gxTv_SdtPromocionModelo_Modelosegmento_Z ;
      private string gxTv_SdtPromocionModelo_Modelodescripcion ;
      private string gxTv_SdtPromocionModelo_Modelodescripcion_Z ;
   }

   [DataContract(Name = @"PromocionModelo", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtPromocionModelo_RESTInterface : GxGenericCollectionItem<SdtPromocionModelo>
   {
      public SdtPromocionModelo_RESTInterface( ) : base()
      {
      }

      public SdtPromocionModelo_RESTInterface( SdtPromocionModelo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PromocionModeloID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Promocionmodeloid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Promocionmodeloid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Promocionmodeloid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PromocionID" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Promocionid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Promocionid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Promocionid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ModeloID" , Order = 2 )]
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

      [DataMember( Name = "ModeloDescripcion" , Order = 3 )]
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

      [DataMember( Name = "ModeloSegmento" , Order = 4 )]
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

      [DataMember( Name = "PromocionModeloPrecio" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Promocionmodeloprecio
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Promocionmodeloprecio, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Promocionmodeloprecio = NumberUtil.Val( value, ".");
         }

      }

      public SdtPromocionModelo sdt
      {
         get {
            return (SdtPromocionModelo)Sdt ;
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
            sdt = new SdtPromocionModelo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
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

   [DataContract(Name = @"PromocionModelo", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtPromocionModelo_RESTLInterface : GxGenericCollectionItem<SdtPromocionModelo>
   {
      public SdtPromocionModelo_RESTLInterface( ) : base()
      {
      }

      public SdtPromocionModelo_RESTLInterface( SdtPromocionModelo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PromocionModeloPrecio" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Promocionmodeloprecio
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Promocionmodeloprecio, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Promocionmodeloprecio = NumberUtil.Val( value, ".");
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

      public SdtPromocionModelo sdt
      {
         get {
            return (SdtPromocionModelo)Sdt ;
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
            sdt = new SdtPromocionModelo() ;
         }
      }

   }

}
