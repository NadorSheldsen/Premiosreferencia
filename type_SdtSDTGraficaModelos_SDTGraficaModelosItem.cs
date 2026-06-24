/*
				   File: type_SdtSDTGraficaModelos_SDTGraficaModelosItem
			Description: SDTGraficaModelos
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
	[XmlRoot(ElementName="SDTGraficaModelosItem")]
	[XmlType(TypeName="SDTGraficaModelosItem" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTGraficaModelos_SDTGraficaModelosItem : GxUserType
	{
		public SdtSDTGraficaModelos_SDTGraficaModelosItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTGraficaModelos_SDTGraficaModelosItem_Modelodescripcion = "";

		}

		public SdtSDTGraficaModelos_SDTGraficaModelosItem(IGxContext context)
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
			AddObjectProperty("ModeloDescripcion", gxTpr_Modelodescripcion, false);


			AddObjectProperty("Total", gxTpr_Total, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ModeloDescripcion")]
		[XmlElement(ElementName="ModeloDescripcion")]
		public string gxTpr_Modelodescripcion
		{
			get {
				return gxTv_SdtSDTGraficaModelos_SDTGraficaModelosItem_Modelodescripcion; 
			}
			set {
				gxTv_SdtSDTGraficaModelos_SDTGraficaModelosItem_Modelodescripcion = value;
				SetDirty("Modelodescripcion");
			}
		}



		[SoapElement(ElementName="Total")]
		[XmlElement(ElementName="Total")]
		public string gxTpr_Total_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTGraficaModelos_SDTGraficaModelosItem_Total, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTGraficaModelos_SDTGraficaModelosItem_Total = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Total
		{
			get {
				return gxTv_SdtSDTGraficaModelos_SDTGraficaModelosItem_Total; 
			}
			set {
				gxTv_SdtSDTGraficaModelos_SDTGraficaModelosItem_Total = value;
				SetDirty("Total");
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
			gxTv_SdtSDTGraficaModelos_SDTGraficaModelosItem_Modelodescripcion = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTGraficaModelos_SDTGraficaModelosItem_Modelodescripcion;
		 

		protected decimal gxTv_SdtSDTGraficaModelos_SDTGraficaModelosItem_Total;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTGraficaModelosItem", Namespace="Premios")]
	public class SdtSDTGraficaModelos_SDTGraficaModelosItem_RESTInterface : GxGenericCollectionItem<SdtSDTGraficaModelos_SDTGraficaModelosItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTGraficaModelos_SDTGraficaModelosItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTGraficaModelos_SDTGraficaModelosItem_RESTInterface( SdtSDTGraficaModelos_SDTGraficaModelosItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ModeloDescripcion", Order=0)]
		public  string gxTpr_Modelodescripcion
		{
			get { 
				return sdt.gxTpr_Modelodescripcion;

			}
			set { 
				 sdt.gxTpr_Modelodescripcion = value;
			}
		}

		[DataMember(Name="Total", Order=1)]
		public  string gxTpr_Total
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Total, 10, 2));

			}
			set { 
				sdt.gxTpr_Total =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTGraficaModelos_SDTGraficaModelosItem sdt
		{
			get { 
				return (SdtSDTGraficaModelos_SDTGraficaModelosItem)Sdt;
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
				sdt = new SdtSDTGraficaModelos_SDTGraficaModelosItem() ;
			}
		}
	}
	#endregion
}