/*
				   File: type_SdtSDTCambioEstatus_SDTCambioEstatusItem
			Description: SDTCambioEstatus
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
	[XmlRoot(ElementName="SDTCambioEstatusItem")]
	[XmlType(TypeName="SDTCambioEstatusItem" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTCambioEstatus_SDTCambioEstatusItem : GxUserType
	{
		public SdtSDTCambioEstatus_SDTCambioEstatusItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturaestatus = "";

			gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturano = "";

		}

		public SdtSDTCambioEstatus_SDTCambioEstatusItem(IGxContext context)
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
			AddObjectProperty("FacturaID", gxTpr_Facturaid, false);


			AddObjectProperty("FacturaEstatus", gxTpr_Facturaestatus, false);


			AddObjectProperty("MotivoRechazoID", gxTpr_Motivorechazoid, false);


			AddObjectProperty("FacturaNo", gxTpr_Facturano, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="FacturaID")]
		[XmlElement(ElementName="FacturaID")]
		public int gxTpr_Facturaid
		{
			get {
				return gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturaid; 
			}
			set {
				gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturaid = value;
				SetDirty("Facturaid");
			}
		}




		[SoapElement(ElementName="FacturaEstatus")]
		[XmlElement(ElementName="FacturaEstatus")]
		public string gxTpr_Facturaestatus
		{
			get {
				return gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturaestatus; 
			}
			set {
				gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturaestatus = value;
				SetDirty("Facturaestatus");
			}
		}




		[SoapElement(ElementName="MotivoRechazoID")]
		[XmlElement(ElementName="MotivoRechazoID")]
		public int gxTpr_Motivorechazoid
		{
			get {
				return gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Motivorechazoid; 
			}
			set {
				gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Motivorechazoid = value;
				SetDirty("Motivorechazoid");
			}
		}




		[SoapElement(ElementName="FacturaNo")]
		[XmlElement(ElementName="FacturaNo")]
		public string gxTpr_Facturano
		{
			get {
				return gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturano; 
			}
			set {
				gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturano = value;
				SetDirty("Facturano");
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
			init_Facturaestatus();

			gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturano = "";
			return  ;
		}

		private void init_Facturaestatus()
		{
			string gxeval;
			gxeval = "En Proceso";

			gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturaestatus = gxeval;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturaid;
		 

		protected string gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturaestatus;
		 

		protected int gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Motivorechazoid;
		 

		protected string gxTv_SdtSDTCambioEstatus_SDTCambioEstatusItem_Facturano;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTCambioEstatusItem", Namespace="Premios")]
	public class SdtSDTCambioEstatus_SDTCambioEstatusItem_RESTInterface : GxGenericCollectionItem<SdtSDTCambioEstatus_SDTCambioEstatusItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCambioEstatus_SDTCambioEstatusItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCambioEstatus_SDTCambioEstatusItem_RESTInterface( SdtSDTCambioEstatus_SDTCambioEstatusItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="FacturaID", Order=0)]
		public  string gxTpr_Facturaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Facturaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Facturaid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FacturaEstatus", Order=1)]
		public  string gxTpr_Facturaestatus
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Facturaestatus);

			}
			set { 
				 sdt.gxTpr_Facturaestatus = value;
			}
		}

		[DataMember(Name="MotivoRechazoID", Order=2)]
		public  string gxTpr_Motivorechazoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Motivorechazoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Motivorechazoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FacturaNo", Order=3)]
		public  string gxTpr_Facturano
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Facturano);

			}
			set { 
				 sdt.gxTpr_Facturano = value;
			}
		}


		#endregion

		public SdtSDTCambioEstatus_SDTCambioEstatusItem sdt
		{
			get { 
				return (SdtSDTCambioEstatus_SDTCambioEstatusItem)Sdt;
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
				sdt = new SdtSDTCambioEstatus_SDTCambioEstatusItem() ;
			}
		}
	}
	#endregion
}