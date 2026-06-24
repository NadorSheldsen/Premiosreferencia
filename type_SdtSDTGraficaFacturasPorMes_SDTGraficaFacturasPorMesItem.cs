/*
				   File: type_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem
			Description: SDTGraficaFacturasPorMes
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
	[XmlRoot(ElementName="SDTGraficaFacturasPorMesItem")]
	[XmlType(TypeName="SDTGraficaFacturasPorMesItem" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem : GxUserType
	{
		public SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Mes = "";

		}

		public SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem(IGxContext context)
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
			AddObjectProperty("Mes", gxTpr_Mes, false);


			AddObjectProperty("MontoAprobada", gxTpr_Montoaprobada, false);


			AddObjectProperty("MontoRechazada", gxTpr_Montorechazada, false);


			AddObjectProperty("MontoEnProceso", gxTpr_Montoenproceso, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Mes")]
		[XmlElement(ElementName="Mes")]
		public string gxTpr_Mes
		{
			get {
				return gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Mes; 
			}
			set {
				gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Mes = value;
				SetDirty("Mes");
			}
		}



		[SoapElement(ElementName="MontoAprobada")]
		[XmlElement(ElementName="MontoAprobada")]
		public string gxTpr_Montoaprobada_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montoaprobada, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montoaprobada = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Montoaprobada
		{
			get {
				return gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montoaprobada; 
			}
			set {
				gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montoaprobada = value;
				SetDirty("Montoaprobada");
			}
		}



		[SoapElement(ElementName="MontoRechazada")]
		[XmlElement(ElementName="MontoRechazada")]
		public string gxTpr_Montorechazada_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montorechazada, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montorechazada = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Montorechazada
		{
			get {
				return gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montorechazada; 
			}
			set {
				gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montorechazada = value;
				SetDirty("Montorechazada");
			}
		}



		[SoapElement(ElementName="MontoEnProceso")]
		[XmlElement(ElementName="MontoEnProceso")]
		public string gxTpr_Montoenproceso_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montoenproceso, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montoenproceso = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Montoenproceso
		{
			get {
				return gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montoenproceso; 
			}
			set {
				gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montoenproceso = value;
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
			gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Mes = "";



			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Mes;
		 

		protected decimal gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montoaprobada;
		 

		protected decimal gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montorechazada;
		 

		protected decimal gxTv_SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_Montoenproceso;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTGraficaFacturasPorMesItem", Namespace="Premios")]
	public class SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_RESTInterface : GxGenericCollectionItem<SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem_RESTInterface( SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Mes", Order=0)]
		public  string gxTpr_Mes
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mes);

			}
			set { 
				 sdt.gxTpr_Mes = value;
			}
		}

		[DataMember(Name="MontoAprobada", Order=1)]
		public  string gxTpr_Montoaprobada
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Montoaprobada, 10, 2));

			}
			set { 
				sdt.gxTpr_Montoaprobada =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MontoRechazada", Order=2)]
		public  string gxTpr_Montorechazada
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Montorechazada, 10, 2));

			}
			set { 
				sdt.gxTpr_Montorechazada =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MontoEnProceso", Order=3)]
		public  string gxTpr_Montoenproceso
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Montoenproceso, 10, 2));

			}
			set { 
				sdt.gxTpr_Montoenproceso =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem sdt
		{
			get { 
				return (SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem)Sdt;
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
				sdt = new SdtSDTGraficaFacturasPorMes_SDTGraficaFacturasPorMesItem() ;
			}
		}
	}
	#endregion
}