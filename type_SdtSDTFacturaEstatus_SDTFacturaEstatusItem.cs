/*
				   File: type_SdtSDTFacturaEstatus_SDTFacturaEstatusItem
			Description: SDTFacturaEstatus
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
	[XmlRoot(ElementName="SDTFacturaEstatusItem")]
	[XmlType(TypeName="SDTFacturaEstatusItem" , Namespace="Premios" )]
	[Serializable]
	public class SdtSDTFacturaEstatus_SDTFacturaEstatusItem : GxUserType
	{
		public SdtSDTFacturaEstatus_SDTFacturaEstatusItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTFacturaEstatus_SDTFacturaEstatusItem_Estatus = "";

		}

		public SdtSDTFacturaEstatus_SDTFacturaEstatusItem(IGxContext context)
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
			AddObjectProperty("Estatus", gxTpr_Estatus, false);


			AddObjectProperty("Cantidad", gxTpr_Cantidad, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Estatus")]
		[XmlElement(ElementName="Estatus")]
		public string gxTpr_Estatus
		{
			get {
				return gxTv_SdtSDTFacturaEstatus_SDTFacturaEstatusItem_Estatus; 
			}
			set {
				gxTv_SdtSDTFacturaEstatus_SDTFacturaEstatusItem_Estatus = value;
				SetDirty("Estatus");
			}
		}




		[SoapElement(ElementName="Cantidad")]
		[XmlElement(ElementName="Cantidad")]
		public long gxTpr_Cantidad
		{
			get {
				return gxTv_SdtSDTFacturaEstatus_SDTFacturaEstatusItem_Cantidad; 
			}
			set {
				gxTv_SdtSDTFacturaEstatus_SDTFacturaEstatusItem_Cantidad = value;
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
			gxTv_SdtSDTFacturaEstatus_SDTFacturaEstatusItem_Estatus = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTFacturaEstatus_SDTFacturaEstatusItem_Estatus;
		 

		protected long gxTv_SdtSDTFacturaEstatus_SDTFacturaEstatusItem_Cantidad;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTFacturaEstatusItem", Namespace="Premios")]
	public class SdtSDTFacturaEstatus_SDTFacturaEstatusItem_RESTInterface : GxGenericCollectionItem<SdtSDTFacturaEstatus_SDTFacturaEstatusItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTFacturaEstatus_SDTFacturaEstatusItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTFacturaEstatus_SDTFacturaEstatusItem_RESTInterface( SdtSDTFacturaEstatus_SDTFacturaEstatusItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Estatus", Order=0)]
		public  string gxTpr_Estatus
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estatus);

			}
			set { 
				 sdt.gxTpr_Estatus = value;
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

		public SdtSDTFacturaEstatus_SDTFacturaEstatusItem sdt
		{
			get { 
				return (SdtSDTFacturaEstatus_SDTFacturaEstatusItem)Sdt;
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
				sdt = new SdtSDTFacturaEstatus_SDTFacturaEstatusItem() ;
			}
		}
	}
	#endregion
}