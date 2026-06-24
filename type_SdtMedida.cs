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
   [XmlRoot(ElementName = "Medida" )]
   [XmlType(TypeName =  "Medida" , Namespace = "Premios" )]
   [Serializable]
   public class SdtMedida : GxSilentTrnSdt
   {
      public SdtMedida( )
      {
      }

      public SdtMedida( IGxContext context )
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

      public void Load( int AV26MedidaID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV26MedidaID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MedidaID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Medida");
         metadata.Set("BT", "Medida");
         metadata.Set("PK", "[ \"MedidaID\" ]");
         metadata.Set("PKAssigned", "[ \"MedidaID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ModeloID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Medidaid_Z");
         state.Add("gxTpr_Medidacodigo_Z");
         state.Add("gxTpr_Medidadescripcion_Z");
         state.Add("gxTpr_Modeloid_Z");
         state.Add("gxTpr_Medidarin_Z");
         state.Add("gxTpr_Modelodescripcion_Z");
         state.Add("gxTpr_Modelosegmento_Z");
         state.Add("gxTpr_Medidanombrecompleto_Z");
         state.Add("gxTpr_Medidacomentario_Z");
         state.Add("gxTpr_Medidaactivo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtMedida sdt;
         sdt = (SdtMedida)(source);
         gxTv_SdtMedida_Medidaid = sdt.gxTv_SdtMedida_Medidaid ;
         gxTv_SdtMedida_Medidacodigo = sdt.gxTv_SdtMedida_Medidacodigo ;
         gxTv_SdtMedida_Medidadescripcion = sdt.gxTv_SdtMedida_Medidadescripcion ;
         gxTv_SdtMedida_Modeloid = sdt.gxTv_SdtMedida_Modeloid ;
         gxTv_SdtMedida_Medidarin = sdt.gxTv_SdtMedida_Medidarin ;
         gxTv_SdtMedida_Modelodescripcion = sdt.gxTv_SdtMedida_Modelodescripcion ;
         gxTv_SdtMedida_Modelosegmento = sdt.gxTv_SdtMedida_Modelosegmento ;
         gxTv_SdtMedida_Medidanombrecompleto = sdt.gxTv_SdtMedida_Medidanombrecompleto ;
         gxTv_SdtMedida_Medidacomentario = sdt.gxTv_SdtMedida_Medidacomentario ;
         gxTv_SdtMedida_Medidaactivo = sdt.gxTv_SdtMedida_Medidaactivo ;
         gxTv_SdtMedida_Mode = sdt.gxTv_SdtMedida_Mode ;
         gxTv_SdtMedida_Initialized = sdt.gxTv_SdtMedida_Initialized ;
         gxTv_SdtMedida_Medidaid_Z = sdt.gxTv_SdtMedida_Medidaid_Z ;
         gxTv_SdtMedida_Medidacodigo_Z = sdt.gxTv_SdtMedida_Medidacodigo_Z ;
         gxTv_SdtMedida_Medidadescripcion_Z = sdt.gxTv_SdtMedida_Medidadescripcion_Z ;
         gxTv_SdtMedida_Modeloid_Z = sdt.gxTv_SdtMedida_Modeloid_Z ;
         gxTv_SdtMedida_Medidarin_Z = sdt.gxTv_SdtMedida_Medidarin_Z ;
         gxTv_SdtMedida_Modelodescripcion_Z = sdt.gxTv_SdtMedida_Modelodescripcion_Z ;
         gxTv_SdtMedida_Modelosegmento_Z = sdt.gxTv_SdtMedida_Modelosegmento_Z ;
         gxTv_SdtMedida_Medidanombrecompleto_Z = sdt.gxTv_SdtMedida_Medidanombrecompleto_Z ;
         gxTv_SdtMedida_Medidacomentario_Z = sdt.gxTv_SdtMedida_Medidacomentario_Z ;
         gxTv_SdtMedida_Medidaactivo_Z = sdt.gxTv_SdtMedida_Medidaactivo_Z ;
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
         AddObjectProperty("MedidaID", gxTv_SdtMedida_Medidaid, false, includeNonInitialized);
         AddObjectProperty("MedidaCodigo", gxTv_SdtMedida_Medidacodigo, false, includeNonInitialized);
         AddObjectProperty("MedidaDescripcion", gxTv_SdtMedida_Medidadescripcion, false, includeNonInitialized);
         AddObjectProperty("ModeloID", gxTv_SdtMedida_Modeloid, false, includeNonInitialized);
         AddObjectProperty("MedidaRin", gxTv_SdtMedida_Medidarin, false, includeNonInitialized);
         AddObjectProperty("ModeloDescripcion", gxTv_SdtMedida_Modelodescripcion, false, includeNonInitialized);
         AddObjectProperty("ModeloSegmento", gxTv_SdtMedida_Modelosegmento, false, includeNonInitialized);
         AddObjectProperty("MedidaNombreCompleto", gxTv_SdtMedida_Medidanombrecompleto, false, includeNonInitialized);
         AddObjectProperty("MedidaComentario", gxTv_SdtMedida_Medidacomentario, false, includeNonInitialized);
         AddObjectProperty("MedidaActivo", gxTv_SdtMedida_Medidaactivo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtMedida_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtMedida_Initialized, false, includeNonInitialized);
            AddObjectProperty("MedidaID_Z", gxTv_SdtMedida_Medidaid_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaCodigo_Z", gxTv_SdtMedida_Medidacodigo_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaDescripcion_Z", gxTv_SdtMedida_Medidadescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloID_Z", gxTv_SdtMedida_Modeloid_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaRin_Z", gxTv_SdtMedida_Medidarin_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloDescripcion_Z", gxTv_SdtMedida_Modelodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloSegmento_Z", gxTv_SdtMedida_Modelosegmento_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaNombreCompleto_Z", gxTv_SdtMedida_Medidanombrecompleto_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaComentario_Z", gxTv_SdtMedida_Medidacomentario_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaActivo_Z", gxTv_SdtMedida_Medidaactivo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtMedida sdt )
      {
         if ( sdt.IsDirty("MedidaID") )
         {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidaid = sdt.gxTv_SdtMedida_Medidaid ;
         }
         if ( sdt.IsDirty("MedidaCodigo") )
         {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidacodigo = sdt.gxTv_SdtMedida_Medidacodigo ;
         }
         if ( sdt.IsDirty("MedidaDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidadescripcion = sdt.gxTv_SdtMedida_Medidadescripcion ;
         }
         if ( sdt.IsDirty("ModeloID") )
         {
            sdtIsNull = 0;
            gxTv_SdtMedida_Modeloid = sdt.gxTv_SdtMedida_Modeloid ;
         }
         if ( sdt.IsDirty("MedidaRin") )
         {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidarin = sdt.gxTv_SdtMedida_Medidarin ;
         }
         if ( sdt.IsDirty("ModeloDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtMedida_Modelodescripcion = sdt.gxTv_SdtMedida_Modelodescripcion ;
         }
         if ( sdt.IsDirty("ModeloSegmento") )
         {
            sdtIsNull = 0;
            gxTv_SdtMedida_Modelosegmento = sdt.gxTv_SdtMedida_Modelosegmento ;
         }
         if ( sdt.IsDirty("MedidaNombreCompleto") )
         {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidanombrecompleto = sdt.gxTv_SdtMedida_Medidanombrecompleto ;
         }
         if ( sdt.IsDirty("MedidaComentario") )
         {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidacomentario = sdt.gxTv_SdtMedida_Medidacomentario ;
         }
         if ( sdt.IsDirty("MedidaActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidaactivo = sdt.gxTv_SdtMedida_Medidaactivo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MedidaID" )]
      [  XmlElement( ElementName = "MedidaID"   )]
      public int gxTpr_Medidaid
      {
         get {
            return gxTv_SdtMedida_Medidaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtMedida_Medidaid != value )
            {
               gxTv_SdtMedida_Mode = "INS";
               this.gxTv_SdtMedida_Medidaid_Z_SetNull( );
               this.gxTv_SdtMedida_Medidacodigo_Z_SetNull( );
               this.gxTv_SdtMedida_Medidadescripcion_Z_SetNull( );
               this.gxTv_SdtMedida_Modeloid_Z_SetNull( );
               this.gxTv_SdtMedida_Medidarin_Z_SetNull( );
               this.gxTv_SdtMedida_Modelodescripcion_Z_SetNull( );
               this.gxTv_SdtMedida_Modelosegmento_Z_SetNull( );
               this.gxTv_SdtMedida_Medidanombrecompleto_Z_SetNull( );
               this.gxTv_SdtMedida_Medidacomentario_Z_SetNull( );
               this.gxTv_SdtMedida_Medidaactivo_Z_SetNull( );
            }
            gxTv_SdtMedida_Medidaid = value;
            SetDirty("Medidaid");
         }

      }

      [  SoapElement( ElementName = "MedidaCodigo" )]
      [  XmlElement( ElementName = "MedidaCodigo"   )]
      public string gxTpr_Medidacodigo
      {
         get {
            return gxTv_SdtMedida_Medidacodigo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidacodigo = value;
            SetDirty("Medidacodigo");
         }

      }

      [  SoapElement( ElementName = "MedidaDescripcion" )]
      [  XmlElement( ElementName = "MedidaDescripcion"   )]
      public string gxTpr_Medidadescripcion
      {
         get {
            return gxTv_SdtMedida_Medidadescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidadescripcion = value;
            SetDirty("Medidadescripcion");
         }

      }

      [  SoapElement( ElementName = "ModeloID" )]
      [  XmlElement( ElementName = "ModeloID"   )]
      public int gxTpr_Modeloid
      {
         get {
            return gxTv_SdtMedida_Modeloid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Modeloid = value;
            SetDirty("Modeloid");
         }

      }

      [  SoapElement( ElementName = "MedidaRin" )]
      [  XmlElement( ElementName = "MedidaRin"   )]
      public string gxTpr_Medidarin
      {
         get {
            return gxTv_SdtMedida_Medidarin ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidarin = value;
            SetDirty("Medidarin");
         }

      }

      [  SoapElement( ElementName = "ModeloDescripcion" )]
      [  XmlElement( ElementName = "ModeloDescripcion"   )]
      public string gxTpr_Modelodescripcion
      {
         get {
            return gxTv_SdtMedida_Modelodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Modelodescripcion = value;
            SetDirty("Modelodescripcion");
         }

      }

      [  SoapElement( ElementName = "ModeloSegmento" )]
      [  XmlElement( ElementName = "ModeloSegmento"   )]
      public string gxTpr_Modelosegmento
      {
         get {
            return gxTv_SdtMedida_Modelosegmento ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Modelosegmento = value;
            SetDirty("Modelosegmento");
         }

      }

      [  SoapElement( ElementName = "MedidaNombreCompleto" )]
      [  XmlElement( ElementName = "MedidaNombreCompleto"   )]
      public string gxTpr_Medidanombrecompleto
      {
         get {
            return gxTv_SdtMedida_Medidanombrecompleto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidanombrecompleto = value;
            SetDirty("Medidanombrecompleto");
         }

      }

      public void gxTv_SdtMedida_Medidanombrecompleto_SetNull( )
      {
         gxTv_SdtMedida_Medidanombrecompleto = "";
         SetDirty("Medidanombrecompleto");
         return  ;
      }

      public bool gxTv_SdtMedida_Medidanombrecompleto_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaComentario" )]
      [  XmlElement( ElementName = "MedidaComentario"   )]
      public string gxTpr_Medidacomentario
      {
         get {
            return gxTv_SdtMedida_Medidacomentario ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidacomentario = value;
            SetDirty("Medidacomentario");
         }

      }

      [  SoapElement( ElementName = "MedidaActivo" )]
      [  XmlElement( ElementName = "MedidaActivo"   )]
      public bool gxTpr_Medidaactivo
      {
         get {
            return gxTv_SdtMedida_Medidaactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidaactivo = value;
            SetDirty("Medidaactivo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtMedida_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtMedida_Mode_SetNull( )
      {
         gxTv_SdtMedida_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtMedida_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtMedida_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtMedida_Initialized_SetNull( )
      {
         gxTv_SdtMedida_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtMedida_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaID_Z" )]
      [  XmlElement( ElementName = "MedidaID_Z"   )]
      public int gxTpr_Medidaid_Z
      {
         get {
            return gxTv_SdtMedida_Medidaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidaid_Z = value;
            SetDirty("Medidaid_Z");
         }

      }

      public void gxTv_SdtMedida_Medidaid_Z_SetNull( )
      {
         gxTv_SdtMedida_Medidaid_Z = 0;
         SetDirty("Medidaid_Z");
         return  ;
      }

      public bool gxTv_SdtMedida_Medidaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaCodigo_Z" )]
      [  XmlElement( ElementName = "MedidaCodigo_Z"   )]
      public string gxTpr_Medidacodigo_Z
      {
         get {
            return gxTv_SdtMedida_Medidacodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidacodigo_Z = value;
            SetDirty("Medidacodigo_Z");
         }

      }

      public void gxTv_SdtMedida_Medidacodigo_Z_SetNull( )
      {
         gxTv_SdtMedida_Medidacodigo_Z = "";
         SetDirty("Medidacodigo_Z");
         return  ;
      }

      public bool gxTv_SdtMedida_Medidacodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaDescripcion_Z" )]
      [  XmlElement( ElementName = "MedidaDescripcion_Z"   )]
      public string gxTpr_Medidadescripcion_Z
      {
         get {
            return gxTv_SdtMedida_Medidadescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidadescripcion_Z = value;
            SetDirty("Medidadescripcion_Z");
         }

      }

      public void gxTv_SdtMedida_Medidadescripcion_Z_SetNull( )
      {
         gxTv_SdtMedida_Medidadescripcion_Z = "";
         SetDirty("Medidadescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtMedida_Medidadescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloID_Z" )]
      [  XmlElement( ElementName = "ModeloID_Z"   )]
      public int gxTpr_Modeloid_Z
      {
         get {
            return gxTv_SdtMedida_Modeloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Modeloid_Z = value;
            SetDirty("Modeloid_Z");
         }

      }

      public void gxTv_SdtMedida_Modeloid_Z_SetNull( )
      {
         gxTv_SdtMedida_Modeloid_Z = 0;
         SetDirty("Modeloid_Z");
         return  ;
      }

      public bool gxTv_SdtMedida_Modeloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaRin_Z" )]
      [  XmlElement( ElementName = "MedidaRin_Z"   )]
      public string gxTpr_Medidarin_Z
      {
         get {
            return gxTv_SdtMedida_Medidarin_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidarin_Z = value;
            SetDirty("Medidarin_Z");
         }

      }

      public void gxTv_SdtMedida_Medidarin_Z_SetNull( )
      {
         gxTv_SdtMedida_Medidarin_Z = "";
         SetDirty("Medidarin_Z");
         return  ;
      }

      public bool gxTv_SdtMedida_Medidarin_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloDescripcion_Z" )]
      [  XmlElement( ElementName = "ModeloDescripcion_Z"   )]
      public string gxTpr_Modelodescripcion_Z
      {
         get {
            return gxTv_SdtMedida_Modelodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Modelodescripcion_Z = value;
            SetDirty("Modelodescripcion_Z");
         }

      }

      public void gxTv_SdtMedida_Modelodescripcion_Z_SetNull( )
      {
         gxTv_SdtMedida_Modelodescripcion_Z = "";
         SetDirty("Modelodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtMedida_Modelodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloSegmento_Z" )]
      [  XmlElement( ElementName = "ModeloSegmento_Z"   )]
      public string gxTpr_Modelosegmento_Z
      {
         get {
            return gxTv_SdtMedida_Modelosegmento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Modelosegmento_Z = value;
            SetDirty("Modelosegmento_Z");
         }

      }

      public void gxTv_SdtMedida_Modelosegmento_Z_SetNull( )
      {
         gxTv_SdtMedida_Modelosegmento_Z = "";
         SetDirty("Modelosegmento_Z");
         return  ;
      }

      public bool gxTv_SdtMedida_Modelosegmento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaNombreCompleto_Z" )]
      [  XmlElement( ElementName = "MedidaNombreCompleto_Z"   )]
      public string gxTpr_Medidanombrecompleto_Z
      {
         get {
            return gxTv_SdtMedida_Medidanombrecompleto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidanombrecompleto_Z = value;
            SetDirty("Medidanombrecompleto_Z");
         }

      }

      public void gxTv_SdtMedida_Medidanombrecompleto_Z_SetNull( )
      {
         gxTv_SdtMedida_Medidanombrecompleto_Z = "";
         SetDirty("Medidanombrecompleto_Z");
         return  ;
      }

      public bool gxTv_SdtMedida_Medidanombrecompleto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaComentario_Z" )]
      [  XmlElement( ElementName = "MedidaComentario_Z"   )]
      public string gxTpr_Medidacomentario_Z
      {
         get {
            return gxTv_SdtMedida_Medidacomentario_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidacomentario_Z = value;
            SetDirty("Medidacomentario_Z");
         }

      }

      public void gxTv_SdtMedida_Medidacomentario_Z_SetNull( )
      {
         gxTv_SdtMedida_Medidacomentario_Z = "";
         SetDirty("Medidacomentario_Z");
         return  ;
      }

      public bool gxTv_SdtMedida_Medidacomentario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaActivo_Z" )]
      [  XmlElement( ElementName = "MedidaActivo_Z"   )]
      public bool gxTpr_Medidaactivo_Z
      {
         get {
            return gxTv_SdtMedida_Medidaactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMedida_Medidaactivo_Z = value;
            SetDirty("Medidaactivo_Z");
         }

      }

      public void gxTv_SdtMedida_Medidaactivo_Z_SetNull( )
      {
         gxTv_SdtMedida_Medidaactivo_Z = false;
         SetDirty("Medidaactivo_Z");
         return  ;
      }

      public bool gxTv_SdtMedida_Medidaactivo_Z_IsNull( )
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
         gxTv_SdtMedida_Medidacodigo = "";
         gxTv_SdtMedida_Medidadescripcion = "";
         gxTv_SdtMedida_Medidarin = "";
         gxTv_SdtMedida_Modelodescripcion = "";
         gxTv_SdtMedida_Modelosegmento = "";
         gxTv_SdtMedida_Medidanombrecompleto = "";
         gxTv_SdtMedida_Medidacomentario = "";
         gxTv_SdtMedida_Mode = "";
         gxTv_SdtMedida_Medidacodigo_Z = "";
         gxTv_SdtMedida_Medidadescripcion_Z = "";
         gxTv_SdtMedida_Medidarin_Z = "";
         gxTv_SdtMedida_Modelodescripcion_Z = "";
         gxTv_SdtMedida_Modelosegmento_Z = "";
         gxTv_SdtMedida_Medidanombrecompleto_Z = "";
         gxTv_SdtMedida_Medidacomentario_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "medida", "GeneXus.Programs.medida_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtMedida_Initialized ;
      private int gxTv_SdtMedida_Medidaid ;
      private int gxTv_SdtMedida_Modeloid ;
      private int gxTv_SdtMedida_Medidaid_Z ;
      private int gxTv_SdtMedida_Modeloid_Z ;
      private string gxTv_SdtMedida_Medidacodigo ;
      private string gxTv_SdtMedida_Medidarin ;
      private string gxTv_SdtMedida_Modelosegmento ;
      private string gxTv_SdtMedida_Mode ;
      private string gxTv_SdtMedida_Medidacodigo_Z ;
      private string gxTv_SdtMedida_Medidarin_Z ;
      private string gxTv_SdtMedida_Modelosegmento_Z ;
      private bool gxTv_SdtMedida_Medidaactivo ;
      private bool gxTv_SdtMedida_Medidaactivo_Z ;
      private string gxTv_SdtMedida_Medidadescripcion ;
      private string gxTv_SdtMedida_Modelodescripcion ;
      private string gxTv_SdtMedida_Medidanombrecompleto ;
      private string gxTv_SdtMedida_Medidacomentario ;
      private string gxTv_SdtMedida_Medidadescripcion_Z ;
      private string gxTv_SdtMedida_Modelodescripcion_Z ;
      private string gxTv_SdtMedida_Medidanombrecompleto_Z ;
      private string gxTv_SdtMedida_Medidacomentario_Z ;
   }

   [DataContract(Name = @"Medida", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtMedida_RESTInterface : GxGenericCollectionItem<SdtMedida>
   {
      public SdtMedida_RESTInterface( ) : base()
      {
      }

      public SdtMedida_RESTInterface( SdtMedida psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MedidaID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Medidaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Medidaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Medidaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MedidaCodigo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Medidacodigo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Medidacodigo) ;
         }

         set {
            sdt.gxTpr_Medidacodigo = value;
         }

      }

      [DataMember( Name = "MedidaDescripcion" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Medidadescripcion
      {
         get {
            return sdt.gxTpr_Medidadescripcion ;
         }

         set {
            sdt.gxTpr_Medidadescripcion = value;
         }

      }

      [DataMember( Name = "ModeloID" , Order = 3 )]
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

      [DataMember( Name = "MedidaRin" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Medidarin
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Medidarin) ;
         }

         set {
            sdt.gxTpr_Medidarin = value;
         }

      }

      [DataMember( Name = "ModeloDescripcion" , Order = 5 )]
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

      [DataMember( Name = "ModeloSegmento" , Order = 6 )]
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

      [DataMember( Name = "MedidaNombreCompleto" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Medidanombrecompleto
      {
         get {
            return sdt.gxTpr_Medidanombrecompleto ;
         }

         set {
            sdt.gxTpr_Medidanombrecompleto = value;
         }

      }

      [DataMember( Name = "MedidaComentario" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Medidacomentario
      {
         get {
            return sdt.gxTpr_Medidacomentario ;
         }

         set {
            sdt.gxTpr_Medidacomentario = value;
         }

      }

      [DataMember( Name = "MedidaActivo" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Medidaactivo
      {
         get {
            return sdt.gxTpr_Medidaactivo ;
         }

         set {
            sdt.gxTpr_Medidaactivo = value;
         }

      }

      public SdtMedida sdt
      {
         get {
            return (SdtMedida)Sdt ;
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
            sdt = new SdtMedida() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 10 )]
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

   [DataContract(Name = @"Medida", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtMedida_RESTLInterface : GxGenericCollectionItem<SdtMedida>
   {
      public SdtMedida_RESTLInterface( ) : base()
      {
      }

      public SdtMedida_RESTLInterface( SdtMedida psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MedidaCodigo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Medidacodigo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Medidacodigo) ;
         }

         set {
            sdt.gxTpr_Medidacodigo = value;
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

      public SdtMedida sdt
      {
         get {
            return (SdtMedida)Sdt ;
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
            sdt = new SdtMedida() ;
         }
      }

   }

}
