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
   [XmlRoot(ElementName = "TrnDirectiva" )]
   [XmlType(TypeName =  "TrnDirectiva" , Namespace = "Premios" )]
   [Serializable]
   public class SdtTrnDirectiva : GxSilentTrnSdt
   {
      public SdtTrnDirectiva( )
      {
      }

      public SdtTrnDirectiva( IGxContext context )
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

      public void Load( string AV89TrnDirectivaTitle )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV89TrnDirectivaTitle});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TrnDirectivaTitle", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TrnDirectiva");
         metadata.Set("BT", "TrnDirectiva");
         metadata.Set("PK", "[ \"TrnDirectivaTitle\" ]");
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
         state.Add("gxTpr_Trndirectivatitle_Z");
         state.Add("gxTpr_Trndirectivavalue_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrnDirectiva sdt;
         sdt = (SdtTrnDirectiva)(source);
         gxTv_SdtTrnDirectiva_Trndirectivatitle = sdt.gxTv_SdtTrnDirectiva_Trndirectivatitle ;
         gxTv_SdtTrnDirectiva_Trndirectivavalue = sdt.gxTv_SdtTrnDirectiva_Trndirectivavalue ;
         gxTv_SdtTrnDirectiva_Trndirectivadescripcion = sdt.gxTv_SdtTrnDirectiva_Trndirectivadescripcion ;
         gxTv_SdtTrnDirectiva_Mode = sdt.gxTv_SdtTrnDirectiva_Mode ;
         gxTv_SdtTrnDirectiva_Initialized = sdt.gxTv_SdtTrnDirectiva_Initialized ;
         gxTv_SdtTrnDirectiva_Trndirectivatitle_Z = sdt.gxTv_SdtTrnDirectiva_Trndirectivatitle_Z ;
         gxTv_SdtTrnDirectiva_Trndirectivavalue_Z = sdt.gxTv_SdtTrnDirectiva_Trndirectivavalue_Z ;
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
         AddObjectProperty("TrnDirectivaTitle", gxTv_SdtTrnDirectiva_Trndirectivatitle, false, includeNonInitialized);
         AddObjectProperty("TrnDirectivaValue", gxTv_SdtTrnDirectiva_Trndirectivavalue, false, includeNonInitialized);
         AddObjectProperty("TrnDirectivaDescripcion", gxTv_SdtTrnDirectiva_Trndirectivadescripcion, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrnDirectiva_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrnDirectiva_Initialized, false, includeNonInitialized);
            AddObjectProperty("TrnDirectivaTitle_Z", gxTv_SdtTrnDirectiva_Trndirectivatitle_Z, false, includeNonInitialized);
            AddObjectProperty("TrnDirectivaValue_Z", gxTv_SdtTrnDirectiva_Trndirectivavalue_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrnDirectiva sdt )
      {
         if ( sdt.IsDirty("TrnDirectivaTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrnDirectiva_Trndirectivatitle = sdt.gxTv_SdtTrnDirectiva_Trndirectivatitle ;
         }
         if ( sdt.IsDirty("TrnDirectivaValue") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrnDirectiva_Trndirectivavalue = sdt.gxTv_SdtTrnDirectiva_Trndirectivavalue ;
         }
         if ( sdt.IsDirty("TrnDirectivaDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrnDirectiva_Trndirectivadescripcion = sdt.gxTv_SdtTrnDirectiva_Trndirectivadescripcion ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TrnDirectivaTitle" )]
      [  XmlElement( ElementName = "TrnDirectivaTitle"   )]
      public string gxTpr_Trndirectivatitle
      {
         get {
            return gxTv_SdtTrnDirectiva_Trndirectivatitle ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtTrnDirectiva_Trndirectivatitle, value) != 0 )
            {
               gxTv_SdtTrnDirectiva_Mode = "INS";
               this.gxTv_SdtTrnDirectiva_Trndirectivatitle_Z_SetNull( );
               this.gxTv_SdtTrnDirectiva_Trndirectivavalue_Z_SetNull( );
            }
            gxTv_SdtTrnDirectiva_Trndirectivatitle = value;
            SetDirty("Trndirectivatitle");
         }

      }

      [  SoapElement( ElementName = "TrnDirectivaValue" )]
      [  XmlElement( ElementName = "TrnDirectivaValue"   )]
      public string gxTpr_Trndirectivavalue
      {
         get {
            return gxTv_SdtTrnDirectiva_Trndirectivavalue ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrnDirectiva_Trndirectivavalue = value;
            SetDirty("Trndirectivavalue");
         }

      }

      [  SoapElement( ElementName = "TrnDirectivaDescripcion" )]
      [  XmlElement( ElementName = "TrnDirectivaDescripcion"   )]
      public string gxTpr_Trndirectivadescripcion
      {
         get {
            return gxTv_SdtTrnDirectiva_Trndirectivadescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrnDirectiva_Trndirectivadescripcion = value;
            SetDirty("Trndirectivadescripcion");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrnDirectiva_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrnDirectiva_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrnDirectiva_Mode_SetNull( )
      {
         gxTv_SdtTrnDirectiva_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrnDirectiva_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrnDirectiva_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrnDirectiva_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrnDirectiva_Initialized_SetNull( )
      {
         gxTv_SdtTrnDirectiva_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrnDirectiva_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrnDirectivaTitle_Z" )]
      [  XmlElement( ElementName = "TrnDirectivaTitle_Z"   )]
      public string gxTpr_Trndirectivatitle_Z
      {
         get {
            return gxTv_SdtTrnDirectiva_Trndirectivatitle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrnDirectiva_Trndirectivatitle_Z = value;
            SetDirty("Trndirectivatitle_Z");
         }

      }

      public void gxTv_SdtTrnDirectiva_Trndirectivatitle_Z_SetNull( )
      {
         gxTv_SdtTrnDirectiva_Trndirectivatitle_Z = "";
         SetDirty("Trndirectivatitle_Z");
         return  ;
      }

      public bool gxTv_SdtTrnDirectiva_Trndirectivatitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrnDirectivaValue_Z" )]
      [  XmlElement( ElementName = "TrnDirectivaValue_Z"   )]
      public string gxTpr_Trndirectivavalue_Z
      {
         get {
            return gxTv_SdtTrnDirectiva_Trndirectivavalue_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrnDirectiva_Trndirectivavalue_Z = value;
            SetDirty("Trndirectivavalue_Z");
         }

      }

      public void gxTv_SdtTrnDirectiva_Trndirectivavalue_Z_SetNull( )
      {
         gxTv_SdtTrnDirectiva_Trndirectivavalue_Z = "";
         SetDirty("Trndirectivavalue_Z");
         return  ;
      }

      public bool gxTv_SdtTrnDirectiva_Trndirectivavalue_Z_IsNull( )
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
         gxTv_SdtTrnDirectiva_Trndirectivatitle = "";
         sdtIsNull = 1;
         gxTv_SdtTrnDirectiva_Trndirectivavalue = "";
         gxTv_SdtTrnDirectiva_Trndirectivadescripcion = "";
         gxTv_SdtTrnDirectiva_Mode = "";
         gxTv_SdtTrnDirectiva_Trndirectivatitle_Z = "";
         gxTv_SdtTrnDirectiva_Trndirectivavalue_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trndirectiva", "GeneXus.Programs.trndirectiva_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrnDirectiva_Initialized ;
      private string gxTv_SdtTrnDirectiva_Mode ;
      private string gxTv_SdtTrnDirectiva_Trndirectivadescripcion ;
      private string gxTv_SdtTrnDirectiva_Trndirectivatitle ;
      private string gxTv_SdtTrnDirectiva_Trndirectivavalue ;
      private string gxTv_SdtTrnDirectiva_Trndirectivatitle_Z ;
      private string gxTv_SdtTrnDirectiva_Trndirectivavalue_Z ;
   }

   [DataContract(Name = @"TrnDirectiva", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtTrnDirectiva_RESTInterface : GxGenericCollectionItem<SdtTrnDirectiva>
   {
      public SdtTrnDirectiva_RESTInterface( ) : base()
      {
      }

      public SdtTrnDirectiva_RESTInterface( SdtTrnDirectiva psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TrnDirectivaTitle" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Trndirectivatitle
      {
         get {
            return sdt.gxTpr_Trndirectivatitle ;
         }

         set {
            sdt.gxTpr_Trndirectivatitle = value;
         }

      }

      [DataMember( Name = "TrnDirectivaValue" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Trndirectivavalue
      {
         get {
            return sdt.gxTpr_Trndirectivavalue ;
         }

         set {
            sdt.gxTpr_Trndirectivavalue = value;
         }

      }

      [DataMember( Name = "TrnDirectivaDescripcion" , Order = 2 )]
      public string gxTpr_Trndirectivadescripcion
      {
         get {
            return sdt.gxTpr_Trndirectivadescripcion ;
         }

         set {
            sdt.gxTpr_Trndirectivadescripcion = value;
         }

      }

      public SdtTrnDirectiva sdt
      {
         get {
            return (SdtTrnDirectiva)Sdt ;
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
            sdt = new SdtTrnDirectiva() ;
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

   [DataContract(Name = @"TrnDirectiva", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtTrnDirectiva_RESTLInterface : GxGenericCollectionItem<SdtTrnDirectiva>
   {
      public SdtTrnDirectiva_RESTLInterface( ) : base()
      {
      }

      public SdtTrnDirectiva_RESTLInterface( SdtTrnDirectiva psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TrnDirectivaTitle" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Trndirectivatitle
      {
         get {
            return sdt.gxTpr_Trndirectivatitle ;
         }

         set {
            sdt.gxTpr_Trndirectivatitle = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/TrnDirectiva/{0}";
            gxuri = String.Format(gxuri,gxTpr_Trndirectivatitle) ;
            return gxuri ;
         }

         set {
         }

      }

      public SdtTrnDirectiva sdt
      {
         get {
            return (SdtTrnDirectiva)Sdt ;
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
            sdt = new SdtTrnDirectiva() ;
         }
      }

      private string gxuri ;
   }

}
