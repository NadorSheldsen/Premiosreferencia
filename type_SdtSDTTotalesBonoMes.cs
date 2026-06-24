/*
				   File: type_SdtSDTTotalesBonoMes
			Description: SDTTotalesBonoMes
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
	[XmlRoot(ElementName="SDTTotalesBonoMes")]
	[XmlType(TypeName="SDTTotalesBonoMes" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTTotalesBonoMes : GxUserType
	{
		public SdtSDTTotalesBonoMes( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTTotalesBonoMes(IGxContext context)
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
			AddObjectProperty("MontoAprobado", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Montoaprobado, 18, 2)), false);


			AddObjectProperty("MontoRechazado", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Montorechazado, 18, 2)), false);


			AddObjectProperty("MontoEnProceso", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Montoenproceso, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MontoAprobado")]
		[XmlElement(ElementName="MontoAprobado")]
		public string gxTpr_Montoaprobado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTTotalesBonoMes_Montoaprobado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTTotalesBonoMes_Montoaprobado = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Montoaprobado
		{
			get {
				return gxTv_SdtSDTTotalesBonoMes_Montoaprobado; 
			}
			set {
				gxTv_SdtSDTTotalesBonoMes_Montoaprobado = value;
				SetDirty("Montoaprobado");
			}
		}



		[SoapElement(ElementName="MontoRechazado")]
		[XmlElement(ElementName="MontoRechazado")]
		public string gxTpr_Montorechazado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTTotalesBonoMes_Montorechazado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTTotalesBonoMes_Montorechazado = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Montorechazado
		{
			get {
				return gxTv_SdtSDTTotalesBonoMes_Montorechazado; 
			}
			set {
				gxTv_SdtSDTTotalesBonoMes_Montorechazado = value;
				SetDirty("Montorechazado");
			}
		}



		[SoapElement(ElementName="MontoEnProceso")]
		[XmlElement(ElementName="MontoEnProceso")]
		public string gxTpr_Montoenproceso_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTTotalesBonoMes_Montoenproceso, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTTotalesBonoMes_Montoenproceso = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Montoenproceso
		{
			get {
				return gxTv_SdtSDTTotalesBonoMes_Montoenproceso; 
			}
			set {
				gxTv_SdtSDTTotalesBonoMes_Montoenproceso = value;
				SetDirty("Montoenproceso");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSDTTotalesBonoMes_Montoaprobado;
		 

		protected decimal gxTv_SdtSDTTotalesBonoMes_Montorechazado;
		 

		protected decimal gxTv_SdtSDTTotalesBonoMes_Montoenproceso;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTTotalesBonoMes", Namespace="Premios")]
	public class SdtSDTTotalesBonoMes_RESTInterface : GxGenericCollectionItem<SdtSDTTotalesBonoMes>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTTotalesBonoMes_RESTInterface( ) : base()
		{	
		}

		public SdtSDTTotalesBonoMes_RESTInterface( SdtSDTTotalesBonoMes psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MontoAprobado", Order=0)]
		public  string gxTpr_Montoaprobado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Montoaprobado, 18, 2));

			}
			set { 
				sdt.gxTpr_Montoaprobado =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MontoRechazado", Order=1)]
		public  string gxTpr_Montorechazado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Montorechazado, 18, 2));

			}
			set { 
				sdt.gxTpr_Montorechazado =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MontoEnProceso", Order=2)]
		public  string gxTpr_Montoenproceso
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Montoenproceso, 18, 2));

			}
			set { 
				sdt.gxTpr_Montoenproceso =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTTotalesBonoMes sdt
		{
			get { 
				return (SdtSDTTotalesBonoMes)Sdt;
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
				sdt = new SdtSDTTotalesBonoMes() ;
			}
		}
	}
	#endregion
}