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
   [XmlRoot(ElementName = "FacturaMedida" )]
   [XmlType(TypeName =  "FacturaMedida" , Namespace = "Premios" )]
   [Serializable]
   public class SdtFacturaMedida : GxSilentTrnSdt
   {
      public SdtFacturaMedida( )
      {
      }

      public SdtFacturaMedida( IGxContext context )
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

      public void Load( int AV77FacturaMedidaID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV77FacturaMedidaID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FacturaMedidaID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "FacturaMedida");
         metadata.Set("BT", "FacturaMedida");
         metadata.Set("PK", "[ \"FacturaMedidaID\" ]");
         metadata.Set("PKAssigned", "[ \"FacturaMedidaID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"FacturaID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"MedidaID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Facturamedidaid_Z");
         state.Add("gxTpr_Facturaid_Z");
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
         state.Add("gxTpr_Promocionid_Z");
         state.Add("gxTpr_Medidaid_Z");
         state.Add("gxTpr_Medidadescripcion_Z");
         state.Add("gxTpr_Medidarin_Z");
         state.Add("gxTpr_Medidacodigo_Z");
         state.Add("gxTpr_Modeloid_Z");
         state.Add("gxTpr_Modelodescripcion_Z");
         state.Add("gxTpr_Facturamedidacantidad_Z");
         state.Add("gxTpr_Facturamedidaprecio_Z");
         state.Add("gxTpr_Usuarionombre_Z");
         state.Add("gxTpr_Usuarioapellido_Z");
         state.Add("gxTpr_Usuariocorreo_Z");
         state.Add("gxTpr_Usuariopass_Z");
         state.Add("gxTpr_Usuariokey_Z");
         state.Add("gxTpr_Puestoid_Z");
         state.Add("gxTpr_Puestodescripcion_Z");
         state.Add("gxTpr_Usuariodirectoasociado_Z");
         state.Add("gxTpr_Usuariorazonsocialasociado_Z");
         state.Add("gxTpr_Usuarionombrecomercial_Z");
         state.Add("gxTpr_Usuariofechanacimiento_Z_Nullable");
         state.Add("gxTpr_Usuariocallenum_Z");
         state.Add("gxTpr_Usuariocolonia_Z");
         state.Add("gxTpr_Usuariodelegacion_Z");
         state.Add("gxTpr_Usuariocp_Z");
         state.Add("gxTpr_Usuariocelular_Z");
         state.Add("gxTpr_Usuariotelefonosucursal_Z");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Estadoid_Z");
         state.Add("gxTpr_Ciudadid_Z");
         state.Add("gxTpr_Usuariosucursal_Z");
         state.Add("gxTpr_Usuarioproducto_Z");
         state.Add("gxTpr_Usuariorol_Z");
         state.Add("gxTpr_Usuarionocuentabroxel_Z");
         state.Add("gxTpr_Usuarioreferenciabroxel_Z");
         state.Add("gxTpr_Promocionarte_gxi_Z");
         state.Add("gxTpr_Facturapdf_gxi_Z");
         state.Add("gxTpr_Puestoid_N");
         state.Add("gxTpr_Usuariodirectoasociado_N");
         state.Add("gxTpr_Usuariofechanacimiento_N");
         state.Add("gxTpr_Ciudadid_N");
         state.Add("gxTpr_Usuarioproducto_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFacturaMedida sdt;
         sdt = (SdtFacturaMedida)(source);
         gxTv_SdtFacturaMedida_Facturamedidaid = sdt.gxTv_SdtFacturaMedida_Facturamedidaid ;
         gxTv_SdtFacturaMedida_Facturaid = sdt.gxTv_SdtFacturaMedida_Facturaid ;
         gxTv_SdtFacturaMedida_Promociondescripcion = sdt.gxTv_SdtFacturaMedida_Promociondescripcion ;
         gxTv_SdtFacturaMedida_Promocionbase = sdt.gxTv_SdtFacturaMedida_Promocionbase ;
         gxTv_SdtFacturaMedida_Promocionarte = sdt.gxTv_SdtFacturaMedida_Promocionarte ;
         gxTv_SdtFacturaMedida_Promocionarte_gxi = sdt.gxTv_SdtFacturaMedida_Promocionarte_gxi ;
         gxTv_SdtFacturaMedida_Promocionvigencia = sdt.gxTv_SdtFacturaMedida_Promocionvigencia ;
         gxTv_SdtFacturaMedida_Facturano = sdt.gxTv_SdtFacturaMedida_Facturano ;
         gxTv_SdtFacturaMedida_Facturafechafactura = sdt.gxTv_SdtFacturaMedida_Facturafechafactura ;
         gxTv_SdtFacturaMedida_Facturafecharegistro = sdt.gxTv_SdtFacturaMedida_Facturafecharegistro ;
         gxTv_SdtFacturaMedida_Usuarioid = sdt.gxTv_SdtFacturaMedida_Usuarioid ;
         gxTv_SdtFacturaMedida_Usuarionombrecompleto = sdt.gxTv_SdtFacturaMedida_Usuarionombrecompleto ;
         gxTv_SdtFacturaMedida_Usuariozona = sdt.gxTv_SdtFacturaMedida_Usuariozona ;
         gxTv_SdtFacturaMedida_Estadodescripcion = sdt.gxTv_SdtFacturaMedida_Estadodescripcion ;
         gxTv_SdtFacturaMedida_Ciudaddescripcion = sdt.gxTv_SdtFacturaMedida_Ciudaddescripcion ;
         gxTv_SdtFacturaMedida_Paisdescripcion = sdt.gxTv_SdtFacturaMedida_Paisdescripcion ;
         gxTv_SdtFacturaMedida_Usuariogenero = sdt.gxTv_SdtFacturaMedida_Usuariogenero ;
         gxTv_SdtFacturaMedida_Facturapdf = sdt.gxTv_SdtFacturaMedida_Facturapdf ;
         gxTv_SdtFacturaMedida_Facturapdf_gxi = sdt.gxTv_SdtFacturaMedida_Facturapdf_gxi ;
         gxTv_SdtFacturaMedida_Facturaestatus = sdt.gxTv_SdtFacturaMedida_Facturaestatus ;
         gxTv_SdtFacturaMedida_Motivorechazoid = sdt.gxTv_SdtFacturaMedida_Motivorechazoid ;
         gxTv_SdtFacturaMedida_Motivorechazodescripcion = sdt.gxTv_SdtFacturaMedida_Motivorechazodescripcion ;
         gxTv_SdtFacturaMedida_Motivorechazoactivo = sdt.gxTv_SdtFacturaMedida_Motivorechazoactivo ;
         gxTv_SdtFacturaMedida_Promocionid = sdt.gxTv_SdtFacturaMedida_Promocionid ;
         gxTv_SdtFacturaMedida_Medidaid = sdt.gxTv_SdtFacturaMedida_Medidaid ;
         gxTv_SdtFacturaMedida_Medidadescripcion = sdt.gxTv_SdtFacturaMedida_Medidadescripcion ;
         gxTv_SdtFacturaMedida_Medidarin = sdt.gxTv_SdtFacturaMedida_Medidarin ;
         gxTv_SdtFacturaMedida_Medidacodigo = sdt.gxTv_SdtFacturaMedida_Medidacodigo ;
         gxTv_SdtFacturaMedida_Modeloid = sdt.gxTv_SdtFacturaMedida_Modeloid ;
         gxTv_SdtFacturaMedida_Modelodescripcion = sdt.gxTv_SdtFacturaMedida_Modelodescripcion ;
         gxTv_SdtFacturaMedida_Facturamedidacantidad = sdt.gxTv_SdtFacturaMedida_Facturamedidacantidad ;
         gxTv_SdtFacturaMedida_Facturamedidaprecio = sdt.gxTv_SdtFacturaMedida_Facturamedidaprecio ;
         gxTv_SdtFacturaMedida_Usuarionombre = sdt.gxTv_SdtFacturaMedida_Usuarionombre ;
         gxTv_SdtFacturaMedida_Usuarioapellido = sdt.gxTv_SdtFacturaMedida_Usuarioapellido ;
         gxTv_SdtFacturaMedida_Usuariocorreo = sdt.gxTv_SdtFacturaMedida_Usuariocorreo ;
         gxTv_SdtFacturaMedida_Usuariopass = sdt.gxTv_SdtFacturaMedida_Usuariopass ;
         gxTv_SdtFacturaMedida_Usuariokey = sdt.gxTv_SdtFacturaMedida_Usuariokey ;
         gxTv_SdtFacturaMedida_Puestoid = sdt.gxTv_SdtFacturaMedida_Puestoid ;
         gxTv_SdtFacturaMedida_Puestodescripcion = sdt.gxTv_SdtFacturaMedida_Puestodescripcion ;
         gxTv_SdtFacturaMedida_Usuariodirectoasociado = sdt.gxTv_SdtFacturaMedida_Usuariodirectoasociado ;
         gxTv_SdtFacturaMedida_Usuariorazonsocialasociado = sdt.gxTv_SdtFacturaMedida_Usuariorazonsocialasociado ;
         gxTv_SdtFacturaMedida_Usuarionombrecomercial = sdt.gxTv_SdtFacturaMedida_Usuarionombrecomercial ;
         gxTv_SdtFacturaMedida_Usuariofechanacimiento = sdt.gxTv_SdtFacturaMedida_Usuariofechanacimiento ;
         gxTv_SdtFacturaMedida_Usuariocallenum = sdt.gxTv_SdtFacturaMedida_Usuariocallenum ;
         gxTv_SdtFacturaMedida_Usuariocolonia = sdt.gxTv_SdtFacturaMedida_Usuariocolonia ;
         gxTv_SdtFacturaMedida_Usuariodelegacion = sdt.gxTv_SdtFacturaMedida_Usuariodelegacion ;
         gxTv_SdtFacturaMedida_Usuariocp = sdt.gxTv_SdtFacturaMedida_Usuariocp ;
         gxTv_SdtFacturaMedida_Usuariocelular = sdt.gxTv_SdtFacturaMedida_Usuariocelular ;
         gxTv_SdtFacturaMedida_Usuariotelefonosucursal = sdt.gxTv_SdtFacturaMedida_Usuariotelefonosucursal ;
         gxTv_SdtFacturaMedida_Paisid = sdt.gxTv_SdtFacturaMedida_Paisid ;
         gxTv_SdtFacturaMedida_Estadoid = sdt.gxTv_SdtFacturaMedida_Estadoid ;
         gxTv_SdtFacturaMedida_Ciudadid = sdt.gxTv_SdtFacturaMedida_Ciudadid ;
         gxTv_SdtFacturaMedida_Usuariosucursal = sdt.gxTv_SdtFacturaMedida_Usuariosucursal ;
         gxTv_SdtFacturaMedida_Usuarioproducto = sdt.gxTv_SdtFacturaMedida_Usuarioproducto ;
         gxTv_SdtFacturaMedida_Usuariorol = sdt.gxTv_SdtFacturaMedida_Usuariorol ;
         gxTv_SdtFacturaMedida_Usuarionocuentabroxel = sdt.gxTv_SdtFacturaMedida_Usuarionocuentabroxel ;
         gxTv_SdtFacturaMedida_Usuarioreferenciabroxel = sdt.gxTv_SdtFacturaMedida_Usuarioreferenciabroxel ;
         gxTv_SdtFacturaMedida_Mode = sdt.gxTv_SdtFacturaMedida_Mode ;
         gxTv_SdtFacturaMedida_Initialized = sdt.gxTv_SdtFacturaMedida_Initialized ;
         gxTv_SdtFacturaMedida_Facturamedidaid_Z = sdt.gxTv_SdtFacturaMedida_Facturamedidaid_Z ;
         gxTv_SdtFacturaMedida_Facturaid_Z = sdt.gxTv_SdtFacturaMedida_Facturaid_Z ;
         gxTv_SdtFacturaMedida_Promociondescripcion_Z = sdt.gxTv_SdtFacturaMedida_Promociondescripcion_Z ;
         gxTv_SdtFacturaMedida_Promocionbase_Z = sdt.gxTv_SdtFacturaMedida_Promocionbase_Z ;
         gxTv_SdtFacturaMedida_Promocionvigencia_Z = sdt.gxTv_SdtFacturaMedida_Promocionvigencia_Z ;
         gxTv_SdtFacturaMedida_Facturano_Z = sdt.gxTv_SdtFacturaMedida_Facturano_Z ;
         gxTv_SdtFacturaMedida_Facturafechafactura_Z = sdt.gxTv_SdtFacturaMedida_Facturafechafactura_Z ;
         gxTv_SdtFacturaMedida_Facturafecharegistro_Z = sdt.gxTv_SdtFacturaMedida_Facturafecharegistro_Z ;
         gxTv_SdtFacturaMedida_Usuarioid_Z = sdt.gxTv_SdtFacturaMedida_Usuarioid_Z ;
         gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z = sdt.gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z ;
         gxTv_SdtFacturaMedida_Usuariozona_Z = sdt.gxTv_SdtFacturaMedida_Usuariozona_Z ;
         gxTv_SdtFacturaMedida_Estadodescripcion_Z = sdt.gxTv_SdtFacturaMedida_Estadodescripcion_Z ;
         gxTv_SdtFacturaMedida_Ciudaddescripcion_Z = sdt.gxTv_SdtFacturaMedida_Ciudaddescripcion_Z ;
         gxTv_SdtFacturaMedida_Paisdescripcion_Z = sdt.gxTv_SdtFacturaMedida_Paisdescripcion_Z ;
         gxTv_SdtFacturaMedida_Usuariogenero_Z = sdt.gxTv_SdtFacturaMedida_Usuariogenero_Z ;
         gxTv_SdtFacturaMedida_Facturaestatus_Z = sdt.gxTv_SdtFacturaMedida_Facturaestatus_Z ;
         gxTv_SdtFacturaMedida_Motivorechazoid_Z = sdt.gxTv_SdtFacturaMedida_Motivorechazoid_Z ;
         gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z = sdt.gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z ;
         gxTv_SdtFacturaMedida_Motivorechazoactivo_Z = sdt.gxTv_SdtFacturaMedida_Motivorechazoactivo_Z ;
         gxTv_SdtFacturaMedida_Promocionid_Z = sdt.gxTv_SdtFacturaMedida_Promocionid_Z ;
         gxTv_SdtFacturaMedida_Medidaid_Z = sdt.gxTv_SdtFacturaMedida_Medidaid_Z ;
         gxTv_SdtFacturaMedida_Medidadescripcion_Z = sdt.gxTv_SdtFacturaMedida_Medidadescripcion_Z ;
         gxTv_SdtFacturaMedida_Medidarin_Z = sdt.gxTv_SdtFacturaMedida_Medidarin_Z ;
         gxTv_SdtFacturaMedida_Medidacodigo_Z = sdt.gxTv_SdtFacturaMedida_Medidacodigo_Z ;
         gxTv_SdtFacturaMedida_Modeloid_Z = sdt.gxTv_SdtFacturaMedida_Modeloid_Z ;
         gxTv_SdtFacturaMedida_Modelodescripcion_Z = sdt.gxTv_SdtFacturaMedida_Modelodescripcion_Z ;
         gxTv_SdtFacturaMedida_Facturamedidacantidad_Z = sdt.gxTv_SdtFacturaMedida_Facturamedidacantidad_Z ;
         gxTv_SdtFacturaMedida_Facturamedidaprecio_Z = sdt.gxTv_SdtFacturaMedida_Facturamedidaprecio_Z ;
         gxTv_SdtFacturaMedida_Usuarionombre_Z = sdt.gxTv_SdtFacturaMedida_Usuarionombre_Z ;
         gxTv_SdtFacturaMedida_Usuarioapellido_Z = sdt.gxTv_SdtFacturaMedida_Usuarioapellido_Z ;
         gxTv_SdtFacturaMedida_Usuariocorreo_Z = sdt.gxTv_SdtFacturaMedida_Usuariocorreo_Z ;
         gxTv_SdtFacturaMedida_Usuariopass_Z = sdt.gxTv_SdtFacturaMedida_Usuariopass_Z ;
         gxTv_SdtFacturaMedida_Usuariokey_Z = sdt.gxTv_SdtFacturaMedida_Usuariokey_Z ;
         gxTv_SdtFacturaMedida_Puestoid_Z = sdt.gxTv_SdtFacturaMedida_Puestoid_Z ;
         gxTv_SdtFacturaMedida_Puestodescripcion_Z = sdt.gxTv_SdtFacturaMedida_Puestodescripcion_Z ;
         gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z = sdt.gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z ;
         gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z = sdt.gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z ;
         gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z = sdt.gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z ;
         gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z = sdt.gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z ;
         gxTv_SdtFacturaMedida_Usuariocallenum_Z = sdt.gxTv_SdtFacturaMedida_Usuariocallenum_Z ;
         gxTv_SdtFacturaMedida_Usuariocolonia_Z = sdt.gxTv_SdtFacturaMedida_Usuariocolonia_Z ;
         gxTv_SdtFacturaMedida_Usuariodelegacion_Z = sdt.gxTv_SdtFacturaMedida_Usuariodelegacion_Z ;
         gxTv_SdtFacturaMedida_Usuariocp_Z = sdt.gxTv_SdtFacturaMedida_Usuariocp_Z ;
         gxTv_SdtFacturaMedida_Usuariocelular_Z = sdt.gxTv_SdtFacturaMedida_Usuariocelular_Z ;
         gxTv_SdtFacturaMedida_Usuariotelefonosucursal_Z = sdt.gxTv_SdtFacturaMedida_Usuariotelefonosucursal_Z ;
         gxTv_SdtFacturaMedida_Paisid_Z = sdt.gxTv_SdtFacturaMedida_Paisid_Z ;
         gxTv_SdtFacturaMedida_Estadoid_Z = sdt.gxTv_SdtFacturaMedida_Estadoid_Z ;
         gxTv_SdtFacturaMedida_Ciudadid_Z = sdt.gxTv_SdtFacturaMedida_Ciudadid_Z ;
         gxTv_SdtFacturaMedida_Usuariosucursal_Z = sdt.gxTv_SdtFacturaMedida_Usuariosucursal_Z ;
         gxTv_SdtFacturaMedida_Usuarioproducto_Z = sdt.gxTv_SdtFacturaMedida_Usuarioproducto_Z ;
         gxTv_SdtFacturaMedida_Usuariorol_Z = sdt.gxTv_SdtFacturaMedida_Usuariorol_Z ;
         gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z = sdt.gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z ;
         gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z = sdt.gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z ;
         gxTv_SdtFacturaMedida_Promocionarte_gxi_Z = sdt.gxTv_SdtFacturaMedida_Promocionarte_gxi_Z ;
         gxTv_SdtFacturaMedida_Facturapdf_gxi_Z = sdt.gxTv_SdtFacturaMedida_Facturapdf_gxi_Z ;
         gxTv_SdtFacturaMedida_Puestoid_N = sdt.gxTv_SdtFacturaMedida_Puestoid_N ;
         gxTv_SdtFacturaMedida_Usuariodirectoasociado_N = sdt.gxTv_SdtFacturaMedida_Usuariodirectoasociado_N ;
         gxTv_SdtFacturaMedida_Usuariofechanacimiento_N = sdt.gxTv_SdtFacturaMedida_Usuariofechanacimiento_N ;
         gxTv_SdtFacturaMedida_Ciudadid_N = sdt.gxTv_SdtFacturaMedida_Ciudadid_N ;
         gxTv_SdtFacturaMedida_Usuarioproducto_N = sdt.gxTv_SdtFacturaMedida_Usuarioproducto_N ;
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
         AddObjectProperty("FacturaMedidaID", gxTv_SdtFacturaMedida_Facturamedidaid, false, includeNonInitialized);
         AddObjectProperty("FacturaID", gxTv_SdtFacturaMedida_Facturaid, false, includeNonInitialized);
         AddObjectProperty("PromocionDescripcion", gxTv_SdtFacturaMedida_Promociondescripcion, false, includeNonInitialized);
         AddObjectProperty("PromocionBase", gxTv_SdtFacturaMedida_Promocionbase, false, includeNonInitialized);
         AddObjectProperty("PromocionArte", gxTv_SdtFacturaMedida_Promocionarte, false, includeNonInitialized);
         AddObjectProperty("PromocionVigencia", gxTv_SdtFacturaMedida_Promocionvigencia, false, includeNonInitialized);
         AddObjectProperty("FacturaNo", gxTv_SdtFacturaMedida_Facturano, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFacturaMedida_Facturafechafactura)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFacturaMedida_Facturafechafactura)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFacturaMedida_Facturafechafactura)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("FacturaFechaFactura", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFacturaMedida_Facturafecharegistro)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFacturaMedida_Facturafecharegistro)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFacturaMedida_Facturafecharegistro)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("FacturaFechaRegistro", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UsuarioID", gxTv_SdtFacturaMedida_Usuarioid, false, includeNonInitialized);
         AddObjectProperty("UsuarioNombreCompleto", gxTv_SdtFacturaMedida_Usuarionombrecompleto, false, includeNonInitialized);
         AddObjectProperty("UsuarioZona", gxTv_SdtFacturaMedida_Usuariozona, false, includeNonInitialized);
         AddObjectProperty("EstadoDescripcion", gxTv_SdtFacturaMedida_Estadodescripcion, false, includeNonInitialized);
         AddObjectProperty("CiudadDescripcion", gxTv_SdtFacturaMedida_Ciudaddescripcion, false, includeNonInitialized);
         AddObjectProperty("PaisDescripcion", gxTv_SdtFacturaMedida_Paisdescripcion, false, includeNonInitialized);
         AddObjectProperty("UsuarioGenero", gxTv_SdtFacturaMedida_Usuariogenero, false, includeNonInitialized);
         AddObjectProperty("FacturaPDF", gxTv_SdtFacturaMedida_Facturapdf, false, includeNonInitialized);
         AddObjectProperty("FacturaEstatus", gxTv_SdtFacturaMedida_Facturaestatus, false, includeNonInitialized);
         AddObjectProperty("MotivoRechazoID", gxTv_SdtFacturaMedida_Motivorechazoid, false, includeNonInitialized);
         AddObjectProperty("MotivoRechazoDescripcion", gxTv_SdtFacturaMedida_Motivorechazodescripcion, false, includeNonInitialized);
         AddObjectProperty("MotivoRechazoActivo", gxTv_SdtFacturaMedida_Motivorechazoactivo, false, includeNonInitialized);
         AddObjectProperty("PromocionID", gxTv_SdtFacturaMedida_Promocionid, false, includeNonInitialized);
         AddObjectProperty("MedidaID", gxTv_SdtFacturaMedida_Medidaid, false, includeNonInitialized);
         AddObjectProperty("MedidaDescripcion", gxTv_SdtFacturaMedida_Medidadescripcion, false, includeNonInitialized);
         AddObjectProperty("MedidaRin", gxTv_SdtFacturaMedida_Medidarin, false, includeNonInitialized);
         AddObjectProperty("MedidaCodigo", gxTv_SdtFacturaMedida_Medidacodigo, false, includeNonInitialized);
         AddObjectProperty("ModeloID", gxTv_SdtFacturaMedida_Modeloid, false, includeNonInitialized);
         AddObjectProperty("ModeloDescripcion", gxTv_SdtFacturaMedida_Modelodescripcion, false, includeNonInitialized);
         AddObjectProperty("FacturaMedidaCantidad", gxTv_SdtFacturaMedida_Facturamedidacantidad, false, includeNonInitialized);
         AddObjectProperty("FacturaMedidaPrecio", gxTv_SdtFacturaMedida_Facturamedidaprecio, false, includeNonInitialized);
         AddObjectProperty("UsuarioNombre", gxTv_SdtFacturaMedida_Usuarionombre, false, includeNonInitialized);
         AddObjectProperty("UsuarioApellido", gxTv_SdtFacturaMedida_Usuarioapellido, false, includeNonInitialized);
         AddObjectProperty("UsuarioCorreo", gxTv_SdtFacturaMedida_Usuariocorreo, false, includeNonInitialized);
         AddObjectProperty("UsuarioPass", gxTv_SdtFacturaMedida_Usuariopass, false, includeNonInitialized);
         AddObjectProperty("UsuarioKey", gxTv_SdtFacturaMedida_Usuariokey, false, includeNonInitialized);
         AddObjectProperty("PuestoID", gxTv_SdtFacturaMedida_Puestoid, false, includeNonInitialized);
         AddObjectProperty("PuestoID_N", gxTv_SdtFacturaMedida_Puestoid_N, false, includeNonInitialized);
         AddObjectProperty("PuestoDescripcion", gxTv_SdtFacturaMedida_Puestodescripcion, false, includeNonInitialized);
         AddObjectProperty("UsuarioDirectoAsociado", gxTv_SdtFacturaMedida_Usuariodirectoasociado, false, includeNonInitialized);
         AddObjectProperty("UsuarioDirectoAsociado_N", gxTv_SdtFacturaMedida_Usuariodirectoasociado_N, false, includeNonInitialized);
         AddObjectProperty("UsuarioRazonSocialAsociado", gxTv_SdtFacturaMedida_Usuariorazonsocialasociado, false, includeNonInitialized);
         AddObjectProperty("UsuarioNombreComercial", gxTv_SdtFacturaMedida_Usuarionombrecomercial, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFacturaMedida_Usuariofechanacimiento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFacturaMedida_Usuariofechanacimiento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFacturaMedida_Usuariofechanacimiento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuarioFechaNacimiento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UsuarioFechaNacimiento_N", gxTv_SdtFacturaMedida_Usuariofechanacimiento_N, false, includeNonInitialized);
         AddObjectProperty("UsuarioCalleNum", gxTv_SdtFacturaMedida_Usuariocallenum, false, includeNonInitialized);
         AddObjectProperty("UsuarioColonia", gxTv_SdtFacturaMedida_Usuariocolonia, false, includeNonInitialized);
         AddObjectProperty("UsuarioDelegacion", gxTv_SdtFacturaMedida_Usuariodelegacion, false, includeNonInitialized);
         AddObjectProperty("UsuarioCP", gxTv_SdtFacturaMedida_Usuariocp, false, includeNonInitialized);
         AddObjectProperty("UsuarioCelular", gxTv_SdtFacturaMedida_Usuariocelular, false, includeNonInitialized);
         AddObjectProperty("UsuarioTelefonoSucursal", gxTv_SdtFacturaMedida_Usuariotelefonosucursal, false, includeNonInitialized);
         AddObjectProperty("PaisID", gxTv_SdtFacturaMedida_Paisid, false, includeNonInitialized);
         AddObjectProperty("EstadoID", gxTv_SdtFacturaMedida_Estadoid, false, includeNonInitialized);
         AddObjectProperty("CiudadID", gxTv_SdtFacturaMedida_Ciudadid, false, includeNonInitialized);
         AddObjectProperty("CiudadID_N", gxTv_SdtFacturaMedida_Ciudadid_N, false, includeNonInitialized);
         AddObjectProperty("UsuarioSucursal", gxTv_SdtFacturaMedida_Usuariosucursal, false, includeNonInitialized);
         AddObjectProperty("UsuarioProducto", gxTv_SdtFacturaMedida_Usuarioproducto, false, includeNonInitialized);
         AddObjectProperty("UsuarioProducto_N", gxTv_SdtFacturaMedida_Usuarioproducto_N, false, includeNonInitialized);
         AddObjectProperty("UsuarioRol", gxTv_SdtFacturaMedida_Usuariorol, false, includeNonInitialized);
         AddObjectProperty("UsuarioNoCuentaBROXEL", gxTv_SdtFacturaMedida_Usuarionocuentabroxel, false, includeNonInitialized);
         AddObjectProperty("UsuarioReferenciaBROXEL", gxTv_SdtFacturaMedida_Usuarioreferenciabroxel, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("PromocionArte_GXI", gxTv_SdtFacturaMedida_Promocionarte_gxi, false, includeNonInitialized);
            AddObjectProperty("FacturaPDF_GXI", gxTv_SdtFacturaMedida_Facturapdf_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtFacturaMedida_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFacturaMedida_Initialized, false, includeNonInitialized);
            AddObjectProperty("FacturaMedidaID_Z", gxTv_SdtFacturaMedida_Facturamedidaid_Z, false, includeNonInitialized);
            AddObjectProperty("FacturaID_Z", gxTv_SdtFacturaMedida_Facturaid_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionDescripcion_Z", gxTv_SdtFacturaMedida_Promociondescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionBase_Z", gxTv_SdtFacturaMedida_Promocionbase_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionVigencia_Z", gxTv_SdtFacturaMedida_Promocionvigencia_Z, false, includeNonInitialized);
            AddObjectProperty("FacturaNo_Z", gxTv_SdtFacturaMedida_Facturano_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFacturaMedida_Facturafechafactura_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFacturaMedida_Facturafechafactura_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFacturaMedida_Facturafechafactura_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("FacturaFechaFactura_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFacturaMedida_Facturafecharegistro_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFacturaMedida_Facturafecharegistro_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFacturaMedida_Facturafecharegistro_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("FacturaFechaRegistro_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("UsuarioID_Z", gxTv_SdtFacturaMedida_Usuarioid_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioNombreCompleto_Z", gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioZona_Z", gxTv_SdtFacturaMedida_Usuariozona_Z, false, includeNonInitialized);
            AddObjectProperty("EstadoDescripcion_Z", gxTv_SdtFacturaMedida_Estadodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("CiudadDescripcion_Z", gxTv_SdtFacturaMedida_Ciudaddescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PaisDescripcion_Z", gxTv_SdtFacturaMedida_Paisdescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioGenero_Z", gxTv_SdtFacturaMedida_Usuariogenero_Z, false, includeNonInitialized);
            AddObjectProperty("FacturaEstatus_Z", gxTv_SdtFacturaMedida_Facturaestatus_Z, false, includeNonInitialized);
            AddObjectProperty("MotivoRechazoID_Z", gxTv_SdtFacturaMedida_Motivorechazoid_Z, false, includeNonInitialized);
            AddObjectProperty("MotivoRechazoDescripcion_Z", gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("MotivoRechazoActivo_Z", gxTv_SdtFacturaMedida_Motivorechazoactivo_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionID_Z", gxTv_SdtFacturaMedida_Promocionid_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaID_Z", gxTv_SdtFacturaMedida_Medidaid_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaDescripcion_Z", gxTv_SdtFacturaMedida_Medidadescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaRin_Z", gxTv_SdtFacturaMedida_Medidarin_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaCodigo_Z", gxTv_SdtFacturaMedida_Medidacodigo_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloID_Z", gxTv_SdtFacturaMedida_Modeloid_Z, false, includeNonInitialized);
            AddObjectProperty("ModeloDescripcion_Z", gxTv_SdtFacturaMedida_Modelodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("FacturaMedidaCantidad_Z", gxTv_SdtFacturaMedida_Facturamedidacantidad_Z, false, includeNonInitialized);
            AddObjectProperty("FacturaMedidaPrecio_Z", gxTv_SdtFacturaMedida_Facturamedidaprecio_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioNombre_Z", gxTv_SdtFacturaMedida_Usuarionombre_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioApellido_Z", gxTv_SdtFacturaMedida_Usuarioapellido_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioCorreo_Z", gxTv_SdtFacturaMedida_Usuariocorreo_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioPass_Z", gxTv_SdtFacturaMedida_Usuariopass_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioKey_Z", gxTv_SdtFacturaMedida_Usuariokey_Z, false, includeNonInitialized);
            AddObjectProperty("PuestoID_Z", gxTv_SdtFacturaMedida_Puestoid_Z, false, includeNonInitialized);
            AddObjectProperty("PuestoDescripcion_Z", gxTv_SdtFacturaMedida_Puestodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioDirectoAsociado_Z", gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioRazonSocialAsociado_Z", gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioNombreComercial_Z", gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("UsuarioFechaNacimiento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("UsuarioCalleNum_Z", gxTv_SdtFacturaMedida_Usuariocallenum_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioColonia_Z", gxTv_SdtFacturaMedida_Usuariocolonia_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioDelegacion_Z", gxTv_SdtFacturaMedida_Usuariodelegacion_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioCP_Z", gxTv_SdtFacturaMedida_Usuariocp_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioCelular_Z", gxTv_SdtFacturaMedida_Usuariocelular_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioTelefonoSucursal_Z", gxTv_SdtFacturaMedida_Usuariotelefonosucursal_Z, false, includeNonInitialized);
            AddObjectProperty("PaisID_Z", gxTv_SdtFacturaMedida_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("EstadoID_Z", gxTv_SdtFacturaMedida_Estadoid_Z, false, includeNonInitialized);
            AddObjectProperty("CiudadID_Z", gxTv_SdtFacturaMedida_Ciudadid_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioSucursal_Z", gxTv_SdtFacturaMedida_Usuariosucursal_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioProducto_Z", gxTv_SdtFacturaMedida_Usuarioproducto_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioRol_Z", gxTv_SdtFacturaMedida_Usuariorol_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioNoCuentaBROXEL_Z", gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioReferenciaBROXEL_Z", gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z, false, includeNonInitialized);
            AddObjectProperty("PromocionArte_GXI_Z", gxTv_SdtFacturaMedida_Promocionarte_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("FacturaPDF_GXI_Z", gxTv_SdtFacturaMedida_Facturapdf_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("PuestoID_N", gxTv_SdtFacturaMedida_Puestoid_N, false, includeNonInitialized);
            AddObjectProperty("UsuarioDirectoAsociado_N", gxTv_SdtFacturaMedida_Usuariodirectoasociado_N, false, includeNonInitialized);
            AddObjectProperty("UsuarioFechaNacimiento_N", gxTv_SdtFacturaMedida_Usuariofechanacimiento_N, false, includeNonInitialized);
            AddObjectProperty("CiudadID_N", gxTv_SdtFacturaMedida_Ciudadid_N, false, includeNonInitialized);
            AddObjectProperty("UsuarioProducto_N", gxTv_SdtFacturaMedida_Usuarioproducto_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFacturaMedida sdt )
      {
         if ( sdt.IsDirty("FacturaMedidaID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturamedidaid = sdt.gxTv_SdtFacturaMedida_Facturamedidaid ;
         }
         if ( sdt.IsDirty("FacturaID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturaid = sdt.gxTv_SdtFacturaMedida_Facturaid ;
         }
         if ( sdt.IsDirty("PromocionDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promociondescripcion = sdt.gxTv_SdtFacturaMedida_Promociondescripcion ;
         }
         if ( sdt.IsDirty("PromocionBase") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionbase = sdt.gxTv_SdtFacturaMedida_Promocionbase ;
         }
         if ( sdt.IsDirty("PromocionArte") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionarte = sdt.gxTv_SdtFacturaMedida_Promocionarte ;
         }
         if ( sdt.IsDirty("PromocionArte") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionarte_gxi = sdt.gxTv_SdtFacturaMedida_Promocionarte_gxi ;
         }
         if ( sdt.IsDirty("PromocionVigencia") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionvigencia = sdt.gxTv_SdtFacturaMedida_Promocionvigencia ;
         }
         if ( sdt.IsDirty("FacturaNo") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturano = sdt.gxTv_SdtFacturaMedida_Facturano ;
         }
         if ( sdt.IsDirty("FacturaFechaFactura") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturafechafactura = sdt.gxTv_SdtFacturaMedida_Facturafechafactura ;
         }
         if ( sdt.IsDirty("FacturaFechaRegistro") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturafecharegistro = sdt.gxTv_SdtFacturaMedida_Facturafecharegistro ;
         }
         if ( sdt.IsDirty("UsuarioID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioid = sdt.gxTv_SdtFacturaMedida_Usuarioid ;
         }
         if ( sdt.IsDirty("UsuarioNombreCompleto") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionombrecompleto = sdt.gxTv_SdtFacturaMedida_Usuarionombrecompleto ;
         }
         if ( sdt.IsDirty("UsuarioZona") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariozona = sdt.gxTv_SdtFacturaMedida_Usuariozona ;
         }
         if ( sdt.IsDirty("EstadoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Estadodescripcion = sdt.gxTv_SdtFacturaMedida_Estadodescripcion ;
         }
         if ( sdt.IsDirty("CiudadDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Ciudaddescripcion = sdt.gxTv_SdtFacturaMedida_Ciudaddescripcion ;
         }
         if ( sdt.IsDirty("PaisDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Paisdescripcion = sdt.gxTv_SdtFacturaMedida_Paisdescripcion ;
         }
         if ( sdt.IsDirty("UsuarioGenero") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariogenero = sdt.gxTv_SdtFacturaMedida_Usuariogenero ;
         }
         if ( sdt.IsDirty("FacturaPDF") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturapdf = sdt.gxTv_SdtFacturaMedida_Facturapdf ;
         }
         if ( sdt.IsDirty("FacturaPDF") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturapdf_gxi = sdt.gxTv_SdtFacturaMedida_Facturapdf_gxi ;
         }
         if ( sdt.IsDirty("FacturaEstatus") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturaestatus = sdt.gxTv_SdtFacturaMedida_Facturaestatus ;
         }
         if ( sdt.IsDirty("MotivoRechazoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Motivorechazoid = sdt.gxTv_SdtFacturaMedida_Motivorechazoid ;
         }
         if ( sdt.IsDirty("MotivoRechazoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Motivorechazodescripcion = sdt.gxTv_SdtFacturaMedida_Motivorechazodescripcion ;
         }
         if ( sdt.IsDirty("MotivoRechazoActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Motivorechazoactivo = sdt.gxTv_SdtFacturaMedida_Motivorechazoactivo ;
         }
         if ( sdt.IsDirty("PromocionID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionid = sdt.gxTv_SdtFacturaMedida_Promocionid ;
         }
         if ( sdt.IsDirty("MedidaID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidaid = sdt.gxTv_SdtFacturaMedida_Medidaid ;
         }
         if ( sdt.IsDirty("MedidaDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidadescripcion = sdt.gxTv_SdtFacturaMedida_Medidadescripcion ;
         }
         if ( sdt.IsDirty("MedidaRin") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidarin = sdt.gxTv_SdtFacturaMedida_Medidarin ;
         }
         if ( sdt.IsDirty("MedidaCodigo") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidacodigo = sdt.gxTv_SdtFacturaMedida_Medidacodigo ;
         }
         if ( sdt.IsDirty("ModeloID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Modeloid = sdt.gxTv_SdtFacturaMedida_Modeloid ;
         }
         if ( sdt.IsDirty("ModeloDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Modelodescripcion = sdt.gxTv_SdtFacturaMedida_Modelodescripcion ;
         }
         if ( sdt.IsDirty("FacturaMedidaCantidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturamedidacantidad = sdt.gxTv_SdtFacturaMedida_Facturamedidacantidad ;
         }
         if ( sdt.IsDirty("FacturaMedidaPrecio") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturamedidaprecio = sdt.gxTv_SdtFacturaMedida_Facturamedidaprecio ;
         }
         if ( sdt.IsDirty("UsuarioNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionombre = sdt.gxTv_SdtFacturaMedida_Usuarionombre ;
         }
         if ( sdt.IsDirty("UsuarioApellido") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioapellido = sdt.gxTv_SdtFacturaMedida_Usuarioapellido ;
         }
         if ( sdt.IsDirty("UsuarioCorreo") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocorreo = sdt.gxTv_SdtFacturaMedida_Usuariocorreo ;
         }
         if ( sdt.IsDirty("UsuarioPass") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariopass = sdt.gxTv_SdtFacturaMedida_Usuariopass ;
         }
         if ( sdt.IsDirty("UsuarioKey") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariokey = sdt.gxTv_SdtFacturaMedida_Usuariokey ;
         }
         if ( sdt.IsDirty("PuestoID") )
         {
            gxTv_SdtFacturaMedida_Puestoid_N = (short)(sdt.gxTv_SdtFacturaMedida_Puestoid_N);
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Puestoid = sdt.gxTv_SdtFacturaMedida_Puestoid ;
         }
         if ( sdt.IsDirty("PuestoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Puestodescripcion = sdt.gxTv_SdtFacturaMedida_Puestodescripcion ;
         }
         if ( sdt.IsDirty("UsuarioDirectoAsociado") )
         {
            gxTv_SdtFacturaMedida_Usuariodirectoasociado_N = (short)(sdt.gxTv_SdtFacturaMedida_Usuariodirectoasociado_N);
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariodirectoasociado = sdt.gxTv_SdtFacturaMedida_Usuariodirectoasociado ;
         }
         if ( sdt.IsDirty("UsuarioRazonSocialAsociado") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariorazonsocialasociado = sdt.gxTv_SdtFacturaMedida_Usuariorazonsocialasociado ;
         }
         if ( sdt.IsDirty("UsuarioNombreComercial") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionombrecomercial = sdt.gxTv_SdtFacturaMedida_Usuarionombrecomercial ;
         }
         if ( sdt.IsDirty("UsuarioFechaNacimiento") )
         {
            gxTv_SdtFacturaMedida_Usuariofechanacimiento_N = (short)(sdt.gxTv_SdtFacturaMedida_Usuariofechanacimiento_N);
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariofechanacimiento = sdt.gxTv_SdtFacturaMedida_Usuariofechanacimiento ;
         }
         if ( sdt.IsDirty("UsuarioCalleNum") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocallenum = sdt.gxTv_SdtFacturaMedida_Usuariocallenum ;
         }
         if ( sdt.IsDirty("UsuarioColonia") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocolonia = sdt.gxTv_SdtFacturaMedida_Usuariocolonia ;
         }
         if ( sdt.IsDirty("UsuarioDelegacion") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariodelegacion = sdt.gxTv_SdtFacturaMedida_Usuariodelegacion ;
         }
         if ( sdt.IsDirty("UsuarioCP") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocp = sdt.gxTv_SdtFacturaMedida_Usuariocp ;
         }
         if ( sdt.IsDirty("UsuarioCelular") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocelular = sdt.gxTv_SdtFacturaMedida_Usuariocelular ;
         }
         if ( sdt.IsDirty("UsuarioTelefonoSucursal") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariotelefonosucursal = sdt.gxTv_SdtFacturaMedida_Usuariotelefonosucursal ;
         }
         if ( sdt.IsDirty("PaisID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Paisid = sdt.gxTv_SdtFacturaMedida_Paisid ;
         }
         if ( sdt.IsDirty("EstadoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Estadoid = sdt.gxTv_SdtFacturaMedida_Estadoid ;
         }
         if ( sdt.IsDirty("CiudadID") )
         {
            gxTv_SdtFacturaMedida_Ciudadid_N = (short)(sdt.gxTv_SdtFacturaMedida_Ciudadid_N);
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Ciudadid = sdt.gxTv_SdtFacturaMedida_Ciudadid ;
         }
         if ( sdt.IsDirty("UsuarioSucursal") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariosucursal = sdt.gxTv_SdtFacturaMedida_Usuariosucursal ;
         }
         if ( sdt.IsDirty("UsuarioProducto") )
         {
            gxTv_SdtFacturaMedida_Usuarioproducto_N = (short)(sdt.gxTv_SdtFacturaMedida_Usuarioproducto_N);
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioproducto = sdt.gxTv_SdtFacturaMedida_Usuarioproducto ;
         }
         if ( sdt.IsDirty("UsuarioRol") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariorol = sdt.gxTv_SdtFacturaMedida_Usuariorol ;
         }
         if ( sdt.IsDirty("UsuarioNoCuentaBROXEL") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionocuentabroxel = sdt.gxTv_SdtFacturaMedida_Usuarionocuentabroxel ;
         }
         if ( sdt.IsDirty("UsuarioReferenciaBROXEL") )
         {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioreferenciabroxel = sdt.gxTv_SdtFacturaMedida_Usuarioreferenciabroxel ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FacturaMedidaID" )]
      [  XmlElement( ElementName = "FacturaMedidaID"   )]
      public int gxTpr_Facturamedidaid
      {
         get {
            return gxTv_SdtFacturaMedida_Facturamedidaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtFacturaMedida_Facturamedidaid != value )
            {
               gxTv_SdtFacturaMedida_Mode = "INS";
               this.gxTv_SdtFacturaMedida_Facturamedidaid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Facturaid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Promociondescripcion_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Promocionbase_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Promocionvigencia_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Facturano_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Facturafechafactura_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Facturafecharegistro_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuarioid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariozona_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Estadodescripcion_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Ciudaddescripcion_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Paisdescripcion_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariogenero_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Facturaestatus_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Motivorechazoid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Motivorechazoactivo_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Promocionid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Medidaid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Medidadescripcion_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Medidarin_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Medidacodigo_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Modeloid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Modelodescripcion_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Facturamedidacantidad_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Facturamedidaprecio_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuarionombre_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuarioapellido_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariocorreo_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariopass_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariokey_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Puestoid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Puestodescripcion_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariocallenum_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariocolonia_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariodelegacion_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariocp_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariocelular_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariotelefonosucursal_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Paisid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Estadoid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Ciudadid_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariosucursal_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuarioproducto_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuariorol_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Promocionarte_gxi_Z_SetNull( );
               this.gxTv_SdtFacturaMedida_Facturapdf_gxi_Z_SetNull( );
            }
            gxTv_SdtFacturaMedida_Facturamedidaid = value;
            SetDirty("Facturamedidaid");
         }

      }

      [  SoapElement( ElementName = "FacturaID" )]
      [  XmlElement( ElementName = "FacturaID"   )]
      public int gxTpr_Facturaid
      {
         get {
            return gxTv_SdtFacturaMedida_Facturaid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturaid = value;
            SetDirty("Facturaid");
         }

      }

      [  SoapElement( ElementName = "PromocionDescripcion" )]
      [  XmlElement( ElementName = "PromocionDescripcion"   )]
      public string gxTpr_Promociondescripcion
      {
         get {
            return gxTv_SdtFacturaMedida_Promociondescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promociondescripcion = value;
            SetDirty("Promociondescripcion");
         }

      }

      [  SoapElement( ElementName = "PromocionBase" )]
      [  XmlElement( ElementName = "PromocionBase"   )]
      public string gxTpr_Promocionbase
      {
         get {
            return gxTv_SdtFacturaMedida_Promocionbase ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionbase = value;
            SetDirty("Promocionbase");
         }

      }

      [  SoapElement( ElementName = "PromocionArte" )]
      [  XmlElement( ElementName = "PromocionArte"   )]
      [GxUpload()]
      public string gxTpr_Promocionarte
      {
         get {
            return gxTv_SdtFacturaMedida_Promocionarte ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionarte = value;
            SetDirty("Promocionarte");
         }

      }

      [  SoapElement( ElementName = "PromocionArte_GXI" )]
      [  XmlElement( ElementName = "PromocionArte_GXI"   )]
      public string gxTpr_Promocionarte_gxi
      {
         get {
            return gxTv_SdtFacturaMedida_Promocionarte_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionarte_gxi = value;
            SetDirty("Promocionarte_gxi");
         }

      }

      [  SoapElement( ElementName = "PromocionVigencia" )]
      [  XmlElement( ElementName = "PromocionVigencia"   )]
      public string gxTpr_Promocionvigencia
      {
         get {
            return gxTv_SdtFacturaMedida_Promocionvigencia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionvigencia = value;
            SetDirty("Promocionvigencia");
         }

      }

      public void gxTv_SdtFacturaMedida_Promocionvigencia_SetNull( )
      {
         gxTv_SdtFacturaMedida_Promocionvigencia = "";
         SetDirty("Promocionvigencia");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Promocionvigencia_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaNo" )]
      [  XmlElement( ElementName = "FacturaNo"   )]
      public string gxTpr_Facturano
      {
         get {
            return gxTv_SdtFacturaMedida_Facturano ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturano = value;
            SetDirty("Facturano");
         }

      }

      [  SoapElement( ElementName = "FacturaFechaFactura" )]
      [  XmlElement( ElementName = "FacturaFechaFactura"  , IsNullable=true )]
      public string gxTpr_Facturafechafactura_Nullable
      {
         get {
            if ( gxTv_SdtFacturaMedida_Facturafechafactura == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFacturaMedida_Facturafechafactura).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFacturaMedida_Facturafechafactura = DateTime.MinValue;
            else
               gxTv_SdtFacturaMedida_Facturafechafactura = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Facturafechafactura
      {
         get {
            return gxTv_SdtFacturaMedida_Facturafechafactura ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturafechafactura = value;
            SetDirty("Facturafechafactura");
         }

      }

      [  SoapElement( ElementName = "FacturaFechaRegistro" )]
      [  XmlElement( ElementName = "FacturaFechaRegistro"  , IsNullable=true )]
      public string gxTpr_Facturafecharegistro_Nullable
      {
         get {
            if ( gxTv_SdtFacturaMedida_Facturafecharegistro == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFacturaMedida_Facturafecharegistro).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFacturaMedida_Facturafecharegistro = DateTime.MinValue;
            else
               gxTv_SdtFacturaMedida_Facturafecharegistro = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Facturafecharegistro
      {
         get {
            return gxTv_SdtFacturaMedida_Facturafecharegistro ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturafecharegistro = value;
            SetDirty("Facturafecharegistro");
         }

      }

      [  SoapElement( ElementName = "UsuarioID" )]
      [  XmlElement( ElementName = "UsuarioID"   )]
      public int gxTpr_Usuarioid
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarioid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioid = value;
            SetDirty("Usuarioid");
         }

      }

      [  SoapElement( ElementName = "UsuarioNombreCompleto" )]
      [  XmlElement( ElementName = "UsuarioNombreCompleto"   )]
      public string gxTpr_Usuarionombrecompleto
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarionombrecompleto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionombrecompleto = value;
            SetDirty("Usuarionombrecompleto");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarionombrecompleto_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarionombrecompleto = "";
         SetDirty("Usuarionombrecompleto");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarionombrecompleto_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioZona" )]
      [  XmlElement( ElementName = "UsuarioZona"   )]
      public string gxTpr_Usuariozona
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariozona ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariozona = value;
            SetDirty("Usuariozona");
         }

      }

      [  SoapElement( ElementName = "EstadoDescripcion" )]
      [  XmlElement( ElementName = "EstadoDescripcion"   )]
      public string gxTpr_Estadodescripcion
      {
         get {
            return gxTv_SdtFacturaMedida_Estadodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Estadodescripcion = value;
            SetDirty("Estadodescripcion");
         }

      }

      [  SoapElement( ElementName = "CiudadDescripcion" )]
      [  XmlElement( ElementName = "CiudadDescripcion"   )]
      public string gxTpr_Ciudaddescripcion
      {
         get {
            return gxTv_SdtFacturaMedida_Ciudaddescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Ciudaddescripcion = value;
            SetDirty("Ciudaddescripcion");
         }

      }

      [  SoapElement( ElementName = "PaisDescripcion" )]
      [  XmlElement( ElementName = "PaisDescripcion"   )]
      public string gxTpr_Paisdescripcion
      {
         get {
            return gxTv_SdtFacturaMedida_Paisdescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Paisdescripcion = value;
            SetDirty("Paisdescripcion");
         }

      }

      [  SoapElement( ElementName = "UsuarioGenero" )]
      [  XmlElement( ElementName = "UsuarioGenero"   )]
      public string gxTpr_Usuariogenero
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariogenero ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariogenero = value;
            SetDirty("Usuariogenero");
         }

      }

      [  SoapElement( ElementName = "FacturaPDF" )]
      [  XmlElement( ElementName = "FacturaPDF"   )]
      [GxUpload()]
      public string gxTpr_Facturapdf
      {
         get {
            return gxTv_SdtFacturaMedida_Facturapdf ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturapdf = value;
            SetDirty("Facturapdf");
         }

      }

      [  SoapElement( ElementName = "FacturaPDF_GXI" )]
      [  XmlElement( ElementName = "FacturaPDF_GXI"   )]
      public string gxTpr_Facturapdf_gxi
      {
         get {
            return gxTv_SdtFacturaMedida_Facturapdf_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturapdf_gxi = value;
            SetDirty("Facturapdf_gxi");
         }

      }

      [  SoapElement( ElementName = "FacturaEstatus" )]
      [  XmlElement( ElementName = "FacturaEstatus"   )]
      public string gxTpr_Facturaestatus
      {
         get {
            return gxTv_SdtFacturaMedida_Facturaestatus ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturaestatus = value;
            SetDirty("Facturaestatus");
         }

      }

      [  SoapElement( ElementName = "MotivoRechazoID" )]
      [  XmlElement( ElementName = "MotivoRechazoID"   )]
      public int gxTpr_Motivorechazoid
      {
         get {
            return gxTv_SdtFacturaMedida_Motivorechazoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Motivorechazoid = value;
            SetDirty("Motivorechazoid");
         }

      }

      [  SoapElement( ElementName = "MotivoRechazoDescripcion" )]
      [  XmlElement( ElementName = "MotivoRechazoDescripcion"   )]
      public string gxTpr_Motivorechazodescripcion
      {
         get {
            return gxTv_SdtFacturaMedida_Motivorechazodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Motivorechazodescripcion = value;
            SetDirty("Motivorechazodescripcion");
         }

      }

      [  SoapElement( ElementName = "MotivoRechazoActivo" )]
      [  XmlElement( ElementName = "MotivoRechazoActivo"   )]
      public bool gxTpr_Motivorechazoactivo
      {
         get {
            return gxTv_SdtFacturaMedida_Motivorechazoactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Motivorechazoactivo = value;
            SetDirty("Motivorechazoactivo");
         }

      }

      [  SoapElement( ElementName = "PromocionID" )]
      [  XmlElement( ElementName = "PromocionID"   )]
      public int gxTpr_Promocionid
      {
         get {
            return gxTv_SdtFacturaMedida_Promocionid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionid = value;
            SetDirty("Promocionid");
         }

      }

      [  SoapElement( ElementName = "MedidaID" )]
      [  XmlElement( ElementName = "MedidaID"   )]
      public int gxTpr_Medidaid
      {
         get {
            return gxTv_SdtFacturaMedida_Medidaid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidaid = value;
            SetDirty("Medidaid");
         }

      }

      [  SoapElement( ElementName = "MedidaDescripcion" )]
      [  XmlElement( ElementName = "MedidaDescripcion"   )]
      public string gxTpr_Medidadescripcion
      {
         get {
            return gxTv_SdtFacturaMedida_Medidadescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidadescripcion = value;
            SetDirty("Medidadescripcion");
         }

      }

      [  SoapElement( ElementName = "MedidaRin" )]
      [  XmlElement( ElementName = "MedidaRin"   )]
      public string gxTpr_Medidarin
      {
         get {
            return gxTv_SdtFacturaMedida_Medidarin ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidarin = value;
            SetDirty("Medidarin");
         }

      }

      [  SoapElement( ElementName = "MedidaCodigo" )]
      [  XmlElement( ElementName = "MedidaCodigo"   )]
      public string gxTpr_Medidacodigo
      {
         get {
            return gxTv_SdtFacturaMedida_Medidacodigo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidacodigo = value;
            SetDirty("Medidacodigo");
         }

      }

      [  SoapElement( ElementName = "ModeloID" )]
      [  XmlElement( ElementName = "ModeloID"   )]
      public int gxTpr_Modeloid
      {
         get {
            return gxTv_SdtFacturaMedida_Modeloid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Modeloid = value;
            SetDirty("Modeloid");
         }

      }

      [  SoapElement( ElementName = "ModeloDescripcion" )]
      [  XmlElement( ElementName = "ModeloDescripcion"   )]
      public string gxTpr_Modelodescripcion
      {
         get {
            return gxTv_SdtFacturaMedida_Modelodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Modelodescripcion = value;
            SetDirty("Modelodescripcion");
         }

      }

      [  SoapElement( ElementName = "FacturaMedidaCantidad" )]
      [  XmlElement( ElementName = "FacturaMedidaCantidad"   )]
      public short gxTpr_Facturamedidacantidad
      {
         get {
            return gxTv_SdtFacturaMedida_Facturamedidacantidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturamedidacantidad = value;
            SetDirty("Facturamedidacantidad");
         }

      }

      [  SoapElement( ElementName = "FacturaMedidaPrecio" )]
      [  XmlElement( ElementName = "FacturaMedidaPrecio"   )]
      public decimal gxTpr_Facturamedidaprecio
      {
         get {
            return gxTv_SdtFacturaMedida_Facturamedidaprecio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturamedidaprecio = value;
            SetDirty("Facturamedidaprecio");
         }

      }

      [  SoapElement( ElementName = "UsuarioNombre" )]
      [  XmlElement( ElementName = "UsuarioNombre"   )]
      public string gxTpr_Usuarionombre
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarionombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionombre = value;
            SetDirty("Usuarionombre");
         }

      }

      [  SoapElement( ElementName = "UsuarioApellido" )]
      [  XmlElement( ElementName = "UsuarioApellido"   )]
      public string gxTpr_Usuarioapellido
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarioapellido ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioapellido = value;
            SetDirty("Usuarioapellido");
         }

      }

      [  SoapElement( ElementName = "UsuarioCorreo" )]
      [  XmlElement( ElementName = "UsuarioCorreo"   )]
      public string gxTpr_Usuariocorreo
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariocorreo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocorreo = value;
            SetDirty("Usuariocorreo");
         }

      }

      [  SoapElement( ElementName = "UsuarioPass" )]
      [  XmlElement( ElementName = "UsuarioPass"   )]
      public string gxTpr_Usuariopass
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariopass ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariopass = value;
            SetDirty("Usuariopass");
         }

      }

      [  SoapElement( ElementName = "UsuarioKey" )]
      [  XmlElement( ElementName = "UsuarioKey"   )]
      public string gxTpr_Usuariokey
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariokey ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariokey = value;
            SetDirty("Usuariokey");
         }

      }

      [  SoapElement( ElementName = "PuestoID" )]
      [  XmlElement( ElementName = "PuestoID"   )]
      public int gxTpr_Puestoid
      {
         get {
            return gxTv_SdtFacturaMedida_Puestoid ;
         }

         set {
            gxTv_SdtFacturaMedida_Puestoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Puestoid = value;
            SetDirty("Puestoid");
         }

      }

      public void gxTv_SdtFacturaMedida_Puestoid_SetNull( )
      {
         gxTv_SdtFacturaMedida_Puestoid_N = 1;
         gxTv_SdtFacturaMedida_Puestoid = 0;
         SetDirty("Puestoid");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Puestoid_IsNull( )
      {
         return (gxTv_SdtFacturaMedida_Puestoid_N==1) ;
      }

      [  SoapElement( ElementName = "PuestoDescripcion" )]
      [  XmlElement( ElementName = "PuestoDescripcion"   )]
      public string gxTpr_Puestodescripcion
      {
         get {
            return gxTv_SdtFacturaMedida_Puestodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Puestodescripcion = value;
            SetDirty("Puestodescripcion");
         }

      }

      [  SoapElement( ElementName = "UsuarioDirectoAsociado" )]
      [  XmlElement( ElementName = "UsuarioDirectoAsociado"   )]
      public string gxTpr_Usuariodirectoasociado
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariodirectoasociado ;
         }

         set {
            gxTv_SdtFacturaMedida_Usuariodirectoasociado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariodirectoasociado = value;
            SetDirty("Usuariodirectoasociado");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariodirectoasociado_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariodirectoasociado_N = 1;
         gxTv_SdtFacturaMedida_Usuariodirectoasociado = "";
         SetDirty("Usuariodirectoasociado");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariodirectoasociado_IsNull( )
      {
         return (gxTv_SdtFacturaMedida_Usuariodirectoasociado_N==1) ;
      }

      [  SoapElement( ElementName = "UsuarioRazonSocialAsociado" )]
      [  XmlElement( ElementName = "UsuarioRazonSocialAsociado"   )]
      public string gxTpr_Usuariorazonsocialasociado
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariorazonsocialasociado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariorazonsocialasociado = value;
            SetDirty("Usuariorazonsocialasociado");
         }

      }

      [  SoapElement( ElementName = "UsuarioNombreComercial" )]
      [  XmlElement( ElementName = "UsuarioNombreComercial"   )]
      public string gxTpr_Usuarionombrecomercial
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarionombrecomercial ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionombrecomercial = value;
            SetDirty("Usuarionombrecomercial");
         }

      }

      [  SoapElement( ElementName = "UsuarioFechaNacimiento" )]
      [  XmlElement( ElementName = "UsuarioFechaNacimiento"  , IsNullable=true )]
      public string gxTpr_Usuariofechanacimiento_Nullable
      {
         get {
            if ( gxTv_SdtFacturaMedida_Usuariofechanacimiento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFacturaMedida_Usuariofechanacimiento).value ;
         }

         set {
            gxTv_SdtFacturaMedida_Usuariofechanacimiento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFacturaMedida_Usuariofechanacimiento = DateTime.MinValue;
            else
               gxTv_SdtFacturaMedida_Usuariofechanacimiento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usuariofechanacimiento
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariofechanacimiento ;
         }

         set {
            gxTv_SdtFacturaMedida_Usuariofechanacimiento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariofechanacimiento = value;
            SetDirty("Usuariofechanacimiento");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariofechanacimiento_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariofechanacimiento_N = 1;
         gxTv_SdtFacturaMedida_Usuariofechanacimiento = (DateTime)(DateTime.MinValue);
         SetDirty("Usuariofechanacimiento");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariofechanacimiento_IsNull( )
      {
         return (gxTv_SdtFacturaMedida_Usuariofechanacimiento_N==1) ;
      }

      [  SoapElement( ElementName = "UsuarioCalleNum" )]
      [  XmlElement( ElementName = "UsuarioCalleNum"   )]
      public string gxTpr_Usuariocallenum
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariocallenum ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocallenum = value;
            SetDirty("Usuariocallenum");
         }

      }

      [  SoapElement( ElementName = "UsuarioColonia" )]
      [  XmlElement( ElementName = "UsuarioColonia"   )]
      public string gxTpr_Usuariocolonia
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariocolonia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocolonia = value;
            SetDirty("Usuariocolonia");
         }

      }

      [  SoapElement( ElementName = "UsuarioDelegacion" )]
      [  XmlElement( ElementName = "UsuarioDelegacion"   )]
      public string gxTpr_Usuariodelegacion
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariodelegacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariodelegacion = value;
            SetDirty("Usuariodelegacion");
         }

      }

      [  SoapElement( ElementName = "UsuarioCP" )]
      [  XmlElement( ElementName = "UsuarioCP"   )]
      public int gxTpr_Usuariocp
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariocp ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocp = value;
            SetDirty("Usuariocp");
         }

      }

      [  SoapElement( ElementName = "UsuarioCelular" )]
      [  XmlElement( ElementName = "UsuarioCelular"   )]
      public long gxTpr_Usuariocelular
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariocelular ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocelular = value;
            SetDirty("Usuariocelular");
         }

      }

      [  SoapElement( ElementName = "UsuarioTelefonoSucursal" )]
      [  XmlElement( ElementName = "UsuarioTelefonoSucursal"   )]
      public long gxTpr_Usuariotelefonosucursal
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariotelefonosucursal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariotelefonosucursal = value;
            SetDirty("Usuariotelefonosucursal");
         }

      }

      [  SoapElement( ElementName = "PaisID" )]
      [  XmlElement( ElementName = "PaisID"   )]
      public int gxTpr_Paisid
      {
         get {
            return gxTv_SdtFacturaMedida_Paisid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "EstadoID" )]
      [  XmlElement( ElementName = "EstadoID"   )]
      public int gxTpr_Estadoid
      {
         get {
            return gxTv_SdtFacturaMedida_Estadoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Estadoid = value;
            SetDirty("Estadoid");
         }

      }

      [  SoapElement( ElementName = "CiudadID" )]
      [  XmlElement( ElementName = "CiudadID"   )]
      public int gxTpr_Ciudadid
      {
         get {
            return gxTv_SdtFacturaMedida_Ciudadid ;
         }

         set {
            gxTv_SdtFacturaMedida_Ciudadid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Ciudadid = value;
            SetDirty("Ciudadid");
         }

      }

      public void gxTv_SdtFacturaMedida_Ciudadid_SetNull( )
      {
         gxTv_SdtFacturaMedida_Ciudadid_N = 1;
         gxTv_SdtFacturaMedida_Ciudadid = 0;
         SetDirty("Ciudadid");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Ciudadid_IsNull( )
      {
         return (gxTv_SdtFacturaMedida_Ciudadid_N==1) ;
      }

      [  SoapElement( ElementName = "UsuarioSucursal" )]
      [  XmlElement( ElementName = "UsuarioSucursal"   )]
      public string gxTpr_Usuariosucursal
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariosucursal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariosucursal = value;
            SetDirty("Usuariosucursal");
         }

      }

      [  SoapElement( ElementName = "UsuarioProducto" )]
      [  XmlElement( ElementName = "UsuarioProducto"   )]
      public string gxTpr_Usuarioproducto
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarioproducto ;
         }

         set {
            gxTv_SdtFacturaMedida_Usuarioproducto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioproducto = value;
            SetDirty("Usuarioproducto");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarioproducto_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarioproducto_N = 1;
         gxTv_SdtFacturaMedida_Usuarioproducto = "";
         SetDirty("Usuarioproducto");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarioproducto_IsNull( )
      {
         return (gxTv_SdtFacturaMedida_Usuarioproducto_N==1) ;
      }

      [  SoapElement( ElementName = "UsuarioRol" )]
      [  XmlElement( ElementName = "UsuarioRol"   )]
      public string gxTpr_Usuariorol
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariorol ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariorol = value;
            SetDirty("Usuariorol");
         }

      }

      [  SoapElement( ElementName = "UsuarioNoCuentaBROXEL" )]
      [  XmlElement( ElementName = "UsuarioNoCuentaBROXEL"   )]
      public string gxTpr_Usuarionocuentabroxel
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarionocuentabroxel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionocuentabroxel = value;
            SetDirty("Usuarionocuentabroxel");
         }

      }

      [  SoapElement( ElementName = "UsuarioReferenciaBROXEL" )]
      [  XmlElement( ElementName = "UsuarioReferenciaBROXEL"   )]
      public string gxTpr_Usuarioreferenciabroxel
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarioreferenciabroxel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioreferenciabroxel = value;
            SetDirty("Usuarioreferenciabroxel");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFacturaMedida_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFacturaMedida_Mode_SetNull( )
      {
         gxTv_SdtFacturaMedida_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFacturaMedida_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFacturaMedida_Initialized_SetNull( )
      {
         gxTv_SdtFacturaMedida_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaMedidaID_Z" )]
      [  XmlElement( ElementName = "FacturaMedidaID_Z"   )]
      public int gxTpr_Facturamedidaid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Facturamedidaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturamedidaid_Z = value;
            SetDirty("Facturamedidaid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Facturamedidaid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Facturamedidaid_Z = 0;
         SetDirty("Facturamedidaid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Facturamedidaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaID_Z" )]
      [  XmlElement( ElementName = "FacturaID_Z"   )]
      public int gxTpr_Facturaid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Facturaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturaid_Z = value;
            SetDirty("Facturaid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Facturaid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Facturaid_Z = 0;
         SetDirty("Facturaid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Facturaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionDescripcion_Z" )]
      [  XmlElement( ElementName = "PromocionDescripcion_Z"   )]
      public string gxTpr_Promociondescripcion_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Promociondescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promociondescripcion_Z = value;
            SetDirty("Promociondescripcion_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Promociondescripcion_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Promociondescripcion_Z = "";
         SetDirty("Promociondescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Promociondescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionBase_Z" )]
      [  XmlElement( ElementName = "PromocionBase_Z"   )]
      public string gxTpr_Promocionbase_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Promocionbase_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionbase_Z = value;
            SetDirty("Promocionbase_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Promocionbase_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Promocionbase_Z = "";
         SetDirty("Promocionbase_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Promocionbase_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionVigencia_Z" )]
      [  XmlElement( ElementName = "PromocionVigencia_Z"   )]
      public string gxTpr_Promocionvigencia_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Promocionvigencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionvigencia_Z = value;
            SetDirty("Promocionvigencia_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Promocionvigencia_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Promocionvigencia_Z = "";
         SetDirty("Promocionvigencia_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Promocionvigencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaNo_Z" )]
      [  XmlElement( ElementName = "FacturaNo_Z"   )]
      public string gxTpr_Facturano_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Facturano_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturano_Z = value;
            SetDirty("Facturano_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Facturano_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Facturano_Z = "";
         SetDirty("Facturano_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Facturano_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaFechaFactura_Z" )]
      [  XmlElement( ElementName = "FacturaFechaFactura_Z"  , IsNullable=true )]
      public string gxTpr_Facturafechafactura_Z_Nullable
      {
         get {
            if ( gxTv_SdtFacturaMedida_Facturafechafactura_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFacturaMedida_Facturafechafactura_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFacturaMedida_Facturafechafactura_Z = DateTime.MinValue;
            else
               gxTv_SdtFacturaMedida_Facturafechafactura_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Facturafechafactura_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Facturafechafactura_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturafechafactura_Z = value;
            SetDirty("Facturafechafactura_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Facturafechafactura_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Facturafechafactura_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Facturafechafactura_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Facturafechafactura_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaFechaRegistro_Z" )]
      [  XmlElement( ElementName = "FacturaFechaRegistro_Z"  , IsNullable=true )]
      public string gxTpr_Facturafecharegistro_Z_Nullable
      {
         get {
            if ( gxTv_SdtFacturaMedida_Facturafecharegistro_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFacturaMedida_Facturafecharegistro_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFacturaMedida_Facturafecharegistro_Z = DateTime.MinValue;
            else
               gxTv_SdtFacturaMedida_Facturafecharegistro_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Facturafecharegistro_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Facturafecharegistro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturafecharegistro_Z = value;
            SetDirty("Facturafecharegistro_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Facturafecharegistro_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Facturafecharegistro_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Facturafecharegistro_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Facturafecharegistro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioID_Z" )]
      [  XmlElement( ElementName = "UsuarioID_Z"   )]
      public int gxTpr_Usuarioid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioid_Z = value;
            SetDirty("Usuarioid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarioid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarioid_Z = 0;
         SetDirty("Usuarioid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioNombreCompleto_Z" )]
      [  XmlElement( ElementName = "UsuarioNombreCompleto_Z"   )]
      public string gxTpr_Usuarionombrecompleto_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z = value;
            SetDirty("Usuarionombrecompleto_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z = "";
         SetDirty("Usuarionombrecompleto_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioZona_Z" )]
      [  XmlElement( ElementName = "UsuarioZona_Z"   )]
      public string gxTpr_Usuariozona_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariozona_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariozona_Z = value;
            SetDirty("Usuariozona_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariozona_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariozona_Z = "";
         SetDirty("Usuariozona_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariozona_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoDescripcion_Z" )]
      [  XmlElement( ElementName = "EstadoDescripcion_Z"   )]
      public string gxTpr_Estadodescripcion_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Estadodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Estadodescripcion_Z = value;
            SetDirty("Estadodescripcion_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Estadodescripcion_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Estadodescripcion_Z = "";
         SetDirty("Estadodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Estadodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadDescripcion_Z" )]
      [  XmlElement( ElementName = "CiudadDescripcion_Z"   )]
      public string gxTpr_Ciudaddescripcion_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Ciudaddescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Ciudaddescripcion_Z = value;
            SetDirty("Ciudaddescripcion_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Ciudaddescripcion_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Ciudaddescripcion_Z = "";
         SetDirty("Ciudaddescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Ciudaddescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisDescripcion_Z" )]
      [  XmlElement( ElementName = "PaisDescripcion_Z"   )]
      public string gxTpr_Paisdescripcion_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Paisdescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Paisdescripcion_Z = value;
            SetDirty("Paisdescripcion_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Paisdescripcion_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Paisdescripcion_Z = "";
         SetDirty("Paisdescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Paisdescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioGenero_Z" )]
      [  XmlElement( ElementName = "UsuarioGenero_Z"   )]
      public string gxTpr_Usuariogenero_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariogenero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariogenero_Z = value;
            SetDirty("Usuariogenero_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariogenero_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariogenero_Z = "";
         SetDirty("Usuariogenero_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariogenero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaEstatus_Z" )]
      [  XmlElement( ElementName = "FacturaEstatus_Z"   )]
      public string gxTpr_Facturaestatus_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Facturaestatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturaestatus_Z = value;
            SetDirty("Facturaestatus_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Facturaestatus_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Facturaestatus_Z = "";
         SetDirty("Facturaestatus_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Facturaestatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MotivoRechazoID_Z" )]
      [  XmlElement( ElementName = "MotivoRechazoID_Z"   )]
      public int gxTpr_Motivorechazoid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Motivorechazoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Motivorechazoid_Z = value;
            SetDirty("Motivorechazoid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Motivorechazoid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Motivorechazoid_Z = 0;
         SetDirty("Motivorechazoid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Motivorechazoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MotivoRechazoDescripcion_Z" )]
      [  XmlElement( ElementName = "MotivoRechazoDescripcion_Z"   )]
      public string gxTpr_Motivorechazodescripcion_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z = value;
            SetDirty("Motivorechazodescripcion_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z = "";
         SetDirty("Motivorechazodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MotivoRechazoActivo_Z" )]
      [  XmlElement( ElementName = "MotivoRechazoActivo_Z"   )]
      public bool gxTpr_Motivorechazoactivo_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Motivorechazoactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Motivorechazoactivo_Z = value;
            SetDirty("Motivorechazoactivo_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Motivorechazoactivo_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Motivorechazoactivo_Z = false;
         SetDirty("Motivorechazoactivo_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Motivorechazoactivo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionID_Z" )]
      [  XmlElement( ElementName = "PromocionID_Z"   )]
      public int gxTpr_Promocionid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Promocionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionid_Z = value;
            SetDirty("Promocionid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Promocionid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Promocionid_Z = 0;
         SetDirty("Promocionid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Promocionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaID_Z" )]
      [  XmlElement( ElementName = "MedidaID_Z"   )]
      public int gxTpr_Medidaid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Medidaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidaid_Z = value;
            SetDirty("Medidaid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Medidaid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Medidaid_Z = 0;
         SetDirty("Medidaid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Medidaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaDescripcion_Z" )]
      [  XmlElement( ElementName = "MedidaDescripcion_Z"   )]
      public string gxTpr_Medidadescripcion_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Medidadescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidadescripcion_Z = value;
            SetDirty("Medidadescripcion_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Medidadescripcion_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Medidadescripcion_Z = "";
         SetDirty("Medidadescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Medidadescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaRin_Z" )]
      [  XmlElement( ElementName = "MedidaRin_Z"   )]
      public string gxTpr_Medidarin_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Medidarin_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidarin_Z = value;
            SetDirty("Medidarin_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Medidarin_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Medidarin_Z = "";
         SetDirty("Medidarin_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Medidarin_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaCodigo_Z" )]
      [  XmlElement( ElementName = "MedidaCodigo_Z"   )]
      public string gxTpr_Medidacodigo_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Medidacodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Medidacodigo_Z = value;
            SetDirty("Medidacodigo_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Medidacodigo_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Medidacodigo_Z = "";
         SetDirty("Medidacodigo_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Medidacodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloID_Z" )]
      [  XmlElement( ElementName = "ModeloID_Z"   )]
      public int gxTpr_Modeloid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Modeloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Modeloid_Z = value;
            SetDirty("Modeloid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Modeloid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Modeloid_Z = 0;
         SetDirty("Modeloid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Modeloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ModeloDescripcion_Z" )]
      [  XmlElement( ElementName = "ModeloDescripcion_Z"   )]
      public string gxTpr_Modelodescripcion_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Modelodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Modelodescripcion_Z = value;
            SetDirty("Modelodescripcion_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Modelodescripcion_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Modelodescripcion_Z = "";
         SetDirty("Modelodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Modelodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaMedidaCantidad_Z" )]
      [  XmlElement( ElementName = "FacturaMedidaCantidad_Z"   )]
      public short gxTpr_Facturamedidacantidad_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Facturamedidacantidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturamedidacantidad_Z = value;
            SetDirty("Facturamedidacantidad_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Facturamedidacantidad_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Facturamedidacantidad_Z = 0;
         SetDirty("Facturamedidacantidad_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Facturamedidacantidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaMedidaPrecio_Z" )]
      [  XmlElement( ElementName = "FacturaMedidaPrecio_Z"   )]
      public decimal gxTpr_Facturamedidaprecio_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Facturamedidaprecio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturamedidaprecio_Z = value;
            SetDirty("Facturamedidaprecio_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Facturamedidaprecio_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Facturamedidaprecio_Z = 0;
         SetDirty("Facturamedidaprecio_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Facturamedidaprecio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioNombre_Z" )]
      [  XmlElement( ElementName = "UsuarioNombre_Z"   )]
      public string gxTpr_Usuarionombre_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarionombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionombre_Z = value;
            SetDirty("Usuarionombre_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarionombre_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarionombre_Z = "";
         SetDirty("Usuarionombre_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarionombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioApellido_Z" )]
      [  XmlElement( ElementName = "UsuarioApellido_Z"   )]
      public string gxTpr_Usuarioapellido_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarioapellido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioapellido_Z = value;
            SetDirty("Usuarioapellido_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarioapellido_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarioapellido_Z = "";
         SetDirty("Usuarioapellido_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarioapellido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioCorreo_Z" )]
      [  XmlElement( ElementName = "UsuarioCorreo_Z"   )]
      public string gxTpr_Usuariocorreo_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariocorreo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocorreo_Z = value;
            SetDirty("Usuariocorreo_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariocorreo_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariocorreo_Z = "";
         SetDirty("Usuariocorreo_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariocorreo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioPass_Z" )]
      [  XmlElement( ElementName = "UsuarioPass_Z"   )]
      public string gxTpr_Usuariopass_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariopass_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariopass_Z = value;
            SetDirty("Usuariopass_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariopass_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariopass_Z = "";
         SetDirty("Usuariopass_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariopass_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioKey_Z" )]
      [  XmlElement( ElementName = "UsuarioKey_Z"   )]
      public string gxTpr_Usuariokey_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariokey_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariokey_Z = value;
            SetDirty("Usuariokey_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariokey_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariokey_Z = "";
         SetDirty("Usuariokey_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariokey_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PuestoID_Z" )]
      [  XmlElement( ElementName = "PuestoID_Z"   )]
      public int gxTpr_Puestoid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Puestoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Puestoid_Z = value;
            SetDirty("Puestoid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Puestoid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Puestoid_Z = 0;
         SetDirty("Puestoid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Puestoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PuestoDescripcion_Z" )]
      [  XmlElement( ElementName = "PuestoDescripcion_Z"   )]
      public string gxTpr_Puestodescripcion_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Puestodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Puestodescripcion_Z = value;
            SetDirty("Puestodescripcion_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Puestodescripcion_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Puestodescripcion_Z = "";
         SetDirty("Puestodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Puestodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioDirectoAsociado_Z" )]
      [  XmlElement( ElementName = "UsuarioDirectoAsociado_Z"   )]
      public string gxTpr_Usuariodirectoasociado_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z = value;
            SetDirty("Usuariodirectoasociado_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z = "";
         SetDirty("Usuariodirectoasociado_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioRazonSocialAsociado_Z" )]
      [  XmlElement( ElementName = "UsuarioRazonSocialAsociado_Z"   )]
      public string gxTpr_Usuariorazonsocialasociado_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z = value;
            SetDirty("Usuariorazonsocialasociado_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z = "";
         SetDirty("Usuariorazonsocialasociado_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioNombreComercial_Z" )]
      [  XmlElement( ElementName = "UsuarioNombreComercial_Z"   )]
      public string gxTpr_Usuarionombrecomercial_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z = value;
            SetDirty("Usuarionombrecomercial_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z = "";
         SetDirty("Usuarionombrecomercial_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioFechaNacimiento_Z" )]
      [  XmlElement( ElementName = "UsuarioFechaNacimiento_Z"  , IsNullable=true )]
      public string gxTpr_Usuariofechanacimiento_Z_Nullable
      {
         get {
            if ( gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z = DateTime.MinValue;
            else
               gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usuariofechanacimiento_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z = value;
            SetDirty("Usuariofechanacimiento_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Usuariofechanacimiento_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioCalleNum_Z" )]
      [  XmlElement( ElementName = "UsuarioCalleNum_Z"   )]
      public string gxTpr_Usuariocallenum_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariocallenum_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocallenum_Z = value;
            SetDirty("Usuariocallenum_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariocallenum_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariocallenum_Z = "";
         SetDirty("Usuariocallenum_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariocallenum_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioColonia_Z" )]
      [  XmlElement( ElementName = "UsuarioColonia_Z"   )]
      public string gxTpr_Usuariocolonia_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariocolonia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocolonia_Z = value;
            SetDirty("Usuariocolonia_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariocolonia_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariocolonia_Z = "";
         SetDirty("Usuariocolonia_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariocolonia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioDelegacion_Z" )]
      [  XmlElement( ElementName = "UsuarioDelegacion_Z"   )]
      public string gxTpr_Usuariodelegacion_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariodelegacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariodelegacion_Z = value;
            SetDirty("Usuariodelegacion_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariodelegacion_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariodelegacion_Z = "";
         SetDirty("Usuariodelegacion_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariodelegacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioCP_Z" )]
      [  XmlElement( ElementName = "UsuarioCP_Z"   )]
      public int gxTpr_Usuariocp_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariocp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocp_Z = value;
            SetDirty("Usuariocp_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariocp_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariocp_Z = 0;
         SetDirty("Usuariocp_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariocp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioCelular_Z" )]
      [  XmlElement( ElementName = "UsuarioCelular_Z"   )]
      public long gxTpr_Usuariocelular_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariocelular_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariocelular_Z = value;
            SetDirty("Usuariocelular_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariocelular_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariocelular_Z = 0;
         SetDirty("Usuariocelular_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariocelular_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioTelefonoSucursal_Z" )]
      [  XmlElement( ElementName = "UsuarioTelefonoSucursal_Z"   )]
      public long gxTpr_Usuariotelefonosucursal_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariotelefonosucursal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariotelefonosucursal_Z = value;
            SetDirty("Usuariotelefonosucursal_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariotelefonosucursal_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariotelefonosucursal_Z = 0;
         SetDirty("Usuariotelefonosucursal_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariotelefonosucursal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisID_Z" )]
      [  XmlElement( ElementName = "PaisID_Z"   )]
      public int gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Paisid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Paisid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoID_Z" )]
      [  XmlElement( ElementName = "EstadoID_Z"   )]
      public int gxTpr_Estadoid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Estadoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Estadoid_Z = value;
            SetDirty("Estadoid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Estadoid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Estadoid_Z = 0;
         SetDirty("Estadoid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Estadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadID_Z" )]
      [  XmlElement( ElementName = "CiudadID_Z"   )]
      public int gxTpr_Ciudadid_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Ciudadid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Ciudadid_Z = value;
            SetDirty("Ciudadid_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Ciudadid_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Ciudadid_Z = 0;
         SetDirty("Ciudadid_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Ciudadid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioSucursal_Z" )]
      [  XmlElement( ElementName = "UsuarioSucursal_Z"   )]
      public string gxTpr_Usuariosucursal_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariosucursal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariosucursal_Z = value;
            SetDirty("Usuariosucursal_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariosucursal_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariosucursal_Z = "";
         SetDirty("Usuariosucursal_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariosucursal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioProducto_Z" )]
      [  XmlElement( ElementName = "UsuarioProducto_Z"   )]
      public string gxTpr_Usuarioproducto_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarioproducto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioproducto_Z = value;
            SetDirty("Usuarioproducto_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarioproducto_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarioproducto_Z = "";
         SetDirty("Usuarioproducto_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarioproducto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioRol_Z" )]
      [  XmlElement( ElementName = "UsuarioRol_Z"   )]
      public string gxTpr_Usuariorol_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariorol_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariorol_Z = value;
            SetDirty("Usuariorol_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariorol_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariorol_Z = "";
         SetDirty("Usuariorol_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariorol_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioNoCuentaBROXEL_Z" )]
      [  XmlElement( ElementName = "UsuarioNoCuentaBROXEL_Z"   )]
      public string gxTpr_Usuarionocuentabroxel_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z = value;
            SetDirty("Usuarionocuentabroxel_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z = "";
         SetDirty("Usuarionocuentabroxel_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioReferenciaBROXEL_Z" )]
      [  XmlElement( ElementName = "UsuarioReferenciaBROXEL_Z"   )]
      public string gxTpr_Usuarioreferenciabroxel_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z = value;
            SetDirty("Usuarioreferenciabroxel_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z = "";
         SetDirty("Usuarioreferenciabroxel_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PromocionArte_GXI_Z" )]
      [  XmlElement( ElementName = "PromocionArte_GXI_Z"   )]
      public string gxTpr_Promocionarte_gxi_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Promocionarte_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Promocionarte_gxi_Z = value;
            SetDirty("Promocionarte_gxi_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Promocionarte_gxi_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Promocionarte_gxi_Z = "";
         SetDirty("Promocionarte_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Promocionarte_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FacturaPDF_GXI_Z" )]
      [  XmlElement( ElementName = "FacturaPDF_GXI_Z"   )]
      public string gxTpr_Facturapdf_gxi_Z
      {
         get {
            return gxTv_SdtFacturaMedida_Facturapdf_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Facturapdf_gxi_Z = value;
            SetDirty("Facturapdf_gxi_Z");
         }

      }

      public void gxTv_SdtFacturaMedida_Facturapdf_gxi_Z_SetNull( )
      {
         gxTv_SdtFacturaMedida_Facturapdf_gxi_Z = "";
         SetDirty("Facturapdf_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Facturapdf_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PuestoID_N" )]
      [  XmlElement( ElementName = "PuestoID_N"   )]
      public short gxTpr_Puestoid_N
      {
         get {
            return gxTv_SdtFacturaMedida_Puestoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Puestoid_N = value;
            SetDirty("Puestoid_N");
         }

      }

      public void gxTv_SdtFacturaMedida_Puestoid_N_SetNull( )
      {
         gxTv_SdtFacturaMedida_Puestoid_N = 0;
         SetDirty("Puestoid_N");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Puestoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioDirectoAsociado_N" )]
      [  XmlElement( ElementName = "UsuarioDirectoAsociado_N"   )]
      public short gxTpr_Usuariodirectoasociado_N
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariodirectoasociado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariodirectoasociado_N = value;
            SetDirty("Usuariodirectoasociado_N");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariodirectoasociado_N_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariodirectoasociado_N = 0;
         SetDirty("Usuariodirectoasociado_N");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariodirectoasociado_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioFechaNacimiento_N" )]
      [  XmlElement( ElementName = "UsuarioFechaNacimiento_N"   )]
      public short gxTpr_Usuariofechanacimiento_N
      {
         get {
            return gxTv_SdtFacturaMedida_Usuariofechanacimiento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuariofechanacimiento_N = value;
            SetDirty("Usuariofechanacimiento_N");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuariofechanacimiento_N_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuariofechanacimiento_N = 0;
         SetDirty("Usuariofechanacimiento_N");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuariofechanacimiento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadID_N" )]
      [  XmlElement( ElementName = "CiudadID_N"   )]
      public short gxTpr_Ciudadid_N
      {
         get {
            return gxTv_SdtFacturaMedida_Ciudadid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Ciudadid_N = value;
            SetDirty("Ciudadid_N");
         }

      }

      public void gxTv_SdtFacturaMedida_Ciudadid_N_SetNull( )
      {
         gxTv_SdtFacturaMedida_Ciudadid_N = 0;
         SetDirty("Ciudadid_N");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Ciudadid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioProducto_N" )]
      [  XmlElement( ElementName = "UsuarioProducto_N"   )]
      public short gxTpr_Usuarioproducto_N
      {
         get {
            return gxTv_SdtFacturaMedida_Usuarioproducto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFacturaMedida_Usuarioproducto_N = value;
            SetDirty("Usuarioproducto_N");
         }

      }

      public void gxTv_SdtFacturaMedida_Usuarioproducto_N_SetNull( )
      {
         gxTv_SdtFacturaMedida_Usuarioproducto_N = 0;
         SetDirty("Usuarioproducto_N");
         return  ;
      }

      public bool gxTv_SdtFacturaMedida_Usuarioproducto_N_IsNull( )
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
         gxTv_SdtFacturaMedida_Promociondescripcion = "";
         gxTv_SdtFacturaMedida_Promocionbase = "";
         gxTv_SdtFacturaMedida_Promocionarte = "";
         gxTv_SdtFacturaMedida_Promocionarte_gxi = "";
         gxTv_SdtFacturaMedida_Promocionvigencia = "";
         gxTv_SdtFacturaMedida_Facturano = "";
         gxTv_SdtFacturaMedida_Facturafechafactura = DateTime.MinValue;
         gxTv_SdtFacturaMedida_Facturafecharegistro = DateTime.MinValue;
         gxTv_SdtFacturaMedida_Usuarionombrecompleto = "";
         gxTv_SdtFacturaMedida_Usuariozona = "";
         gxTv_SdtFacturaMedida_Estadodescripcion = "";
         gxTv_SdtFacturaMedida_Ciudaddescripcion = "";
         gxTv_SdtFacturaMedida_Paisdescripcion = "";
         gxTv_SdtFacturaMedida_Usuariogenero = "";
         gxTv_SdtFacturaMedida_Facturapdf = "";
         gxTv_SdtFacturaMedida_Facturapdf_gxi = "";
         gxTv_SdtFacturaMedida_Facturaestatus = "En Proceso";
         gxTv_SdtFacturaMedida_Motivorechazodescripcion = "";
         gxTv_SdtFacturaMedida_Medidadescripcion = "";
         gxTv_SdtFacturaMedida_Medidarin = "";
         gxTv_SdtFacturaMedida_Medidacodigo = "";
         gxTv_SdtFacturaMedida_Modelodescripcion = "";
         gxTv_SdtFacturaMedida_Usuarionombre = "";
         gxTv_SdtFacturaMedida_Usuarioapellido = "";
         gxTv_SdtFacturaMedida_Usuariocorreo = "";
         gxTv_SdtFacturaMedida_Usuariopass = "";
         gxTv_SdtFacturaMedida_Usuariokey = "";
         gxTv_SdtFacturaMedida_Puestodescripcion = "";
         gxTv_SdtFacturaMedida_Usuariodirectoasociado = "";
         gxTv_SdtFacturaMedida_Usuariorazonsocialasociado = "";
         gxTv_SdtFacturaMedida_Usuarionombrecomercial = "";
         gxTv_SdtFacturaMedida_Usuariofechanacimiento = DateTime.MinValue;
         gxTv_SdtFacturaMedida_Usuariocallenum = "";
         gxTv_SdtFacturaMedida_Usuariocolonia = "";
         gxTv_SdtFacturaMedida_Usuariodelegacion = "";
         gxTv_SdtFacturaMedida_Usuariosucursal = "";
         gxTv_SdtFacturaMedida_Usuarioproducto = "";
         gxTv_SdtFacturaMedida_Usuariorol = "";
         gxTv_SdtFacturaMedida_Usuarionocuentabroxel = "";
         gxTv_SdtFacturaMedida_Usuarioreferenciabroxel = "";
         gxTv_SdtFacturaMedida_Mode = "";
         gxTv_SdtFacturaMedida_Promociondescripcion_Z = "";
         gxTv_SdtFacturaMedida_Promocionbase_Z = "";
         gxTv_SdtFacturaMedida_Promocionvigencia_Z = "";
         gxTv_SdtFacturaMedida_Facturano_Z = "";
         gxTv_SdtFacturaMedida_Facturafechafactura_Z = DateTime.MinValue;
         gxTv_SdtFacturaMedida_Facturafecharegistro_Z = DateTime.MinValue;
         gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z = "";
         gxTv_SdtFacturaMedida_Usuariozona_Z = "";
         gxTv_SdtFacturaMedida_Estadodescripcion_Z = "";
         gxTv_SdtFacturaMedida_Ciudaddescripcion_Z = "";
         gxTv_SdtFacturaMedida_Paisdescripcion_Z = "";
         gxTv_SdtFacturaMedida_Usuariogenero_Z = "";
         gxTv_SdtFacturaMedida_Facturaestatus_Z = "";
         gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z = "";
         gxTv_SdtFacturaMedida_Medidadescripcion_Z = "";
         gxTv_SdtFacturaMedida_Medidarin_Z = "";
         gxTv_SdtFacturaMedida_Medidacodigo_Z = "";
         gxTv_SdtFacturaMedida_Modelodescripcion_Z = "";
         gxTv_SdtFacturaMedida_Usuarionombre_Z = "";
         gxTv_SdtFacturaMedida_Usuarioapellido_Z = "";
         gxTv_SdtFacturaMedida_Usuariocorreo_Z = "";
         gxTv_SdtFacturaMedida_Usuariopass_Z = "";
         gxTv_SdtFacturaMedida_Usuariokey_Z = "";
         gxTv_SdtFacturaMedida_Puestodescripcion_Z = "";
         gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z = "";
         gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z = "";
         gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z = "";
         gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z = DateTime.MinValue;
         gxTv_SdtFacturaMedida_Usuariocallenum_Z = "";
         gxTv_SdtFacturaMedida_Usuariocolonia_Z = "";
         gxTv_SdtFacturaMedida_Usuariodelegacion_Z = "";
         gxTv_SdtFacturaMedida_Usuariosucursal_Z = "";
         gxTv_SdtFacturaMedida_Usuarioproducto_Z = "";
         gxTv_SdtFacturaMedida_Usuariorol_Z = "";
         gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z = "";
         gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z = "";
         gxTv_SdtFacturaMedida_Promocionarte_gxi_Z = "";
         gxTv_SdtFacturaMedida_Facturapdf_gxi_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "facturamedida", "GeneXus.Programs.facturamedida_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtFacturaMedida_Facturamedidacantidad ;
      private short gxTv_SdtFacturaMedida_Initialized ;
      private short gxTv_SdtFacturaMedida_Facturamedidacantidad_Z ;
      private short gxTv_SdtFacturaMedida_Puestoid_N ;
      private short gxTv_SdtFacturaMedida_Usuariodirectoasociado_N ;
      private short gxTv_SdtFacturaMedida_Usuariofechanacimiento_N ;
      private short gxTv_SdtFacturaMedida_Ciudadid_N ;
      private short gxTv_SdtFacturaMedida_Usuarioproducto_N ;
      private int gxTv_SdtFacturaMedida_Facturamedidaid ;
      private int gxTv_SdtFacturaMedida_Facturaid ;
      private int gxTv_SdtFacturaMedida_Usuarioid ;
      private int gxTv_SdtFacturaMedida_Motivorechazoid ;
      private int gxTv_SdtFacturaMedida_Promocionid ;
      private int gxTv_SdtFacturaMedida_Medidaid ;
      private int gxTv_SdtFacturaMedida_Modeloid ;
      private int gxTv_SdtFacturaMedida_Puestoid ;
      private int gxTv_SdtFacturaMedida_Usuariocp ;
      private int gxTv_SdtFacturaMedida_Paisid ;
      private int gxTv_SdtFacturaMedida_Estadoid ;
      private int gxTv_SdtFacturaMedida_Ciudadid ;
      private int gxTv_SdtFacturaMedida_Facturamedidaid_Z ;
      private int gxTv_SdtFacturaMedida_Facturaid_Z ;
      private int gxTv_SdtFacturaMedida_Usuarioid_Z ;
      private int gxTv_SdtFacturaMedida_Motivorechazoid_Z ;
      private int gxTv_SdtFacturaMedida_Promocionid_Z ;
      private int gxTv_SdtFacturaMedida_Medidaid_Z ;
      private int gxTv_SdtFacturaMedida_Modeloid_Z ;
      private int gxTv_SdtFacturaMedida_Puestoid_Z ;
      private int gxTv_SdtFacturaMedida_Usuariocp_Z ;
      private int gxTv_SdtFacturaMedida_Paisid_Z ;
      private int gxTv_SdtFacturaMedida_Estadoid_Z ;
      private int gxTv_SdtFacturaMedida_Ciudadid_Z ;
      private long gxTv_SdtFacturaMedida_Usuariocelular ;
      private long gxTv_SdtFacturaMedida_Usuariotelefonosucursal ;
      private long gxTv_SdtFacturaMedida_Usuariocelular_Z ;
      private long gxTv_SdtFacturaMedida_Usuariotelefonosucursal_Z ;
      private decimal gxTv_SdtFacturaMedida_Facturamedidaprecio ;
      private decimal gxTv_SdtFacturaMedida_Facturamedidaprecio_Z ;
      private string gxTv_SdtFacturaMedida_Facturano ;
      private string gxTv_SdtFacturaMedida_Usuariozona ;
      private string gxTv_SdtFacturaMedida_Usuariogenero ;
      private string gxTv_SdtFacturaMedida_Facturaestatus ;
      private string gxTv_SdtFacturaMedida_Medidarin ;
      private string gxTv_SdtFacturaMedida_Medidacodigo ;
      private string gxTv_SdtFacturaMedida_Usuarionombre ;
      private string gxTv_SdtFacturaMedida_Usuarioapellido ;
      private string gxTv_SdtFacturaMedida_Usuariodirectoasociado ;
      private string gxTv_SdtFacturaMedida_Usuariocallenum ;
      private string gxTv_SdtFacturaMedida_Usuariocolonia ;
      private string gxTv_SdtFacturaMedida_Usuariodelegacion ;
      private string gxTv_SdtFacturaMedida_Usuariosucursal ;
      private string gxTv_SdtFacturaMedida_Usuariorol ;
      private string gxTv_SdtFacturaMedida_Usuarionocuentabroxel ;
      private string gxTv_SdtFacturaMedida_Usuarioreferenciabroxel ;
      private string gxTv_SdtFacturaMedida_Mode ;
      private string gxTv_SdtFacturaMedida_Facturano_Z ;
      private string gxTv_SdtFacturaMedida_Usuariozona_Z ;
      private string gxTv_SdtFacturaMedida_Usuariogenero_Z ;
      private string gxTv_SdtFacturaMedida_Facturaestatus_Z ;
      private string gxTv_SdtFacturaMedida_Medidarin_Z ;
      private string gxTv_SdtFacturaMedida_Medidacodigo_Z ;
      private string gxTv_SdtFacturaMedida_Usuarionombre_Z ;
      private string gxTv_SdtFacturaMedida_Usuarioapellido_Z ;
      private string gxTv_SdtFacturaMedida_Usuariodirectoasociado_Z ;
      private string gxTv_SdtFacturaMedida_Usuariocallenum_Z ;
      private string gxTv_SdtFacturaMedida_Usuariocolonia_Z ;
      private string gxTv_SdtFacturaMedida_Usuariodelegacion_Z ;
      private string gxTv_SdtFacturaMedida_Usuariosucursal_Z ;
      private string gxTv_SdtFacturaMedida_Usuariorol_Z ;
      private string gxTv_SdtFacturaMedida_Usuarionocuentabroxel_Z ;
      private string gxTv_SdtFacturaMedida_Usuarioreferenciabroxel_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtFacturaMedida_Facturafechafactura ;
      private DateTime gxTv_SdtFacturaMedida_Facturafecharegistro ;
      private DateTime gxTv_SdtFacturaMedida_Usuariofechanacimiento ;
      private DateTime gxTv_SdtFacturaMedida_Facturafechafactura_Z ;
      private DateTime gxTv_SdtFacturaMedida_Facturafecharegistro_Z ;
      private DateTime gxTv_SdtFacturaMedida_Usuariofechanacimiento_Z ;
      private bool gxTv_SdtFacturaMedida_Motivorechazoactivo ;
      private bool gxTv_SdtFacturaMedida_Motivorechazoactivo_Z ;
      private string gxTv_SdtFacturaMedida_Promociondescripcion ;
      private string gxTv_SdtFacturaMedida_Promocionbase ;
      private string gxTv_SdtFacturaMedida_Promocionarte_gxi ;
      private string gxTv_SdtFacturaMedida_Promocionvigencia ;
      private string gxTv_SdtFacturaMedida_Usuarionombrecompleto ;
      private string gxTv_SdtFacturaMedida_Estadodescripcion ;
      private string gxTv_SdtFacturaMedida_Ciudaddescripcion ;
      private string gxTv_SdtFacturaMedida_Paisdescripcion ;
      private string gxTv_SdtFacturaMedida_Facturapdf_gxi ;
      private string gxTv_SdtFacturaMedida_Motivorechazodescripcion ;
      private string gxTv_SdtFacturaMedida_Medidadescripcion ;
      private string gxTv_SdtFacturaMedida_Modelodescripcion ;
      private string gxTv_SdtFacturaMedida_Usuariocorreo ;
      private string gxTv_SdtFacturaMedida_Usuariopass ;
      private string gxTv_SdtFacturaMedida_Usuariokey ;
      private string gxTv_SdtFacturaMedida_Puestodescripcion ;
      private string gxTv_SdtFacturaMedida_Usuariorazonsocialasociado ;
      private string gxTv_SdtFacturaMedida_Usuarionombrecomercial ;
      private string gxTv_SdtFacturaMedida_Usuarioproducto ;
      private string gxTv_SdtFacturaMedida_Promociondescripcion_Z ;
      private string gxTv_SdtFacturaMedida_Promocionbase_Z ;
      private string gxTv_SdtFacturaMedida_Promocionvigencia_Z ;
      private string gxTv_SdtFacturaMedida_Usuarionombrecompleto_Z ;
      private string gxTv_SdtFacturaMedida_Estadodescripcion_Z ;
      private string gxTv_SdtFacturaMedida_Ciudaddescripcion_Z ;
      private string gxTv_SdtFacturaMedida_Paisdescripcion_Z ;
      private string gxTv_SdtFacturaMedida_Motivorechazodescripcion_Z ;
      private string gxTv_SdtFacturaMedida_Medidadescripcion_Z ;
      private string gxTv_SdtFacturaMedida_Modelodescripcion_Z ;
      private string gxTv_SdtFacturaMedida_Usuariocorreo_Z ;
      private string gxTv_SdtFacturaMedida_Usuariopass_Z ;
      private string gxTv_SdtFacturaMedida_Usuariokey_Z ;
      private string gxTv_SdtFacturaMedida_Puestodescripcion_Z ;
      private string gxTv_SdtFacturaMedida_Usuariorazonsocialasociado_Z ;
      private string gxTv_SdtFacturaMedida_Usuarionombrecomercial_Z ;
      private string gxTv_SdtFacturaMedida_Usuarioproducto_Z ;
      private string gxTv_SdtFacturaMedida_Promocionarte_gxi_Z ;
      private string gxTv_SdtFacturaMedida_Facturapdf_gxi_Z ;
      private string gxTv_SdtFacturaMedida_Promocionarte ;
      private string gxTv_SdtFacturaMedida_Facturapdf ;
   }

   [DataContract(Name = @"FacturaMedida", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtFacturaMedida_RESTInterface : GxGenericCollectionItem<SdtFacturaMedida>
   {
      public SdtFacturaMedida_RESTInterface( ) : base()
      {
      }

      public SdtFacturaMedida_RESTInterface( SdtFacturaMedida psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FacturaMedidaID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Facturamedidaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Facturamedidaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Facturamedidaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "FacturaID" , Order = 1 )]
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

      [DataMember( Name = "PromocionID" , Order = 21 )]
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

      [DataMember( Name = "MedidaID" , Order = 22 )]
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

      [DataMember( Name = "MedidaDescripcion" , Order = 23 )]
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

      [DataMember( Name = "MedidaRin" , Order = 24 )]
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

      [DataMember( Name = "MedidaCodigo" , Order = 25 )]
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

      [DataMember( Name = "ModeloID" , Order = 26 )]
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

      [DataMember( Name = "ModeloDescripcion" , Order = 27 )]
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

      [DataMember( Name = "FacturaMedidaCantidad" , Order = 28 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Facturamedidacantidad
      {
         get {
            return sdt.gxTpr_Facturamedidacantidad ;
         }

         set {
            sdt.gxTpr_Facturamedidacantidad = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "FacturaMedidaPrecio" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Facturamedidaprecio
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Facturamedidaprecio, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Facturamedidaprecio = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "UsuarioNombre" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Usuarionombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuarionombre) ;
         }

         set {
            sdt.gxTpr_Usuarionombre = value;
         }

      }

      [DataMember( Name = "UsuarioApellido" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Usuarioapellido
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuarioapellido) ;
         }

         set {
            sdt.gxTpr_Usuarioapellido = value;
         }

      }

      [DataMember( Name = "UsuarioCorreo" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Usuariocorreo
      {
         get {
            return sdt.gxTpr_Usuariocorreo ;
         }

         set {
            sdt.gxTpr_Usuariocorreo = value;
         }

      }

      [DataMember( Name = "UsuarioPass" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Usuariopass
      {
         get {
            return sdt.gxTpr_Usuariopass ;
         }

         set {
            sdt.gxTpr_Usuariopass = value;
         }

      }

      [DataMember( Name = "UsuarioKey" , Order = 34 )]
      [GxSeudo()]
      public string gxTpr_Usuariokey
      {
         get {
            return sdt.gxTpr_Usuariokey ;
         }

         set {
            sdt.gxTpr_Usuariokey = value;
         }

      }

      [DataMember( Name = "PuestoID" , Order = 35 )]
      [GxSeudo()]
      public string gxTpr_Puestoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Puestoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Puestoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PuestoDescripcion" , Order = 36 )]
      [GxSeudo()]
      public string gxTpr_Puestodescripcion
      {
         get {
            return sdt.gxTpr_Puestodescripcion ;
         }

         set {
            sdt.gxTpr_Puestodescripcion = value;
         }

      }

      [DataMember( Name = "UsuarioDirectoAsociado" , Order = 37 )]
      [GxSeudo()]
      public string gxTpr_Usuariodirectoasociado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariodirectoasociado) ;
         }

         set {
            sdt.gxTpr_Usuariodirectoasociado = value;
         }

      }

      [DataMember( Name = "UsuarioRazonSocialAsociado" , Order = 38 )]
      [GxSeudo()]
      public string gxTpr_Usuariorazonsocialasociado
      {
         get {
            return sdt.gxTpr_Usuariorazonsocialasociado ;
         }

         set {
            sdt.gxTpr_Usuariorazonsocialasociado = value;
         }

      }

      [DataMember( Name = "UsuarioNombreComercial" , Order = 39 )]
      [GxSeudo()]
      public string gxTpr_Usuarionombrecomercial
      {
         get {
            return sdt.gxTpr_Usuarionombrecomercial ;
         }

         set {
            sdt.gxTpr_Usuarionombrecomercial = value;
         }

      }

      [DataMember( Name = "UsuarioFechaNacimiento" , Order = 40 )]
      [GxSeudo()]
      public string gxTpr_Usuariofechanacimiento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usuariofechanacimiento) ;
         }

         set {
            sdt.gxTpr_Usuariofechanacimiento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UsuarioCalleNum" , Order = 41 )]
      [GxSeudo()]
      public string gxTpr_Usuariocallenum
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariocallenum) ;
         }

         set {
            sdt.gxTpr_Usuariocallenum = value;
         }

      }

      [DataMember( Name = "UsuarioColonia" , Order = 42 )]
      [GxSeudo()]
      public string gxTpr_Usuariocolonia
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariocolonia) ;
         }

         set {
            sdt.gxTpr_Usuariocolonia = value;
         }

      }

      [DataMember( Name = "UsuarioDelegacion" , Order = 43 )]
      [GxSeudo()]
      public string gxTpr_Usuariodelegacion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariodelegacion) ;
         }

         set {
            sdt.gxTpr_Usuariodelegacion = value;
         }

      }

      [DataMember( Name = "UsuarioCP" , Order = 44 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Usuariocp
      {
         get {
            return sdt.gxTpr_Usuariocp ;
         }

         set {
            sdt.gxTpr_Usuariocp = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuarioCelular" , Order = 45 )]
      [GxSeudo()]
      public string gxTpr_Usuariocelular
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Usuariocelular), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Usuariocelular = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "UsuarioTelefonoSucursal" , Order = 46 )]
      [GxSeudo()]
      public string gxTpr_Usuariotelefonosucursal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Usuariotelefonosucursal), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Usuariotelefonosucursal = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PaisID" , Order = 47 )]
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

      [DataMember( Name = "EstadoID" , Order = 48 )]
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

      [DataMember( Name = "CiudadID" , Order = 49 )]
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

      [DataMember( Name = "UsuarioSucursal" , Order = 50 )]
      [GxSeudo()]
      public string gxTpr_Usuariosucursal
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosucursal) ;
         }

         set {
            sdt.gxTpr_Usuariosucursal = value;
         }

      }

      [DataMember( Name = "UsuarioProducto" , Order = 51 )]
      [GxSeudo()]
      public string gxTpr_Usuarioproducto
      {
         get {
            return sdt.gxTpr_Usuarioproducto ;
         }

         set {
            sdt.gxTpr_Usuarioproducto = value;
         }

      }

      [DataMember( Name = "UsuarioRol" , Order = 52 )]
      [GxSeudo()]
      public string gxTpr_Usuariorol
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariorol) ;
         }

         set {
            sdt.gxTpr_Usuariorol = value;
         }

      }

      [DataMember( Name = "UsuarioNoCuentaBROXEL" , Order = 53 )]
      [GxSeudo()]
      public string gxTpr_Usuarionocuentabroxel
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuarionocuentabroxel) ;
         }

         set {
            sdt.gxTpr_Usuarionocuentabroxel = value;
         }

      }

      [DataMember( Name = "UsuarioReferenciaBROXEL" , Order = 54 )]
      [GxSeudo()]
      public string gxTpr_Usuarioreferenciabroxel
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuarioreferenciabroxel) ;
         }

         set {
            sdt.gxTpr_Usuarioreferenciabroxel = value;
         }

      }

      public SdtFacturaMedida sdt
      {
         get {
            return (SdtFacturaMedida)Sdt ;
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
            sdt = new SdtFacturaMedida() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 55 )]
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

   [DataContract(Name = @"FacturaMedida", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtFacturaMedida_RESTLInterface : GxGenericCollectionItem<SdtFacturaMedida>
   {
      public SdtFacturaMedida_RESTLInterface( ) : base()
      {
      }

      public SdtFacturaMedida_RESTLInterface( SdtFacturaMedida psdt ) : base(psdt)
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

      public SdtFacturaMedida sdt
      {
         get {
            return (SdtFacturaMedida)Sdt ;
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
            sdt = new SdtFacturaMedida() ;
         }
      }

   }

}
