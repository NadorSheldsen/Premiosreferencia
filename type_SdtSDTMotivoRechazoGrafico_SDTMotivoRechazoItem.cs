/*
				   File: type_SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem
			Description: SDTMotivoRechazoGrafico
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
	[XmlRoot(ElementName="SDTMotivoRechazoItem")]
	[XmlType(TypeName="SDTMotivoRechazoItem" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem : GxUserType
	{
		public SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_Motivorechazodescripcion = "";

		}

		public SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem(IGxContext context)
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
			AddObjectProperty("MotivoRechazoDescripcion", gxTpr_Motivorechazodescripcion, false);


			AddObjectProperty("Cantidad", gxTpr_Cantidad, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MotivoRechazoDescripcion")]
		[XmlElement(ElementName="MotivoRechazoDescripcion")]
		public string gxTpr_Motivorechazodescripcion
		{
			get {
				return gxTv_SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_Motivorechazodescripcion; 
			}
			set {
				gxTv_SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_Motivorechazodescripcion = value;
				SetDirty("Motivorechazodescripcion");
			}
		}




		[SoapElement(ElementName="Cantidad")]
		[XmlElement(ElementName="Cantidad")]
		public long gxTpr_Cantidad
		{
			get {
				return gxTv_SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_Cantidad; 
			}
			set {
				gxTv_SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_Cantidad = value;
				SetDirty("Cantidad");
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
			gxTv_SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_Motivorechazodescripcion = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_Motivorechazodescripcion;
		 

		protected long gxTv_SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_Cantidad;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTMotivoRechazoItem", Namespace="Premios")]
	public class SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_RESTInterface : GxGenericCollectionItem<SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem_RESTInterface( SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MotivoRechazoDescripcion", Order=0)]
		public  string gxTpr_Motivorechazodescripcion
		{
			get { 
				return sdt.gxTpr_Motivorechazodescripcion;

			}
			set { 
				 sdt.gxTpr_Motivorechazodescripcion = value;
			}
		}

		[DataMember(Name="Cantidad", Order=1)]
		public  string gxTpr_Cantidad
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Cantidad, 10, 0));

			}
			set { 
				sdt.gxTpr_Cantidad = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem sdt
		{
			get { 
				return (SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem)Sdt;
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
				sdt = new SdtSDTMotivoRechazoGrafico_SDTMotivoRechazoItem() ;
			}
		}
	}
	#endregion
}