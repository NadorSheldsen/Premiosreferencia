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
   [XmlRoot(ElementName = "Factura" )]
   [XmlType(TypeName =  "Factura" , Namespace = "Premios" )]
   [Serializable]
   public class SdtFactura : GxSilentTrnSdt
   {
      public SdtFactura( )
      {
      }

      public SdtFactura( IGxContext context )
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

      public void Load( int AV69FacturaID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV69FacturaID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FacturaID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Factura");
         metadata.Set("BT", "Factura");
         metadata.Set("PK", "[ \"FacturaID\" ]");
         metadata.Set("PKAssigned", "[ \"FacturaID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"MotivoRechazoID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PromocionID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"UsuarioID\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Promocionarte_gxi");
         state.Add("gxTpr_Facturapdf_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Facturaid_Z");
         state.Add("gxTpr_Promocionid_Z");
         state.Add("gxTpr_Promociondescripcion_Z");
         state.Add("gxTpr_Promocionbase_Z");
         state.Add("gxTpr_Promocionvigencia_Z");
         state.Add("gxTpr_Facturano_Z");
         state.Add("gxTpr_Facturafechafactura_Z_Nullable");
         state.Add("gxTpr_Facturafecharegistro_Z_Nullable");
         state.Add("gxTpr_Usuarioid_Z");
         state.Add("gxTpr_Usuarionombrecompleto_Z");
         state.Add("gxTpr_Usuariozona_Z");
         state.Add("gxTpr_Estadodescripcion_Z");
         state.Add("gxTpr_Ciudaddescripcion_Z");
         state.Add("gxTpr_Paisdescripcion_Z");
         state.Add("gxTpr_Usuariogenero_Z");
         state.Add("gxTpr_Facturaestatus_Z");
         state.Add("gxTpr_Motivorechazoid_Z");
         state.Add("gxTpr_Motivorechazodescripcion_Z");
         state.Add("gxTpr_Motivorechazoactivo_Z");
         state.Add("gxTpr_Facturacompleta_Z");
         state.Add("gxTpr_Promocionarte_gxi_Z");
         state.Add("gxTpr_Facturapdf_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFactura sdt;
         sdt = (SdtFactura)(source);
         gxTv_SdtFactura_Facturaid = sdt.gxTv_SdtFactura_Facturaid ;
         gxTv_SdtFactura_Promocionid = sdt.gxTv_SdtFactura_Promocionid ;
         gxTv_SdtFactura_Promociondescripcion = sdt.gxTv_SdtFactura_Promociondescripcion ;
         gxTv_SdtFactura_Promocionbase = sdt.gxTv_SdtFactura_Promocionbase ;
         gxTv_SdtFactura_Promocionarte = sdt.gxTv_SdtFactura_Promocionarte ;
         gxTv_SdtFactura_Promocionarte_gxi = sdt.gxTv_SdtFactura_Promocionarte_gxi ;
         gxTv_SdtFactura_Promocionvigencia = sdt.gxTv_SdtFactura_Promocionvigencia ;
         gxTv_SdtFactura_Facturano = sdt.gxTv_SdtFactura_Facturano ;
         gxTv_SdtFactura_Facturafechafactura = sdt.gxTv_SdtFactura_Facturafechafactura ;
         gxTv_SdtFactura_Facturafecharegistro = sdt.gxTv_SdtFactura_Facturafecharegistro ;
         gxTv_SdtFactura_Usuarioid = sdt.gxTv_SdtFactura_Usuarioid ;
         gxTv_SdtFactura_Usuarionombrecompleto = sdt.gxTv_SdtFactura_Usuarionombrecompleto ;
         gxTv_SdtFactura_Usuariozona = sdt.gxTv_SdtFactura_Usuariozona ;
         gxTv_SdtFactura_Estadodescripcion = sdt.gxTv_SdtFactura_Estadodescripcion ;
         gxTv_SdtFactura_Ciudaddescripcion = sdt.gxTv_SdtFactura_Ciudaddescripcion ;
         gxTv_SdtFactura_Paisdescripcion = sdt.gxTv_SdtFactura_Paisdescripcion ;
         gxTv_SdtFactura_Usuariogenero = sdt.gxTv_SdtFactura_Usuariogenero ;
         gxTv_SdtFactura_Facturapdf = sdt.gxTv_SdtFactura_Facturapdf ;
         gxTv_SdtFactura_Facturapdf_gxi = sdt.gxTv_SdtFactura_Facturapdf_gxi ;
         gxTv_SdtFactura_Facturaestatus = sdt.gxTv_SdtFactura_Facturaestatus ;
         gxTv_SdtFactura_Motivorechazoid = sdt.gxTv_SdtFactura_Motivorechazoid ;
         gxTv_SdtFactura_Motivorechazodescripcion = sdt.gxTv_SdtFactura_Motivorechazodescripcion ;
         gxTv_SdtFactura_Motivorechazoactivo = sdt.gxTv_SdtFactura_Motivorechazoactivo ;
         gxTv_SdtFactura_Facturacompleta = sdt.gxTv_SdtFactura_Facturacompleta ;
         gxTv_SdtFactura_Mode = sdt.gxTv_SdtFactura_Mode ;
         gxTv_SdtFactura_Initialized = sdt.gxTv_SdtFactura_Initialized ;
         gxTv_SdtFactura_Facturaid_Z = sdt.gxTv_SdtFactura_Facturaid_Z ;
         gxTv_SdtFactura_Promocionid_Z = sdt.gxTv_SdtFactura_Promocionid_Z ;
         gxTv_SdtFactura_Promociondescripcion_Z = sdt.gxTv_SdtFactura_Promociondescripcion_Z ;
         gxTv_SdtFactura_Promocionbase_Z = sdt.gxTv_SdtFactura_Promocionbase_Z ;
         gxTv_SdtFactura_Promocionvigencia_Z = sdt.gxTv_SdtFactura_Promocionvigencia_Z ;
         gxTv_SdtFactura_Facturano_Z = sdt.gxTv_SdtFactura_Facturano_Z ;
         gxTv_SdtFactura_Facturafechafactura_Z = sdt.gxTv_SdtFactura_Facturafechafactura_Z ;
         gxTv_SdtFactura_Facturafecharegistro_Z = sdt.gxTv_SdtFactura_Facturafecharegistro_Z ;
         gxTv_SdtFactura_Usuarioid_Z = sdt.gxTv_SdtFactura_Usuarioid_Z ;
         gxTv_SdtFactura_Usuarionombrecompleto_Z = sdt.gxTv_SdtFactura_Usuarionombrecompleto_Z ;
         gxTv_SdtFactura_Usuariozona_Z = sdt.gxTv_SdtFactura_Usuariozona_Z ;
         gxTv_SdtFactura_Estadodescripcion_Z = sdt.gxTv_SdtFactura_Estadodescripcion_Z ;
         gxTv_SdtFactura_Ciudaddescripcion_Z = sdt.gxTv_SdtFactura_Ciudaddescripcion_Z ;
         gxTv_SdtFactura_Paisdescripcion_Z = sdt.gxTv_SdtFactura_Paisdescripcion_Z ;
         gxTv_SdtFactura_Usuariogenero_Z = sdt.gxTv_SdtFactura_Usuariogenero_Z ;
         gxTv_SdtFactura_Facturaestatus_Z = sdt.gxTv_SdtFactura_Facturaestatus_Z ;
         gxTv_SdtFactura_Motivorechazoid_Z = sdt.gxTv_SdtFactura_Motivorechazoid_Z ;
         gxTv_SdtFactura_Motivorechazodescripcion_Z = sdt.gxTv_SdtFactura_Motivorechazodescripcion_Z ;
         gxTv_SdtFactura_Motivorechazoactivo_Z = sdt.gxTv_SdtFactura_Motivorechazoactivo_Z ;
         gxTv_SdtFactura_Facturacompleta_Z = sdt.gxTv_SdtFactura_Facturacompleta_Z ;
         gxTv_SdtFactura_Promocionarte_gxi_Z = sdt.gxTv_SdtFactura_Promocionarte_gxi_Z ;
         gxTv_SdtFactura_Facturapdf_gxi_Z = sdt.gxTv_SdtFactura_Facturapdf_gxi_Z ;
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
         AddObjectProperty("FacturaID", gxTv_SdtFactura_Facturaid, false, includeNonInitialized);
         AddObjectProperty("PromocionID", gxTv_SdtFactura_Promocionid, false, includeNonInitialized);
         AddObjectProperty("PromocionDescripcion", gxTv_SdtFactura_Promociondescripcion, false, includeNonInitialized);
         AddObjectProperty("PromocionBase", gxTv_SdtFactura_Promocionbase, false, includeNonInitialized);
         AddObjectProperty("PromocionArte", gxTv_SdtFactura_Promocionarte, false, includeNonInitialized);
         AddObjectProperty("PromocionVigencia", gxTv_SdtFactura_Promocionvigencia, false, includeNonInitialized);
         AddObjectProperty("FacturaNo", gxTv_SdtFactura_Facturano, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFactura_Facturafechafactura)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFactura_Facturafechafactura)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFactura_Facturafechafactura)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("FacturaFechaFactura", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFactura_Facturafecharegistro)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFactura_Facturafecharegistro)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFactura_Facturafecharegistro)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("FacturaFechaRegistro", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UsuarioID", gxTv_SdtFactura_Usuarioid, false, includeNonInitialized);
         AddObjectProperty("UsuarioNombreCompleto", gxTv_SdtFactura_Usuarionombrecompleto, false, includeNonInitialized);
         AddObjectProperty("UsuarioZona", gxTv_SdtFactura_Usuariozona, false, includeNonInitialized);
         AddObjectProperty("EstadoDescripcion", gxTv_SdtFactura_Estadodescripcion, false, includeNonInitialized);
         AddObjectProperty("CiudadDescripcion", gxTv_SdtFactura_Ciudaddescripcion, false, includeNonInitialized);
         AddObjectProperty("PaisDescripcion", gxTv_SdtFactura_Paisdescripcion, false, includeNonInitialized);
         AddObjectProperty("UsuarioGenero", gxTv_SdtFactura_Usuariogenero, false, includeNonInitialized);
         AddObjectProperty("FacturaPDF", gxTv_SdtFactura_Facturapdf, false, includeNonInitialized);
         AddObjectProperty("FacturaEstatus", gxTv_SdtFactura_Facturaestatus, false, includeNonInitialized);
         AddObjectProperty("MotivoRechazoID", gxTv_SdtFactura_Motivorechazoid, false, includeNonInitialized);
         AddObjectProperty("MotivoRechazoDescripcion", gxTv_SdtFactura_Motivorechazodescripcion, false, includeNonInitialized);
         AddObjectProperty("MotivoRechazoActivo", gxTv_SdtFactura_Motivorechazoactivo, false, includeNonInitialized);
         AddObjectProperty("FacturaCompleta", gxTv_SdtFactura_Facturacompleta, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("PromocionArte_GXI", gxTv_SdtFactura_Promocionarte_gxi, false, includeNonInitialized);
            AddObjectProperty("FacturaPDF_GXI", gxTv_SdtFactura_Facturapdf_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtFactura_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFactura_Initialized, false, includeNonInitialized);
            AddObjectProperty("FacturaID_Z", gxTv_SdtFactura_Facturaid_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionID_Z", gxTv_SdtFactura_Promocionid_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionDescripcion_Z", gxTv_SdtFactura_Promociondescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionBase_Z", gxTv_SdtFactura_Promocionbase_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionVigencia_Z", gxTv_SdtFactura_Promocionvigencia_Z, false, includeNonInitialized);
            AddObjectProperty("FacturaNo_Z", gxTv_SdtFactura_Facturano_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFactura_Facturafechafactura_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFactura_Facturafechafactura_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFactura_Facturafechafactura_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("FacturaFechaFactura_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFactura_Facturafecharegistro_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFactura_Facturafecharegistro_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFactura_Facturafecharegistro_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("FacturaFechaRegistro_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("UsuarioID_Z", gxTv_SdtFactura_Usuarioid_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioNombreCompleto_Z", gxTv_SdtFactura_Usuarionombrecompleto_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioZona_Z", gxTv_SdtFactura_Usuariozona_Z, false, includeNonInitialized);
            AddObjectProperty("EstadoDescripcion_Z", gxTv_SdtFactura_Estadodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("CiudadDescripcion_Z", gxTv_SdtFactura_Ciudaddescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PaisDescripcion_Z", gxTv_SdtFactura_Paisdescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioGenero_Z", gxTv_SdtFactura_Usuariogenero_Z, false, includeNonInitialized);
            AddObjectProperty("FacturaEstatus_Z", gxTv_SdtFactura_Facturaestatus_Z, false, includeNonInitialized);
            AddObjectProperty("MotivoRechazoID_Z", gxTv_SdtFactura_Motivorechazoid_Z, false, includeNonInitialized);
            AddObjectProperty("MotivoRechazoDescripcion_Z", gxTv_SdtFactura_Motivorechazodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("MotivoRechazoActivo_Z", gxTv_SdtFactura_Motivorechazoactivo_Z, false, includeNonInitialized);
            AddObjectProperty("FacturaCompleta_Z", gxTv_SdtFactura_Facturacompleta_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionArte_GXI_Z", gxTv_SdtFactura_Promocionarte_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("FacturaPDF_GXI_Z", gxTv_SdtFactura_Facturapdf_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFactura sdt )
      {
         if ( sdt.IsDirty("FacturaID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturaid = sdt.gxTv_SdtFactura_Facturaid ;
         }
         if ( sdt.IsDirty("PromocionID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionid = sdt.gxTv_SdtFactura_Promocionid ;
         }
         if ( sdt.IsDirty("PromocionDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promociondescripcion = sdt.gxTv_SdtFactura_Promociondescripcion ;
         }
         if ( sdt.IsDirty("PromocionBase") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionbase = sdt.gxTv_SdtFactura_Promocionbase ;
         }
         if ( sdt.IsDirty("PromocionArte") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionarte = sdt.gxTv_SdtFactura_Promocionarte ;
         }
         if ( sdt.IsDirty("PromocionArte") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionarte_gxi = sdt.gxTv_SdtFactura_Promocionarte_gxi ;
         }
         if ( sdt.IsDirty("PromocionVigencia") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionvigencia = sdt.gxTv_SdtFactura_Promocionvigencia ;
         }
         if ( sdt.IsDirty("FacturaNo") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturano = sdt.gxTv_SdtFactura_Facturano ;
         }
         if ( sdt.IsDirty("FacturaFechaFactura") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturafechafactura = sdt.gxTv_SdtFactura_Facturafechafactura ;
         }
         if ( sdt.IsDirty("FacturaFechaRegistro") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturafecharegistro = sdt.gxTv_SdtFactura_Facturafecharegistro ;
         }
         if ( sdt.IsDirty("UsuarioID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuarioid = sdt.gxTv_SdtFactura_Usuarioid ;
         }
         if ( sdt.IsDirty("UsuarioNombreCompleto") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuarionombrecompleto = sdt.gxTv_SdtFactura_Usuarionombrecompleto ;
         }
         if ( sdt.IsDirty("UsuarioZona") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuariozona = sdt.gxTv_SdtFactura_Usuariozona ;
         }
         if ( sdt.IsDirty("EstadoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Estadodescripcion = sdt.gxTv_SdtFactura_Estadodescripcion ;
         }
         if ( sdt.IsDirty("CiudadDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Ciudaddescripcion = sdt.gxTv_SdtFactura_Ciudaddescripcion ;
         }
         if ( sdt.IsDirty("PaisDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Paisdescripcion = sdt.gxTv_SdtFactura_Paisdescripcion ;
         }
         if ( sdt.IsDirty("UsuarioGenero") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuariogenero = sdt.gxTv_SdtFactura_Usuariogenero ;
         }
         if ( sdt.IsDirty("FacturaPDF") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturapdf = sdt.gxTv_SdtFactura_Facturapdf ;
         }
         if ( sdt.IsDirty("FacturaPDF") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturapdf_gxi = sdt.gxTv_SdtFactura_Facturapdf_gxi ;
         }
         if ( sdt.IsDirty("FacturaEstatus") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturaestatus = sdt.gxTv_SdtFactura_Facturaestatus ;
         }
         if ( sdt.IsDirty("MotivoRechazoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Motivorechazoid = sdt.gxTv_SdtFactura_Motivorechazoid ;
         }
         if ( sdt.IsDirty("MotivoRechazoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Motivorechazodescripcion = sdt.gxTv_SdtFactura_Motivorechazodescripcion ;
         }
         if ( sdt.IsDirty("MotivoRechazoActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Motivorechazoactivo = sdt.gxTv_SdtFactura_Motivorechazoactivo ;
         }
         if ( sdt.IsDirty("FacturaCompleta") )
         {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturacompleta = sdt.gxTv_SdtFactura_Facturacompleta ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FacturaID" )]
      [  XmlElement( ElementName = "FacturaID"   )]
      public int gxTpr_Facturaid
      {
         get {
            return gxTv_SdtFactura_Facturaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtFactura_Facturaid != value )
            {
               gxTv_SdtFactura_Mode = "INS";
               this.gxTv_SdtFactura_Facturaid_Z_SetNull( );
               this.gxTv_SdtFactura_Promocionid_Z_SetNull( );
               this.gxTv_SdtFactura_Promociondescripcion_Z_SetNull( );
               this.gxTv_SdtFactura_Promocionbase_Z_SetNull( );
               this.gxTv_SdtFactura_Promocionvigencia_Z_SetNull( );
               this.gxTv_SdtFactura_Facturano_Z_SetNull( );
               this.gxTv_SdtFactura_Facturafechafactura_Z_SetNull( );
               this.gxTv_SdtFactura_Facturafecharegistro_Z_SetNull( );
               this.gxTv_SdtFactura_Usuarioid_Z_SetNull( );
               this.gxTv_SdtFactura_Usuarionombrecompleto_Z_SetNull( );
               this.gxTv_SdtFactura_Usuariozona_Z_SetNull( );
               this.gxTv_SdtFactura_Estadodescripcion_Z_SetNull( );
               this.gxTv_SdtFactura_Ciudaddescripcion_Z_SetNull( );
               this.gxTv_SdtFactura_Paisdescripcion_Z_SetNull( );
               this.gxTv_SdtFactura_Usuariogenero_Z_SetNull( );
               this.gxTv_SdtFactura_Facturaestatus_Z_SetNull( );
               this.gxTv_SdtFactura_Motivorechazoid_Z_SetNull( );
               this.gxTv_SdtFactura_Motivorechazodescripcion_Z_SetNull( );
               this.gxTv_SdtFactura_Motivorechazoactivo_Z_SetNull( );
               this.gxTv_SdtFactura_Facturacompleta_Z_SetNull( );
               this.gxTv_SdtFactura_Promocionarte_gxi_Z_SetNull( );
               this.gxTv_SdtFactura_Facturapdf_gxi_Z_SetNull( );
            }
            gxTv_SdtFactura_Facturaid = value;
            SetDirty("Facturaid");
         }

      }

      [  SoapElement( ElementName = "PromocionID" )]
      [  XmlElement( ElementName = "PromocionID"   )]
      public int gxTpr_Promocionid
      {
         get {
            return gxTv_SdtFactura_Promocionid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionid = value;
            SetDirty("Promocionid");
         }

      }

      [  SoapElement( ElementName = "PromocionDescripcion" )]
      [  XmlElement( ElementName = "PromocionDescripcion"   )]
      public string gxTpr_Promociondescripcion
      {
         get {
            return gxTv_SdtFactura_Promociondescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promociondescripcion = value;
            SetDirty("Promociondescripcion");
         }

      }

      [  SoapElement( ElementName = "PromocionBase" )]
      [  XmlElement( ElementName = "PromocionBase"   )]
      public string gxTpr_Promocionbase
      {
         get {
            return gxTv_SdtFactura_Promocionbase ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionbase = value;
            SetDirty("Promocionbase");
         }

      }

      [  SoapElement( ElementName = "PromocionArte" )]
      [  XmlElement( ElementName = "PromocionArte"   )]
      [GxUpload()]
      public string gxTpr_Promocionarte
      {
         get {
            return gxTv_SdtFactura_Promocionarte ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionarte = value;
            SetDirty("Promocionarte");
         }

      }

      [  SoapElement( ElementName = "PromocionArte_GXI" )]
      [  XmlElement( ElementName = "PromocionArte_GXI"   )]
      public string gxTpr_Promocionarte_gxi
      {
         get {
            return gxTv_SdtFactura_Promocionarte_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionarte_gxi = value;
            SetDirty("Promocionarte_gxi");
         }

      }

      [  SoapElement( ElementName = "PromocionVigencia" )]
      [  XmlElement( ElementName = "PromocionVigencia"   )]
      public string gxTpr_Promocionvigencia
      {
         get {
            return gxTv_SdtFactura_Promocionvigencia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionvigencia = value;
            SetDirty("Promocionvigencia");
         }

      }

      public void gxTv_SdtFactura_Promocionvigencia_SetNull( )
      {
         gxTv_SdtFactura_Promocionvigencia = "";
         SetDirty("Promocionvigencia");
         return  ;
      }

      public bool gxTv_SdtFactura_Promocionvigencia_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaNo" )]
      [  XmlElement( ElementName = "FacturaNo"   )]
      public string gxTpr_Facturano
      {
         get {
            return gxTv_SdtFactura_Facturano ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturano = value;
            SetDirty("Facturano");
         }

      }

      [  SoapElement( ElementName = "FacturaFechaFactura" )]
      [  XmlElement( ElementName = "FacturaFechaFactura"  , IsNullable=true )]
      public string gxTpr_Facturafechafactura_Nullable
      {
         get {
            if ( gxTv_SdtFactura_Facturafechafactura == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFactura_Facturafechafactura).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFactura_Facturafechafactura = DateTime.MinValue;
            else
               gxTv_SdtFactura_Facturafechafactura = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Facturafechafactura
      {
         get {
            return gxTv_SdtFactura_Facturafechafactura ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturafechafactura = value;
            SetDirty("Facturafechafactura");
         }

      }

      [  SoapElement( ElementName = "FacturaFechaRegistro" )]
      [  XmlElement( ElementName = "FacturaFechaRegistro"  , IsNullable=true )]
      public string gxTpr_Facturafecharegistro_Nullable
      {
         get {
            if ( gxTv_SdtFactura_Facturafecharegistro == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFactura_Facturafecharegistro).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFactura_Facturafecharegistro = DateTime.MinValue;
            else
               gxTv_SdtFactura_Facturafecharegistro = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Facturafecharegistro
      {
         get {
            return gxTv_SdtFactura_Facturafecharegistro ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturafecharegistro = value;
            SetDirty("Facturafecharegistro");
         }

      }

      [  SoapElement( ElementName = "UsuarioID" )]
      [  XmlElement( ElementName = "UsuarioID"   )]
      public int gxTpr_Usuarioid
      {
         get {
            return gxTv_SdtFactura_Usuarioid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuarioid = value;
            SetDirty("Usuarioid");
         }

      }

      [  SoapElement( ElementName = "UsuarioNombreCompleto" )]
      [  XmlElement( ElementName = "UsuarioNombreCompleto"   )]
      public string gxTpr_Usuarionombrecompleto
      {
         get {
            return gxTv_SdtFactura_Usuarionombrecompleto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuarionombrecompleto = value;
            SetDirty("Usuarionombrecompleto");
         }

      }

      public void gxTv_SdtFactura_Usuarionombrecompleto_SetNull( )
      {
         gxTv_SdtFactura_Usuarionombrecompleto = "";
         SetDirty("Usuarionombrecompleto");
         return  ;
      }

      public bool gxTv_SdtFactura_Usuarionombrecompleto_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioZona" )]
      [  XmlElement( ElementName = "UsuarioZona"   )]
      public string gxTpr_Usuariozona
      {
         get {
            return gxTv_SdtFactura_Usuariozona ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuariozona = value;
            SetDirty("Usuariozona");
         }

      }

      [  SoapElement( ElementName = "EstadoDescripcion" )]
      [  XmlElement( ElementName = "EstadoDescripcion"   )]
      public string gxTpr_Estadodescripcion
      {
         get {
            return gxTv_SdtFactura_Estadodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Estadodescripcion = value;
            SetDirty("Estadodescripcion");
         }

      }

      [  SoapElement( ElementName = "CiudadDescripcion" )]
      [  XmlElement( ElementName = "CiudadDescripcion"   )]
      public string gxTpr_Ciudaddescripcion
      {
         get {
            return gxTv_SdtFactura_Ciudaddescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Ciudaddescripcion = value;
            SetDirty("Ciudaddescripcion");
         }

      }

      [  SoapElement( ElementName = "PaisDescripcion" )]
      [  XmlElement( ElementName = "PaisDescripcion"   )]
      public string gxTpr_Paisdescripcion
      {
         get {
            return gxTv_SdtFactura_Paisdescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Paisdescripcion = value;
            SetDirty("Paisdescripcion");
         }

      }

      [  SoapElement( ElementName = "UsuarioGenero" )]
      [  XmlElement( ElementName = "UsuarioGenero"   )]
      public string gxTpr_Usuariogenero
      {
         get {
            return gxTv_SdtFactura_Usuariogenero ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuariogenero = value;
            SetDirty("Usuariogenero");
         }

      }

      [  SoapElement( ElementName = "FacturaPDF" )]
      [  XmlElement( ElementName = "FacturaPDF"   )]
      [GxUpload()]
      public string gxTpr_Facturapdf
      {
         get {
            return gxTv_SdtFactura_Facturapdf ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturapdf = value;
            SetDirty("Facturapdf");
         }

      }

      [  SoapElement( ElementName = "FacturaPDF_GXI" )]
      [  XmlElement( ElementName = "FacturaPDF_GXI"   )]
      public string gxTpr_Facturapdf_gxi
      {
         get {
            return gxTv_SdtFactura_Facturapdf_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturapdf_gxi = value;
            SetDirty("Facturapdf_gxi");
         }

      }

      [  SoapElement( ElementName = "FacturaEstatus" )]
      [  XmlElement( ElementName = "FacturaEstatus"   )]
      public string gxTpr_Facturaestatus
      {
         get {
            return gxTv_SdtFactura_Facturaestatus ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturaestatus = value;
            SetDirty("Facturaestatus");
         }

      }

      [  SoapElement( ElementName = "MotivoRechazoID" )]
      [  XmlElement( ElementName = "MotivoRechazoID"   )]
      public int gxTpr_Motivorechazoid
      {
         get {
            return gxTv_SdtFactura_Motivorechazoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Motivorechazoid = value;
            SetDirty("Motivorechazoid");
         }

      }

      [  SoapElement( ElementName = "MotivoRechazoDescripcion" )]
      [  XmlElement( ElementName = "MotivoRechazoDescripcion"   )]
      public string gxTpr_Motivorechazodescripcion
      {
         get {
            return gxTv_SdtFactura_Motivorechazodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Motivorechazodescripcion = value;
            SetDirty("Motivorechazodescripcion");
         }

      }

      [  SoapElement( ElementName = "MotivoRechazoActivo" )]
      [  XmlElement( ElementName = "MotivoRechazoActivo"   )]
      public bool gxTpr_Motivorechazoactivo
      {
         get {
            return gxTv_SdtFactura_Motivorechazoactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Motivorechazoactivo = value;
            SetDirty("Motivorechazoactivo");
         }

      }

      [  SoapElement( ElementName = "FacturaCompleta" )]
      [  XmlElement( ElementName = "FacturaCompleta"   )]
      public bool gxTpr_Facturacompleta
      {
         get {
            return gxTv_SdtFactura_Facturacompleta ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturacompleta = value;
            SetDirty("Facturacompleta");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFactura_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFactura_Mode_SetNull( )
      {
         gxTv_SdtFactura_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtFactura_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFactura_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFactura_Initialized_SetNull( )
      {
         gxTv_SdtFactura_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtFactura_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaID_Z" )]
      [  XmlElement( ElementName = "FacturaID_Z"   )]
      public int gxTpr_Facturaid_Z
      {
         get {
            return gxTv_SdtFactura_Facturaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturaid_Z = value;
            SetDirty("Facturaid_Z");
         }

      }

      public void gxTv_SdtFactura_Facturaid_Z_SetNull( )
      {
         gxTv_SdtFactura_Facturaid_Z = 0;
         SetDirty("Facturaid_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Facturaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionID_Z" )]
      [  XmlElement( ElementName = "PromocionID_Z"   )]
      public int gxTpr_Promocionid_Z
      {
         get {
            return gxTv_SdtFactura_Promocionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionid_Z = value;
            SetDirty("Promocionid_Z");
         }

      }

      public void gxTv_SdtFactura_Promocionid_Z_SetNull( )
      {
         gxTv_SdtFactura_Promocionid_Z = 0;
         SetDirty("Promocionid_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Promocionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionDescripcion_Z" )]
      [  XmlElement( ElementName = "PromocionDescripcion_Z"   )]
      public string gxTpr_Promociondescripcion_Z
      {
         get {
            return gxTv_SdtFactura_Promociondescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promociondescripcion_Z = value;
            SetDirty("Promociondescripcion_Z");
         }

      }

      public void gxTv_SdtFactura_Promociondescripcion_Z_SetNull( )
      {
         gxTv_SdtFactura_Promociondescripcion_Z = "";
         SetDirty("Promociondescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Promociondescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionBase_Z" )]
      [  XmlElement( ElementName = "PromocionBase_Z"   )]
      public string gxTpr_Promocionbase_Z
      {
         get {
            return gxTv_SdtFactura_Promocionbase_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionbase_Z = value;
            SetDirty("Promocionbase_Z");
         }

      }

      public void gxTv_SdtFactura_Promocionbase_Z_SetNull( )
      {
         gxTv_SdtFactura_Promocionbase_Z = "";
         SetDirty("Promocionbase_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Promocionbase_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionVigencia_Z" )]
      [  XmlElement( ElementName = "PromocionVigencia_Z"   )]
      public string gxTpr_Promocionvigencia_Z
      {
         get {
            return gxTv_SdtFactura_Promocionvigencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionvigencia_Z = value;
            SetDirty("Promocionvigencia_Z");
         }

      }

      public void gxTv_SdtFactura_Promocionvigencia_Z_SetNull( )
      {
         gxTv_SdtFactura_Promocionvigencia_Z = "";
         SetDirty("Promocionvigencia_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Promocionvigencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaNo_Z" )]
      [  XmlElement( ElementName = "FacturaNo_Z"   )]
      public string gxTpr_Facturano_Z
      {
         get {
            return gxTv_SdtFactura_Facturano_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturano_Z = value;
            SetDirty("Facturano_Z");
         }

      }

      public void gxTv_SdtFactura_Facturano_Z_SetNull( )
      {
         gxTv_SdtFactura_Facturano_Z = "";
         SetDirty("Facturano_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Facturano_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaFechaFactura_Z" )]
      [  XmlElement( ElementName = "FacturaFechaFactura_Z"  , IsNullable=true )]
      public string gxTpr_Facturafechafactura_Z_Nullable
      {
         get {
            if ( gxTv_SdtFactura_Facturafechafactura_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFactura_Facturafechafactura_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFactura_Facturafechafactura_Z = DateTime.MinValue;
            else
               gxTv_SdtFactura_Facturafechafactura_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Facturafechafactura_Z
      {
         get {
            return gxTv_SdtFactura_Facturafechafactura_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturafechafactura_Z = value;
            SetDirty("Facturafechafactura_Z");
         }

      }

      public void gxTv_SdtFactura_Facturafechafactura_Z_SetNull( )
      {
         gxTv_SdtFactura_Facturafechafactura_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Facturafechafactura_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Facturafechafactura_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaFechaRegistro_Z" )]
      [  XmlElement( ElementName = "FacturaFechaRegistro_Z"  , IsNullable=true )]
      public string gxTpr_Facturafecharegistro_Z_Nullable
      {
         get {
            if ( gxTv_SdtFactura_Facturafecharegistro_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFactura_Facturafecharegistro_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFactura_Facturafecharegistro_Z = DateTime.MinValue;
            else
               gxTv_SdtFactura_Facturafecharegistro_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Facturafecharegistro_Z
      {
         get {
            return gxTv_SdtFactura_Facturafecharegistro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturafecharegistro_Z = value;
            SetDirty("Facturafecharegistro_Z");
         }

      }

      public void gxTv_SdtFactura_Facturafecharegistro_Z_SetNull( )
      {
         gxTv_SdtFactura_Facturafecharegistro_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Facturafecharegistro_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Facturafecharegistro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioID_Z" )]
      [  XmlElement( ElementName = "UsuarioID_Z"   )]
      public int gxTpr_Usuarioid_Z
      {
         get {
            return gxTv_SdtFactura_Usuarioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuarioid_Z = value;
            SetDirty("Usuarioid_Z");
         }

      }

      public void gxTv_SdtFactura_Usuarioid_Z_SetNull( )
      {
         gxTv_SdtFactura_Usuarioid_Z = 0;
         SetDirty("Usuarioid_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Usuarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioNombreCompleto_Z" )]
      [  XmlElement( ElementName = "UsuarioNombreCompleto_Z"   )]
      public string gxTpr_Usuarionombrecompleto_Z
      {
         get {
            return gxTv_SdtFactura_Usuarionombrecompleto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuarionombrecompleto_Z = value;
            SetDirty("Usuarionombrecompleto_Z");
         }

      }

      public void gxTv_SdtFactura_Usuarionombrecompleto_Z_SetNull( )
      {
         gxTv_SdtFactura_Usuarionombrecompleto_Z = "";
         SetDirty("Usuarionombrecompleto_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Usuarionombrecompleto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioZona_Z" )]
      [  XmlElement( ElementName = "UsuarioZona_Z"   )]
      public string gxTpr_Usuariozona_Z
      {
         get {
            return gxTv_SdtFactura_Usuariozona_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuariozona_Z = value;
            SetDirty("Usuariozona_Z");
         }

      }

      public void gxTv_SdtFactura_Usuariozona_Z_SetNull( )
      {
         gxTv_SdtFactura_Usuariozona_Z = "";
         SetDirty("Usuariozona_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Usuariozona_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoDescripcion_Z" )]
      [  XmlElement( ElementName = "EstadoDescripcion_Z"   )]
      public string gxTpr_Estadodescripcion_Z
      {
         get {
            return gxTv_SdtFactura_Estadodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Estadodescripcion_Z = value;
            SetDirty("Estadodescripcion_Z");
         }

      }

      public void gxTv_SdtFactura_Estadodescripcion_Z_SetNull( )
      {
         gxTv_SdtFactura_Estadodescripcion_Z = "";
         SetDirty("Estadodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Estadodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadDescripcion_Z" )]
      [  XmlElement( ElementName = "CiudadDescripcion_Z"   )]
      public string gxTpr_Ciudaddescripcion_Z
      {
         get {
            return gxTv_SdtFactura_Ciudaddescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Ciudaddescripcion_Z = value;
            SetDirty("Ciudaddescripcion_Z");
         }

      }

      public void gxTv_SdtFactura_Ciudaddescripcion_Z_SetNull( )
      {
         gxTv_SdtFactura_Ciudaddescripcion_Z = "";
         SetDirty("Ciudaddescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Ciudaddescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisDescripcion_Z" )]
      [  XmlElement( ElementName = "PaisDescripcion_Z"   )]
      public string gxTpr_Paisdescripcion_Z
      {
         get {
            return gxTv_SdtFactura_Paisdescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Paisdescripcion_Z = value;
            SetDirty("Paisdescripcion_Z");
         }

      }

      public void gxTv_SdtFactura_Paisdescripcion_Z_SetNull( )
      {
         gxTv_SdtFactura_Paisdescripcion_Z = "";
         SetDirty("Paisdescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Paisdescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioGenero_Z" )]
      [  XmlElement( ElementName = "UsuarioGenero_Z"   )]
      public string gxTpr_Usuariogenero_Z
      {
         get {
            return gxTv_SdtFactura_Usuariogenero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Usuariogenero_Z = value;
            SetDirty("Usuariogenero_Z");
         }

      }

      public void gxTv_SdtFactura_Usuariogenero_Z_SetNull( )
      {
         gxTv_SdtFactura_Usuariogenero_Z = "";
         SetDirty("Usuariogenero_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Usuariogenero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaEstatus_Z" )]
      [  XmlElement( ElementName = "FacturaEstatus_Z"   )]
      public string gxTpr_Facturaestatus_Z
      {
         get {
            return gxTv_SdtFactura_Facturaestatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturaestatus_Z = value;
            SetDirty("Facturaestatus_Z");
         }

      }

      public void gxTv_SdtFactura_Facturaestatus_Z_SetNull( )
      {
         gxTv_SdtFactura_Facturaestatus_Z = "";
         SetDirty("Facturaestatus_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Facturaestatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MotivoRechazoID_Z" )]
      [  XmlElement( ElementName = "MotivoRechazoID_Z"   )]
      public int gxTpr_Motivorechazoid_Z
      {
         get {
            return gxTv_SdtFactura_Motivorechazoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Motivorechazoid_Z = value;
            SetDirty("Motivorechazoid_Z");
         }

      }

      public void gxTv_SdtFactura_Motivorechazoid_Z_SetNull( )
      {
         gxTv_SdtFactura_Motivorechazoid_Z = 0;
         SetDirty("Motivorechazoid_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Motivorechazoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MotivoRechazoDescripcion_Z" )]
      [  XmlElement( ElementName = "MotivoRechazoDescripcion_Z"   )]
      public string gxTpr_Motivorechazodescripcion_Z
      {
         get {
            return gxTv_SdtFactura_Motivorechazodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Motivorechazodescripcion_Z = value;
            SetDirty("Motivorechazodescripcion_Z");
         }

      }

      public void gxTv_SdtFactura_Motivorechazodescripcion_Z_SetNull( )
      {
         gxTv_SdtFactura_Motivorechazodescripcion_Z = "";
         SetDirty("Motivorechazodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Motivorechazodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MotivoRechazoActivo_Z" )]
      [  XmlElement( ElementName = "MotivoRechazoActivo_Z"   )]
      public bool gxTpr_Motivorechazoactivo_Z
      {
         get {
            return gxTv_SdtFactura_Motivorechazoactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Motivorechazoactivo_Z = value;
            SetDirty("Motivorechazoactivo_Z");
         }

      }

      public void gxTv_SdtFactura_Motivorechazoactivo_Z_SetNull( )
      {
         gxTv_SdtFactura_Motivorechazoactivo_Z = false;
         SetDirty("Motivorechazoactivo_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Motivorechazoactivo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaCompleta_Z" )]
      [  XmlElement( ElementName = "FacturaCompleta_Z"   )]
      public bool gxTpr_Facturacompleta_Z
      {
         get {
            return gxTv_SdtFactura_Facturacompleta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturacompleta_Z = value;
            SetDirty("Facturacompleta_Z");
         }

      }

      public void gxTv_SdtFactura_Facturacompleta_Z_SetNull( )
      {
         gxTv_SdtFactura_Facturacompleta_Z = false;
         SetDirty("Facturacompleta_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Facturacompleta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionArte_GXI_Z" )]
      [  XmlElement( ElementName = "PromocionArte_GXI_Z"   )]
      public string gxTpr_Promocionarte_gxi_Z
      {
         get {
            return gxTv_SdtFactura_Promocionarte_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Promocionarte_gxi_Z = value;
            SetDirty("Promocionarte_gxi_Z");
         }

      }

      public void gxTv_SdtFactura_Promocionarte_gxi_Z_SetNull( )
      {
         gxTv_SdtFactura_Promocionarte_gxi_Z = "";
         SetDirty("Promocionarte_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Promocionarte_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaPDF_GXI_Z" )]
      [  XmlElement( ElementName = "FacturaPDF_GXI_Z"   )]
      public string gxTpr_Facturapdf_gxi_Z
      {
         get {
            return gxTv_SdtFactura_Facturapdf_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFactura_Facturapdf_gxi_Z = value;
            SetDirty("Facturapdf_gxi_Z");
         }

      }

      public void gxTv_SdtFactura_Facturapdf_gxi_Z_SetNull( )
      {
         gxTv_SdtFactura_Facturapdf_gxi_Z = "";
         SetDirty("Facturapdf_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtFactura_Facturapdf_gxi_Z_IsNull( )
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
         gxTv_SdtFactura_Promociondescripcion = "";
         gxTv_SdtFactura_Promocionbase = "";
         gxTv_SdtFactura_Promocionarte = "";
         gxTv_SdtFactura_Promocionarte_gxi = "";
         gxTv_SdtFactura_Promocionvigencia = "";
         gxTv_SdtFactura_Facturano = "";
         gxTv_SdtFactura_Facturafechafactura = DateTime.MinValue;
         gxTv_SdtFactura_Facturafecharegistro = DateTime.MinValue;
         gxTv_SdtFactura_Usuarionombrecompleto = "";
         gxTv_SdtFactura_Usuariozona = "";
         gxTv_SdtFactura_Estadodescripcion = "";
         gxTv_SdtFactura_Ciudaddescripcion = "";
         gxTv_SdtFactura_Paisdescripcion = "";
         gxTv_SdtFactura_Usuariogenero = "";
         gxTv_SdtFactura_Facturapdf = "";
         gxTv_SdtFactura_Facturapdf_gxi = "";
         gxTv_SdtFactura_Facturaestatus = "En Proceso";
         gxTv_SdtFactura_Motivorechazodescripcion = "";
         gxTv_SdtFactura_Facturacompleta = false;
         gxTv_SdtFactura_Mode = "";
         gxTv_SdtFactura_Promociondescripcion_Z = "";
         gxTv_SdtFactura_Promocionbase_Z = "";
         gxTv_SdtFactura_Promocionvigencia_Z = "";
         gxTv_SdtFactura_Facturano_Z = "";
         gxTv_SdtFactura_Facturafechafactura_Z = DateTime.MinValue;
         gxTv_SdtFactura_Facturafecharegistro_Z = DateTime.MinValue;
         gxTv_SdtFactura_Usuarionombrecompleto_Z = "";
         gxTv_SdtFactura_Usuariozona_Z = "";
         gxTv_SdtFactura_Estadodescripcion_Z = "";
         gxTv_SdtFactura_Ciudaddescripcion_Z = "";
         gxTv_SdtFactura_Paisdescripcion_Z = "";
         gxTv_SdtFactura_Usuariogenero_Z = "";
         gxTv_SdtFactura_Facturaestatus_Z = "";
         gxTv_SdtFactura_Motivorechazodescripcion_Z = "";
         gxTv_SdtFactura_Promocionarte_gxi_Z = "";
         gxTv_SdtFactura_Facturapdf_gxi_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "factura", "GeneXus.Programs.factura_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtFactura_Initialized ;
      private int gxTv_SdtFactura_Facturaid ;
      private int gxTv_SdtFactura_Promocionid ;
      private int gxTv_SdtFactura_Usuarioid ;
      private int gxTv_SdtFactura_Motivorechazoid ;
      private int gxTv_SdtFactura_Facturaid_Z ;
      private int gxTv_SdtFactura_Promocionid_Z ;
      private int gxTv_SdtFactura_Usuarioid_Z ;
      private int gxTv_SdtFactura_Motivorechazoid_Z ;
      private string gxTv_SdtFactura_Facturano ;
      private string gxTv_SdtFactura_Usuariozona ;
      private string gxTv_SdtFactura_Usuariogenero ;
      private string gxTv_SdtFactura_Facturaestatus ;
      private string gxTv_SdtFactura_Mode ;
      private string gxTv_SdtFactura_Facturano_Z ;
      private string gxTv_SdtFactura_Usuariozona_Z ;
      private string gxTv_SdtFactura_Usuariogenero_Z ;
      private string gxTv_SdtFactura_Facturaestatus_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtFactura_Facturafechafactura ;
      private DateTime gxTv_SdtFactura_Facturafecharegistro ;
      private DateTime gxTv_SdtFactura_Facturafechafactura_Z ;
      private DateTime gxTv_SdtFactura_Facturafecharegistro_Z ;
      private bool gxTv_SdtFactura_Motivorechazoactivo ;
      private bool gxTv_SdtFactura_Facturacompleta ;
      private bool gxTv_SdtFactura_Motivorechazoactivo_Z ;
      private bool gxTv_SdtFactura_Facturacompleta_Z ;
      private string gxTv_SdtFactura_Promociondescripcion ;
      private string gxTv_SdtFactura_Promocionbase ;
      private string gxTv_SdtFactura_Promocionarte_gxi ;
      private string gxTv_SdtFactura_Promocionvigencia ;
      private string gxTv_SdtFactura_Usuarionombrecompleto ;
      private string gxTv_SdtFactura_Estadodescripcion ;
      private string gxTv_SdtFactura_Ciudaddescripcion ;
      private string gxTv_SdtFactura_Paisdescripcion ;
      private string gxTv_SdtFactura_Facturapdf_gxi ;
      private string gxTv_SdtFactura_Motivorechazodescripcion ;
      private string gxTv_SdtFactura_Promociondescripcion_Z ;
      private string gxTv_SdtFactura_Promocionbase_Z ;
      private string gxTv_SdtFactura_Promocionvigencia_Z ;
      private string gxTv_SdtFactura_Usuarionombrecompleto_Z ;
      private string gxTv_SdtFactura_Estadodescripcion_Z ;
      private string gxTv_SdtFactura_Ciudaddescripcion_Z ;
      private string gxTv_SdtFactura_Paisdescripcion_Z ;
      private string gxTv_SdtFactura_Motivorechazodescripcion_Z ;
      private string gxTv_SdtFactura_Promocionarte_gxi_Z ;
      private string gxTv_SdtFactura_Facturapdf_gxi_Z ;
      private string gxTv_SdtFactura_Promocionarte ;
      private string gxTv_SdtFactura_Facturapdf ;
   }

   [DataContract(Name = @"Factura", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtFactura_RESTInterface : GxGenericCollectionItem<SdtFactura>
   {
      public SdtFactura_RESTInterface( ) : base()
      {
      }

      public SdtFactura_RESTInterface( SdtFactura psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FacturaID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Facturaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Facturaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Facturaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      [DataMember( Name = "PromocionVigencia" , Order = 5 )]
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

      [DataMember( Name = "FacturaNo" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Facturano
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Facturano) ;
         }

         set {
            sdt.gxTpr_Facturano = value;
         }

      }

      [DataMember( Name = "FacturaFechaFactura" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Facturafechafactura
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Facturafechafactura) ;
         }

         set {
            sdt.gxTpr_Facturafechafactura = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "FacturaFechaRegistro" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Facturafecharegistro
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Facturafecharegistro) ;
         }

         set {
            sdt.gxTpr_Facturafecharegistro = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UsuarioID" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Usuarioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Usuarioid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Usuarioid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "UsuarioNombreCompleto" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Usuarionombrecompleto
      {
         get {
            return sdt.gxTpr_Usuarionombrecompleto ;
         }

         set {
            sdt.gxTpr_Usuarionombrecompleto = value;
         }

      }

      [DataMember( Name = "UsuarioZona" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Usuariozona
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariozona) ;
         }

         set {
            sdt.gxTpr_Usuariozona = value;
         }

      }

      [DataMember( Name = "EstadoDescripcion" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Estadodescripcion
      {
         get {
            return sdt.gxTpr_Estadodescripcion ;
         }

         set {
            sdt.gxTpr_Estadodescripcion = value;
         }

      }

      [DataMember( Name = "CiudadDescripcion" , Order = 13 )]
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

      [DataMember( Name = "PaisDescripcion" , Order = 14 )]
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

      [DataMember( Name = "UsuarioGenero" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Usuariogenero
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariogenero) ;
         }

         set {
            sdt.gxTpr_Usuariogenero = value;
         }

      }

      [DataMember( Name = "FacturaPDF" , Order = 16 )]
      [GxUpload()]
      public string gxTpr_Facturapdf
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Facturapdf)) ? PathUtil.RelativeURL( sdt.gxTpr_Facturapdf) : StringUtil.RTrim( sdt.gxTpr_Facturapdf_gxi)) ;
         }

         set {
            sdt.gxTpr_Facturapdf = value;
         }

      }

      [DataMember( Name = "FacturaEstatus" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Facturaestatus
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Facturaestatus) ;
         }

         set {
            sdt.gxTpr_Facturaestatus = value;
         }

      }

      [DataMember( Name = "MotivoRechazoID" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Motivorechazoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Motivorechazoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Motivorechazoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MotivoRechazoDescripcion" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Motivorechazodescripcion
      {
         get {
            return sdt.gxTpr_Motivorechazodescripcion ;
         }

         set {
            sdt.gxTpr_Motivorechazodescripcion = value;
         }

      }

      [DataMember( Name = "MotivoRechazoActivo" , Order = 20 )]
      [GxSeudo()]
      public bool gxTpr_Motivorechazoactivo
      {
         get {
            return sdt.gxTpr_Motivorechazoactivo ;
         }

         set {
            sdt.gxTpr_Motivorechazoactivo = value;
         }

      }

      [DataMember( Name = "FacturaCompleta" , Order = 21 )]
      [GxSeudo()]
      public bool gxTpr_Facturacompleta
      {
         get {
            return sdt.gxTpr_Facturacompleta ;
         }

         set {
            sdt.gxTpr_Facturacompleta = value;
         }

      }

      public SdtFactura sdt
      {
         get {
            return (SdtFactura)Sdt ;
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
            sdt = new SdtFactura() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 22 )]
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

   [DataContract(Name = @"Factura", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtFactura_RESTLInterface : GxGenericCollectionItem<SdtFactura>
   {
      public SdtFactura_RESTLInterface( ) : base()
      {
      }

      public SdtFactura_RESTLInterface( SdtFactura psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FacturaNo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Facturano
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Facturano) ;
         }

         set {
            sdt.gxTpr_Facturano = value;
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

      public SdtFactura sdt
      {
         get {
            return (SdtFactura)Sdt ;
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
            sdt = new SdtFactura() ;
         }
      }

   }

}
