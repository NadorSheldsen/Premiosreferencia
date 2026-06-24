/*
				   File: type_SdtSDTUsuario
			Description: SDTUsuario
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDTUsuario")]
	[XmlType(TypeName="SDTUsuario" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTUsuario : GxUserType
	{
		public SdtSDTUsuario( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTUsuario_Usuarionombre = "";

			gxTv_SdtSDTUsuario_Usuariocorreo = "";

			gxTv_SdtSDTUsuario_Usuariorol = "";

			gxTv_SdtSDTUsuario_Usuarioapellido = "";

			gxTv_SdtSDTUsuario_Usuarionombrecompleto = "";

			gxTv_SdtSDTUsuario_Puestodescripcion = "";

			gxTv_SdtSDTUsuario_Usuariogenero = "";

			gxTv_SdtSDTUsuario_Usuariodirectoasociado = "";

			gxTv_SdtSDTUsuario_Usuariorazonsocialasociado = "";

			gxTv_SdtSDTUsuario_Usuarionombrecomercial = "";

			gxTv_SdtSDTUsuario_Usuariocallenum = "";

			gxTv_SdtSDTUsuario_Usuariocolonia = "";

			gxTv_SdtSDTUsuario_Usuariodelegacion = "";

			gxTv_SdtSDTUsuario_Usuariozona = "";

			gxTv_SdtSDTUsuario_Paisdescripcion = "";

			gxTv_SdtSDTUsuario_Estadodescripcion = "";

			gxTv_SdtSDTUsuario_Ciudaddescripcion = "";

			gxTv_SdtSDTUsuario_Usuariosucursal = "";

			gxTv_SdtSDTUsuario_Usuarioproducto = "";

		}

		public SdtSDTUsuario(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("UsuarioID", gxTpr_Usuarioid, false);


			AddObjectProperty("UsuarioNombre", gxTpr_Usuarionombre, false);


			AddObjectProperty("UsuarioCorreo", gxTpr_Usuariocorreo, false);


			AddObjectProperty("UsuarioRol", gxTpr_Usuariorol, false);


			AddObjectProperty("UsuarioApellido", gxTpr_Usuarioapellido, false);


			AddObjectProperty("UsuarioNombreCompleto", gxTpr_Usuarionombrecompleto, false);


			AddObjectProperty("PuestoID", gxTpr_Puestoid, false);


			AddObjectProperty("PuestoDescripcion", gxTpr_Puestodescripcion, false);


			AddObjectProperty("UsuarioGenero", gxTpr_Usuariogenero, false);


			AddObjectProperty("UsuarioDirectoAsociado", gxTpr_Usuariodirectoasociado, false);


			AddObjectProperty("UsuarioRazonSocialAsociado", gxTpr_Usuariorazonsocialasociado, false);


			AddObjectProperty("UsuarioNombreComercial", gxTpr_Usuarionombrecomercial, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Usuariofechanacimiento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Usuariofechanacimiento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Usuariofechanacimiento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("UsuarioFechaNacimiento", sDateCnv, false);



			AddObjectProperty("UsuarioCalleNum", gxTpr_Usuariocallenum, false);


			AddObjectProperty("UsuarioColonia", gxTpr_Usuariocolonia, false);


			AddObjectProperty("UsuarioDelegacion", gxTpr_Usuariodelegacion, false);


			AddObjectProperty("UsuarioCP", gxTpr_Usuariocp, false);


			AddObjectProperty("UsuarioZona", gxTpr_Usuariozona, false);


			AddObjectProperty("UsuarioCelular", gxTpr_Usuariocelular, false);


			AddObjectProperty("UsuarioTelefonoSucursal", gxTpr_Usuariotelefonosucursal, false);


			AddObjectProperty("PaisID", gxTpr_Paisid, false);


			AddObjectProperty("PaisDescripcion", gxTpr_Paisdescripcion, false);


			AddObjectProperty("EstadoID", gxTpr_Estadoid, false);


			AddObjectProperty("EstadoDescripcion", gxTpr_Estadodescripcion, false);


			AddObjectProperty("CiudadID", gxTpr_Ciudadid, false);


			AddObjectProperty("CiudadDescripcion", gxTpr_Ciudaddescripcion, false);


			AddObjectProperty("UsuarioSucursal", gxTpr_Usuariosucursal, false);


			AddObjectProperty("UsuarioProducto", gxTpr_Usuarioproducto, false);


			AddObjectProperty("UsuarioAvisoPrivacidad", gxTpr_Usuarioavisoprivacidad, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UsuarioID")]
		[XmlElement(ElementName="UsuarioID")]
		public int gxTpr_Usuarioid
		{
			get {
				return gxTv_SdtSDTUsuario_Usuarioid; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuarioid = value;
				SetDirty("Usuarioid");
			}
		}




		[SoapElement(ElementName="UsuarioNombre")]
		[XmlElement(ElementName="UsuarioNombre")]
		public string gxTpr_Usuarionombre
		{
			get {
				return gxTv_SdtSDTUsuario_Usuarionombre; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuarionombre = value;
				SetDirty("Usuarionombre");
			}
		}




		[SoapElement(ElementName="UsuarioCorreo")]
		[XmlElement(ElementName="UsuarioCorreo")]
		public string gxTpr_Usuariocorreo
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariocorreo; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariocorreo = value;
				SetDirty("Usuariocorreo");
			}
		}




		[SoapElement(ElementName="UsuarioRol")]
		[XmlElement(ElementName="UsuarioRol")]
		public string gxTpr_Usuariorol
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariorol; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariorol = value;
				SetDirty("Usuariorol");
			}
		}




		[SoapElement(ElementName="UsuarioApellido")]
		[XmlElement(ElementName="UsuarioApellido")]
		public string gxTpr_Usuarioapellido
		{
			get {
				return gxTv_SdtSDTUsuario_Usuarioapellido; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuarioapellido = value;
				SetDirty("Usuarioapellido");
			}
		}




		[SoapElement(ElementName="UsuarioNombreCompleto")]
		[XmlElement(ElementName="UsuarioNombreCompleto")]
		public string gxTpr_Usuarionombrecompleto
		{
			get {
				return gxTv_SdtSDTUsuario_Usuarionombrecompleto; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuarionombrecompleto = value;
				SetDirty("Usuarionombrecompleto");
			}
		}




		[SoapElement(ElementName="PuestoID")]
		[XmlElement(ElementName="PuestoID")]
		public int gxTpr_Puestoid
		{
			get {
				return gxTv_SdtSDTUsuario_Puestoid; 
			}
			set {
				gxTv_SdtSDTUsuario_Puestoid = value;
				SetDirty("Puestoid");
			}
		}




		[SoapElement(ElementName="PuestoDescripcion")]
		[XmlElement(ElementName="PuestoDescripcion")]
		public string gxTpr_Puestodescripcion
		{
			get {
				return gxTv_SdtSDTUsuario_Puestodescripcion; 
			}
			set {
				gxTv_SdtSDTUsuario_Puestodescripcion = value;
				SetDirty("Puestodescripcion");
			}
		}




		[SoapElement(ElementName="UsuarioGenero")]
		[XmlElement(ElementName="UsuarioGenero")]
		public string gxTpr_Usuariogenero
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariogenero; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariogenero = value;
				SetDirty("Usuariogenero");
			}
		}




		[SoapElement(ElementName="UsuarioDirectoAsociado")]
		[XmlElement(ElementName="UsuarioDirectoAsociado")]
		public string gxTpr_Usuariodirectoasociado
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariodirectoasociado; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariodirectoasociado = value;
				SetDirty("Usuariodirectoasociado");
			}
		}




		[SoapElement(ElementName="UsuarioRazonSocialAsociado")]
		[XmlElement(ElementName="UsuarioRazonSocialAsociado")]
		public string gxTpr_Usuariorazonsocialasociado
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariorazonsocialasociado; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariorazonsocialasociado = value;
				SetDirty("Usuariorazonsocialasociado");
			}
		}




		[SoapElement(ElementName="UsuarioNombreComercial")]
		[XmlElement(ElementName="UsuarioNombreComercial")]
		public string gxTpr_Usuarionombrecomercial
		{
			get {
				return gxTv_SdtSDTUsuario_Usuarionombrecomercial; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuarionombrecomercial = value;
				SetDirty("Usuarionombrecomercial");
			}
		}



		[SoapElement(ElementName="UsuarioFechaNacimiento")]
		[XmlElement(ElementName="UsuarioFechaNacimiento" , IsNullable=true)]
		public string gxTpr_Usuariofechanacimiento_Nullable
		{
			get {
				if ( gxTv_SdtSDTUsuario_Usuariofechanacimiento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTUsuario_Usuariofechanacimiento).value ;
			}
			set {
				gxTv_SdtSDTUsuario_Usuariofechanacimiento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Usuariofechanacimiento
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariofechanacimiento; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariofechanacimiento = value;
				SetDirty("Usuariofechanacimiento");
			}
		}



		[SoapElement(ElementName="UsuarioCalleNum")]
		[XmlElement(ElementName="UsuarioCalleNum")]
		public string gxTpr_Usuariocallenum
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariocallenum; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariocallenum = value;
				SetDirty("Usuariocallenum");
			}
		}




		[SoapElement(ElementName="UsuarioColonia")]
		[XmlElement(ElementName="UsuarioColonia")]
		public string gxTpr_Usuariocolonia
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariocolonia; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariocolonia = value;
				SetDirty("Usuariocolonia");
			}
		}




		[SoapElement(ElementName="UsuarioDelegacion")]
		[XmlElement(ElementName="UsuarioDelegacion")]
		public string gxTpr_Usuariodelegacion
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariodelegacion; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariodelegacion = value;
				SetDirty("Usuariodelegacion");
			}
		}




		[SoapElement(ElementName="UsuarioCP")]
		[XmlElement(ElementName="UsuarioCP")]
		public int gxTpr_Usuariocp
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariocp; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariocp = value;
				SetDirty("Usuariocp");
			}
		}




		[SoapElement(ElementName="UsuarioZona")]
		[XmlElement(ElementName="UsuarioZona")]
		public string gxTpr_Usuariozona
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariozona; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariozona = value;
				SetDirty("Usuariozona");
			}
		}




		[SoapElement(ElementName="UsuarioCelular")]
		[XmlElement(ElementName="UsuarioCelular")]
		public long gxTpr_Usuariocelular
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariocelular; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariocelular = value;
				SetDirty("Usuariocelular");
			}
		}




		[SoapElement(ElementName="UsuarioTelefonoSucursal")]
		[XmlElement(ElementName="UsuarioTelefonoSucursal")]
		public long gxTpr_Usuariotelefonosucursal
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariotelefonosucursal; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariotelefonosucursal = value;
				SetDirty("Usuariotelefonosucursal");
			}
		}




		[SoapElement(ElementName="PaisID")]
		[XmlElement(ElementName="PaisID")]
		public int gxTpr_Paisid
		{
			get {
				return gxTv_SdtSDTUsuario_Paisid; 
			}
			set {
				gxTv_SdtSDTUsuario_Paisid = value;
				SetDirty("Paisid");
			}
		}




		[SoapElement(ElementName="PaisDescripcion")]
		[XmlElement(ElementName="PaisDescripcion")]
		public string gxTpr_Paisdescripcion
		{
			get {
				return gxTv_SdtSDTUsuario_Paisdescripcion; 
			}
			set {
				gxTv_SdtSDTUsuario_Paisdescripcion = value;
				SetDirty("Paisdescripcion");
			}
		}




		[SoapElement(ElementName="EstadoID")]
		[XmlElement(ElementName="EstadoID")]
		public int gxTpr_Estadoid
		{
			get {
				return gxTv_SdtSDTUsuario_Estadoid; 
			}
			set {
				gxTv_SdtSDTUsuario_Estadoid = value;
				SetDirty("Estadoid");
			}
		}




		[SoapElement(ElementName="EstadoDescripcion")]
		[XmlElement(ElementName="EstadoDescripcion")]
		public string gxTpr_Estadodescripcion
		{
			get {
				return gxTv_SdtSDTUsuario_Estadodescripcion; 
			}
			set {
				gxTv_SdtSDTUsuario_Estadodescripcion = value;
				SetDirty("Estadodescripcion");
			}
		}




		[SoapElement(ElementName="CiudadID")]
		[XmlElement(ElementName="CiudadID")]
		public int gxTpr_Ciudadid
		{
			get {
				return gxTv_SdtSDTUsuario_Ciudadid; 
			}
			set {
				gxTv_SdtSDTUsuario_Ciudadid = value;
				SetDirty("Ciudadid");
			}
		}




		[SoapElement(ElementName="CiudadDescripcion")]
		[XmlElement(ElementName="CiudadDescripcion")]
		public string gxTpr_Ciudaddescripcion
		{
			get {
				return gxTv_SdtSDTUsuario_Ciudaddescripcion; 
			}
			set {
				gxTv_SdtSDTUsuario_Ciudaddescripcion = value;
				SetDirty("Ciudaddescripcion");
			}
		}




		[SoapElement(ElementName="UsuarioSucursal")]
		[XmlElement(ElementName="UsuarioSucursal")]
		public string gxTpr_Usuariosucursal
		{
			get {
				return gxTv_SdtSDTUsuario_Usuariosucursal; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuariosucursal = value;
				SetDirty("Usuariosucursal");
			}
		}




		[SoapElement(ElementName="UsuarioProducto")]
		[XmlElement(ElementName="UsuarioProducto")]
		public string gxTpr_Usuarioproducto
		{
			get {
				return gxTv_SdtSDTUsuario_Usuarioproducto; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuarioproducto = value;
				SetDirty("Usuarioproducto");
			}
		}




		[SoapElement(ElementName="UsuarioAvisoPrivacidad")]
		[XmlElement(ElementName="UsuarioAvisoPrivacidad")]
		public bool gxTpr_Usuarioavisoprivacidad
		{
			get {
				return gxTv_SdtSDTUsuario_Usuarioavisoprivacidad; 
			}
			set {
				gxTv_SdtSDTUsuario_Usuarioavisoprivacidad = value;
				SetDirty("Usuarioavisoprivacidad");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTUsuario_Usuarionombre = "";
			gxTv_SdtSDTUsuario_Usuariocorreo = "";
			gxTv_SdtSDTUsuario_Usuariorol = "";
			gxTv_SdtSDTUsuario_Usuarioapellido = "";
			gxTv_SdtSDTUsuario_Usuarionombrecompleto = "";

			gxTv_SdtSDTUsuario_Puestodescripcion = "";
			gxTv_SdtSDTUsuario_Usuariogenero = "";
			gxTv_SdtSDTUsuario_Usuariodirectoasociado = "";
			gxTv_SdtSDTUsuario_Usuariorazonsocialasociado = "";
			gxTv_SdtSDTUsuario_Usuarionombrecomercial = "";

			gxTv_SdtSDTUsuario_Usuariocallenum = "";
			gxTv_SdtSDTUsuario_Usuariocolonia = "";
			gxTv_SdtSDTUsuario_Usuariodelegacion = "";

			gxTv_SdtSDTUsuario_Usuariozona = "";



			gxTv_SdtSDTUsuario_Paisdescripcion = "";

			gxTv_SdtSDTUsuario_Estadodescripcion = "";

			gxTv_SdtSDTUsuario_Ciudaddescripcion = "";
			gxTv_SdtSDTUsuario_Usuariosucursal = "";
			gxTv_SdtSDTUsuario_Usuarioproducto = "";
			gxTv_SdtSDTUsuario_Usuarioavisoprivacidad = false;
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected int gxTv_SdtSDTUsuario_Usuarioid;
		 

		protected string gxTv_SdtSDTUsuario_Usuarionombre;
		 

		protected string gxTv_SdtSDTUsuario_Usuariocorreo;
		 

		protected string gxTv_SdtSDTUsuario_Usuariorol;
		 

		protected string gxTv_SdtSDTUsuario_Usuarioapellido;
		 

		protected string gxTv_SdtSDTUsuario_Usuarionombrecompleto;
		 

		protected int gxTv_SdtSDTUsuario_Puestoid;
		 

		protected string gxTv_SdtSDTUsuario_Puestodescripcion;
		 

		protected string gxTv_SdtSDTUsuario_Usuariogenero;
		 

		protected string gxTv_SdtSDTUsuario_Usuariodirectoasociado;
		 

		protected string gxTv_SdtSDTUsuario_Usuariorazonsocialasociado;
		 

		protected string gxTv_SdtSDTUsuario_Usuarionombrecomercial;
		 

		protected DateTime gxTv_SdtSDTUsuario_Usuariofechanacimiento;
		 

		protected string gxTv_SdtSDTUsuario_Usuariocallenum;
		 

		protected string gxTv_SdtSDTUsuario_Usuariocolonia;
		 

		protected string gxTv_SdtSDTUsuario_Usuariodelegacion;
		 

		protected int gxTv_SdtSDTUsuario_Usuariocp;
		 

		protected string gxTv_SdtSDTUsuario_Usuariozona;
		 

		protected long gxTv_SdtSDTUsuario_Usuariocelular;
		 

		protected long gxTv_SdtSDTUsuario_Usuariotelefonosucursal;
		 

		protected int gxTv_SdtSDTUsuario_Paisid;
		 

		protected string gxTv_SdtSDTUsuario_Paisdescripcion;
		 

		protected int gxTv_SdtSDTUsuario_Estadoid;
		 

		protected string gxTv_SdtSDTUsuario_Estadodescripcion;
		 

		protected int gxTv_SdtSDTUsuario_Ciudadid;
		 

		protected string gxTv_SdtSDTUsuario_Ciudaddescripcion;
		 

		protected string gxTv_SdtSDTUsuario_Usuariosucursal;
		 

		protected string gxTv_SdtSDTUsuario_Usuarioproducto;
		 

		protected bool gxTv_SdtSDTUsuario_Usuarioavisoprivacidad;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTUsuario", Namespace="Premios")]
	public class SdtSDTUsuario_RESTInterface : GxGenericCollectionItem<SdtSDTUsuario>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTUsuario_RESTInterface( ) : base()
		{	
		}

		public SdtSDTUsuario_RESTInterface( SdtSDTUsuario psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="UsuarioID", Order=0)]
		public  string gxTpr_Usuarioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Usuarioid, 9, 0));

			}
			set { 
				sdt.gxTpr_Usuarioid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="UsuarioNombre", Order=1)]
		public  string gxTpr_Usuarionombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuarionombre);

			}
			set { 
				 sdt.gxTpr_Usuarionombre = value;
			}
		}

		[DataMember(Name="UsuarioCorreo", Order=2)]
		public  string gxTpr_Usuariocorreo
		{
			get { 
				return sdt.gxTpr_Usuariocorreo;

			}
			set { 
				 sdt.gxTpr_Usuariocorreo = value;
			}
		}

		[DataMember(Name="UsuarioRol", Order=3)]
		public  string gxTpr_Usuariorol
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariorol);

			}
			set { 
				 sdt.gxTpr_Usuariorol = value;
			}
		}

		[DataMember(Name="UsuarioApellido", Order=4)]
		public  string gxTpr_Usuarioapellido
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuarioapellido);

			}
			set { 
				 sdt.gxTpr_Usuarioapellido = value;
			}
		}

		[DataMember(Name="UsuarioNombreCompleto", Order=5)]
		public  string gxTpr_Usuarionombrecompleto
		{
			get { 
				return sdt.gxTpr_Usuarionombrecompleto;

			}
			set { 
				 sdt.gxTpr_Usuarionombrecompleto = value;
			}
		}

		[DataMember(Name="PuestoID", Order=6)]
		public  string gxTpr_Puestoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Puestoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Puestoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PuestoDescripcion", Order=7)]
		public  string gxTpr_Puestodescripcion
		{
			get { 
				return sdt.gxTpr_Puestodescripcion;

			}
			set { 
				 sdt.gxTpr_Puestodescripcion = value;
			}
		}

		[DataMember(Name="UsuarioGenero", Order=8)]
		public  string gxTpr_Usuariogenero
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariogenero);

			}
			set { 
				 sdt.gxTpr_Usuariogenero = value;
			}
		}

		[DataMember(Name="UsuarioDirectoAsociado", Order=9)]
		public  string gxTpr_Usuariodirectoasociado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariodirectoasociado);

			}
			set { 
				 sdt.gxTpr_Usuariodirectoasociado = value;
			}
		}

		[DataMember(Name="UsuarioRazonSocialAsociado", Order=10)]
		public  string gxTpr_Usuariorazonsocialasociado
		{
			get { 
				return sdt.gxTpr_Usuariorazonsocialasociado;

			}
			set { 
				 sdt.gxTpr_Usuariorazonsocialasociado = value;
			}
		}

		[DataMember(Name="UsuarioNombreComercial", Order=11)]
		public  string gxTpr_Usuarionombrecomercial
		{
			get { 
				return sdt.gxTpr_Usuarionombrecomercial;

			}
			set { 
				 sdt.gxTpr_Usuarionombrecomercial = value;
			}
		}

		[DataMember(Name="UsuarioFechaNacimiento", Order=12)]
		public  string gxTpr_Usuariofechanacimiento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Usuariofechanacimiento);

			}
			set { 
				sdt.gxTpr_Usuariofechanacimiento = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="UsuarioCalleNum", Order=13)]
		public  string gxTpr_Usuariocallenum
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariocallenum);

			}
			set { 
				 sdt.gxTpr_Usuariocallenum = value;
			}
		}

		[DataMember(Name="UsuarioColonia", Order=14)]
		public  string gxTpr_Usuariocolonia
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariocolonia);

			}
			set { 
				 sdt.gxTpr_Usuariocolonia = value;
			}
		}

		[DataMember(Name="UsuarioDelegacion", Order=15)]
		public  string gxTpr_Usuariodelegacion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariodelegacion);

			}
			set { 
				 sdt.gxTpr_Usuariodelegacion = value;
			}
		}

		[DataMember(Name="UsuarioCP", Order=16)]
		public int gxTpr_Usuariocp
		{
			get { 
				return sdt.gxTpr_Usuariocp;

			}
			set { 
				sdt.gxTpr_Usuariocp = value;
			}
		}

		[DataMember(Name="UsuarioZona", Order=17)]
		public  string gxTpr_Usuariozona
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariozona);

			}
			set { 
				 sdt.gxTpr_Usuariozona = value;
			}
		}

		[DataMember(Name="UsuarioCelular", Order=18)]
		public  string gxTpr_Usuariocelular
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Usuariocelular, 10, 0));

			}
			set { 
				sdt.gxTpr_Usuariocelular = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="UsuarioTelefonoSucursal", Order=19)]
		public  string gxTpr_Usuariotelefonosucursal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Usuariotelefonosucursal, 10, 0));

			}
			set { 
				sdt.gxTpr_Usuariotelefonosucursal = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PaisID", Order=20)]
		public  string gxTpr_Paisid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Paisid, 9, 0));

			}
			set { 
				sdt.gxTpr_Paisid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PaisDescripcion", Order=21)]
		public  string gxTpr_Paisdescripcion
		{
			get { 
				return sdt.gxTpr_Paisdescripcion;

			}
			set { 
				 sdt.gxTpr_Paisdescripcion = value;
			}
		}

		[DataMember(Name="EstadoID", Order=22)]
		public  string gxTpr_Estadoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Estadoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Estadoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="EstadoDescripcion", Order=23)]
		public  string gxTpr_Estadodescripcion
		{
			get { 
				return sdt.gxTpr_Estadodescripcion;

			}
			set { 
				 sdt.gxTpr_Estadodescripcion = value;
			}
		}

		[DataMember(Name="CiudadID", Order=24)]
		public  string gxTpr_Ciudadid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ciudadid, 9, 0));

			}
			set { 
				sdt.gxTpr_Ciudadid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CiudadDescripcion", Order=25)]
		public  string gxTpr_Ciudaddescripcion
		{
			get { 
				return sdt.gxTpr_Ciudaddescripcion;

			}
			set { 
				 sdt.gxTpr_Ciudaddescripcion = value;
			}
		}

		[DataMember(Name="UsuarioSucursal", Order=26)]
		public  string gxTpr_Usuariosucursal
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Usuariosucursal);

			}
			set { 
				 sdt.gxTpr_Usuariosucursal = value;
			}
		}

		[DataMember(Name="UsuarioProducto", Order=27)]
		public  string gxTpr_Usuarioproducto
		{
			get { 
				return sdt.gxTpr_Usuarioproducto;

			}
			set { 
				 sdt.gxTpr_Usuarioproducto = value;
			}
		}

		[DataMember(Name="UsuarioAvisoPrivacidad", Order=28)]
		public bool gxTpr_Usuarioavisoprivacidad
		{
			get { 
				return sdt.gxTpr_Usuarioavisoprivacidad;

			}
			set { 
				sdt.gxTpr_Usuarioavisoprivacidad = value;
			}
		}


		#endregion

		public SdtSDTUsuario sdt
		{
			get { 
				return (SdtSDTUsuario)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDTUsuario() ;
			}
		}
	}
	#endregion
}