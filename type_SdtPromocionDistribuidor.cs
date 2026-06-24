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
   [XmlRoot(ElementName = "PromocionDistribuidor" )]
   [XmlType(TypeName =  "PromocionDistribuidor" , Namespace = "Premios" )]
   [Serializable]
   public class SdtPromocionDistribuidor : GxSilentTrnSdt
   {
      public SdtPromocionDistribuidor( )
      {
      }

      public SdtPromocionDistribuidor( IGxContext context )
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

      public void Load( int AV47PromocionDistribuidorID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV47PromocionDistribuidorID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PromocionDistribuidorID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PromocionDistribuidor");
         metadata.Set("BT", "PromocionDistribuidor");
         metadata.Set("PK", "[ \"PromocionDistribuidorID\" ]");
         metadata.Set("PKAssigned", "[ \"PromocionDistribuidorID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DistribuidorID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PromocionID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Promociondistribuidorid_Z");
         state.Add("gxTpr_Promocionid_Z");
         state.Add("gxTpr_Promociondescripcion_Z");
         state.Add("gxTpr_Promocionbase_Z");
         state.Add("gxTpr_Promocionfechainicio_Z_Nullable");
         state.Add("gxTpr_Promocionfechafin_Z_Nullable");
         state.Add("gxTpr_Distribuidorid_Z");
         state.Add("gxTpr_Distribuidordescripcion_Z");
         state.Add("gxTpr_Promocionarte_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPromocionDistribuidor sdt;
         sdt = (SdtPromocionDistribuidor)(source);
         gxTv_SdtPromocionDistribuidor_Promociondistribuidorid = sdt.gxTv_SdtPromocionDistribuidor_Promociondistribuidorid ;
         gxTv_SdtPromocionDistribuidor_Promocionid = sdt.gxTv_SdtPromocionDistribuidor_Promocionid ;
         gxTv_SdtPromocionDistribuidor_Promociondescripcion = sdt.gxTv_SdtPromocionDistribuidor_Promociondescripcion ;
         gxTv_SdtPromocionDistribuidor_Promocionbase = sdt.gxTv_SdtPromocionDistribuidor_Promocionbase ;
         gxTv_SdtPromocionDistribuidor_Promocionarte = sdt.gxTv_SdtPromocionDistribuidor_Promocionarte ;
         gxTv_SdtPromocionDistribuidor_Promocionarte_gxi = sdt.gxTv_SdtPromocionDistribuidor_Promocionarte_gxi ;
         gxTv_SdtPromocionDistribuidor_Promocionfechainicio = sdt.gxTv_SdtPromocionDistribuidor_Promocionfechainicio ;
         gxTv_SdtPromocionDistribuidor_Promocionfechafin = sdt.gxTv_SdtPromocionDistribuidor_Promocionfechafin ;
         gxTv_SdtPromocionDistribuidor_Distribuidorid = sdt.gxTv_SdtPromocionDistribuidor_Distribuidorid ;
         gxTv_SdtPromocionDistribuidor_Distribuidordescripcion = sdt.gxTv_SdtPromocionDistribuidor_Distribuidordescripcion ;
         gxTv_SdtPromocionDistribuidor_Mode = sdt.gxTv_SdtPromocionDistribuidor_Mode ;
         gxTv_SdtPromocionDistribuidor_Initialized = sdt.gxTv_SdtPromocionDistribuidor_Initialized ;
         gxTv_SdtPromocionDistribuidor_Promociondistribuidorid_Z = sdt.gxTv_SdtPromocionDistribuidor_Promociondistribuidorid_Z ;
         gxTv_SdtPromocionDistribuidor_Promocionid_Z = sdt.gxTv_SdtPromocionDistribuidor_Promocionid_Z ;
         gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z = sdt.gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z ;
         gxTv_SdtPromocionDistribuidor_Promocionbase_Z = sdt.gxTv_SdtPromocionDistribuidor_Promocionbase_Z ;
         gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z = sdt.gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z ;
         gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z = sdt.gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z ;
         gxTv_SdtPromocionDistribuidor_Distribuidorid_Z = sdt.gxTv_SdtPromocionDistribuidor_Distribuidorid_Z ;
         gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z = sdt.gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z ;
         gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z = sdt.gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z ;
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
         AddObjectProperty("PromocionDistribuidorID", gxTv_SdtPromocionDistribuidor_Promociondistribuidorid, false, includeNonInitialized);
         AddObjectProperty("PromocionID", gxTv_SdtPromocionDistribuidor_Promocionid, false, includeNonInitialized);
         AddObjectProperty("PromocionDescripcion", gxTv_SdtPromocionDistribuidor_Promociondescripcion, false, includeNonInitialized);
         AddObjectProperty("PromocionBase", gxTv_SdtPromocionDistribuidor_Promocionbase, false, includeNonInitialized);
         AddObjectProperty("PromocionArte", gxTv_SdtPromocionDistribuidor_Promocionarte, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPromocionDistribuidor_Promocionfechainicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPromocionDistribuidor_Promocionfechainicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPromocionDistribuidor_Promocionfechainicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PromocionFechaInicio", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPromocionDistribuidor_Promocionfechafin)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPromocionDistribuidor_Promocionfechafin)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPromocionDistribuidor_Promocionfechafin)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PromocionFechaFin", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DistribuidorID", gxTv_SdtPromocionDistribuidor_Distribuidorid, false, includeNonInitialized);
         AddObjectProperty("DistribuidorDescripcion", gxTv_SdtPromocionDistribuidor_Distribuidordescripcion, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("PromocionArte_GXI", gxTv_SdtPromocionDistribuidor_Promocionarte_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtPromocionDistribuidor_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPromocionDistribuidor_Initialized, false, includeNonInitialized);
            AddObjectProperty("PromocionDistribuidorID_Z", gxTv_SdtPromocionDistribuidor_Promociondistribuidorid_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionID_Z", gxTv_SdtPromocionDistribuidor_Promocionid_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionDescripcion_Z", gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionBase_Z", gxTv_SdtPromocionDistribuidor_Promocionbase_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PromocionFechaInicio_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PromocionFechaFin_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DistribuidorID_Z", gxTv_SdtPromocionDistribuidor_Distribuidorid_Z, false, includeNonInitialized);
            AddObjectProperty("DistribuidorDescripcion_Z", gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionArte_GXI_Z", gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPromocionDistribuidor sdt )
      {
         if ( sdt.IsDirty("PromocionDistribuidorID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promociondistribuidorid = sdt.gxTv_SdtPromocionDistribuidor_Promociondistribuidorid ;
         }
         if ( sdt.IsDirty("PromocionID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionid = sdt.gxTv_SdtPromocionDistribuidor_Promocionid ;
         }
         if ( sdt.IsDirty("PromocionDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promociondescripcion = sdt.gxTv_SdtPromocionDistribuidor_Promociondescripcion ;
         }
         if ( sdt.IsDirty("PromocionBase") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionbase = sdt.gxTv_SdtPromocionDistribuidor_Promocionbase ;
         }
         if ( sdt.IsDirty("PromocionArte") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionarte = sdt.gxTv_SdtPromocionDistribuidor_Promocionarte ;
         }
         if ( sdt.IsDirty("PromocionArte") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionarte_gxi = sdt.gxTv_SdtPromocionDistribuidor_Promocionarte_gxi ;
         }
         if ( sdt.IsDirty("PromocionFechaInicio") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionfechainicio = sdt.gxTv_SdtPromocionDistribuidor_Promocionfechainicio ;
         }
         if ( sdt.IsDirty("PromocionFechaFin") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionfechafin = sdt.gxTv_SdtPromocionDistribuidor_Promocionfechafin ;
         }
         if ( sdt.IsDirty("DistribuidorID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Distribuidorid = sdt.gxTv_SdtPromocionDistribuidor_Distribuidorid ;
         }
         if ( sdt.IsDirty("DistribuidorDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Distribuidordescripcion = sdt.gxTv_SdtPromocionDistribuidor_Distribuidordescripcion ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PromocionDistribuidorID" )]
      [  XmlElement( ElementName = "PromocionDistribuidorID"   )]
      public int gxTpr_Promociondistribuidorid
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promociondistribuidorid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPromocionDistribuidor_Promociondistribuidorid != value )
            {
               gxTv_SdtPromocionDistribuidor_Mode = "INS";
               this.gxTv_SdtPromocionDistribuidor_Promociondistribuidorid_Z_SetNull( );
               this.gxTv_SdtPromocionDistribuidor_Promocionid_Z_SetNull( );
               this.gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z_SetNull( );
               this.gxTv_SdtPromocionDistribuidor_Promocionbase_Z_SetNull( );
               this.gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z_SetNull( );
               this.gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z_SetNull( );
               this.gxTv_SdtPromocionDistribuidor_Distribuidorid_Z_SetNull( );
               this.gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z_SetNull( );
               this.gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z_SetNull( );
            }
            gxTv_SdtPromocionDistribuidor_Promociondistribuidorid = value;
            SetDirty("Promociondistribuidorid");
         }

      }

      [  SoapElement( ElementName = "PromocionID" )]
      [  XmlElement( ElementName = "PromocionID"   )]
      public int gxTpr_Promocionid
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionid = value;
            SetDirty("Promocionid");
         }

      }

      [  SoapElement( ElementName = "PromocionDescripcion" )]
      [  XmlElement( ElementName = "PromocionDescripcion"   )]
      public string gxTpr_Promociondescripcion
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promociondescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promociondescripcion = value;
            SetDirty("Promociondescripcion");
         }

      }

      [  SoapElement( ElementName = "PromocionBase" )]
      [  XmlElement( ElementName = "PromocionBase"   )]
      public string gxTpr_Promocionbase
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionbase ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionbase = value;
            SetDirty("Promocionbase");
         }

      }

      [  SoapElement( ElementName = "PromocionArte" )]
      [  XmlElement( ElementName = "PromocionArte"   )]
      [GxUpload()]
      public string gxTpr_Promocionarte
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionarte ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionarte = value;
            SetDirty("Promocionarte");
         }

      }

      [  SoapElement( ElementName = "PromocionArte_GXI" )]
      [  XmlElement( ElementName = "PromocionArte_GXI"   )]
      public string gxTpr_Promocionarte_gxi
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionarte_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionarte_gxi = value;
            SetDirty("Promocionarte_gxi");
         }

      }

      [  SoapElement( ElementName = "PromocionFechaInicio" )]
      [  XmlElement( ElementName = "PromocionFechaInicio"  , IsNullable=true )]
      public string gxTpr_Promocionfechainicio_Nullable
      {
         get {
            if ( gxTv_SdtPromocionDistribuidor_Promocionfechainicio == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPromocionDistribuidor_Promocionfechainicio).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPromocionDistribuidor_Promocionfechainicio = DateTime.MinValue;
            else
               gxTv_SdtPromocionDistribuidor_Promocionfechainicio = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Promocionfechainicio
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionfechainicio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionfechainicio = value;
            SetDirty("Promocionfechainicio");
         }

      }

      [  SoapElement( ElementName = "PromocionFechaFin" )]
      [  XmlElement( ElementName = "PromocionFechaFin"  , IsNullable=true )]
      public string gxTpr_Promocionfechafin_Nullable
      {
         get {
            if ( gxTv_SdtPromocionDistribuidor_Promocionfechafin == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPromocionDistribuidor_Promocionfechafin).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPromocionDistribuidor_Promocionfechafin = DateTime.MinValue;
            else
               gxTv_SdtPromocionDistribuidor_Promocionfechafin = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Promocionfechafin
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionfechafin ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionfechafin = value;
            SetDirty("Promocionfechafin");
         }

      }

      [  SoapElement( ElementName = "DistribuidorID" )]
      [  XmlElement( ElementName = "DistribuidorID"   )]
      public int gxTpr_Distribuidorid
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Distribuidorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Distribuidorid = value;
            SetDirty("Distribuidorid");
         }

      }

      [  SoapElement( ElementName = "DistribuidorDescripcion" )]
      [  XmlElement( ElementName = "DistribuidorDescripcion"   )]
      public string gxTpr_Distribuidordescripcion
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Distribuidordescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Distribuidordescripcion = value;
            SetDirty("Distribuidordescripcion");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Mode_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Initialized_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionDistribuidorID_Z" )]
      [  XmlElement( ElementName = "PromocionDistribuidorID_Z"   )]
      public int gxTpr_Promociondistribuidorid_Z
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promociondistribuidorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promociondistribuidorid_Z = value;
            SetDirty("Promociondistribuidorid_Z");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Promociondistribuidorid_Z_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Promociondistribuidorid_Z = 0;
         SetDirty("Promociondistribuidorid_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Promociondistribuidorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionID_Z" )]
      [  XmlElement( ElementName = "PromocionID_Z"   )]
      public int gxTpr_Promocionid_Z
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionid_Z = value;
            SetDirty("Promocionid_Z");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Promocionid_Z_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Promocionid_Z = 0;
         SetDirty("Promocionid_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Promocionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionDescripcion_Z" )]
      [  XmlElement( ElementName = "PromocionDescripcion_Z"   )]
      public string gxTpr_Promociondescripcion_Z
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z = value;
            SetDirty("Promociondescripcion_Z");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z = "";
         SetDirty("Promociondescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionBase_Z" )]
      [  XmlElement( ElementName = "PromocionBase_Z"   )]
      public string gxTpr_Promocionbase_Z
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionbase_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionbase_Z = value;
            SetDirty("Promocionbase_Z");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Promocionbase_Z_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Promocionbase_Z = "";
         SetDirty("Promocionbase_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Promocionbase_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionFechaInicio_Z" )]
      [  XmlElement( ElementName = "PromocionFechaInicio_Z"  , IsNullable=true )]
      public string gxTpr_Promocionfechainicio_Z_Nullable
      {
         get {
            if ( gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z = DateTime.MinValue;
            else
               gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Promocionfechainicio_Z
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z = value;
            SetDirty("Promocionfechainicio_Z");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Promocionfechainicio_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionFechaFin_Z" )]
      [  XmlElement( ElementName = "PromocionFechaFin_Z"  , IsNullable=true )]
      public string gxTpr_Promocionfechafin_Z_Nullable
      {
         get {
            if ( gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z = DateTime.MinValue;
            else
               gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Promocionfechafin_Z
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z = value;
            SetDirty("Promocionfechafin_Z");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Promocionfechafin_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DistribuidorID_Z" )]
      [  XmlElement( ElementName = "DistribuidorID_Z"   )]
      public int gxTpr_Distribuidorid_Z
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Distribuidorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Distribuidorid_Z = value;
            SetDirty("Distribuidorid_Z");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Distribuidorid_Z_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Distribuidorid_Z = 0;
         SetDirty("Distribuidorid_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Distribuidorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DistribuidorDescripcion_Z" )]
      [  XmlElement( ElementName = "DistribuidorDescripcion_Z"   )]
      public string gxTpr_Distribuidordescripcion_Z
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z = value;
            SetDirty("Distribuidordescripcion_Z");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z = "";
         SetDirty("Distribuidordescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionArte_GXI_Z" )]
      [  XmlElement( ElementName = "PromocionArte_GXI_Z"   )]
      public string gxTpr_Promocionarte_gxi_Z
      {
         get {
            return gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z = value;
            SetDirty("Promocionarte_gxi_Z");
         }

      }

      public void gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z_SetNull( )
      {
         gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z = "";
         SetDirty("Promocionarte_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z_IsNull( )
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
         gxTv_SdtPromocionDistribuidor_Promociondescripcion = "";
         gxTv_SdtPromocionDistribuidor_Promocionbase = "";
         gxTv_SdtPromocionDistribuidor_Promocionarte = "";
         gxTv_SdtPromocionDistribuidor_Promocionarte_gxi = "";
         gxTv_SdtPromocionDistribuidor_Promocionfechainicio = DateTime.MinValue;
         gxTv_SdtPromocionDistribuidor_Promocionfechafin = DateTime.MinValue;
         gxTv_SdtPromocionDistribuidor_Distribuidordescripcion = "";
         gxTv_SdtPromocionDistribuidor_Mode = "";
         gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z = "";
         gxTv_SdtPromocionDistribuidor_Promocionbase_Z = "";
         gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z = DateTime.MinValue;
         gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z = DateTime.MinValue;
         gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z = "";
         gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "promociondistribuidor", "GeneXus.Programs.promociondistribuidor_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPromocionDistribuidor_Initialized ;
      private int gxTv_SdtPromocionDistribuidor_Promociondistribuidorid ;
      private int gxTv_SdtPromocionDistribuidor_Promocionid ;
      private int gxTv_SdtPromocionDistribuidor_Distribuidorid ;
      private int gxTv_SdtPromocionDistribuidor_Promociondistribuidorid_Z ;
      private int gxTv_SdtPromocionDistribuidor_Promocionid_Z ;
      private int gxTv_SdtPromocionDistribuidor_Distribuidorid_Z ;
      private string gxTv_SdtPromocionDistribuidor_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtPromocionDistribuidor_Promocionfechainicio ;
      private DateTime gxTv_SdtPromocionDistribuidor_Promocionfechafin ;
      private DateTime gxTv_SdtPromocionDistribuidor_Promocionfechainicio_Z ;
      private DateTime gxTv_SdtPromocionDistribuidor_Promocionfechafin_Z ;
      private string gxTv_SdtPromocionDistribuidor_Promociondescripcion ;
      private string gxTv_SdtPromocionDistribuidor_Promocionbase ;
      private string gxTv_SdtPromocionDistribuidor_Promocionarte_gxi ;
      private string gxTv_SdtPromocionDistribuidor_Distribuidordescripcion ;
      private string gxTv_SdtPromocionDistribuidor_Promociondescripcion_Z ;
      private string gxTv_SdtPromocionDistribuidor_Promocionbase_Z ;
      private string gxTv_SdtPromocionDistribuidor_Distribuidordescripcion_Z ;
      private string gxTv_SdtPromocionDistribuidor_Promocionarte_gxi_Z ;
      private string gxTv_SdtPromocionDistribuidor_Promocionarte ;
   }

   [DataContract(Name = @"PromocionDistribuidor", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtPromocionDistribuidor_RESTInterface : GxGenericCollectionItem<SdtPromocionDistribuidor>
   {
      public SdtPromocionDistribuidor_RESTInterface( ) : base()
      {
      }

      public SdtPromocionDistribuidor_RESTInterface( SdtPromocionDistribuidor psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PromocionDistribuidorID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Promociondistribuidorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Promociondistribuidorid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Promociondistribuidorid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      [DataMember( Name = "PromocionDescripcion" , Order = 2 )]
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

      [DataMember( Name = "PromocionBase" , Order = 3 )]
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

      [DataMember( Name = "PromocionArte" , Order = 4 )]
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

      [DataMember( Name = "PromocionFechaInicio" , Order = 5 )]
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

      [DataMember( Name = "PromocionFechaFin" , Order = 6 )]
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

      [DataMember( Name = "DistribuidorID" , Order = 7 )]
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

      [DataMember( Name = "DistribuidorDescripcion" , Order = 8 )]
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

      public SdtPromocionDistribuidor sdt
      {
         get {
            return (SdtPromocionDistribuidor)Sdt ;
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
            sdt = new SdtPromocionDistribuidor() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 9 )]
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

   [DataContract(Name = @"PromocionDistribuidor", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtPromocionDistribuidor_RESTLInterface : GxGenericCollectionItem<SdtPromocionDistribuidor>
   {
      public SdtPromocionDistribuidor_RESTLInterface( ) : base()
      {
      }

      public SdtPromocionDistribuidor_RESTLInterface( SdtPromocionDistribuidor psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PromocionDistribuidorID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Promociondistribuidorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Promociondistribuidorid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Promociondistribuidorid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/PromocionDistribuidor/{0}";
            gxuri = String.Format(gxuri,gxTpr_Promociondistribuidorid) ;
            return gxuri ;
         }

         set {
         }

      }

      public SdtPromocionDistribuidor sdt
      {
         get {
            return (SdtPromocionDistribuidor)Sdt ;
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
            sdt = new SdtPromocionDistribuidor() ;
         }
      }

      private string gxuri ;
   }

}
