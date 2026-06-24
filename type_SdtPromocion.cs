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
   [XmlRoot(ElementName = "Promocion" )]
   [XmlType(TypeName =  "Promocion" , Namespace = "Premios" )]
   [Serializable]
   public class SdtPromocion : GxSilentTrnSdt
   {
      public SdtPromocion( )
      {
      }

      public SdtPromocion( IGxContext context )
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

      public void Load( int AV41PromocionID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV41PromocionID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PromocionID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Promocion");
         metadata.Set("BT", "Promocion");
         metadata.Set("PK", "[ \"PromocionID\" ]");
         metadata.Set("PKAssigned", "[ \"PromocionID\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Promocionarte_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Promocionid_Z");
         state.Add("gxTpr_Promociondescripcion_Z");
         state.Add("gxTpr_Promocionbase_Z");
         state.Add("gxTpr_Promocionfechainicio_Z_Nullable");
         state.Add("gxTpr_Promocionfechafin_Z_Nullable");
         state.Add("gxTpr_Promocionvigencia_Z");
         state.Add("gxTpr_Promocionarte_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPromocion sdt;
         sdt = (SdtPromocion)(source);
         gxTv_SdtPromocion_Promocionid = sdt.gxTv_SdtPromocion_Promocionid ;
         gxTv_SdtPromocion_Promociondescripcion = sdt.gxTv_SdtPromocion_Promociondescripcion ;
         gxTv_SdtPromocion_Promocionbase = sdt.gxTv_SdtPromocion_Promocionbase ;
         gxTv_SdtPromocion_Promocionarte = sdt.gxTv_SdtPromocion_Promocionarte ;
         gxTv_SdtPromocion_Promocionarte_gxi = sdt.gxTv_SdtPromocion_Promocionarte_gxi ;
         gxTv_SdtPromocion_Promocionfechainicio = sdt.gxTv_SdtPromocion_Promocionfechainicio ;
         gxTv_SdtPromocion_Promocionfechafin = sdt.gxTv_SdtPromocion_Promocionfechafin ;
         gxTv_SdtPromocion_Promocionvigencia = sdt.gxTv_SdtPromocion_Promocionvigencia ;
         gxTv_SdtPromocion_Promocionsegmentosjson = sdt.gxTv_SdtPromocion_Promocionsegmentosjson ;
         gxTv_SdtPromocion_Mode = sdt.gxTv_SdtPromocion_Mode ;
         gxTv_SdtPromocion_Initialized = sdt.gxTv_SdtPromocion_Initialized ;
         gxTv_SdtPromocion_Promocionid_Z = sdt.gxTv_SdtPromocion_Promocionid_Z ;
         gxTv_SdtPromocion_Promociondescripcion_Z = sdt.gxTv_SdtPromocion_Promociondescripcion_Z ;
         gxTv_SdtPromocion_Promocionbase_Z = sdt.gxTv_SdtPromocion_Promocionbase_Z ;
         gxTv_SdtPromocion_Promocionfechainicio_Z = sdt.gxTv_SdtPromocion_Promocionfechainicio_Z ;
         gxTv_SdtPromocion_Promocionfechafin_Z = sdt.gxTv_SdtPromocion_Promocionfechafin_Z ;
         gxTv_SdtPromocion_Promocionvigencia_Z = sdt.gxTv_SdtPromocion_Promocionvigencia_Z ;
         gxTv_SdtPromocion_Promocionarte_gxi_Z = sdt.gxTv_SdtPromocion_Promocionarte_gxi_Z ;
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
         AddObjectProperty("PromocionID", gxTv_SdtPromocion_Promocionid, false, includeNonInitialized);
         AddObjectProperty("PromocionDescripcion", gxTv_SdtPromocion_Promociondescripcion, false, includeNonInitialized);
         AddObjectProperty("PromocionBase", gxTv_SdtPromocion_Promocionbase, false, includeNonInitialized);
         AddObjectProperty("PromocionArte", gxTv_SdtPromocion_Promocionarte, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPromocion_Promocionfechainicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPromocion_Promocionfechainicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPromocion_Promocionfechainicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PromocionFechaInicio", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPromocion_Promocionfechafin)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPromocion_Promocionfechafin)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPromocion_Promocionfechafin)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PromocionFechaFin", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PromocionVigencia", gxTv_SdtPromocion_Promocionvigencia, false, includeNonInitialized);
         AddObjectProperty("PromocionSegmentosJson", gxTv_SdtPromocion_Promocionsegmentosjson, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("PromocionArte_GXI", gxTv_SdtPromocion_Promocionarte_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtPromocion_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPromocion_Initialized, false, includeNonInitialized);
            AddObjectProperty("PromocionID_Z", gxTv_SdtPromocion_Promocionid_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionDescripcion_Z", gxTv_SdtPromocion_Promociondescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionBase_Z", gxTv_SdtPromocion_Promocionbase_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPromocion_Promocionfechainicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPromocion_Promocionfechainicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPromocion_Promocionfechainicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PromocionFechaInicio_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPromocion_Promocionfechafin_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPromocion_Promocionfechafin_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPromocion_Promocionfechafin_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PromocionFechaFin_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PromocionVigencia_Z", gxTv_SdtPromocion_Promocionvigencia_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionArte_GXI_Z", gxTv_SdtPromocion_Promocionarte_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPromocion sdt )
      {
         if ( sdt.IsDirty("PromocionID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionid = sdt.gxTv_SdtPromocion_Promocionid ;
         }
         if ( sdt.IsDirty("PromocionDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promociondescripcion = sdt.gxTv_SdtPromocion_Promociondescripcion ;
         }
         if ( sdt.IsDirty("PromocionBase") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionbase = sdt.gxTv_SdtPromocion_Promocionbase ;
         }
         if ( sdt.IsDirty("PromocionArte") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionarte = sdt.gxTv_SdtPromocion_Promocionarte ;
         }
         if ( sdt.IsDirty("PromocionArte") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionarte_gxi = sdt.gxTv_SdtPromocion_Promocionarte_gxi ;
         }
         if ( sdt.IsDirty("PromocionFechaInicio") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionfechainicio = sdt.gxTv_SdtPromocion_Promocionfechainicio ;
         }
         if ( sdt.IsDirty("PromocionFechaFin") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionfechafin = sdt.gxTv_SdtPromocion_Promocionfechafin ;
         }
         if ( sdt.IsDirty("PromocionVigencia") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionvigencia = sdt.gxTv_SdtPromocion_Promocionvigencia ;
         }
         if ( sdt.IsDirty("PromocionSegmentosJson") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionsegmentosjson = sdt.gxTv_SdtPromocion_Promocionsegmentosjson ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PromocionID" )]
      [  XmlElement( ElementName = "PromocionID"   )]
      public int gxTpr_Promocionid
      {
         get {
            return gxTv_SdtPromocion_Promocionid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPromocion_Promocionid != value )
            {
               gxTv_SdtPromocion_Mode = "INS";
               this.gxTv_SdtPromocion_Promocionid_Z_SetNull( );
               this.gxTv_SdtPromocion_Promociondescripcion_Z_SetNull( );
               this.gxTv_SdtPromocion_Promocionbase_Z_SetNull( );
               this.gxTv_SdtPromocion_Promocionfechainicio_Z_SetNull( );
               this.gxTv_SdtPromocion_Promocionfechafin_Z_SetNull( );
               this.gxTv_SdtPromocion_Promocionvigencia_Z_SetNull( );
               this.gxTv_SdtPromocion_Promocionarte_gxi_Z_SetNull( );
            }
            gxTv_SdtPromocion_Promocionid = value;
            SetDirty("Promocionid");
         }

      }

      [  SoapElement( ElementName = "PromocionDescripcion" )]
      [  XmlElement( ElementName = "PromocionDescripcion"   )]
      public string gxTpr_Promociondescripcion
      {
         get {
            return gxTv_SdtPromocion_Promociondescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promociondescripcion = value;
            SetDirty("Promociondescripcion");
         }

      }

      [  SoapElement( ElementName = "PromocionBase" )]
      [  XmlElement( ElementName = "PromocionBase"   )]
      public string gxTpr_Promocionbase
      {
         get {
            return gxTv_SdtPromocion_Promocionbase ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionbase = value;
            SetDirty("Promocionbase");
         }

      }

      [  SoapElement( ElementName = "PromocionArte" )]
      [  XmlElement( ElementName = "PromocionArte"   )]
      [GxUpload()]
      public string gxTpr_Promocionarte
      {
         get {
            return gxTv_SdtPromocion_Promocionarte ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionarte = value;
            SetDirty("Promocionarte");
         }

      }

      [  SoapElement( ElementName = "PromocionArte_GXI" )]
      [  XmlElement( ElementName = "PromocionArte_GXI"   )]
      public string gxTpr_Promocionarte_gxi
      {
         get {
            return gxTv_SdtPromocion_Promocionarte_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionarte_gxi = value;
            SetDirty("Promocionarte_gxi");
         }

      }

      [  SoapElement( ElementName = "PromocionFechaInicio" )]
      [  XmlElement( ElementName = "PromocionFechaInicio"  , IsNullable=true )]
      public string gxTpr_Promocionfechainicio_Nullable
      {
         get {
            if ( gxTv_SdtPromocion_Promocionfechainicio == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPromocion_Promocionfechainicio).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPromocion_Promocionfechainicio = DateTime.MinValue;
            else
               gxTv_SdtPromocion_Promocionfechainicio = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Promocionfechainicio
      {
         get {
            return gxTv_SdtPromocion_Promocionfechainicio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionfechainicio = value;
            SetDirty("Promocionfechainicio");
         }

      }

      [  SoapElement( ElementName = "PromocionFechaFin" )]
      [  XmlElement( ElementName = "PromocionFechaFin"  , IsNullable=true )]
      public string gxTpr_Promocionfechafin_Nullable
      {
         get {
            if ( gxTv_SdtPromocion_Promocionfechafin == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPromocion_Promocionfechafin).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPromocion_Promocionfechafin = DateTime.MinValue;
            else
               gxTv_SdtPromocion_Promocionfechafin = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Promocionfechafin
      {
         get {
            return gxTv_SdtPromocion_Promocionfechafin ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionfechafin = value;
            SetDirty("Promocionfechafin");
         }

      }

      [  SoapElement( ElementName = "PromocionVigencia" )]
      [  XmlElement( ElementName = "PromocionVigencia"   )]
      public string gxTpr_Promocionvigencia
      {
         get {
            return gxTv_SdtPromocion_Promocionvigencia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionvigencia = value;
            SetDirty("Promocionvigencia");
         }

      }

      public void gxTv_SdtPromocion_Promocionvigencia_SetNull( )
      {
         gxTv_SdtPromocion_Promocionvigencia = "";
         SetDirty("Promocionvigencia");
         return  ;
      }

      public bool gxTv_SdtPromocion_Promocionvigencia_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionSegmentosJson" )]
      [  XmlElement( ElementName = "PromocionSegmentosJson"   )]
      public string gxTpr_Promocionsegmentosjson
      {
         get {
            return gxTv_SdtPromocion_Promocionsegmentosjson ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionsegmentosjson = value;
            SetDirty("Promocionsegmentosjson");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPromocion_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPromocion_Mode_SetNull( )
      {
         gxTv_SdtPromocion_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPromocion_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPromocion_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPromocion_Initialized_SetNull( )
      {
         gxTv_SdtPromocion_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPromocion_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionID_Z" )]
      [  XmlElement( ElementName = "PromocionID_Z"   )]
      public int gxTpr_Promocionid_Z
      {
         get {
            return gxTv_SdtPromocion_Promocionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionid_Z = value;
            SetDirty("Promocionid_Z");
         }

      }

      public void gxTv_SdtPromocion_Promocionid_Z_SetNull( )
      {
         gxTv_SdtPromocion_Promocionid_Z = 0;
         SetDirty("Promocionid_Z");
         return  ;
      }

      public bool gxTv_SdtPromocion_Promocionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionDescripcion_Z" )]
      [  XmlElement( ElementName = "PromocionDescripcion_Z"   )]
      public string gxTpr_Promociondescripcion_Z
      {
         get {
            return gxTv_SdtPromocion_Promociondescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promociondescripcion_Z = value;
            SetDirty("Promociondescripcion_Z");
         }

      }

      public void gxTv_SdtPromocion_Promociondescripcion_Z_SetNull( )
      {
         gxTv_SdtPromocion_Promociondescripcion_Z = "";
         SetDirty("Promociondescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtPromocion_Promociondescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionBase_Z" )]
      [  XmlElement( ElementName = "PromocionBase_Z"   )]
      public string gxTpr_Promocionbase_Z
      {
         get {
            return gxTv_SdtPromocion_Promocionbase_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionbase_Z = value;
            SetDirty("Promocionbase_Z");
         }

      }

      public void gxTv_SdtPromocion_Promocionbase_Z_SetNull( )
      {
         gxTv_SdtPromocion_Promocionbase_Z = "";
         SetDirty("Promocionbase_Z");
         return  ;
      }

      public bool gxTv_SdtPromocion_Promocionbase_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionFechaInicio_Z" )]
      [  XmlElement( ElementName = "PromocionFechaInicio_Z"  , IsNullable=true )]
      public string gxTpr_Promocionfechainicio_Z_Nullable
      {
         get {
            if ( gxTv_SdtPromocion_Promocionfechainicio_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPromocion_Promocionfechainicio_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPromocion_Promocionfechainicio_Z = DateTime.MinValue;
            else
               gxTv_SdtPromocion_Promocionfechainicio_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Promocionfechainicio_Z
      {
         get {
            return gxTv_SdtPromocion_Promocionfechainicio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionfechainicio_Z = value;
            SetDirty("Promocionfechainicio_Z");
         }

      }

      public void gxTv_SdtPromocion_Promocionfechainicio_Z_SetNull( )
      {
         gxTv_SdtPromocion_Promocionfechainicio_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Promocionfechainicio_Z");
         return  ;
      }

      public bool gxTv_SdtPromocion_Promocionfechainicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionFechaFin_Z" )]
      [  XmlElement( ElementName = "PromocionFechaFin_Z"  , IsNullable=true )]
      public string gxTpr_Promocionfechafin_Z_Nullable
      {
         get {
            if ( gxTv_SdtPromocion_Promocionfechafin_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPromocion_Promocionfechafin_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPromocion_Promocionfechafin_Z = DateTime.MinValue;
            else
               gxTv_SdtPromocion_Promocionfechafin_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Promocionfechafin_Z
      {
         get {
            return gxTv_SdtPromocion_Promocionfechafin_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionfechafin_Z = value;
            SetDirty("Promocionfechafin_Z");
         }

      }

      public void gxTv_SdtPromocion_Promocionfechafin_Z_SetNull( )
      {
         gxTv_SdtPromocion_Promocionfechafin_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Promocionfechafin_Z");
         return  ;
      }

      public bool gxTv_SdtPromocion_Promocionfechafin_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionVigencia_Z" )]
      [  XmlElement( ElementName = "PromocionVigencia_Z"   )]
      public string gxTpr_Promocionvigencia_Z
      {
         get {
            return gxTv_SdtPromocion_Promocionvigencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionvigencia_Z = value;
            SetDirty("Promocionvigencia_Z");
         }

      }

      public void gxTv_SdtPromocion_Promocionvigencia_Z_SetNull( )
      {
         gxTv_SdtPromocion_Promocionvigencia_Z = "";
         SetDirty("Promocionvigencia_Z");
         return  ;
      }

      public bool gxTv_SdtPromocion_Promocionvigencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionArte_GXI_Z" )]
      [  XmlElement( ElementName = "PromocionArte_GXI_Z"   )]
      public string gxTpr_Promocionarte_gxi_Z
      {
         get {
            return gxTv_SdtPromocion_Promocionarte_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocion_Promocionarte_gxi_Z = value;
            SetDirty("Promocionarte_gxi_Z");
         }

      }

      public void gxTv_SdtPromocion_Promocionarte_gxi_Z_SetNull( )
      {
         gxTv_SdtPromocion_Promocionarte_gxi_Z = "";
         SetDirty("Promocionarte_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtPromocion_Promocionarte_gxi_Z_IsNull( )
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
         gxTv_SdtPromocion_Promociondescripcion = "";
         gxTv_SdtPromocion_Promocionbase = "";
         gxTv_SdtPromocion_Promocionarte = "";
         gxTv_SdtPromocion_Promocionarte_gxi = "";
         gxTv_SdtPromocion_Promocionfechainicio = DateTime.MinValue;
         gxTv_SdtPromocion_Promocionfechafin = DateTime.MinValue;
         gxTv_SdtPromocion_Promocionvigencia = "";
         gxTv_SdtPromocion_Promocionsegmentosjson = "";
         gxTv_SdtPromocion_Mode = "";
         gxTv_SdtPromocion_Promociondescripcion_Z = "";
         gxTv_SdtPromocion_Promocionbase_Z = "";
         gxTv_SdtPromocion_Promocionfechainicio_Z = DateTime.MinValue;
         gxTv_SdtPromocion_Promocionfechafin_Z = DateTime.MinValue;
         gxTv_SdtPromocion_Promocionvigencia_Z = "";
         gxTv_SdtPromocion_Promocionarte_gxi_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "promocion", "GeneXus.Programs.promocion_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPromocion_Initialized ;
      private int gxTv_SdtPromocion_Promocionid ;
      private int gxTv_SdtPromocion_Promocionid_Z ;
      private string gxTv_SdtPromocion_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtPromocion_Promocionfechainicio ;
      private DateTime gxTv_SdtPromocion_Promocionfechafin ;
      private DateTime gxTv_SdtPromocion_Promocionfechainicio_Z ;
      private DateTime gxTv_SdtPromocion_Promocionfechafin_Z ;
      private string gxTv_SdtPromocion_Promocionsegmentosjson ;
      private string gxTv_SdtPromocion_Promociondescripcion ;
      private string gxTv_SdtPromocion_Promocionbase ;
      private string gxTv_SdtPromocion_Promocionarte_gxi ;
      private string gxTv_SdtPromocion_Promocionvigencia ;
      private string gxTv_SdtPromocion_Promociondescripcion_Z ;
      private string gxTv_SdtPromocion_Promocionbase_Z ;
      private string gxTv_SdtPromocion_Promocionvigencia_Z ;
      private string gxTv_SdtPromocion_Promocionarte_gxi_Z ;
      private string gxTv_SdtPromocion_Promocionarte ;
   }

   [DataContract(Name = @"Promocion", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtPromocion_RESTInterface : GxGenericCollectionItem<SdtPromocion>
   {
      public SdtPromocion_RESTInterface( ) : base()
      {
      }

      public SdtPromocion_RESTInterface( SdtPromocion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PromocionID" , Order = 0 )]
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

      [DataMember( Name = "PromocionDescripcion" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Promociondescripcion
      {
         get {
            return sdt.gxTpr_Promociondescripcion ;
         }

         set {
            sdt.gxTpr_Promociondescripcion = value;
         }

      }

      [DataMember( Name = "PromocionBase" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Promocionbase
      {
         get {
            return sdt.gxTpr_Promocionbase ;
         }

         set {
            sdt.gxTpr_Promocionbase = value;
         }

      }

      [DataMember( Name = "PromocionArte" , Order = 3 )]
      [GxUpload()]
      public string gxTpr_Promocionarte
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Promocionarte)) ? PathUtil.RelativeURL( sdt.gxTpr_Promocionarte) : StringUtil.RTrim( sdt.gxTpr_Promocionarte_gxi)) ;
         }

         set {
            sdt.gxTpr_Promocionarte = value;
         }

      }

      [DataMember( Name = "PromocionFechaInicio" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Promocionfechainicio
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Promocionfechainicio) ;
         }

         set {
            sdt.gxTpr_Promocionfechainicio = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PromocionFechaFin" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Promocionfechafin
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Promocionfechafin) ;
         }

         set {
            sdt.gxTpr_Promocionfechafin = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PromocionVigencia" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Promocionvigencia
      {
         get {
            return sdt.gxTpr_Promocionvigencia ;
         }

         set {
            sdt.gxTpr_Promocionvigencia = value;
         }

      }

      [DataMember( Name = "PromocionSegmentosJson" , Order = 7 )]
      public string gxTpr_Promocionsegmentosjson
      {
         get {
            return sdt.gxTpr_Promocionsegmentosjson ;
         }

         set {
            sdt.gxTpr_Promocionsegmentosjson = value;
         }

      }

      public SdtPromocion sdt
      {
         get {
            return (SdtPromocion)Sdt ;
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
            sdt = new SdtPromocion() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 8 )]
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

   [DataContract(Name = @"Promocion", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtPromocion_RESTLInterface : GxGenericCollectionItem<SdtPromocion>
   {
      public SdtPromocion_RESTLInterface( ) : base()
      {
      }

      public SdtPromocion_RESTLInterface( SdtPromocion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PromocionDescripcion" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Promociondescripcion
      {
         get {
            return sdt.gxTpr_Promociondescripcion ;
         }

         set {
            sdt.gxTpr_Promociondescripcion = value;
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

      public SdtPromocion sdt
      {
         get {
            return (SdtPromocion)Sdt ;
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
            sdt = new SdtPromocion() ;
         }
      }

   }

}
