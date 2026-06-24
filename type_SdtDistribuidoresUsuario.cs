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
   [XmlRoot(ElementName = "DistribuidoresUsuario" )]
   [XmlType(TypeName =  "DistribuidoresUsuario" , Namespace = "Premios" )]
   [Serializable]
   public class SdtDistribuidoresUsuario : GxSilentTrnSdt
   {
      public SdtDistribuidoresUsuario( )
      {
      }

      public SdtDistribuidoresUsuario( IGxContext context )
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

      public void Load( int AV81DistribuidoresUsuarioID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV81DistribuidoresUsuarioID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DistribuidoresUsuarioID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DistribuidoresUsuario");
         metadata.Set("BT", "DistribuidoresUsuario");
         metadata.Set("PK", "[ \"DistribuidoresUsuarioID\" ]");
         metadata.Set("PKAssigned", "[ \"DistribuidoresUsuarioID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DistribuidorID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"UsuarioID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Distribuidoresusuarioid_Z");
         state.Add("gxTpr_Usuarioid_Z");
         state.Add("gxTpr_Usuarionombre_Z");
         state.Add("gxTpr_Usuarioapellido_Z");
         state.Add("gxTpr_Usuarionombrecompleto_Z");
         state.Add("gxTpr_Usuariocorreo_Z");
         state.Add("gxTpr_Usuariopass_Z");
         state.Add("gxTpr_Usuariokey_Z");
         state.Add("gxTpr_Puestoid_Z");
         state.Add("gxTpr_Puestodescripcion_Z");
         state.Add("gxTpr_Usuariogenero_Z");
         state.Add("gxTpr_Usuariodirectoasociado_Z");
         state.Add("gxTpr_Usuariorazonsocialasociado_Z");
         state.Add("gxTpr_Usuarionombrecomercial_Z");
         state.Add("gxTpr_Usuariofechanacimiento_Z_Nullable");
         state.Add("gxTpr_Usuariocallenum_Z");
         state.Add("gxTpr_Usuariocolonia_Z");
         state.Add("gxTpr_Usuariodelegacion_Z");
         state.Add("gxTpr_Usuariocp_Z");
         state.Add("gxTpr_Usuariozona_Z");
         state.Add("gxTpr_Usuariocelular_Z");
         state.Add("gxTpr_Usuariotelefonosucursal_Z");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisdescripcion_Z");
         state.Add("gxTpr_Estadoid_Z");
         state.Add("gxTpr_Estadodescripcion_Z");
         state.Add("gxTpr_Ciudadid_Z");
         state.Add("gxTpr_Ciudaddescripcion_Z");
         state.Add("gxTpr_Usuariosucursal_Z");
         state.Add("gxTpr_Usuarioproducto_Z");
         state.Add("gxTpr_Usuariorol_Z");
         state.Add("gxTpr_Distribuidorid_Z");
         state.Add("gxTpr_Distribuidordescripcion_Z");
         state.Add("gxTpr_Distribuidorrfc_Z");
         state.Add("gxTpr_Puestoid_N");
         state.Add("gxTpr_Usuariodirectoasociado_N");
         state.Add("gxTpr_Usuariofechanacimiento_N");
         state.Add("gxTpr_Ciudadid_N");
         state.Add("gxTpr_Usuarioproducto_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDistribuidoresUsuario sdt;
         sdt = (SdtDistribuidoresUsuario)(source);
         gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid ;
         gxTv_SdtDistribuidoresUsuario_Usuarioid = sdt.gxTv_SdtDistribuidoresUsuario_Usuarioid ;
         gxTv_SdtDistribuidoresUsuario_Usuarionombre = sdt.gxTv_SdtDistribuidoresUsuario_Usuarionombre ;
         gxTv_SdtDistribuidoresUsuario_Usuarioapellido = sdt.gxTv_SdtDistribuidoresUsuario_Usuarioapellido ;
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto = sdt.gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto ;
         gxTv_SdtDistribuidoresUsuario_Usuariocorreo = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocorreo ;
         gxTv_SdtDistribuidoresUsuario_Usuariopass = sdt.gxTv_SdtDistribuidoresUsuario_Usuariopass ;
         gxTv_SdtDistribuidoresUsuario_Usuariokey = sdt.gxTv_SdtDistribuidoresUsuario_Usuariokey ;
         gxTv_SdtDistribuidoresUsuario_Puestoid = sdt.gxTv_SdtDistribuidoresUsuario_Puestoid ;
         gxTv_SdtDistribuidoresUsuario_Puestodescripcion = sdt.gxTv_SdtDistribuidoresUsuario_Puestodescripcion ;
         gxTv_SdtDistribuidoresUsuario_Usuariogenero = sdt.gxTv_SdtDistribuidoresUsuario_Usuariogenero ;
         gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado = sdt.gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado ;
         gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado = sdt.gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado ;
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial = sdt.gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial ;
         gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento = sdt.gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento ;
         gxTv_SdtDistribuidoresUsuario_Usuariocallenum = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocallenum ;
         gxTv_SdtDistribuidoresUsuario_Usuariocolonia = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocolonia ;
         gxTv_SdtDistribuidoresUsuario_Usuariodelegacion = sdt.gxTv_SdtDistribuidoresUsuario_Usuariodelegacion ;
         gxTv_SdtDistribuidoresUsuario_Usuariocp = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocp ;
         gxTv_SdtDistribuidoresUsuario_Usuariozona = sdt.gxTv_SdtDistribuidoresUsuario_Usuariozona ;
         gxTv_SdtDistribuidoresUsuario_Usuariocelular = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocelular ;
         gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal = sdt.gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal ;
         gxTv_SdtDistribuidoresUsuario_Paisid = sdt.gxTv_SdtDistribuidoresUsuario_Paisid ;
         gxTv_SdtDistribuidoresUsuario_Paisdescripcion = sdt.gxTv_SdtDistribuidoresUsuario_Paisdescripcion ;
         gxTv_SdtDistribuidoresUsuario_Estadoid = sdt.gxTv_SdtDistribuidoresUsuario_Estadoid ;
         gxTv_SdtDistribuidoresUsuario_Estadodescripcion = sdt.gxTv_SdtDistribuidoresUsuario_Estadodescripcion ;
         gxTv_SdtDistribuidoresUsuario_Ciudadid = sdt.gxTv_SdtDistribuidoresUsuario_Ciudadid ;
         gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion = sdt.gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion ;
         gxTv_SdtDistribuidoresUsuario_Usuariosucursal = sdt.gxTv_SdtDistribuidoresUsuario_Usuariosucursal ;
         gxTv_SdtDistribuidoresUsuario_Usuarioproducto = sdt.gxTv_SdtDistribuidoresUsuario_Usuarioproducto ;
         gxTv_SdtDistribuidoresUsuario_Usuariorol = sdt.gxTv_SdtDistribuidoresUsuario_Usuariorol ;
         gxTv_SdtDistribuidoresUsuario_Distribuidorid = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidorid ;
         gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion ;
         gxTv_SdtDistribuidoresUsuario_Distribuidorrfc = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidorrfc ;
         gxTv_SdtDistribuidoresUsuario_Mode = sdt.gxTv_SdtDistribuidoresUsuario_Mode ;
         gxTv_SdtDistribuidoresUsuario_Initialized = sdt.gxTv_SdtDistribuidoresUsuario_Initialized ;
         gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid_Z = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuarioid_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuarioid_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariopass_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariopass_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariokey_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariokey_Z ;
         gxTv_SdtDistribuidoresUsuario_Puestoid_Z = sdt.gxTv_SdtDistribuidoresUsuario_Puestoid_Z ;
         gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z = sdt.gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariocp_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocp_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariozona_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariozona_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariocelular_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocelular_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal_Z ;
         gxTv_SdtDistribuidoresUsuario_Paisid_Z = sdt.gxTv_SdtDistribuidoresUsuario_Paisid_Z ;
         gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z = sdt.gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z ;
         gxTv_SdtDistribuidoresUsuario_Estadoid_Z = sdt.gxTv_SdtDistribuidoresUsuario_Estadoid_Z ;
         gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z = sdt.gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z ;
         gxTv_SdtDistribuidoresUsuario_Ciudadid_Z = sdt.gxTv_SdtDistribuidoresUsuario_Ciudadid_Z ;
         gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z = sdt.gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z ;
         gxTv_SdtDistribuidoresUsuario_Usuariorol_Z = sdt.gxTv_SdtDistribuidoresUsuario_Usuariorol_Z ;
         gxTv_SdtDistribuidoresUsuario_Distribuidorid_Z = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidorid_Z ;
         gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z ;
         gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z ;
         gxTv_SdtDistribuidoresUsuario_Puestoid_N = sdt.gxTv_SdtDistribuidoresUsuario_Puestoid_N ;
         gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N = sdt.gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N ;
         gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N = sdt.gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N ;
         gxTv_SdtDistribuidoresUsuario_Ciudadid_N = sdt.gxTv_SdtDistribuidoresUsuario_Ciudadid_N ;
         gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N = sdt.gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N ;
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
         AddObjectProperty("DistribuidoresUsuarioID", gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid, false, includeNonInitialized);
         AddObjectProperty("UsuarioID", gxTv_SdtDistribuidoresUsuario_Usuarioid, false, includeNonInitialized);
         AddObjectProperty("UsuarioNombre", gxTv_SdtDistribuidoresUsuario_Usuarionombre, false, includeNonInitialized);
         AddObjectProperty("UsuarioApellido", gxTv_SdtDistribuidoresUsuario_Usuarioapellido, false, includeNonInitialized);
         AddObjectProperty("UsuarioNombreCompleto", gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto, false, includeNonInitialized);
         AddObjectProperty("UsuarioCorreo", gxTv_SdtDistribuidoresUsuario_Usuariocorreo, false, includeNonInitialized);
         AddObjectProperty("UsuarioPass", gxTv_SdtDistribuidoresUsuario_Usuariopass, false, includeNonInitialized);
         AddObjectProperty("UsuarioKey", gxTv_SdtDistribuidoresUsuario_Usuariokey, false, includeNonInitialized);
         AddObjectProperty("PuestoID", gxTv_SdtDistribuidoresUsuario_Puestoid, false, includeNonInitialized);
         AddObjectProperty("PuestoID_N", gxTv_SdtDistribuidoresUsuario_Puestoid_N, false, includeNonInitialized);
         AddObjectProperty("PuestoDescripcion", gxTv_SdtDistribuidoresUsuario_Puestodescripcion, false, includeNonInitialized);
         AddObjectProperty("UsuarioGenero", gxTv_SdtDistribuidoresUsuario_Usuariogenero, false, includeNonInitialized);
         AddObjectProperty("UsuarioDirectoAsociado", gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado, false, includeNonInitialized);
         AddObjectProperty("UsuarioDirectoAsociado_N", gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N, false, includeNonInitialized);
         AddObjectProperty("UsuarioRazonSocialAsociado", gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado, false, includeNonInitialized);
         AddObjectProperty("UsuarioNombreComercial", gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuarioFechaNacimiento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UsuarioFechaNacimiento_N", gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N, false, includeNonInitialized);
         AddObjectProperty("UsuarioCalleNum", gxTv_SdtDistribuidoresUsuario_Usuariocallenum, false, includeNonInitialized);
         AddObjectProperty("UsuarioColonia", gxTv_SdtDistribuidoresUsuario_Usuariocolonia, false, includeNonInitialized);
         AddObjectProperty("UsuarioDelegacion", gxTv_SdtDistribuidoresUsuario_Usuariodelegacion, false, includeNonInitialized);
         AddObjectProperty("UsuarioCP", gxTv_SdtDistribuidoresUsuario_Usuariocp, false, includeNonInitialized);
         AddObjectProperty("UsuarioZona", gxTv_SdtDistribuidoresUsuario_Usuariozona, false, includeNonInitialized);
         AddObjectProperty("UsuarioCelular", gxTv_SdtDistribuidoresUsuario_Usuariocelular, false, includeNonInitialized);
         AddObjectProperty("UsuarioTelefonoSucursal", gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal, false, includeNonInitialized);
         AddObjectProperty("PaisID", gxTv_SdtDistribuidoresUsuario_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisDescripcion", gxTv_SdtDistribuidoresUsuario_Paisdescripcion, false, includeNonInitialized);
         AddObjectProperty("EstadoID", gxTv_SdtDistribuidoresUsuario_Estadoid, false, includeNonInitialized);
         AddObjectProperty("EstadoDescripcion", gxTv_SdtDistribuidoresUsuario_Estadodescripcion, false, includeNonInitialized);
         AddObjectProperty("CiudadID", gxTv_SdtDistribuidoresUsuario_Ciudadid, false, includeNonInitialized);
         AddObjectProperty("CiudadID_N", gxTv_SdtDistribuidoresUsuario_Ciudadid_N, false, includeNonInitialized);
         AddObjectProperty("CiudadDescripcion", gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion, false, includeNonInitialized);
         AddObjectProperty("UsuarioSucursal", gxTv_SdtDistribuidoresUsuario_Usuariosucursal, false, includeNonInitialized);
         AddObjectProperty("UsuarioProducto", gxTv_SdtDistribuidoresUsuario_Usuarioproducto, false, includeNonInitialized);
         AddObjectProperty("UsuarioProducto_N", gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N, false, includeNonInitialized);
         AddObjectProperty("UsuarioRol", gxTv_SdtDistribuidoresUsuario_Usuariorol, false, includeNonInitialized);
         AddObjectProperty("DistribuidorID", gxTv_SdtDistribuidoresUsuario_Distribuidorid, false, includeNonInitialized);
         AddObjectProperty("DistribuidorDescripcion", gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion, false, includeNonInitialized);
         AddObjectProperty("DistribuidorRFC", gxTv_SdtDistribuidoresUsuario_Distribuidorrfc, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDistribuidoresUsuario_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDistribuidoresUsuario_Initialized, false, includeNonInitialized);
            AddObjectProperty("DistribuidoresUsuarioID_Z", gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioID_Z", gxTv_SdtDistribuidoresUsuario_Usuarioid_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioNombre_Z", gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioApellido_Z", gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioNombreCompleto_Z", gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioCorreo_Z", gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioPass_Z", gxTv_SdtDistribuidoresUsuario_Usuariopass_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioKey_Z", gxTv_SdtDistribuidoresUsuario_Usuariokey_Z, false, includeNonInitialized);
            AddObjectProperty("PuestoID_Z", gxTv_SdtDistribuidoresUsuario_Puestoid_Z, false, includeNonInitialized);
            AddObjectProperty("PuestoDescripcion_Z", gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioGenero_Z", gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioDirectoAsociado_Z", gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioRazonSocialAsociado_Z", gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioNombreComercial_Z", gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("UsuarioFechaNacimiento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("UsuarioCalleNum_Z", gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioColonia_Z", gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioDelegacion_Z", gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioCP_Z", gxTv_SdtDistribuidoresUsuario_Usuariocp_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioZona_Z", gxTv_SdtDistribuidoresUsuario_Usuariozona_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioCelular_Z", gxTv_SdtDistribuidoresUsuario_Usuariocelular_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioTelefonoSucursal_Z", gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal_Z, false, includeNonInitialized);
            AddObjectProperty("PaisID_Z", gxTv_SdtDistribuidoresUsuario_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisDescripcion_Z", gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("EstadoID_Z", gxTv_SdtDistribuidoresUsuario_Estadoid_Z, false, includeNonInitialized);
            AddObjectProperty("EstadoDescripcion_Z", gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("CiudadID_Z", gxTv_SdtDistribuidoresUsuario_Ciudadid_Z, false, includeNonInitialized);
            AddObjectProperty("CiudadDescripcion_Z", gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioSucursal_Z", gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioProducto_Z", gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z, false, includeNonInitialized);
            AddObjectProperty("UsuarioRol_Z", gxTv_SdtDistribuidoresUsuario_Usuariorol_Z, false, includeNonInitialized);
            AddObjectProperty("DistribuidorID_Z", gxTv_SdtDistribuidoresUsuario_Distribuidorid_Z, false, includeNonInitialized);
            AddObjectProperty("DistribuidorDescripcion_Z", gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("DistribuidorRFC_Z", gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z, false, includeNonInitialized);
            AddObjectProperty("PuestoID_N", gxTv_SdtDistribuidoresUsuario_Puestoid_N, false, includeNonInitialized);
            AddObjectProperty("UsuarioDirectoAsociado_N", gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N, false, includeNonInitialized);
            AddObjectProperty("UsuarioFechaNacimiento_N", gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N, false, includeNonInitialized);
            AddObjectProperty("CiudadID_N", gxTv_SdtDistribuidoresUsuario_Ciudadid_N, false, includeNonInitialized);
            AddObjectProperty("UsuarioProducto_N", gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDistribuidoresUsuario sdt )
      {
         if ( sdt.IsDirty("DistribuidoresUsuarioID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid ;
         }
         if ( sdt.IsDirty("UsuarioID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarioid = sdt.gxTv_SdtDistribuidoresUsuario_Usuarioid ;
         }
         if ( sdt.IsDirty("UsuarioNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarionombre = sdt.gxTv_SdtDistribuidoresUsuario_Usuarionombre ;
         }
         if ( sdt.IsDirty("UsuarioApellido") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarioapellido = sdt.gxTv_SdtDistribuidoresUsuario_Usuarioapellido ;
         }
         if ( sdt.IsDirty("UsuarioNombreCompleto") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto = sdt.gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto ;
         }
         if ( sdt.IsDirty("UsuarioCorreo") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocorreo = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocorreo ;
         }
         if ( sdt.IsDirty("UsuarioPass") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariopass = sdt.gxTv_SdtDistribuidoresUsuario_Usuariopass ;
         }
         if ( sdt.IsDirty("UsuarioKey") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariokey = sdt.gxTv_SdtDistribuidoresUsuario_Usuariokey ;
         }
         if ( sdt.IsDirty("PuestoID") )
         {
            gxTv_SdtDistribuidoresUsuario_Puestoid_N = (short)(sdt.gxTv_SdtDistribuidoresUsuario_Puestoid_N);
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Puestoid = sdt.gxTv_SdtDistribuidoresUsuario_Puestoid ;
         }
         if ( sdt.IsDirty("PuestoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Puestodescripcion = sdt.gxTv_SdtDistribuidoresUsuario_Puestodescripcion ;
         }
         if ( sdt.IsDirty("UsuarioGenero") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariogenero = sdt.gxTv_SdtDistribuidoresUsuario_Usuariogenero ;
         }
         if ( sdt.IsDirty("UsuarioDirectoAsociado") )
         {
            gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N = (short)(sdt.gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N);
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado = sdt.gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado ;
         }
         if ( sdt.IsDirty("UsuarioRazonSocialAsociado") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado = sdt.gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado ;
         }
         if ( sdt.IsDirty("UsuarioNombreComercial") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial = sdt.gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial ;
         }
         if ( sdt.IsDirty("UsuarioFechaNacimiento") )
         {
            gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N = (short)(sdt.gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N);
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento = sdt.gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento ;
         }
         if ( sdt.IsDirty("UsuarioCalleNum") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocallenum = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocallenum ;
         }
         if ( sdt.IsDirty("UsuarioColonia") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocolonia = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocolonia ;
         }
         if ( sdt.IsDirty("UsuarioDelegacion") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariodelegacion = sdt.gxTv_SdtDistribuidoresUsuario_Usuariodelegacion ;
         }
         if ( sdt.IsDirty("UsuarioCP") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocp = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocp ;
         }
         if ( sdt.IsDirty("UsuarioZona") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariozona = sdt.gxTv_SdtDistribuidoresUsuario_Usuariozona ;
         }
         if ( sdt.IsDirty("UsuarioCelular") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocelular = sdt.gxTv_SdtDistribuidoresUsuario_Usuariocelular ;
         }
         if ( sdt.IsDirty("UsuarioTelefonoSucursal") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal = sdt.gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal ;
         }
         if ( sdt.IsDirty("PaisID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Paisid = sdt.gxTv_SdtDistribuidoresUsuario_Paisid ;
         }
         if ( sdt.IsDirty("PaisDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Paisdescripcion = sdt.gxTv_SdtDistribuidoresUsuario_Paisdescripcion ;
         }
         if ( sdt.IsDirty("EstadoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Estadoid = sdt.gxTv_SdtDistribuidoresUsuario_Estadoid ;
         }
         if ( sdt.IsDirty("EstadoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Estadodescripcion = sdt.gxTv_SdtDistribuidoresUsuario_Estadodescripcion ;
         }
         if ( sdt.IsDirty("CiudadID") )
         {
            gxTv_SdtDistribuidoresUsuario_Ciudadid_N = (short)(sdt.gxTv_SdtDistribuidoresUsuario_Ciudadid_N);
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Ciudadid = sdt.gxTv_SdtDistribuidoresUsuario_Ciudadid ;
         }
         if ( sdt.IsDirty("CiudadDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion = sdt.gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion ;
         }
         if ( sdt.IsDirty("UsuarioSucursal") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariosucursal = sdt.gxTv_SdtDistribuidoresUsuario_Usuariosucursal ;
         }
         if ( sdt.IsDirty("UsuarioProducto") )
         {
            gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N = (short)(sdt.gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N);
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarioproducto = sdt.gxTv_SdtDistribuidoresUsuario_Usuarioproducto ;
         }
         if ( sdt.IsDirty("UsuarioRol") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariorol = sdt.gxTv_SdtDistribuidoresUsuario_Usuariorol ;
         }
         if ( sdt.IsDirty("DistribuidorID") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidorid = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidorid ;
         }
         if ( sdt.IsDirty("DistribuidorDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion ;
         }
         if ( sdt.IsDirty("DistribuidorRFC") )
         {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidorrfc = sdt.gxTv_SdtDistribuidoresUsuario_Distribuidorrfc ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DistribuidoresUsuarioID" )]
      [  XmlElement( ElementName = "DistribuidoresUsuarioID"   )]
      public int gxTpr_Distribuidoresusuarioid
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid != value )
            {
               gxTv_SdtDistribuidoresUsuario_Mode = "INS";
               this.gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuarioid_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariopass_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariokey_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Puestoid_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariocp_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariozona_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariocelular_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Paisid_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Estadoid_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Ciudadid_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Usuariorol_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Distribuidorid_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z_SetNull( );
               this.gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z_SetNull( );
            }
            gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid = value;
            SetDirty("Distribuidoresusuarioid");
         }

      }

      [  SoapElement( ElementName = "UsuarioID" )]
      [  XmlElement( ElementName = "UsuarioID"   )]
      public int gxTpr_Usuarioid
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarioid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarioid = value;
            SetDirty("Usuarioid");
         }

      }

      [  SoapElement( ElementName = "UsuarioNombre" )]
      [  XmlElement( ElementName = "UsuarioNombre"   )]
      public string gxTpr_Usuarionombre
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarionombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarionombre = value;
            SetDirty("Usuarionombre");
         }

      }

      [  SoapElement( ElementName = "UsuarioApellido" )]
      [  XmlElement( ElementName = "UsuarioApellido"   )]
      public string gxTpr_Usuarioapellido
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarioapellido ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarioapellido = value;
            SetDirty("Usuarioapellido");
         }

      }

      [  SoapElement( ElementName = "UsuarioNombreCompleto" )]
      [  XmlElement( ElementName = "UsuarioNombreCompleto"   )]
      public string gxTpr_Usuarionombrecompleto
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto = value;
            SetDirty("Usuarionombrecompleto");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto = "";
         SetDirty("Usuarionombrecompleto");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioCorreo" )]
      [  XmlElement( ElementName = "UsuarioCorreo"   )]
      public string gxTpr_Usuariocorreo
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariocorreo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocorreo = value;
            SetDirty("Usuariocorreo");
         }

      }

      [  SoapElement( ElementName = "UsuarioPass" )]
      [  XmlElement( ElementName = "UsuarioPass"   )]
      public string gxTpr_Usuariopass
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariopass ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariopass = value;
            SetDirty("Usuariopass");
         }

      }

      [  SoapElement( ElementName = "UsuarioKey" )]
      [  XmlElement( ElementName = "UsuarioKey"   )]
      public string gxTpr_Usuariokey
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariokey ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariokey = value;
            SetDirty("Usuariokey");
         }

      }

      [  SoapElement( ElementName = "PuestoID" )]
      [  XmlElement( ElementName = "PuestoID"   )]
      public int gxTpr_Puestoid
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Puestoid ;
         }

         set {
            gxTv_SdtDistribuidoresUsuario_Puestoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Puestoid = value;
            SetDirty("Puestoid");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Puestoid_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Puestoid_N = 1;
         gxTv_SdtDistribuidoresUsuario_Puestoid = 0;
         SetDirty("Puestoid");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Puestoid_IsNull( )
      {
         return (gxTv_SdtDistribuidoresUsuario_Puestoid_N==1) ;
      }

      [  SoapElement( ElementName = "PuestoDescripcion" )]
      [  XmlElement( ElementName = "PuestoDescripcion"   )]
      public string gxTpr_Puestodescripcion
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Puestodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Puestodescripcion = value;
            SetDirty("Puestodescripcion");
         }

      }

      [  SoapElement( ElementName = "UsuarioGenero" )]
      [  XmlElement( ElementName = "UsuarioGenero"   )]
      public string gxTpr_Usuariogenero
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariogenero ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariogenero = value;
            SetDirty("Usuariogenero");
         }

      }

      [  SoapElement( ElementName = "UsuarioDirectoAsociado" )]
      [  XmlElement( ElementName = "UsuarioDirectoAsociado"   )]
      public string gxTpr_Usuariodirectoasociado
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado ;
         }

         set {
            gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado = value;
            SetDirty("Usuariodirectoasociado");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N = 1;
         gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado = "";
         SetDirty("Usuariodirectoasociado");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_IsNull( )
      {
         return (gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N==1) ;
      }

      [  SoapElement( ElementName = "UsuarioRazonSocialAsociado" )]
      [  XmlElement( ElementName = "UsuarioRazonSocialAsociado"   )]
      public string gxTpr_Usuariorazonsocialasociado
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado = value;
            SetDirty("Usuariorazonsocialasociado");
         }

      }

      [  SoapElement( ElementName = "UsuarioNombreComercial" )]
      [  XmlElement( ElementName = "UsuarioNombreComercial"   )]
      public string gxTpr_Usuarionombrecomercial
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial = value;
            SetDirty("Usuarionombrecomercial");
         }

      }

      [  SoapElement( ElementName = "UsuarioFechaNacimiento" )]
      [  XmlElement( ElementName = "UsuarioFechaNacimiento"  , IsNullable=true )]
      public string gxTpr_Usuariofechanacimiento_Nullable
      {
         get {
            if ( gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento).value ;
         }

         set {
            gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento = DateTime.MinValue;
            else
               gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usuariofechanacimiento
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento ;
         }

         set {
            gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento = value;
            SetDirty("Usuariofechanacimiento");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N = 1;
         gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento = (DateTime)(DateTime.MinValue);
         SetDirty("Usuariofechanacimiento");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_IsNull( )
      {
         return (gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N==1) ;
      }

      [  SoapElement( ElementName = "UsuarioCalleNum" )]
      [  XmlElement( ElementName = "UsuarioCalleNum"   )]
      public string gxTpr_Usuariocallenum
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariocallenum ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocallenum = value;
            SetDirty("Usuariocallenum");
         }

      }

      [  SoapElement( ElementName = "UsuarioColonia" )]
      [  XmlElement( ElementName = "UsuarioColonia"   )]
      public string gxTpr_Usuariocolonia
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariocolonia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocolonia = value;
            SetDirty("Usuariocolonia");
         }

      }

      [  SoapElement( ElementName = "UsuarioDelegacion" )]
      [  XmlElement( ElementName = "UsuarioDelegacion"   )]
      public string gxTpr_Usuariodelegacion
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariodelegacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariodelegacion = value;
            SetDirty("Usuariodelegacion");
         }

      }

      [  SoapElement( ElementName = "UsuarioCP" )]
      [  XmlElement( ElementName = "UsuarioCP"   )]
      public int gxTpr_Usuariocp
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariocp ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocp = value;
            SetDirty("Usuariocp");
         }

      }

      [  SoapElement( ElementName = "UsuarioZona" )]
      [  XmlElement( ElementName = "UsuarioZona"   )]
      public string gxTpr_Usuariozona
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariozona ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariozona = value;
            SetDirty("Usuariozona");
         }

      }

      [  SoapElement( ElementName = "UsuarioCelular" )]
      [  XmlElement( ElementName = "UsuarioCelular"   )]
      public long gxTpr_Usuariocelular
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariocelular ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocelular = value;
            SetDirty("Usuariocelular");
         }

      }

      [  SoapElement( ElementName = "UsuarioTelefonoSucursal" )]
      [  XmlElement( ElementName = "UsuarioTelefonoSucursal"   )]
      public long gxTpr_Usuariotelefonosucursal
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal = value;
            SetDirty("Usuariotelefonosucursal");
         }

      }

      [  SoapElement( ElementName = "PaisID" )]
      [  XmlElement( ElementName = "PaisID"   )]
      public int gxTpr_Paisid
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Paisid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisDescripcion" )]
      [  XmlElement( ElementName = "PaisDescripcion"   )]
      public string gxTpr_Paisdescripcion
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Paisdescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Paisdescripcion = value;
            SetDirty("Paisdescripcion");
         }

      }

      [  SoapElement( ElementName = "EstadoID" )]
      [  XmlElement( ElementName = "EstadoID"   )]
      public int gxTpr_Estadoid
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Estadoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Estadoid = value;
            SetDirty("Estadoid");
         }

      }

      [  SoapElement( ElementName = "EstadoDescripcion" )]
      [  XmlElement( ElementName = "EstadoDescripcion"   )]
      public string gxTpr_Estadodescripcion
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Estadodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Estadodescripcion = value;
            SetDirty("Estadodescripcion");
         }

      }

      [  SoapElement( ElementName = "CiudadID" )]
      [  XmlElement( ElementName = "CiudadID"   )]
      public int gxTpr_Ciudadid
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Ciudadid ;
         }

         set {
            gxTv_SdtDistribuidoresUsuario_Ciudadid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Ciudadid = value;
            SetDirty("Ciudadid");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Ciudadid_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Ciudadid_N = 1;
         gxTv_SdtDistribuidoresUsuario_Ciudadid = 0;
         SetDirty("Ciudadid");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Ciudadid_IsNull( )
      {
         return (gxTv_SdtDistribuidoresUsuario_Ciudadid_N==1) ;
      }

      [  SoapElement( ElementName = "CiudadDescripcion" )]
      [  XmlElement( ElementName = "CiudadDescripcion"   )]
      public string gxTpr_Ciudaddescripcion
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion = value;
            SetDirty("Ciudaddescripcion");
         }

      }

      [  SoapElement( ElementName = "UsuarioSucursal" )]
      [  XmlElement( ElementName = "UsuarioSucursal"   )]
      public string gxTpr_Usuariosucursal
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariosucursal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariosucursal = value;
            SetDirty("Usuariosucursal");
         }

      }

      [  SoapElement( ElementName = "UsuarioProducto" )]
      [  XmlElement( ElementName = "UsuarioProducto"   )]
      public string gxTpr_Usuarioproducto
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarioproducto ;
         }

         set {
            gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarioproducto = value;
            SetDirty("Usuarioproducto");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuarioproducto_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N = 1;
         gxTv_SdtDistribuidoresUsuario_Usuarioproducto = "";
         SetDirty("Usuarioproducto");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuarioproducto_IsNull( )
      {
         return (gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N==1) ;
      }

      [  SoapElement( ElementName = "UsuarioRol" )]
      [  XmlElement( ElementName = "UsuarioRol"   )]
      public string gxTpr_Usuariorol
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariorol ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariorol = value;
            SetDirty("Usuariorol");
         }

      }

      [  SoapElement( ElementName = "DistribuidorID" )]
      [  XmlElement( ElementName = "DistribuidorID"   )]
      public int gxTpr_Distribuidorid
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Distribuidorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidorid = value;
            SetDirty("Distribuidorid");
         }

      }

      [  SoapElement( ElementName = "DistribuidorDescripcion" )]
      [  XmlElement( ElementName = "DistribuidorDescripcion"   )]
      public string gxTpr_Distribuidordescripcion
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion = value;
            SetDirty("Distribuidordescripcion");
         }

      }

      [  SoapElement( ElementName = "DistribuidorRFC" )]
      [  XmlElement( ElementName = "DistribuidorRFC"   )]
      public string gxTpr_Distribuidorrfc
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Distribuidorrfc ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidorrfc = value;
            SetDirty("Distribuidorrfc");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Mode_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Initialized_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DistribuidoresUsuarioID_Z" )]
      [  XmlElement( ElementName = "DistribuidoresUsuarioID_Z"   )]
      public int gxTpr_Distribuidoresusuarioid_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid_Z = value;
            SetDirty("Distribuidoresusuarioid_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid_Z = 0;
         SetDirty("Distribuidoresusuarioid_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioID_Z" )]
      [  XmlElement( ElementName = "UsuarioID_Z"   )]
      public int gxTpr_Usuarioid_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarioid_Z = value;
            SetDirty("Usuarioid_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuarioid_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuarioid_Z = 0;
         SetDirty("Usuarioid_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioNombre_Z" )]
      [  XmlElement( ElementName = "UsuarioNombre_Z"   )]
      public string gxTpr_Usuarionombre_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z = value;
            SetDirty("Usuarionombre_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z = "";
         SetDirty("Usuarionombre_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioApellido_Z" )]
      [  XmlElement( ElementName = "UsuarioApellido_Z"   )]
      public string gxTpr_Usuarioapellido_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z = value;
            SetDirty("Usuarioapellido_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z = "";
         SetDirty("Usuarioapellido_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioNombreCompleto_Z" )]
      [  XmlElement( ElementName = "UsuarioNombreCompleto_Z"   )]
      public string gxTpr_Usuarionombrecompleto_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z = value;
            SetDirty("Usuarionombrecompleto_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z = "";
         SetDirty("Usuarionombrecompleto_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioCorreo_Z" )]
      [  XmlElement( ElementName = "UsuarioCorreo_Z"   )]
      public string gxTpr_Usuariocorreo_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z = value;
            SetDirty("Usuariocorreo_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z = "";
         SetDirty("Usuariocorreo_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioPass_Z" )]
      [  XmlElement( ElementName = "UsuarioPass_Z"   )]
      public string gxTpr_Usuariopass_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariopass_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariopass_Z = value;
            SetDirty("Usuariopass_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariopass_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariopass_Z = "";
         SetDirty("Usuariopass_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariopass_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioKey_Z" )]
      [  XmlElement( ElementName = "UsuarioKey_Z"   )]
      public string gxTpr_Usuariokey_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariokey_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariokey_Z = value;
            SetDirty("Usuariokey_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariokey_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariokey_Z = "";
         SetDirty("Usuariokey_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariokey_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PuestoID_Z" )]
      [  XmlElement( ElementName = "PuestoID_Z"   )]
      public int gxTpr_Puestoid_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Puestoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Puestoid_Z = value;
            SetDirty("Puestoid_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Puestoid_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Puestoid_Z = 0;
         SetDirty("Puestoid_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Puestoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PuestoDescripcion_Z" )]
      [  XmlElement( ElementName = "PuestoDescripcion_Z"   )]
      public string gxTpr_Puestodescripcion_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z = value;
            SetDirty("Puestodescripcion_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z = "";
         SetDirty("Puestodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioGenero_Z" )]
      [  XmlElement( ElementName = "UsuarioGenero_Z"   )]
      public string gxTpr_Usuariogenero_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z = value;
            SetDirty("Usuariogenero_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z = "";
         SetDirty("Usuariogenero_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioDirectoAsociado_Z" )]
      [  XmlElement( ElementName = "UsuarioDirectoAsociado_Z"   )]
      public string gxTpr_Usuariodirectoasociado_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z = value;
            SetDirty("Usuariodirectoasociado_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z = "";
         SetDirty("Usuariodirectoasociado_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioRazonSocialAsociado_Z" )]
      [  XmlElement( ElementName = "UsuarioRazonSocialAsociado_Z"   )]
      public string gxTpr_Usuariorazonsocialasociado_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z = value;
            SetDirty("Usuariorazonsocialasociado_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z = "";
         SetDirty("Usuariorazonsocialasociado_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioNombreComercial_Z" )]
      [  XmlElement( ElementName = "UsuarioNombreComercial_Z"   )]
      public string gxTpr_Usuarionombrecomercial_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z = value;
            SetDirty("Usuarionombrecomercial_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z = "";
         SetDirty("Usuarionombrecomercial_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioFechaNacimiento_Z" )]
      [  XmlElement( ElementName = "UsuarioFechaNacimiento_Z"  , IsNullable=true )]
      public string gxTpr_Usuariofechanacimiento_Z_Nullable
      {
         get {
            if ( gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z = DateTime.MinValue;
            else
               gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usuariofechanacimiento_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z = value;
            SetDirty("Usuariofechanacimiento_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Usuariofechanacimiento_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioCalleNum_Z" )]
      [  XmlElement( ElementName = "UsuarioCalleNum_Z"   )]
      public string gxTpr_Usuariocallenum_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z = value;
            SetDirty("Usuariocallenum_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z = "";
         SetDirty("Usuariocallenum_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioColonia_Z" )]
      [  XmlElement( ElementName = "UsuarioColonia_Z"   )]
      public string gxTpr_Usuariocolonia_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z = value;
            SetDirty("Usuariocolonia_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z = "";
         SetDirty("Usuariocolonia_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioDelegacion_Z" )]
      [  XmlElement( ElementName = "UsuarioDelegacion_Z"   )]
      public string gxTpr_Usuariodelegacion_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z = value;
            SetDirty("Usuariodelegacion_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z = "";
         SetDirty("Usuariodelegacion_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioCP_Z" )]
      [  XmlElement( ElementName = "UsuarioCP_Z"   )]
      public int gxTpr_Usuariocp_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariocp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocp_Z = value;
            SetDirty("Usuariocp_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariocp_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariocp_Z = 0;
         SetDirty("Usuariocp_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariocp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioZona_Z" )]
      [  XmlElement( ElementName = "UsuarioZona_Z"   )]
      public string gxTpr_Usuariozona_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariozona_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariozona_Z = value;
            SetDirty("Usuariozona_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariozona_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariozona_Z = "";
         SetDirty("Usuariozona_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariozona_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioCelular_Z" )]
      [  XmlElement( ElementName = "UsuarioCelular_Z"   )]
      public long gxTpr_Usuariocelular_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariocelular_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariocelular_Z = value;
            SetDirty("Usuariocelular_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariocelular_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariocelular_Z = 0;
         SetDirty("Usuariocelular_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariocelular_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioTelefonoSucursal_Z" )]
      [  XmlElement( ElementName = "UsuarioTelefonoSucursal_Z"   )]
      public long gxTpr_Usuariotelefonosucursal_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal_Z = value;
            SetDirty("Usuariotelefonosucursal_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal_Z = 0;
         SetDirty("Usuariotelefonosucursal_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisID_Z" )]
      [  XmlElement( ElementName = "PaisID_Z"   )]
      public int gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Paisid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Paisid_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisDescripcion_Z" )]
      [  XmlElement( ElementName = "PaisDescripcion_Z"   )]
      public string gxTpr_Paisdescripcion_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z = value;
            SetDirty("Paisdescripcion_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z = "";
         SetDirty("Paisdescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoID_Z" )]
      [  XmlElement( ElementName = "EstadoID_Z"   )]
      public int gxTpr_Estadoid_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Estadoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Estadoid_Z = value;
            SetDirty("Estadoid_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Estadoid_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Estadoid_Z = 0;
         SetDirty("Estadoid_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Estadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoDescripcion_Z" )]
      [  XmlElement( ElementName = "EstadoDescripcion_Z"   )]
      public string gxTpr_Estadodescripcion_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z = value;
            SetDirty("Estadodescripcion_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z = "";
         SetDirty("Estadodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadID_Z" )]
      [  XmlElement( ElementName = "CiudadID_Z"   )]
      public int gxTpr_Ciudadid_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Ciudadid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Ciudadid_Z = value;
            SetDirty("Ciudadid_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Ciudadid_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Ciudadid_Z = 0;
         SetDirty("Ciudadid_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Ciudadid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadDescripcion_Z" )]
      [  XmlElement( ElementName = "CiudadDescripcion_Z"   )]
      public string gxTpr_Ciudaddescripcion_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z = value;
            SetDirty("Ciudaddescripcion_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z = "";
         SetDirty("Ciudaddescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioSucursal_Z" )]
      [  XmlElement( ElementName = "UsuarioSucursal_Z"   )]
      public string gxTpr_Usuariosucursal_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z = value;
            SetDirty("Usuariosucursal_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z = "";
         SetDirty("Usuariosucursal_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioProducto_Z" )]
      [  XmlElement( ElementName = "UsuarioProducto_Z"   )]
      public string gxTpr_Usuarioproducto_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z = value;
            SetDirty("Usuarioproducto_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z = "";
         SetDirty("Usuarioproducto_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioRol_Z" )]
      [  XmlElement( ElementName = "UsuarioRol_Z"   )]
      public string gxTpr_Usuariorol_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariorol_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariorol_Z = value;
            SetDirty("Usuariorol_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariorol_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariorol_Z = "";
         SetDirty("Usuariorol_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariorol_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DistribuidorID_Z" )]
      [  XmlElement( ElementName = "DistribuidorID_Z"   )]
      public int gxTpr_Distribuidorid_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Distribuidorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidorid_Z = value;
            SetDirty("Distribuidorid_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Distribuidorid_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Distribuidorid_Z = 0;
         SetDirty("Distribuidorid_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Distribuidorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DistribuidorDescripcion_Z" )]
      [  XmlElement( ElementName = "DistribuidorDescripcion_Z"   )]
      public string gxTpr_Distribuidordescripcion_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z = value;
            SetDirty("Distribuidordescripcion_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z = "";
         SetDirty("Distribuidordescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DistribuidorRFC_Z" )]
      [  XmlElement( ElementName = "DistribuidorRFC_Z"   )]
      public string gxTpr_Distribuidorrfc_Z
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z = value;
            SetDirty("Distribuidorrfc_Z");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z = "";
         SetDirty("Distribuidorrfc_Z");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PuestoID_N" )]
      [  XmlElement( ElementName = "PuestoID_N"   )]
      public short gxTpr_Puestoid_N
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Puestoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Puestoid_N = value;
            SetDirty("Puestoid_N");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Puestoid_N_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Puestoid_N = 0;
         SetDirty("Puestoid_N");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Puestoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioDirectoAsociado_N" )]
      [  XmlElement( ElementName = "UsuarioDirectoAsociado_N"   )]
      public short gxTpr_Usuariodirectoasociado_N
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N = value;
            SetDirty("Usuariodirectoasociado_N");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N = 0;
         SetDirty("Usuariodirectoasociado_N");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioFechaNacimiento_N" )]
      [  XmlElement( ElementName = "UsuarioFechaNacimiento_N"   )]
      public short gxTpr_Usuariofechanacimiento_N
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N = value;
            SetDirty("Usuariofechanacimiento_N");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N = 0;
         SetDirty("Usuariofechanacimiento_N");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CiudadID_N" )]
      [  XmlElement( ElementName = "CiudadID_N"   )]
      public short gxTpr_Ciudadid_N
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Ciudadid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Ciudadid_N = value;
            SetDirty("Ciudadid_N");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Ciudadid_N_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Ciudadid_N = 0;
         SetDirty("Ciudadid_N");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Ciudadid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuarioProducto_N" )]
      [  XmlElement( ElementName = "UsuarioProducto_N"   )]
      public short gxTpr_Usuarioproducto_N
      {
         get {
            return gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N = value;
            SetDirty("Usuarioproducto_N");
         }

      }

      public void gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N_SetNull( )
      {
         gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N = 0;
         SetDirty("Usuarioproducto_N");
         return  ;
      }

      public bool gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N_IsNull( )
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
         gxTv_SdtDistribuidoresUsuario_Usuarionombre = "";
         gxTv_SdtDistribuidoresUsuario_Usuarioapellido = "";
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto = "";
         gxTv_SdtDistribuidoresUsuario_Usuariocorreo = "";
         gxTv_SdtDistribuidoresUsuario_Usuariopass = "";
         gxTv_SdtDistribuidoresUsuario_Usuariokey = "";
         gxTv_SdtDistribuidoresUsuario_Puestodescripcion = "";
         gxTv_SdtDistribuidoresUsuario_Usuariogenero = "";
         gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado = "";
         gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado = "";
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial = "";
         gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento = DateTime.MinValue;
         gxTv_SdtDistribuidoresUsuario_Usuariocallenum = "";
         gxTv_SdtDistribuidoresUsuario_Usuariocolonia = "";
         gxTv_SdtDistribuidoresUsuario_Usuariodelegacion = "";
         gxTv_SdtDistribuidoresUsuario_Usuariozona = "";
         gxTv_SdtDistribuidoresUsuario_Paisdescripcion = "";
         gxTv_SdtDistribuidoresUsuario_Estadodescripcion = "";
         gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion = "";
         gxTv_SdtDistribuidoresUsuario_Usuariosucursal = "";
         gxTv_SdtDistribuidoresUsuario_Usuarioproducto = "";
         gxTv_SdtDistribuidoresUsuario_Usuariorol = "";
         gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion = "";
         gxTv_SdtDistribuidoresUsuario_Distribuidorrfc = "";
         gxTv_SdtDistribuidoresUsuario_Mode = "";
         gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariopass_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariokey_Z = "";
         gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z = DateTime.MinValue;
         gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariozona_Z = "";
         gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z = "";
         gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z = "";
         gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z = "";
         gxTv_SdtDistribuidoresUsuario_Usuariorol_Z = "";
         gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z = "";
         gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "distribuidoresusuario", "GeneXus.Programs.distribuidoresusuario_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtDistribuidoresUsuario_Initialized ;
      private short gxTv_SdtDistribuidoresUsuario_Puestoid_N ;
      private short gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_N ;
      private short gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_N ;
      private short gxTv_SdtDistribuidoresUsuario_Ciudadid_N ;
      private short gxTv_SdtDistribuidoresUsuario_Usuarioproducto_N ;
      private int gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid ;
      private int gxTv_SdtDistribuidoresUsuario_Usuarioid ;
      private int gxTv_SdtDistribuidoresUsuario_Puestoid ;
      private int gxTv_SdtDistribuidoresUsuario_Usuariocp ;
      private int gxTv_SdtDistribuidoresUsuario_Paisid ;
      private int gxTv_SdtDistribuidoresUsuario_Estadoid ;
      private int gxTv_SdtDistribuidoresUsuario_Ciudadid ;
      private int gxTv_SdtDistribuidoresUsuario_Distribuidorid ;
      private int gxTv_SdtDistribuidoresUsuario_Distribuidoresusuarioid_Z ;
      private int gxTv_SdtDistribuidoresUsuario_Usuarioid_Z ;
      private int gxTv_SdtDistribuidoresUsuario_Puestoid_Z ;
      private int gxTv_SdtDistribuidoresUsuario_Usuariocp_Z ;
      private int gxTv_SdtDistribuidoresUsuario_Paisid_Z ;
      private int gxTv_SdtDistribuidoresUsuario_Estadoid_Z ;
      private int gxTv_SdtDistribuidoresUsuario_Ciudadid_Z ;
      private int gxTv_SdtDistribuidoresUsuario_Distribuidorid_Z ;
      private long gxTv_SdtDistribuidoresUsuario_Usuariocelular ;
      private long gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal ;
      private long gxTv_SdtDistribuidoresUsuario_Usuariocelular_Z ;
      private long gxTv_SdtDistribuidoresUsuario_Usuariotelefonosucursal_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuarionombre ;
      private string gxTv_SdtDistribuidoresUsuario_Usuarioapellido ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariogenero ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariocallenum ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariocolonia ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariodelegacion ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariozona ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariosucursal ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariorol ;
      private string gxTv_SdtDistribuidoresUsuario_Distribuidorrfc ;
      private string gxTv_SdtDistribuidoresUsuario_Mode ;
      private string gxTv_SdtDistribuidoresUsuario_Usuarionombre_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuarioapellido_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariogenero_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariodirectoasociado_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariocallenum_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariocolonia_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariodelegacion_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariozona_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariosucursal_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariorol_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Distribuidorrfc_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento ;
      private DateTime gxTv_SdtDistribuidoresUsuario_Usuariofechanacimiento_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariocorreo ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariopass ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariokey ;
      private string gxTv_SdtDistribuidoresUsuario_Puestodescripcion ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado ;
      private string gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial ;
      private string gxTv_SdtDistribuidoresUsuario_Paisdescripcion ;
      private string gxTv_SdtDistribuidoresUsuario_Estadodescripcion ;
      private string gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion ;
      private string gxTv_SdtDistribuidoresUsuario_Usuarioproducto ;
      private string gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion ;
      private string gxTv_SdtDistribuidoresUsuario_Usuarionombrecompleto_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariocorreo_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariopass_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariokey_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Puestodescripcion_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuariorazonsocialasociado_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuarionombrecomercial_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Paisdescripcion_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Estadodescripcion_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Ciudaddescripcion_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Usuarioproducto_Z ;
      private string gxTv_SdtDistribuidoresUsuario_Distribuidordescripcion_Z ;
   }

   [DataContract(Name = @"DistribuidoresUsuario", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtDistribuidoresUsuario_RESTInterface : GxGenericCollectionItem<SdtDistribuidoresUsuario>
   {
      public SdtDistribuidoresUsuario_RESTInterface( ) : base()
      {
      }

      public SdtDistribuidoresUsuario_RESTInterface( SdtDistribuidoresUsuario psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DistribuidoresUsuarioID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Distribuidoresusuarioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Distribuidoresusuarioid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Distribuidoresusuarioid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "UsuarioID" , Order = 1 )]
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

      [DataMember( Name = "UsuarioNombre" , Order = 2 )]
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

      [DataMember( Name = "UsuarioApellido" , Order = 3 )]
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

      [DataMember( Name = "UsuarioNombreCompleto" , Order = 4 )]
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

      [DataMember( Name = "UsuarioCorreo" , Order = 5 )]
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

      [DataMember( Name = "UsuarioPass" , Order = 6 )]
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

      [DataMember( Name = "UsuarioKey" , Order = 7 )]
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

      [DataMember( Name = "PuestoID" , Order = 8 )]
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

      [DataMember( Name = "PuestoDescripcion" , Order = 9 )]
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

      [DataMember( Name = "UsuarioGenero" , Order = 10 )]
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

      [DataMember( Name = "UsuarioDirectoAsociado" , Order = 11 )]
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

      [DataMember( Name = "UsuarioRazonSocialAsociado" , Order = 12 )]
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

      [DataMember( Name = "UsuarioNombreComercial" , Order = 13 )]
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

      [DataMember( Name = "UsuarioFechaNacimiento" , Order = 14 )]
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

      [DataMember( Name = "UsuarioCalleNum" , Order = 15 )]
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

      [DataMember( Name = "UsuarioColonia" , Order = 16 )]
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

      [DataMember( Name = "UsuarioDelegacion" , Order = 17 )]
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

      [DataMember( Name = "UsuarioCP" , Order = 18 )]
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

      [DataMember( Name = "UsuarioZona" , Order = 19 )]
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

      [DataMember( Name = "UsuarioCelular" , Order = 20 )]
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

      [DataMember( Name = "UsuarioTelefonoSucursal" , Order = 21 )]
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

      [DataMember( Name = "PaisID" , Order = 22 )]
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

      [DataMember( Name = "PaisDescripcion" , Order = 23 )]
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

      [DataMember( Name = "EstadoID" , Order = 24 )]
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

      [DataMember( Name = "EstadoDescripcion" , Order = 25 )]
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

      [DataMember( Name = "CiudadID" , Order = 26 )]
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

      [DataMember( Name = "CiudadDescripcion" , Order = 27 )]
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

      [DataMember( Name = "UsuarioSucursal" , Order = 28 )]
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

      [DataMember( Name = "UsuarioProducto" , Order = 29 )]
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

      [DataMember( Name = "UsuarioRol" , Order = 30 )]
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

      [DataMember( Name = "DistribuidorID" , Order = 31 )]
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

      [DataMember( Name = "DistribuidorDescripcion" , Order = 32 )]
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

      [DataMember( Name = "DistribuidorRFC" , Order = 33 )]
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

      public SdtDistribuidoresUsuario sdt
      {
         get {
            return (SdtDistribuidoresUsuario)Sdt ;
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
            sdt = new SdtDistribuidoresUsuario() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 34 )]
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

   [DataContract(Name = @"DistribuidoresUsuario", Namespace = "Premios")]
   [GxJsonSerialization("default")]
   public class SdtDistribuidoresUsuario_RESTLInterface : GxGenericCollectionItem<SdtDistribuidoresUsuario>
   {
      public SdtDistribuidoresUsuario_RESTLInterface( ) : base()
      {
      }

      public SdtDistribuidoresUsuario_RESTLInterface( SdtDistribuidoresUsuario psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DistribuidoresUsuarioID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Distribuidoresusuarioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Distribuidoresusuarioid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Distribuidoresusuarioid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/DistribuidoresUsuario/{0}";
            gxuri = String.Format(gxuri,gxTpr_Distribuidoresusuarioid) ;
            return gxuri ;
         }

         set {
         }

      }

      public SdtDistribuidoresUsuario sdt
      {
         get {
            return (SdtDistribuidoresUsuario)Sdt ;
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
            sdt = new SdtDistribuidoresUsuario() ;
         }
      }

      private string gxuri ;
   }

}
